//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackOffice
{
    using System;
    using System.Collections.Generic;
    
    public partial class tran_priceProfileDay
    {
        public tran_priceProfileDay()
        {
            this.tran_priceProfileHour = new HashSet<tran_priceProfileHour>();
        }
    
        public int priceProfileDayID { get; set; }
        public int priceProfileDayNumOfDay { get; set; }
        public int priceProfileDayFreeTime { get; set; }
        public double priceProfileDayServiceCharge { get; set; }
        public int priceProfileID { get; set; }
    
        public virtual tran_priceProfile tran_priceProfile { get; set; }
        public virtual ICollection<tran_priceProfileHour> tran_priceProfileHour { get; set; }
    }
}
