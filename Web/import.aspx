<%@ Page Title="从文件导入数据" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="import.aspx.cs" Inherits="Topicsys.Web.import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
    </div>
    <div class="card-body">
        <p>
            你可以先下载数据文件模板，在模板里编辑好数据后再导入
        </p>
        <div class="form-group">
            1.下载UUID数据:
            <ul>
                <li><a target="_blank" href="/Download.aspx?action=GetUUID&type=Class">班级UUID数据</a></li>
                <li><a target="_blank" href="/Download.aspx?action=GetUUID&type=Major">专业UUID数据</a></li>
                <li><a target="_blank" href="/Download.aspx?action=GetUUID&type=Dept">系别UUID数据</a></li>
            </ul>
        </div>
        <div class="form-group">
            2.下载模板文件:
            <ul>
                <li><a target="_blank" href="/Download.aspx?action=GetTemplate&type=Student">学生数据模板</a></li>
                <li><a target="_blank" href="/Download.aspx?action=GetTemplate&type=Teacher">导师数据模板</a></li>
                <li><a target="_blank" href="/Download.aspx?action=GetTemplate&type=Class">班级数据模板</a></li>
            </ul>
        </div>
        <div class="form-group">
            3.导入数据类型：<select name="type">
                <option value="student">学生</option>
                <option value="teacher">导师</option>
                <option value="class">班级</option>
            </select><span class="fa fa-angle-double-down"></span>
            <asp:FileUpload ID="myFile" runat="server" />
            <p>文件大小不能超过10MB</p>
            <asp:Button ID="btnUpload" runat="server" Text="开始导入" OnClientClick="this.Enabled=true" />
        </div>
    </div>
</asp:Content>