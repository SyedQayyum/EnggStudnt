
function QsPaperVM() {

    qsPaper = this;
    qsPaper.subjectId = ko.observable();
    qsPaper.qsContentRegular = ko.observable();
    qsPaper.qsContentSupplementary = ko.observable();
    qsPaper.pageOrder = ko.observable();
    qsPaper.branchShortName = ko.observable();
    qsPaper.deptName = ko.observable();
    qsPaper.semName = ko.observable();
    qsPaper.subjectArray = ko.observableArray();
    qsPaper.navigationLink = ko.observable();
    qsPaper.navigationTitle = ko.observable();


    $.ajaxSetup({ async: false })

    qsPaper.GetQsPaperByHeading = function (qsPaperHeading, SubId, PageOrder) {

        qsPaperHeading = qsPaperHeading == 'null' ? null : qsPaperHeading;
        $.getJSON("../api/QsPaper/GetQsPaperByHeading?QsHeading=" + qsPaperHeading + "&SubId=" + SubId + "&PageOrder=" + PageOrder, function (QsPaper) {
            qsPaper.subjectId(QsPaper.subId);
            debugger;
            qsPaper.pageOrder(QsPaper.qsPageOrder);
            qsPaper.qsContentRegular(QsPaper.qsContentRegular);
            qsPaper.qsContentSupplementary(QsPaper.qsContentSupplementary);
        })
        ko.cleanNode(document.getElementById("pageContent"));
        ko.applyBindings(qsPaper, document.getElementById('pageContent'));
    }

    qsPaper.GetQsPaperSideNavigation = function () {
        $.getJSON("../api/subject/GetRelatedSubjectsBySubId?subId=" + qsPaper.subjectId(), function (subjectList) {
            ko.utils.arrayMap(subjectList, function (subject) {
                qsPaper.subjectArray.push(new QsPaperYear(subject));
            })
        })
    }

    qsPaper.GetDepartmentBySubjectId = function () {
        $.getJSON("../api/subject/GetRelatedSubjectsBySubId?subId=" + qsPaper.subjectId(), function (subjectList) {
            ko.utils.arrayMap(subjectList, function (subject) {
                qsPaper.subjectArray.push(new QsPaperYear(subject));
            })
        })
    }
}


function QsPaperYear(subject) {
    var qsPaperYear = this;
    qsPaperYear.subjectName = subject.Name;
    qsPaperYear.qsPaperArray = ko.observableArray();
    $.getJSON("../api/QsPaper/GetQsPaperYearBySubjectId?subjectId=" + subject.Id, function (qsPaperList) {
        ko.utils.arrayMap(qsPaperList, function (qsPaper) {
            qsPaperYear.qsPaperArray.push(qsPaper);
        })
    })
}


$(function () {

    var qsPapervm = new QsPaperVM();
    var qsPaperHeading = $.query.get("qsPaperHeading");
    var qsPaperSubjectId = $.query.get("subjectId");
    debugger;
    var pageOrder = qsPaperSubjectId == "" ? null : 1;
    qsPapervm.GetQsPaperByHeading(qsPaperHeading, qsPaperSubjectId, pageOrder);
    qsPapervm.GetQsPaperSideNavigation();
    ko.applyBindings(qsPapervm, document.getElementById('sideNavigation'));
    $('#PageBody').show();

    $(".pager").click(function () {
        $('html,body').animate({ scrollTop: 0 }, 'slow', function () { });
    })


})