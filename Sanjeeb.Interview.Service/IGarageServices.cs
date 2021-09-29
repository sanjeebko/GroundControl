using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Service
{
    public interface IGarageServices
    {
        Task<IEnumerable<BookingType>> GetBookingTypes();
    }
}
