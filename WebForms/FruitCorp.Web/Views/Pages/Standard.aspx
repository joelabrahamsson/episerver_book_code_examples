<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/WithSubNavigation.master" AutoEventWireup="true" CodeBehind="Standard.aspx.cs" Inherits="FruitCorp.Web.Views.Pages.Standard" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <EPiServer:Property PropertyName="Image" Width="100%" runat="server" />
    <EPiServer:Property PropertyName="PageName" CustomTagName="h1" runat="server" />
    <EPiServer:Property PropertyName="MainIntro" CustomTagName="p" CssClass="lead" runat="server" />
    <EPiServer:Property PropertyName="MainBody" runat="server" />
</asp:Content>