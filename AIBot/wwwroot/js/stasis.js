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


