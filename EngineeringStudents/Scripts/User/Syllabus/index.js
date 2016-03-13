
function SyllabusVM() {

    syllabus = this;
    syllabus.subjectId = ko.observable();
    syllabus.syllabusContent = ko.observable();
    syllabus.pageOrder = ko.observable();
    syllabus.branchShortName = ko.observable();
    syllabus.branchName = ko.observable();
    syllabus.subjectArray = ko.observableArray();
    syllabus.navigationLink = ko.observable();
    syllabus.navigationTitle = ko.observable();


    $.ajaxSetup({ async: false })

    syllabus.GetSyllabusByHeading = function (syllabusHeading, SubId, PageOrder) {

        syllabusHeading = syllabusHeading == 'null' ? null : syllabusHeading;
        $.getJSON("../api/syllabus/GetSyllabusByHeading?syllabusHeading=" + syllabusHeading + "&SubId=" + SubId + "&PageOrder=" + PageOrder, function (Syllabus) {
            syllabus.subjectId(Syllabus.subId);
            syllabus.pageOrder(Syllabus.syllabusPageOrder);
            syllabus.syllabusContent(Syllabus.syllabusContent);
            if (Syllabus.subId == undefined)
                debugger;
                syllabus.syllabusContent(Syllabus.Message);
        
        })
        ko.cleanNode(document.getElementById("pageContent"));
        ko.applyBindings(syllabus, document.getElementById('pageContent'));
    }

    //qsPaper.GetQsPaperSideNavigation = function () {
    //    $.getJSON("../api/subject/GetRelatedSubjectsBySubId?subId=" + qsPaper.subjectId(), function (subjectList) {
    //        ko.utils.arrayMap(subjectList, function (subject) {
    //            qsPaper.subjectArray.push(new QsPaperYear(subject));
    //        })
    //    })
    //}

    //qsPaper.GetDepartmentBySubjectId = function () {
    //    $.getJSON("../api/subject/GetRelatedSubjectsBySubId?subId=" + qsPaper.subjectId(), function (subjectList) {
    //        ko.utils.arrayMap(subjectList, function (subject) {
    //            qsPaper.subjectArray.push(new QsPaperYear(subject));
    //        })
    //    })
    //}
}


//function QsPaperYear(subject) {
//    var qsPaperYear = this;
//    qsPaperYear.subjectName = subject.Name;
//    qsPaperYear.qsPaperArray = ko.observableArray();
//    $.getJSON("../api/QsPaper/GetQsPaperYearBySubjectId?subjectId=" + subject.Id, function (qsPaperList) {
//        ko.utils.arrayMap(qsPaperList, function (qsPaper) {
//            qsPaperYear.qsPaperArray.push(qsPaper);
//        })
//    })
//}


$(function () {

    var syllabusvm = new SyllabusVM();
    var syllabusHeading = $.query.get("syllabusHeading");
    syllabusvm.GetSyllabusByHeading(syllabusHeading, null, null);

})