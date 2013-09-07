using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "1cfe38ca-025e-4f66-a237-226c44f586e9",
    GroupName = "Editorial")]
  [ImageUrl("~/Content/Icons/Standard.png")]
  public class StandardPage : BasePage
  {
    public virtual string MainIntro { get; set; }

    public virtual XhtmlString MainBody { get; set; }
  }
}