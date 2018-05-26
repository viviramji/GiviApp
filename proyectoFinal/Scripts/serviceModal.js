function addService() {
    var _des = $('#description').val();
    var _clientID = $('#clientIDs').val();
    var _adminID = $('#adminID').val();
    var _userID = $('#userIDs').val();
    var _date = $('#date').val();
    var _typeService = $('#typeService').val();
    var _status = $('#status').val();

    var Service = {
        id: "",
        companyName: "",
        description: _des,
        date: _date,
        status: _status,
        typeService: _typeService,
        adminID: _adminID,
        userID: _userID,
        clientID: _clientID
    }
    console.log(Service)
    $.ajax({
        type: "POST",
        dataType: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Admin/addService",
        data: JSON.stringify({
            '_service': Service
        }),

        error: function () {
            toastr.error('system Error, check your code (hint: check your .js \';)\' ) or re-debug your code', 'Eye!', {
                timeOut: 6000,
                positionClass: 'toast-top-full-width'
            });
        },
        success: function (data) {
            if (data.msg === "ok") {
                toastr.success('Service added', 'Good Job', {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
                $("#addServiceModal").modal("hide"); //to hide my idModal jeje
                $("#servicePartialId").load("/Admin/getServices");
            } 
            else {
                toastr.error("Backend error", "Eye!", {
                    timeOut: 6000,
                    positionClass: 'toast-top-full-width'
                });
            }
        }

    });
}


function setDate(d) {
    var arrDate = d.split('/');
    return arrDate[2] + "-" + arrDate[1] + "-" + arrDate[0];
}


