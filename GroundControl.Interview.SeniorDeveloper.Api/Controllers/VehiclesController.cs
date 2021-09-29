using System.Collections.Generic;
using GroundControl.Interview.SeniorDeveloper.Api.Data.Repository;
using GroundControl.Interview.SeniorDeveloper.Model;
using Microsoft.AspNetCore.Mvc;

namespace GroundControl.Interview.SeniorDeveloper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehiclesController(IVehicleMakeRepository vehicleMake,IVehicleModelRepository vehicleModel)
        {
            _vehicleMakeRepository = vehicleMake;
            _vehicleModelRepository = vehicleModel;
        }
        

        [HttpGet]
        [Route("makes")]
        public IActionResult GetMakes()
        {
            IEnumerable<VehicleMake> result = _vehicleMakeRepository.GetVehicleMakes();
            if (result == null) BadRequest("ERROR: No Vehicle Makes found in the database.");
            return Ok(result);
        }

        [HttpGet]
        [Route("{makeId}/makes")]
        public IActionResult GetMakes(int makeId)
        {
            // using the makeId parameter, get the results from the database
            //IEnumerable<VehicleModel> result = new List<VehicleModel> {new() { Id = 1, Name = "Test Model"  }, new() { Id = 2, Name = "Test Model 2" } };
            // return Ok(result);
            VehicleMake result = _vehicleMakeRepository.GetVehicleMake(makeId);
            if (result == null)
                return BadRequest("ERROR: MakeId doesn't exist in the database");
            return Ok(result);
        }

        [HttpGet]
        [Route("models")]
        public IActionResult GetModels()
        {
            IEnumerable<VehicleModel> result = _vehicleModelRepository.GetVehicleModels();
            if (result == null) BadRequest("ERROR: No Vehicle Model found in the database.");
            return Ok(result);
        }

        [HttpGet]
        [Route("{makeId}/models")]
        public IActionResult GetModels(int makeId)
        {
            // using the makeId parameter, get the results from the database
            //IEnumerable<VehicleModel> result = new List<VehicleModel> {new() { Id = 1, Name = "Test Model"  }, new() { Id = 2, Name = "Test Model 2" } };
            // return Ok(result);
            IEnumerable<VehicleModel> result = _vehicleModelRepository.GetVehicleModelsByMakeId(makeId);
            if (result == null)
                return BadRequest("ERROR: Model doesn't exist for this make.");
            return Ok(result);
        }
    }
}
