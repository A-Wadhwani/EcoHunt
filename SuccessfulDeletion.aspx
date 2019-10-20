<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuccessfulDeletion.aspx.cs" Inherits="EcoHunt.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class =" container">
    <div class =" row text-right">
        <div class =" col-3"></div>
        <div class =" col-5 text-center mt-5">
            <div class ="alert alert-success text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Success" >
                <p class="pb-n2">Congratulations! You have successfully earned 10 points!</p>
             </div>
            <h2 class ="btn btn-primary text-right mt-3">Click to confirm completion of task!</h2>
        </div>
        </div>
    </div>  
</asp:Content>
