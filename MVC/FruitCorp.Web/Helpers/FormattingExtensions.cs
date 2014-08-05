using System.Web;

namespace FruitCorp.Web.Helpers
{
  public static class FormattingExtensions
  {
    public static HtmlString ToHtmlLineBreaks(this string value)
    {
      var parsed = string.Empty;
      if (!string.IsNullOrEmpty(value))
      {
        parsed = HttpUtility.HtmlEncode(value);
        parsed = parsed.Replace("\n", "<br />");
      }

      return new HtmlString(parsed);
    }
  }
}