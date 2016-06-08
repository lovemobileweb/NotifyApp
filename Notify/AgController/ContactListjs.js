var myApp = angular.module('ContactListApp', ['angularjs-dropdown-multiselect']);
myApp.controller('ContactListController', function ($scope, $http,$window, $filter) {
    $scope.showadd = function () {
        window.location = "/Home/AddContactList";
    }

    $scope.GetInit = function () {
        $http({
            method: 'Get',
            url: '/Home/getcontactList'
        }).success(function (result) {
            $scope.cont = result;

        });
    }

    $scope.GetselectVal = function () {
    $http({
            method: 'Get',
            url: '/Home/GetContactListDetail/' + $scope.con.ListId
        }).success(function (data, status, headers, config) {
            $scope.ContactPropertyList = data;
        })
    }
        
    $scope.GetInitprsn = function () {
        debugger;
        $scope.id = $scope.con.ListId
        $http({
            method: 'Get',
            url: '/Home/getcontactPerson',
            params: { lid: $scope.id }
        }).success(function (result) {
            $scope.cont1 = result;

        });
    }

    // delete contact
    $scope.deleteContactList = function (ListDetailID) {
        if ($window.confirm("Are you sure want to delete this Contact?")) {
            $scope.Message = "You clicked YES.";
            //ListdetailId = $scope.contactlist.ListDetailID;
          //  alert(ListDetailID);
            $http({
                method: 'Get',
                url: '/Home/DeleteContactList',
                params: { listId: JSON.stringify(ListDetailID) }
            }).success(function (data) {
                $('#myModal').hide();
                location.reload();
            })
        } else {
            $scope.Message = "You clicked NO.";
        }
    };

})
