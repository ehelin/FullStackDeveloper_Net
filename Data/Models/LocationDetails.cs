using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class LocationDetails
    {
        public int LocationDetailId { get; set; }
        public int? LocationId { get; set; }
        public string Weather { get; set; }
        public string Food { get; set; }
        public string People { get; set; }

        public Location Location { get; set; }
    }
}
