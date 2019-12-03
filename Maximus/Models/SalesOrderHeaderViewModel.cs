using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class SalesOrderHeaderViewModel
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
     
        public string Comments { get; set; }
        public string CompanyID { get; set; }
        public string WarehouseID { get; set; }
        public long OrderNo { get; set; }
        public string CustID { get; set; }
        public string OrderDate { get; set; }
        public string InvDesc { get; set; }
        public string InvAddress1 { get; set; }
        public string InvAddress2 { get; set; }
        public string InvAddress3 { get; set; }
        public string InvCity { get; set; }
        public string InvTown { get; set; }
        public string InvPostCode { get; set; }
        public string InvCountry { get; set; }
        public string DelDesc { get; set; }
        public string DelAddress1 { get; set; }
        public int AddressId { get; set; }
        public string DelAddress2 { get; set; }
        public string DelAddress3 { get; set; }
        public string DelCity { get; set; }
        public string DelTown { get; set; }
        public string DelPostCode { get; set; }
        public string DelCountry { get; set; }
        public string CustRef { get; set; }
        public string ContractRef { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string Carrier { get; set; }
        public Nullable<double> CarrierCharge { get; set; }
        public Nullable<double> CustDisc { get; set; }
        public Nullable<double> SettDisc { get; set; }
        public Nullable<double> VolDisc { get; set; }
        public Nullable<int> SettlementDays { get; set; }
        public Nullable<byte> OrderConfirm { get; set; }
        public string CommentsExternal { get; set; }
        public string NomCode { get; set; }
        public string NomCode1 { get; set; }
        public string NomCode2 { get; set; }
        public string NomCode3 { get; set; }
        public string NomCode4 { get; set; }
        public Nullable<sbyte> Cancelled { get; set; }
        public Nullable<sbyte> ProForma { get; set; }
        public Nullable<sbyte> Completed { get; set; }
        public Nullable<double> WorksOrderNo { get; set; }
        public Nullable<sbyte> AllowPartShipment { get; set; }
        public Nullable<double> TotalGoods { get; set; }
        public Nullable<double> Net { get; set; }
         
        public Nullable<double> OrderGoods { get; set; }
        public string UserID { get; set; }
        public Nullable<sbyte> pRINTINVOICE { get; set; }
        public Nullable<double> Currency_Exchange_Rate { get; set; }
        public string PinNo { get; set; }
        public string UCodeId { get; set; }
        public string ContractNo { get; set; }
        public string VatFlag { get; set; }
       public double VATPercent { get; set; }
        public string Currency_Exchange_Code { get; set; }
        public Nullable<System.TimeSpan> TIMEOFENTRY { get; set; }
        public Nullable<long> RepID { get; set; }
        public Nullable<long> RepNo { get; set; }
        public Nullable<sbyte> OnlineConfirm { get; set; }
        public Nullable<System.DateTime> OnlineConfirmDate { get; set; }
        public string OnlineConfirmedBy { get; set; }
        public Nullable<sbyte> OnlineProcessed { get; set; }
        public Nullable<System.DateTime> OnlineProcessedDate { get; set; }
        public string OnlineProcessedBy { get; set; }
        public Nullable<int> ReasonCode { get; set; }
        public string OnlineUserID { get; set; }
        public string OrderAnalysisCode1 { get; set; }
        public string OrderAnalysisCode2 { get; set; }
        public string OrderAnalysisCode3 { get; set; }
        public string OrderAnalysisCode4 { get; set; }
        public string OrderAnalysisCode5 { get; set; }
        public Nullable<sbyte> PrintLabel { get; set; }
        public Nullable<sbyte> ProFormaPrint { get; set; }
        public Nullable<sbyte> ConfirmPrint { get; set; }
        public string OrderType { get; set; }
        public string EmailID { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public int VatCode { get; set; }
        public int KAMid { get; set; }
        public List<SalesOrderLineViewModel> SalesOrderLine { get; set; }
    }
}