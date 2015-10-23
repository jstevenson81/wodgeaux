module App.Nav {
    'use strict';

    export class NavController implements INavScope {
        static $inject = ['auth', 'store', '$location', 'app.constants'];

        constructor(
            private auth: IAuthZeroAngular,
            private store: ng.a0.storage.IStoreService,
            private $location: ng.ILocationService,
            private appConstants: IAppConstants
        ) { }

        title = 'wodgeaux.com - woderific!';
        userIsLoggedIn = false;

        login = () => {
            this.auth.signin({ sso: false, rememberLastLogin: false }, (profile: {}, token: string) => {

                this.store.set(this.appConstants.localStorage.userProfileStoreName, profile);
                this.store.set(this.appConstants.localStorage.authTokenStoreName, token);
                this.userIsLoggedIn = true;

                this.$location.path(this.appConstants.routes.user);
            });
        }

        logout = () => {
            this.auth.signout();
            this.store.remove(this.appConstants.localStorage.userProfileStoreName);
            this.store.remove(this.appConstants.localStorage.authTokenStoreName);
            this.userIsLoggedIn = false;

            this.$location.path(this.appConstants.routes.defaultRoute);

        }
    }

    angular
        .module('app.nav')
        .controller('nav.controller', NavController);
}