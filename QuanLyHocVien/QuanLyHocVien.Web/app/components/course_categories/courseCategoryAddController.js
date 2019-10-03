(function (app) {
    app.controller('courseCategoryAddController', courseCategoryAddController)

    courseCategoryAddController.$inject = ['apiService', '$scope','notificationService', '$state'];

    function courseCategoryAddController(apiService, $scope, notificationService, $state) {
        $scope.courseCategory = {
            CreatedDate: new Date(),
            Status: true,
            Cate_Name: "Node JS"
        }
    

        $scope.AddCourseCategory = AddCourseCategory;

        function AddCourseCategory() {
            apiService.post('/api/coursecategory/create', $scope.courseCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Cate_Name + 'được thêm mới');
                    $state.go('course_categories');
                }, function (error) {
                    notificationService.displayError('Thêm không thành công');
                });
        }

    } 
})(angular.module('academy.course_categories'));