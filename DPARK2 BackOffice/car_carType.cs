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
    
    public partial class car_carType
    {
        public car_carType()
        {
            this.cars = new HashSet<car>();
            this.tran_priceProfile = new HashSet<tran_priceProfile>();
        }
    
        public int carTypeID { get; set; }
        public string carTypeName { get; set; }
        public string carTypeComment { get; set; }
        public bool carTypeActive { get; set; }
    
        public virtual ICollection<car> cars { get; set; }
        public virtual ICollection<tran_priceProfile> tran_priceProfile { get; set; }
    }
}