$(document).ready(function () {

    var baseurl = localStorage.getItem("baseurl");

    $("#grid").kendoGrid({
        selectable: "multiple cell",
        allowCopy: true,
        columns: [
            { field: "id" },
            { field: "question" },
            { field: "userAnswer" },
            { field: "summery" },
            { field: "value" },
        ],
        dataSource: []
    });
    $("#grid2").kendoGrid({
        selectable: "multiple cell",
        allowCopy: true,
        columns: [
            { field: "instance" },
            { field: "value" },
            { field: "forecast" },
            { field: "error" },
            { field: "absoluteError" },
            { field: "percentError" },
            { field: "absolutePercentError" }
        ],
        dataSource: []
    });

    $("#sessions").kendoComboBox({
        dataTextField: "value",
        dataValueField: "key",
        filter: "contains",
        suggest: true,
        select: (e) => {
            xhr('/api/sessions/' + e.dataItem.key, 'get', (e) => {
                var grid = $("#grid").data("kendoGrid");
                grid.setDataSource(e);
            });
        }
    });

    function setSessions(values) {
        $("#sessions").data("kendoComboBox").setDataSource(values);
    }

 
    function createChart2(e) {
        $("#chart2").kendoChart({
            title: {
                text: "Your Status with Time"
            },
            dataSource: {
                data: e
            },
            series: [{
                type: "line",
                field: "key",
                categoryField: "value"
            }]
        });
    }
    xhr('/api/sessions/graph', 'get', (e) => {
        createChart2(e);
    });


    function forecast(searchby) {

        xhr('/api/forecast/' + searchby, 'get', (e) => {
            var grid = $("#grid2").data("kendoGrid");
            grid.setDataSource(e.forecastList);
            $('#type').html(e.masterData.type);
            $('#mad').html(e.masterData.mad);
            $('#mape').html(e.masterData.mape);
            $('#mpe').html(e.masterData.mpe);
            $('#msd').html(e.masterData.msd);
            $('#mse').html(e.masterData.mse);
            $('#ts').html(e.masterData.ts);
        });
    }
    $('#naive').click(() => {
        forecast('naive');
    });
    $('#sma').click(() => {
        forecast('sma');
    });
    $('#wma').click(() => {
        forecast('wma');
    });
    $('#es').click(() => {
        forecast('es');
    });
    $('#ars').click(() => {
        forecast('ars');
    });
    forecast('naive');

    function xhr(url, type, callback) {
        $.ajax({
            url: baseurl+url,
            type: type,
            contentType: 'application/json; charset=utf-8',
            caher: false,
            data: null,
            success: function (data) {
                callback(data);
            },
            error: function (e) {
                alert('error');
            }
        });
    }

    xhr('/api/sessions','get', (e) => {
        setSessions(e);
    });

    $('#logout').click(() => {
        localStorage.clear();
        window.location = baseurl + "/view/login.html";
    });
});


