using Maximus.Data.models;
using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
   public interface IReturn
    {
        List<ReturnOrderModel> GetOrderToReturn(string empId, string businessId, string userId, string OrderPermission, string role, bool pointsReq, List<string> catagory, int OrdNo = 0, string custRef = "", string courierRef = "", int pickingSlipNo = 0);
       AcceptResultSet AcceptReturns(string conString, List<SalesOrderHeaderViewModel> salesHead, string cmpId, double CARRPERCENT, string CARRPRICE_RTN, bool DELADDR_USER_CREATE, string OverrideEnt, string CARRPRICE_XCHG, string RTN_Collection_Style, string PriceList, string FITALLOC, string DIMALLOC, string rolloutName,string WAREHOUSE_RTN, string pnlCarriageReason, string selectedCarr, bool IsManPack, int empResetMnths, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, string usrId, bool editFlag, string POINTSREQ, string ONLCUSREFLBL, string cmpLogo, string custLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string ueMailEMail, string permissionPrice  , int collectionStatus = 0);
        bool DeleteReturnOrders(int orderno,string user);
    }
}
