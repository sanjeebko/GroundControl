using System;
using System.ComponentModel.DataAnnotations;

namespace GroundControl.Interview.SeniorDeveloper.Model
{
    public class VehicleMake
    {
        [Key]
        public int MakeId { get; set; }
        public string Make { get; set; }
    }
}
