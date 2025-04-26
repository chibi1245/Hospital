using Hospital.Model;
using Hospital.Services;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DoctorsController : Controller
    { private  IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AddTiming()
        {
            Timing timing = new Timing();
            List<SelectListItem> Morningshiftstart = new List<SelectListItem>();
            List<SelectListItem> Morningshiftend = new List<SelectListItem>();
            List<SelectListItem> afternoonshiftstart = new List<SelectListItem>();
            List<SelectListItem> afternoonshiftend = new List<SelectListItem>();
            for (int i = 1; i < 11; i++)
            {
                Morningshiftstart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
               
            }
            for (int i = 1; i < 13; i++)
            {
                Morningshiftend.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i < 16; i++)
            {
                afternoonshiftstart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i < 18; i++)
            {
                afternoonshiftend.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.Morningshiftstart = new SelectList( Morningshiftstart,"Value","Text");
            ViewBag.Morningshiftend = new SelectList(Morningshiftend, "Value", "Text");
            ViewBag.afternoonshiftstart = new SelectList(afternoonshiftstart, "Value", "Text");
            ViewBag.afternoonshiftend = new SelectList(afternoonshiftend, "Value", "Text");

            TimingViewModel vm = new TimingViewModel();
            vm.Daytime = DateTime.Now;
            vm.Daytime = vm.Daytime.AddDays(1);

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
            
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claims != null)
            {
               
               
                _doctorService.AddTiming(vm);
            }


               
                return RedirectToAction("Index");
            
            
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetTimingById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(TimingViewModel vm)
        {
            _doctorService.UpdateTiming(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _doctorService.DeleteTiming(id);
            return RedirectToAction("Index");
        }
    }
}
