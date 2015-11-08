var App;
(function (App) {
    var User;
    (function (User) {
        'use strict';
        var UserController = (function () {
            function UserController($window) {
                $window.document.title = 'Welcome inside your WOD manager!';
                $('#workouts').kendoComboBox({ filter: 'contains', suggest: true });
                //$('#btn').kendoButton();
            }
            UserController.$inject = ['$window'];
            return UserController;
        })();
        angular
            .module('app.user')
            .controller('user.controller', UserController);
    })(User = App.User || (App.User = {}));
})(App || (App = {}));
