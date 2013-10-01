using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "daaf8adc-f615-45ca-8a0e-1ba3d53caec2",
    GroupName = "Editorial")]
  [ImageUrl("~/Content/Icons/Standard.png")]
  [AvailablePageTypes(Include = new[] { typeof(StandardPage) })]
  public class StandardPage : BasePage
  {
    public virtual string MainIntro { get; set; }

    public virtual XhtmlString MainBody { get; set; }

  }
}