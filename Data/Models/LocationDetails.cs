using System;
using System.Runtime.Serialization;

namespace Data.Models
{
    [Serializable]
    [DataContract]
    public partial class LocationDetails
    {
        [DataMember]
        public int LocationDetailId { get; set; }
        [DataMember]
        public int? LocationId { get; set; }
        [DataMember]
        public string Weather { get; set; }
        [DataMember]
        public string Food { get; set; }
        [DataMember]
        public string People { get; set; }
    }
}
