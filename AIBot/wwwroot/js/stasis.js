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
    function bindViewModel(values) {
        var viewModel = kendo.observable({
            selectSession: null,
            sessions: values,
            onSelect: (e) => {
                //var xxx = this.get("selectSession");
                xhr('/api/sessions/7','get', (e) => {
                    var grid = $("#grid").data("kendoGrid");
                    grid.setDataSource(e);
                });
                
            }
        });
        kendo.bind($("#placeholder"), viewModel);
    }

   
    function createChart() {
        $("#chart").kendoChart({
            title: {
                text: "Your overrole status?"
            },
            legend: {
                position: "top"
            },
            seriesDefaults: {
                labels: {
                    template: "#= category # - #= kendo.format('{0:P}', percentage)#",
                    position: "outsideEnd",
                    visible: true,
                    background: "transparent"
                }
            },
            series: [{
                type: "donut",
                data: [{
                    category: "One",
                    value: 35
                }, {
                    category: "Two",
                    value: 25
                }, {
                    category: "Three",
                    value: 20
                }, {
                    category: "Four",
                    value: 10
                }, {
                    category: "Five",
                    value: 10
                }]
            }],
            tooltip: {
                visible: true,
                template: "#= category # - #= kendo.format('{0:P}', percentage) #"
            }
        });
    }

    createChart();

    function createChart2() {
        $("#chart2").kendoChart({
            title: {
                text: "Your Status with Time"
            },
            dataSource: {
                data: [
                    { value: 30, date: new Date("2011/12/20") },
                    { value: 50, date: new Date("2011/12/21") },
                    { value: 45, date: new Date("2011/12/22") },
                    { value: 40, date: new Date("2011/12/23") },
                    { value: 35, date: new Date("2011/12/24") },
                    { value: 40, date: new Date("2011/12/25") },
                    { value: 42, date: new Date("2011/12/26") },
                    { value: 40, date: new Date("2011/12/27") },
                    { value: 35, date: new Date("2011/12/28") },
                    { value: 43, date: new Date("2011/12/29") },
                    { value: 38, date: new Date("2011/12/30") },
                    { value: 30, date: new Date("2011/12/31") },
                    { value: 48, date: new Date("2012/01/01") },
                    { value: 50, date: new Date("2012/01/02") },
                    { value: 55, date: new Date("2012/01/03") },
                    { value: 35, date: new Date("2012/01/04") },
                    { value: 30, date: new Date("2012/01/05") }
                ]
            },
            series: [{
                type: "line",
                aggregate: "avg",
                field: "value",
                categoryField: "date"
            }],
            categoryAxis: {
                baseUnit: "weeks"
            }
        });
    }
    createChart2();
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
        bindViewModel(e);
    });

    $('#logout').click(() => {
        localStorage.clear();
        window.location = baseurl + "/view/login.html";
    });
});


