<%@ Page Title="发布选题结果" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="dist.aspx.cs" Inherits="Topicsys.Web.select.dist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><% =this.Title %>
    </div>
    <div class="card-body">
        <div class="form-group">
            <label for="txtSNum">学生人数：</label>
            <asp:Label ID="txtSNum" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <label for="txtSNum_ok">已成功选题学生人数：</label>
            <asp:Label ID="txtSNum_ok" runat="server"></asp:Label>
        </div>
        <asp:Button ID="btnDist" runat="server" Text="发布选题结果" OnClick="btnDist_Click" />
    </div>
</asp:Content>