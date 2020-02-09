"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/websocket").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
  

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