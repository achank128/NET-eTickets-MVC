using eTickets.Models;
using eTickets.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await _actorsService.GetAll();
            return View(actors);
        }

        public IActionResult Create() { 
            return View(); 
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorsService.GetById(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorsService.GetById(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _actorsService.Create(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _actorsService.Update(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorsService.GetById(id);
            if (actorDetails == null) return View("NotFound");

            await _actorsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
