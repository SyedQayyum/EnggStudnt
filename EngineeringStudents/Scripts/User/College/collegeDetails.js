function CollegeVM() {

    college = this;
    college.collId = ko.observable();
    college.universityId = ko.observable();
    college.collName = ko.observable();
    college.collAddress = ko.observable();
    college.collCity = ko.observable();
    college.collLogo = ko.observable();
    college.collRating = ko.observable();
    college.collPhone = ko.observable();
    college.collWebsite = ko.observable();
    college.collFax = ko.observable();
    college.collEmail = ko.observable();
    college.coursesOffered = ko.observable();
    college.collStablishedYear = ko.observable();
    college.reviewArray = ko.observableArray();

    $.ajaxSetup({ async: false });

    college.GetCollegeDetails = function (collegeId) {
        $.getJSON("../api/college/GetCollegeDetails?collId=" + collegeId, function (coll) {
            college.collId(coll.collId);
            college.universityId(coll.universityId);
            college.collName(coll.collName);
            $('#collgeName').text(coll.collName);
            college.collAddress(coll.collAddress);
            college.collCity(coll.collCity);
            college.collLogo(coll.collLogo);
            var rating = parseInt(coll.collRating) / 5 * 100 + '%';
            college.collRating(rating);
            college.collPhone(coll.collPhone);
            college.collWebsite(coll.collWebsite);
            college.collFax(coll.collFax);
            college.collEmail(coll.collEmail);
            college.coursesOffered(coll.coursesOffered);
            college.collStablishedYear(coll.collStablishedYear);

        });

        college.GetCollegeReviews = function (collegeId) {
            $.getJSON("../api/college/GetCollegeReviews?collId=" + collegeId, function (ReviewList) {
                ko.utils.arrayMap(ReviewList, function (review) {
                    college.reviewArray.push(review);
                })
            })
        }
    }
}



$(function () {

    var collegeVM = new CollegeVM();
    var collId = $.query.get("collId");
    collegeVM.GetCollegeDetails(collId);
    college.GetCollegeReviews(collId);
    ko.applyBindings(collegeVM, document.getElementById('collegeDetails'));
    ko.applyBindings(collegeVM, document.getElementById('collegeReviews'));
    $('#PageBody').show();
});