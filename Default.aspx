<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcoHunt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    
        <asp:Label Text="Photo Library" runat="server" Font-Bold="true" Font-Size="XX-Large" />

        <div class="row">
            <div class="col-md-3">
                <asp:Literal runat="server" ID="imgList" />
            </div>
        </div>

    </div>


</asp:Content>
