var pageSize = 5;
var lastId = -1;

$(document).ready(function () {
    GetData();

    $(window).scroll(function () {
        if ($(window).scrollTop() === $(document).height() - $(window).height()) {
            GetData();
        }
    });
});

$("#tryAgainBtn").click(function() {
    $("#error").hide();
    GetData();
});

function GetData() {
    $.ajax({
        type: "GET",
        url: "/Operations/Index",
        data: { "lastId": lastId, "pageSize": pageSize },
        success: function (data) {
            if (data.lastId !== -1) {

                $("#operationsList").append(data.partialView);

                if (lastId !== data.lastId) {
                    lastId = data.lastId;

                    if ($("body").height() <= $(window).height())
                        GetData();
                }
            }

            $("#error").hide();
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        },
        error: function () {
            $("#error").show();
        }
    });
}