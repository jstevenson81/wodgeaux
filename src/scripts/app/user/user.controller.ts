module App.User {
    'use strict';

    class UserController implements IUserControllerScope {

        static $inject = ['$window'];

        constructor(
            $window: ng.IWindowService
        ) {
            $window.document.title = 'Welcome inside your WOD manager!';
            $('#workouts').kendoComboBox();
        }
    }

    angular
        .module('app.user')
        .controller('user.controller', UserController);
}