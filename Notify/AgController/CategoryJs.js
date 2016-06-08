var myApp = angular.module('ContactListApp', ['angularjs-dropdown-multiselect']);
myApp.controller('ContactListController', function ($scope, $http, $filter) {
    $scope.CategoriesSelected = [];
    $scope.Contacts = [];
    $scope.dropdownSetting = {
        scrollable: true,
        scrollableHeight: '200px'
    }

    $scope.BackList = function () {
        window.location = "/Home/ContactList";
    }
    //fetch data from database for show in multiselect dropdown
    $http.get('/Home/getcategories').then(function (data) {
        angular.forEach(data.data, function (value, index) {
            $scope.Contacts.push({ id: value.ContactId, label: value.FirstName });
        });
    })

    //post or submit selected items from multiselect dropdown to server
    $scope.SubmittedCategories = [];
    $scope.SubmitData = function () {
        var contactlistname = $scope.ContactListname;
        var categoryIds = [];
        angular.forEach($scope.CategoriesSelected, function (value, index) {
            categoryIds.push(value.id);
        });
        var data = {
            categoryIds: categoryIds,
            contactlistname: $scope.ContactListname
        };
        $http({
            method: "POST",
            url: "/Home/savedata",
            data: JSON.stringify(data)
        })
            .then(function (response) {
                $scope.value = response.d;
                alert('Inserted ContactList! Success Contact list.');
                window.location = "/Home/ContactList";
            },
          function (error) {
              alert('not inserted sucessfully');

          })
    }

})