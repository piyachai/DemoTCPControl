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
    
    public partial class sysUserLog
    {
        public int sysUserLogID { get; set; }
        public int sysUserID { get; set; }
        public string sysUserLogType { get; set; }
        public System.DateTime sysUserLogTime { get; set; }
        public string sysUserLogMachineName { get; set; }
    
        public virtual sysUser sysUser { get; set; }
    }
}
