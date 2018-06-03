using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public partial class LocationDetailsModel
    {
        public int LocationDetailId { get; set; }               
        public int? LocationId { get; set; }                    

        [Display(Name = "Weather")]
        public string Weather { get; set; }                     

        [Display(Name = "Weather")]
        public string Food { get; set; }                        

        [Display(Name = "Weather")]
        public string People { get; set; }                      
    }
}
