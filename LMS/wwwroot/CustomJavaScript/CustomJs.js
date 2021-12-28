const { debug } = require("console");

function Success(response) {
    debugger;
    if (response == "Server error please contact admin team") {
        notification("topright", "error", "fa fa-exclamation-circle vd_red", "Error Notification", "Hello this is your notification using custom theme. Cool right?");
    }
    else {
        notification("topright", "success", "fa fa-check-circle vd_green", "Success Notification", "Hello this is your notification using custom theme. Cool right?");
         
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
    debugger;
   
      
        $.get(deleteUrl, { id: id }, function (response) {
            notification("topright", "success", "fa fa-check-circle vd_green", "Success Notification", "Lead Type Data Deleted Successfully?"); 
        }).done(function () {
            $.get(getUrl, function (response) {
                $("#divLead").html(response);
            }).done(function () {
                
            });

            $(".form-control").val('');//Clear the controll which is present inside the form.
        });
    
}

function UpdateCustomRecord(id, updateUrl, textData) {
    $("#modalTitle").text(textData)
    $("#myLeadModal").addClass("loading");
    $.get(updateUrl, { id: id }, function (response) {
        $("#divLeadCreate").html(response);
        $('#myLeadModal').modal({ backdrop: 'static' });
    }).done(function () {
        $("#myLeadModal").removeClass("loading");
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
    $("#myLeadModal").addClass("loading");
    $.get(url, function (response) {
        debugger;
        $("#divLeadCreate").html(response);
        $('#myLeadModal').modal({ backdrop: 'static' });
        
    }).done(function () {
        $("#myLeadModal").removeClass("loading");
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

