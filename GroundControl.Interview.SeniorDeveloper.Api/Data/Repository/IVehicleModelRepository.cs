using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public interface IVehicleModelRepository
    {
        void AddVehicleModel(VehicleModel vehicleModel);
        VehicleModel GetVehicleModel(int id);
        IEnumerable<VehicleModel> GetVehicleModels();
        IEnumerable<VehicleModel> GetVehicleModelsByMakeId(int MakeId);
        bool SaveAll();

    }
}
