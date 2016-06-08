var app = angular.module('ContactListApp', ['angularjs--multiselect']);
app.controller('ContactListController', ['$scope', '$http', function ($scope, $http) {
    //define object 
    $scope.ContactsSelected= [];
    $scope.Contacts = [];
    $scope.dropdownSetting = {
        scrollable: true,
        scrollableHeight: '200px'
    }
    //fetch data from database for show in multiselect dropdown
    $http.get('/home/getcontacts').then(function (data) {
        angular.forEach(data.data, function (value, index) {
            $scope.Contacts.push({ id: value.Contactid, label: value.FirstName });
        });
    })
    //post or submit selected items from multiselect dropdown to server
    $scope.SubmittedCategories = [];
    $scope.SubmitData = function () {
        var Contactid = [];
        angular.forEach($scope.ContactsSelected, function (value, index) {
            Contactid.push(value.id);
        });

        var data = {
            Contactid: Contactid
        };

        $http({
            method: "POST",
            url: "/Contact/ContactList/Index",
            data: JSON.stringify(data)
        }).then(function (data) {
            $scope.SubmittedCategories = data.data;
        }, function (error) {
            alert('Error');
        })
    }
}])