var App;
(function (App) {
    var Login;
    (function (Login) {
        'use strict';
        angular
            .module('app.login', [
            'auth0',
            'angular-storage'
        ]);
    })(Login = App.Login || (App.Login = {}));
})(App || (App = {}));
//# sourceMappingURL=login.module.js.map