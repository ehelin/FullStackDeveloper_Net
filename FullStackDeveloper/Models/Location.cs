using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace FullStackDeveloper.Models
{
    public partial class Location
    {
        [DataMember]
        public int LocationiId { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public LocationDetails LocationDetails { get; set; }
    }
}
