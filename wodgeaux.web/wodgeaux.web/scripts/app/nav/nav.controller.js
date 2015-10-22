var App;
(function (App) {
    var Nav;
    (function (Nav) {
        'use strict';
        var NavController = (function () {
            function NavController(auth, store, $location, appConstants) {
                var _this = this;
                this.auth = auth;
                this.store = store;
                this.$location = $location;
                this.appConstants = appConstants;
                this.title = 'wodgeaux.com - woderific!';
                this.login = function () {
                    _this.auth.signin({ sso: false, rememberLastLogin: false }, function (profile, token) {
                        _this.store.set(_this.appConstants.localStorage.userProfileStoreName, profile);
                        _this.store.set(_this.appConstants.localStorage.authTokenStoreName, token);
                        _this.$location.path(_this.appConstants.routes.user);
                    });
                };
            }
            NavController.$inject = ['auth', 'store', '$location', 'app.constants'];
            return NavController;
        })();
        Nav.NavController = NavController;
        angular
            .module('app.nav')
            .controller('nav.controller', NavController);
    })(Nav = App.Nav || (App.Nav = {}));
})(App || (App = {}));
