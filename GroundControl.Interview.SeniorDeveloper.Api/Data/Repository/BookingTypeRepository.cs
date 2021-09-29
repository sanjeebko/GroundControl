using GroundControl.Interview.SeniorDeveloper.Api.Data.Context;
using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;
using System.Linq;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public class BookingTypeRepository : IBookingTypeRepository
    {
        private readonly GroundDBContext groundDBContext;
        public BookingTypeRepository(GroundDBContext groundDBContext)
        {
            this.groundDBContext = groundDBContext;
        }
        public void AddBookingType(BookingType bookingType)
        {
            if (bookingType != null)
            {
                this.groundDBContext.BookingType.Add(bookingType);
            }
        }

        public BookingType GetBookingType(int id)
        {
            return groundDBContext.BookingType.Where(a => a.TypeId == id).FirstOrDefault();
        } 

       

        public IEnumerable<BookingType> GetBookingTypes()
        {
            return groundDBContext.BookingType.OrderBy(a => a.Name);
        }

        public bool SaveAll()
        {
            return groundDBContext.SaveChanges() > 0;
        }
    }
}
