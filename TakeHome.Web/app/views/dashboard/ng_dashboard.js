'use strict';

angular.module('app', []).config(function () { })

.factory('DashboardService', function ($httpService) {
    return {
        getAllEmployees: function () {
            var Obj = { url: 'api/Employee/GetEmployees' };
            return $httpService.$get(Obj);
        },
        getAllCases: function () {
            var Obj = { url: 'api/EmployeeCases/GetAllCases' };
            return $httpService.$get(Obj);
        },

    };
})


.controller('DashboardCtrl', function ($scope) {

    //TO DO: Write Logic for Dashboard
})

