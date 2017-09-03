'use strict'

app.factory("details", function ($http) {
    return {
        
        getEmployees: function () {
            return $http({
                method: 'GET',
                url: 'api/Employee/GetEmployees'
            })

        },
        getCases: function () {
            return $http({ 
                method: 'GET', 
                url: 'api/EmployeeCases/GetAllCases' 
            })
        },
        getEmployee: function(id){
            return $http({ 
                method: 'GET', 
                url: 'api/EmployeeCases/GetCaseByEmployee/'+id
            })
        }
    }
});
