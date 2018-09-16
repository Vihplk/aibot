$(document).ready(function () {

    localStorage.setItem("baseurl", "http://localhost:5500");

    $("#login").click(function () {
        $.ajax({
            url: localStorage.getItem("baseurl") + '/api/security/login',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            caher: false,
            data: JSON.stringify({ Email: $('#inputEmail').val(), Password: $('#inputPassword').val() }),
            success: function (data) {
                localStorage.setItem("token", data);
                window.location = localStorage.getItem("baseurl")+"/view/dashboard.html";
            },
            error: function(e) {
                alert(e.responseText);
            }
        });
    });
});
