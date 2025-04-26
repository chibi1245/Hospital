using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ApplicationUserController : Controller
    {private IApplicationUserSerivce _UserService;

        public ApplicationUserController(IApplicationUserSerivce userService)
        {
            _UserService = userService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            
            return View( _UserService.GetAll(pageNumber, pageSize));
        }
        public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
        {

            return View(_UserService.GetAllDoctor(pageNumber, pageSize));
        }



    }
}
