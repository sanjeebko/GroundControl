using GroundControl.Interview.SeniorDeveloper.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Web.ViewModels
{
    public class ViewModelBooking
    {
        protected IEnumerable<BookingType> _bookingTypes;
        protected int _bookingTypeId;
        public int bookingTypeId
        {
            get { return _bookingTypeId; }
            set { _bookingTypeId = value; }
        }
        public List<SelectListItem> SelectedListBookingTypes { get; set; }
        
        public IEnumerable<BookingType> BookingTypes
        {
            get { return _bookingTypes; }
            set { _bookingTypes = value;
          
                foreach (var bt in _bookingTypes)
                {
                    if (SelectedListBookingTypes == null)
                        SelectedListBookingTypes = new List<SelectListItem>();
                    
                    SelectedListBookingTypes.Add(new SelectListItem(bt.Name, bt.TypeId.ToString()));
                     
                }
            }
        }

        protected IEnumerable<VehicleMake> _vehicleMakes;
        protected int _vehicleMakeId;
        public int VehicleMakeId
        {
            get { return _vehicleMakeId; }
            set { _vehicleMakeId = value; }
        }
       
        public List<SelectListItem> SelectedListVehicleMakes { get; set; }
        public IEnumerable<VehicleMake> VehicleMakes
        {
            get { return _vehicleMakes; }
            set
            {
                _vehicleMakes = value;
                foreach(var bt in _vehicleMakes)
                {
                    if (SelectedListVehicleMakes == null)
                        SelectedListVehicleMakes = new List<SelectListItem>();

                    SelectedListVehicleMakes.Add(new SelectListItem(bt.Make, bt.MakeId.ToString()));
                }
            }
        }


        protected IEnumerable<VehicleModel> _vehicleModels;
        public int VehicleModelId { get; set; }
        public List<SelectListItem> SelectedListVehicleModels { get; set; }

        public IEnumerable<VehicleModel> VehicleModels
        {
            get { return _vehicleModels; }
            set { _vehicleModels = value; 
                foreach(var bt in _vehicleModels)
                {
                    if (SelectedListVehicleModels == null)
                        SelectedListVehicleModels = new List<SelectListItem>();

                    SelectedListVehicleModels.Add(new SelectListItem(bt.Model, bt.ModelId.ToString()));
                }
            }
        }
        
        [Required]
        [MaxLength(8,ErrorMessage ="Registration Number cannot exceed more than 8 caracters.")]
        [MinLength(7, ErrorMessage = "Registration Number cannot be less than 6 caracters.")]
        public string RegistrationNumber { get; set; }
       
        
        
    }
}
