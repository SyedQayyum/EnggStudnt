var allSubject = null;
function SubjectVM() {

    subject = this;
    subject.semesterArray = ko.observableArray();
    $.ajaxSetup({ async: false });
    subject.GetAvailableSubjects = function (branchId) {
        $.getJSON("../api/subject/GetAllSubjects?subId=&semId=&branchId=" + branchId, function (subjectList) {
            allSubject = subjectList;
            $.ajaxSetup({ async: false });
            var semesterArray = Enumerable.From(allSubject).Distinct(function (x) { return x.semId }).Select(function (x) { return x.semName }).ToArray();

            ko.utils.arrayMap(semesterArray, function (sem) {

                subject.semesterArray.push(new SubjectsClass(sem));

            });

        });


    }
    subject.GetQsPaperBySubject = function (subject) {
        debugger;

        window.location.href = "../QsPaper/QsPaperDetails?subjectId=" + subject.id;
        return false;
    }

}

function SubjectsClass(semester) {
    var sub = this;
    sub.subjectArray = ko.observableArray(Enumerable.From(allSubject).Where(function (x) { return x.semName == semester }).Select(function (x) { return x }).ToArray());
    sub.semName = ko.observable(semester);

}



$(function () {

    subjectVM = new SubjectVM();
    var deptId = $.query.get("deptId");
    subjectVM.GetAvailableSubjects(deptId);

    ko.applyBindings(subjectVM, document.getElementById('subjects'));
    $('#PageBody').show();



});