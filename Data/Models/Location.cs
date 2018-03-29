using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationDetails = new HashSet<LocationDetails>();
        }

        public int LocationiId { get; set; }
        public string LocationName { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<LocationDetails> LocationDetails { get; set; }
    }
}
