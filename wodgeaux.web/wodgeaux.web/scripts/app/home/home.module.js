var App;
(function (App) {
    var Home;
    (function (Home) {
        'use strict';
        angular
            .module('app.home', [
            'auth0',
            'angular-storage'
        ]);
    })(Home = App.Home || (App.Home = {}));
})(App || (App = {}));
//# sourceMappingURL=home.module.js.map