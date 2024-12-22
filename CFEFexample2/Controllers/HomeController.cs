using CFEFexample2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace CFEFexample2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly employeeDbContext employeeDb;
        public HomeController(employeeDbContext employeeDb)
        {
            this.employeeDb = employeeDb;
        }

        public IActionResult Index()
        {
            var empData = employeeDb.Employees.ToList();
            return View(empData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                await employeeDb.Employees.AddAsync(emp);
                await employeeDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || employeeDb.Employees == null)
            {
                return NotFound();
            }
            var empdata = await employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empdata == null)
            {
                return NotFound();
            }
            return View(empdata);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || employeeDb.Employees == null)
            {
                return NotFound();
            }
            var empdata = await employeeDb.Employees.FindAsync(id);
            if (empdata == null)
            {
                return NotFound();
            }
            return View(empdata);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Employee emp)
        {

            if (id != emp.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeDb.Employees.Update(emp);
                await employeeDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || employeeDb.Employees == null)
            {
                return NotFound();
            }
            var empdata = await employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empdata == null)
            {
                return NotFound();
            }
            return View(empdata);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var empdata = await employeeDb.Employees.FindAsync(id);
            if (empdata != null)
            {
                employeeDb.Employees.Remove(empdata);
            }
            await employeeDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            
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
