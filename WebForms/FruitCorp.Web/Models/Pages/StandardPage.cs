using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace FruitCorp.Web.Models.Pages
{
  [ContentType]
  public class StandardPage : PageData
  {
    public virtual string MainIntro { get; set; }

    public virtual XhtmlString MainBody { get; set; }

  }
}