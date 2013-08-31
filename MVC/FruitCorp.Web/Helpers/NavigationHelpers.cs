using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FruitCorp.Web.Helpers
{
  public static class NavigationHelpers
  {
    public static void RenderMainNavigation(
      this HtmlHelper html,
      PageReference rootLink = null,
      ContentReference contentLink = null,
      bool includeRoot = true,
      IContentLoader contentLoader = null)
    {
      contentLink = contentLink ??
        html.ViewContext.RequestContext.GetContentLink();
      rootLink = rootLink ??
        ContentReference.StartPage;

      var writer = html.ViewContext.Writer;

      //Top level elements
      writer.WriteLine("<nav class=\"navbar navbar-inverse\">");
      writer.WriteLine("<ul class=\"nav navbar-nav\">");

      if (includeRoot)
      {
        //Link to the root page
        if (rootLink.CompareToIgnoreWorkID(contentLink))
        {
          writer.WriteLine("<li class=\"active\">");
        }
        else
        {
          writer.WriteLine("<li>");
        }
        writer.WriteLine(
          html.PageLink(rootLink).ToHtmlString());
        writer.WriteLine("</li>");
      }

      //Retrieve and filter the root pages children
      contentLoader = contentLoader ??
        ServiceLocator.Current.GetInstance<IContentLoader>();
      var topLevelPages = contentLoader
        .GetChildren<PageData>(rootLink);
      topLevelPages = FilterForVisitor.Filter(topLevelPages)
        .OfType<PageData>()
        .Where(x => x.VisibleInMenu);

      //Retrieve the "path" from the current page up to the
      //root page in the content tree in order to check if
      //a link should be highlighted.
      var currentBranch = contentLoader.GetAncestors(contentLink)
        .Select(x => x.ContentLink)
        .ToList();
      currentBranch.Add(contentLink);

      //Link to the root pages children
      foreach (var topLevelPage in topLevelPages)
      {
        if (currentBranch.Any(x =>
          x.CompareToIgnoreWorkID(topLevelPage.ContentLink)))
        {
          writer.WriteLine("<li class=\"active\">");
        }
        else
        {
          writer.WriteLine("<li>");
        }
        writer.WriteLine(html.PageLink(topLevelPage).ToHtmlString());
        writer.WriteLine("</li>");
      }

      //Close top level element
      writer.WriteLine("</ul>");
      writer.WriteLine("</nav>");
    }

    public static void RenderSubNavigation(
      this HtmlHelper html,
      ContentReference contentLink = null,
      IContentLoader contentLoader = null)
    {
      contentLink = contentLink ??
        html.ViewContext.RequestContext.GetContentLink();
      contentLoader = contentLoader ??
        ServiceLocator.Current.GetInstance<IContentLoader>();

      var path = NavigationPath(
        contentLink,
        contentLoader,
        ContentReference.StartPage)
        .Select(x => x.PageLink);

      var root = path.FirstOrDefault();
      if (root == null)
      {
        //We're not on a page below the start page,
        //meaning that there's nothing to render.
        return;
      }

      RenderSubNavigationLevel(
        html,
        root,
        path,
        contentLoader);
    }

    private static IEnumerable<PageData> NavigationPath(
      ContentReference contentLink,
      IContentLoader contentLoader,
      ContentReference fromLink = null)
    {
      fromLink = fromLink ?? ContentReference.RootPage;

      //Find all pages between the current and the 
      //"from" page, in top-down order.
      var path = contentLoader.GetAncestors(contentLink)
          .Reverse()
          .SkipWhile(x =>
            ContentReference.IsNullOrEmpty(x.ParentLink)
            || !x.ParentLink.CompareToIgnoreWorkID(fromLink))
          .OfType<PageData>()
          .ToList();

      //In theory the current content may not be a page.
      //We check that and, if it is, add it to the end of
      //the content tree path.
      var currentPage = contentLoader
        .Get<IContent>(contentLink) as PageData;
      if (currentPage != null)
      {
        path.Add(currentPage);
      }
      return path;
    }

    private static void RenderSubNavigationLevel(
          HtmlHelper helper,
          ContentReference levelRootLink,
          IEnumerable<ContentReference> path,
          IContentLoader contentLoader)
    {
      //Retrieve and filter the pages on the current level
      var children = contentLoader.GetChildren<PageData>(levelRootLink);
      children = FilterForVisitor.Filter(children)
                                 .OfType<PageData>()
                                 .Where(x => x.VisibleInMenu);

      if (!children.Any())
      {
        //There's nothing to render on this level so we abort
        //in order not to write an empty ul element.
        return;
      }

      var writer = helper.ViewContext.Writer;

      //Open list element for the current level
      writer.WriteLine("<ul class=\"nav\">");

      //Project to an anonymous class in order to know
      //the index of each page in the collection when
      //iterating over it.
      var indexedChildren = children
        .Select((page, index) => new { index, page })
        .ToList();

      foreach (var levelItem in indexedChildren)
      {
        var page = levelItem.page;
        var partOfCurrentBranch = path.Any(x =>
          x.CompareToIgnoreWorkID(levelItem.page.ContentLink));

        if (partOfCurrentBranch)
        {
          //We highlight pages that are part of the current branch,
          //including the currently viewed page.
          writer.WriteLine("<li class=\"active\">");
        }
        else
        {
          writer.WriteLine("<li>");
        }
        writer.WriteLine(helper.PageLink(page).ToHtmlString());

        if (partOfCurrentBranch)
        {
          //The page is part of the current pages branch, 
          //so we render a level below it 
          RenderSubNavigationLevel(
            helper,
            page.ContentLink,
            path,
            contentLoader);
        }
        writer.WriteLine("</li>");
      }

      //Close list element
      writer.WriteLine("</ul>");
    }

    public static void RenderBreadcrumb(
      this HtmlHelper html,
      ContentReference contentLink = null,
      IContentLoader contentLoader = null)
    {
      contentLink = contentLink ??
        html.ViewContext.RequestContext.GetContentLink();
      contentLoader = contentLoader ??
        ServiceLocator.Current.GetInstance<IContentLoader>();

      var pagePath = NavigationPath(contentLink, contentLoader);
      var path = FilterForVisitor.Filter(pagePath)
        .OfType<PageData>()
        .Select(x => x.PageLink);
      if (!path.Any())
      {
        //Nothing to render, no need to output an empty list.
        return;
      }

      var writer = html.ViewContext.Writer;

      writer.WriteLine("<ol class=\"breadcrumb\">");

      foreach (var part in path)
      {
        if (part.CompareToIgnoreWorkID(contentLink))
        {
          writer.WriteLine("<li class=\"active\">");

          //For the current page there's no point in outputting a link.
          //Instead output just the (encoded) page name.
          var currentPage = contentLoader.Get<PageData>(contentLink);
          writer.WriteLine(html.Encode(currentPage.PageName));
        }
        else
        {
          writer.WriteLine("<li>");
          writer.WriteLine(html.PageLink(part));
        }

        writer.WriteLine("</li>");
      }

      writer.WriteLine("</ol>");
    }
  }
}