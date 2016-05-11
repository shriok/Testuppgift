using General.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IGoogleMapsRepository
    {
        /// <summary>
        /// Gets Cordinates of Stores location information and saves it to database 
        /// (if fail location 0 will be saved instead)
        /// </summary>
        /// <param name="store">Repository.Store</param>
        void Post(Stores store);

        /// <summary>
        /// Attempts to get cordinates from googlemaps
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Returns Result (objectified Json string)</returns>
        Task<Results> APIRequest(string address);
    }
}
