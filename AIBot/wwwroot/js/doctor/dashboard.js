function createChart() {
    $("#chart").kendoChart({
        title: {
            text: "Mental Symptomes Status"
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
                category: "Football",
                value: 35
            }, {
                category: "Basketball",
                value: 25
            }, {
                category: "Volleyball",
                value: 20
            }, {
                category: "Rugby",
                value: 10
            }, {
                category: "Tennis",
                value: 10
            }]
        }],
        tooltip: {
            visible: true,
            template: "#= category # - #= kendo.format('{0:P}', percentage) #"
        }
    });
}

$(document).ready(function() {
    createChart();
    $(document).bind("kendo:skinChange", createChart);
    $(".box").bind("change", refresh);
});