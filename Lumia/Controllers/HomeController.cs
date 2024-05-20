
using Bussiness.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lumia.Controllers
{
    
    public class HomeController : Controller
    {
    
        ITeamService _service;

        public HomeController(ITeamService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var teams=_service.GetAllTeams();
            return View(teams);
        }

    

        
    }
}
