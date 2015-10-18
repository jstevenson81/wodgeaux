var App;
(function (App) {
    'use strict';
    var run = function (auth) {
        auth.hookEvents();
    };
    run.$inject = ['auth'];
    var config = function ($locationProvider, authProvider) {
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
})(App || (App = {}));
//# sourceMappingURL=app.js.map