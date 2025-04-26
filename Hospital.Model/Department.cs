using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
   public  class Department
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Employee{ get; set; }
        public int Type { get; set; }
    }
}
