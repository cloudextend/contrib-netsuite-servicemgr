// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
    production: false,
    urls: {
        authAPI: {
            base: 'https://00a817a2.ap.ngrok.io',

            basicAuth: '/api/netsuite/2.0/auth',
            tbaAuth: '/api/netsuite/2.0/auth',

            loginMethods: '/api/netsuite/2.0/auth/type',
            initiateSSO: '/api/netsuite/2.0/auth/initiate-sso'
        },
        cexlApp: 'https://00a817a2.ap.ngrok.io/'
    }
};
