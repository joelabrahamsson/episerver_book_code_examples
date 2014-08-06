using System.Web;
using System.Web.Mvc;
using CsQuery;
using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.Web.Mvc.Html;

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

    public static IHtmlString CustomXhtmlString(this HtmlHelper helper, XhtmlString value)
    {
      var htmlString = helper.XhtmlString(value).ToHtmlString();
      
      var headline = LocalizationService.Current
        .GetString("/views/common/linklist/headline");
      
      var cq = new CQ(htmlString, HtmlParsingMode.Document);
      cq.Find("ul.link-list").Each(list =>
        {
          var box = CQ.CreateFragment(
            "<div class=\"link-list\">" 
            + "<h4><span class=\"glyphicon glyphicon-link\"></span> " 
            + headline
            + "</h4></div>");
          list.RemoveClass("link-list");
          box.Append(list.OuterHTML);
          list.Cq().ReplaceWith(box);
        });

      return new MvcHtmlString(cq.Find("body").Html());
    }
  }
}