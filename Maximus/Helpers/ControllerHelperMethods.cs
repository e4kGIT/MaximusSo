using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maximus.Models;
using System.Configuration;

namespace Maximus.Helpers
{
    public class ControllerHelperMethods
    {
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        DataProcessing dp = new DataProcessing();
        #region Employeectrl
        #endregion

        #region  Homectrl
        public List<SalesOrderLineViewModel> GetChargableAssembly(string style = "", long lineNo = 0, long qty = 0, string empId = "", string empName = "", string busId = "")
        {
            var chargableAsm = new List<SalesOrderLineViewModel>();
            var result = new List<AssemblyModel>();
            result = entity.getcustassemblies.Where(x => x.ParentStyleID == style & x.isChargeable == 1 & x.CustID == busId).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable }).ToList();
            if (result.Count == 0)
            {
                result = entity.getallassemblies.Where(x => x.ParentStyleID == style & x.isChargeable == 1).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable }).ToList();
            }
            long curLine = lineNo;
            foreach (var res in result)
            {
                chargableAsm.Add(new SalesOrderLineViewModel
                {
                    ColourID = entity.tblfsk_style_colour.Any(x => x.StyleID == res.StyleID) ? entity.tblfsk_style_colour.Where(x => x.StyleID == res.StyleID).FirstOrDefault().ColourID : "",
                    OriginalLineNo = lineNo,
                    LineNo = curLine + 1,
                    Description = res.Instruction,
                    OrdQty = dp.Getqty(busId, style, res.StyleID, qty)*qty,
                    Price = 0,
                    SizeID = entity.tblfsk_style_sizes.Any(x => x.StyleID == res.StyleID) ? entity.tblfsk_style_sizes.Where(x => x.StyleID == res.StyleID).FirstOrDefault().SizeID : "",
                    StyleID = res.StyleID,
                    EmployeeId = empId,
                    EmployeeName = empName,
                    Assembly = true,
                    Ischargable = true,
                    StyleImage = entity.tblfsk_style.Where(x => x.StyleID.Contains(res.StyleID)).FirstOrDefault().StyleImage
                });
                curLine = curLine + 1;
            }
            return chargableAsm;


            //(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDecimal(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString() });
        }
        public List<SalesOrderLineViewModel> GetOptionalAssembly(List<string> assemList = null, string style = "", long lineNo = 0, long qty = 0, string empId = "", string empName = "", int lastLino = 0, string busId = "")
        {
            var optionalAsm = new List<SalesOrderLineViewModel>();
            long curLine = lineNo;
            try
            {
                foreach (var res in assemList)
                {
                    optionalAsm.Add(new SalesOrderLineViewModel
                    {
                        ColourID = entity.tblfsk_style_colour.Any(x => x.StyleID == res) ? entity.tblfsk_style_colour.Where(x => x.StyleID == res).FirstOrDefault().ColourID : "",
                        OriginalLineNo = lineNo,
                        LineNo = curLine + 1,
                        Description = entity.getcustassemblies.Where(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction == "" |
                         entity.getcustassemblies.Where(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction == null ? "" : entity.getcustassemblies.Where(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction,
                        OrdQty = dp.Getqty(busId, style, res, qty),
                        Price = 0,
                        SizeID = entity.tblfsk_style_sizes.Any(x => x.StyleID == res) ? entity.tblfsk_style_sizes.Where(x => x.StyleID == res).FirstOrDefault().SizeID : "",
                        StyleID = res,
                        EmployeeId = empId,
                        EmployeeName = empName,
                        Assembly = true,
                        Ischargable = false,
                        StyleImage = entity.tblfsk_style.Where(x => x.StyleID.Contains(res)).FirstOrDefault().StyleImage
                    });
                    curLine = curLine + 1;
                }

            }
            catch (Exception E)
            {

            }
            return optionalAsm;
        }




        #endregion

        #region Basketctrl
        #endregion

        //#region UserCtrl

        //public string DefaultEmployee(string companyid, string userid, string custid)
        //{
        //    string result = "";
        //    string sql = "";
        //    int eCnt = 0;
        //    string mDefaultEmp = "";
        //    sql = "SELECT COUNT(*) FROM tblonline_userid_employee WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
        //    eCnt = dp.getCount(sql);
        //    if (eCnt == 1)
        //    {
        //        sql = "SELECT EmployeeID FROM tblonline_userid_employee WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
        //        mDefaultEmp = dp.GetValue(sql);
        //    }
        //    else if (eCnt <= 0)
        //    {
        //        if (mDefaultEmp == "")
        //        {
        //            sql = "SELECT COUNT(*) FROM tblonline_emp_address WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
        //            eCnt = dp.getCount(sql);
        //            if (eCnt == 1)
        //            {
        //                sql = "SELECT EmployeeID FROM tblonline_emp_address WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
        //                mDefaultEmp = dp.GetValue(sql);
        //            }
        //        }

        //        return mDefaultEmp;
        //    }
        //    return result;
        //}
        //public string SetDefaultWarehouse(string userId, string businessId)
        //{
        //    string wareHouse = "";
        //    wareHouse = BusinessParam("Warehouse", businessId.Trim().ToUpper());
        //    wareHouse = wareHouse == "" ? UserParam("Warehouse", userId.ToUpper().Trim()) : wareHouse;
        //    wareHouse = wareHouse == "" ? CompanyParam("Warehouse", System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString()):wareHouse;
        //    return wareHouse;
        //}

        //public string BusinessParam(string paramId, string businessId)
        //{
        //    string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        //    var data = "";
        //    data= entity.tblbus_setvalues.Any(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId)? entity.tblbus_setvalues.Where(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId).First().Value:"";
        //    if(data!="" && data != null)
        //    {
        //        return data;
        //    }
        //    else
        //    {
        //        data = entity.tblbus_settings.Where(x => x.SettingID == paramId).First().DefaultValue;
        //        if(data !="" && data !=null)
        //        {
        //            return data;
        //        }
        //    }
        //    return "";
        //}

        //public string CompanyParam(string paramID, string companyId)
        //{
        //    string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        //    var data = "";
        //    data = entity.tblcmp_defaults.Where(x => x.CompanyID == companyId & x.ParamID == paramID).First().Value;
        //    if (data != "" && data != null)
        //    {
        //        return data;
        //    }
        //    else
        //    {
        //        data = dp.getCompanyParam(paramID);
        //        if (data != "" && data != null)
        //        {
        //            return data;
        //        }
        //    }
        //    return "";
        //}
        //public string UserParam(string paramId, string userId)
        //{
        //    var result = "";
        //    result = entity.tblgen_user_defaults.Where(x => x.ParamID == paramId && x.UserID == userId).First().Param_Value;
        //    if(result!="" && result!=null)
        //    {
        //        return result;
        //    }
        //    else
        //    {
        //        result = entity.tblgen_user_parameters.Where(x => x.ParamID == paramId).First().Default_Value;
        //        if (result != "" && result != null)
        //        {
        //            return result;
        //        }
        //    }
        //    return result;
        //}

        //#endregion
    }
}