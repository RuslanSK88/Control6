using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers;

public class ProblemController : Controller
{
    private readonly ToDoListContext _db;

    public ProblemController(ToDoListContext db)
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

    public IActionResult Create()
    {
        ViewBag.Priority = new SelectList(_db.Priorities, "Id", "Name");
        ViewBag.Status = new SelectList(_db.Statuses, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Problem problem)
    {
        ViewBag.Priority = new SelectList(_db.Priorities, "Id", "Name");
        ViewBag.Status = new SelectList(_db.Statuses, "Id", "Name");
        if (ModelState.IsValid)
        {
            _db.Add(problem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(problem);
    }
}
