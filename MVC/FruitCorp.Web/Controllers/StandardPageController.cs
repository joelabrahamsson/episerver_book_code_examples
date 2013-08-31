using EPiServer.Web.Mvc;
using FruitCorp.Web.Models.Pages;
using System.Web.Mvc;

namespace FruitCorp.Web.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            return View(currentPage);
        }

    }
}
