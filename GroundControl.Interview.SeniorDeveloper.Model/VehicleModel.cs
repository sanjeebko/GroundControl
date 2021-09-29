using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Model
{
    public class VehicleModel
    {
        [Key]
        public int ModelId { get; set; }
        public string Model { get; set; }

        public int MakeId { get; set; }
        
    }
}
