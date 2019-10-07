//var app = angular.module('academy', ['ui.bootstrap']);

//(function (app) {
//    app.controller('courseCategoryListController', courseCategoryListController);
//    courseCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$uibModal','$uibModalInstance'];

//    function courseCategoryListController($scope, apiService, notificationService, $uibModal, $uibModalInstance) {
//        $scope.courseCategories = [];
//        $scope.page = 0;
//        $scope.pagesCount = 0;
//        $scope.getCourseCategories = getCourseCategories;
//        $scope.keyword = '';
//        $scope.search = search;

//        $scope.openModal = openModal;
//        $scope.ok = ok;
//        $scope.cancel = cancel;



//        function openModal() {
//            var modalInstance = $uibModal.open({
//                templateUrl: "/app/components/course_categories/courseCategoryAddView.html",
//                controller: "courseCategoryAddController",
//                size: '',
//            });

//            modalInstance.result.then(function (response) {
//                $scope.result = `${response} button hitted`;
//            });
//        }

//        function ok() {
//            $uibModalInstance.close("Ok");
//        }
//        function cancel() {
//            $uibModalInstance.dismiss();
//        } 


//        function search() {
//            getCourseCategories();
//        }

//        function getCourseCategories(page) {
//            page = page || 0;
//            var config = {
//                params: {
//                    keyword: $scope.keyword,
//                    page: page,
//                    pageSize: 2
//                }
//            }
//            apiService.get('/api/coursecategory/getall', config, function (result) {
//                if (result.data.TotalCount == 0) {
//                    notificationService.displayWarning('Not found');
//                }
//                else {
//                    notificationService.displaySuccess("Da tim thay" + result.data.totalCount + "ban ghi");
//                }
//                $scope.courseCategories = result.data.Items;
//                $scope.page = result.data.Page;
//                $scope.pagesCount = result.data.TotalPages;
//                $scope.totalCount = result.data.TotalCount;
//            }, function () {
//                Console.log('fail');
//            });
//        }
//        $scope.getCourseCategories();
//        //$scope.openModel();
//    }

//})(angular.module('academy.course_categories'));






















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


