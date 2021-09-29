using GroundControl.Interview.SeniorDeveloper.Api.Data.Context;
using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;
using System.Linq;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly GroundDBContext groundDBContext;
        public BookingRepository(GroundDBContext groundDBContext)
        {
            this.groundDBContext = groundDBContext;
        }
        public void AddVehicleMake(VehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                this.groundDBContext.VehicleMake.Add(vehicleMake);
            }
        }

        public IEnumerable<Booking> GetBookings()
        {
            return this.groundDBContext.Booking.OrderByDescending(a=>a.BookingDate);
        }

        public bool SaveBookings(int bookingType, int makeid, int model, string registrationNumber)
        {
            Booking booking = new Booking();
            booking.BookingDate = System.DateTime.Now;
            booking.BookingTypeId = bookingType;
            booking.VehicleModelId = model;
            booking.Registration = registrationNumber;
            groundDBContext.Booking.Add(booking);

            return (groundDBContext.SaveChanges() > 0);
        }
    }
}
