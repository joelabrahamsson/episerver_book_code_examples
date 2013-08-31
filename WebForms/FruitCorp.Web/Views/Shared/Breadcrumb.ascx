<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumb.ascx.cs" Inherits="FruitCorp.Web.Views.Shared.Breadcrumb" %>
<%@ Import Namespace="EPiServer.Core" %>
<EPiServer:PageTree PageLink="<%# ContentReference.StartPage %>" 
    ShowRootPage="True" runat="server">
    <HeaderTemplate>
        <ol class="breadcrumb">
    </HeaderTemplate>
    <ExpandedItemTemplate>
        <li>
            <EPiServer:Property PropertyName="PageLink" runat="server" />
        </li>
    </ExpandedItemTemplate>
    <SelectedItemTemplate>
        <li class="active">
            <EPiServer:Property PropertyName="PageName" runat="server" />
        </li>
    </SelectedItemTemplate>
    <FooterTemplate>
        </ol>
    </FooterTemplate>
</EPiServer:PageTree>