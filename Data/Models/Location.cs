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
            this.Created = DateTime.Now;
            this.CreatedBy = "Api";
            this.Modified = DateTime.Now;
            this.ModifiedBy = "Api";
        }

        [DataMember]
        public int LocationiId { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime Modified { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public LocationDetails LocationDetails { get; set; }
    }
}
