using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "daaf8adc-f615-45ca-8a0e-1ba3d53caec2",
    GroupName = "Editorial")]
  [ImageUrl("~/Content/Icons/Standard.png")]
  [AvailablePageTypes(Include = new[] { typeof(StandardPage) })]
  public class StandardPage : BasePage
  {
    [Display(GroupName = "Meta data", Order = 10)]
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

    [Display(GroupName = "Meta data", Order = 20)]
    [UIHint(UIHint.Textarea)]
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

    [Display(Order = 10)]
    [UIHint(UIHint.Textarea)]
    public virtual string MainIntro { get; set; }

    [Display(Order = 20)]
    public virtual XhtmlString MainBody { get; set; }
  }
}