<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Topicsys.Web.t_topic.Add" Title="添加出题信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            可选班级：
            <asp:DropDownList ID="txtstudent_class_id" runat="server"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            论文题目：<asp:TextBox ID="txttopic_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            可选人数上限：<asp:TextBox ID="txttopic_num" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            备&emsp;注：<asp:TextBox ID="txttopic_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>


