using System.ComponentModel.DataAnnotations;

namespace Macro.Models
{
    public class AdminSettings
    {
        public int ID { get; set; }
        public bool Scheduled { get; set; }
        [Required]
        [Display(Name = "Maintenance Date")]
        public string MaintenanceDate { get; set; }
        [Required]
        [Display(Name = "Maintenance Time")]
        public string MaintenanceTime { get; set; }
        public static string MaintenaceInfo { get; set; }
        public static string MaintenaceTimeInfo { get; set; }
        public static bool ScheduledBool { get; set; }
    }
    public class LicenseType
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
}
