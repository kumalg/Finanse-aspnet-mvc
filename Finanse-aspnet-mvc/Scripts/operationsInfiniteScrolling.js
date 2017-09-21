var lastId;
var actualMonthAndYear = moment();
var accounts = [];

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

$("#account-filter-button").click(function() {
    var values = [];
    $("#accounts-checkboxes input:checked").each(function() {
        values.push($(this).attr("value"));
    });
    accounts = values;
    ReloadData(0);
    console.log(accounts);
});

$("#tryAgainBtn").click(function() {
    $("#error").hide();
    GetData();
});

function CheckIfEmpty() {
    if (!$.trim($('#operations-list').html()).length) {
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
        traditional:true,
        data: { "lastId": lastId, "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM"), "accounts": accounts },
        success: function (data) {

            if (data.lastId != null) {

                var lastDate = $("#operations-list > div[role=heading]").last().attr("value");
                var firstNewDate = $(data.partialView).first().attr("value");

                if (lastDate == firstNewDate) {
                    $("#operations-list").append($(data.partialView).slice(1));
                } else {
                    $("#operations-list").append(data.partialView);    
                }
                
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

$(document).on("click", "#prev-month-button", function () {
    ReloadData(-1);
});

$(document).on("click", "#next-month-button", function () {
    ReloadData(1);
});

function ReloadData(addMonth) {
    actualMonthAndYear.add(addMonth, "month");
    UpdateActualMonthBtn(actualMonthAndYear);

    lastId = null;
    $("#operations-list").html("");

    $.ajax({
        type: "GET",
        url: "/Operations/Index",
        traditional: true,
        data: { "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM"), "accounts": accounts },
        success: function (data) {
            $("#operations-list").html(data.partialView);

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
    $("#actual-month-title").text(actualMonthAndYear.format("MMMM"));
    $("#actual-year-title").text(actualMonthAndYear.format("YYYY"));
}