//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecuritySafeZone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Report
    {
        public int Rid { get; set; }
        public int Uid { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Time { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public Nullable<int> Pid { get; set; }
        public string Boundary { get; set; }
    
        public virtual Police Police { get; set; }
        public virtual User User { get; set; }
    }
}