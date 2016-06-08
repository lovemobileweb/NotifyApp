var myApp = angular.module('UserApp', []);

myApp.controller('UserController', function ($scope, $http, $filter, $window) {
    $scope.showadd = function () {
        window.location = "/Home/AddUser";
    };
    $scope.BackList = function () {
        window.location = "/Home/User";

    }
    $scope.GetInituser = function () {
        $http({
            method: 'Get',
            url: '/Home/getuserList'
        }).success(function (result) {
            $scope.user = result;

        });
    }

    $scope.submitform = function () {
        var UserModule = {};
        UserModule.RoleId = 3;
        UserModule.UserName = $scope.UserName;
        UserModule.Fullname = $scope.Fullname;
        UserModule.EmailId = $scope.EmailId;
        UserModule.Password = $scope.Password;
        $http({
            method: 'POST',
            url: '/Home/saveUserdata',
            data: JSON.stringify(UserModule)
        }).then(function (response) {
            $scope.value = response.d;
            alert('User has been created successfully!');
            window.location = "/Home/ContactList";
        }, function (error) {

        })
    }
    // edit contact
    $scope.editUserList = function () {
        $scope.usr = this.usr;
        $scope.editMode = true;
        $('#userModel').modal('show');
    };

    $scope.UpdateUser = function () {
        //debugger;
        $scope.id = $scope.User.UserID
        $http({
            method: 'Get',
            url: '/Home/edituserList',
            params: { lid: $scope.id }
        }).success(function (result) {
            $scope.cont1 = result;

        });
    }


    $scope.deleteUserList = function (User) {
        if ($window.confirm("Are you sure want to delete this User?")) {
            $scope.Message = "You clicked YES.";
            //ListdetailId = $scope.contactlist.ListDetailID;
            //  alert(ListDetailID);
            $http({
                method: 'Get',
                url: '/Home/DeleteUserList',
                params: { listId: JSON.stringify(User.UserID) }
            }).success(function (data) {
                $('#myModal').hide();
                location.reload();
            })
        } else {
            $scope.Message = "You clicked NO.";
        }
    };

    $scope.GetInitClientuser = function () {
        $http({
            method: 'Get',
            url: '/Home/getuserList'
        }).success(function (result) {
            $scope.user = result;

        });
    }

});