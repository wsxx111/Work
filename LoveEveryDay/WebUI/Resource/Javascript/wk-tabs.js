+function () {
    //alert('nihao');
    // jQuery width() 和 height() 方法
    // width() 方法设置或返回元素的宽度（不包括内边距、边框或外边距）。
    //height() 方法设置或返回元素的高度（不包括内边距、边框或外边距）。
    //innerWidth() 方法返回元素的宽度（包括内边距）。
    //innerHeight() 方法返回元素的高度（包括内边距）。
    //outerWidth() 方法返回元素的宽度（包括内边距和边框）。
    //outerHeight() 方法返回元素的高度（包括内边距和边框）。
    //outerWidth(true) 方法返回元素的宽度（包括内边距、边框和外边距）。
    //<div style="width:300px;height:100px;padding:10px;margin:5px;border:2px solid red"></div>
    // width():300px    innerWidth():(300+10+10)px    outerWidth():(300+10+10+2+2)px   outerWidth(true) (300+10+10+2+2+5+5)px


    $(".Wk_menuItem").on("click touchstart", function () {
        var $_this = $(this);
        var noTab = true;
        var $tabActive = "";
        //获取当前激活tab   判断是否是新tab
        $(".page-tabs-content>a").each(function (index, data) {
            if ($(data).attr("href") == $_this.attr("href") && $(data).html().split("<span")[0] == $_this.children("span").text()) {
                noTab = false;
                $tabActive = $(data);
            }
        });

        if (noTab) {
            //新tab
            $(".page-tabs-content>a").removeClass("active");
            var tabHtml = "<a class=\"active\" target=\"frameRight\" href=\"" + $_this.attr("href") + "\"  data-id=\"" + $_this.attr("href") + "\">" + $_this.children("span").text() + "<span class=\"close-badge\"><i>&times;</i></span></a>";
            $(tabHtml).insertAfter($(".page-tabs-content").children("a:last-child"));
            $("#frameRight").attr("src", $_this.attr("href"));

            //删除tab    
            $(".page-tabs-content>a>span").unbind("click");
            $(".page-tabs-content>a>span").unbind("touchstart");
            $(".page-tabs-content>a>span").on("click touchstart", function () {
                var $nextO = $(this).parent().prev();
                if ($(this).parent().hasClass("active")) {
                    $(".page-tabs-content>a").removeClass("active");
                    $nextO.addClass("active");
                    $("#frameRight").attr("src", $nextO.attr("href"));
                }
                $(this).parent().remove();
                MoveTab();
                return false;
            });
        }
        else {

            $(".page-tabs-content>a").removeClass("active");
            $tabActive.addClass("active");
            $("#frameRight").attr("src", $_this.attr("href"));

        }

        $(".page-tabs-content>a").unbind("click");
        $(".page-tabs-content>a").unbind("touchstart");
        $(".page-tabs-content>a").on("click touchstart", function () {
            $(".page-tabs-content>a").removeClass("active");
            $(this).addClass("active");
            $("#frameRight").attr("src", $(this).attr("href"));


        })
        MoveTab();

        return false;
    });




    //切换tab    
    $(".roll-btn-left").on("click touchstart", function () {
        $(".page-tabs-content>a").each(function (index, data) {
            if ($(data).hasClass("active")) {
                if ($(data).prev().length > 0) {
                    $(".page-tabs-content>a").removeClass("active");
                    $(data).prev().addClass("active");
                    $("#frameRight").attr("src", $(data).prev().attr("href"));
                    MoveTab();
                }
            }
        });
        return false;
    });


    $(".roll-btn-right").on("click touchstart", function () {
        $(".page-tabs-content>a").each(function (index, data) {
            if ($(data).hasClass("active")) {
                if ($(data).next().length > 0) {
                    $(".page-tabs-content>a").removeClass("active");
                    $(data).next().addClass("active");
                    $("#frameRight").attr("src", $(data).next().attr("href"));
                    MoveTab();
                    return false;
                }

            }
        });
        return false;
    });

    //关闭所有
    $("#tabs_close").on("click touchstart", function () {
        var $firstTab = $(".page-tabs-content>a:first");
        $firstTab.addClass("active");
        $("#frameRight").attr("src", $firstTab.attr("href"));
        $(".page-tabs-content>a:not(:first)").remove();
        MoveTab();
    });

    //关闭其他所有
    $("#tabs_otherclose").on("click touchstart", function () {
        $(".page-tabs-content>a").each(function (index, data) {
            if ($(data).hasClass("active")) {
                $(".page-tabs-content>a:not(:eq(" + index + "),:eq(0))").remove();
            }
            MoveTab();
        });
    });

    var startX, sX, moveX, last_Tab, leftSc = 104;
    $(".page-tabs").on({
        touchstart: function (e) {
            startX = parseInt($(this).css("left")) - e.originalEvent.targetTouches[0].pageX;
            last_Tab = $(".page-tabs-content>a:last");
            if ($(window).width() > 790) {
                leftSc = 180;
            }


            return false;
        },
        touchmove: function (e) {
            e.preventDefault();
            moveX = e.originalEvent.targetTouches[0].pageX;          
            if (parseInt($(this).css("left")) <= 0 && last_Tab.offset().left >= leftSc) {
                $(this).css({
                    "left": moveX + startX > 0 ? 0 : moveX + startX
                });
            }
            return false;
        },
        touchend: function (e) {
            if (last_Tab.offset().left < leftSc) {
                $(this).css({
                    "left": parseInt($(this).css("left")) + 30
                });
            }
            return false;
        }

    });


}()

function getWidth($elem) {
    return $elem.outerWidth();
}



function MoveTab() {
    $(".page-tabs-content>a").each(function (index, data) {
        if ($(data).hasClass("active")) {
            var leftWidth = getAvailWidth($(data)) - getAllPrev($(data));
            if (leftWidth <= 0) {
                $(".page-tabs").css("left", leftWidth + "px");
            }
            else {
                $(".page-tabs").css("left", "0px");
            }
        }
    });
}

function getAllPrev($elem) {
    var allWidth = getWidth($elem);
    $elem.prevAll().each(function (index, data) {
        allWidth += getWidth($(data));
    });
    return allWidth;
}
function getAvailWidth() {
    var visiWidth = getWidth($(".content-tabs")) - getWidth($(".roll-btn-left")) - getWidth($(".roll-link-right")) - getWidth($(".roll-btn-right"));
    if (!$(".roll-group-right").is(":hidden")) {
        visiWidth -= getWidth($(".roll-group-right"));
    }
    return visiWidth;
}