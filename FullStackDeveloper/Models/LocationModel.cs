using System.Runtime.Serialization;

namespace Web.Models
{
    public partial class LocationModel
    {
        [DataMember]
        public int LocationiId { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public LocationDetailsModel LocationDetails { get; set; }
    }
}
