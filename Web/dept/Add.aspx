<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Topicsys.Web.t_dept.Add" Title="添加系别" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
        <a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            名称	：<asp:TextBox ID="txtdept_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            备注	：<asp:TextBox ID="txtdept_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"
                ></asp:Button>
        </div>
    </div>
</asp:Content>


