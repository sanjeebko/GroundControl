using GroundControl.Interview.SeniorDeveloper.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Web.Services
{
    public class GarageServices :IGarageServices
    {
        private readonly HttpClient _httpClient;
        public GarageServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            var res = await _httpClient.GetStreamAsync($"api/Bookings/Booking");

            return await JsonSerializer.DeserializeAsync<IEnumerable<Booking>>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakes()
        {
            var res = await _httpClient.GetStreamAsync($"Vehicles/makes");

            return await JsonSerializer.DeserializeAsync<IEnumerable<VehicleMake>>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsByMakeId(int makeId)
        {
            var res = await _httpClient.GetStreamAsync($"Vehicles/{makeId}/models");

            return await JsonSerializer.DeserializeAsync<IEnumerable<VehicleModel>>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> SaveBookings(int bookingType, int makeid, int model, string registrationNumber)
        {
            var res = await _httpClient.GetStreamAsync($"api/Bookings/SaveBooking/{bookingType}/{makeid}/{model}/{registrationNumber}");

            return await JsonSerializer.DeserializeAsync<bool>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<BookingType>> GetBookingTypes(){

             
            var res = await _httpClient.GetStreamAsync($"api/Bookings/BookingTypes");

            return await JsonSerializer.DeserializeAsync<IEnumerable<BookingType>>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
