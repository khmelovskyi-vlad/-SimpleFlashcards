using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.RoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleFlashcards.Data.Initializers
{
    public class IdentityInitializer : IIdentityInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public IdentityInitializer(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Run()
        {
            var mainRoleName = "main";
            var rolePermissions = new List<RolePermissions>()
            {
                new RolePermissions()
                {
                    RoleName = mainRoleName,
                    Permissions = new List<ClaimModel>()
                    {
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageAllRoles",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageManagers",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageUsers",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "banIp",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "banUser",
                            ValueType = ClaimValueTypes.String
                        },
                    }
                },
                new RolePermissions()
                {
                    RoleName = "admin",
                    Permissions = new List<ClaimModel>()
                    {
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageManagers",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageUsers",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "banIp",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "banUser",
                            ValueType = ClaimValueTypes.String
                        },
                    }
                },
                new RolePermissions()
                {
                    RoleName = "manager",
                    Permissions = new List<ClaimModel>()
                    {
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "manageUsers",
                            ValueType = ClaimValueTypes.String
                        },
                        new ClaimModel()
                        {
                            Type = "permission",
                            Value = "banUser",
                            ValueType = ClaimValueTypes.String
                        },
                    }
                },
                new RolePermissions()
                {
                    RoleName = "user",
                    Permissions = new List<ClaimModel>(),
                },
                new RolePermissions()
                {
                    RoleName = "guest",
                    Permissions = new List<ClaimModel>(),
                },
            };
            var roles = rolePermissions.Select(rp => rp.RoleName).ToList(); // "main", "admin", "manager", "user", "guest"
            SeedRoles(roles).Wait();
            SeedUser(roles, mainRoleName).Wait();
            SeedPermission(rolePermissions).Wait();
        }
        private async Task SeedRoles(List<string> roles)
        {
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(new ApplicationRole() { Name = role });
            }
        }
        private async Task SeedUser(List<string> roles, string mainRole)
        {
            var email = "initEmail@gmail.com";
            var password = "InitPassword0000-";
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await SeedUserRole(user, mainRole);
            }
        }
        private async Task SeedUserRole(ApplicationUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
        public async Task SeedPermission(List<RolePermissions> rolePermissions)
        {
            foreach (var rolePermission in rolePermissions)
            {
                var role = await _roleManager.FindByNameAsync(rolePermission.RoleName);
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var permission in rolePermission.Permissions)
                {
                    if (!roleClaims.Any(el => el.Type == permission.Type && el.Value == permission.Value && el.ValueType == permission.ValueType))
                    {
                        var claim = new Claim(permission.Type, permission.Value, permission.ValueType);
                        await _roleManager.AddClaimAsync(role, claim);
                    }
                }
            }
        }
    }
}
