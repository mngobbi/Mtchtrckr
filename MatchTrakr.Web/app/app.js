var app = angular.module('MatchTrakrApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar']);

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'home.html',
        controller: 'PageController'
    });

    $routeProvider.when('/profile', {
        templateUrl: 'profile.html',
        controller: 'ProfileController',
        secured: true
    });

    $routeProvider.when('/password', {
        templateUrl: 'password.html',
        controller: 'PasswordController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'login.html',
        controller: 'LogInController'
    });

    $routeProvider.when('/signup', {
        templateUrl: 'signup.html',
        controller: 'SignUpController'
    });

    $routeProvider.when('/404', {
        templateUrl: 'notfound.html',
        controller: 'PageController'
    });

    $routeProvider.otherwise({
        redirectTo: '/404'
    });


});