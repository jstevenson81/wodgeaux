var App;
(function (App) {
    var Login;
    (function (Login) {
        'use strict';
        var LoginController = (function () {
            function LoginController(auth, store, $location) {
                var _this = this;
                this.auth = auth;
                this.store = store;
                this.$location = $location;
                this.login = function () {
                    _this.auth.signin({ sso: false, rememberLastLogin: false }, function (profile, token) {
                        _this.store.set('profile', profile);
                        _this.store.set('token', token);
                        _this.$location.path('/');
                    });
                };
            }
            LoginController.$inject = ['auth', 'store', '$location'];
            return LoginController;
        })();
        Login.LoginController = LoginController;
        angular
            .module('app.login')
            .controller('login.controller', LoginController);
    })(Login = App.Login || (App.Login = {}));
})(App || (App = {}));
//# sourceMappingURL=login.controller.js.map