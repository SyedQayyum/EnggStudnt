
$(function () {

    var pageUrl = window.location.pathname;
    $.getJSON("../api/advertisement/GetAdvertisements?url=" + pageUrl, function (advertisement) {
        for (var i = 0; i < advertisement.length; i++) {
            var record = advertisement[i];
            $('#' + record.advPlaceHolderId).attr("src", record.advContent);
        }
    })
})