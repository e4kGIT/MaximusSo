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
        List<string> GetAllRollouts(string busId);
        List<RolloutReportModel> GetRolloutReport(string busId, List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false);
    }
}
