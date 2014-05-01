'use strict';

var app = angular.module('MatchTrakrApp', ['ui.router', 'ngResource'
    , 'ngCookies'
    , 'ui.bootstrap'
    , 'toaster'
    , 'chieffancypants.loadingBar']);

app.config(function ($stateProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $stateProvider

    .state('home', {
        url: '/',
        templateUrl: 'app/views/home.html'
    })

    .state('profile', {
        url: '/profile',
        templateUrl: 'app/views/profile.html',
        controller: 'ProfileController',
        secured: true
    })

    .state('password', {
        templateUrl: 'app/views/password.html',
        controller: 'PasswordController'
    })

    .state('login', {
        templateUrl: 'app/views/login.html',
        controller: 'LogInController'
    })

    .state('logout', {
        controller: 'LogOutController'
    })

    .state('signup', {
        templateUrl: 'app/views/signup.html',
        controller: 'SignUpController'
    })

    .state('404', {
        url: '/404',
        templateUrl: 'app/views/notfound.html'
    })


    //Data
    .state('complejos', {
        templateUrl: 'app/views/complejos.html',
        controller: 'ComplejosController',
        resolve: {
            user: 'UserService',
            authenticationRequired: function (user) {
                user.isAuthenticated();
            }
        }
    })
});

app.run(function ($rootScope, $state, UserService) {
    try {
        UserService.isAuthenticated();
    } catch (e) {
        //Do nothing 
    }
    $rootScope.$on('$stateChangeError', function (event, toState, toParams, fromState, fromParams, error) {
        if (error.name == 'AuthenticationRequired') {
            UserService.setNextState(toState.name, 'You must login to access this page');
            $state.go('login', {}, { reload: true });
        }
    })
})