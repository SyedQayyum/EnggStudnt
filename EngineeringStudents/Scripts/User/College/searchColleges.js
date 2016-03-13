var cityString = "";
var ratingString = "";

function CollegeVM() {

    college = this;
    college.cityArray = ko.observableArray();
    college.collegeArray = ko.observableArray();
    college.reviewArray = ko.observableArray([100, 80, 60, 40, 20]);


    $.ajaxSetup({ async: false });

    college.GetAllCities = function () {
        $.getJSON("../api/common/GetAllCities", function (CityList) {
            ko.utils.arrayMap(CityList, function (city) {
                college.cityArray.push(city);
            })
        })
    }

    college.GetAllColleges = function (isTop, cities, ratings) {
        $.getJSON("../api/college/GetAllColleges?isTop=" + isTop + "&cities=" + cities + "&ratings=" + ratings, function (CollegeList) {
            college.collegeArray.removeAll();
            ko.utils.arrayMap(CollegeList, function (coll) {
                coll.collRating = (coll.collRating / 5 * 100) + "%";
                college.collegeArray.push(coll);
            })
        })
    }

    college.RedirectToCollegeDetails = function (college) {

        window.location.href = "../College/CollegeDetails?collId=" + college.id;
        return false;

    }


    college.searchCollegeByCity = function (element, event) {

        var tempCity = "$" + element.Id;
        if (event.target.checked)
            cityString += tempCity;
        else
            cityString = cityString.replace(tempCity, '');

        bindColleges(false, cityString, ratingString);

    }

    college.searchCollegeByRating = function (element, event) {

        var tempRating = "$" + parseInt(element) / 100 * 5;
        if (event.target.checked)
            ratingString += tempRating;
        else
            ratingString = ratingString.replace(tempRating, '');

        bindColleges(false, cityString, ratingString);
    }

    college.calWidth = function (rating) {
        return rating + '%';
    }
}



$(function () {

    collegeVM = new CollegeVM();
    collegeVM.GetAllCities();
    ko.applyBindings(collegeVM, document.getElementById('cities'));
    ko.applyBindings(collegeVM, document.getElementById('reviews'));
    bindColleges(true, null, null);
    ko.applyBindings(collegeVM, document.getElementById('pageContent'));
    $('#PageBody').show();

});

function bindColleges(isTop, cities, ratings) {
    collegeVM.GetAllColleges(isTop, cities, ratings);
}