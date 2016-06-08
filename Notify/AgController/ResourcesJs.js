var myApp = angular.module('ResourcesApp', []);

myApp.controller('ResourcesController', function ($scope, $http,$window,$filter, Resourcesfactory) {
    $scope.showadd = function () {
        window.location = "/Home/AddResources";
    };
    $scope.BackList = function () {
        window.location = "/Home/Resources";

    }
    getResources()
    function getResources() {
        Resourcesfactory.getResource()
        .then(function (response) {
            $scope.Resources = response.data;
        });
    }
    $scope.submitform = function () {
        var Resources = {};
        Resources.ResoureName = $scope.ResoureName;
        Resources.ResoureDescription = $scope.ResoureDescription;
        Resources.URL = $scope.URL;
        Resources.AccountNumber = $scope.AccountNumber;
        Resources.FirstName = $scope.FirstName;
        Resources.LastName = $scope.LastName;
        Resources.EmailAddress = $scope.EmailAddress;
        Resources.PrimaryPhoneNumber = $scope.PrimaryPhoneNumber;
        Resources.SecondaryPhoneNumber = $scope.SecondaryPhoneNumber;
        Resources.CellPhoneNumber = $scope.CellPhoneNumber;
        Resources.Street = $scope.Street;
        Resources.City = $scope.City;
        Resources.State = $scope.State;
        Resources.ZipCode = $scope.ZipCode;       
        if ($window.confirm("Are you sure want to insert this Resource?")) {
            Resourcesfactory.insertResources(Resources)
            then(function (response) {
                alert('Inserted Contact! Refreshing Contact list.');
                window.location = "/Home/Resources";

            }, function (error) {
                $scope.status = 'Unable to insert Resources: ' + error.message;
            });
        }
        else {
            $scope.Message = "You clicked NO.";
        }
    };

    // edit contact
    $scope.editResources = function () {
        $scope.Resource = this.Resource;
        $scope.editMode = true;
        $('#userModel').modal('show');
    };

    $scope.Cancel = function () {
        window.location = "/Home/Resources";
        getResource();
        $('#userModel').modal('hide');
    }

    //update contact
    $scope.update = function () {
        var custResources = this.Resource;
        Resourcesfactory.updateResources(custResources).success(function (data) {
            custResources.editMode = false;
            alert('Updated Resources! Refreshing Resources list.');
            $('#userModel').modal('hide');
        }).error(function (data) {
            $scope.error = "An Error has occured while Updating user! " + data.ExceptionMessage;
        });
    };

    $scope.deleteResources = function (Resources) {
        if ($window.confirm("Are you sure want to delete this Resource?")) {
            $scope.Message = "You clicked YES.";
            var getData = Resourcesfactory.deleteResources(Resources.ResoureId);
            getData.then(function (msg) {
                getResources();
                //  alert('Resources Deleted');
            }, function (error) {
                //  alert('Error in Deleting Record');
                //  alert('Notification Deleted');
            });
        } else {
            $scope.Message = "You clicked NO.";
        }

    };


})

myApp.factory('Resourcesfactory', function ($http) {
    var urlBase = '../../api/Resources';
    var Resourcesfactory = {};
    Resourcesfactory.getResource = function () {
        return $http.get(urlBase);
    }
    Resourcesfactory.insertResources = function (Resources) {
        return $http.post(urlBase, Resources);
    }
    Resourcesfactory.updateResources = function (Resources) {
        return $http.put(urlBase + '/' + Resources.ResoureId, Resources)

    }
    Resourcesfactory.deleteResources = function (ResoureId) {
        return $http.delete(urlBase + '/' + ResoureId)
    }
    return Resourcesfactory;
});