import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { GoodRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MainModule } from './main/main.module';
import { NavbarModule } from './navbar/navbar.module';
import { AuthConfigModule } from './auth/auth-config.module';

// import { AuthModule, LogLevel, OidcConfigService } from 'angular-auth-oidc-client';
// export function configureAuth(oidcConfigService: OidcConfigService) {
//   return () =>
//     oidcConfigService.withConfig({
//       stsServer: 'https://localhost:44379',
//       responseType: 'id_token token',
//       redirectUrl: window.location.origin,
//       postLogoutRedirectUri: window.location.origin,
//       silentRenew: true,
//       silentRenewUrl: `${window.location.origin}/silent-renew.html`,
//       clientId: 'angularClient',
//       scope: 'openid profile permissions',
//       logLevel: LogLevel.Debug,
//     });
// }
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    MainModule,
    NavbarModule,

    GoodRoutingModule,

    AuthConfigModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
