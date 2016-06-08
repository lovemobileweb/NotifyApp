var myApp = angular.module('NotificationApp', []);

myApp.controller('NotificationController', function ($scope, $http, $window, $filter, Notificationfactory) {
    $scope.showadd = function () {
        window.location = "/Home/AddNotifications";
    }
    $scope.BackList = function () {
        window.location = "/Home/Notifications";

    }
    notificationsrecord()
    function notificationsrecord() {
        Notificationfactory.getnotification()
        .then(function (response) {
            $scope.notifications = response.data;
        })
    }
    $scope.submitform = function () {
        var notifications = {};
        notifications.TemplateName = $scope.TemplateName;
        notifications.NotificationMessage = $scope.NotificationMessage;
        notifications.NotificationType = $scope.NotificationType;
        if (notifications.NotificationType == "Email") { notifications.TypeId = '1'; }
        if (notifications.NotificationType == "SMS") { notifications.TypeId = '2'; }
        if (notifications.NotificationType == "Voice Call") { notifications.TypeId = '3'; }
        notifications.Status = true;
        if ($window.confirm("Are you sure want to insert this Notification?")) {
            Notificationfactory.insertnotification(notifications)
            then(function (response) {
                $scope.status = 'Inserted Notification! Refreshing Notification list.';
                window.location = "/Home/Notifications";
            }, function (error) {
                $scope.status = 'Unable to insert Notification: ' + error.message;
            });
        } else {
            $scope.Message = "You clicked NO.";
        }
    };

    // edit contact

    $scope.editnotification = function () {

        $scope.notification = this.notification;
        $scope.editMode = true;
        $('#userModel').modal('show');
    };


    //update contact
    $scope.update = function () {

        var custnotification = this.notification;
        Notificationfactory.updatenotification(custnotification).success(function (data) {
            custnotification.editMode = false;
            alert('Updated Notification! Refreshing Resources list.');
            $('#userModel').modal('hide');
        }).error(function (data) {
            $scope.error = "An Error has occured while Updating user! " + data.ExceptionMessage;
        });
    };

    // delete contact
    $scope.deletenotification = function (notifications) {
        if ($window.confirm("Are you sure want to delete this Notification?")) {
            $scope.Message = "You clicked YES.";
            var getData = Notificationfactory.deletenotification(notifications.NotificationId);
            getData.then(function (msg) {
                notificationsrecord();
                //   alert('contact Deleted');
            }, function (error) {
                alert('Error in Deleting Record');
            });
        } else {
            $scope.Message = "You clicked NO.";
        }
    };


})
myApp.factory('Notificationfactory', function ($http) {
    var urlBase = '../../api/Notifications';
    var Notificationfactory = {};
    Notificationfactory.getnotification = function () {
        return $http.get(urlBase);
    }
    Notificationfactory.insertnotification = function (notifications) {
        return $http.post(urlBase, notifications);
    }
    Notificationfactory.updatenotification = function (notifications) {
        return $http.put(urlBase + '/' + notifications.NotificationId, notifications);
    }
    Notificationfactory.deletenotification = function (notificationId) {
        return $http.delete(urlBase + '/' + notificationId);
    }
    return Notificationfactory;
});