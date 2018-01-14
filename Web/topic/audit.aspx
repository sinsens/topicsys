<%@ Page Title="审核" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="audit.aspx.cs" Inherits="Topicsys.Web.topic.audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .input-row {
            line-height: 3em
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./list.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            系别：<asp:Label ID="lblDept" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            导师工号：<asp:Label ID="lblGh" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            导师姓名：<asp:Label ID="lblTName" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            论文题目：<asp:Label ID="lblName" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            可选班级：<asp:Label ID="lblClass" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            可选人数上限：<asp:Label ID="lblNum" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            审核：<asp:DropDownList ID="ddlStat" runat="server">
                <asp:ListItem Value="0">待审核</asp:ListItem>
                <asp:ListItem Value="1">不通过</asp:ListItem>
                <asp:ListItem Value="2">通过</asp:ListItem>
            </asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            审核意见：<asp:TextBox ID="txttopic_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>