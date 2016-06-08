var myApp = angular.module('myApp', []);


myApp.controller('LoginController', function ($scope, $http, $filter, LoginService)
{



    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;


    $scope.LoginData = {
        Username: '',
        Password: ''
    };
    //Check is Form Valid or Not // Here f1 is our form Name
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });
    $scope.showadd = function () {
        
        
      window.location = "/Account/Forgetpassword";
     
    };

    $scope.recover = function () {
        $scope.Firstname = $scope.email;
        $http({
            method: 'Post',
            url: '/Account/recoverpassword',
            params: { id: $scope.Firstname }
        })
    };

    $scope.Login = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            LoginService.GetUser($scope.LoginData).then(function (d) {
                //alert(d.data.UserName);
                if (d.data.UserName != null) {
                    if (d.data.UserName == $scope.LoginData.Username) {
                        $scope.IsLogedIn = true;
                        $scope.Message = "Successfully login done. Welcome Admin " + d.data.Fullname;
                        $("#btnQueryString")
                        var url = "/Home/index?UserName=" + encodeURIComponent($("#textName").val());

                        window.location.href = url;
                        //$location.path('/Home/index/' + d.data.Fullname);
                    }
                    if (d.data.UserName != $scope.LoginData.Username) {
                        $scope.IsLogedIn = true;
                        $scope.Message = "Successfully login done. Welcome User " + d.data.Fullname;
                        $("#btnQueryString")
                        var url = "/Home/index?UserName=" + encodeURIComponent($("#textName").val());

                        window.location.href = url;
                    }                  
                }
                else if(d.data.ClientUserName != null)
                {
                    if (d.data.ClientUserName == $scope.LoginData.Username) {
                        $scope.IsLogedIn = true;
                        $scope.Message = "Successfully login done. Welcome Client Admin " + d.data.ClientName;
                        $("#btnQueryString")
                        var url = "/Home/index?UserName=" + encodeURIComponent($("#textName").val());

                        window.location.href = url;
                    }
                }
                else {
                    alert('Invalid Credential!');
                }
            });
        }
    };
})

myApp.factory('LoginService', function ($http)
{
    var fac = {};
    fac.GetUser = function (d) {
        return $http({
            url: '/Account/Login',
            method: 'POST',
            data: JSON.stringify(d),
            headers: { 'content-type': 'application/json' }
        });
    };
    return fac;
})

//angular.module('MyApp') // extending from previously created angular module in the First Part
//.controller('LoginController', function ($scope, LoginService) {
//    $scope.IsLogedIn = false;
//    $scope.Message = '';
//    $scope.Submitted = false;
//    $scope.IsFormValid = false;

//    $scope.LoginData = {
//        Username: '',
//        Password: ''
//    };

//    //Check is Form Valid or Not // Here f1 is our form Name
//    $scope.$watch('f1.$valid', function (newVal) {
//        $scope.IsFormValid = newVal;
//    });

//    $scope.Login = function () {
//        $scope.Submitted = true;
//        if ($scope.IsFormValid) {
//            LoginService.GetUser($scope.LoginData).then(function (d) {
//                if (d.data.Username != null) {
//                    if (d.data.Username == "pushpendra") {
//                        $scope.IsLogedIn = true;



//                        $scope.Message = "Successfully login done. Welcome Admin " + d.data.FullName;
//                        $location.path('/employee-details/' + employee.EmployeeNumber);
//                    }
//                    if (d.data.Username != "pushpendra") {
//                        $scope.IsLogedIn = true;
//                        $scope.Message = "Successfully login done. Welcome User " + d.data.FullName;
//                    }

//                }
//                else {
//                    alert('Invalid Credential!');
//                }
//            });
//        }
//    };

//})
//.factory('LoginService', function ($http) {
//    var fac = {};
//    fac.GetUser = function (d) {
//        return $http({
//            url: '/Data/UserLogin',
//            method: 'POST',
//            data: JSON.stringify(d),
//            headers: { 'content-type': 'application/json' }
//        });
//    };
//    return fac;
//});