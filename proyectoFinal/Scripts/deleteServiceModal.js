

function deleteService() {
    var element = {
        id : $('#deleteId').val()
    }

    console.log(element);
    //alert();

    $.ajax({
        type: "POST",
        dataType: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Admin/deleteService",
        data: JSON.stringify({
            '_id': element
        }),
        error: function () {
            toastr.error('system Error, check your code (hint: check your .js \';)\' ) or re-debug your code', 'Eye!', {
                timeOut: 5000,
                positionClass: 'toast-top-full-width'
            });
        },
        success: function (data) {
            if (data.msg === "ok") {
                toastr.success('Service deleted', 'Good Job', {
                    timeOut: 5000,
                    positionClass: 'toast-top-full-width'
                });
                $("#deleteServiceModal").modal("hide"); //to hide my idModal jeje
                $("#servicePartialId").load("/Admin/getServices");
            }
            else if (data.msg === "bad") {
                toastr.error("You're id does not exists or you've already deleted it", "Eye!", {
                    timeOut: 5000,
                    positionClass: 'toast-top-full-width'
                });
            }
            else {
                toastr.error("Backend error", "Eye!", {
                    timeOut: 5000,
                    positionClass: 'toast-top-full-width'
                });
            }
        }
    });
}