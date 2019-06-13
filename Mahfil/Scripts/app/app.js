/*  //Revealing module pattern
var f = function () {
    var firstName = "Arif";
    console.log(firstName);
}();//IIFE
//f();
var g = function () {
    var firstName = "Arif";
    console.log(firstName);
}();
//Revealing Module Pattern
var Person = function(){
    var firstName = "Arif";
var sayHello = function () {//not supported in c#
    console.log(firstName);
    }
    return {
        sayHello: sayHello
    }
}();

Person.sayHello();
*/
  

var MahfilController = function () {
    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
       
    };
    var button;
    var toggleAttendance = function (e) {

        button = $(e.target);
        if (button.hasClass("btn-default")) 
            createAttendance();
        else 
            deleteAttendance();
        

    };
    var createAttendance = function () {
        $.post("/api/attendances", { "CongregrationId": button.attr("data-congregration-id") })
            .done(function () {
                button.removeClass("btn-default").addClass("btn-info").text("Going");
            }).fail(fail);
    };

    var deleteAttendance = function () {
        $.ajax({
            url: "/api/attendances/" + button.attr("data-congregration-id"),
            method: "DELETE"
        }).done(function () {
            button.removeClass("btn-info")
                .addClass("btn-default").text("Going?");
        }).fail(fail);
    }
    var fail = function () {
        alert("Something failed");
    };
    return { init: init }
}();

var MahfilDetailsController = function () {
    var followButton;
    var init = function () {
        $(".js-toggle-follow").click(toggleFollowing);
    };
    var toggleFollowing = function (e) {
       followButton = $(e.target);
        if (followButton.hasClass("btn-default"))
            createFollowing();
        else
            deleteFollowing();
    };

    var createFollowing = function () {
        $.post("/api/followings", { "followeeId": followButton.attr("data-user-id") })
            .done(function () {
                followButton.removeClass("btn-default").addClass("btn-info").text("Following");
            }).fail(fail);
    };

    var deleteFollowing = function () {
        $.ajax({
            url: "/api/followings/" + followButton.attr("data-user-id"),
            method: "DELETE"
        }).done(function () {
            followButton.removeClass("btn-info")
                .addClass("btn-default").text("Follow");
        }).fail(fail);
    };
    var fail = function () {
        alert("Something failed");
    };
    return { init: init }

}();


