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
    
    public partial class ticket
    {
        public int ticketID { get; set; }
        public string ticketNumber { get; set; }
        public int ticketTypeID { get; set; }
        public Nullable<int> ticketMemberID { get; set; }
        public System.DateTime ticketStartDate { get; set; }
        public System.DateTime ticketExpiryDate { get; set; }
        public string ticketRemainDay { get; set; }
        public Nullable<int> ticketRemainSecond { get; set; }
        public bool ticketActive { get; set; }
        public int ticketRemainTimes { get; set; }
        public double ticketCredit { get; set; }
        public int userID_Create { get; set; }
        public System.DateTime ticketDateUpdate { get; set; }
        public Nullable<int> carID { get; set; }
        public Nullable<int> priceMonthlyID { get; set; }
    
        public virtual accounting accounting { get; set; }
        public virtual car car { get; set; }
        public virtual sysUser sysUser { get; set; }
        public virtual ticketType ticketType { get; set; }
        public virtual ticketMember ticketMember { get; set; }
    }
}