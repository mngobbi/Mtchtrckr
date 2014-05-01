'use strict';

app.controller('ComplejosController', ['$scope','$resource',function ($scope, $resource) {
    $scope.complejos = $resource('/api/complejos').query();
}]);