'use strict';

app.controller('LogInController', [ '$scope', '$state', 'UserService', function ($scope, $state, UserService) {

    $scope.username = '';
    $scope.password = '';
    $scope.errors = new Array();
    $scope.buttonEnabled = true;
    var nextState = null;

    try {
        nextState = UserService.getNextState();
    } catch (e) {
        nextState = null;
    }

    if (nextState !== null) {
        var nameBuffer = nextState.name + '';
        var errorBuffer = nextState.error + '';
        UserService.clearNextState();
        nextState = {
            name: nameBuffer,
            error: errorBuffer
        };
        if (typeof nextState.error === 'string' && nextState.error !== '' && $scope.errors.indexOf(nextState.error) === -1) {
            $scope.errors.push(nextState.error);
        } else {
            $scope.errors.push('You must be logged in to view this page');
        }
    }

    function onSuccessfulLogin () {
        if (nextState !== null && typeof nextState.name === 'string' && nextState.name !== '') {
            $state.go(nextState.name, nextState.params);
        } else {
            $state.go('home');
        }
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