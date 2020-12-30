using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;
using Maximus.Data.Models;

namespace Maximus.Services
{
   public class ReportService: IReportService
    {
      public readonly  IUnitOfWork _unitOfWork;
        public readonly RolloutNames _rolloutNames;
        public readonly DataProcessing _dp;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RolloutNames rolloutNames = new RolloutNames(_unitOfWork);
            DataProcessing dp=new DataProcessing(_unitOfWork);
            _rolloutNames = rolloutNames;
            _dp = dp;
        }

        public List<string> GetAllRollouts(string busId)
        {
            List<string> result = _rolloutNames.Exists(s => s.Businessid == busId && s.Companyid == "001" && s.IsClosed == 0) ? _rolloutNames.GetAll(s => s.Businessid == busId && s.Companyid == "001" && s.IsClosed == 0).Select(s=>s.Rollname).ToList() : new List<string>();
            return result;
        }

        public List<RolloutReportModel> GetRolloutReport(string busId, List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false)
        {
            List<RolloutReportModel> result = new List<RolloutReportModel>();
            result= _dp.GetRolloutReports(busId, selRollout, reportName, reportTypes, embro, uncnf, pointsREq);
            return result;
        }
    }
}
