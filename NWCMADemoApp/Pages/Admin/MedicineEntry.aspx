<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="MedicineEntry.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.MedicineEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<form id="form1" runat="server">--%>
<div class="content">
    <div class="col-xs-6 col-sm-3 col-md-7 placeholder">
         <div class="row placeholders">  
         <table class="table table-responsive">
        <tr>
            <td colspan="2"><h3>Create an entry of new medicine</h3></td>
            
        </tr>
        <tr>
            <td><b>Name of medicine</b></td>
            <td>
                <asp:TextBox ID="medicineNameTextBox" CssClass="form-control" Width="200px" runat="server"></asp:TextBox></td>
             <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="medicineNameTextBox" runat="server" ErrorMessage="Name is required" ForeColor="red"></asp:RequiredFieldValidator></td>
             </tr>
              
             

        <tr>
            <td></td>
            <td>
                <asp:Button CssClass="btn btn-default right" ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/></td>
        </tr>
        <tr>            
            <td colspan="2">
                <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="successStatusLabel" runat="server"></span>  
                <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span> 
            </td>               
         </tr>
    </table>
             </div>
    </div>
    
     <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <asp:GridView ID="medicineGridView" CssClass="table table-responsive" runat="server">         
     </asp:GridView>         
  </div>
     </div>

</div>
<%--</form>--%>



</asp:Content>
