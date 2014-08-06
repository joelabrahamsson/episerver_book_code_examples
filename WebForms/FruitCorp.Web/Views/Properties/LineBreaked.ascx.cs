using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace FruitCorp.Web.Views.Properties
{
  [TemplateDescriptor(TagString = "LineBreaked")]
  public partial class LineBreaked : PropertyControlBase<string>
  {
    protected string Formated
    {
      get
      {
        if (string.IsNullOrEmpty(CurrentData))
        {
          return string.Empty;
        }
        return CurrentData.Replace("\n", "<br />");
      }
    }
  }
}