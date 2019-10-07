/// <reference path="../../../node_modules/angular/angular.js" />

(function () {
    angular.module('academy.course_categories', ['academy.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('course_categories', {
            url: "/course_categories",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryListView.html",
            controller: "courseCategoryListController"
        }).state('add_course_category', {
            url: "/add_course_category",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryAddView.html",
            controller: "courseCategoryAddController"
        }).state('edit_course_category', {
            url: "/edit_course_category/:Cate_ID",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryEditView.html",
            controller: "courseCategoryEditController"
        });
    }
})();