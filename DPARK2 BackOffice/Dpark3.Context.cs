﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Dpark3Entities : DbContext
    {
        public Dpark3Entities()
            : base("name=Dpark3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accounting> accountings { get; set; }
        public virtual DbSet<accountingType> accountingTypes { get; set; }
        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<car_carBrand> car_carBrand { get; set; }
        public virtual DbSet<car_carType> car_carType { get; set; }
        public virtual DbSet<DLSHour> DLSHours { get; set; }
        public virtual DbSet<param_blackListVehicle> param_blackListVehicle { get; set; }
        public virtual DbSet<param_holiday> param_holiday { get; set; }
        public virtual DbSet<param_province> param_province { get; set; }
        public virtual DbSet<param_systemLog> param_systemLog { get; set; }
        public virtual DbSet<param_systemParam> param_systemParam { get; set; }
        public virtual DbSet<parkingArea> parkingAreas { get; set; }
        public virtual DbSet<parkingArea_reservParking> parkingArea_reservParking { get; set; }
        public virtual DbSet<sys_gate_Match_reader> sys_gate_Match_reader { get; set; }
        public virtual DbSet<sys_permission> sys_permission { get; set; }
        public virtual DbSet<sys_sysUserType_permission> sys_sysUserType_permission { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<sysGate> sysGates { get; set; }
        public virtual DbSet<sysOwnerCompany> sysOwnerCompanies { get; set; }
        public virtual DbSet<sysReader> sysReaders { get; set; }
        public virtual DbSet<sysUser> sysUsers { get; set; }
        public virtual DbSet<sysUserLog> sysUserLogs { get; set; }
        public virtual DbSet<sysUserType> sysUserTypes { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<ticketMember> ticketMembers { get; set; }
        public virtual DbSet<ticketMemberType> ticketMemberTypes { get; set; }
        public virtual DbSet<ticketType> ticketTypes { get; set; }
        public virtual DbSet<tran_emergencyType> tran_emergencyType { get; set; }
        public virtual DbSet<tran_priceDialy> tran_priceDialy { get; set; }
        public virtual DbSet<tran_priceProfile> tran_priceProfile { get; set; }
        public virtual DbSet<tran_priceProfileChangeLog> tran_priceProfileChangeLog { get; set; }
        public virtual DbSet<tran_priceProfileDay> tran_priceProfileDay { get; set; }
        public virtual DbSet<tran_priceProfileHour> tran_priceProfileHour { get; set; }
        public virtual DbSet<tran_priceProfileType> tran_priceProfileType { get; set; }
        public virtual DbSet<tran_transaction> tran_transaction { get; set; }
        public virtual DbSet<tran_transaction2> tran_transaction2 { get; set; }
        public virtual DbSet<tran_transactionType> tran_transactionType { get; set; }
        public virtual DbSet<VMS_LOG> VMS_LOG { get; set; }
        public virtual DbSet<DLSCalendar> DLSCalendars { get; set; }
        public virtual DbSet<tran_priceMonthly> tran_priceMonthly { get; set; }
        public virtual DbSet<SumOfDateSery> SumOfDateSeries { get; set; }
        public virtual DbSet<tmpHourOnDateSery> tmpHourOnDateSeries { get; set; }
        public virtual DbSet<view_accessright> view_accessright { get; set; }
        public virtual DbSet<view_accounting_all> view_accounting_all { get; set; }
        public virtual DbSet<view_accountingWithNumPerson> view_accountingWithNumPerson { get; set; }
        public virtual DbSet<view_Emergency_ALL> view_Emergency_ALL { get; set; }
        public virtual DbSet<view_EStamp_log> view_EStamp_log { get; set; }
        public virtual DbSet<view_EStamp_log_DisTinc_transID> view_EStamp_log_DisTinc_transID { get; set; }
        public virtual DbSet<view_parkingAreaInfo> view_parkingAreaInfo { get; set; }
        public virtual DbSet<view_priceProfile> view_priceProfile { get; set; }
        public virtual DbSet<view_ticketInfo> view_ticketInfo { get; set; }
        public virtual DbSet<view_transaction_all> view_transaction_all { get; set; }
        public virtual DbSet<view_transaction_all_parkingTime> view_transaction_all_parkingTime { get; set; }
        public virtual DbSet<view_VMS_log_stayTime> view_VMS_log_stayTime { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<stProDate_Result> stProDate(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stProDate_Result>("stProDate", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<stProDateOnMonth_Result> stProDateOnMonth(Nullable<System.DateTime> startMonth, Nullable<System.DateTime> endMonth)
        {
            var startMonthParameter = startMonth.HasValue ?
                new ObjectParameter("startMonth", startMonth) :
                new ObjectParameter("startMonth", typeof(System.DateTime));
    
            var endMonthParameter = endMonth.HasValue ?
                new ObjectParameter("endMonth", endMonth) :
                new ObjectParameter("endMonth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stProDateOnMonth_Result>("stProDateOnMonth", startMonthParameter, endMonthParameter);
        }
    
        public virtual ObjectResult<stProHourOnDate_Result> stProHourOnDate(Nullable<System.DateTime> startDateTime, Nullable<System.DateTime> endDateTime)
        {
            var startDateTimeParameter = startDateTime.HasValue ?
                new ObjectParameter("startDateTime", startDateTime) :
                new ObjectParameter("startDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stProHourOnDate_Result>("stProHourOnDate", startDateTimeParameter, endDateTimeParameter);
        }
    
        public virtual ObjectResult<stProYear_Result> stProYear(Nullable<int> startYear, Nullable<int> endYear)
        {
            var startYearParameter = startYear.HasValue ?
                new ObjectParameter("startYear", startYear) :
                new ObjectParameter("startYear", typeof(int));
    
            var endYearParameter = endYear.HasValue ?
                new ObjectParameter("endYear", endYear) :
                new ObjectParameter("endYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stProYear_Result>("stProYear", startYearParameter, endYearParameter);
        }
    
        public virtual ObjectResult<tr_accounting_all_bydate_userID_accType_Result> tr_accounting_all_bydate_userID_accType(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, Nullable<int> accountingTypeID, Nullable<int> sysUserID)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var accountingTypeIDParameter = accountingTypeID.HasValue ?
                new ObjectParameter("accountingTypeID", accountingTypeID) :
                new ObjectParameter("accountingTypeID", typeof(int));
    
            var sysUserIDParameter = sysUserID.HasValue ?
                new ObjectParameter("sysUserID", sysUserID) :
                new ObjectParameter("sysUserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_accounting_all_bydate_userID_accType_Result>("tr_accounting_all_bydate_userID_accType", beginDateTimeParameter, endDateTimeParameter, accountingTypeIDParameter, sysUserIDParameter);
        }
    
        public virtual ObjectResult<tr_accounting_saleTicket_bydate_userID_accType_Result> tr_accounting_saleTicket_bydate_userID_accType(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, Nullable<int> sysUserID)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var sysUserIDParameter = sysUserID.HasValue ?
                new ObjectParameter("sysUserID", sysUserID) :
                new ObjectParameter("sysUserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_accounting_saleTicket_bydate_userID_accType_Result>("tr_accounting_saleTicket_bydate_userID_accType", beginDateTimeParameter, endDateTimeParameter, sysUserIDParameter);
        }
    
        public virtual ObjectResult<tr_accounting_with_numperson_Result> tr_accounting_with_numperson(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, Nullable<int> sysUserID)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var sysUserIDParameter = sysUserID.HasValue ?
                new ObjectParameter("sysUserID", sysUserID) :
                new ObjectParameter("sysUserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_accounting_with_numperson_Result>("tr_accounting_with_numperson", beginDateTimeParameter, endDateTimeParameter, sysUserIDParameter);
        }
    
        public virtual ObjectResult<tr_report_cashier_Result> tr_report_cashier(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, Nullable<int> userId)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_report_cashier_Result>("tr_report_cashier", beginDateTimeParameter, endDateTimeParameter, userIdParameter);
        }
    
        public virtual ObjectResult<tr_report_cashier_sum_Result> tr_report_cashier_sum(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, Nullable<int> userId)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_report_cashier_sum_Result>("tr_report_cashier_sum", beginDateTimeParameter, endDateTimeParameter, userIdParameter);
        }
    
        public virtual ObjectResult<tr_ticket_moreInfo_Result> tr_ticket_moreInfo(Nullable<int> ticketID)
        {
            var ticketIDParameter = ticketID.HasValue ?
                new ObjectParameter("ticketID", ticketID) :
                new ObjectParameter("ticketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_ticket_moreInfo_Result>("tr_ticket_moreInfo", ticketIDParameter);
        }
    
        public virtual ObjectResult<tr_ticket_paymentHistory_Result> tr_ticket_paymentHistory(Nullable<int> ticketID)
        {
            var ticketIDParameter = ticketID.HasValue ?
                new ObjectParameter("ticketID", ticketID) :
                new ObjectParameter("ticketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_ticket_paymentHistory_Result>("tr_ticket_paymentHistory", ticketIDParameter);
        }
    
        public virtual ObjectResult<tr_transaction_allTime_byCarPlateNumber_Result> tr_transaction_allTime_byCarPlateNumber(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, string carPlateNumber)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var carPlateNumberParameter = carPlateNumber != null ?
                new ObjectParameter("carPlateNumber", carPlateNumber) :
                new ObjectParameter("carPlateNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_allTime_byCarPlateNumber_Result>("tr_transaction_allTime_byCarPlateNumber", beginDateTimeParameter, endDateTimeParameter, carPlateNumberParameter);
        }
    
        public virtual ObjectResult<tr_transaction_allTime_bydate_Result> tr_transaction_allTime_bydate(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_allTime_bydate_Result>("tr_transaction_allTime_bydate", beginDateTimeParameter, endDateTimeParameter);
        }
    
        public virtual ObjectResult<tr_transaction_Emergency_Result> tr_transaction_Emergency(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_Emergency_Result>("tr_transaction_Emergency", beginDateTimeParameter, endDateTimeParameter);
        }
    
        public virtual ObjectResult<tr_transaction_ForceChkOut_byCarPlateNumber_Result> tr_transaction_ForceChkOut_byCarPlateNumber(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, string carPlateNumber)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var carPlateNumberParameter = carPlateNumber != null ?
                new ObjectParameter("carPlateNumber", carPlateNumber) :
                new ObjectParameter("carPlateNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_ForceChkOut_byCarPlateNumber_Result>("tr_transaction_ForceChkOut_byCarPlateNumber", beginDateTimeParameter, endDateTimeParameter, carPlateNumberParameter);
        }
    
        public virtual ObjectResult<tr_transaction_InParking_Result> tr_transaction_InParking(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_InParking_Result>("tr_transaction_InParking", beginDateTimeParameter, endDateTimeParameter);
        }
    
        public virtual ObjectResult<tr_transaction_InParking_byCarPlateNumber_Result> tr_transaction_InParking_byCarPlateNumber(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, string carPlateNumber)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var carPlateNumberParameter = carPlateNumber != null ?
                new ObjectParameter("carPlateNumber", carPlateNumber) :
                new ObjectParameter("carPlateNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_InParking_byCarPlateNumber_Result>("tr_transaction_InParking_byCarPlateNumber", beginDateTimeParameter, endDateTimeParameter, carPlateNumberParameter);
        }
    
        public virtual ObjectResult<tr_transaction_IsLostCard_byCarPlateNumber_Result> tr_transaction_IsLostCard_byCarPlateNumber(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, string carPlateNumber)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var carPlateNumberParameter = carPlateNumber != null ?
                new ObjectParameter("carPlateNumber", carPlateNumber) :
                new ObjectParameter("carPlateNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_IsLostCard_byCarPlateNumber_Result>("tr_transaction_IsLostCard_byCarPlateNumber", beginDateTimeParameter, endDateTimeParameter, carPlateNumberParameter);
        }
    
        public virtual ObjectResult<tr_transaction_moreInfo_Result> tr_transaction_moreInfo(Nullable<int> tranID)
        {
            var tranIDParameter = tranID.HasValue ?
                new ObjectParameter("tranID", tranID) :
                new ObjectParameter("tranID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_moreInfo_Result>("tr_transaction_moreInfo", tranIDParameter);
        }
    
        public virtual ObjectResult<tr_transaction_Stamp_Log_Result> tr_transaction_Stamp_Log(Nullable<System.DateTime> beginDateTime, Nullable<System.DateTime> endDateTime, string carPlateNumber, string ticketNumber)
        {
            var beginDateTimeParameter = beginDateTime.HasValue ?
                new ObjectParameter("beginDateTime", beginDateTime) :
                new ObjectParameter("beginDateTime", typeof(System.DateTime));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var carPlateNumberParameter = carPlateNumber != null ?
                new ObjectParameter("carPlateNumber", carPlateNumber) :
                new ObjectParameter("carPlateNumber", typeof(string));
    
            var ticketNumberParameter = ticketNumber != null ?
                new ObjectParameter("ticketNumber", ticketNumber) :
                new ObjectParameter("ticketNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tr_transaction_Stamp_Log_Result>("tr_transaction_Stamp_Log", beginDateTimeParameter, endDateTimeParameter, carPlateNumberParameter, ticketNumberParameter);
        }
    }
}
