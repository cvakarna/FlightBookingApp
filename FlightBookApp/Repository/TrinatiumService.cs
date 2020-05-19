using FlightBookApp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookApp.Repository
{
    public class TrinatiumService: IService
    {
        public async Task<string> BookFlightAsync(string bookingInfo)
        {
            string result = null;
            string serviceUrl = ConfigurationUtil.Properties.ServiceUrl;
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(serviceUrl, new StringContent(bookingInfo, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            return result;

        }
    }
}
