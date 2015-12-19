<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="MedicineStockReport.aspx.cs" Inherits="NWCMADemoApp.Pages.Center.MedicineStockReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <form id="form1" runat="server">--%>
        <div class="content">
         <div class="col-sm-9 col-sm-offset-3 col-md-7 col-md-offset-2 main">
          <h3 class="page-header">Medicine Stock Report</h3>
                        
     <div class="row placeholders">
         
         <asp:GridView ID="medicineStockGridView" CssClass="table table-responsive table-hover" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
               <asp:BoundField HeaderText="Medicine Name" DataField="MedicineName"/>
                  <asp:BoundField HeaderText="Present Stock" DataField="PresentStock"/>
             </Columns>
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
         

      </div>
     </div>   

        </div>
        
   <%-- </form>--%>
     

</asp:Content>
