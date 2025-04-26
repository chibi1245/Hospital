using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class ApplicationUserViewModel
    {

        public string Name { get; set; }
        public Gender Gender { get; set; }
      
        public string Email { get; set; }
        public bool IsDoctor { get; set; }

        public string Specialist { get; set; }
        public ApplicationUserViewModel()
        {
        }
        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            Gender = user.Gender;
            Specialist = user.Specialist;
            Email = user.Email;
            IsDoctor = user.IsDoctor;


        }
        public ApplicationUser ConvertViewModelToModel(ApplicationUser user)
        {
            return new ApplicationUser
            {

                Name = user.Name,
                Gender = user.Gender,

                Specialist = user.Specialist,
                Email = user.Email,
                IsDoctor=user.IsDoctor

            };
        }
             public List<ApplicationUser> Doctor { get; set; } = new List<ApplicationUser>();
    }

    }
    

