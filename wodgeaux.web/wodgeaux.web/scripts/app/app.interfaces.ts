module App {
    'use strict';

    export interface IAuthZeroAngular {
        hookEvents(): void;
        signin(options?: {}, successCallback?: Function, errorCallback?: Function, libName?: string);
    }

    export interface IAuthZeroAuthProvider {
        init(options: IAuthZeroInitOptions);
    }

    export interface IAuthZeroInitOptions {
        domain: string;
        clientID: string;
    }

    export interface IAppConstants {
        localStorage: {
            userProfileStoreName: string;
            authTokenStoreName: string;
        },
        routes: {
            defaultRoute: string;
            user: string;
        }
    }
}