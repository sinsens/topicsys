<%@ Page Title="重置其他角色密码" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Topicsys.Web.admin.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header"><%=Title %></div>
    <div class="card-body">
        <div class="form-group">
            <label for="role">
                角&emsp;色:</label>
            <select id="type" style="font-size: 0.8em; margin-top: 10px">
                <option value="student">学生</option>
                <option value="teacher">导师/教研室主任</option>
            </select><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            登录名:<input id="login_name" placeholder="学号或者工号" />
            <button id="btnFindMe" class="btn btn-link">查找</button>
        </div>
        <div class="form-group">
        </div>
        <div id="qaq" style="margin-top: 50px">
            <div class="form-group">
                新密码:<input id="pwd" placeholder="请输入新密码" />
            </div>
            <div class="form-group">
                确认新密码:<input id="pwd_retry" placeholder="请确认密码" />
            </div>
            <div class="form-group">
                <button id="btnSave" onclick="return false;">确定</button>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            /// 查找角色
            $("#btnFindMe").click(function () {
                mui.getJSON("", {
                    "type": $("#type").val(),
                    "login_name": $("#login_name").val(),
                }, function (data) {
                    if (data["Body"] == null || data["Body"].length < 1) {
                        mui.alert(data["Msg"]);
                        return;
                    }
                });
            });
            $("#btnSave").click(function () {
                /// 验证密码
                if ($("#pwd").val().length < 6) {
                    mui.alert("密码长度必须大于等于6个字符！");
                    return;
                }
                if ($("#pwd").val() !== $("#pwd_retry").val()) {
                    mui.alert("两次密码输入不一致！");
                    return;
                }
                var datas = {
                    "pwd": $("#pwd").val(),
                    "type": $("#type").val(),
                    "login_name": $("#login_name").val(),
                };
                $.post("", datas, function (data) {
                    var d = $.parseJSON(data);
                    mui.alert(data["Msg"]);
                });
            });
        });
    </script>
</asp:Content>