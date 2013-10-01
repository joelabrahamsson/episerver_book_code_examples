using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "7d6920ba-5718-49e4-ab82-b289a296f487",
    GroupName = "Specialized")]
  [ImageUrl("~/Content/Icons/Home.png")]
  [AvailablePageTypes(Include = new[] { typeof(StandardPage) })]
  [Access(Roles = "CmsAdmins")]
  public class StartPage : BasePage
  {
  }
}