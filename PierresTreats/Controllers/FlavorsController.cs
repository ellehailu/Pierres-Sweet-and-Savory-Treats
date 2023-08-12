using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresTreats.Models;

#nullable enable
namespace PierresTreats.Controllers
{
    [Authorize]
    public class FlavorsController : Controller
    {
        private readonly PierresTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Flavor> model = _db.Flavors.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            // //check if model state is valid
            // if (ModelState.IsValid)
            // {
            //     _db.Flavors.Add(flavor);
            //     _db.SaveChanges();
            //     return RedirectToAction("Index");
            // }
            // else
            // {
            //     return View(flavor);
            // }

            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Flavor thisFlavor = _db.Flavors
                                .Include(flavor => flavor.JoinEntities)
                                .ThenInclude(join => join.Treat).FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        public ActionResult Edit(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Flavors.Update(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddTreat(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult AddTreat(Flavor flavor, int treatId)
        {
            TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => join.TreatId == treatId && join.FlavorId == flavor.FlavorId);
            if (joinEntity == null && treatId != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = flavor.FlavorId });
        }
    }
}