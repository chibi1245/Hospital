using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
   public  interface IApplicationUserSerivce
    {PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize,string spicility=null);
    }
}
