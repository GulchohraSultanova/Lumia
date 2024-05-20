using Bussiness.Abstracts;
using Bussiness.Exceptions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Admin
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var teams = _teamService.GetAllTeams();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _teamService.Create(team);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            catch (NotNullException ex)
            {
                ModelState.AddModelError("PhotoFile", ex.Message);
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("PhotoFile", ex.Message);
            }
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            var team=_teamService.GetTeam(x=>x.Id == id);
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _teamService.Update(team.Id,team);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
         
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("PhotoFile", ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
