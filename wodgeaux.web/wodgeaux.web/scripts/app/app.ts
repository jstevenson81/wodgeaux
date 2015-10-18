module App {
    'use strict';

    export interface IAuthZeroAngular {
        hookEvents(): void;
        signin(options?: {}, successCallback?: Function, errorCallback?: Function, libName?: string);
    }

    export interface IAuthZeroAuthProvider {
        init(options: {domain: string, clientID: string});
    }

    var run = (auth: IAuthZeroAngular) => {
        auth.hookEvents();
    };

    run.$inject = ['auth'];

    var config = (
        $locationProvider: angular.ILocationProvider,
        authProvider: IAuthZeroAuthProvider) => {

        $locationProvider.html5Mode(true);

        authProvider.init({
            domain: 'jsteve81.auth0.com',
            clientID: 'wycQ91mZPCrX53Wo9uxNPPF4ptREJyeI'
        });
    };

    config.$inject = ['$locationProvider', 'authProvider'];


    angular
        .module('app', [
            // angular modules
            'ngRoute',
            'ngCookies',

            // third party modules
            'angular-storage',
            'angular-jwt',
            'auth0',

            // app modules
            'app.login'
        ])
        .config(config)
        .run(run);
}