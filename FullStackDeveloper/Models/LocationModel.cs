using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [DataContract]
    public partial class LocationModel
    {
        [DataMember]
        public int LocationiId { get; set; }                            // add as hidden field

        [DataMember]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }                        // add as html label/input (use [Display(Name="Name")])

        [DataMember]
        public LocationDetailsModel LocationDetails { get; set; }

        public LocationModel() { }

        public LocationModel(Data.Models.Location location)
        {
            this.LocationiId = location.LocationiId;
            this.LocationName = location.LocationName;

            if (location.LocationDetails != null)
            {
                this.LocationDetails = new LocationDetailsModel();

                this.LocationDetails.Food = location.LocationDetails.Food;
                this.LocationDetails.People = location.LocationDetails.People;
                this.LocationDetails.Weather = location.LocationDetails.Weather;
                this.LocationDetails.LocationDetailId = location.LocationDetails.LocationDetailId;
            }
        }

        public Data.Models.Location GetDataModel()
        {
            Data.Models.Location dataLocation = new Data.Models.Location();

            dataLocation.LocationiId = this.LocationiId;
            dataLocation.LocationName = this.LocationName;

            if (this.LocationDetails != null)
            {
                dataLocation.LocationDetails = new Data.Models.LocationDetails();
                dataLocation.LocationDetails.LocationDetailId = this.LocationDetails.LocationDetailId;
                dataLocation.LocationDetails.Food = this.LocationDetails.Food;
                dataLocation.LocationDetails.People = this.LocationDetails.People;
                dataLocation.LocationDetails.Weather = this.LocationDetails.Weather;
            }

            return dataLocation;
        }
    }
}
