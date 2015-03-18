using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackOffice
{
    class cbsysUserType : ComboBox
    {

         public new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }
     
         public cbsysUserType()
        {

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
           

            if (this.DesignMode)
            {
                return;
            }
            General gb = new General();
                 
            using (Dpark3Entities  db = new  Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                
                var th  = from p in db.sysUserTypes
                         select p;
                if (th.Count() > 0)
                {
                   
                    this.BeginUpdate();
                    this.DisplayMember = "sysUserTypeDes";
                    this.ValueMember = "sysUserTypeID";
                    this.DataSource = th.ToList();
                    this.EndUpdate();
                }
            }
        }
    }
}
