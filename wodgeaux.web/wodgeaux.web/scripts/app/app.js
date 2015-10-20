var App;
(function (App) {
    'use strict';
    var constants = {
        localStorage: {
            userProfileStoreName: 'profile',
            authTokenStoreName: 'token'
        },
        routes: {
            defaultRoute: '/',
            user: '/user'
        }
    };
    var run = function (auth) {
        auth.hookEvents();
    };
    run.$inject = ['auth'];
    var config = function ($locationProvider, authProvider, $routeProvider, appConstants) {
        authProvider.init({ domain: 'jsteve81.auth0.com', clientID: 'wycQ91mZPCrX53Wo9uxNPPF4ptREJyeI' });
        $routeProvider
            .when(appConstants.routes.defaultRoute, {
            controllerAs: 'vm',
            controller: 'home.controller',
            templateUrl: '/scripts/app/home/template.htm'
        })
            .when(appConstants.routes.user, {
            controllerAs: 'vm',
            controller: 'user.controller',
            templateUrl: '/scripts/app/user/template.htm'
        });
        $locationProvider.html5Mode(true);
    };
    config.$inject = ['$locationProvider', 'authProvider', '$routeProvider', 'app.constants'];
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
        'app.home'
    ])
        .constant('app.constants', constants)
        .config(config)
        .run(run);
})(App || (App = {}));
//# sourceMappingURL=app.js.map