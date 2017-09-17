<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_test.aspx.cs" Inherits="LoveEveryDay.WebUI.Content.总结.前端.菜单样式.menu_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        ul, li, a, body {
            margin: 0px;
            padding: 0px;
        }

        li {
            list-style: none;
        }

            li a {
                font-family: 'Microsoft YaHei';
                text-decoration: none;
                color: #146883;
                display: block;
                width: 100%;
            }

        body {
            background-color: rgb(216,237,252);
            width: 100%;
            height: 100%;
        }

        .L_menu {
            width: 160px;
            overflow-y: auto;
            min-height: 400px;
            display: block;
        }

        .L_item > ul {
            background-color: rgb(142,196,233);
            display: none;
        }

        .L_item > a {
            font-size: 12px;
            line-height: 24px;
            font-weight: bold;
            line-height: 23px;
            background: -moz-linear-gradient(top, rgb(255,255,255) 5%, rgb(189,224,248) 50%,rgb(189,224,248));
            background: -webkit-linear-gradient(top, rgb(255,255,255) 5%, rgb(189,224,248) 50%,rgb(189,224,248));
            background: -o-linear-gradient(top, rgb(255,255,255) 5%, rgb(189,224,248) 50%,rgb(189,224,248));
            border: 1px solid rgb(147,200,237);
            border-radius: 2px;
            margin-bottom: 4px;
            position: relative;
        }

            .L_item > a.active {
                color: #146883;
                background: -moz-linear-gradient(top, rgb(255,206,149) 5%,rgb(255,206,149) 46%,rgb(252,180,72) 46%,rgb(255,204,103));
                background: -webkit-linear-gradient(top, rgb(255,206,149) 5%,rgb(255,206,149) 46%,rgb(252,180,72) 46%,rgb(255,204,103));
                background: -o-linear-gradient(top, rgb(255,206,149) 5%,rgb(255,206,149) 46%,rgb(252,180,72) 46%,rgb(255,204,103));
            }

                .L_item > a.active::before {
                    content: '√';
                    font-size: 14px;
                    font-family: 'Microsoft YaHei';
                    position: absolute;
                    left: 20px;
                    font-weight: bold;
                    color: #40bf42;
                    text-shadow: 0 0 6px #fbe708;
                }

        .L_item > ul a {
            margin-bottom: 1px;
            font-size: 13px;
            line-height: 30px;
            background-color: rgb(142,196,233);
        }

            .L_item > ul a:hover {
                background-color: white;
                color: #ff6a00;
            }

            .L_item > ul a.active {
                background-color: white;
                color: #40bf42;
                font-weight: bold;
                position: relative;
            }

                .L_item > ul a.active::after {
                    content: '→';
                    font-size: 14px;
                    font-family: 'Microsoft YaHei';
                    position: absolute;
                    right: 10px;
                    font-weight: 900;
                    color: #40bf42;
                }

        .L_item {
            overflow-y: hidden;
            overflow-x: hidden;
            margin: 3px 3px;
            padding: 0px 2px;
            text-align: center;
        }
    </style>
</head>
<body>
    <%--<asp:Label ID="Menu" CssClass="L_menu" runat="server" Text="Label"></asp:Label>--%>
    <div class="L_menu">
        <ul>
            <li class="L_item"><a href="javascript:void(0)">报表统计</a><ul>
                <li><a href="javascript:void(0)">报警日志查询</a></li>
                <li><a href="javascript:void(0)">报警分析报表</a></li>
                <li><a href="javascript:void(0)">轨迹报表</a></li>
                <li><a href="javascript:void(0)">报警明细</a></li>
            </ul>
            </li>
            <li class="L_item on" style="height: 89px;"><a href="javascript:void(0)" class="active">用车审批</a><ul style="display: block;">
                <li><a href="javascript:void(0)" class="">维修审核</a></li>
                <li><a href="javascript:void(0)" class="active">维修申请</a></li>
            </ul>
            </li>
            <li class="L_item" style="height: 28px;"><a href="javascript:void(0)" class="">驾驶员</a></li>
            <li class="L_item" style="height: 28px;"><a href="javascript:void(0)" class="">系统设置</a><ul style="display: block;">
                <li><a href="javascript:void(0)">菜单管理</a></li>
            </ul>
            </li>
            <li class="L_item"><a href="javascript:void(0)">员工管理</a></li>
        </ul>
    </div>
</body>
</html>
<script src="../../../../Resource/Javascript/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {      
        $(".L_item>a").click(function () {
            toggleMenu($(this));
        });
        $(".L_item>ul a").click(function () {
            toggleSelect($(this));
        });

    });

    function toggleSelect($obj) {
        if (!$obj.hasClass("active")) {
            {
                $(".L_item>ul").find("a").removeClass("active");
                $obj.addClass("active");
            }
        }
    }

    function toggleMenu($obj) {
        var $parent = $obj.parent();
        var $bother = $obj.next("ul");
        if ($parent.hasClass("on")) {
            $parent.removeClass("on");
            $obj.removeClass("active");
            $parent.animate({ height: "28px" }, 300);
        }
        else {
            if ($bother.is(":hidden")) {
                $bother.css("display", "block");
                $parent.css({ "height": "28px" });
            }
            $parent.siblings().each(function () {
                var otherobj = $(this);
                if (otherobj.hasClass("on")) {
                    otherobj.removeClass("on");
                    otherobj.children("a").removeClass("active");
                    otherobj.animate({ height: "28px" }, 300);
                }
            });
            $obj.addClass("active");
            var getHeight = parseInt($bother.height());
            $parent.addClass("on");
            $parent.animate({ height: (getHeight + 28) + "px" }, 300);
        }
    }

</script>
