<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNavigation.ascx.cs" Inherits="FruitCorp.Web.Views.Shared.MainNavigation" %>
<%@ Import Namespace="EPiServer.Core" %>
<nav class="navbar navbar-inverse">
    <ul class="nav navbar-nav">
        <li class="<%= CurrentPage.ContentLink.CompareToIgnoreWorkID(ContentReference.StartPage) ? "active" : "" %>">
            <EPiServer:Property PageLink="<%# ContentReference.StartPage %>" 
                PropertyName="PageLink" runat="server" />
        </li>
        <EPiServer:MenuList PageLink="<%# PageReference.StartPage %>" runat="server">
          <ItemTemplate>
            <li>
              <EPiServer:Property PropertyName="PageLink" runat="server" />
            </li>
          </ItemTemplate>
          <SelectedTemplate>
            <li class="active">
              <EPiServer:Property PropertyName="PageLink" runat="server" />
            </li>
          </SelectedTemplate>
        </EPiServer:MenuList>
    </ul>
</nav>