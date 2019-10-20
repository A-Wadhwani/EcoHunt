<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuccessfulDeletion.aspx.cs" Inherits="EcoHunt.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class =" container">
    <div class =" row text-right">
        <div class =" col-3"></div>
        <div class =" col-5 text-center mt-5">
            <div class ="alert alert-success text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Success" >
                <p class="pb-n2">Congratulations! You have successfully earned 10 points!</p>
             </div>

        </div>
            <div class="col-11 col-md-11 text-center">
                <button class="btn btn-primary" id="SubmitChanges" runat="server" onserverclick="SubmitChanges_ServerClick">Click to confirm completion of task!</button>
            </div>
                    <div class="col-11 col-md-11 text-center">
                <button class="btn btn-primary" id="Redirect" runat="server" onserverclick="Redirect_ServerClick">Click to go to Leaderboard</button>
            </div>

        </div>
    </div>  
</asp:Content>
