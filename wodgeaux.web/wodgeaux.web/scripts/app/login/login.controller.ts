module App.Login {
    'use strict';

    export class LoginController {

        static $inject  = ['auth', 'store', '$location'];

        constructor(
            private auth: IAuthZeroAngular,
            private store: ng.a0.storage.IStoreService,
            private $location: ng.ILocationService
            ) { }

        login = () => {
            this.auth.signin({sso: false, rememberLastLogin: false}, (profile: {}, token: string) => {
                this.store.set('profile', profile);
                this.store.set('token', token);

                this.$location.path('/');
            });
        }

    }

    angular
        .module('app.login')
        .controller('login.controller', LoginController);
}