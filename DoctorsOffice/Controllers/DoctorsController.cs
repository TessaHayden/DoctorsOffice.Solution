using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorsOfficeContext _db;
    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Doctor thisDoc = _db.Doctors
                      .Include(doc => doc.Patients)
                      .Include(doc => doc.JoinEntities)
                      .ThenInclude(join => join.Specialty)
                      .FirstOrDefault(doc => doc.DoctorId == id);
      return View(thisDoc);
    }
    public ActionResult AddSpecialty(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "SpecialtyName");
      return View(thisDoctor);
    }
    [HttpPost]
    public ActionResult AddSpecialty(Doctor doctor, int specialtyId)
    {
#nullable enable
      DoctorSpecialty? joinEntity = _db.DoctorSpecialties.FirstOrDefault(join => (join.SpecialtyId == specialtyId && join.DoctorId == doctor.DoctorId));
#nullable disable
      if (joinEntity == null && specialtyId != 0)
      {
        _db.DoctorSpecialties.Add(new DoctorSpecialty() { SpecialtyId = specialtyId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = doctor.DoctorId });
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      DoctorSpecialty joinEntry = _db.DoctorSpecialties.FirstOrDefault(entry => entry.DoctorSpecialtyId == joinId);
      _db.DoctorSpecialties.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}