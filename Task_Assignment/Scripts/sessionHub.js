$(function () {
    // Reference the auto-generated proxy for the hub.
    var hub = $.connection.sessionHub;
    hub.client.refresh = function () {
        location.reload();
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        console.log("Connection established.")
        $('#sendmessage').click(function () {
            hub.server.hello();
        });
    });
})