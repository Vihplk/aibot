$(document).ready(function() {

    var me = {};
    me.avatar = "../images/me.png";

    var you = {};
    you.avatar = "https://cdn.iconscout.com/icon/premium/png-512-thumb/ai-63-407907.png";

    function formatAMPM(date) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        return strTime;
    }

//-- No use time. It is a javaScript effect.
    function insertChat(who, text, time) {
        if (time === undefined) {
            time = 0;
        }
        var control = "";
        var date = formatAMPM(new Date());

        if (who === "me") {
            control = '<li style="width:100%">' +
                '<div class="msj macro">' +
                '<div class="avatar"><img class="img-circle" style="width:75px;" src="' +
                me.avatar +
                '" /></div>' +
                '<div class="text text-l">' +
                '<p>' +
                text +
                '</p>' +
                '<p><small>' +
                date +
                '</small></p>' +
                '</div>' +
                '</div>' +
                '</li>';
        } else {
            control = '<li style="width:100%;">' +
                '<div class="msj-rta macro">' +
                '<div class="text text-r">' +
                '<p>' +
                text +
                '</p>' +
                '<p><small>' +
                date +
                '</small></p>' +
                '</div>' +
                '<div class="avatar" style="padding:0px 0px 0px 10px !important"><img class="img-circle" style="width:75px;" src="' +
                you.avatar +
                '" /></div>' +
                '</li>';
        }
        setTimeout(
            function() {
                $("ul").append(control).scrollTop($("ul").prop('scrollHeight'));
            },
            time);

    }

    function resetChat() {
        $("ul").empty();
    }

    $(".mytext").on("keydown",
        function(e) {
            if (e.which === 13) {
                var text = $(this).val();
                if (text !== "") {
                    insertChat("me", text);
                    $(this).val('');
                    pushChat(text);
                }
            }
        });

    $('body > div > div > div:nth-child(2) > span').click(function() {
        $(".mytext").trigger({ type: 'keydown', which: 13, keyCode: 13 });
    })

//-- Clear Chat
    resetChat();
 
    function pushChat(answername) {
        $.ajax({
            url: localStorage.getItem("baseurl") + '/api/chat/answer',
            type: 'post',
            contentType: 'application/json; charset=utf-8',
            caher: false,
            data: JSON.stringify({
                SessionId: parseInt(localStorage.getItem("session")),
                Index: index, AnswerName: answername, QuestionId: qid}),
            success: function (data) {
                index++;
                qid = data.id;
                insertChat("you", data.questionName, 1500);
            },
            error: function (e) {
                alert('error');
            }
        });
    }

    var qid = 1;
    var index = 1;
    function initChat() {
        $.ajax({
            url: localStorage.getItem("baseurl") + '/api/chat/questions/' + parseInt(localStorage.getItem("session")) + '/' + index,
            type: 'get',
            contentType: 'application/json; charset=utf-8',
            caher: false,
            data: null,
            success: function (data) {
                insertChat("you", data.questionName, 1500);
                index++;
            },
            error: function (e) {
                alert('error');
            }
        });
    }

    initChat();
});