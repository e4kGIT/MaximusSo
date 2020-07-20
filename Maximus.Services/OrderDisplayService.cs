using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;

namespace Maximus.Services
{
    public class OrderDisplayService : IOrderDisplay
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly tblSalesOrderHeader _salesOrderHeader;
        public readonly tblSalesLines _salesOrderLines;
        public readonly tblManPackOrders _manPackOrders;
        public readonly tblCourrierRef _courrierRef;
        public readonly Employee _employee;
        public readonly PointsCard _pointsCard;
        public readonly ViewPointsCard _vuPointsCard;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointStyle _pointsStyle;
        public OrderDisplayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            tblSalesOrderHeader salesOrderHeader = new tblSalesOrderHeader(_unitOfWork);
            tblSalesLines salesOrderLines=new tblSalesLines(_unitOfWork);
            tblManPackOrders manPackOrders=new tblManPackOrders(_unitOfWork);
            tblCourrierRef courrierRef=new tblCourrierRef(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            ViewPointsCard vuPointsCard = new ViewPointsCard(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointStyle pointsStyle = new PointStyle(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            _salesOrderHeader = salesOrderHeader;
            _pointsStyle = pointsStyle;
            _salesOrderLines = salesOrderLines;
            _manPackOrders = manPackOrders;
            _courrierRef = courrierRef;
            _employee = employee;
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _vuPointsCard =vuPointsCard;
        }
        public List<OrderDisplayModel> GetAllOrders(string busId,string userId,List<string> usrs)
        {
            List<OrderDisplayModel> lst = new List<OrderDisplayModel>();
            DateTime endDate = DateTime.Now;
            DateTime startDate = DateTime.Now.AddMonths(-3);
           var soh= _salesOrderHeader.GetAll(s => s.CustID == busId  && usrs.Contains(s.OnlineUserID)).OrderByDescending(s=>s.OrderNo).ToList();
            foreach (var sod in soh)
            {
                var totalQty = _salesOrderLines.GetAll(s => s.OrderNo == sod.OrderNo && s.OriginalLineNo == 0).Sum(s => s.OrdQty);
                var manPackNo = _manPackOrders.Exists(s => s.OrderNo == sod.OrderNo) ? _manPackOrders.GetAll(s => s.OrderNo == sod.OrderNo).First().ManPackNo:0;
                var courrierRef = _courrierRef.Exists(s => s.OrderNo == sod.OrderNo)? _courrierRef.GetAll(s => s.OrderNo == sod.OrderNo).First().CourierRef:"";
                var firstDespatch = _courrierRef.Exists(s => s.OrderNo == sod.OrderNo) ? _courrierRef.GetAll(s => s.OrderNo == sod.OrderNo).First().DespatchDate   :   null;
                var empName = _employee.Exists(s => s.EmployeeID == sod.PinNo) ? _employee.GetAll(s => s.EmployeeID == sod.PinNo).First().Forename + " " + _employee.GetAll(s => s.EmployeeID == sod.PinNo).First().Surname : "";
                var totPoints = _pointsByUcode.Exists(s => s.UcodeID == sod.UCodeId) ? _pointsByUcode.GetAll(s => s.UcodeID == sod.UCodeId).First().TotalPoints : 0;
                var usedPoints = 0;
                usedPoints = GetOrderPoints(sod);
                var saledetail = _salesOrderLines.GetAll(s => s.OrderNo == sod.OrderNo).Select(s => new SalesOrderLineViewModel {StyleID=s.StyleID,ColourID=s.ColourID,SizeID=s.SizeID,OrdQty=s.OrdQty.Value }).ToList();
                lst.Add(new OrderDisplayModel { Address1 = sod.DelAddress1, CustomerRef = sod.CustRef, DelDesc = sod.DelDesc, EmpID = sod.PinNo, UserId = sod.OnlineUserID, FirstDespatch = firstDespatch, CourrierRef = courrierRef, IsConfirmed = Convert.ToBoolean(sod.OnlineConfirm)?"YES":"NO", IsProcessed = Convert.ToBoolean(sod.OnlineProcessed) ? "YES" : "NO", NominalCode = sod.OrderAnalysisCode1, OrderDate = sod.OrderDate.Value, OrderNo = sod.OrderNo, PersonPackNo = manPackNo, TotalQty = totalQty.Value, EmpName = empName,PointsSpent= usedPoints,TotalPoints=totPoints.Value,GoodsValue= sod.OrderGoods.Value,TotalIncVat=sod.TotalGoods.Value,saleDetail= saledetail });
            }
            return lst;
        }
    public int GetOrderPoints(tblsop_salesorder_header saleHed)
        {
            int points = 0;
           var lines= _salesOrderLines.GetAll(s => s.OrderNo == saleHed.OrderNo).ToList();
            foreach(var line in lines)
            {
                 
               int ss = _pointsStyle.GetAll(s => s.UcodeID == saleHed.UCodeId && s.StyleID == line.StyleID).First().Points.Value * Convert.ToInt32(line.OrdQty);
                points = points + ss;
            }
            return points;
        }
    }
}
