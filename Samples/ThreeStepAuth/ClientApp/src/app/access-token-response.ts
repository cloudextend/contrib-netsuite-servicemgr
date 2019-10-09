export interface AccessTokenResponse {
    token: string;
    tokenSecret: string;
    error: {
        code: string;
        message: string;
    };
}