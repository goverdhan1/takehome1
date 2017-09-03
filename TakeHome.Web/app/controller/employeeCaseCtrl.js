'use strict'
app.controller("employeeCaseCtrl", function ($scope, details, $stateParams, $uibModal, $log, $document) {
    $scope.id = $stateParams.id
    details.getEmployee($scope.id).then(function (data) {
        $scope.employee = data.data.employee;
        $scope.empCases = data.data.caseList
    })
    $scope.items = ['item1', 'item2', 'item3'];
    $scope.open = function () {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            component: 'modalComponent',
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });
        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('modal-component dismissed at: ' + new Date());
        });
    };
});

app.component('modalComponent', {
    templateUrl: 'myModalContent.html',
    bindings: {
        resolve: '<',
        close: '&',
        dismiss: '&'
    },
    controller: function () {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            $ctrl.items = $ctrl.resolve.items;
            $ctrl.selected = {
                item: $ctrl.items[0]
            };
        };

        $ctrl.ok = function () {
            $ctrl.close({ $value: $ctrl.selected.item });
        };

        $ctrl.cancel = function () {
            $ctrl.dismiss({ $value: 'cancel' });
        };
    }
});