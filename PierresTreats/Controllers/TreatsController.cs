using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PierresTreats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierresTreatsContext _dbContext;

        public TreatsController(PierresTreatsContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Treats> model = _db.Treats.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}