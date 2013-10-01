using EPiServer.Core;

namespace FruitCorp.Web.Models.Pages
{
  public abstract class BasePage : PageData
  {
    public virtual string Title { get; set; }

    public virtual string MetaDescription { get; set; }
  }
}