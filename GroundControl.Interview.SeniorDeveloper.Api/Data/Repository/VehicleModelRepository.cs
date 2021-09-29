using GroundControl.Interview.SeniorDeveloper.Api.Data.Context;
using GroundControl.Interview.SeniorDeveloper.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly GroundDBContext groundDBContext;
        public VehicleModelRepository(GroundDBContext groundDBContext)
        {
            this.groundDBContext = groundDBContext;
        }

        public void AddVehicleModel(VehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                this.groundDBContext.VehicleModel.Add(vehicleModel);
            }
        }

        public VehicleModel GetVehicleModel(int id)
        {
            return groundDBContext.VehicleModel.Where(a => a.MakeId == id).FirstOrDefault();
        }

        public IEnumerable<VehicleModel> GetVehicleModels()
        {
            return groundDBContext.VehicleModel.OrderBy(a=>a.MakeId).ThenBy(a=>a.Model) ;
        }

        public IEnumerable<VehicleModel> GetVehicleModelsByMakeId(int MakeId)
        {
            return groundDBContext.VehicleModel.Where(a => a.MakeId == MakeId).OrderBy(a=>a.Model);
        }

        public bool SaveAll()
        {
            return groundDBContext.SaveChanges() > 0;
        }
    }
}
