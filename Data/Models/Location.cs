using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.Models
{
    [Serializable]
    [DataContract]
    public partial class Location
    {
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
        public LocationDetails LocationDetails { get; set; }
    }
}
