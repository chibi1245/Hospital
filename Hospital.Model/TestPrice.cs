using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
   public  class TestPrice
    {
        public int id { get; set; }
        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Lab Labs{ get; set; }
        public Bill Bills{ get; set; }
    }
}
