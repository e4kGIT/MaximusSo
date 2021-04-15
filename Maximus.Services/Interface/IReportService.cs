using Maximus.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
    public interface  IReportService
    {
        List<OrderDisplayModel> GetAllOrderRPT(string empId, string busId, string cardType, bool pointsReq);
        List<string> GetAllRollouts(string busId);
        List<CardByStyle> GetOrderLinesBystyle(string styleid, string empid,string CardType);
        List<CardReportModel> GetExporterData(string CardType, string access, string userid);
        List<CardReportModel> GetCardReport(string busId, string userID, string access);
        List<CardReportModel> GetdetailCard(string empId, string busId,string cardType,bool pointsReq);
        List<RolloutReportModel> GetRolloutReport(string busId, List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false);
    }
}
