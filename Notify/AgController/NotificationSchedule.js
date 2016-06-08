var myApp = angular.module('NotificationScheduleApp', []);

myApp.controller('NotificationScheduleController', function ($scope, $http, $filter, NotificationSchedulefactory) {
    $scope.GetInit = function () {
        $http({
            method: 'Get',
            url: '/Home/getcontactList'
        }).success(function (result) {
            $scope.cont = result;

        });
    }
    NSchedulerecord()
    function NSchedulerecord() {
        NotificationSchedulefactory.GetNotificationSchedule()
        .then(function (response) {
            $scope.notifications = response.data;
        })
    }
    $scope.save = function () {
        $scope.albumNameArray = [];
        angular.forEach($scope.notifications, function (notification) {
            if (!!notification.selected) $scope.albumNameArray.push(notification.NScheduleID);

        })
        $http({
            method: 'post',
            url: '/SendNotification/Create',
            params: { schedule: $scope.albumNameArray }
        }).success(function (result) {
            $scope.Resources = result
        });
    }

    $scope.GetResources = function () {
        $http({
            method: 'Get',
            url: '/Home/GetResourcesList'
        }).success(function (result) {
            $scope.Resources = result
        });
    }
    $scope.IsVisible = false;
    $scope.Visible = false;
    //$scope.GetTemplate = function () {
    //    $scope.CheckBoxStatus = 'Email';
    //    $scope.IsVisible = $scope.ChanelMode;
    //    $http({
    //        method: 'Get',
    //        url: '/Home/GetTemplateRecord',
    //        params: { Mode: $scope.CheckBoxStatus }
    //    }).success(function (result) {
    //        $scope.NotifyTemplate = result
    //    });
    //}
    $scope.vm = {};
    $scope.vm.myClick = function ($event) {       
        var st=$event;
        if (st == true) {
            $scope.CheckBoxEmailStatus = 'Email';
        }
        else
        {
            $scope.CheckBoxEmailStatus = '';
        }
        $scope.IsVisible = $scope.vm.myChkModel;
        $http({
            method: 'Get',
            url: '/Home/GetTemplateRecord',
            params: { Mode: $scope.CheckBoxEmailStatus }
        }).success(function (result) {
            $scope.NotifyTemplate = result
        });
    }

    $scope.vm.mySmsClick = function ($event) {        
        var st = $event;
        if (st == true) {
            $scope.CheckBoxSmsStatus = 'SMS';
        }
        else {
            $scope.CheckBoxSmsStatus = '';
        }
        $scope.IsSMSVisible = $scope.vm.myChkSmsModel;
        $http({
            method: 'Get',
            url: '/Home/GetTemplateRecord',
            params: { Mode: $scope.CheckBoxSmsStatus }
        }).success(function (result) {
            $scope.NotifyTemplatesms = result
        });
    }
    $scope.vm.myvoiceClick = function ($event) {
        var st = $event;
        if (st == true) {
            $scope.CheckBoxVoiceStatus = 'Voice Call';
        }
        else {
            $scope.CheckBoxVoiceStatus = '';
        }
        $scope.IsVoiceVisible = $scope.vm.myChkvoiceModel;
        $http({
            method: 'Get',
            url: '/Home/GetTemplateRecord',
            params: { Mode: $scope.CheckBoxVoiceStatus }
        }).success(function (result) {
            $scope.NotifyTemplateVoice = result
        });
    }
    $scope.GetNotificationEmailMessage = function () {
        $scope.TemplateId = $scope.Nt.NotificationId;
        $scope.Visible = $scope.Nt.NotificationId;
        $http({
            method: 'Get',
            url: '/Home/GetNotificationMessageRecord',
            params: { Template: $scope.TemplateId }
        }).success(function (result) {
            $scope.Notifymsg = result
        });
    }
    $scope.GetNotificationSMSMessage = function () {
        $scope.TemplateId = $scope.Nt.NotificationSmsId;
        $scope.Visible = $scope.Nt.NotificationSmsId;
        $http({
            method: 'Get',
            url: '/Home/GetNotificationSMSMessageRecord',
            params: { Template: $scope.TemplateId }
        }).success(function (result) {
            $scope.Notifymsg = result
        });
    }
    $scope.GetNotificationVoiceMessage = function () {
        $scope.TemplateId = $scope.Nt.NotificationVoiceId;
        $scope.Visible = $scope.Nt.NotificationVoiceId;
        $http({
            method: 'Get',
            url: '/Home/GetNotificationVoiceMessageRecord',
            params: { Template: $scope.TemplateId }
        }).success(function (result) {
            $scope.Notifymsg = result
        });
    }


    $scope.submitform = function () {
        var datval = $('.datval').val();
        var Schedule = {};
        Schedule.NotificationCampaign = $scope.NotificationCampaign;
        Schedule.CampaignDate = datval;
        Schedule.ChanelMode = $scope.CheckBoxEmailStatus;
        Schedule.ChanelsmsMode = $scope.CheckBoxSmsStatus;
        Schedule.ChanelvoiceMode = $scope.CheckBoxVoiceStatus;
        Schedule.ContactListId = $scope.con.ListId;
        Schedule.ResourceId = $scope.Resource.ResoureId;
        Schedule.NotificationId = $scope.Nt.NotificationId;
        Schedule.NotificationSmsId = $scope.Nt.NotificationSmsId;
        Schedule.NotificationVoiceId = $scope.Nt.NotificationVoiceId;
        $http({
            method: "POST",
            url: "/Home/AddNotification",
            data: JSON.stringify(Schedule)    
        }).success(function (result) {
            $scope.msg = result;
            alert($scope.msg);
            alert('Inserted Success!');
        });
    };
})
myApp.factory('NotificationSchedulefactory', function ($http) {
    var url = '../../api/Schedule';
    var NotificationSchedulefactory = {};
    NotificationSchedulefactory.getclient = function () {
        return $http.get(urlBase);
    }
    NotificationSchedulefactory.GetNotificationSchedule = function () {
        return $http.get(url);
    }
    return NotificationSchedulefactory;
});