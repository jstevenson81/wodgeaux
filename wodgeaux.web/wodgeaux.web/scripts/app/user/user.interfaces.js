var App;
(function (App) {
    var User;
    (function (User) {
        'use strict';
        var UserController = (function () {
            function UserController() {
            }
            return UserController;
        })();
        angular
            .module('app.user')
            .controller('user.controller', UserController);
    })(User = App.User || (App.User = {}));
})(App || (App = {}));
//# sourceMappingURL=user.interfaces.js.map