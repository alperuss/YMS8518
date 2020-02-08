"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/websocket").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    message = message.replace(/:)/g, "<img src='/img/icon_smile.png' style= height:30px;'/>")
    message = message.replace(/:(/g, "<img src='/img/icon_sad.png' style= height:30px;'/>")
    message = message.replace(/;)/g, "<img src='/img/icon_blink.png' style= height:30px;'/>")
    message = message.replace(/bravo/g, "<img src='/img/icon_clap.png' style= height:30px;'/>")
    message = message.replace(/8\)/g, "<img src='/img/icon_cool.png' style= height:30px;'/>")
    message = message.replace(/:\'\(/g, "<img src='/img/icon_cry.png' style= height:30px;'/>")
    message = message.replace(/:E/g, "<img src='/img/icon_evil.png' style= height:30px;'/>")
    message = message.replace(/:D/g, "<img src='/img/icon_laugh.png' style= height:30px;'/>")
    message = message.replace(/<3/g, "<img src='/img/icon_love.png' style= height:30px;'/>")
    message = message.replace(/:T/g, "<img src='/img/icon_think.png' style= height:30px;'/>")
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();

    message = "<li>" + user + ":" + message + "  Time:" + h + ":" + m + ":" + s + "</li>";
    
    document.getElementById("messagesList").innerHTML =
        document.getElementById("messagesList").innerHTML + message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});