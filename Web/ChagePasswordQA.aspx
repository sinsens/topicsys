<%@ Page Title="设置密保问题" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ChagePasswordQA.aspx.cs" Inherits="Topicsys.Web.ChagePasswordQA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><% =this.Title %>
    </div>
    <div class="card-body">
        <div class="form-group">
            密保问题
            <input id="my_q" placeholder="请输入密保问题" />
        </div>
        <div class="form-group">
            密保答案
            <input id="my_a" placeholder="请输入密保答案" />
        </div>
        <div class="form-group">
            <button id="btnSave" class="mui-btn mui-btn-blue" onclick="return false;">保存</button>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            /// 保存
            $("#btnSave").click(function () {
                mui.getJSON("", {
                    "type": "update",
                    "my_a": $("#my_a").val(),
                    "my_q": $("#my_q").val(),
                }, function (d) {
                    if (isIE())
                        $("#my_q").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + d["Msg"] + '</strong>点击关闭提示</div >');
                    else
                        mui.alert(d["Msg"]);
                })
            })
            /// 获取现有数据
            mui.getJSON("", {
                "type": "get",
            }, function (data) {
                if (data["Body"] == null || data["Body"].length < 1) {
                    return;
                }
                if (data["Code"] == 1) {
                    //通过data["Body"]["Code"]判断是学生还是导师,1学生,2导师
                    $("#my_q").val(data["Body"]["student_pwd_q"]);
                    $("#my_a").val(data["Body"]["student_pwd_a"]);
                } else {
                    $("#my_q").val(data["Body"]["teacher_pwd_q"]);
                    $("#my_a").val(data["Body"]["teacher_pwd_a"]);
                }

            });
        });
    </script>
</asp:Content>