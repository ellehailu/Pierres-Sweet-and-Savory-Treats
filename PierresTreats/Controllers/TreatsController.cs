using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresTreats.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly PierresTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Treat> model = _db.Treats.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            //Model state validation
            if (ModelState.IsValid)
            {
                _db.Treats.Add(treat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
                return View(treat);
            }
        }

        public ActionResult Details(int id)
        {
            Treat thisTreat = _db.Treats
                                .Include(treat => treat.JoinEntities)
                                .ThenInclude(join => join.Flavor)
                                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }


        public ActionResult Edit(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Treats.Update(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //AddFlavor()
    }
}