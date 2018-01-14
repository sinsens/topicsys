<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Topicsys.Web.t_major.Show" Title="显示页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
        <a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            ID：<asp:Label ID="lblid" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            专业名词：<asp:Label ID="lblmajor_name" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            所属系别：<asp:Label ID="lblmajor_dept_id" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            状态：<asp:Label ID="lblmajor_stat" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            备注：<asp:Label ID="lblmajor_note" runat="server" TextMode="MultiLine"></asp:Label>
        </div>
    </div>
</asp:Content>