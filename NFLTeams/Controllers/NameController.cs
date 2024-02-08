using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
            });
        }
       
        [HttpGet]
        public ViewResult NameIndex()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                UserName = session.GetName(),
            };

            return View(model);
        }
    }
}
