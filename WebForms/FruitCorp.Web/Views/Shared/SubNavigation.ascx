<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubNavigation.ascx.cs" Inherits="FruitCorp.Web.Views.Shared.SubNavigation" %>
<EPiServer:PageTree PageLink="<%# MenuRoot %>" Visible="<%# MenuRootHasChildren %>" runat="server">
    <HeaderTemplate>
        <div class="sub-navigation">
            <ul class="nav">
    </HeaderTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
    <ItemTemplate>
        <li>
            <EPiServer:Property PropertyName="PageLink" runat="server" />
    </ItemTemplate>
    <SelectedItemTemplate>
        <li class="active">
            <EPiServer:Property PropertyName="PageLink" runat="server" />
    </SelectedItemTemplate>
    <ExpandedItemTemplate>
        <li class="active">
            <EPiServer:Property PropertyName="PageLink" runat="server" />
    </ExpandedItemTemplate>
    <ItemFooterTemplate>
        </li>
    </ItemFooterTemplate>
    <IndentTemplate>
        <ul class="nav">
    </IndentTemplate>
    <UnindentTemplate>
        </ul>
    </UnindentTemplate>
</EPiServer:PageTree>