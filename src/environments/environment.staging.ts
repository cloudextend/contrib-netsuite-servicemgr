export const environment = {
    production: true,
    urls: {
        backend: {
            base: 'https://staging.smartclient.io',

            basicAuth: '/api/netsuite/2.0/auth',
            tbaAuth: '/api/netsuite/2.0/auth',

            loginMethods: '/api/netsuite/2.0/auth/type',
            initiateSSO: '/api/netsuite/2.0/auth/initiate-sso',

            leadCreation: '/integration/salesforce',
            trialActivation: '/license/activateTrial',
            licenseCheck: '/license/check',
        },
        cexlApp: 'https://staging.smartclient.io/netsuite'
    },
    cexlPlanID: 'smartclientee',
};
