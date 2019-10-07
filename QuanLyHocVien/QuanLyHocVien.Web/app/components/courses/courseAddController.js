(function (app) {
    app.controller('courseAddController', courseAddController);

    courseAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function courseAddController(apiService, $scope, notificationService, $state) {
        $scope.course = {
            CreatedDate: new Date(),
            Status: true
            //Name: "A"
        }

        $scope.AddCourse = AddCourse;

        function AddCourse() {
            apiService.post('api/course/create', $scope.course,
                function (result) {
                    notificationService.displaySuccess(result.data.Cou_Name + ' đã được thêm mới.');
                    $state.go('courses');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
    }

})(angular.module('academy.courses'));