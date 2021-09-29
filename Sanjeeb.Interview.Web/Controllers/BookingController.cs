using GroundControl.Interview.SeniorDeveloper.Model;
using Microsoft.AspNetCore.Mvc;
using Sanjeeb.Interview.Web.Services;
using Sanjeeb.Interview.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Web.Controllers
{
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly IGarageServices garageServices;
        public ViewModelBooking _viewModelBooking;

        public BookingController(IGarageServices garageServices)
        {
            this.garageServices = garageServices;
        }

        
        public async Task<IActionResult> Index()
        {
            if (_viewModelBooking == null)
                _viewModelBooking = new ViewModelBooking();
            _viewModelBooking.BookingTypes = (await garageServices.GetBookingTypes()).ToList();
            _viewModelBooking.VehicleMakes = (await garageServices.GetVehicleMakes()).ToList();

            return View(_viewModelBooking);
        }
        [Route("BookingList")]
        public async Task<IActionResult> BookingList()
        {
            var result = (await garageServices.GetBookings()).ToList();

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ViewModelBooking viewModelBooking)
        {
            var valid =true;
            if ((viewModelBooking.VehicleModelId < 0) ||
                (viewModelBooking.VehicleMakeId < 0) ||
                (string.IsNullOrEmpty(viewModelBooking.RegistrationNumber)) ||
                (viewModelBooking.bookingTypeId < 0))
                valid = false;

            if (valid)
            {
                var saveBooking = (await garageServices.SaveBookings(
                                            viewModelBooking.bookingTypeId, 
                                            viewModelBooking.VehicleMakeId,
                                            viewModelBooking.VehicleModelId,                                            
                                            viewModelBooking.RegistrationNumber));
                return RedirectToAction("BookingList");
            }
            viewModelBooking.BookingTypes= (await garageServices.GetBookingTypes()).ToList();
            return View(viewModelBooking);
        }
        

        [Route("GetVehicleMakes")]
        public async Task<JsonResult> GetVehicleMakes()
        {
            var result = await garageServices.GetVehicleMakes();
           return Json(result);            
        }

        [HttpPost]
    [Route("GetVehicleModels")]
        public async Task<JsonResult> GetVehicleModels(int makeid)
        {
            var result = await garageServices.GetVehicleModelsByMakeId(makeid);
           return Json(result);            
        }
    }
}
