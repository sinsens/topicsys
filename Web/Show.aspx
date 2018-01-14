<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Topicsys.Web.ShowNotice" %>

<!DOCTYPE html>
<html lang="zh">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/mui.min.css" rel="stylesheet" />
    <script src="/js/mui.min.js"></script>
    <script src="/js/app.js"></script>
    <script src="/js/jquery.min.js"></script>
    <link href="/css/MyStyle/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <noscript>
        <div style="color: Red; font-size: 2em; height: 1000px; padding: 20px">
            本系统需要浏览器启用Javascript支持，否则无法正常使用。关于浏览器如何启用JavaScript支持，请参阅=>各种浏览器开启JavaScript脚本方法:<a
                href="http://360.bgu.edu.cn/help/openJsHelp.html">http://360.bgu.edu.cn/help/openJsHelp.html</a>。
            <br />
            <br />
            推荐使用谷歌浏览器：<a href="http://www.google.cn/chrome/browser/desktop/index.html">http://www.google.cn/chrome/browser/desktop/index.html</a>
            <br />
            <br />
            <a href="/">重新加载</a>
        </div>
    </noscript>
    <div class="row">
        <div class="col-12" style="background: #0094ff;">
            <h1 class="mytitle">
                论文选题管理系统</h1>
            <span id="panelShowTime">&emsp;
                <script type="text/javascript">
                    /*
                    function writeNow() {
                    document.getElementById("panelShowTime").innerText = (new Date().Format("yyyy年-M月-dd日 星期w hh:mm:ss"));
                    };
                    setInterval("writeNow()", 1000);
                    */
                </script>
            </span><span id="showLogin_name">
                <%
                    ///登录后相关角色相关链接
                    if (Session["login_name"] != null)
                    {
                        if (Session["type"].Equals("student"))
                            Response.Write("<a href='/select/default.aspx' style='color: #fff'>" + Session["login_name"] + "</a>，");
                        else
                            Response.Write("<a href='/Admin/' style='color: #fff'>" + Session["login_name"] + "</a>，");//显示管理员后台链接

                        Response.Write("<a href='#' style='color: #fff' onclick='return mui.confirm(\"确认注销？\",\"温馨提示\",[\"取消\",\"注销\"],function(e){if(e.index==1)top.location.href = \"/logout.aspx\";})'>注销</a>");//显示注销链接
                    }
                %>
            </span>
        </div>
    </div>
    <div class="col-9" style="margin: 20px auto">
        <div class="card">
            <div class="card-header" style="text-align: center;">
                <h1 id="ftitle" />
            </div>
            <div class="card-body" id="fbody" style="padding: 10px; min-height: 400px">
            </div>
            <div class="card-footer" style="text-align: right">
                <span id="fgh"></span>&nbsp;于&nbsp; <span id="fdate" style="float: right"></span>
            </div>
        </div>
    </div>
    <script type="text/javascript">
                    $(document).ready(function () {
                        mui.getJSON("", {
                            "id": app.getUrlParam("id"),
                            "type": null,
                        }, function (data) {

                            //var d = $.parseJSON(data);
                            if (data == null || data.length < 1)
                                return;
                            $("#ftitle").text(data["notice_title"]);
                            $("#fbody").html(data["notice_body"]);
                            $("#fgh").html(data["notice_user_name"]);
                            $("#fdate").html(data["notice_date"].toString().replace("T", '&nbsp;'));
                            document.title = data["notice_title"];
                        });
                    });
    </script>
</body>
</html>
