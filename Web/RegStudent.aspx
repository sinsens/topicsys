<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegStudent.aspx.cs" Inherits="Topicsys.Web.RegStudent" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生注册</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <div class="card">
        <div class="card-header" style="text-align: center;">
            <h2>
                学生注册</h2>
        </div>
        <div class="card-body">
            <form id="form1" runat="server">
            <div class="form-group">
                系别：
                <asp:DropDownList ID="ddlDept_id" runat="server" OnSelectedIndexChanged="ddlDept_id_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <span class="fa fa-angle-double-down"></span>
            </div>
            <div class="form-group">
                专业：
                <asp:DropDownList ID="ddlMajor_id" runat="server" OnSelectedIndexChanged="ddlMajor_id_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <span class="fa fa-angle-double-down"></span>
            </div>
            <div class="form-group">
                班级：
                <asp:DropDownList ID="txtstudent_class_id" runat="server">
                </asp:DropDownList>
                <span class="fa fa-angle-double-down"></span>
            </div>
            <div class="form-group">
                学号：
                <asp:TextBox ID="txtstudent_xh" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                姓名：
                <asp:TextBox ID="txtstudent_name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                密码：<asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="注册" OnClick="btnSave_Click" class="btn btn-block">
                </asp:Button>
                <a href="/default.aspx" class="btn btn-block">返回</a>
            </div>
            </form>
        </div>
    </div>
</body>
</html>
