<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="SendMedicine.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.SendMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <form id="form1" runat="server">--%>
 <div class="content">
    <div class="col-xs-12 col-sm-10 col-md-7 placeholder">
         <div class="row placeholders">  
         <table class="table table-responsive">
        <tr>
            <td colspan="2"><h4>Send medicine to a center</h4></td>
            
        </tr>
       
              <tr>
            <td><b>District</b></td>
            <td style="width: 200px;">
                <asp:DropDownList ID="districtDropDownList" CssClass="form-control" Width="100%" Height="30px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </td>
        </tr>
              <tr>
            <td ><b>Thana</b></td>
            <td>
               <asp:DropDownList ID="thanaDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="thanaDropDownList_SelectedIndexChanged"></asp:DropDownList> 
              </td> 
        </tr>
              <tr>
            <td ><b>Center</b></td>
            <td>
               <asp:DropDownList ID="centerNameDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList> 
              </td> 
        </tr>
             <tr>
            <td  colspan="2"><b>Add medicine</b></td>            
        </tr>                         
              <tr>
            <td ><b>Select medicine</b></td>
            <td>
               <asp:DropDownList ID="medicineDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList> 
              </td>
                  
                   <td ><b>Quantity</b></td>
            <td>
                <asp:TextBox ID="quantityTextBox" CssClass="form-control" Width="150px" runat="server"></asp:TextBox>
              </td>
                  <td>
                <asp:Button CssClass="btn btn-default right" ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" Width="71px"/></td>
            
        </tr>
             <tr>
                 <td colspan="5"> <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span> </td>
             </tr> 
             <tr>
                <td colspan="5">
                    <asp:GridView ID="addMedicineGridView" CssClass="table table-responsive" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                        
                    </asp:GridView>
                </td> 
             </tr>  
             
             <tr>
                <td></td>
                     <td></td> 
                  <td></td> 
                  <td></td> 
                  <td><asp:Button CssClass="btn btn-default right" ID="saveButton" runat="server" Text="save" OnClick="saveButton_Click"/></td>  
             </tr>                                      
        <tr>            
            <td colspan="2">
                <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="sendMedicineSuccessStatusLabel" runat="server"></span>  
                <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="sendMedicineFailStatusLabel" runat="server"></span> 
            </td>               
                </tr>
    </table>
             </div>

    </div>
     

    
</div>
<%--</form>--%>
</asp:Content>
