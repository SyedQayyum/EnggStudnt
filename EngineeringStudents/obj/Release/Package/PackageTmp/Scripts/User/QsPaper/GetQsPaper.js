
function QsPaperVM() {

    var qsPaper = this;
    qsPaper.pageContent = ko.observable();
    qsPaper.previousPage = ko.observable();
    qsPaper.nextPage = ko.observable();

    qsPaper.GetQsPaperByHeading = function (qsPaperHeading) {
    
        $.getJSON("../api/QsPaperApi/GetQsPaperByHeading?QsHeading=" + qsPaperHeading, function (QsPaper) {
            debugger;
            var jsonData = $.parseJSON(QsPaper)["Table"][0];
            qsPaper.pageContent(jsonData.qsDetail);
        })
    }


    qsPaper.GetAdvertisement = function () {
        $.getJSON("../api/advertisementApi/GetAdvertisements", function (advertisement) {
            for (var i = 0; i < advertisement.length; i++) {
                var record = advertisement[i];
                $('#' + record.advPlaceHolderId).attr("src", record.advContent);
            }
        })
    }

    qsPaper.GetQsPaperSideNavigation = function () {


    }
}





$(function () {

    var qsPapervm = new QsPaperVM();
    var qsPaperHeading = $.query.get("qsPaperHeading");
    qsPapervm.GetQsPaperByHeading(qsPaperHeading);
    qsPapervm.GetAdvertisement();
    ko.applyBindings(qsPapervm, document.getElementById('pageContent'));
})