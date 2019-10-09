export interface RequestTokenRespone {
    token: string;
    tokenSecret: string;
    isCallbackConfirmed: boolean;

    error: {
        code: string;
        message: string;
    };
}