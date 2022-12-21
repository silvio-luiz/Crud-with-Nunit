using System;
using System.ComponentModel.DataAnnotations;

namespace TruckDiscovery.Models.TruckViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? FabYear { get; set; }

        public int TruckCount { get; set; }
    }
}