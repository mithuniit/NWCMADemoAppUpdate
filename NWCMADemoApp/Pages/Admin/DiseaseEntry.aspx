<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DiseaseEntry.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.DiseaseEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%-- <form id="form1" runat="server">--%>
     <div class="content">
    <div class="col-xs-6 col-sm-3 col-md-6 placeholder">
         <div class="row placeholders">  
         <table class="table table-responsive">
        <tr>
            <td colspan="2"><h1>Create new Disease</h1></td>
            
        </tr>
        <tr>
            <td><b>Name of disease</b></td>
            <td>
                <asp:TextBox ID="diseaseTextBox" CssClass="form-control" Width="200px" runat="server"></asp:TextBox>
               
            </td>
            <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="diseaseTextBox" runat="server" ErrorMessage="Name is required" ForeColor="red"></asp:RequiredFieldValidator></td>
        </tr>
              <tr>
            <td><b>Description</b></td>
            <td>
                <asp:TextBox ID="descriptionTextBox" CssClass="form-control" TextMode="MultiLine" Width="200px" Height="100px" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="descriptionTextBox" runat="server" ErrorMessage="Descriptione is required" ForeColor="red"></asp:RequiredFieldValidator></td>
                   </tr>
              <tr>
            <td style="width: 200px;"><b>Treatement Procedure</b></td>
            <td>
                <asp:TextBox ID="procedureTextBox" CssClass="form-control" TextMode="MultiLine" Width="200px" Height="100px" runat="server"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="procedureTextBox" runat="server" ErrorMessage="Treatment procedure is required" ForeColor="red"></asp:RequiredFieldValidator></td>
              </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button CssClass="btn btn-default right" ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/></td>
        </tr>
        <tr>
            
            <td colspan="2">
                <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="successSpan" runat="server"></span>  
                <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failSpan" runat="server"></span> 
            </td>
     
          
                </tr>
    </table>
             </div>
    </div>
    
     <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <asp:GridView ID="diseaseGridView" CssClass="table table-responsive" runat="server">         
     </asp:GridView>         
  </div>
     </div>

</div>
     <%--</form>--%>


</asp:Content>
