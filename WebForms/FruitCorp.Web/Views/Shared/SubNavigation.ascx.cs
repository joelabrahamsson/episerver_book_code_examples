using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;

namespace FruitCorp.Web.Views.Shared
{
  public partial class SubNavigation : UserControlBase<PageData>
  {
    protected PageReference MenuRoot
    {
      get
      {
        if (CurrentPage.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
        {
          return CurrentPage.PageLink;
        }
        var rootPage = Locate.ContentLoader()
            .GetAncestors(CurrentPage.ContentLink)
            .OfType<PageData>()
            .FirstOrDefault(x => x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage));
        if (rootPage != null)
        {
          return rootPage.PageLink;
        }
        return null;
      }
    }

    protected bool MenuRootHasChildren
    {
      get
      {
        var rootLink = MenuRoot;
        if (rootLink == null)
        {
          return false;
        }
        var children = Locate.ContentLoader()
                             .GetChildren<PageData>(rootLink);
        return FilterForVisitor.Filter(children).Any();
      }
    }
  }
}