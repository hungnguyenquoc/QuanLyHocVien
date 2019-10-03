(function(app) {
    app.controller('courseCategoryListController', courseCategoryListController);

    courseCategoryListController.$inject = ['$scope', 'apiService','notificationService'];

    function courseCategoryListController($scope, apiService, notificationService ) {
        $scope.courseCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCourseCategories = getCourseCategories;
        $scope.keyword = '';
        $scope.search = search;

        function search() {
            getCourseCategories();
        }

        function getCourseCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/coursecategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Not found');
                }
                else {
                    notificationService.displaySuccess("Da tim thay" + result.data.totalCount + "ban ghi");
                }
                $scope.courseCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                Console.log('fail');
            });
        }
        $scope.getCourseCategories();
    }
})(angular.module('academy.course_categories'));


//(function (app) {
//    app.controller('courseCategoryListController', courseCategoryListController);

//    courseCategoryListController.$inject = ['$scope'];

//    function courseCategoryListController($scope) {
//        $scope.courseCategories = [];


//        $scope.getcourseCategories = getCourseCategories;

//        function getCourseCategories() {
//            apiService.get('/api/coursecategory/getall', null, function (result) {
//                $scope.courseCategories = result.data;
//            }, function () {
//                console.log('Load productcategory failed.');
//            });
//        }

//        $scope.getCourseCategories();
//    }
//})(angular.module('academy.course_categories'));

