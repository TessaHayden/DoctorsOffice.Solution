using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoctorsOffice.Models;

namespace DoctorsOffice.Controllers
{
  public class HomeController : Controller
  {
    private readonly DoctorsOfficeContext _db;
    public HomeController(DoctorsOfficeContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}