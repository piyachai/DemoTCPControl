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
    
    public partial class tran_transaction2
    {
        public int transactionID { get; set; }
        public System.DateTime transactionChkIn { get; set; }
        public int sysUserID_ChkIn { get; set; }
        public Nullable<int> priceProfileID { get; set; }
        public Nullable<int> accountingID { get; set; }
    }
}
