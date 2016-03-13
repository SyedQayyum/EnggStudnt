function ResultVM() {

    result = this;
    result.resultArray = ko.observableArray();
    result.universityArray = ko.observableArray();

    $.ajaxSetup({ async: false });
    result.GetAllResults = function () {

        $.getJSON("../api/result/GetAllResults", function (resultList) {
            ko.utils.arrayMap(resultList, function (res) {
                result.resultArray.push(res);
            })
        })
    }

    result.GetAllUniversities = function () {

        $.getJSON("../api/university/GetAllUniversities", function (universityList) {
            ko.utils.arrayMap(universityList, function (uni) {
                result.universityArray.push(uni);
            })
        })
    }
}




$(function () {

    var resultVM = new ResultVM();
    resultVM.GetAllResults();
    resultVM.GetAllUniversities();
    ko.applyBindings(resultVM, document.getElementById('results'));
    ko.applyBindings(resultVM, document.getElementById('universities'));
    $('#PageBody').show();

});