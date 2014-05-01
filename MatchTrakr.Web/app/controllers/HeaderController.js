'use strict';

app.controller('HeaderController', function ($scope, $location, UserService) {
    $scope.user = UserService.getUserData();

    $scope.removeAuth = function () {
        UserService.removeAuthentication();
    };
});