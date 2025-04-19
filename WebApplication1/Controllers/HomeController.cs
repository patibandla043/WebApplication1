using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MartDb _context;

        public HomeController(ILogger<HomeController> logger, MartDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }
        public IActionResult Create(int? id)
        {
            var expInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            return View(expInDb);
        }
        public IActionResult Delete(int id)
        {
            var expInDb=_context.Expenses.SingleOrDefault
                (x => x.Id == id);
            _context.Expenses.Remove(expInDb);
            _context.SaveChanges();
            
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}