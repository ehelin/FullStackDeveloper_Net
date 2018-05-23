using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public partial class LocationDetailsModel
    {
        // TODO - add serializable and datacontract/datamember annotations

        public int LocationDetailId { get; set; }               //make hidden field
        public int? LocationId { get; set; }                    //do not use of view

        [Display(Name = "Weather")]
        public string Weather { get; set; }                     //add as html label/input (use [Display(Name="Name")])

        [Display(Name = "Weather")]
        public string Food { get; set; }                        //add as html label/input (use [Display(Name="Name")])

        [Display(Name = "Weather")]
        public string People { get; set; }                      //add as html label/input (use [Display(Name="Name")])
    }
}
