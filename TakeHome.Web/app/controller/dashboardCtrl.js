'use strict'
app.controller("dashboardCtrl", function ($scope, details) {
    details.getEmployees().then(function (data) {
        $scope.employees = data.data;
    })

    details.getCases().then(function (data) {
        $scope.cases = data.data;
    })

});