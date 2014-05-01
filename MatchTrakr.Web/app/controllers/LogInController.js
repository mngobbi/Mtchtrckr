'use strict';

app.controller('LogInController', [ '$scope', '$state', 'UserService', function ($scope, $state, UserService) {

    $scope.username = '';
    $scope.password = '';
    $scope.errors = new Array();
    $scope.buttonEnabled = true;

    function onSuccessfulLogin () {
        $state.go('home');
    };

    function onFailedLogin (error) {
        if (typeof error === 'string' && $scope.errors.indexOf(error) === -1) {
            $scope.errors.push(error);
        }
        $scope.buttonEnabled = true;
    };

    $scope.login = function () {
        $scope.buttonEnabled = false;
        UserService.authenticate($scope.username, $scope.password, onSuccessfulLogin, onFailedLogin);
    };
}]);