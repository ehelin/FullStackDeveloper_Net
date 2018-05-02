using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.Models
{
    [Serializable]
    [DataContract]
    public partial class Location
    {
        public Location()
        {
            LocationDetails = new HashSet<LocationDetails>();
        }

        [DataMember]
        public int LocationiId { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public DateTime? Created { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime? Modified { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public ICollection<LocationDetails> LocationDetails { get; set; }
    }
}
