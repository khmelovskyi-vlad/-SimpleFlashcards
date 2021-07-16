import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AuthModule, LogLevel, OidcConfigService } from 'angular-auth-oidc-client';

// export function configureAuth(oidcConfigService: OidcConfigService): () => Promise<any> {
//     return () =>
//         oidcConfigService.withConfig({
//             stsServer: 'https://localhost:59779',
//             redirectUrl: window.location.origin,
//             postLogoutRedirectUri: window.location.origin,
//             clientId: 'please-enter-clientId',
//             scope: 'please-enter-scopes', // 'openid profile ' + your scopes
//             responseType: 'code',
//             silentRenew: true,
//             silentRenewUrl: window.location.origin + '/silent-renew.html',
//             renewTimeBeforeTokenExpiresInSeconds: 10,
//         });
// }
export function configureAuth(oidcConfigService: OidcConfigService): () => Promise<any> {
    return () =>
        oidcConfigService.withConfig({
            stsServer: 'https://localhost:44390',
            responseType: 'id_token token',
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            silentRenew: true,
            silentRenewUrl: window.location.origin + '/silent-renew.html',
            clientId: 'angularClient',
            scope: 'openid profile permissions',
            logLevel: LogLevel.Debug
        });
}

@NgModule({
    imports: [AuthModule.forRoot()],
    exports: [AuthModule],
    providers: [
        OidcConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: configureAuth,
            deps: [OidcConfigService],
            multi: true,
        },
    ],
})
export class AuthConfigModule {}
