'use strict';

app.controller('LogOutController', ['$state', 'UserService', function ($state, UserService) {
    UserService.removeAuthentication();
    $state.go('home')
}]);