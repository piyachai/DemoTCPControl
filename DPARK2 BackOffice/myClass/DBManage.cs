using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data;
using BackOffice.Properties;
using System.Linq;
using BackOffice;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using EntityFramework.Extensions;

namespace BackOffice
{
    public class DBManage
    {
        string _DBServer = string.Empty;
        string _DBUsername =string.Empty;
        string _DBPassword = string.Empty;
        string _DBName = string.Empty;
        private string dbconnStr = "";


        public SqlConnection cn;
        private SqlTransaction trn;
        private General gb;
        public DBManage()
        {
            gb = new General();
        }
    
        private void UpdateConnectionString()
        {
            _DBName = Settings.Default.DBName;
            _DBUsername = Settings.Default.DBUsername;
            _DBServer = Settings.Default.DBServer;
            _DBPassword = Settings.Default.DBPassword;

            dbconnStr = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;Connect Timeout=8;User ID={2};Password={3}", _DBServer, _DBName, _DBUsername, _DBPassword);
            cn = new SqlConnection(dbconnStr);
            GC.Collect();
        }
        #region main
        public bool DBConnectionTest()
        {
            UpdateConnectionString();
            using (SqlConnection cn2 = new SqlConnection(dbconnStr))
            {
                if (cn2.State == ConnectionState.Open)
                {
                    GC.Collect();
                    return true;
                }
                try
                {
                    cn2.Open();
                    GC.Collect();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERR datapro #52# {0}", e);
                }
            }
            GC.Collect();
            return false;
        }
        private SqlConnection DBconnect()
        {
            UpdateConnectionString();
            cn = new SqlConnection(dbconnStr);


            // if (cn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    GC.Collect();
                    cn.Open();
           trn = cn.BeginTransaction();
                }
                catch (Exception e) { Console.WriteLine("ERR datapro #70# {0}", e); return null; }


            }
            GC.Collect();
            return cn;
        }
        private void DBClose()
        {

            cn.Close();
            GC.Collect();
        }
        private bool DBQueryNonReturn(string sqlStr)
        {
            Console.WriteLine(sqlStr);
            bool tmp = false;
            try
            {
                SqlCommand comm = new SqlCommand();

                comm.Connection = DBconnect();
                comm.Transaction = trn;
                comm.CommandText = sqlStr;
                comm.ExecuteNonQuery();
                trn.Commit();

                DBClose();
                tmp = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERR datapro #97# {0}", e);
            }
            GC.Collect();
            return tmp;

        }
        private DataTable DBSelect(string selectStr)
        {
            Console.WriteLine(selectStr);
            SqlCommand comm = new SqlCommand();
            DataSet ds = new DataSet();

            //try
            {
                comm.Connection = DBconnect();
                comm.Transaction = trn;
                comm.CommandText = selectStr;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                if (cn.State == ConnectionState.Open)
                {
                    try
                    {
                        da.Fill(ds);
                        trn.Commit();
                    }
                    catch { }
                }
                else { return null; }
            }

            
            DBClose();
            GC.Collect();
            return ds.Tables[0];
        }
        #endregion

        public class TBAccounting : DBManage {
            public int New(accounting _account)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                //_account.accountingReceive = null;
                db.accountings.Add(_account);
              //  try
                {
                    db.SaveChanges(); GC.Collect();
                }
             //   catch (UpdateException)
                {
              //      GC.Collect();
              //      return -1;
                }
              //  catch (DbUpdateException) { return -1; }
                return _account.accountingID;
            }

            public int Update(accounting _account)
            {
                accounting acc;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    acc = (from a in db.accountings
                             where a.accountingID == _account.accountingID
                             select a).First();

             
                    acc.cancleProblemComment = _account.cancleProblemComment;
                    acc.numOfPerson = _account.numOfPerson;
                    acc.realNumOfPerson = _account.realNumOfPerson;

                    try
                    {
                        db.SaveChanges();
                        //db.save
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                }
                return acc.accountingID;
            }
        }
        public class TBsysParam : DBManage {
            public void ReadAll()
            {
                General gb = new General();
                
                using (var db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var param = from a in db.param_systemParam
                                select a;
                    foreach (var p in param)
                    {
                        switch (p.systemParamKey)
                        {
                            case "imgPath":
                                imgPath = p.systemParamValue;
                                break;
                            case "pricesMonthlyTicket":
                                pricesMonthlyTicket = Convert.ToDouble(p.systemParamValue);
                                break;
                            case "imgPathUser":
                                imgPathUser = p.systemParamValue;
                                break;
                            case "imgPathPasswd":
                                imgPathPasswd = p.systemParamValue;
                                break;
                            case "EnableAutoReprotChkIn" :
                                EnableAutoReprotChkIn = p.systemParamValue == "True";
                                break;
                            case "EnableAutoReprotChkOut" :
                                EnableAutoReprotChkOut = p.systemParamValue == "True";
                                break;
                            case "EnableAutoReportTicket":
                                EnableAutoReportTicket = p.systemParamValue == "True";
                                break;
                            case "EnableGateInSummaryPrintByCashier":
                                EnableGateInSummaryPrintByCashier   = p.systemParamValue == "True";
                                break;
                            case "EnableAntiPassback":
                                EnableAntiPassback = p.systemParamValue == "True";
                                break;
                            case "AcceptRegisterTicketOnly":
                                AcceptRegisterTicketOnly = p.systemParamValue == "True";
                                break;

                        }
                    }
                }
               
            }
            public void SaveParam(paramType prType)
            {
                using (var db = new Dpark3Entities())
                {
                    //var param;
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    switch (prType)  {
                        case paramType.imgPath: var param = db.param_systemParam.Single(c => c.systemParamKey == "imgPath");
                                                param.systemParamValue = imgPath;
                                                break;
                        case paramType.imgPathUser:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "imgPathUser");
                                                param.systemParamValue = imgPathUser;
                            
                                                break;
                        case paramType.imgPathPasswd :
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "imgPathPasswd");
                                                param.systemParamValue = imgPathPasswd;
                                                break;

                        case paramType.pricesMonthlyTicket:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "pricesMonthlyTicket");
                                                param.systemParamValue = pricesMonthlyTicket.ToString();
                                                break;
                        case paramType.EnableAutoReprotChkIn:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "EnableAutoReprotChkIn");
                                                param.systemParamValue = EnableAutoReprotChkIn.ToString();
                                              
                                                break;
                        case paramType.EnableAutoReprotChkOut:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "EnableAutoReprotChkOut");
                                                param.systemParamValue = EnableAutoReprotChkOut.ToString();
                                              
                                                break;

                        case paramType.EnableAutoReportTicket:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "EnableAutoReportTicket");
                                                param.systemParamValue = EnableAutoReportTicket.ToString();

                                                break;

                        case paramType.EnableGateInSummaryPrintByCashier:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "EnableGateInSummaryPrintByCashier");
                                                param.systemParamValue =EnableGateInSummaryPrintByCashier.ToString();

                                                break;
                        case paramType.EnableAntiPassback:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "EnableAntiPassback");
                                                param.systemParamValue =EnableAntiPassback.ToString();

                                                break;
                        case paramType.AcceptRegisterTicketOnly:
                                                param = db.param_systemParam.Single(c => c.systemParamKey == "AcceptRegisterTicketOnly");
                                                param.systemParamValue = AcceptRegisterTicketOnly.ToString();
                                                break;
     
                    }
                    db.SaveChanges(); 
                    GC.Collect();
                }

            }

            public string imgPath {get; set;}
            public string imgPathUser { get; set; }
            public string imgPathPasswd { get; set; }
            public double pricesMonthlyTicket { get; set; }
            public bool EnableAutoReprotChkIn { get; set; }
            public bool EnableAutoReprotChkOut { get; set; }
            public bool EnableGateInSummaryPrintByCashier { get; set; }
            public bool EnableAntiPassback { get; set; }
            public bool AcceptRegisterTicketOnly { set; get; }
            public bool EnableAutoReportTicket { set; get; }

            public enum paramType  { 
                imgPath,
                imgPathUser,
                imgPathPasswd,
                pricesMonthlyTicket,
                EnableAutoReprotChkIn,
                EnableAutoReprotChkOut,
                EnableGateInSummaryPrintByCashier,
                EnableAntiPassback,
                AcceptRegisterTicketOnly,
                EnableAutoReportTicket
           }

         }
        public class TBownerCompany : DBManage {
            public int New(sysOwnerCompany _ownerCom)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                db.sysOwnerCompanies.Add(_ownerCom);
                try
                {
                    db.SaveChanges(); GC.Collect();
                }
                catch (UpdateException)
                {
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException) { return -1; }
                return _ownerCom.ownerCompanyID;
            }
            public int Update(sysOwnerCompany _ownerCom)
            {
                sysOwnerCompany owner;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    owner = (from a in db.sysOwnerCompanies
                                              where a.ownerCompanyCodeName == _ownerCom.ownerCompanyCodeName
                                              select a).First();

                    owner.ownerCompanyAddr = _ownerCom.ownerCompanyAddr;
                    owner.ownerCompanyActive = _ownerCom.ownerCompanyActive;
                    owner.ownerCompanyCodeName = _ownerCom.ownerCompanyCodeName;
                    owner.ownerCompanyEmail = _ownerCom.ownerCompanyEmail;
                    owner.ownerCompanyFax = _ownerCom.ownerCompanyFax;
                    owner.ownerCompanyTel = _ownerCom.ownerCompanyTel;
                    //owner.ownerCompanyID = _ow    nerCom.ownerCompanyID;
                    owner.ownerCompanyName = _ownerCom.ownerCompanyName;
                    try
                    {
                        db.SaveChanges();
                        //db.save
                        GC.Collect();
                    }
                   catch (UpdateException )
                    {
                        GC.Collect();
                       return -1;
                    }
                }
                return owner.ownerCompanyID;
            }
        }
        public class TBparkingArea : DBManage
        {
            public int New(parkingArea _pArea)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                db.parkingAreas.Add(_pArea);
                try
                {
                    db.SaveChanges(); GC.Collect();
                }
                catch (UpdateException)
                {
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException) { return -1; }
                return _pArea.parkingAreaID;
            }
            public int Update(parkingArea _pArea)
            {
                parkingArea pArea;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    pArea = (from a in db.parkingAreas
                             where a.parkingAreaID == _pArea.parkingAreaID
                             select a).First();
                    pArea.OnwerCompanyID = _pArea.OnwerCompanyID;
                    pArea.parkingAreaActive = _pArea.parkingAreaActive;
                    pArea.parkingAreaCloseTime = _pArea.parkingAreaCloseTime;
                    pArea.parkingAreaComment = _pArea.parkingAreaComment;
                    pArea.parkingAreaName = _pArea.parkingAreaName;
                    pArea.parkingAreaOpenTime = _pArea.parkingAreaOpenTime;
                    pArea.parkingAreaSlotAvaliable = _pArea.parkingAreaSlotAvaliable;
                    try
                    {
                        db.SaveChanges(); GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                }
                return pArea.parkingAreaID;
            }
            
            public view_parkingAreaInfo getParkingAreaInfoByGate(int gateID)
            { view_parkingAreaInfo parkInfo = new view_parkingAreaInfo();
                try
                {
                    using (Dpark3Entities db = new Dpark3Entities())
                    {
                        db.Database.Connection.ConnectionString = gb.GetConnectionString();
                        var ps = (from a in db.view_parkingAreaInfo
                                  from b in db.sysGates
                                  where ((a.parkingAreaID == b.parkingAreaID) && (b.gateID == gateID))
                                  select a);
                        if (ps.Count() > 0)
                        {
                            parkInfo.parkingAreaID = ps.First().parkingAreaID;
                            parkInfo.parkingAreaName = ps.First().parkingAreaName;
                            parkInfo.parkingAreaSlotAvaliable = ps.First().parkingAreaSlotAvaliable;
                            parkInfo.parkingAreaSlotRemain = ps.First().parkingAreaSlotRemain;
                            parkInfo.count = ps.First().count;
                        }
                        else
                        {
                            GC.Collect();
                            return null;
                        }
                    } GC.Collect();
                    
                }
                catch { }
                return parkInfo;
            }
            public view_parkingAreaInfo getParkingAreaInfoByParkID(int parkingID)
            {
                view_parkingAreaInfo parkInfo = new view_parkingAreaInfo();
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.view_parkingAreaInfo
                              where a.parkingAreaID == parkingID
                              select a);
                    if (ps.Count() > 0)
                    {
                        parkInfo.parkingAreaID = ps.First().parkingAreaID;
                        parkInfo.parkingAreaName = ps.First().parkingAreaName;
                        parkInfo.parkingAreaSlotAvaliable = ps.First().parkingAreaSlotAvaliable;
                        parkInfo.parkingAreaSlotRemain = ps.First().parkingAreaSlotRemain;
                    }
                    else
                    {
                        GC.Collect();
                        return null;
                    }

                } GC.Collect();
                return parkInfo;
            }
            public List<view_parkingAreaInfo> getParkingAreaInfo()
            {
                view_parkingAreaInfo parkInfo = new view_parkingAreaInfo();
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.view_parkingAreaInfo
                              select a);
                    if (ps.Count() > 0)
                    {
                        GC.Collect();
                        return ps.ToList();
                    }
                    else
                    {
                        GC.Collect();
                        return null;
                    }

                }
            }
        }
        public class TBpriceProfileHour : DBManage
            {
            public int New(tran_priceProfileHour _priceHour)
            { return 0; }
            public int Del(tran_priceProfileHour _priceHour)
            { return 0; }
                public int Update(tran_priceProfileHour _priceHour)
                {
                    tran_priceProfileHour priceHour;
                    using (Dpark3Entities db = new Dpark3Entities())
                    {
                        db.Database.Connection.ConnectionString = gb.GetConnectionString();
                        priceHour = (from a in db.tran_priceProfileHour
                                     where a.priceProfileHourID == _priceHour.priceProfileHourID
                                    select a).First();
                        priceHour.priceProfileHourRate = _priceHour.priceProfileHourRate;
                        try
                        {
                            db.SaveChanges();
                            GC.Collect();
                        }
                        catch (UpdateException)
                        {
                            return -1;
                        }
                    }
                    GC.Collect();
                    return priceHour.priceProfileHourID;
                }
            }
        public class TBTransaction : DBManage
        {

            public int ChangePricesProfile(int tranID,int newProfile,string comment) {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
                              where (a.transactionID == tranID)
                              select a).First();
                    int oldProfile = (int)ps.priceProfileID;
                    ps.priceProfileID = newProfile;
                    try
                    {
                        tran_priceProfileChangeLog pfl = new tran_priceProfileChangeLog();
                        pfl.priceProfileChangeLogDateTime = DateTime.Now;
                        pfl.priceProfileNewID =(int) ps.priceProfileID;
                        pfl.priceProfileOldID = oldProfile;
                        pfl.sysUserID = Globals.sysUserID;
                        pfl.transactionID = ps.transactionID;
                        pfl.priceProfileChangeLogComment = comment;
                        db.tran_priceProfileChangeLog.Add(pfl);
                        db.SaveChanges();
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                    return ps.transactionID;
                }
            }
            public int New(tran_transaction tran)
            {

                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    if (tran.ticketNumber == string.Empty)
                    {
                        tran.ticketNumber = "Emergency";
                        tran.transactionTypeID = (int)TypeOfTicket.Emergency;

                    }
                   db.tran_transaction.Add(tran);
                   // try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                  //  catch (UpdateException)
                    {
                  //      return -1;
                    }
                    return tran.transactionID;
                }
            }
            public class TransSactionInfo
            {
                public int transactionID { get; set; }
                public int transactionTypeID { get; set; }
                public DateTime transactionChkIn { get; set; }
                public DateTime transactionChkOut { get; set; }
                public int sysUserID_ChkIn{ get; set; }
                public int sysUserID_ChkOut{ get; set; }
                public int gateID_IN{ get; set; }
                public int gateID_OUT{ get; set; }
                public string ticketNumber{ get; set; }
                public string carPlateNumber{ get; set; }
                public string carPlateCity{ get; set; }
                public int priceProfileID { get; set; }
                public string priceProfileName { get; set; }
                public DateTime transactionLastUpdate{ get; set; }
                public int accountingID{ get; set; }
                public string transactionComment { get; set; }
                public string parkingTime { get; set; }

            }
            public List<tran_transaction> getTransactionInfo()
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
 
                              select a);
                    if (ps.Count() > 0)
                    {
                        GC.Collect();
                        return ps.ToList();
                    }

                 }
                GC.Collect();
                return null;
            }
            public List<tran_transaction> getTransactionInParkInfo() {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
                              where (a.transactionChkOut == null) 
                              select  a);
                    if (ps.Count() > 0)
                    {
                        GC.Collect();
                        return ps.ToList();
                    }
                    else
                    {
                        GC.Collect();
                        return null;
                    }

                }
            }
            public TransSactionInfo getTransactionInParkInfo(string ticketNumber)
            {
                TransSactionInfo tranInfo = new TransSactionInfo();
                using (Dpark3Entities db = new Dpark3Entities())
                {

                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
                              from b in db.tran_priceProfile
                              where (a.transactionChkOut == null) &&  (a.ticketNumber == ticketNumber)&& (a.priceProfileID == b.priceProfileID)
                              select new { a, b });
                    if (ps.Count() > 0)
                    {
                            tranInfo.transactionID = ps.First().a.transactionID;
                            tranInfo.parkingTime = ps.First().a.transactionParkingTime;
                            //tranInfo.transactionTypeID = ps.First().a.transactionTypeID;
                            tranInfo.transactionChkIn = ps.First().a.transactionChkIn;
                            if (ps.First().a.transactionChkOut != null)
                            {
                                tranInfo.transactionChkOut = (DateTime)ps.First().a.transactionChkOut;
                            }
                            tranInfo.sysUserID_ChkIn = ps.First().a.sysUserID_ChkIn;
                            if (ps.First().a.sysUserID_ChkOut != null)
                            {
                                tranInfo.sysUserID_ChkOut = (int)ps.First().a.sysUserID_ChkOut;
                             }
                            //tranInfo.gateID_IN = ps.First().a.gateID_IN;
                            if (ps.First().a.gateID_OUT != null)
                            {
                                tranInfo.gateID_OUT = (int)ps.First().a.gateID_OUT;
                            }

                            tranInfo.ticketNumber = ps.First().a.ticketNumber;
                            tranInfo.carPlateNumber = ps.First().a.carPlateNumber.ToString();
                            tranInfo.carPlateCity = ps.First().a.carPlateCity.ToString();
                            if (ps.First().a.priceProfileID != null)
                            {
                                tranInfo.priceProfileID = (int)ps.First().a.priceProfileID;
                                tranInfo.priceProfileName = ps.First().b.priceProfileName;
                            }

                            //tranInfo.transactionLastUpdate = ps.First().a.transactionLastUpdate;
                            if (ps.First().a.accountingID != null) { tranInfo.accountingID = (int)ps.First().a.accountingID; }

                            tranInfo.transactionComment = ps.First().a.transactionComment;
                    }
                    else
                    {
                        return null;
                    }

                }
                GC.Collect();
                return tranInfo;
            }
            public TransSactionInfo getTransactionPriceProfileInfo(string ticketNumber)
            {
                TransSactionInfo tranInfo = new TransSactionInfo();
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
                              from b in db.tran_priceProfile
                              from c in db.tickets
                              where ((a.ticketNumber == ticketNumber) && 
                              (a.priceProfileID == b.priceProfileID) )
                              
                              select new { a, b });
                    if (ps.Count() > 0)
                    {
                        if (ps.First().a.priceProfileID != null) {
                            tranInfo.priceProfileID =Convert.ToInt16( ps.First().a.priceProfileID);
                        }
                        
                        tranInfo.priceProfileName = ps.First().b.priceProfileName;
                        tranInfo.transactionID = ps.First().a.transactionID;
                        tranInfo.transactionChkIn = ps.First().a.transactionChkIn;
                        if (ps.First().a.transactionChkOut != null) {tranInfo.transactionChkOut =(DateTime) ps.First().a.transactionChkOut; }
                        
                    }
                    else
                    {
                        GC.Collect();
                        return null;
                    }

                }
                GC.Collect();
                return tranInfo;
            }
            public bool IsInParking(string ticketNumber)
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = (from a in db.tran_transaction
                              where ((a.ticketNumber == ticketNumber) && (a.transactionChkOut == null))
                              select a);
                    if(ps.Count() >0)
                    {
                        return true;
                    }else{
                        return false;
                    }

                }
            }
            public int Update(tran_transaction tran)
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    if (tran.ticketNumber == string.Empty)
                    {
                        tran.ticketNumber = "Emergency";
                        tran.transactionTypeID = (int)TypeOfTicket.Emergency;

                    }

                    var ps = (from a in db.tran_transaction
                              where a.transactionID == tran.transactionID 
                              select a).First();
                    if (string.IsNullOrEmpty(tran.transactionComment))
                    {
                        ps.transactionComment = tran.transactionComment;
                    }
                    if (tran.transactionChkOut != null)
                    {
                        ps.transactionChkOut = tran.transactionChkOut;
                    }
                    if (tran.sysUserID_ChkOut != null)
                    {
                        ps.sysUserID_ChkOut = tran.sysUserID_ChkOut;
                    }
                    if (tran.gateID_OUT != null)
                    {
                        ps.gateID_OUT = tran.gateID_OUT;
                    }
                    try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        MessageBox.Show("ERR DBMangage 616");
                        return -1;
                    }
                    GC.Collect();
                    return ps.transactionID;
                }
            }
            public void ChkOutForce(int[] tranID) {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    foreach (int a in tranID) {
                        Console.WriteLine(a.ToString());
                    }
                    var ps = (from a in db.tran_transaction
                              where (a.transactionChkOut == null) && (tranID.Contains(a.transactionID))
                              select a).ToList();

                    DateTime dt = DateTime.Now;

                    ps.ForEach(i => { i.gateID_OUT = 0; i.transactionChkOut = dt; i.sysUserID_ChkOut = Globals.sysUserID; });
                    db.SaveChanges();
                    GC.Collect();
                }
            }
           
            public int ChkOut(tran_transaction tran)
            {
                using (Dpark3Entities db = new Dpark3Entities())
                { db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = (from a in db.tran_transaction
                          where (a.transactionChkOut == null) && (a.transactionID == tran.transactionID || a.ticketNumber == tran.ticketNumber)
                          select a).First();
                    
                    ps.transactionComment = tran.transactionComment;
                    ps.accountingID = tran.accountingID;
                    ps.transactionChkOut = tran.transactionChkOut;
                    ps.sysUserID_ChkOut = tran.sysUserID_ChkOut;
                    ps.gateID_OUT = tran.gateID_OUT;
                     try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        MessageBox.Show("ERR DBMangage 641");
                        GC.Collect();
                        return -1;
                    }

                    return ps.transactionID;
                }
            }
        }
        public class viewPriceProfile : DBManage
        {

            public int Update(view_priceProfile _priceProfile)
            {
               
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var priceProfile = (from a in db.tran_priceProfile
                                        where a.priceProfileID == _priceProfile.priceProfileID
                                        select a).FirstOrDefault();
                    priceProfile.priceProfileName = _priceProfile.priceProfileName;
                    priceProfile.priceProfileFlooringMode = _priceProfile.priceProfileFlooringMode;
                    priceProfile.priceProfileLostCardFee = _priceProfile.priceProfileLostCardFee;
                    priceProfile.priceProfileOverNightFee = _priceProfile.priceProfileOverNightFee;
                    priceProfile.priceProfileDiscountInCashier = (bool)_priceProfile.priceProfileDiscountInCashier;
                    priceProfile.priceProfileColor =(int) _priceProfile.priceProfileColor;
                    priceProfile.priceProfileFlooringOffset = (int)_priceProfile.priceProfileFlooringOffset;

                    try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                    catch (UpdateException) 
                    {
                        GC.Collect();
                        return -1;
                    }
                    var priceProfileDay = (from a in db.tran_priceProfileDay
                                        where a.priceProfileDayID== _priceProfile.priceProfileDayID
                                        select a).FirstOrDefault();
                        priceProfileDay.priceProfileDayFreeTime = _priceProfile.priceProfileDayFreeTime;
                        priceProfileDay.priceProfileDayServiceCharge = _priceProfile.priceProfileDayServiceCharge;

                    try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
               
                return priceProfile.priceProfileID; 
                }
            }
            public List<view_priceProfile> getPriceProfileTodayByID(int priceProfileID)
            {
                view_priceProfile pProfile = new view_priceProfile();
                /// tkInfo = new TicketInfo(); ;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    int DayOfWeek = 1+(int)DateTime.Now.DayOfWeek;


                    var pf = (from a in db.view_priceProfile
                              where ((a.priceProfileID == priceProfileID) && (a.priceProfileDayNumOfDay == DayOfWeek))
                              select a).ToList();
                    GC.Collect();
                    return pf;
                }    
            }
            
        }
        public class TBpriceProfile: DBManage
        {
            public int New(tran_priceProfile _pf)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                tran_priceProfile pf = _pf;
                db.tran_priceProfile.Add(pf);
            //    try
                {
                    db.SaveChanges();
                    GC.Collect();
                }
             //   catch (UpdateException e1)
                {
             //       Console.WriteLine(e1.ToString());
             //       return -1;
                }
             //   catch (DbUpdateException e2) { Console.WriteLine(e2.ToString()); return -1; }
                return pf.priceProfileID;
            }
            public int Del(tran_priceProfile _price)
            { return 0; }

            public List<tran_priceProfile> getDisCountProfile()
            {
           
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = from a in db.tran_priceProfile
                         where a.priceProfileTypeID == 2

                         select a;
  
                GC.Collect();
                return ps.OrderBy(i=>i.priceProfileName).ToList();
            }
        }
        public class TBpriceDialy : DBManage {
            public int Update(tran_priceDialy _priceDay)
            {
                tran_priceDialy priceDay;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    priceDay = (from a in db.tran_priceDialy
                                where a.priceDialyID == _priceDay.priceDialyID
                                select a).First();
                    priceDay.priceDialyRate = _priceDay.priceDialyRate;
                    try
                    {
                        db.SaveChanges();
                        //db.save
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                }
                return priceDay.priceDialyID;
            }
        }
        public class TBpriceProfileDay : DBManage
        {
            public int New(tran_priceProfileDay _pfDay)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                tran_priceProfileDay pfDay = _pfDay;
                db.tran_priceProfileDay.Add(pfDay);
                try
                {
                    db.SaveChanges();
                }
                catch (UpdateException e1)
                {
                    Console.WriteLine(e1.ToString());
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException e2) { Console.WriteLine(e2.ToString()); return -1; }
                GC.Collect();
                return pfDay.priceProfileDayID;
            }
            public int Del(tran_priceDialy _priceDay)
            { return 0; }
 
        }
        public class TBvisitorType : DBManage
        {
            public int New(ticketMemberType _vstType)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                ticketMemberType vstType = _vstType;
                db.ticketMemberTypes.Add(vstType);

                try
                {
                    db.SaveChanges();
                    GC.Collect();
                }
                catch (UpdateException e1)
                {
                    Console.WriteLine(e1.ToString());
                    return -1;
                }
                catch (DbUpdateException e2) { Console.WriteLine(e2.ToString());
                GC.Collect(); 
                    return -1;
                }
             
                return _vstType.ticketMemberTypeID;

            }

            public int Update(ticketMemberType _vstType)
            {
                ticketMemberType vstType;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    vstType = (from a in db.ticketMemberTypes
                               where a.ticketMemberTypeID == _vstType.ticketMemberTypeID
                               select a).First();

                    vstType.ticketMemberTypeActive= _vstType.ticketMemberTypeActive;
                    vstType.ticketMemberTypeComment = _vstType.ticketMemberTypeComment;
                    vstType.ticketMemberTypeName = _vstType.ticketMemberTypeName;
                
                    try
                    {
                        db.SaveChanges();
                        //db.save
                        GC.Collect();
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                }
                 GC.Collect();
                return vstType.ticketMemberTypeID;
            }

        }
        public class TBCar : DBManage
        {
            public int New(car _car)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                car mCar = _car;
                db.cars.Add(mCar);
                try
                {
                    db.SaveChanges();
                    GC.Collect();
                }
                catch (UpdateException e1)
                {
                    Console.WriteLine(e1.ToString());
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException e2)
                {
                    Console.WriteLine(e2.ToString());
                    GC.Collect();
                    return -1;
                }
                GC.Collect();
                return mCar.carID;

            }
            public int Update(car _car)
            {
                car mCar;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    mCar = (from a in db.cars
                          where a.carID == _car.carID
                          select a).First();
                    mCar.carBrandID = _car.carBrandID;
                    mCar.carColor = _car.carColor;
                    mCar.carID = _car.carID;
                    mCar.carModel = _car.carModel;
                    mCar.carPlateNumber = _car.carPlateNumber;
                    mCar.carTypeID = _car.carTypeID;
                    mCar.ProvinceID = _car.ProvinceID;
                    // try
                    {
                        db.SaveChanges();
                        GC.Collect();
                    }
                    //catch (UpdateException)
                    {
                        //  GC.Collect();
                        //return -1;
                    }
                }
                return mCar.carID;
            }
        }
        public class TBticket : DBManage
        {
           public int New(ticket _tk)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                ticket tk = _tk;
                db.tickets.Add(tk);
                try
                {
                    db.SaveChanges();
                    GC.Collect();
                }
                catch (UpdateException e1)
                {
                    Console.WriteLine(e1.ToString());
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException e2) { Console.WriteLine(e2.ToString());
                GC.Collect(); 
                    return -1;
                }
                GC.Collect();
                return tk.ticketID;

            }
            public int Update(ticket _tk)
            {
                ticket tk;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    tk = (from a in db.tickets
                                where a.ticketID == _tk.ticketID
                                select a).First();

                        tk.ticketNumber = _tk.ticketNumber ;
                        tk.ticketTypeID = _tk.ticketTypeID;
                        tk.ticketMemberID = _tk.ticketMemberID;
                        tk.ticketStartDate = _tk.ticketStartDate;
                        tk.ticketExpiryDate = _tk.ticketExpiryDate;
                        tk.ticketActive = _tk.ticketActive;
                        tk.ticketMemberID = _tk.ticketMemberID;
                        tk.carID = _tk.carID;
                        tk.userID_Create = _tk.userID_Create;
                  // try
                    {
                        db.SaveChanges();
                        //db.save
                        GC.Collect();
                    }
                    //catch (UpdateException)
                    {
                      //  GC.Collect();
                        //return -1;
                    }
                }
                return tk.ticketID;
            }
        
            public view_ticketInfo getTicketInfo(string ticketNumber)
            {
                view_ticketInfo tkInfo = new view_ticketInfo(); ;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var tk = (from a in db.view_ticketInfo
                              where a.ticketNumber == ticketNumber
                             select a);
                    
                    if (tk.Count() == 0)
                    {
                        tkInfo.ticketTypeName = "Visitor";
                        tkInfo.ticketID = -1;
                        GC.Collect();
                        return tkInfo;
                    }
                    tkInfo = tk.First();
                    return tkInfo;
                }    
            }
            public void RemoveCarID(int carID)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var tks = (from a in db.tickets
                           where a.carID == carID
                           select a).ToList();
                foreach (var tk in tks) {
                    tk.carID = null;
                }
                db.SaveChanges();
                GC.Collect();
            }

            public void RemoveMemberID(int ticketMemberID)
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var tks = (from a in db.tickets
                           where a.ticketMemberID == ticketMemberID
                           select a).ToList();
                foreach (var tk in tks)
                {
                    tk.ticketMemberID = null;
                }
                db.SaveChanges();
                GC.Collect();
            }

        }
        public class TBticketMember : DBManage
        {
            public int Del(int ticketMemberTypeID) {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                   

                    ticketMemberType vstType = (from a in db.ticketMemberTypes
                                                where a.ticketMemberTypeID == ticketMemberTypeID
                                                select a).Single();

                    db.ticketMemberTypes.Remove(vstType);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    { MessageBox.Show("กรุณาตรวจสอบอีกครั้ง ข้อมูลอาจสัมพันธ์ กับการบันทึกอื่นๆ", "ไม่ลบข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                       
                    }
                }
                return 1;
            }
            public int New(ticketMember _tkMember)
            {
                Dpark3Entities db = new Dpark3Entities();
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    ticketMember tkMember = _tkMember;
                    db.ticketMembers.Add(tkMember);
                     try {

                        db.SaveChanges();
                        GC.Collect();
                     }
                     catch (UpdateException e1)
                      {
                         Console.WriteLine(e1.ToString());
                         return -1;
                     }
                     catch (DbUpdateException e2) { Console.WriteLine(e2.ToString()); return -1; }
              
                GC.Collect();
                return tkMember.ticketMemberID;

            }
           public int Update(ticketMember _tkMember)
            {
                ticketMember tkMember;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    tkMember = (from a in db.ticketMembers
                               where a.ticketMemberID == _tkMember.ticketMemberID
                               select a).First();

                    tkMember.ticketMemberName = _tkMember.ticketMemberName;
                    tkMember.ticketMemberTel = _tkMember.ticketMemberTel;
                    tkMember.ticketMemberAddr = _tkMember.ticketMemberAddr;
                    tkMember.ticketMemberEmail = _tkMember.ticketMemberEmail;
                    tkMember.ticketMemberTypeID = _tkMember.ticketMemberTypeID;
                    try
                    {
                        db.SaveChanges();
                        GC.Collect();
                        //db.save
                    }
                    catch (UpdateException)
                    {
                        GC.Collect();
                        return -1;
                    }
                }
           
                return tkMember.ticketMemberID;
            }

         }
        public class TBsysUser : DBManage
        {
            public int New(sysUser _sysUser )
            {
                Dpark3Entities db = new Dpark3Entities();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                sysUser sysUser = _sysUser;
                db.sysUsers.Add(sysUser);

                try
                {
                    db.SaveChanges();
                    GC.Collect();
                }
                catch (UpdateException)
                {
                    GC.Collect();
                    return -1;
                }
                catch (DbUpdateException) { return -1; }
                catch { }
                GC.Collect();
                return sysUser.sysUserID;

            }
            public int Update(sysUser _sysUser)
            {
                sysUser sysUser;
                    using (Dpark3Entities db = new Dpark3Entities())
                    {
                        db.Database.Connection.ConnectionString = gb.GetConnectionString();
                        sysUser = (from a in db.sysUsers
                                   where a.sysUserID == _sysUser.sysUserID
                                 select a).First();

                             sysUser.OwnerCompanyID = _sysUser.OwnerCompanyID;
                             sysUser.sysUserActive = _sysUser.sysUserActive;
                             sysUser.sysUserLoginName = _sysUser.sysUserLoginName;
                             sysUser.sysUserPassword = _sysUser.sysUserPassword;
                             sysUser.sysUserName = _sysUser.sysUserName;
                             sysUser.sysUserTel = _sysUser.sysUserTel;
                             sysUser.sysUserPhone = _sysUser.sysUserPhone;
                             sysUser.sysUserEmail = _sysUser.sysUserEmail;
                             sysUser.sysUserAddr = _sysUser.sysUserAddr;
                             sysUser.sysUserExpiryDate = _sysUser.sysUserExpiryDate;

                        try
                        {
                            db.SaveChanges();
                            GC.Collect();
                            //db.save
                        }
                        catch (UpdateException)
                        {
                            return -1;
                        }
                    }
                    GC.Collect();
                    return sysUser.sysUserID;
                }
            public int LogIn(string username, string password)
            {

                Cursor.Current = Cursors.WaitCursor;
                //   try
                {
                    using (Dpark3Entities db = new Dpark3Entities())
                    {
                        // try
                        {
                            db.Database.Connection.ConnectionString = gb.GetConnectionString();
                            try
                            {
                                var sysUser = (from a in db.sysUsers
                                               where (a.sysUserLoginName == username) && (a.sysUserActive == true) && (a.sysUserPassword == password)
                                               select a);

                                if (sysUser.ToList().Count == 0) { return -1; }
                                var _sysUserLog = new sysUserLog();

                                _sysUserLog.sysUserLogType = "LOGIN";
                                _sysUserLog.sysUserLogTime = DateTime.Now;
                                _sysUserLog.sysUserLogMachineName = Environment.MachineName;
                                _sysUserLog.sysUserID = sysUser.FirstOrDefault().sysUserID;
                                db.sysUserLogs.Add(_sysUserLog);
                                db.SaveChanges();
                                Cursor.Current = Cursors.Default;
                                GC.Collect();
                                return sysUser.FirstOrDefault().sysUserID;

                            }
                             catch
                            {
                                MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return 0;
                            }
                        }
                    }
                    //  catch { }
                }
            }
            public void LogOut(int userID)
            {
                Cursor.Current = Cursors.WaitCursor;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    //   try
                    {
                        var sysUser = (from a in db.sysUsers
                                       where (a.sysUserID== userID)
                                       select a);
                        Cursor.Current = Cursors.Default;
                        var _sysUserLog = new sysUserLog();

                        _sysUserLog.sysUserLogType = "LOGOUT";
                        _sysUserLog.sysUserLogTime = DateTime.Now;
                        _sysUserLog.sysUserLogMachineName = Environment.MachineName;
                        _sysUserLog.sysUserID = sysUser.FirstOrDefault().sysUserID;
                        db.sysUserLogs.Add(_sysUserLog);
                        db.SaveChanges();
                        GC.Collect();
                    }
                    //   catch
                    {
                        //       MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            public void LogOut(string username)
            {
                Cursor.Current = Cursors.WaitCursor;
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    //   try
                    {
                        var sysUser = (from a in db.sysUsers
                                       where (a.sysUserLoginName == username) 
                                       select a);
                        Cursor.Current = Cursors.Default;
                         var _sysUserLog = new sysUserLog();

                        _sysUserLog.sysUserLogType = "LOGOUT";
                        _sysUserLog.sysUserLogTime = DateTime.Now;
                        _sysUserLog.sysUserLogMachineName = Environment.MachineName;
                        _sysUserLog.sysUserID = sysUser.FirstOrDefault().sysUserID;
                        db.sysUserLogs.Add(_sysUserLog);
                        db.SaveChanges();
                        GC.Collect();
                    }
                    //   catch
                    {
                        //       MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
           
            }

            public int Del(int[] sysUserID)
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();

                    var ps = (from a in db.sysUsers
                                  where (sysUserID.Contains(a.sysUserID))
                                  select a);
                   
                    try
                    {
                        db.sysUsers.Delete(ps);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("กรุณาตรวจสอบอีกครั้ง ข้อมูลอาจสัมพันธ์ กับการบันทึกอื่นๆ", "ไม่ลบข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;

                    }
                    db.SaveChanges();
                    GC.Collect();
                    return 1;
                }
            }
            public sysUser GetSysUserInfo(int sysUserID)
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var sysUsers = (from a in db.sysUsers
                                       where (a.sysUserID== sysUserID)
                                       select a).First();
                    GC.Collect();
                        return sysUsers;
                }
            }
        }
    }
}