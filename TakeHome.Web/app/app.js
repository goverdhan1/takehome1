'use strict'

var app = angular.module("app", ["ui.bootstrap", "ui.router"]);
app.config(function($stateProvider, $urlRouterProvider, $httpProvider) {
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/home");

    // Now set up the states
    $stateProvider
        .state('home', {
            url: "/home",
            templateUrl: "app/views/dashboard.html"
        })
        .state('employeeCase', {
            url:'/employeeCase/{id}',
            templateUrl:"app/views/employeeCase.html"
        })
});
