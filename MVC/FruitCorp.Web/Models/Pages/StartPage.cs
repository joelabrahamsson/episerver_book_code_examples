using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType(
    GUID = "3e06c3bd-4bdf-4bbd-b745-07df69567502",
    GroupName = "Specialized")]
  [ImageUrl("~/Content/Icons/Home.png")]
  [AvailablePageTypes(Include = new [] {typeof(StandardPage)})]
  public class StartPage : BasePage
  {
  }
}