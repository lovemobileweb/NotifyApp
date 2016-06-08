var myApp = angular.module('UserClient', []);

myApp.controller('UserClientController', function ($scope, $http, $filter, $window) {
    $scope.GetInitClientuser = function () {
        $http({
            method: 'Get',
            url: '/Home/getuserClientList'
        }).success(function (result) {
            $scope.userclient = result;

        });
    }

    $scope.GetClientvalue=function()
    {
        debugger;
        $scope.id = $scope.Client.ClientId       
        $http({
            method:'Get',         
            url: '/Home/GetUserClientId/',
            params: { id: $scope.id }
        }).success(function (data)
        {
            $scope.Userrcord = data;
            $scope.clientId = $scope.Userrcord.ClientId;

        })       
    }
    $scope.GetCountUser=function()
    {
        $http({
            method: 'Get',
            url: '/Home/GetUserCount/'
        }).success(function (data) {
            $scope.Usercount = data;
           

        })

    }
    $scope.GetCountContact = function () {
        $http({
            method: 'Get',
            url: '/Home/GetUserCount/'
        }).success(function (data) {
            $scope.Contactcount = data;
           

        })
    }
    $scope.GetCountNotification = function () {
        $http({
            method: 'Get',
            url: '/Home/GetNotificationCount/'
        }).success(function (data) {
            $scope.Notificationcount = data;


        })
    }
     $scope.GetClientCountUser=function()
    {
        $http({
            method: 'Get',
            url: '/Home/GetClientUserCount/'
        }).success(function (data) {
            $scope.Usercount = data;
           

        })

    }
    $scope.GetClientCountContact = function () {
        $http({
            method: 'Get',
            url: '/Home/GetClientContactCount/'
        }).success(function (data) {
            $scope.Contactcount = data;
           

        })
    }
    $scope.GetClientCountNotification = function () {
        $http({
            method: 'Get',
            url: '/Home/GetClientNotificationCount/'
        }).success(function (data) {
            $scope.Notificationcount = data;


        })
    }
});
//myApp.controller('ContactController', function ($scope, $http, $filter, $window, Contactfactory) {
//    $scope.showadd = function () {
//        window.location = "/Home/AddContact";
//    };
//    $scope.BackList = function () {
//        window.location = "/Home/Contact";

//    }
//    getContacts();
//    function getContacts() {
//        Contactfactory.getContacts()
//        .then(function (response) {
//            $scope.contacts = response.data;

//        });
//    }

//    $scope.GetInit = function () {
//        $http({
//            method: 'Get',
//            url: '/Home/getcontactList'
//        }).success(function (result) {
//            $scope.cont = result;

//        });
//    }

//    $scope.submitform = function () {
//        var contact = {};
//        contact.Firstname = $scope.Firstname;
//        contact.LastName = $scope.Lastname;
//        contact.Email = $scope.EmailId;
//        contact.PrimaryPhone = $scope.Primaryno;
//        contact.SecondaryPhone = $scope.Secondaryno;
//        contact.CellPhone = $scope.Cellno;
//        contact.Street = $scope.Street;
//        contact.City = $scope.City;
//        contact.State = $scope.State;
//        contact.ZipCode = $scope.Zip;
//        alert(contact.Firstname);
//        if ($scope.con.ListId == "") {
//            contact.Id = 0;
//        }
//        else {
//            contact.Id = $scope.con.ListId;
//        }
//        if ($window.confirm("Are you sure want to insert this contact?")) {
//            Contactfactory.insertContact(contact)
//            then(function (response) {
//                $scope.Ct = response.data.ContactId;
//                if (contact.Id != 0) {
//                    var cont = {}
//                    cont.CtListId = $scope.con.ListId;
//                    cont.CtId = $scope.Ct;
//                    alert(contact.Id);
//                    $http({
//                        method: "POST",
//                        url: "/Home/savecategory",
//                        data: JSON.stringify(cont),
//                    }).then(function (data) {
//                        alert('Inserted Contact! Refreshing Contact list.');
//                        window.location = "/Home/Contact";
//                    })
//                }
//                else {
//                    alert('Inserted Contact! Refreshing Contact list.');
//                    window.location = "/Home/Contact";
//                }
//            }, function (error) {
//                $scope.status = 'Unable to insert contact: ' + error.message;
//            });
//        }
//        else {
//            $scope.Message = "You clicked NO.";
//        }
//    };

//    // edit contact
//    $scope.editContact = function () {
//        $scope.contact = this.contact;
//        $scope.editMode = true;
//        $('#userModel').modal('show');
//    };

//    $scope.Cancel = function () {
//        $('#userModel').modal('hide');
//    }

//    //update contact
//    $scope.update = function () {
//        var custcontact = this.contact;
//        Contactfactory.updateContact(custcontact).success(function (data) {
//            custcontact.editMode = false;
//            alert('Updated contact! Refreshing contact list.');
//            $('#userModel').modal('hide');
//        }).error(function (data) {
//            $scope.error = "An Error has occured while Updating user! " + data.ExceptionMessage;
//        });
//    };
//    // delete contact
//    $scope.deleteContact = function (contact) {
//        if ($window.confirm("Are you sure want to delete this Contact?")) {
//            $scope.Message = "You clicked YES.";
//            var getData = Contactfactory.deleteContact(contact.ContactId);
//            getData.then(function (msg) {
//                getContacts();
//                //alert('contact Deleted');
//            }, function (error) {
//                alert('Error in Deleting Record');
//            });
//        } else {
//            $scope.Message = "You clicked NO.";
//        }
//    };


//})

//myApp.controller('ContactListController',function ($scope, $http, $window, $filter) {
//    $scope.showadd = function () {
//        window.location = "/Home/AddContactList";
//    }

//    $scope.GetInit = function () {
//        $http({
//            method: 'Get',
//            url: '/Home/getcontactList'
//        }).success(function (result) {
//            $scope.cont = result;

//        });
//    }

//    $scope.GetselectVal = function () {
//        $http({
//            method: 'Get',
//            url: '/Home/GetContactListDetail/' + $scope.con.ListId
//        }).success(function (data, status, headers, config) {
//            $scope.ContactPropertyList = data;
//        })
//    }

//    $scope.GetInitprsn = function () {
//        debugger;
//        $scope.id = $scope.con.ListId
//        $http({
//            method: 'Get',
//            url: '/Home/getcontactPerson',
//            params: { lid: $scope.id }
//        }).success(function (result) {
//            $scope.cont1 = result;

//        });
//    }

//    // delete contact
//    $scope.deleteContactList = function (ListDetailID) {
//        if ($window.confirm("Are you sure want to delete this Contact?")) {
//            $scope.Message = "You clicked YES.";
//            //ListdetailId = $scope.contactlist.ListDetailID;
//            //  alert(ListDetailID);
//            $http({
//                method: 'Get',
//                url: '/Home/DeleteContactList',
//                params: { listId: JSON.stringify(ListDetailID) }
//            }).success(function (data) {
//                $('#myModal').hide();
//                location.reload();
//            })
//        } else {
//            $scope.Message = "You clicked NO.";
//        }
//    };
     
//    $scope.CategoriesSelected = [];
//    $scope.Contacts = [];
//    $scope.dropdownSetting = {
//        scrollable: true,
//        scrollableHeight: '200px'
//    }

//    $scope.BackList = function () {
//        window.location = "/Home/ContactList";
//    }
//    //fetch data from database for show in multiselect dropdown
//    $http.get('/Home/getcategories').then(function (data) {
//        angular.forEach(data.data, function (value, index) {
//            $scope.Contacts.push({ id: value.ContactId, label: value.FirstName });
//        });
//    })

//    //post or submit selected items from multiselect dropdown to server
//    $scope.SubmittedCategories = [];
//    $scope.SubmitData = function () {
//        var contactlistname = $scope.ContactListname;
//        var categoryIds = [];
//        angular.forEach($scope.CategoriesSelected, function (value, index) {
//            categoryIds.push(value.id);
//        });
//        var data = {
//            categoryIds: categoryIds,
//            contactlistname: $scope.ContactListname
//        };
//        $http({
//            method: "POST",
//            url: "/Home/savedata",
//            data: JSON.stringify(data)
//        })
//            .then(function (response) {
//                $scope.value = response.d;
//                alert('Inserted ContactList! Success Contact list.');
//                window.location = "/Home/ContactList";
//            }, function (error) {

//            })
//    }
//})
//myApp.controller('ResourcesController', function ($scope, $http, $window, $filter, Resourcesfactory) {
//    $scope.showadd = function () {
//        window.location = "/Home/AddResources";
//    };
//    $scope.BackList = function () {
//        window.location = "/Home/Resources";

//    }
//    getResources()
//    function getResources() {
//        Resourcesfactory.getResource()
//        .then(function (response) {
//            $scope.Resources = response.data;
//        });
//    }
//    $scope.submitform = function () {
//        var Resources = {};
//        Resources.ResoureName = $scope.ResoureName;
//        Resources.ResoureDescription = $scope.ResoureDescription;
//        Resources.URL = $scope.URL;
//        Resources.AccountNumber = $scope.AccountNumber;
//        Resources.FirstName = $scope.FirstName;
//        Resources.LastName = $scope.LastName;
//        Resources.EmailAddress = $scope.EmailAddress;
//        Resources.PrimaryPhoneNumber = $scope.PrimaryPhoneNumber;
//        Resources.SecondaryPhoneNumber = $scope.SecondaryPhoneNumber;
//        Resources.CellPhoneNumber = $scope.CellPhoneNumber;
//        Resources.Street = $scope.Street;
//        Resources.City = $scope.City;
//        Resources.State = $scope.State;
//        Resources.ZipCode = $scope.ZipCode;
//        if ($window.confirm("Are you sure want to insert this Resource?")) {
//            Resourcesfactory.insertResources(Resources)
//            then(function (response) {
//                alert('Inserted Contact! Refreshing Contact list.');
//                window.location = "/Home/Resources";

//            }, function (error) {
//                $scope.status = 'Unable to insert Resources: ' + error.message;
//            });
//        }
//        else {
//            $scope.Message = "You clicked NO.";
//        }
//    };

//    // edit contact
//    $scope.editResources = function () {
//        $scope.Resource = this.Resource;
//        $scope.editMode = true;
//        $('#userModel').modal('show');
//    };

//    //update contact
//    $scope.update = function () {
//        var custResources = this.Resource;
//        Resourcesfactory.updateResources(custResources).success(function (data) {
//            custResources.editMode = false;
//            alert('Updated Resources! Refreshing Resources list.');
//            $('#userModel').modal('hide');
//        }).error(function (data) {
//            $scope.error = "An Error has occured while Updating user! " + data.ExceptionMessage;
//        });
//    };

//    $scope.deleteResources = function (Resources) {
//        if ($window.confirm("Are you sure want to delete this Resource?")) {
//            $scope.Message = "You clicked YES.";
//            var getData = Resourcesfactory.deleteResources(Resources.ResoureId);
//            getData.then(function (msg) {
//                getResources();
//                //  alert('Resources Deleted');
//            }, function (error) {
//                //  alert('Error in Deleting Record');
//                //  alert('Notification Deleted');
//            });
//        } else {
//            $scope.Message = "You clicked NO.";
//        }

//    };


//})
//myApp.factory('Contactfactory', function ($http) {
//    var urlBase = '../../api/Contact';
//    var Contactfactory = {};

//    Contactfactory.getContacts = function () {
//        return $http.get(urlBase);
//    }

//    Contactfactory.insertContact = function (contact) {
//        return $http.post(urlBase, contact);
//    }
//    Contactfactory.updateContact = function (contact) {
//        return $http.put(urlBase + '/' + contact.ContactId, contact);

//    }
//    Contactfactory.deleteContact = function (contactId) {
//        return $http.delete(urlBase + '/' + contactId)
//    }
//    return Contactfactory;
//});
//myApp.factory('Resourcesfactory', function ($http) {
//    var urlBase = '../../api/Resources';
//    var Resourcesfactory = {};
//    Resourcesfactory.getResource = function () {
//        return $http.get(urlBase);
//    }
//    Resourcesfactory.insertResources = function (Resources) {
//        return $http.post(urlBase, Resources);
//    }
//    Resourcesfactory.updateResources = function (Resources) {
//        return $http.put(urlBase + '/' + Resources.ResoureId, Resources)

//    }
//    Resourcesfactory.deleteResources = function (ResoureId) {
//        return $http.delete(urlBase + '/' + ResoureId)
//    }
//    return Resourcesfactory;
//});