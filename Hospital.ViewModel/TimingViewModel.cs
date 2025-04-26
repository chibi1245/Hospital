using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hospital.ViewModel
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        
        public DateTime Daytime { get; set; }
        public int morningshiftstart { get; set; }
        public int morningshiftend { get; set; }
        public int Afternoonshiftstart { get; set; }
        public int Afternoonshiftend { get; set; }
        public int duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> Morningshiftstart = new List<SelectListItem>();
        List<SelectListItem> Morningshiftend = new List<SelectListItem>();
        List<SelectListItem> afternoonshiftstart = new List<SelectListItem>();
        List<SelectListItem> afternoonshiftend = new List<SelectListItem>();
        
        public ApplicationUser DoctorId{ get; set; }
        public TimingViewModel()
        {
        }
        public TimingViewModel(Timing model)
           
        {
            Id = model.Id;
            Daytime = model.Daytime;
            morningshiftstart = model.morningshiftstart;
            morningshiftend = model.morningshiftend;
            Afternoonshiftstart = model.Afternoonshiftstart;
            Afternoonshiftend = model.Afternoonshiftend;
            duration = model.duration;
            Status = model.Status;
            DoctorId= model.DoctorId;
        }
        public Timing ConvertViewModelToModel(TimingViewModel model)
        {
            return new Timing
            {
                Id =model. Id,
               
                Daytime = model.Daytime,
                morningshiftstart = model.morningshiftstart,
                morningshiftend = model.morningshiftend,
                Afternoonshiftstart =model. Afternoonshiftstart,
                Afternoonshiftend = model.Afternoonshiftend,
                duration =model. duration,
                Status = model.Status,
                DoctorId = model.DoctorId,

            };
        }
    }
}
