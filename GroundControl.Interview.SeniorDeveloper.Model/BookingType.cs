using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Model
{
    public class BookingType
    {
        [Key]
        public int TypeId { get; set; }
        public String Name{ get; set; }
    }
}
