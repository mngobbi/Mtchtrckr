var app = angular.module('MatchTrakrApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: 'app/views/home.html',
        controller: 'PageController'
    });

    $routeProvider.when('/profile', {
        templateUrl: 'app/views/profile.html',
        controller: 'ProfileController',
        secured: true
    });

    $routeProvider.when('/password', {
        templateUrl: 'app/views/password.html',
        controller: 'PasswordController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'app/views/login.html',
        controller: 'LogInController'
    });

    $routeProvider.when('/signup', {
        templateUrl: 'app/views/signup.html',
        controller: 'SignUpController'
    });

    $routeProvider.when('/404', {
        templateUrl: 'app/views/notfound.html',
        controller: 'PageController'
    });

    $routeProvider.otherwise({
        redirectTo: 'app/views/404'
    });


    //Data
    $routeProvider.when('/complejos', {
        templateUrl: 'app/views/complejos.html',
        controller: 'ComplejosController'
    });

    // use the HTML5 History API
    //$locationProvider.html5Mode(true);

});