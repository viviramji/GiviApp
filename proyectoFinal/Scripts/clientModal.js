function addClient() {
    var _id = $('#clientID').val();
    var _companyName = $('#companyName').val();
    var _phoneNumber = $('#phone').val();
    var _address = $('#address').val();
    var _email = $('#emailC').val();
    var _city = $('#cityC').val();
    //validate all variables or CLient object
    var Client = {
        id: _id,
        companyName: _companyName,
        phoneNumber: _phoneNumber,
        address: _address,
        email: _email,
        city: _city
    };

    console.log(Client);

    $.ajax({
        type: "POST",
        dataType: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Admin/addClient",
        data: JSON.stringify({
            '_client':Client
        }),

        error: function () {
            toastr.error('system Error, check your code (hint: check your .js \';)\' ) or re-debug your code', 'Eye!', {
                timeOut: 6000,
                positionClass: 'toast-top-full-width'
            });
        },
        success: function (data) {
            if (data.msg === "ok") {
                toastr.success('Client added', 'Good Job', {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
                $("#addClientModal").modal("hide"); //to hide my idModal jeje
                $("#listClients").load("/Admin/getClients");
            } else if (data.msg === "exists") {
                toastr.error("You're trying to add an ID that already exists", "Eye!", {
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