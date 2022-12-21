using System.ComponentModel.DataAnnotations;

namespace TruckDiscovery.Models
{
    public enum TruckModel
    {
        FH, FM
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int TruckID { get; set; }
        [DisplayFormat(NullDisplayText = "No truck model")]
        public TruckModel? TruckModel { get; set; }

        public Truck Truck { get; set; }
    }
}