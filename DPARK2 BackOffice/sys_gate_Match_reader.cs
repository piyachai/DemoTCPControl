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
    
    public partial class sys_gate_Match_reader
    {
        public int gatelMatchReaderID { get; set; }
        public Nullable<int> gateID { get; set; }
        public Nullable<int> readerID { get; set; }
    
        public virtual sysReader sysReader { get; set; }
    }
}
