using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public List<Patient> Patients { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}