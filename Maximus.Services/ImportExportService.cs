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
using MySql.Data.MySqlClient;

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
                usrLst = _dp.GetUserLst(busId);
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
            return usrLst;
        }

        public List<AddressImportModel> GetAllAddress(string busid)
        {
            List<AddressImportModel> AddLSt = new List<AddressImportModel>();

            AddLSt = _dp.GetAddressLst(busid);

            return AddLSt;
        }

        public List<EmployeeImportModel> GetAllEmployee(string busid)
        {
            List<EmployeeImportModel> empLst = new List<EmployeeImportModel>();

            empLst = _dp.GetEmployeeLst(busid);

            return empLst;
        }

        //public bool SaveImportedUser(UserImportModel usr, string cnStr)
        //{
        //    var result = false;
        //    MySqlConnection conn = new MySqlConnection(cnStr);
        //    MySqlTransaction trans;
        //    conn.Open();
        //    trans = conn.BeginTransaction();
        //    try
        //    {
        //        if(_dp.SaveImportedUser(usr))
        //        {

        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        trans.Rollback();
        //    }
        //    finally
        //    {
        //        if(result)
        //        {
        //            trans.Commit();

        //        }
        //        else
        //        {
        //            trans.Rollback();
        //        }
        //        conn.Close();
        //    }
        //    return result;
        //}

        //public bool SaveImportedEmployee(EmployeeImportModel emp, bool UsrCreate, string rndpwd, string cnStr)
        //{
        //    var result = false;
        //    MySqlConnection conn = new MySqlConnection(cnStr);
        //    MySqlTransaction trans;
        //    conn.Open();
        //    trans = conn.BeginTransaction();
        //    try
        //    {
        //        if (_dp.SaveImportedEmployee(emp,UsrCreate,rndpwd))
        //        {

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //    }
        //    finally
        //    {
        //        if (result)
        //        {
        //            trans.Commit();

        //        }
        //        else
        //        {
        //            trans.Rollback();
        //        }
        //        conn.Close();
        //    }
        //    return result;
        //}

        //public bool SaveImportedAddress(AddressImportModel address, string cnStr)
        //{
        //    var result = false;
        //    MySqlConnection conn = new MySqlConnection(cnStr);
        //    MySqlTransaction trans;
        //    conn.Open();
        //    trans = conn.BeginTransaction();
        //    try
        //    {
        //        if (_dp.SaveImportedAddress(address))
        //        {

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //    }
        //    finally
        //    {
        //        if (result)
        //        {
        //            trans.Commit();

        //        }
        //        else
        //        {
        //            trans.Rollback();
        //        }
        //        conn.Close();
        //    }
        //    return result;
        //}
    }
}
