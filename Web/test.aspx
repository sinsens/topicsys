<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Topicsys.Web.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测试页面</title>
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
    <script src="/kindeditor/kindeditor-all-min.js"></script>
    <script src="/kindeditor/lang/zh-CN.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
        <div class="">
            <h2>公告压缩测试</h2>
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
                <textarea id="fbody" style="font-size: 0.8em; min-height: 500px;">
            </textarea>
            </div>
            <button id="btnAdd" class="btn btn-primary" onclick="return false;">发布</button>
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
                            "ftype": $("#ftype").val(),
                            "fname": $("#fname").val(),
                            "fbody": editor.html(),
                        }, function (data) {
                            if (isIE())
                                $("#fname").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + data + '</strong>点击关闭提示</div >');
                            else
                                mui.alert(data);
                        });
                    });
                });
            </script>
        </div>
    </form>
</body>
</html>