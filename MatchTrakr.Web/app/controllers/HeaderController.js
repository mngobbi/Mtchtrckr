'use strict';
app.controller('HeaderController', function ($scope, $location, UserService) {
    $scope.user = User.getUserData();



});