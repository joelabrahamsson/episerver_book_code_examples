using CsQuery;
using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.Web;

namespace FruitCorp.Web.Views.Properties
{
  public partial class CustomXhtmlString : PropertyControlBase<XhtmlString>
  {
    protected string Parsed
    {
      get
      {
        var htmlString = CurrentData.ToHtmlString();
        
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

        return cq.Find("body").Html();
      }
    }
  }
}