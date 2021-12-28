function Success(response) {
    if (response == "Server error please contact admin team") {
        alertify.set('notifier', 'position', 'bottom-right');
        alertify.error(response);
    }
    else {
        alertify.set('notifier', 'position', 'bottom-right');
        alertify.success(response);
    }

    $("#form")[0].reset();//reset the form controll.
    $(".form-control").val('');//Clear the controll which is present inside the form.

    setTimeout(function () {
        location.reload();
    }, 300)
}


function CustomDelete(id, url) {
    alertify.set('notifier', 'position', 'top-center');
    var defered = $.Deferred();
    alertify.confirm("Are you sure want to Inactivate this record ?", function () {
        $.get(url, { Id: id }, function (response) {
            alertify.success('Record deactivated successfully')
            return defered.promise();

        });
    }, function () {
        alertify.error('There is some server Error please contact admin team .')
    });
}

function CustomDeleteRecord(id, getUrl, deleteUrl, event) {
    alertify.set('notifier', 'position', 'top-center');
    alertify.confirm("Are you sure want to delete the record ?", function () {

        var thisId = $(event);
        thisId.button('loading');

        $.get(deleteUrl, { id: id }, function (response) {
            alertify.success("Record deleted successfully");
        }).done(function () {
            $.get(getUrl, function (response) {
                $("#divHRMS").html(response);
            }).done(function () {
                $("#tblDataList").DataTable({
                    fixedHeader: true,
                    select: true,
                    responsive: true
                });
            });

            $(".form-control").val('');//Clear the controll which is present inside the form.
        });
    }, function () {
        alertify.warning("You cancel the delete.");
    });
}

function UpdateCustomRecord(id, updateUrl,textData) {
    $("#modalTitle").text(textData)
    $("#divModalPop").addClass("loading");
    $.get(updateUrl, { id: id }, function (response) {
        $("#divHRMSCreate").html(response);
        $("#divModalPop").modal('show');
    }).done(function () {
        $("#divModalPop").removeClass("loading");
    });
}

function GetCustomRecord(getUrl, divId) {
    $("#divSERP").addClass("loading");
    $.get(getUrl, function (response) {
        $("#" + divId).html(response);
    }).done(function () {
        $("#divSERP").removeClass("loading");
    });
}

function NewCustomRecord(url, textData) {
    $("#modalTitle").text(textData)
    $("#divModalPop").addClass("loading");
    $.get(url, function (response) {
        $("#divHRMSCreate").html(response);
        $("#divModalPop").modal('show');
    }).done(function () {
        $("#divModalPop").removeClass("loading");
    });
}

function AjaxOnBegin() {
    $("#modalContent").addClass('loading');
}
function AjaxComplete() {
    $("#modalContent").removeClass('loading');
}

function CustomFormSubmitBegin() {
    $("#modalContent").addClass('loading');
}

function CustomFormSubmitComplete() {
    $("#modalContent").removeClass('loading');
   
}

function GetInfo() {
    alert("Information")
}

//use onfocus in textbox
function RemoveZero(e) {
    if (e.value == "0") {
        e.value = "";
    }
}
//use onblur in textbox
function SetZeroIfEmpty(e) {
    if (e.value == "") {
        e.value = "0";
    }
}

