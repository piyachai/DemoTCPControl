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
    
    public partial class sysUserType
    {
        public sysUserType()
        {
            this.sys_sysUserType_permission = new HashSet<sys_sysUserType_permission>();
            this.sysUsers = new HashSet<sysUser>();
        }
    
        public int sysUserTypeID { get; set; }
        public string sysUserTypeName { get; set; }
        public string sysUserTypeDes { get; set; }
        public string sysUserTypeComment { get; set; }
    
        public virtual ICollection<sys_sysUserType_permission> sys_sysUserType_permission { get; set; }
        public virtual ICollection<sysUser> sysUsers { get; set; }
    }
}
