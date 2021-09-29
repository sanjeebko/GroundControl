using GroundControl.Interview.SeniorDeveloper.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Service
{
    public class GarageServices :IGarageServices
    {
        private readonly HttpClient _httpClient;
        public GarageServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        async Task<IEnumerable<BookingType>> IGarageServices.GetBookingTypes()
        {
            var res = await _httpClient.GetStreamAsync($"api/Bookings");

            return await JsonSerializer.DeserializeAsync<IEnumerable<BookingType>>
                     (res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
