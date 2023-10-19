using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;
    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Specialties.ToList());
    }
    public ActionResult Details(int id)
    {
      Specialty thisSpec = _db.Specialties
                           .Include(spec => spec.JoinEntities)
                           .ThenInclude(join => join.Doctor)
                           .FirstOrDefault(spec => spec.SpecialtyId == id);
      return View(thisSpec);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
      _db.Specialties.Add(specialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddDoctor(int id)
    {
      Specialty thisSpec = _db.Specialties.FirstOrDefault(specs => specs.SpecialtyId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "DoctorName");
      return View(thisSpec);
    }
    [HttpPost]
    public ActionResult AddDoctor(Specialty specialty, int doctorId)
    {
      #nullable enable
      DoctorSpecialty? joinEntity = _db.DoctorSpecialties
                                    .FirstOrDefault(join => (join.DoctorId == doctorId && join.SpecialtyId == specialty.SpecialtyId));
      #nullable disable
      if (joinEntity == null && doctorId != 0)
      {
        _db.DoctorSpecialties.Add(new DoctorSpecialty() { DoctorId = doctorId, SpecialtyId = specialty.SpecialtyId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = specialty.SpecialtyId });
    }
    
    public ActionResult Delete(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(spec => spec.SpecialtyId == id);
      _db.Specialties.Remove(thisSpecialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      DoctorSpecialty joinEntry = _db.DoctorSpecialties
                                   .FirstOrDefault(entry => entry.DoctorSpecialtyId == joinId);
      _db.DoctorSpecialties.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}