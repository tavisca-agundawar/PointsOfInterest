using System;
using System.Collections.Generic;
using System.Text;

namespace PointsOfInterest.Models
{
    public class InterestPoint
    {
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionNameLong { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SubClassification { get; set; }
    }
}
