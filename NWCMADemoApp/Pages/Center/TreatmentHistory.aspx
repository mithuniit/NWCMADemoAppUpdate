<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="TreatmentHistory.aspx.cs" Inherits="NWCMADemoApp.Pages.Center.TreatmentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%--<form id="form1" runat="server">--%>
        <div class="container" runat="server">
            <br />
            <h2 class="page-header">Treatment
            </h2>
            <div class="col-xs-12 col-sm-12 col-md-12 placeholder">
                <div class="row placeholders">
                    <table class="table table-responsive">
                        <tr>
                            <td><b>Voter Id</b></td>
                            <td>
                                <asp:TextBox ID="voterIdTextBox" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="showDetailsButton" CssClass="btn btn-primary left" runat="server" Text="Show Details" OnClick="showDetailsButton_Click" /></td>
                        </tr>
                        <tr>
                            <td><b>Name</b></td>
                            <td>
                                <asp:TextBox ID="patientNameTextBox" Width="200px" CssClass="form-control" runat="server"></asp:TextBox> 
                            </td>
                        </tr>
                        <tr>
                            <td><b>Address</b></td>
                            <td>
                                <asp:TextBox ID="addressTextBox" Width="200px" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>   
                            </td>
                        </tr>
                        
                    </table>
                    <div class="historyDiv" runat="server">
                        
                    </div>

                </div>

            </div>


        </div>

   <%-- </form>   --%>

</asp:Content>
