using GroundControl.Interview.SeniorDeveloper.Api.Data.Context;
using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly GroundDBContext groundDBContext;
        public VehicleMakeRepository(GroundDBContext groundDBContext)
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

        public VehicleMake GetVehicleMake(int id)
        {
            return groundDBContext.VehicleMake.Where(a => a.MakeId == id).FirstOrDefault();
        }

        public IEnumerable<VehicleMake> GetVehicleMakes()
        {
            return groundDBContext.VehicleMake.OrderBy(a => a.Make);
        }

        public bool SaveAll()
        {
            return groundDBContext.SaveChanges() > 0;
        }
    }
}
