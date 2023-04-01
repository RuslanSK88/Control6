using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListContext _db;

        public HomeController(ToDoListContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.Problem = _db.Problems.ToList();
            vm.Priority = _db.Priorities.ToList();
            vm.Status = _db.Statuses.ToList();
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}