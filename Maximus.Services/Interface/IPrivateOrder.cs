using Maximus.Data.models;
using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
   public interface IPrivateOrder 
    {
          AcceptResultSet AcceptOrder(string cmpId, bool IsManPack, string busId, List<SalesOrderHeaderViewModel> salesHeaderLst, List<BusAddress1> busAddress, string selectedcar, string UserName, double CARRPERCENT, double CARRREQAMT, string Browser, string REMOTE_ADDR, string cmpLogo, string custLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string ueMailEMail, string HTTP_X_FORWARDED_FOR, bool isedit, bool boolDeleteConfirm, string pnlCarriageReason, string pricePermission, UpdateMailModel updModel);
          List<PrivateOrderResultModel> ShowPrivateOrders(string access, string onlineuserId, string busId);
    }
}
