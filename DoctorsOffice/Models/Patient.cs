using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctors { get; set; }
    
  }
}