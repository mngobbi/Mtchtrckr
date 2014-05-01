'use strict';

app.controller('HeaderController', ['$scope', 'UserService', function ($scope, UserService) {
    $scope.user = UserService.getUserData();
}]);