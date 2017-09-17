
function generateNavHtml(menuList) {
    var innerHtml = "<ul>";
    for (var i = 0; i < menuList.length; i++) {
        if (menuList[i].subMenuList != undefined && menuList[i].subMenuList != null && menuList[i].subMenuList.length > 0) {
            innerHtml += "<li class=\"icon icon-arrow-left\"><a class=\"" + menuList[i].iconClass + "\" href=\"javascript:void(0);\">" + menuList[i].title + "</a><div class=\"mp-level\"><h2 class=\"" + menuList[i].iconClass + "\">" + menuList[i].title + "</h2><a class=\"mp-back\" href=\"javascript:void(0);\">back</a>";
            innerHtml += generateNavHtml(menuList[i].subMenuList);
        }
        else {
            //innerHtml += "<li><a href=\"javascript:void(0);\" class=\"pageurl\" data-pageurl=\"" + menuList[i].url + "\">" + menuList[i].title + "</a>";
            innerHtml += "<li><a class=\"do_href\" href=\"" + menuList[i].url + "\" target=\"frameRight\">" + menuList[i].title + "</a>";
        }
        innerHtml += "</li>";
    }
    innerHtml += "</ul>";   
    return innerHtml;
}


(function () { 
    var menuLiList = "<div class=\"mp-level\"><ul>";
    for (var i = 0; i < menuList.length; i++) {
        if (menuList[i].subMenuList != undefined && menuList[i].subMenuList != null && menuList[i].subMenuList.length > 0) {
            menuLiList += "<li class=\"icon icon-arrow-left\"><a class=\"" + menuList[i].iconClass + "\" href=\"javascript:void(0);\">" + menuList[i].title + "</a><div class=\"mp-level\"><h2 class=\"" + menuList[i].iconClass + "\">" + menuList[i].title + "</h2><a class=\"mp-back\" href=\"javascript:void(0);\">back</a>";
            menuLiList += generateNavHtml(menuList[i].subMenuList);
            menuLiList +="</div>";
        }
        else {
            //menuLiList += "<li><a href=\"javascript:void(0);\" data-pageurl=\"" + menuList[i].url + "\">" + menuList[i].title + "</a>";
            menuLiList += "<li><a class=\"do_href\" href=\"" + menuList[i].url + "\" target=\"frameRight\">" + menuList[i].title + "</a>";
        }
        menuLiList += "</li>";
    }
    menuLiList += "</ul></div>";

    if (menuLiList != "") {
       // console.log(menuLiList);
        document.getElementById("mp-menu").innerHTML = menuLiList;
                     
    }
 

})()
