//$(function () {

    $.ajaxSetup({ cache: false });

    $(document).on("click", "a[data-modal]", function (e) {

        // hide dropdown if any
        $(e.target).closest(".btn-group").children(".dropdown-toggle").dropdown("toggle");
        
        $("#myModalContent").load(this.href, function () {

            $("#myModal").modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, "show");
            
            bindForm(this);
        });

        return false;
    });

    $("#myModal").on("hidden.bs.modal", function () {
        $("#myModalContent").empty();
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
                    $("#myModal").modal("hide");
                    //Refresh
                    location.reload();
                } else {
                    $("#myModalContent").html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}