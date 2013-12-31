using EPiServer.Core;
using System.ComponentModel.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  public abstract class BasePage : PageData
  {
    [Display(GroupName = "Meta data", Order = 10)]
    public virtual string Title
    {
      get { return this.GetPropertyValue(x => x.Title); }
      set { this.SetPropertyValue(x => x.Title, value); }
    }

    [Display(GroupName = "Meta data", Order = 20)]
    public virtual string MetaDescription
    {
      get { return this.GetPropertyValue(x => x.MetaDescription); }
      set { this.SetPropertyValue(x => x.MetaDescription, value); }
    }
  }
}