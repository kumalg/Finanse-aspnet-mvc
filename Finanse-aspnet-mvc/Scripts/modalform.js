//$(function () {

$.ajaxSetup({ cache: false });

$(document).on("click", "a[dataModal]", function (e) {
    
    // hide dropdown if any
    $(e.target).closest(".btn-group").children(".dropdown-toggle").dropdown("toggle");

    $("#pop-up-content").load(this.href, function () {

        $("#pop-up").modal({
            /*backdrop: 'static',*/
            keyboard: true
        }, "show");

        bindForm(this);
    });

    return false;
});

$("#pop-up").on("hidden.bs.modal", function () {
    $("#pop-up-content").empty();
});

//});

function bindForm(dialog) {

    $("form", dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $("#pop-up").modal("hide");
                    //Refresh
                    location.reload();
                } else {
                    $("#pop-up-content").html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}

///* FROM WEB */

//// Get the modal
//var modal = document.getElementById('myModal');

//// Get the button that opens the modal
//var btn = document.getElementById("btnCreate");

//// Get the <span> element that closes the modal
//var span = document.getElementsByClassName("close")[0];

//// When the user clicks on the button, open the modal 
//btn.onclick = function () {
//    modal.style.display = "block";
//}

//// When the user clicks on <span> (x), close the modal
//span.onclick = function () {
//    modal.style.display = "none";
//}

//// When the user clicks anywhere outside of the modal, close it
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//}