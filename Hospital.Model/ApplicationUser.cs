﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender{ get; set; }
        public  string Nationality{ get; set; }
      
        public string Email { get; set; }


        public string Address { get; set; }
        public DateTime DOB{ get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
       // public string ?PictureUrl{ get; set; }
        public Department? Department { get; set; }

        [NotMapped]
        public ICollection<Appointment> Appointments{ get; set; }
        [NotMapped]
           public ICollection<PayRoll> PayRolls { get; set; }
        [NotMapped]
        public ICollection<PatientReport> patientReports { get; set; }

    }
}

namespace Hospital.Model
{
    public enum Gender
    {
        Female,Male,Others
    }
}