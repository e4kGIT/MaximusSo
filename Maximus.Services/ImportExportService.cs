using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.InterFace;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.Models;

namespace Maximus.Services
{
    public class ImportExportService : IImportExport
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly EmployeeRollout _empRollout;
        private readonly DataProcessing _dp;
        public ImportExportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            User user = new User(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            EmployeeRollout empRollout = new EmployeeRollout(_unitOfWork);
            _user = user;
            _dp = dp;
            _empRollout = empRollout;
        }
        public List<ImpExpUsers> GetAllUsers(string busId)
        {
            List<ImpExpUsers> usrLst = new List<ImpExpUsers>();
             
            try
            {
                usrLst= _dp.GetUserLst(busId);
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
            return usrLst;
        }
    }
}
