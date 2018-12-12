export const environment = {
    production: true,
    urls: {
        backend: {
            base: 'https://app.smartclient.io',

            basicAuth: '/api/netsuite/2.0/auth',
            tbaAuth: '/api/netsuite/2.0/auth',

            loginMethods: '/api/netsuite/2.0/auth/type',
            initiateSSO: '/api/netsuite/2.0/auth/initiate-sso',

            leadCreation: '/integration/salesforce',
            trialActivation: '/license/activateTrial',
            licenseCheck: '/license/check',
        },
        cexlApp: 'https://app.smartclient.io/netsuite'
    },
    cexlPlanID: 'excel-smartclient-for-netsuite-enterprise-edition',
};
