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
                this.userIsLoggedIn = false;
                this.login = function () {
                    _this.auth.signin({ sso: false, rememberLastLogin: false }, function (profile, token) {
                        _this.store.set(_this.appConstants.localStorage.userProfileStoreName, profile);
                        _this.store.set(_this.appConstants.localStorage.authTokenStoreName, token);
                        _this.userIsLoggedIn = true;
                        _this.$location.path(_this.appConstants.routes.user);
                    });
                };
                this.logout = function () {
                    _this.auth.signout();
                    _this.store.remove(_this.appConstants.localStorage.userProfileStoreName);
                    _this.store.remove(_this.appConstants.localStorage.authTokenStoreName);
                    _this.userIsLoggedIn = false;
                    _this.$location.path(_this.appConstants.routes.defaultRoute);
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
