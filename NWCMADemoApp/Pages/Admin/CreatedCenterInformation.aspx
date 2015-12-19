<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CreatedCenterInformation.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.CreatedCenterInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--<form id="form1" runat="server">--%>

<div class="content">
    <div class="modal-header"><h4>Newly created center</h4></div>
    
    <div>
       <asp:GridView ID="newCenterGridView" CssClass="table table-responsive table-bordered" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
        
           <Columns>
               <asp:BoundField HeaderText="Center Name" DataField="Name"/>
                <asp:BoundField HeaderText="Code" DataField="Code"/>
                <asp:BoundField HeaderText="Password" DataField="Password"/>
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
    <div>
        <asp:Button ID="generatePDFButton" CssClass="btn btn-default" runat="server" Text="Generate PDF" OnClick="generatePDFButton_Click" />
    </div>
    
</div>
<%--</form>--%>

</asp:Content>
