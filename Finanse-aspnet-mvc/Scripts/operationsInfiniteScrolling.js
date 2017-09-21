var lastId;
var actualMonthAndYear = moment();
var accounts = [];
var groupBy;

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
$("#group-method-list input").on("change",
    function() {
        groupBy = $("input[name=group-method]:checked").attr("value");
       //console.log(type);
        ReloadData();
    });

$("#account-filter-button").click(function() {
    var values = SelectedAccounts();

    if (!CompareLists(accounts, values)) {
        accounts = values;
        ReloadData();
    }

    $(this).attr("disabled", true);
});

$("#accounts-checkboxes").on("change",
    function() {
        $("#account-filter-button[disabled]").attr("disabled", false);
    });

$("#tryAgainBtn").click(function() {
    $("#error").hide();
    GetData();
});

function CompareLists(arr1, arr2) {
    return arr1.length === arr2.length && arr1.every((el, ix) => el === arr2[ix]);
}

function SelectedAccounts() {
    var values = [];

    $("#accounts-checkboxes input:checked").each(function () {
        values.push($(this).attr("value"));
    });

    return values;
}

function CheckIfEmpty() {
    if (!$.trim($("#operations-list").html()).length) {
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
        data: { "lastId": lastId, "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM"), "accounts": accounts, "groupBy": groupBy },
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
        data: { "actualYear": actualMonthAndYear.format("YYYY"), "actualMonth": actualMonthAndYear.format("MM"), "accounts": accounts, "groupBy": groupBy },
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