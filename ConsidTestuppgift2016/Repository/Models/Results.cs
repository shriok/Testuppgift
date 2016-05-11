using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    /// <summary>
    /// Models for GoogleMaps Api request for easy convertion
    /// </summary>
    public class Results
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public List<Components> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public IList<string> types { get; set; }
    }

    public class Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public IList<string> types { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Location northeast { get; set; }
        public Location southwest { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

}
