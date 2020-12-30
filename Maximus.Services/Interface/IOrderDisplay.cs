using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;

namespace Maximus.Services.Interface
{
  public  interface IOrderDisplay
    {
        List<OrderDisplayModel> GetAllOrders(string OrderType,string busId,bool booPoints, string userId, List<string> usrs, string role, string orderPermission,bool isEmergencyOrder=false, bool booIsConfirm=false, bool isPrnt=false,string RequirePermissionUSR="");
        Boolean ConfirmOrders(List<SalesConfirmModel> orderLst, bool isManpack, string userId, string cmpLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string busId,bool isemergency);
        string GetPrintTemplate(int fromOrdNo, int toOrdNo, string cmpLogo, string custlogo, string userId, string pricePermission, string ONLCUSREFLBL);

          List<OrderDisplayDetail> GetOrderDetail(int orderno);

        //List<int> GetPrintRange(string busid,string userid,List<string> usrLst,string empid = "", string empname = "", string ucode = "", string ucodedesc = "", string address = "", Nullable<DateTime> startdate = null, int firstOrdNo = 0, int lastOrdNo = 0, Nullable<DateTime> frsOrdDate = null, Nullable<DateTime> lstOrdDate = null);
    }
}
