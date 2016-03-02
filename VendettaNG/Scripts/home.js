
$(document).ready(function () {
    $(function () {
        // Declare a proxy to reference the hub. 
        var chat = $.connection.servicioHub;
        // Create a function that the hub can call to broadcast messages.
        chat.client.recibirMensaje = function (message) {
        };
        // Start the connection.
        $.connection.hub.start().done(function () {});
    });
});