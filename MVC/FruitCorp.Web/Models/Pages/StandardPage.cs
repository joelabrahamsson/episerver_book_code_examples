using System.Runtime.CompilerServices;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "1cfe38ca-025e-4f66-a237-226c44f586e9",
    GroupName = "Editorial")]
  [ImageUrl("~/Content/Icons/Standard.png")]
  [AvailablePageTypes(Include = new[] { typeof(StandardPage) })]
  public class StandardPage : BasePage
  {
    public override string Title
    {
      get
      {
        var title = base.Title;

        if (string.IsNullOrEmpty(title))
        {
          title = PageName;
        }

        return title;
      }
      set
      {
        base.Title = value;
      }
    }
    
    public override string MetaDescription
    {
      get
      {
        var metaDescription = base.MetaDescription;

        if (string.IsNullOrEmpty(metaDescription))
        {
          metaDescription = MainIntro;
        }

        return metaDescription;
      }
      set
      {
        base.MetaDescription = value;
      }
    }

    public virtual string MainIntro { get; set; }

    public virtual XhtmlString MainBody { get; set; }
  }
}