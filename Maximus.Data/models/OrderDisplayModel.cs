using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
  public class OrderDisplayModel
    {
        public long OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int RtnOrdNo { get; set; }
        public string OrderType { get; set; }
        public string CustomerRef { get; set; }
        public string NominalCode { get; set; }
        public string Address1 { get; set; }
        public string DelDesc { get; set; }
        public double TotalIncVat{ get; set; }
        public double GoodsValue { get; set; }
        public long TotalQty { get; set; }
        public string UserId { get; set; }
        public string  EmpID { get; set; }
        public string EmpName { get; set; }
        public string IsConfirmed { get; set; }
        public string IsProcessed { get; set; }
        public long PersonPackNo { get; set; }
        public string CourrierRef { get; set; }
        public string FirstDespatch { get; set; }
        public int PointsSpent { get; set; }
        public int TotalPoints { get; set; }
        public int Points { get; set; }
        public int DeliveryWeek { get; set; }
        public string DeliveryDay { get; set; }
        public string EmergencyReason { get; set; }
        public string UCODEID { get; set; }
        public bool RtnCredited { get; set; }
        public bool ShowRtnCredited { get; set; }
        public List<SalesOrderLineViewModel> saleDetail{ get; set; }
}
}
