namespace FullStackDeveloper.Models
{
    public partial class LocationDetails
    {
        public int LocationDetailId { get; set; }
        public int? LocationId { get; set; }
        public string Weather { get; set; }
        public string Food { get; set; }
        public string People { get; set; }
    }
}
