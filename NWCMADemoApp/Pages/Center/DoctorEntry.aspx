<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DoctorEntry.aspx.cs" Inherits="NWCMADemoApp.Pages.Center.DoctorEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="content">
       <%--<form id="form1" runat="server">--%>
            <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
            <table class="table table-responsive">
            <tr>
                <th>Doctor Entry</th>
            </tr>
            <tr>
                <td>Name : </td>
                <td>
                    <asp:TextBox ID="doctorNameTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>                
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="doctorNameTextBox" runat="server" ErrorMessage="Name is required" ForeColor="red"></asp:RequiredFieldValidator></td>
            </tr>
           <tr>
                <td>Degree : </td>
                <td>
                    <asp:TextBox ID="degreeTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>                
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="degreeTextBox" runat="server" ErrorMessage="Degree is required" ForeColor="red"></asp:RequiredFieldValidator></td>
            </tr>
                
                 <tr>
                <td>Specialization : </td>
                <td>
                    <asp:TextBox ID="specializationTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>                
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="specializationTextBox" runat="server" ErrorMessage="Specialization is required" ForeColor="red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="saveDoctorButton" runat="server" Text="Save" CssClass="btn btn-default right" OnClick="saveDoctorButton_Click"/></td>                
            </tr>
               
            <tr>
                
                <td colspan="2">
                     <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span> 
                    <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="successStatusLabel" runat="server"></span> 
                </td>                
            </tr>
        </table>  
       </div>
            
            <div class="col-xs-6 col-sm-3 col-md-7 placeholder">
          <asp:GridView ID="doctorGridView" AllowPaging="True" PageSize="5" CssClass="table table-responsive table-bordered" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnPageIndexChanging="doctorGridView_PageIndexChanging">
        
           <Columns>
               <asp:BoundField HeaderText="Name" DataField="Name"/>
                <asp:BoundField HeaderText="Degree" DataField="Degree"/>
                <asp:BoundField HeaderText="Specialization" DataField="Specialization"/>
           </Columns>

           <FooterStyle BackColor="White" ForeColor="#333333" />
           <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="White" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F7F7F7" />
           <SortedAscendingHeaderStyle BackColor="#487575" />
           <SortedDescendingCellStyle BackColor="#E5E5E5" />
           <SortedDescendingHeaderStyle BackColor="#275353" />

       </asp:GridView> 
      </div> 
      <%-- </form> --%>
       
       
    </div>

</asp:Content>
