'use strict';

angular.module('app', []).config(function () { })

.factory('EmployeeCaseService', function ($httpService) {
    return {
        getCaseByEmployee: function (id) {
            var Obj = { param: {id: id} , url: 'api/Employee/GetEmployees' };
            return $httpService.$get(Obj);
        },
        getAllCases: function () {
            var Obj = { url: 'api/EmployeeCases/GetAllCases' };
            return $httpService.$get(Obj);
        },

    };
})


.controller('EmployeeCaseCtrl', function ($scope) {

    //TO DO: Write Logic for EmployeeCaseCtrl
})

