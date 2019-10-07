
(function (app) {
    app.controller('courseListController', courseListController);

    courseListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function courseListController($scope, apiService, notificationService) {
        $scope.Courses = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCourses = getCourses;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getCourses();
        }
        function getCourses(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/course/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.Courses = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load courses failed.');
            });
        }
        //$scope.getCourses();
    }
})(angular.module('academy.courses'));