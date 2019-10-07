/// <reference path="../../../node_modules/angular/angular.js" />


(function () {
    angular.module('academy.courses', ['academy.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('courses', {
            url: "/courses",
            parent: 'base',
            templateUrl: "/app/components/courses/courseListView.html",
            controller: "courseListController"
        }).state('course_add', {
            url: "/course_add",
            parent: 'base',
            templateUrl: "/app/components/courses/courseAddView.html",
            controller: "courseAddController"
        }).state('course_edit', {
            url: "/course_edit",
            parent: 'base',
            templateUrl: "app/components/courses/courseEditView.html",
            controller: "courseEditController"
        });
    }
})();