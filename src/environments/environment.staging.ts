export const environment = {
    production: true,
    urls: {
        authAPI: {
            base: 'https://staging.smartclient.io',

            basicAuth: '/api/netsuite/2.0/auth',
            tbaAuth: '/api/netsuite/2.0/auth',

            loginMethods: '/api/netsuite/2.0/auth/type',
            initiateSSO: '/api/netsuite/2.0/auth/initiate-sso'
        },
        cexlApp: 'https://staging.smartclient.io/'
    }
};
