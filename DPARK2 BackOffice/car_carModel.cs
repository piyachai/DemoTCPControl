//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackOffice
{
    using System;
    using System.Collections.Generic;
    
    public partial class car_carModel
    {
        public car_carModel()
        {
            this.cars = new HashSet<car>();
        }
    
        public int carModelID { get; set; }
        public Nullable<int> carBrandID { get; set; }
        public string carModelName { get; set; }
    
        public virtual ICollection<car> cars { get; set; }
        public virtual car_carBrand car_carBrand { get; set; }
    }
}
