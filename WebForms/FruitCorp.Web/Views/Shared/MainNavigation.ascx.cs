using EPiServer;
using EPiServer.Core;
using System;

namespace FruitCorp.Web.Views.Shared
{
  public partial class MainNavigation : UserControlBase<PageData>
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      DataBind();
    }
  }
}