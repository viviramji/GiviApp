function addUser() {
    $('#addUserModal').modal("hide");
    var _id = $('#userID').val();
    var _firstName = $('#firstName').val();
    var _lastName = $('#lastName').val();
    var _email = $('#email').val();
    var _phoneNumber = $('#phoneNumber').val();
    var _city = $('#city').val();
    var _username = $('#username').val();
    var _password = $('#password').val();
    var _typeUser = $('#typeUser').val();
    //let's create a objet just like our user.cs
    var user = {
        id: _id,
        firstName: _firstName,
        lastName: _lastName,
        email: _email,
        phoneNumber: _phoneNumber,
        city: _city,
        username: _username,
        password: _password,
        typeUser: _typeUser
    };
    
    $.ajax({
        type: "POST",
        dataType: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Admin/addUser",
        data: JSON.stringify({
            '_user':user
        }),

        error: function () {
            toastr.error('system Error, check your connection or re-debug your code', 'Error', {
                timeOut: 6000,
                positionClass: 'toast-top-full-width'
            });
        },

        success: function (data) {
            if (data.msg === "ok") {
                toastr.success('OK, User added', 'ok', {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
                $("#addUserModal").modal("hide"); //to hide my idModal jeje
                $("#listUsers").load("/Admin/getUsers");
            }
            else if (data.msg === "exists") { //not finish yet
                toastr.error("You're trying to add a user that alreday exists", "Eye!", {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
            } else {
                toastr.error("Backend error", "Eye!", {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
            }
        }
    });
}