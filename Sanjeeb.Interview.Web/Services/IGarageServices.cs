using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Web.Services
{
    public interface IGarageServices
    {
        Task<IEnumerable<BookingType>> GetBookingTypes();
        Task<IEnumerable<VehicleMake>> GetVehicleMakes();
        Task<IEnumerable<VehicleModel>> GetVehicleModelsByMakeId(int makeId);
        Task<IEnumerable<Booking>> GetBookings();
        Task<bool> SaveBookings(int bookingType,int makeid, int model, string registrationNumber);
    }
}
