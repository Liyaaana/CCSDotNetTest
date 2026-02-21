using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hospital.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult AddTiming()
        {
            var doctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var vm = new TimingViewModel
            {
                DoctorId = doctorId,
                DoctorName = User.Identity.Name ?? "",
                Date = DateTime.Today
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            // Always assign DoctorId and DoctorName before validation
            vm.DoctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            vm.DoctorName = User.Identity.Name ?? "";

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _doctorService.AddTiming(vm);
            return RedirectToAction("Index");
        }
    }
}
