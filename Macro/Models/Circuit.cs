using System;
using System.ComponentModel.DataAnnotations;

namespace Macro.Models
{
    public class Circuit
    {
        public int ID { get; set; }
        public string CCSD { get; set; }
        public string Domain { get; set; }
        [Display(Name ="Type")]
        public string CKT_Type { get; set; }
        public string Source { get; set; }
        [Display(Name ="Source Interface")]
        public string SInt { get; set; }
        [Display(Name ="Source IP")]
        public string SIP { get; set; }
        public string Destination { get; set; }
        [Display(Name = "Destination Interface")]
        public string DInt { get; set; }
        [Display(Name = "Destination IP")]
        public string DIP { get; set; }
        public string CCO { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Display(Name="User")]
        public string user { get; set; }
    }
}
