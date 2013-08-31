<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="FruitCorp.Web.Views.Pages.Start" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <EPiServer:Property PropertyName="PageName" CustomTagName="h1" runat="server" />
</asp:Content>
