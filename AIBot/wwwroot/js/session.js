$(document).ready(function () {
    $("#createnewsession").click(function () {
        if (!confirm('do you need to create new exam')) {
            return;
        }
        $.ajax({
            url: localStorage.getItem("baseurl") +'/api/sessions',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            caher: false,
            data: null,
            success: function (data) {
                localStorage.setItem("session", data);
                window.location = localStorage.getItem("baseurl") +"/view/chatbot.html";
            },
            error: function (e) {
                alert('error');
            }
        });
    });
});

