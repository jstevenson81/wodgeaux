﻿module App.Home {
    'use strict';

    export class HomeController implements IHomeScope {
        static $inject = ['auth', 'store', '$location', 'app.constants'];

        constructor(
            private auth: IAuthZeroAngular,
            private store: ng.a0.storage.IStoreService,
            private $location: ng.ILocationService,
            private appConstants: IAppConstants
        ) { }

        title = 'wodgeaux.com - woderific!';

        login = () => {
            this.auth.signin({ sso: false, rememberLastLogin: false }, (profile: {}, token: string) => {

                this.store.set(this.appConstants.localStorage.userProfileStoreName, profile);
                this.store.set(this.appConstants.localStorage.authTokenStoreName, token);

                this.$location.path(this.appConstants.routes.user);
            });
        }
    }

    angular
        .module('app.home')
        .controller('home.controller', HomeController);
}