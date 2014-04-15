var app = angular.module('MatchTrakrApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar']);

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'home.html',
        controller: 'Page'
    });

    $routeProvider.when('/about', {
        templateUrl: 'about.html',
        controller: 'Page'
    });

    $routeProvider.when('/my-account', {
        templateUrl: 'profile.html',
        controller: 'Profile',
        secured: true
    });

    $routeProvider.when('/forgot-password', {
        templateUrl: 'forgot-password.html',
        controller: 'ForgotPassword'
    });

    $routeProvider.when('/sign-in', {
        templateUrl: 'session-create.html',
        controller: 'SignIn'
    });

    $routeProvider.when('/sign-up', {
        templateUrl: 'user-create.html',
        controller: 'SignUp'
    });

    $routeProvider.when('/404', {
        templateUrl: 'not-found.html',
        controller: 'Page'
    });

    $routeProvider.otherwise({
        redirectTo: '/404'
    });


});