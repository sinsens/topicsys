<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Topicsys.Web.notice.Modify" Title="修改公告" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- 2017年12月21日在本页面头部添加了
        ValidateRequest="false"
    引自:http://shiyousan.com/post/635563669112062894
    -->
    <script src="/kindeditor/kindeditor-all-min.js"></script>
    <script src="/kindeditor/lang/zh-CN.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
    </div>
    <div class="card-body">
        <div class="form-group">
            <label for="fname">公告标题</label>
            <input id="fname" type="text" maxlength="64" placeholder="公告标题" />
        </div>
        <div class="form-group">
            <label for="ftype">公告类型</label>
            <select id="ftype">
                <option value="0">出题公告</option>
                <option value="1">选题公告</option>
                <option value="2">其他公告</option>
            </select>
        </div>
        <div class="form-group">
            <label for="fbody">公告内容</label>
            <textarea id="fbody" style="font-size: 0.8em; min-height: 500px; max-width: 100%">
            </textarea>
        </div>
        <button id="btnAdd" class="btn btn-primary" onclick="return false;">保存</button>
        <script type="text/javascript">
            /// 初始化编辑器
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#fbody', {
                    cssPath: '/kindeditor/plugins/code/prettify.css',
                    uploadJson: '/upload_json.aspx',
                    fileManagerJson: '/file_manager_json.aspx',
                    pluginsPath: "/kindeditor/plugins/",
                    allowFileManager: true,
                });
            });
            $(document).ready(function () {
                /// 获取原始公告数据
                mui.getJSON("/Show.aspx", {
                    "id": app.getUrlParam("id"),
                    "type": null,
                }, function (data) {
                    $("#fname").val(data["notice_title"]);
                    editor.html(data["notice_body"]);
                });

                /// 新增按钮处理
                $("#btnAdd").click(function () {
                    /// 检测输入
                    if ($("#fname").val().length < 5) {
                        if (isIE()) {
                            $("#fname").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>公告标题不能小于5个字符！</strong>点击关闭提示</div >');
                        } else {
                            mui.alert("公告标题不能小于5个字符！");
                        }
                        return;
                    }
                    ///2017年12月4日 采用POST方法
                    $.post(location.href, {
                        "fname": $("#fname").val(),
                        "fbody": editor.html(),
                        "ftype": $("#ftype").val(),
                        "id": app.getUrlParam("id"),
                    }, function (data) {
                        var d = $.parseJSON(data);
                        if (isIE())
                            $("#fname").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + d["Msg"] + '</strong>点击关闭提示</div >');
                        else
                            mui.alert(d["Msg"]);
                    });
                });
            });
        </script>
    </div>
</asp:Content>