using EPiServer.Web.Mvc;
using FruitCorp.Web.Models.Pages;
using System.Web.Mvc;

namespace FruitCorp.Web.Controllers
{
    public class StartController : PageController<StartPage>
    {
        
        public ActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }

    }
}
