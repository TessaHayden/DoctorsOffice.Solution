using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorsOffice.Controllers
{
  public class PatientsController : Controller
  {
    private readonly DoctorsOfficeContext _db;
    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Patient> model = _db.Patients
                            .Include(pat => pat.Doctors)
                            .ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "DoctorName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Patient patient)
    {
      if(!ModelState.IsValid)
      {
        ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "DoctorName");
        return View(patient);
      }
      _db.Patients.Add(patient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Patient thisPat = _db.Patients
                        .Include(pat => pat.Doctors)
                        .FirstOrDefault(pat => pat.PatientId == id);
      return View(thisPat);
    }
  }
}