using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test_Work.Models;

namespace Test_Work.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ItemsDbContext _context;

    public HomeController(ILogger<HomeController> logger,ItemsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Items()
    {
        var allItems = _context.Items.ToList();
        return View(allItems);
    }

    public IActionResult EditItem(int? id)
    {
        if (id != null)
        {
            var ItemInDb = _context.Items.SingleOrDefault(item => item.id == id);
            return View(ItemInDb);
        }

        return View();
    }

    public IActionResult DeleteItem(int id)
    {
        var ItemInDb = _context.Items.SingleOrDefault(item=>item.id==id);
        _context.Items.Remove(ItemInDb);
        _context.SaveChanges();
        return RedirectToAction("Items");
    }

    public IActionResult CreateEditForm(Item i)
    {
        if (i.id == 0)
        {
            _context.Items.Add(i);
        }
        else
        {
            _context.Items.Update(i);
        }
        _context.SaveChanges();

        return RedirectToAction("Items");
    }

    public IActionResult CreateEdit(int? id)
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
