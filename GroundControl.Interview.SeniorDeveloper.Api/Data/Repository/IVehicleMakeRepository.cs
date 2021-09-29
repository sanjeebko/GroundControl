using GroundControl.Interview.SeniorDeveloper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public interface IVehicleMakeRepository
    {
        void AddVehicleMake(VehicleMake vehicleMake);
        VehicleMake GetVehicleMake(int id);
        IEnumerable<VehicleMake> GetVehicleMakes();
        bool SaveAll();

    }
}
