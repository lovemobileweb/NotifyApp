var ReportApp = angular.module('ReportViewLog', []);

ReportApp.controller('ViewLogController', function ($scope, $http, $filter, $window) {
    $scope.GetInitViewLog = function () {
        $http({
            method: 'Get',
            url: '/Home/GetViewLog'
        }).success(function (result) {
            $scope.Log = result;

        });
    }

    $scope.GetInitViewCallLog = function () {
        $http({
            method: 'Get',
            url: '/Home/GetCallViewLog'
        }).success(function (result) {
            $scope.Log = result;

        });
    }
})