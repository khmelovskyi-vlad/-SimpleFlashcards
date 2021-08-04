using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleFlashcards.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Policy = "manageUsers")]
        public async Task<ViewResult> Index()
        {

            var country = new Country() {
                Id = 1,
                Name = "asd"
            };
            var word = new Word() {
                Id = Guid.NewGuid(),
                CountryId = country.Id,
                Value = "word1"
            };
            var word2 = new Word()
            {
                Id = Guid.NewGuid(),
                CountryId = country.Id,
                Value = "word2"
            };
            var translation = new Translation() { 
                WordId1 = word.Id,
                WordId2 = word2.Id
            };
            _context.Countries.Add(country);
            _context.Words.Add(word);
            _context.Words.Add(word2);
            _context.Translations.Add(translation);
            await _context.SaveChangesAsync();
            var words = await _context.Words.ToListAsync();
            var trans = await _context.Translations.Include(t => t.Word1).Include(t => t.Word2).ToListAsync();
            var wordToDel = words.FirstOrDefault(el => el.Value == "word2");
            _context.Words.Remove(wordToDel);
            _context.Translations.RemoveRange(trans.Where(el => el.WordId1 == wordToDel.Id || el.WordId2 == wordToDel.Id));
            await _context.SaveChangesAsync();
            var trans2 = await _context.Translations.Include(t => t.Word1).Include(t => t.Word2).ToListAsync();
            ////var adsasd = await _context.FlashcardWords.Where(el => el.Transcription != "ok").ToListAsync();
            ////_context.FlashcardWords.RemoveRange(adsasd);
            //var country = await _context.Countries.FirstOrDefaultAsync();
            //var flashcard = await _context.Flashcards.FirstOrDefaultAsync();
            //var fl = await _context.Words.FirstOrDefaultAsync(f => f.Transcription == "ok");
            //var flashcardWord1 = new Word() { Id = Guid.NewGuid(), CountryId = country.Id, TParentId = fl.Id };
            ////fl.TranslationParentId = flashcardWord1.Id;
            //_context.Words.Add(flashcardWord1);
            //await _context.SaveChangesAsync();
            //var flashcardWords = await _context.Words.Include(f => f.TParent).ThenInclude(f => f.TParent).Include(f => f.Translations).ThenInclude(f => f.Translations).ToListAsync();

            //var user = await _context.Users.FirstOrDefaultAsync();
            //var userName = User.Identity.Name;
            //var userType = User.Identity.AuthenticationType;
            var roles = await GetRoles();
            return View(roles);
        }
        private async Task<List<RoleModel>> GetRoles()
        {
            List<RoleModel> roleModels = new List<RoleModel>();
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles != null)
            {
                var users = await _userManager.Users.ToListAsync();
                if (users != null)
                {
                    foreach (var role in roles)
                    {
                        List<string> names = new List<string>();
                        foreach (var user in users)
                        {
                            if (await _userManager.IsInRoleAsync(user, role.Name))
                                names.Add(user.UserName);
                        }
                        roleModels.Add(new RoleModel(role, string.Join(", ", names)));
                    }
                }
            }
            return roleModels;
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [Authorize(Policy = "manageAllRoles")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Policy = "manageAllRoles")]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = name });
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        [HttpPost]
        [Authorize(Policy = "manageAllRoles")]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }
        //
        [Authorize(Policy = "manageUsers")]
        public async Task<IActionResult> Update(string id)
        {
            ApplicationRole role = await _roleManager.FindByIdAsync(id);
            if (CheckPermissionsToUpdate(role.Name))
            {
                List<ApplicationUser> members = new List<ApplicationUser>();
                List<ApplicationUser> nonMembers = new List<ApplicationUser>();
                foreach (ApplicationUser user in await _userManager.Users.ToListAsync())
                {
                    var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                    list.Add(user);
                }
                return View(new RoleEdit
                {
                    Role = role,
                    Members = members,
                    NonMembers = nonMembers
                });
            }
            else
            {
                return View("Index", await GetRoles());
            }
        }

        [Authorize(Policy = "manageUsers")]
        public bool CheckPermissionsToUpdate(string roleName)
        {
            if (roleName == "user")
            {
                return true;
            }
            else if (roleName == "manager")
            {
                if (User.Claims.Where(claim => claim.Type == "permission" && claim.Value == "manageManagers").Count() > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (User.Claims.Where(claim => claim.Type == "permission" && claim.Value == "manageAllRoles").Count() > 0)
                {
                    return true;
                }
                return false;
            }
        }
        [HttpPost]
        [Authorize(Policy = "manageUsers")]
        public async Task<IActionResult> Update(RoleModification model)
        {
            if (CheckPermissionsToUpdate(model.RoleName))
            {
                IdentityResult result;
                if (ModelState.IsValid)
                {
                    foreach (string userId in model.AddIds ?? new string[] { })
                    {
                        ApplicationUser user = await _userManager.FindByIdAsync(userId);
                        if (user != null)
                        {
                            result = await _userManager.AddToRoleAsync(user, model.RoleName);
                            if (!result.Succeeded)
                                Errors(result);
                        }
                    }
                    foreach (string userId in model.DeleteIds ?? new string[] { })
                    {
                        ApplicationUser user = await _userManager.FindByIdAsync(userId);
                        if (user != null)
                        {
                            result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                            if (!result.Succeeded)
                                Errors(result);
                        }
                    }
                }

                if (ModelState.IsValid)
                    return RedirectToAction(nameof(Index));
                else
                    return await Update(model.RoleId);
            }
            else
            {
                return View("Index", await GetRoles());
            }
        }
        [Authorize(Policy = "manageAllRoles")]
        public IActionResult CreateClaim() => View();
        [HttpPost]
        [ActionName("CreateClaim")]
        [Authorize(Policy = "manageAllRoles")]
        public async Task<IActionResult> CreateClaim(string claimType, string claimValue, string roleName)
        {
            ApplicationRole role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return RedirectToAction("Index", await GetRoles());
            }
            Claim claim = new Claim(claimType, claimValue, ClaimValueTypes.String);
            IdentityResult result = await _roleManager.AddClaimAsync(role, claim);

            if (result.Succeeded)
                return RedirectToAction("Index", await GetRoles());
            else
                Errors(result);
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "banUser")]
        public async Task<IActionResult> BanUser(BanModification model)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.Users
                    .Where(user => (model.BanIds == null ? false : model.BanIds.Contains(user.Id))
                    || (model.UnbanIds == null ? false : model.UnbanIds.Contains(user.Id)))
                    .ToListAsync() ?? new List<ApplicationUser>();
                var usersToBan = users
                    .Where(user => model.BanIds == null ? false : model.BanIds.Contains(user.Id))
                    .ToList() ?? new List<ApplicationUser>();
                var usersFromBan = users
                    .Where(user => model.UnbanIds == null ? false : model.UnbanIds.Contains(user.Id))
                    .ToList() ?? new List<ApplicationUser>();
                foreach (var user in usersToBan)
                {
                    user.IsInBan = true;
                }
                foreach (var user in usersFromBan)
                {
                    user.IsInBan = false;
                }
                await _context.SaveChangesAsync();
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await BanUser();
        }
        [Authorize(Policy = "banUser")]
        public async Task<IActionResult> BanUser(string emailPart = "")
        {
            var userBanModel = new UserBanModel();
            var bannedUsers = await _context.Users.Where(user => user.IsInBan && user.Email.Contains(emailPart)).Take(10).ToListAsync();
            var noBannedUsers = await _context.Users.Where(user => !user.IsInBan && user.Email.Contains(emailPart)).Take(10).ToListAsync();
            return View(new UserBanModel()
            {
                BannedUsers = bannedUsers,
                NoBannedUsers = noBannedUsers,
            });
        }
        [HttpPost]
        [Authorize(Policy = "banIp")]
        public async Task<IActionResult> BanIp(BanModification model)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.Users
                    .Where(user => (model.BanIds == null ? false : model.BanIds.Contains(user.Id))
                    || (model.UnbanIds == null ? false : model.UnbanIds.Contains(user.Id))).Include(u => u.UserIps).ThenInclude(ui => ui.Ip)
                    .ToListAsync() ?? new List<ApplicationUser>();
                var usersToBan = users
                    .Where(user => model.BanIds == null ? false : model.BanIds.Contains(user.Id))
                    .ToList() ?? new List<ApplicationUser>();
                var usersFromBan = users
                    .Where(user => model.UnbanIds == null ? false : model.UnbanIds.Contains(user.Id))
                    .ToList() ?? new List<ApplicationUser>();
                foreach (var user in usersToBan)
                {
                    user.IsInBan = true;
                    if (user.UserIps != null)
                    {
                        foreach (var userIp in user.UserIps)
                        {
                            userIp.Ip.IsInBan = true;
                        }
                    }
                }
                foreach (var user in usersFromBan)
                {
                    user.IsInBan = false;
                    if (user.UserIps != null)
                    {
                        foreach (var userIp in user.UserIps)
                        {
                            userIp.Ip.IsInBan = false;
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await BanUser();
        }
        [Authorize(Policy = "banIp")]
        public async Task<IActionResult> BanIp(string emailPart = "")
        {
            var userBanModel = new UserBanModel();
            var bannedUsers = await _context.Users.Where(user => user.IsInBan && user.Email.Contains(emailPart)).Take(10).ToListAsync();
            var noBannedUsers = await _context.Users.Where(user => !user.IsInBan && user.Email.Contains(emailPart)).Take(10).ToListAsync();
            return View(new UserBanModel()
            {
                BannedUsers = bannedUsers,
                NoBannedUsers = noBannedUsers,
            });
        }
    }
}
