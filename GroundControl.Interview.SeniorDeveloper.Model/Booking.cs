using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string Registration { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingTypeId { get; set; }
               
        public int VehicleModelId { get; set; }

    }
}
