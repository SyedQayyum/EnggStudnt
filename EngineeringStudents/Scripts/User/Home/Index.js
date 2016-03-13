function HomeVM() {

    home = this;
    home.departmentsArray = ko.observableArray();


    $.ajaxSetup({ async: false });
    home.GetAllDepartments = function () {
        $.getJSON("../api/department/GetAllDepartments", function (deptList) {
            ko.utils.arrayMap(deptList, function (dept) {
                home.departmentsArray.push(dept);
            })
        })
    }

    home.GetAvailableSubjects = function (dept) {
        debugger;
        window.location.href = "../QsPaper/AvailableSubjects?deptId=" + dept.id;
        return false;
    }
}




$(function () {

    var homevm = new HomeVM();
    homevm.GetAllDepartments();
    ko.applyBindings(homevm, document.getElementById('departments'));
    $('#PageBody').show();

});