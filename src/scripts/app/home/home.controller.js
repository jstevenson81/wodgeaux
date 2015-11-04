var App;
(function (App) {
    var Home;
    (function (Home) {
        'use strict';
        var HomeController = (function () {
            function HomeController(auth, store, $location, appConstants) {
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
            HomeController.$inject = ['auth', 'store', '$location', 'app.constants'];
            return HomeController;
        })();
        Home.HomeController = HomeController;
        angular
            .module('app.home')
            .controller('home.controller', HomeController);
    })(Home = App.Home || (App.Home = {}));
})(App || (App = {}));
