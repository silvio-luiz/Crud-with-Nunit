using System.ComponentModel.DataAnnotations;

namespace TruckDiscovery.Models
{
     public class DateAttribute : RangeAttribute
    {
        public string currentYear = new DateTime(DateTime.Now.Year, 1, 1).ToShortDateString();
        public string lastDayOfYear = new DateTime(DateTime.Now.Year, 1, 1).AddYears(+1).AddDays(-1).ToShortDateString();
        public DateAttribute()
            : base(typeof(DateTime), 
                        new DateTime(DateTime.Now.Year, 1, 1).ToShortDateString(),     
                        new DateTime(DateTime.Now.Year, 1, 1).AddYears(+1).AddDays(-1).ToShortDateString()) 
            { } 
    }
    public class YearEndAttribute : RangeAttribute
    {
        public string lastDayOfNextYear = new DateTime(DateTime.Now.Year, 12, 31).AddYears(+1).ToShortDateString();
        public YearEndAttribute()
            : base(typeof(DateTime), 
                    new DateTime(DateTime.Now.Year, 1, 1).ToShortDateString(),
                    new DateTime(DateTime.Now.Year, 12, 31).AddYears(+1).ToShortDateString())  
        { } 
    }
    public class Truck
    {
        
        public int ID { get; set; }

        [RegularExpression(@"^[FM, FH]*$")]
        [Required, Display(Name = "Model")]
        public string Model { get; set; }

        [YearEnd]
        [Required, Display(Name = "Fabrication Year")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FabYear { get; set; }

        [Date]
        [Required, Display(Name = "Model Year")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModelYear { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}