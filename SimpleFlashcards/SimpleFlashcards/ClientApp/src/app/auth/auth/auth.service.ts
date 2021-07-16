import { Injectable, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ManageRole } from '../../value-objects/manage-role';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(public oidcSecurityService: OidcSecurityService) {
  }

  checkPermission(permission: string): Observable<boolean>{
    return this.oidcSecurityService.userData$.pipe(
      map(res => {
        if (res && res.Permission) {
          return (res.Permission as string[]).includes(permission);
        }
        else{
          return false;
        }
      })
    );
  }

  checkManage(): Observable<ManageRole | undefined>{
    return this.oidcSecurityService.userData$.pipe(
      map(res => {
        if (res && res.Permission) {
          const permission = res.Permission as string[];
          if (permission.includes("ManageAllRoles")){
            return ManageRole.manageAllRoles;
          }
          else if(permission.includes("ManageManagers")){
            return ManageRole.manageManagers;
          }
          else if(permission.includes("ManageUsers")){
            return ManageRole.manageUsers;
          }
        }
        return undefined;
      })
    );
  }

  checkLogin(): Observable<boolean>{
    return this.oidcSecurityService.checkAuth();
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }
}
