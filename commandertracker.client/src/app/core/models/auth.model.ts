export type RegisterRequest = {
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
};

export type LoginRequest = {
    userName: string;
    password: string;
};

export type TokenResponse = {
    token: string;
    expires: Date;
};
