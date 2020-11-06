using System;
using System.ComponentModel.DataAnnotations;

namespace Macro.Models
{
    public class Software
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        [Display(Name ="Software Title")]
        public string SoftwareTitle { get; set; }
        [Display(Name = "Installed on")]
        public string AssignedTo { get; set; }
        [Display(Name = "Purchase Order")]
        public string PurchaseOrder { get; set; }
        [Display(Name = "License Type")]
        public string LicenseType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
        public bool Supported { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SupportExp { get; set; }
        [Display(Name = "Total Keys")]
        public int TotalKeys { get; set; }
        [Display(Name = "Used Keys")]
        public int UsedKeys { get; set; }
        [Display(Name = "License Key")]
        public string LicenseKey { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.DateTime)]
        public DateTime added { get; set; }
    }
}
