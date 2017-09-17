
function generateNavHtml(menuList) {
    var innerhtml = "";
    if (menuList.subMenuList != "undefined" && menuList.subMenuList != null && menuList.subMenuList.length > 0) {
        innerhtml += "<ul>";
        for (var j = 0; j < menuList.subMenuList.length; j++) {
            if (menuList.subMenuList[j].url == "") {
                innerhtml += "<li><a href=\"javascript:void(0);\"><span>" + menuList.subMenuList[j].title + "</span>";
            }
            else {
                innerhtml += "<li><a class=\"Wk_menuItem\" href=\"" + menuList.subMenuList[j].url + "\" target=\"frameRight\"><span>" + menuList.subMenuList[j].title + "</span>";
            }
            if (menuList.subMenuList[j].subMenuList != "undefined" && menuList.subMenuList[j].subMenuList != null && menuList.subMenuList[j].subMenuList.length > 0) {
                innerhtml += "<i class=\"glyphicon glyphicon-chevron-right\"></i></a>";
            }
            else {
                innerhtml += "</a>";
            }
            innerhtml += generateNavHtml(menuList.subMenuList[j]);
            innerhtml += "</li>";
        }

        innerhtml += "</ul>";
    }
    return innerhtml;
}

function browserCheck() {
    var sUserAgent = navigator.userAgent.toLowerCase();
    var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
    var bIsMidp = sUserAgent.match(/midp/i) == "midp";
    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
    var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
    var bIsAndroid = sUserAgent.match(/android/i) == "android";
    var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
    var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";

    if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) {
        //移动端;            

        $(".nav-left>li").on('touchstart', function (event) {
            if ($(this).children("ul").is(":hidden")) {
                $(this).children("ul").show();
            }
            else {
                $(this).find("ul").slideUp();
                $(this).find("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
            }
            event.stopPropagation();


        }).each(function (index, data) {
            $(data).on('touchstart', function (event) {
                $(data).siblings().find("a").children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                $(data).siblings().find("ul").slideUp();
                event.stopPropagation();
            });
        });


        $(".nav-left>li li>a").each(function (index, data) {
            $(data).on('touchstart', function (event) {
                if ($(data).children("i").hasClass("glyphicon-chevron-right")) {
                    $(data).children("i").removeClass("glyphicon-chevron-right").addClass("glyphicon-chevron-down");
                    $(data).next("ul").slideDown();
                    $(data).next("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                    $(data).parent().siblings().find("ul").slideUp();
                    $(data).parent().siblings().find("a").children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                }
                else {
                    $(data).next("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                    $(data).next("ul").slideUp();
                    $(data).children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                }
                if ($(data).children("i").length == 0) {
                    $(".nav-left>li").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                    $(".nav-left").find("ul").slideUp(500);
                }
                event.stopPropagation();

            });
        });


    } else {
        // PC端;
        if ($(window).width() < 791) {
            forPcLittleScreen();
        }
        $(window).resize(function () {
            window.location.reload();
        });
    }
}

//PC端适应屏幕小样式
function forPcLittleScreen() {
    $(".nav-left>li").on('click touchstart', function (event) {
        if ($(this).children("ul").is(":hidden")) {
            $(this).children("ul").show();
        }
        else {
            $(this).find("ul").slideUp();
            $(this).find("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
        }
        event.stopPropagation();
    }).each(function (index, data) {
        $(data).on('click touchstart', function (event) {
            $(data).siblings().find("a").children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
            $(data).siblings().find("ul").slideUp();
            event.stopPropagation();
        });
    });

    $(".nav-left>li li>a").each(function (index, data) {
        $(data).on('click touchstart', function (event) {
            if ($(data).children("i").hasClass("glyphicon-chevron-right")) {
                $(data).children("i").removeClass("glyphicon-chevron-right").addClass("glyphicon-chevron-down");
                $(data).next("ul").slideDown();
                $(data).next("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                $(data).parent().siblings().find("ul").slideUp();
                $(data).parent().siblings().find("a").children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
            }
            else {
                $(data).next("ul").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                $(data).next("ul").slideUp();
                $(data).children("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
            }
            if ($(data).children("i").length == 0) {
                $(".nav-left>li").find("i").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
                $(".nav-left").find("ul").slideUp(500);
            }
            event.stopPropagation();
        });
    })
   
}



(function () {
    var menuLiList = "<ul class=\"nav-left\">";
    if (menuList != undefined && menuList != null && menuList.length > 0) {
        for (var i = 0; i < menuList.length; i++) {
            if (menuList[i].subMenuList != "undefined" && menuList[i].subMenuList != null && menuList[i].subMenuList.length > 0) {
                menuLiList += "<li><div class=\"" + menuList[i].iconClass + "\"></div><a href=\"javascript:void(0);\"><span>" + menuList[i].title + "</span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

            }
            else {
                menuLiList += "<li><div class=\"" + menuList[i].iconClass + "\"></div><a class=\"Wk_menuItem\" href=\"" + menuList[i].url + "\" target=\"frameRight\"><span>" + menuList[i].title + "</span></a>";
            }
            menuLiList += generateNavHtml(menuList[i]);
            menuLiList += "</li>";
        }
    }

    menuLiList += "</ul>"

    if (menuLiList != "") {
        // console.log(menuLiList);
        document.getElementById("menu").innerHTML = menuLiList;
    }
    browserCheck();   

})()







