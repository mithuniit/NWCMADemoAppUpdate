<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DiseaseWiseReport.aspx.cs" Inherits="NWCMADemoApp.Pages.Admin.DiseaseWiseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <%-- <form id="form1" runat="server">
  --%>
      <div class="container">
            <br />
            <h2 class="page-header">Disease-wise report
            </h2>
            <div class="col-xs-12 col-sm-12 col-md-12 placeholder">
                <div class="row placeholders">
                    <table class="table table-responsive">
                        <tr>
                            <td><b>Select disease</b></td>
                            <td>
                                <asp:DropDownList CssClass="form-control" ID="diseaseDropdownList" runat="server"></asp:DropDownList>
                            </td>
                             </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="date1" CssClass=" col-md-1 form-control" Width="215px" runat="server"></asp:TextBox>  
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="date2" CssClass=" col-md-1 form-control" Width="215px" runat="server"></asp:TextBox>  
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td><b>Select date between</b></td>
                            <td>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                </td>
                            <td><b>and</b></td>
                            <td>
                                <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged"></asp:Calendar>
                            </td>
                            <td>
                                <asp:Button ID="showButton" CssClass="btn btn-primary" runat="server" Text="Show" OnClick="showButton_Click" /> 
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="4">
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

                       
                    </table>
                </div>

            </div>


        </div>
        
<%-- </form>--%>
   
</asp:Content>
