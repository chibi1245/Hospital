using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
   public   class Timing
    {
        public int Id { get; set; }
       
        public ApplicationUser DoctorId{ get; set; }
        public DateTime Daytime { get; set; }
        public int morningshiftstart { get; set; }
        public int morningshiftend { get; set; }
        public int Afternoonshiftstart { get; set; }
        public int Afternoonshiftend { get; set; }
        public int duration { get; set; }
        public Status Status { get; set; }
    }
}

namespace Hospital.Model
{
    public enum Status
    {Available,pending, confirm
    }
}