<%@ Page Title="首页" Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"
    Inherits="Topicsys.Web.WebForm1" %>

<%@ Register Src="~/Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<!DOCTYPE html>
<html lang="zh">
<head>
    <title>登录</title>
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
    <div  style="color: Red; font-size: 2em;height:1000px;padding:20px">
        本系统需要浏览器启用Javascript支持，否则无法正常使用。关于浏览器如何启用JavaScript支持，请参阅=>各种浏览器开启JavaScript脚本方法:<a href="http://360.bgu.edu.cn/help/openJsHelp.html">http://360.bgu.edu.cn/help/openJsHelp.html</a>。
        <br />
        <br />
        推荐使用谷歌浏览器：<a href="http://www.google.cn/chrome/browser/desktop/index.html">http://www.google.cn/chrome/browser/desktop/index.html</a>
        <br/>
        <br/>
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
            </span>
        </div>
    </div>
    <div class="row" style="padding: 10px">
        <div class="col-3">
            <div class="card">
                <div class="card-header">
                    登录
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="role">
                            角&emsp;色:</label>
                        <select id="type" name="type" class="custom-select" style="font-size: 0.8em; margin-top: 10px">
                            <option value="student">学生</option>
                            <option value="teacher">导师</option>
                            <option value="mteacher">教研室主任</option>
                            <option value="admin">教务管理员</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="login_name">
                            登录名:</label>
                        <input id="login_name" name="login_name" type="text" placeholder="请输入登录名" style="font-size: 0.8em" />
                    </div>
                    <div class="form-group">
                        <label for="pwd">
                            密&emsp;码:</label>
                        <input id="pwd" name="pwd" type="password" placeholder="请输入密码" style="font-size: 0.8em" />
                    </div>
                    <input type="reset" id="btnClear" class="btn btn-primary" value="清空">
                    <input id="btnLogin" class="btn btn-primary" type="submit" value="登录" />
                    <p>
                        初始密码为<strong>abc12345</strong>
                    </p>
                    <p>
                        <a href="/regstudent.aspx">学生注册</a>|<a href="/ResetMyPassword.aspx">重置密码</a>
                    </p>
                </div>
            </div>
            <div class="card" style="margin-top: 10px">
                <div class="card-header">
                    联系方式
                </div>
                <div class="card-body">
                </div>
            </div>
        </div>
        <div class="col-9">
            <div class="card">
                <div class="card-header">
                    公告列表
                </div>
                <div class="card-body">
                    <ul id="gonggaolist" class="ul" style="list-style: none; margin: 0; padding: 0; line-height: 2em;">
                    </ul>
                </div>
                <div class="card-footer" style="text-align: right">
                    <button id="btnPrivPage">
                        上一页</button>
                    <span id="page_num" class="badge badge-dark" style="margin-top: 5px"></span>
                    <button id="btnNextPage">
                        下一页</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            /// 初始化按钮点击事件
            $("#btnClear").click(function () {
                if (isIE()) {
                    $("#pwd").val("");
                    $("#login_name").val("");
                    return;
                }
                mui.confirm("清空输入框?", "温馨提示", ["取消", "清空"], function (e) {
                    if (e.index == 1) {
                        $("#pwd").val("");
                        $("#login_name").val("");
                        mui.toast("已清空");
                    }
                });
            });

            $("#btnLogin").click(function () {
                /// 检测用户名和密码
                if ($("#login_name").val().length < 3 || $("#pwd").val().length < 5) {
                    if (isIE())
                        $("#login_name").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>输入有误</strong>点击关闭提示</div >');
                    else
                        mui.alert("输入有误！");
                    return;
                }

                $.post("login.aspx", {
                    "type": $("#type").val(),
                    "pwd": $("#pwd").val(),
                    "login_name": $("#login_name").val()
                }, function (data) {
                    var d = $.parseJSON(data);
                    if (isIE())
                        $("#login_name").after('<div class="alert alert-warning" onclick="this.removeNode(true)"><strong>' + d["Msg"] + '</strong>点击关闭提示</div >');
                    else
                        mui.alert(d["Msg"]);
                    if (d["Body"] == null || d["Body"].length < 1)
                        return;
                    top.location.href = d["Body"];
                });
            });

            //获取最新公告

            //获取最新公告
            var page = 1;
            function loadGongao() {
                mui.getJSON("", { "type": "list", "page": page }, function (d) {
                    if (d == null || d.length < 1) {
                        return;
                    }
                    var str = "";
                    d.forEach(function (value) {
                        str += "<li style='margin:0;padding:0'>";
                        // 标注公告类型
                        str += "【";
                        str += value["notice_type"] == 0 ? "出题" : value["notice_type"] == 1 ? "选题" : "其他";
                        str += "公告】";

                        str += "<a target='_blank' href='show.aspx?fid=" + value["id"] + "'>" + value["notice_title"] + "<span style='float:right'>";
                        str += value["notice_date"].replace("T", '&emsp;') + "</span></a>";
                        str += "</li>";
                    });
                    $("#gonggaolist").html(str);
                });
                $("#page_num").text(page);
            }
            loadGongao();

            //公告翻页
            $("#btnPrivPage").click(function () {
                if (page == 1) {
                    mui.alert("已经是第一页了");
                    return;
                }
                page -= 1;
                loadGongao();
            });
            //公告翻页
            $("#btnNextPage").click(function () {
                page += 1;
                loadGongao();
            });
        });
    </script>
    <uc1:copyright ID="copyright1" runat="server" />
</body>
</html>
