var myApp = angular.module('myApp', []);

myApp.controller('ContactController', function ($scope, $http, $filter, $window, Contactfactory) {
    $scope.showadd = function () {
        window.location = "/Home/AddContact";
    };
    $scope.BackList = function () {
        window.location = "/Home/Contact";

    }
    getContacts();
    function getContacts() {
        Contactfactory.getContacts()
        .then(function (response) {
            $scope.contacts = response.data;

        });
    }

    $scope.GetInit = function () {
        $http({
            method: 'Get',
            url: '/Home/getcontactList'
        }).success(function (result) {
            $scope.cont = result;

        });
    }

    $scope.submitform = function () {
        var contact = {};
        contact.Firstname = $scope.Firstname;
        contact.LastName = $scope.Lastname;
        contact.Email = $scope.EmailId;
        contact.PrimaryPhone = $scope.Primaryno;
        contact.SecondaryPhone = $scope.Secondaryno;
        contact.CellPhone = $scope.Cellno;
        contact.Street = $scope.Street;
        contact.City = $scope.City;
        contact.State = $scope.State;
        contact.ZipCode = $scope.Zip;
        //if ($scope.con.ListId != 0) {
        //    contact.Id = $scope.con.ListId;
        //}
        //else {
        //    contact.Id = 0;
        //}
        if ($window.confirm("Are you sure want to insert this contact?")) {
            Contactfactory.insertContact(contact)
            then(function (response) {
                // $scope.Ct = response.data.ContactId;
                //if (contact.Id != 0) {
                //    var cont = {}
                //    cont.CtListId = $scope.con.ListId;
                //    cont.CtId = $scope.Ct;
                //    alert(contact.Id);
                //    $http({
                //        method: "POST",
                //        url: "/Home/savecategory",
                //        data: JSON.stringify(cont),
                //    }).then(function (data) {
                //        alert('Inserted Contact! Refreshing Contact list.');
                //        window.location = "/Home/Contact";
                //    })
                //}
                //else {
                alert('Inserted Contact! Refreshing Contact list.');
                window.location = "/Home/Contact";
                // }
            }, function (error) {
                $scope.status = 'Unable to insert contact: ' + error.message;
            });
        }
        else {
            $scope.Message = "You clicked NO.";
        }
    };

    // edit contact
    $scope.editContact = function () {
        $scope.contact = this.contact;
        $scope.editMode = true;
        $('#userModel').modal('show');
    };

    $scope.Cancel = function () {
        window.location = "/Home/Contact";
        getContacts();
        $('#userModel').modal('hide');
    }

    //update contact
    $scope.update = function () {
        var custcontact = this.contact;
        Contactfactory.updateContact(custcontact).success(function (data) {
            custcontact.editMode = false;
            window.location = "/Home/Contact";
            alert('Updated contact! Refreshing contact list.');
            $('#userModel').modal('hide');
        }).error(function (data) {
            $scope.error = "An Error has occured while Updating user! " + data.ExceptionMessage;
        });
    };
    // delete contact
    $scope.deleteContact = function (contact) {
        if ($window.confirm("Are you sure want to delete this Contact?")) {
            $scope.Message = "You clicked YES.";
            var getData = Contactfactory.deleteContact(contact.ContactId);
            getData.then(function (msg) {
                getContacts();
                //alert('contact Deleted');
            }, function (error) {
                alert('Error in Deleting Record');
            });
        } else {
            $scope.Message = "You clicked NO.";
        }
    };


})

myApp.factory('Contactfactory', function ($http) {
    var urlBase = '../../api/Contact';
    var Contactfactory = {};

    Contactfactory.getContacts = function () {
        return $http.get(urlBase);
    }

    Contactfactory.insertContact = function (contact) {
        return $http.post(urlBase, contact);
    }
    Contactfactory.updateContact = function (contact) {
        return $http.put(urlBase + '/' + contact.ContactId, contact);

    }
    Contactfactory.deleteContact = function (contactId) {
        return $http.delete(urlBase + '/' + contactId)
    }
    return Contactfactory;
});