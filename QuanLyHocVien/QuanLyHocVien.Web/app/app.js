/// <reference path="../node_modules/angular/angular.js" />
(function () {
    angular.module('academy', ['academy.courses', 'academy.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/Admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        //$urlRouterProvider.otherwise('/admin');
        $urlRouterProvider.otherwise('/Admin');
    }
})();