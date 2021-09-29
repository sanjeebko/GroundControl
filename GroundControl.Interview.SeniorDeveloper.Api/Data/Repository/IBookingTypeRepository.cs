using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public interface IBookingTypeRepository
    {
        void AddBookingType(BookingType bookingType);
        BookingType GetBookingType(int id);
        IEnumerable<BookingType> GetBookingTypes();
        bool SaveAll();

    }
}
