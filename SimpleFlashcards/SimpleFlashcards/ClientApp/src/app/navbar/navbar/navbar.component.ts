import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ManageRole } from '../../value-objects/manage-role';
import { AuthService } from '../../auth/auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public oidcSecurityService: OidcSecurityService, public authService: AuthService) { 
    this.authService.checkLogin().subscribe((isLogin) => this.isLogin = isLogin);
    this.authService.checkManage().subscribe(manageRole => this.manageRole = manageRole);
  }
  
  isLogin: boolean = false;
  manageRole: ManageRole | undefined;

  ngOnInit(): void {
  }

}
