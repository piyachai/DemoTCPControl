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
    
    public partial class sys_sysUserType_permission
    {
        public int sysUserTypePermissionID { get; set; }
        public int sysUserTypeID { get; set; }
        public int permissionID { get; set; }
        public bool sysUserTypePermissionNew { get; set; }
        public bool sysUserTypePermissionRead { get; set; }
        public bool sysUserTypePermissionDel { get; set; }
        public bool sysUserTypePermissionEdit { get; set; }
    
        public virtual sys_permission sys_permission { get; set; }
        public virtual sysUserType sysUserType { get; set; }
    }
}