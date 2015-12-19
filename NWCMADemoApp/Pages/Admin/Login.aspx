<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <%-- <form id="form1" runat="server">--%>
              
    <div class="content">
        
        <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
            <table class="table table-responsive">
            <tr>
                <th> Login</th>
            </tr>
            <tr>
                <td>Code : </td>
                <td>
                    <asp:TextBox ID="codeTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>                
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="codeTextBox" ForeColor="red" ErrorMessage="Code is required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Password :</td>
                <td>
                    <asp:TextBox ID="passwoedTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td>                
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passwoedTextBox" ForeColor="red" ErrorMessage="Password is required"></asp:RequiredFieldValidator></td>
                 </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="loginButton" runat="server" Text="Login" CssClass="btn btn-default right" OnClick="loginButton_Click"/></td>                
            </tr>
                </tr>
            <tr>
                
                <td colspan="2">
                     <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span> 
                </td>                
            </tr>
        </table>  
       </div>
       
    </div>
     <%-- </form>--%>
</asp:Content>
