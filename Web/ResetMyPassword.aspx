<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetMyPassword.aspx.cs"
    Inherits="Topicsys.Web.ResetMyPassword" %>

<%@ Register Src="~/Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>通过密保问题重置密码</title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/mui.min.css" rel="stylesheet" />
    <script src="/js/mui.min.js"></script>
    <script src="/js/jquery.min.js"></script>
    <script src="/js/popper.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/app.js"></script>
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
                    /*function writeNow() {
                    document.getElementById("panelShowTime").innerText = (new Date().Format("yyyy年-M月-dd日 星期w hh:mm:ss"));
                    };
                    setInterval("writeNow()", 1000);*/
                </script>
            </span><span id="showLogin_name"></span>
        </div>
    </div>
    <div class="row">
        <div class="col-6" style="margin: 50px auto;">
            <div class="card">
                <div class="card-header">
                    <%=Title %></div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="role">
                            角&emsp;色:</label>
                        <select id="type" style="font-size: 0.8em; margin-top: 10px">
                            <option value="student">学生</option>
                            <option value="teacher">导师</option>
                        </select><span class="fa fa-angle-double-down"></span>
                        <p>
                            注:教研室主任不支持通过密保问题找回密码
                        </p>
                    </div>
                    <div class="form-group">
                        登录名:
                        <input id="login_name" placeholder="学号或者工号" />
                    </div>
                    <div class="form-group">
                        <button id="btnFindMe">
                            查找</button>
                    </div>
                    <div id="qaq" style="margin-top: 50px">
                        <div class="form-group">
                            密保问题:
                            <label id="my_q">
                            </label>
                        </div>
                        <div class="form-group">
                            答案:
                            <input id="my_a" placeholder="请输入回答" />
                        </div>
                        <div class="form-group">
                            <button id="btnResetMyPwd">
                                确定</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-12" style="margin-top: 100px; text-align: center">
        <uc1:copyright ID="copyright1" runat="server" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#qaq").hide();
            /// 验证密保
            $("#btnResetMyPwd").click(function () {
                var datas = {
                    "type": $("#type").val(),
                    "login_name": $("#login_name").val(),
                    "a": $("#my_a").val(),
                };
                $.post("", datas, function (data) {
                    var d = $.parseJSON(data);
                    if (d["Body"] == null || d["Body"].length < 1) {
                        if (isIE())
                            $("#login_name").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + d["Msg"] + '</strong>点击关闭提示</div >');
                        else
                            mui.alert(d["Msg"]);
                        return;
                    }
                    top.location.href = d["Body"];
                })
            });
            /// 查找角色
            $("#btnFindMe").click(function () {
                mui.getJSON("", {
                    "type": $("#type").val(),
                    "login_name": $("#login_name").val(),
                }, function (data) {
                    if (data["Body"] == null || data["Body"].length < 1) {
                        if (isIE())
                            $("#login_name").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + data["Msg"] + '</strong>点击关闭提示</div >');
                        else
                            mui.alert(data["Msg"]);
                        return;
                    }
                    $("#my_q").text(data["Body"]);
                    $("#qaq").show();
                });
            });
        });
    </script>
</body>
</html>
