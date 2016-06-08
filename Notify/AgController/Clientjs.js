var myApp = angular.module('ClientApp', []);
myApp.controller('ClientController', function ($scope, $http, $filter,$window, FileUploadService) {
    // Variables
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.clientName, $scope.clientEmail, $scope.Clientusername, $scope.Password).then(function (d) {
                alert(d.Message);
                ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }

    $scope.showadd = function () {
        window.location = "/Home/AddClient";
    }
    $scope.BackList = function () {
        window.location = "/Home/Client";

    }
    clientsrecord();
    function clientsrecord() {
        FileUploadService.GetClients()
        .then(function (response) {
            $scope.clients = response.data;
        })
    }


})
myApp.factory('FileUploadService', function ($http, $q) { // explained abour controller and service in part 2
    var urlBase = '../../api/ClientAPI';
    var fac = {};
    fac.GetClients = function () {
        return $http.get(urlBase);
    }
    fac.deleteclient = function (clientId) {
        return $http.delete(urlBase + '/' + clientId);
    }
    fac.UploadFile = function (file, clientName, clientEmail,ClientuserName,Password) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("clientName", clientName);
        formData.append("clientEmail", clientEmail);
        formData.append("ClientUserName", ClientuserName);
        formData.append("ClientPassword", Password);

        var defer = $q.defer();
        $http.post("/Home/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
          
        })
        .error(function () {
           defer.reject("File Upload succefully!");
        });

        return defer.promise;

    }
    return fac;

});