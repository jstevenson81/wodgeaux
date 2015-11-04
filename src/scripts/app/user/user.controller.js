var App;
(function (App) {
    var User;
    (function (User) {
        'use strict';
        var UserController = (function () {
            function UserController($window) {
                $window.document.title = 'Welcome inside your WOD manager!';
                $('#workouts').kendoComboBox();
            }
            UserController.$inject = ['$window'];
            return UserController;
        })();
        angular
            .module('app.user')
            .controller('user.controller', UserController);
    })(User = App.User || (App.User = {}));
})(App || (App = {}));
