using EPiServer.Core;

namespace FruitCorp.Web.Models.Pages
{
  public abstract class BasePage : PageData
  {
    public virtual string Title
    {
      get { return this.GetPropertyValue(x => x.Title); }
      set { this.SetPropertyValue(x => x.Title, value); }
    }

    public virtual string MetaDescription
    {
      get { return this.GetPropertyValue(x => x.MetaDescription); }
      set { this.SetPropertyValue(x => x.MetaDescription, value); }
    }
  }
}