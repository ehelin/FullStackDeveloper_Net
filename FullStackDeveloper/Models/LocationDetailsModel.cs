namespace Web.Models
{
    public partial class LocationDetailsModel
    {
        public int LocationDetailId { get; set; }
        public int? LocationId { get; set; }
        public string Weather { get; set; }
        public string Food { get; set; }
        public string People { get; set; }
    }
}
