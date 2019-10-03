(function (app) {
    app.controller('courseCategoryEditController', courseCategoryEditController)

    courseCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function courseCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.courseCategory = {
            CreatedDate: new Date(),
            Status: true
            //Cate_Name: "Node JS"
        }


        $scope.UpdateCourseCategory = UpdateCourseCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.courseCategory.Cate_Alias = commonService.getSeoTitle($scope.courseCategory.Cate_Name);
        }

        function loadCourseCategoryDetail() {
            apiService.get('/api/coursecategory/getbyid' + $stateParams.Cate_ID, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        //function loadCourseCategoryDetail() {
        //    apiService.get('api/coursecategory/getbyid/' + $stateParams.id, null, function (result) {
        //        $scope.courseCategory = result.data;
        //    }, function (error) {
        //        notificationService.displayError(error.data);
        //    });
        //}

        function UpdateCourseCategory() {
            apiService.put('/api/coursecategory/update', $scope.courseCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Cate_Name + 'được cập nhật thành công');
                    $state.go('course_categories');
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công');
                });
        }
        loadCourseCategoryDetail();
    }
})(angular.module('academy.course_categories'));