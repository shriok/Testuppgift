using Newtonsoft.Json;
using Repository.Interface;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GoogleMapsRepository: IGoogleMapsRepository
    {
        IStoreRepository _StoreRepository;

        public GoogleMapsRepository()
        {
            _StoreRepository = new StoreRepository();
        }

        public GoogleMapsRepository(StoreRepository storeRepository)
        {
            _StoreRepository = storeRepository;
        }

        /// <summary>
        /// Gets Cordinates of Stores location information and saves it to database 
        /// (if fail location 0 will be saved instead)
        /// </summary>
        /// <param name="store">Repository.Store</param>
        public async void Post(Stores store)
        {
            try
            {
                string address = store.Address + "+" + store.Zip + "+" + store.City + "+" + store.Country;
                Results result = await APIRequest(address);
                if (result.results.Count > 0 && result != null && result.results != null && result.results[0].geometry != null 
                                   && result.results[0].geometry.location != null)
                {
                    store.Latitude = result.results[0].geometry.location.lat.ToString();
                    store.Longitude = result.results[0].geometry.location.lng.ToString();
                }
                else
                {
                    store.Latitude = "0";
                    store.Longitude = "0";
                }
                _StoreRepository.Update(store);
            }
            catch (Exception)
            {
            }
            
        }

        /// <summary>
        /// Attempts to get cordinates from googlemaps
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Returns Result (objectified Json string)</returns>
        public async Task<Results> APIRequest(string address)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var r = await client.GetAsync("https://maps.google.com/maps/api/geocode/json?address=" + address + "&sensor=false"))
                    {
                        if (r.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string response = await r.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<Results>(response);
                        }
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
