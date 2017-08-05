var lastId;
var actualMonthAndYear = moment();
actualMonthAndYear.locale("pl");

$(document).ready(function () {
    UpdateActualMonthBtn(actualMonthAndYear);
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

function CheckIfEmpty() {
    if (!$.trim($('#operationsList').html()).length) {
        $("#noOperationsMessage").show();
    } else {
        $("#noOperationsMessage").hide();
    }
}

function GetData() {
    
    if ($("#error").is(":visible"))
        return false;

    $.ajax({
        type: "GET",
        url: "/Operations/Index",
        data: { "lastId": lastId, "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM") },
        success: function (data) {
            if (data.lastId != null) {

                $("#operationsList").append(data.partialView);

                if (lastId != data.lastId) {
                    lastId = data.lastId;

                    if ($("body").height() <= $(window).height())
                        GetData();
                }
            }

            $("#error").hide();
            CheckIfEmpty();
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

$(document).on("click", "#prevMonthBtn", function () {
    ReloadData(-1);
});

$(document).on("click", "#nextMonthBtn", function () {
    ReloadData(1);
});

function ReloadData(addMonth) {
    actualMonthAndYear.add(addMonth, "month");
    UpdateActualMonthBtn(actualMonthAndYear);

    lastId = null;
    $("#operationsList").html("");

    $.ajax({
        type: "GET",
        url: "/Operations/Index",
        data: { "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM") },
        success: function (data) {
            $("#operationsList").html(data.partialView);

            if (lastId != data.lastId) {
                lastId = data.lastId;

                if ($("body").height() <= $(window).height())
                    GetData();
            }

            $("#error").hide();
            CheckIfEmpty();
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

function UpdateActualMonthBtn(actualMonthAndYear) {
    if (actualMonthAndYear.format("YYYY") != moment().format("YYYY"))
        $("#actualMonthBtn").text(actualMonthAndYear.format("MMMM YYYY"));
    else
        $("#actualMonthBtn").text(actualMonthAndYear.format("MMMM"));
}