<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChagePassword.aspx.cs"
    Inherits="Topicsys.Web.ChagePassword" %>

<%@ Register Src="~/Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<!DOCTYPE html>
<html lang="zh">
<head runat="server">
    <title>修改密码</title>
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
                        新密码:<input id="pwd" type="password">
                    </div>
                    <div class="form-group">
                        确认新密码:<input id="pwd_retry" type="password">
                    </div>
                    <p>
                        修改密码后需要重新登录。</p>
                    <div class="form-group">
                        <button id="btnSave">
                            保存</button>
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
            $("#btnSave").click(function () {
                /// 验证密码
                if ($("#pwd").val().length < 6) {
                    if (isIE())
                        $("#pwd").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>密码长度必须大于等于6个字符!</strong>点击关闭提示</div >');
                    else
                        mui.alert("密码长度必须大于等于6个字符！");
                    return;
                }
                if ($("#pwd").val() !== $("#pwd_retry").val()) {
                    if (isIE())
                        $("#pwd").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>两次密码输入不一致!</strong>点击关闭提示</div >');
                    else
                        mui.alert("两次密码输入不一致！");
                    return;
                }
                var datas = {
                    "pwd": $("#pwd").val(),
                };
                $.post("", datas, function (data) {
                    var d = $.parseJSON(data);
                    if (d["Body"] == null || d["Body"].length < 1) {
                        if (isIE())
                            $("#pwd").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + d["Msg"] + '</strong>点击关闭提示</div >');
                        else
                            mui.alert(d["Msg"]);
                        return;
                    }
                    /// 重新登录
                    top.location.href = d["Body"];
                });
            });
        });
    </script>
</body>
</html>
