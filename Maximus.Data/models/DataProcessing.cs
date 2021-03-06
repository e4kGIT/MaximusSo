﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using static Maximus.Data.Models.Structrues;
using Maximus.Data.Models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Maximus.Data.Models
{
    public class DataProcessing
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DataProcessing));
        #region parameter Declaration
        List<AllowUsers> result1 = new List<AllowUsers>();
        private static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Maximus"].ConnectionString;
        private static string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"];
        //public bool isRolloutOrder;
        public List<TBusinessAccount> tBusinessAccount;
        public List<TBusinessAccount> TbusinessAccount
        {
            get
            {
                return tBusinessAccount;
            }
            set
            {
                tBusinessAccount = SetBuisnessAccount();
            }
        }

        //public bool IsRolloutOrder
        //{
        //    get
        //    {
        //        return isRolloutOrder;
        //    }
        //    set
        //    {
        //        if (HttpContext.Current.Session["RolloutName"] != null)
        //        {
        //            if (HttpContext.Current.Session["RolloutName"].ToString() != "")
        //            {
        //                isRolloutOrder = true;
        //            }
        //        }
        //        else
        //        {
        //            isRolloutOrder = false;
        //        }

        //    }
        //}

        private readonly UcodeByFreeTextView _ucodeByFreeText;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AllAssemblies _allAssembly;
        private readonly CustomAssembly _customAssembly;
        private readonly BusBusiness _busBusiness;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly Departments _departments;
        public readonly Employee _employee;
        public readonly EmployeeRollout _employeeRollout;
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly Nextno _nextno;
        public readonly StockCard _stockCard;
        public readonly Style_Colour _style_Colour;
        public readonly Style_Sizes _style_Sizes;
        public readonly ReturnReasonCodes _reason;
        public readonly StyleByFreetext _styleByFreetext;
        public readonly StyleColorSizeObsolete _styleColorSizeObsolete;
        public readonly StyleGroups _styleGroups;
        public readonly StylesView _stylesView;
        public readonly TblFskStyle _tblFskStyle;
        public readonly Ucode_Description _ucode_Description;
        public readonly UcodeEmployees _ucodeEmployees;
        public readonly Ucodes _ucodes;
        public readonly BusAddress _busAddress;
        public readonly User _user;
        private readonly PointStyle _stylePoints;
        public readonly StyleSizePrice _styleSizePrice;
        public readonly OnlineUserIdEmployee _onlineUserIdEmployee;
        public readonly GenUserDefaults _genUserDefaults;
        public readonly FskStyle _fskStyle;
        public readonly FskSetValues _fskSetValues;
        public readonly FskSettings _fskSettings;
        public readonly CustomerOrderTemplate _customerOrderTemplate;
        public readonly BusSetValues _busSetValues;
        public readonly CmpDefaults _cmpDefaults;
        public readonly BusSettings _busSettings;
        public readonly AccVatCodes _accVatCodes;
        public readonly UcodeOperationsTbl _ucodeOperationsTbl;
        public readonly GenParameter _genParameter;
        public readonly BusAccount _busAccount;
        public readonly StyleByTemplateView _styleByTemplateView;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsCard _pointsCard;
        public readonly SalesDetail _salesDetail;
        public readonly PickingSlipHeader _pickHeader;
        public readonly tblSalesOrderHeader _salesHead;
        public readonly ViewPointsCard _vuPointsCard;
        public readonly Warehouses _wareHouses;
        public readonly Company _company;
        public readonly UcodeReasons _ucodeReason;
        public readonly TblAlternateTable _tblAlternates;
        public readonly TblReturnsCredited _tblRtnCredites;
        public readonly TblAutono _tblAutono;
        public readonly tblCntRef _cntRef;
        public DataProcessing(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UcodeOperationsTbl ucodeOperationsTbl = new UcodeOperationsTbl(_unitOfWork);
            PickingSlipHeader pickHeader = new PickingSlipHeader(_unitOfWork);
            TblAutono tblAutono = new TblAutono(_unitOfWork);
            UcodeReasons ucodeReason = new UcodeReasons(_unitOfWork);
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            Warehouses wareHouses = new Warehouses(_unitOfWork);
            tblSalesOrderHeader salesHead = new tblSalesOrderHeader(_unitOfWork);
            AllAssemblies allAssembly = new AllAssemblies(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            ReturnReasonCodes reason = new ReturnReasonCodes(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            PointStyle stylePoints = new PointStyle(_unitOfWork);
            FskStyleFreetext fskStyleFreetext = new FskStyleFreetext(_unitOfWork);
            Nextno nextno = new Nextno(_unitOfWork);
            StockCard stockCard = new StockCard(_unitOfWork);
            TblReturnsCredited tblRtnCredites = new TblReturnsCredited(_unitOfWork);
            Style_Colour style_Colour = new Style_Colour(_unitOfWork);
            Style_Sizes style_Sizes = new Style_Sizes(_unitOfWork);
            StyleByFreetext styleByFreetext = new StyleByFreetext(_unitOfWork);
            StyleColorSizeObsolete styleColorSizeObsolete = new StyleColorSizeObsolete(_unitOfWork);
            StyleGroups styleGroups = new StyleGroups(_unitOfWork);
            StylesView stylesView = new StylesView(_unitOfWork);
            TblFskStyle tblFskStyle = new TblFskStyle(_unitOfWork);
            ViewPointsCard vuPointsCard = new ViewPointsCard(_unitOfWork);
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            User user = new User(_unitOfWork);
            EmployeeRollout employeeRollout = new EmployeeRollout(_unitOfWork);
            StyleSizePrice styleSizePrice = new StyleSizePrice(_unitOfWork);
            OnlineUserIdEmployee onlineUserIdEmployee = new OnlineUserIdEmployee(_unitOfWork);
            GenUserDefaults genUserDefaults = new GenUserDefaults(_unitOfWork);
            FskStyle fskStyle = new FskStyle(_unitOfWork);
            FskSetValues fskSetValues = new FskSetValues(_unitOfWork);
            FskSettings fskSettings = new FskSettings(_unitOfWork);
            CustomerOrderTemplate customerOrderTemplate = new CustomerOrderTemplate(_unitOfWork);
            BusSetValues busSetValues = new BusSetValues(_unitOfWork);
            CmpDefaults cmpDefaults = new CmpDefaults(_unitOfWork);
            BusSettings busSettings = new BusSettings(_unitOfWork);
            AccVatCodes accVatCodes = new AccVatCodes(_unitOfWork);
            GenParameter genParameter = new GenParameter(_unitOfWork);
            BusAccount busAccount = new BusAccount(_unitOfWork);
            StyleByTemplateView styleByTemplateView = new StyleByTemplateView(_unitOfWork);
            SalesDetail salesDetail = new SalesDetail(_unitOfWork);
            Company company = new Company(_unitOfWork);
            TblAlternateTable tblAlternates = new TblAlternateTable(_unitOfWork);
            tblCntRef cntRef = new tblCntRef(_unitOfWork);
            _salesDetail = salesDetail;
            _cntRef = cntRef;
            _company = company;
            _styleByTemplateView = styleByTemplateView;
            _user = user;
            _tblAlternates = tblAlternates;
            _reason = reason;
            _salesHead = salesHead;
            _tblAutono = tblAutono;
            _stylePoints = stylePoints;
            _tblRtnCredites = tblRtnCredites;
            _busAccount = busAccount;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _busContact = busContact;
            _employeeRollout = employeeRollout;
            _countryCodes = countryCodes;
            _customAssembly = customAssembly;
            _departments = departments;
            _employee = employee;
            _ucodeReason = ucodeReason;
            _ucodeOperationsTbl = ucodeOperationsTbl;
            _fskStyleFreetext = fskStyleFreetext;
            _nextno = nextno;
            _stockCard = stockCard;
            _style_Colour = style_Colour;
            _style_Sizes = style_Sizes;
            _styleByFreetext = styleByFreetext;
            _pickHeader = pickHeader;
            _styleColorSizeObsolete = styleColorSizeObsolete;
            _styleGroups = styleGroups;
            _stylesView = stylesView;
            _tblFskStyle = tblFskStyle;
            _pointsByUcode = pointsByUcode;
            _ucode_Description = ucode_Description;
            _ucodeByFreeText = ucodeByFreeText;
            _ucodeEmployees = ucodeEmployees;
            _ucodes = ucodes;
            _busAddress = busAddress;
            _ucodeByFreeText = ucodeByFreeText;
            _allAssembly = allAssembly;
            _customAssembly = customAssembly;
            _busBusiness = busBusiness;
            _styleSizePrice = styleSizePrice;
            _onlineUserIdEmployee = onlineUserIdEmployee;
            _genUserDefaults = genUserDefaults;
            _fskStyle = fskStyle;
            _wareHouses = wareHouses;
            _fskSetValues = fskSetValues;
            _fskSettings = fskSettings;
            _vuPointsCard = vuPointsCard;
            _customerOrderTemplate = customerOrderTemplate;
            _busSetValues = busSetValues;
            _cmpDefaults = cmpDefaults;
            _busSettings = busSettings;
            _genParameter = genParameter;
            _pointsCard = pointsCard;
            _accVatCodes = accVatCodes;
        }

        #endregion


        #region Home Module
        #region getColors
        public List<ObsoleteColor> getColors(string style)
        {
            List<ObsoleteColor> color = new List<ObsoleteColor>();
            DataTable dt = new DataTable();
            var s = new List<ColorsOb>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {

                    MySqlCommand cmd = new MySqlCommand("CALL  `getColorProcedure`('" + style + "')", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            color.Add(new ObsoleteColor { ColorId = dr.ItemArray[1].ToString(), CompanyId = dr.ItemArray[0].ToString(), ObsoleteCode = Convert.ToInt32(dr.ItemArray[2].ToString()) });
                        }
                        return color;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }
        #endregion

        public List<UcodeModel> GetAllUcodeLst(string ucode)
        {
            List<UcodeModel> lst = new List<UcodeModel>();
            string sqry = "select StyleID,FreeText,IsHidden from ucodeby_freetextview where UcodeID='" + ucode + "'";
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    var IsHiddenUcode = _ucodeOperationsTbl.Exists(s => s.UcodeId == ucode && s.FreeStkChk && s.IsEmergency) ? _ucodeOperationsTbl.GetAll(s => s.UcodeId == ucode && s.FreeStkChk && s.IsEmergency).First().HasAltStyles : false;
                    MySqlCommand cmd = new MySqlCommand(sqry, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (IsHiddenUcode)
                        {
                            dt.AsEnumerable().Where(s => Convert.ToInt32(s[2].ToString()) == 0).Select(s => new UcodeModel { StyleId = s[0].ToString(), FreeText = s[1].ToString() });
                        }
                        else
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                lst.Add(new UcodeModel { StyleId = dr[0].ToString(), FreeText = dr[1].ToString() });
                            }
                        }
                        return lst;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }

        #region getFreeTextStyles
        public List<styleViewmodel> getFreeTextStyles(string freeText, string selectedEmp, string buisnessId)
        {

            var result = new List<styleViewmodel>();
            List<string> getFreTxt = new List<string>();
            var freeTxtType = Allocation.DIMALLOC.ToString();
            var freeTxtLst = _ucodeByFreeText.GetAll(x => x.DimFreeText == freeText).Select(x => new styleViewmodel { StyleID = x.StyleID, OriginalStyleid = x.StyleID, StyleImage = x.StyleImage, Freetext = freeText, ProductGroup = x.Product_Group.Value }).Distinct().ToList();
            return freeTxtLst;
        }
        #endregion

        #region getSizes
        public DataTable getSizes(string style)
        {
            var s = new List<SizeOb>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("CALL  `getSizeProcedure`('" + style + "')", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }
        #endregion

        #region getColorSizes
        public DataTable getColorSizes(string style)
        {
            var s = new List<SizeOb>();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("CALL  `getSizeColorchangeProcedure`('" + style + "')", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }
        #endregion

        #region getDimStylandImg
        public styleViewmodel getDimStylandImg(string style)
        {
            styleViewmodel svm = new styleViewmodel();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT GROUP_CONCAT(DISTINCT StyleId) AS StyleID,StyleImage,Product_Group,FreeText FROM getstylesview WHERE StyleID IN ('" + style.Replace(",", "','") + "') GROUP BY StyleImage,Product_Group,FreeText LIMIT 1", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            svm.StyleID = dr.ItemArray[0].ToString();
                            svm.StyleImage = dr.ItemArray[1].ToString();
                            svm.ProductGroup = Convert.ToInt32(dr.ItemArray[2].ToString());
                            svm.Freetext = dr.ItemArray[3].ToString();
                            svm.Assembly = _customAssembly.GetAll(d => d.ParentStyleID == style).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == style && d.isChargeable == false).Any() ? 1 : 0 : 0;
                            svm.Dimensions = "";
                            svm.isAllocated = false;
                            svm.OriginalStyleid = dr.ItemArray[0].ToString();
                        }
                        return svm;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }
        #endregion

        #region Dimalloc
        public styleViewmodel GetDimallocStyles(string style)
        {
            styleViewmodel svm = new styleViewmodel();
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT GROUP_CONCAT(DISTINCT StyleId) AS StyleID,StyleImage,Product_Group,FreeText FROM getstylesview WHERE StyleID IN ('" + style.Replace(",", "','") + "') GROUP BY StyleImage,Product_Group,FreeText LIMIT 1", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            svm.StyleID = dr.ItemArray[0].ToString();
                            svm.StyleImage = dr.ItemArray[1].ToString();
                            svm.ProductGroup = Convert.ToInt32(dr.ItemArray[2].ToString());
                            svm.Freetext = dr.ItemArray[3].ToString();
                            svm.Assembly = _customAssembly.GetAll(d => d.ParentStyleID == style).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == style && d.isChargeable == false).Any() ? 1 : 0 : 0;
                            svm.Dimensions = "";
                            svm.isAllocated = false;
                            svm.OriginalStyleid = dr.ItemArray[0].ToString();
                        }
                        return svm;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return null;
        }
        #endregion

        #region getStyleFromFretxt
        public string getStyleFromFretxt(string freetxt)
        {
            string result = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string sqry = "SELECT StyleId FROM styleby_freetextview WHERE FreeText='" + freetxt + "' LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sqry, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader.GetString(0) != "" ? reader.GetString(0) : "";
                    }
                }


            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;

        }
        #endregion

        #endregion

        #region Employee Module

        #region getEmpaddress

        public int GetEmpAddress(string EmpId)
        {
            int result = 0;
            string sSqry = "";
            sSqry = sSqry + " SELECT addressId FROM `tblonline_emp_address` WHERE onlineuserid='" + EmpId + "' limit 1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetOrderPermission
        public string GetOrderPermission(string OrderPermit)
        {
            //return System.Web.HttpContext.Current.Session["OrderPermit"].ToString() == "" ? "" : System.Web.HttpContext.Current.Session["OrderPermit"].ToString();
            return OrderPermit == "" ? "" : OrderPermit;
        }
        public bool IsPrivateUcode(string busId, string ucode = "")
        {
            var privatUcode = BusinessParam("PRIVATEUCODE", busId);
            if (privatUcode != "")
            {
                if (privatUcode.ToLower().Trim() == ucode.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckEmergency(string busId, string ucode = "")
        {
            var result = false;
            var result1 = false;
            if (ucode != "")
            {
                result = _ucodeOperationsTbl.Exists(s => s.BusinessID == busId && s.UcodeId == ucode) ? _ucodeOperationsTbl.GetAll(s => s.BusinessID == busId && s.UcodeId == ucode).First().IsEmergency ? true : false : false;
            }
            if (ucode != "")
            {
                result1 = _pointsByUcode.Exists(s => s.BusinessID == busId && s.UcodeID == ucode) ? false : true;
            }
            if (result1 | result)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region GetUcodeList
        public List<UcodenDescModal> GetAllTemplates(string businessId = "")
        {
            List<UcodenDescModal> tempLst = new List<UcodenDescModal>();
            string sSqry = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                sSqry = sSqry + "SELECT DISTINCT template FROM tblSOP_customerorder_Template WHERE `BusinessID` ='" + businessId + "'";
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tempLst.Add(new UcodenDescModal { UcodeDescription = dr[0].ToString(), UcodeId = dr[0].ToString() });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return tempLst;

        }

        public List<UcodenDescModal> GetAllUcodesAndDesc(string businessId = "")
        {
            List<UcodenDescModal> ucodeLst = new List<UcodenDescModal>();
            string sSqry = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                sSqry = sSqry + "SELECT DISTINCT tblaccemp_ucodesemployees.UCodeID, IF(ISNULL(tblaccemp_ucodes_desc.Description),tblaccemp_ucodesemployees.UCodeID,tblaccemp_ucodes_desc.Description) AS Description FROM tblaccemp_ucodesemployees LEFT JOIN tblaccemp_ucodes_desc ON tblaccemp_ucodesemployees.UCodeID = tblaccemp_ucodes_desc.UCodeID WHERE tblaccemp_ucodesemployees.BusinessID = '" + businessId + "' AND  tblaccemp_ucodesemployees.`UCodeID` NOT IN(SELECT DISTINCT ucodeid FROM `tblaccemp_stylepoints`)";
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ucodeLst.Add(new UcodenDescModal { UcodeDescription = dr[1].ToString(), UcodeId = dr[0].ToString() });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return ucodeLst;

        }

        public List<string> GetUcodeList(string employeeId = "", string businessId = "")
        {
            List<string> result = new List<string>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string sqry = "SELECT DISTINCT t1.`CompanyID`,t1.`UCodeID`,IF (Q1.`UCodeID` IS NULL,FALSE,FALSE) AS CheckIt  FROM `tblaccemp_ucodes` t1  LEFT JOIN (SELECT CompanyID,BusinessID,UCodeID FROM `tblaccemp_ucodesemployees` WHERE `EmployeeID`='" + employeeId + "') Q1 ON t1.`CompanyID`=Q1.CompanyID AND t1.UCODEID=Q1.UCODEID  LEFT JOIN tblaccemp_ucodesemployees t2 ON t1.`CompanyID` = t2.`CompanyID` AND t1.`UCodeID` = t2.`UCodeID`  WHERE t2.BusinessID='" + businessId + "' AND t2.CompanyID='" + cmpId + "' ORDER BY t1.UCodeID";
                MySqlCommand cmd = new MySqlCommand(sqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.ItemArray[1].ToString());
                    }
                }
                if (result.Count > 0)
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;

        }
        #endregion

        #region GetRoles 
        public List<string> GetRoles(string busId = "")
        {
            var result = new List<string>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string sqry = "SELECT RoleID, RoleName FROM tblroles";
                MySqlCommand cmd = new MySqlCommand(sqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.ItemArray[1].ToString());
                    }
                }
                if (result.Count > 0)
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region LimitEmpUsers
        public bool LimitEmpUsers(string access, string busId)
        {
            if (AddressUserCreate())
            {
                return false;
            }
            else
            {
                if (access.Trim().ToUpper() == "ADMIN")
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(BusinessParam("LimitUsrEmp", busId.Trim()));
                }
            }

        }
        #endregion

        #region ShowHourse
        public bool ShowHourse(string busId = "")
        {
            return Convert.ToBoolean(BusinessParam("SHOW_HRS_WORK", busId.Trim()));

        }
        #endregion

        #region SaveWorldPayTrans

        public void SaveWorldPayTrans(string txnId, string cartId, string ono, string payr, string amount, string email, string address, string phone, string country, string postcode)
        {
            string sSql = "";
            sSql = "Insert into worldpay_trans(`TransID`,`CartID`,`OrderNo`,`Payer`,`Amount`,`Email`,`Phone`,`Address`,`Postcode`,`Country`)values('" + txnId + "','" + cartId + "','" + ono + "','" + payr + "','" + amount + "','" + email + "','" + address + "','" + phone + "','" + address + "','" + postcode + "','" + country + "') ";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region AddressUserCreate
        public bool AddressUserCreate(string busId = "")
        {
            return Convert.ToBoolean(BusinessParam("DELADDR_USER_CREATE", busId.Trim()));
        }
        #endregion


        #region AddressUserCreate
        public int GetUserAddress(string busId = "", string userId = "")
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            var result = 0;
            int outq = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tblonline_emp_address where BusinessID='" + busId + "' and EmployeeID='" + userId + "'", conn);
                var data = cmd.ExecuteScalar().ToString();
                result = int.TryParse(data, out outq) ? Convert.ToInt32(data) : 0;
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        #region ViewtotalPointLst
        public List<vuTotalPointsModel> ViewtotalPointLst(string busId = "", string emp = "")
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            var result = new List<vuTotalPointsModel>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from view_totalpointsused where BusinessID='" + busId + "' and EmployeeID='" + emp + "'", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = dt.AsEnumerable().Select(s => new vuTotalPointsModel { BusinessID = s.ItemArray[0].ToString(), ColourID = s.ItemArray[3].ToString(), EmployeeID = s.ItemArray[1].ToString(), StyleID = s.ItemArray[2].ToString(), TOTSOPOINTS = Convert.ToInt32(s.ItemArray[4].ToString()) }).ToList();
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region IsSuperUser 
        public bool IsSuperUser(string cmpId, string custId, string _user)
        {
            bool result = false;
            string sSqry = "SELECT if(isnull(`Permission`),'HIDE',`Permission`) as `Permission` from `tblpermission_settings_users` WHERE `CompanyID`='" + cmpId + "' AND `UserID`='" + _user + "' AND `BusinessID`='" + custId + "' AND `ControlID`='SUPERUSER'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var data = cmd.ExecuteScalar();
                result = data.ToString().ToUpper() == "SHOW";
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region IsReasonUcodes
        public bool IsReasonUcodes(string busId = "")
        {
            return Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim()));
        }
        #endregion

        #region getPermission
        public string getPermission(controls controlId, string AccessID, string BusinessID = "", string usr = "", string userId = "")
        {
            string sqlP = "";
            string ControlName = "";
            string varPermission = "";
            string strUserID = "";
            strUserID = userId;
            strUserID = usr == "" ? userId : usr;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            if (controlId == controls.Price)
            { ControlName = "Price"; }
            else if (controlId == controls.Orders)
            { ControlName = "Order"; }
            else if (controlId == controls.Employee)
            { ControlName = "Employee"; }
            else if (controlId == controls.OrderDelete)
            { ControlName = "OrderDelete"; }
            else if (controlId == controls.NomCode)
            { ControlName = "NomPanel"; }
            else if (controlId == controls.Access)
            { ControlName = "Access"; }
            else if (controlId == controls.SAP)
            { ControlName = "SAPPermit"; }
            else if (controlId == controls.OrderConfirm)
            { ControlName = "OrderConfirm"; }
            else if (controlId == controls.AllowOverrideEntitlement)
            { ControlName = "ALLOW_OVERRIDE_ENT"; }
            else if (controlId == controls.OverrideEntitlementWithReason)
            {
                ControlName = "OVERRIDE_ENT_WITH_REASON";
            }
            else if (controlId == controls.AllAddress)
            { ControlName = "AllAddress"; }
            else if (controlId == controls.UserAddressMapping)
            { ControlName = "UserAddressMapping"; }
            else if (controlId == controls.ShowStockcard)
            { ControlName = "btnShowStockcard"; }
            else if (controlId == controls.ROLLOUTEMPDELADDR_CHG)
            { ControlName = "ROLLOUTEMPDELADDR_CHG"; }
            else if (controlId == controls.SuperUser)
            {
                ControlName = "SUPERUSER";
            }
            try
            {
                sqlP = "SELECT Permission FROM tblpermission_settings_users " +
                  "WHERE UserID='" + strUserID + "' AND ControlID='" + ControlName + "' AND BusinessID='" + BusinessID + "'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlP, conn);
                MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dr.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        varPermission = dr1.ItemArray[0].ToString();
                    }
                }
                else
                {
                    varPermission = "";
                }
                if (varPermission == "")
                {
                    sqlP = "SELECT Permission FROM tblpermission_settings  WHERE AccessID='" + AccessID + "' AND ControlID='" + ControlName + "' AND BusinessID='" + BusinessID + "'";
                    MySqlCommand cmd1 = new MySqlCommand(sqlP, conn);
                    MySqlDataAdapter dr1 = new MySqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    dr1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dar in dt1.Rows)
                        {
                            varPermission = dar.ItemArray[0].ToString();
                        }
                    }
                    else
                    {
                        sqlP = "SELECT Permission FROM tblpermission_settings  WHERE AccessID='" + AccessID + "' AND ControlID='" + ControlName + "' AND BusinessID='ALL'";
                        MySqlCommand cmd2 = new MySqlCommand(sqlP, conn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dar1 in dt2.Rows)
                            {
                                varPermission = dar1.ItemArray[0].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return varPermission;
        }
        #endregion

        #region GetPrice

        public decimal GetPrice(string StyleID = "", string SizeId = "", string busId = "", string priceId = "", bool isPrivOrder = false)
        {
            decimal result = 0;
            string sSqry = "", sSqry1 = "";
            string res1 = "", res2 = "";
            try
            {
                string businessId = busId;
                if (StyleID.Contains(",") == false)
                {
                    if (priceId != "")
                    {
                        sSqry = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='" + businessId + "' and PriceID=" + priceId + "";
                        sSqry1 = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='All' and PriceID=" + priceId + "";
                    }
                    else
                    {
                        sSqry = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='" + businessId + "' and PriceID=2";
                        sSqry1 = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='All' and PriceID=2";
                    }
                    res1 = GetScalar(sSqry);
                    res2 = GetScalar(sSqry1);
                    if (isPrivOrder)
                    {
                        if (res1 == "" && res2 == "")
                        {
                            sSqry = ""; sSqry1 = "";
                            sSqry = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='" + businessId + "' and PriceID=2";
                            sSqry1 = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='All' and PriceID=2";
                            res1 = GetScalar(sSqry);
                            res2 = GetScalar(sSqry1);
                        }
                    }

                }
                else
                {
                    string[] styleArr = StyleID.Split(',');
                    string firstStyl = styleArr[0].ToString();
                    sSqry = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + firstStyl.Trim() + "' and BusinessId='" + businessId + "' and PriceID=2";
                    sSqry1 = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + firstStyl.Trim() + "' and BusinessId='All' and PriceID=2";
                    res1 = GetScalar(sSqry);
                    res2 = GetScalar(sSqry1);
                }
                result = Convert.ToDecimal(res1 == "" ? res2 == "" ? "0" : res2 : res1);
                if (result != 0)
                {
                    return System.Math.Round(result, 2);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return 0;
        }

        #endregion

        #region getScalar
        public string GetScalar(string sSqry)
        {
            var result = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var data = cmd.ExecuteScalar();
                result = data.ToString();
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        #region getScalar
        public string GetScalarTrans(string sSqry, MySqlConnection conn)
        {
            var result = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var data = cmd.ExecuteScalar();
                result = data.ToString();
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region GetTotalSOPoints
        public int GetTotalSOPointsByStyle(string businessId, string employeeId, int year, string styleId)
        {

            int totSoPts = 0;
            try
            {
                totSoPts = _vuPointsCard.Exists(s => s.BusinessID == businessId && s.EmployeeID == employeeId && s.StyleID == styleId) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == businessId && s.EmployeeID == employeeId && s.StyleID == styleId).Sum(s => s.TOTSOPOINTS).Value) : 0;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return totSoPts;
            //string stylLst = "";

            //string qry = "SELECT SUM(IF(SOPoints IS NULL,0,SOPoints)+IF(PickPoints IS NULL,0,PickPoints)+IF(InvPoints IS NULL ,0,InvPoints)) AS TOTSOPOINTS FROM `tblaccemp_pointscard` WHERE EmployeeId='" + employeeId + "' AND BusinessID = '" + businessId + "' AND Year=" + year + " AND StyleID ='" + styleId + "'";
            //MySqlConnection conn = new MySqlConnection(ConnectionString);
            //try
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand(qry, conn);
            //    totSoPts = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    conn.Close();
            //}
            //return totSoPts;
        }
        #endregion
        #region GetTotalSOPoints
        public int GetTotalSOPointsByStyleMap(string businessId, string employeeId, int year, List<string> styleIdLst)
        {
            int totSoPts = 0;
            totSoPts = _vuPointsCard.Exists(s => s.BusinessID == businessId && s.EmployeeID == employeeId && styleIdLst.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == businessId && s.EmployeeID == employeeId && styleIdLst.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;
            return totSoPts;
            //int totSoPts = 0;
            //string stylLst = "";
            //stylLst = string.Join(",", styleIdLst);


            //if (stylLst.Last() == ',')
            //{
            //    stylLst = stylLst.Remove(stylLst.Length - 1);
            //}
            //string qry = "SELECT SUM(IF(SOPoints IS NULL,0,SOPoints)+IF(PickPoints IS NULL,0,PickPoints)+IF(InvPoints IS NULL ,0,InvPoints)) AS TOTSOPOINTS FROM `tblaccemp_pointscard` WHERE EmployeeId='" + employeeId + "' AND BusinessID = '" + businessId + "' AND Year=" + year + " AND StyleID in (" + stylLst + ")";
            //MySqlConnection conn = new MySqlConnection(ConnectionString);
            //try
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand(qry, conn);
            //    totSoPts = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    conn.Close();
            //}
            //return totSoPts;

        }
        #endregion

        #region getTotalSopoints
        public int GetTotalSoPoints(string businessId, string employeeId, int year = 0, List<string> ucodestyles = null)
        {
            int totSoPts = 0;
            if (ucodestyles != null)
            {
                if (ucodestyles.Count > 0)
                {
                    totSoPts = _vuPointsCard.Exists(s => s.BusinessID == businessId && s.EmployeeID == employeeId && ucodestyles.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == businessId && s.EmployeeID == employeeId && ucodestyles.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;
                }
                else
                {
                    totSoPts = _vuPointsCard.Exists(s => s.BusinessID == businessId && s.EmployeeID == employeeId) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == businessId && s.EmployeeID == employeeId).Sum(s => s.TOTSOPOINTS).Value) : 0;
                }

            }
            else
            {
                totSoPts = _vuPointsCard.Exists(s => s.BusinessID == businessId && s.EmployeeID == employeeId) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == businessId && s.EmployeeID == employeeId).Sum(s => s.TOTSOPOINTS).Value) : 0;
            }

            return totSoPts;
            //string qry = "SELECT SUM(IF(SOPoints IS NULL,0,SOPoints)+IF(PickPoints IS NULL,0,PickPoints)+IF(InvPoints IS NULL ,0,InvPoints)) AS TOTSOPOINTS FROM `tblaccemp_pointscard` WHERE EmployeeId='" + employeeId + "' AND BusinessID = '" + businessId + "' AND Year=" + year;
            //MySqlConnection conn = new MySqlConnection(ConnectionString);
            //try
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand(qry, conn);
            //    totSoPts = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    conn.Close();
            //}
            //return totSoPts;
        }
        #endregion
        #region GetBulkPrice1
        public decimal GetBulkPrice1(int qty, string StyleID = "", string SizeId = "", string busId = "")
        {
            decimal resPric = 0;
            try
            {
                if (qty > 0)
                {

                    string businessId = busId;
                    decimal result = _styleSizePrice.Exists(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId && x.PriceID == 2) ? (decimal)_styleSizePrice.GetAll(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId && x.PriceID == 2).FirstOrDefault().Price.Value : 0;
                    result = result == 0 ? _styleSizePrice.Exists(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL" && x.PriceID == 2) ? (decimal)_styleSizePrice.GetAll(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL" && x.PriceID == 2).FirstOrDefault().Price.Value : result : result;
                    if (result != 0)
                    {
                        resPric = System.Math.Round(result, 2);
                        resPric = resPric * qty;
                    }
                    else
                    {
                        resPric = 0 * qty;
                    }
                    return resPric;
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return 0;

        }
        #endregion

        #region getCount
        public int getCount(string sQry)
        {
            int cnt = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                cnt = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                return cnt;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return cnt;
        }
        #endregion

        #region GetValue
        public string GetValue(string sSqry)
        {
            string result = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                result = dr["EmployeeID"] != null ? dr["EmployeeID"].ToString() : "";
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetDenyChildUsers
        public string GetDenyChildUsers(string userId, string busId)
        {
            string result = "";
            string sqlUser = "";
            string parentlist = "";
            string mylist = "";
            mylist = "'" + userId + "'";
            sqlUser = "select GROUP_CONCAT(DenyUser) as UsersDeny  from tblpermission_users_deny where businessid='" + busId + "' and userid='" + userId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUser, conn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.ItemArray[0].ToString() == "")
                        {
                            parentlist = "";
                        }
                        else
                        {
                            parentlist = Regex.Replace(dr.ItemArray[0].ToString(), ",", "','");
                        }
                    }
                }
                else
                {
                    parentlist = "";
                }
                return result = parentlist;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region getDenyPermissionUsers
        public string getDenyPermissionUsers(string OrderPermission, string userId, string busId)
        {
            string result = "";
            string DenyUsers = "";
            DenyUsers = GetDenyChildUsers(userId, busId);
            return result = DenyUsers == "" ? "''" : DenyUsers;
        }
        #endregion

        #region GetPermission
        public string getPermissionUsers(string Permission, string CurrUser, string busID, string mRole)
        {
            string result = "", AllowUsers = "", Users = "";
            mRole = GetDBScalarString("SELECT AccessID FROM tblUsers WHERE BusinessID='" + busID + "' AND Active='Y' AND UserName='" + CurrUser + "'");
            if (mRole.ToLower() == "admin")
            {
                AllowUsers = GetOnlyAllowUsers(CurrUser, busID, mRole.ToUpper());
            }
            else
            {
                List<AllowUsers> lst = getNewPermissionUser(CurrUser, AllowUsers, Users, busID);
                var max = lst.Max(x => x.count);
                var datae = lst.OrderByDescending(x => x.count).Take(2).ToList();

                var newAllUser = "";
                foreach (var data in datae)
                {
                    if (data.users != "")
                    {
                        newAllUser = newAllUser + data.users;
                    }
                }
                AllowUsers = newAllUser;
                if (AllowUsers == "")
                {
                    AllowUsers = "'" + CurrUser + "'";
                }
                else
                {
                    AllowUsers = Users == "'0'," ? "" : Users + AllowUsers + "'" + CurrUser + "'";
                }
            }
            if (AllowUsers.ToUpper() == ("'" + CurrUser + "'").ToUpper())
            {
                result = getPermissionUsers_Old(Permission, CurrUser, busID);
            }
            else
            {
                result = AllowUsers == "" ? "''" : AllowUsers;
            }
            return result;
        }
        #endregion

        #region getPermissionUsers_Old
        public string getPermissionUsers_Old(string Permission, string CurrUser, string busID)
        {

            string sqlUser = "";
            string tmpStr = "";
            string tmpOrdStr = "";
            string strFlds = "";
            string Rolename = "";
            string sSqry = "";
            int i = 0, cnt = 0;
            DataTable dt = new DataTable();
            sqlUser = "SELECT DISTINCT UserName FROM tblusers WHERE BusinessID='" + busID + "' ";
            string result = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                if (Permission != "")
                {
                    var param = Permission.Split('.');
                    foreach (var RoleID in param)
                    {
                        Rolename = getRoleName(Convert.ToInt32(RoleID));
                        if (strFlds == "")
                        {
                            strFlds = "AccessID = '" + Rolename + "'";
                        }
                        else
                        {
                            strFlds += " OR AccessID = '" + Rolename + "'";
                        }
                        cnt = cnt + 1;
                    }
                    if (cnt == 0)
                    {
                        sSqry = "SELECT `EmployeeID` as UserName FROM `tblonline_userid_employee` WHERE BusinessID='" + busID + "' and `OnlineUserID`='" + CurrUser + "'";
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            var empLst = dt.AsEnumerable().Select(s => s.ItemArray[0]).ToList();
                            strFlds = String.Join("','", empLst);
                            strFlds = "'" + strFlds + "'";
                            //foreach (DataRow dr in dt.Rows)
                            //{
                            //    strFlds += "'" + dr.ItemArray[0].ToString() + "',";
                            //}
                        }
                        //strFlds = strFlds.Remove(strFlds.LastIndexOf(","), 1);
                        result = "'" + CurrUser + "'," + strFlds;
                    }
                }
                else
                {
                    result = "'" + CurrUser + "'";
                }
                if (strFlds != "")
                {
                    sqlUser += "AND (" + strFlds + ")";
                }
                else
                {
                    result = "'" + CurrUser + "'";
                    return result;
                }
                MySqlCommand cmd3 = new MySqlCommand(sqlUser, conn);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd3);
                DataTable dt1 = new DataTable();
                da2.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    var usrLst = dt1.AsEnumerable().Select(s => s.ItemArray[0]).ToList();
                    //foreach (DataRow dr in dt1.Rows)
                    //{
                    //    tmpStr += "'" + dr.ItemArray[0].ToString() + "',";
                    //}
                    tmpStr = String.Join("','", usrLst);
                    tmpStr = "'" + tmpStr + "'";
                    if (tmpStr != "")
                    {
                        tmpStr = "'" + CurrUser + "'," + tmpStr;
                    }
                    else
                    {
                        tmpStr = "'" + CurrUser + "'";
                    }
                }
                else
                {
                    tmpStr = "'" + CurrUser + "'";
                }
                sqlUser = "SELECT DISTINCT H.OnlineUserID FROM tblsop_salesorder_header H  WHERE H.CustID='" + busID + "' AND H.OnlineUserID IN (" + tmpStr + ") ORDER BY H.OnlineUserID";
                MySqlCommand cmd4 = new MySqlCommand(sqlUser, conn);
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd4);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    var usrLst1 = dt3.AsEnumerable().Select(s => s.ItemArray[0]).ToList();
                    tmpOrdStr = String.Join("','", usrLst1);
                    //foreach (DataRow dr in dt3.Rows)
                    //{
                    //    if (dr.ItemArray[0].ToString().Trim() != CurrUser)
                    //    {
                    //        tmpOrdStr += "'" + dr.ItemArray[0].ToString() + "',";
                    //    }

                    //}
                    tmpOrdStr = "'" + tmpOrdStr + "'";
                }

                if (tmpOrdStr != "")
                {
                    result = tmpStr + "," + tmpOrdStr;
                }
                else
                {
                    result = tmpStr;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion



        #region sendDeleteMail
        public void sendDeleteMail(long orderno, string reason, string busId, string userId, string employeeid, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer)
        {
            string UeEmailId = BusinessParam("UsersManageEmail", busId);
            UeEmailId = UeEmailId == "" ? UeEmailId : UeEmailId;
            string msg = "";
            string subject = "";
            string managerName = "";
            string UserManagerID = "";
            string UserManagerName = "";
            string empMail = "";
            string bcc = "";
            string cc = "";
            if (reason == "")
            {
                msg = "The Order No " + orderno + " has been deleted by the user " + userId + " on " + DateTime.Now.ToString("dd-MM-yyyy") + "";
            }
            else
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
                string OrderRejectionTemplate = System.IO.File.ReadAllText(appPath + "\\OrderRejection.html");
                var orderRejectionBuilder = new StringBuilder(OrderRejectionTemplate);
                var emp = _employee.Exists(s => s.EmployeeID == employeeid) ? _employee.GetAll(s => s.EmployeeID == employeeid).First() : new tblaccemp_employee();
                var user = _user.Exists(s => s.UserName == userId) ? _user.GetAll(s => s.UserName == userId).First() : new tbluser()
                ;
                orderRejectionBuilder.Replace("{%ORDERNO%}", orderno.ToString());
                orderRejectionBuilder.Replace("{%ONLINEUSERID%}", userId);
                orderRejectionBuilder.Replace("{%EMPLOYEEID%}", employeeid);
                if (user.UserName != null && user.UserName != "")
                {
                    orderRejectionBuilder.Replace("{%ONLINEUSERNAME%}", user.ForeName + " " + user.SurName);
                }
                else
                {
                    orderRejectionBuilder.Replace("{%ONLINEUSERNAME%}", "");
                }

                if (emp.EmployeeID != null && emp.EmployeeID != "")
                {
                    orderRejectionBuilder.Replace("{%EMPLOYEENAME%}", emp.Forename + " " + emp.Surname);
                }
                else
                {
                    orderRejectionBuilder.Replace("{%EMPLOYEENAME%}", "");
                }
                orderRejectionBuilder.Replace("{%REASON%}", reason);
                msg = "<html><head></head><body>" + orderRejectionBuilder + "</body></html>";
            }
            subject = "Online Order Deleted...";
            var Qry = "SELECT * FROM tblusers WHERE UserName='" + userId + "' AND BusinessID='" + busId + "'";
            string userMail = _user.Exists(s => s.UserName == userId && s.BusinessID == busId) ? _user.GetAll(s => s.UserName == userId && s.BusinessID == busId).First().Email_ID : "";
            if (userMail != null)
            {
                empMail = _user.Exists(s => s.UserName == employeeid && s.BusinessID == busId) ? _user.GetAll(s => s.UserName == employeeid && s.BusinessID == busId).First().Email_ID : "";
                if (empMail != "")
                {
                    if (empMail != userMail)
                    {
                        bcc = empMail;
                    }
                }
                try
                {
                    sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, msg, userMail, bcc, cc);
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
            }
            managerName = _user.Exists(s => s.Email_ID == UeEmailId) ? _user.GetAll(s => s.Email_ID == UeEmailId).First().ForeName + " " + _user.GetAll(s => s.Email_ID == UeEmailId).First().ForeName : "";
            if (UeEmailId != "")
            {
                try
                {
                    bcc = "";
                    cc = "";
                    sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, msg, UeEmailId, bcc, cc);
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
            }
            if (Convert.ToBoolean(BusinessParam("REQ_USRMANAGER_EMAIL", busId)))
            {
                string sql = "SELECT UserName, Email_ID, ForeName, SurName FROM tblusers t1 JOIN tblpermission_users_allow t2 ON t1.BusinessID=t2.BusinessID AND t1.UserName=t2.UserID  WHERE t1.Active='Y' AND t2.AllowUser='" + userId + "' AND t2.BusinessID='" + busId + "'";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            UserManagerID = dr["Email_ID"].ToString();
                            UserManagerName = dr["ForeName"].ToString() + " " + dr["SurName"].ToString();
                        }
                    }
                    if (UserManagerID != "")
                    {
                        cc = "";
                        bcc = "";
                        sendSmtpMail(subject, adminMail, mailUsername, mailUsername, mailPort, mailServer, msg, UserManagerID, bcc, cc);
                    }
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
                finally
                {
                    conn.Close();
                }
            }
            //      If CBoolstr(BusinessParam("REQ_USRMANAGER_EMAIL", Session("CustID"))) Then

            //    Dim UserManagerID As String = ""

            //    Dim UserManagerName As String = ""

            //    Dim rsTmp As New ADODB.Recordset

            //    sql = "SELECT UserName, Email_ID, ForeName, SurName FROM tblusers t1 JOIN tblpermission_users_allow t2 ON t1.BusinessID=t2.BusinessID AND t1.UserName=t2.UserID " & _

            //          "WHERE t1.Active='Y' AND t2.AllowUser='" & Session("UserID") & "' AND t2.BusinessID='" & Session("CustID") & "'"

            //    rsTmp.Open(LCase(sql), Conn)

            //    If Not rsTmp.EOF Then

            //        If IsDBNull(rsTmp("Email_ID").Value) = False Then

            //            UserManagerID = rsTmp("Email_ID").Value

            //            UserManagerName = rsTmp("ForeName").Value & " " & rsTmp("SurName").Value

            //        End If

            //    End If

            //    rsTmp.Close()


            //    If UserManagerID <> "" Then

            //        ObjMail1.To = UserManagerID

            //        ObjMail1.From = ConfigurationSettings.AppSettings.Item("EmailID")

            //        ObjMail1.Subject = strSubject

            //        ObjMail1.BodyFormat = MailFormat.Text

            //        ObjMail1.Body = strMsg

            //        SmtpMail.SmtpServer = ConfigurationSettings.AppSettings.Item("smtpserver")

            //        Try

            //            SMTPClientMethodToSendMail(ObjMail1)

            //            ' SmtpMail.Send(ObjMail1)

            //        Catch exe As Exception

            //        End Try

            //    End If

            //End If
        }
        #endregion

        #region sendSmtpMail
        public void sendSmtpMail(string subject, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string htmlString, string toEMail, string bcc, string cc)
        {
            bool isMailReq = System.Configuration.ConfigurationManager.AppSettings["IsMailRequired"] != "" ? Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsMailRequired"]) : true;
            try
            {

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(adminMail);
                message.To.Add(new MailAddress(toEMail));
                message.Subject = subject;
                if (bcc != "")
                {
                    message.Bcc.Add((new MailAddress(bcc)));
                }
                if (cc != "")
                {
                    message.CC.Add((new MailAddress(cc)));
                }
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = Convert.ToInt32(mailPort);
                smtp.Host = mailServer; //for webmai host  
                smtp.EnableSsl = true;
                smtp.Timeout = 100000;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailUsername, mailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                if (isMailReq)
                {
                    smtp.Send(message);
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
        }
        #endregion

        #region  getRoleName
        public string getRoleName(int RoleID)
        {
            var result = "";
            string sSql = "";
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                sSql = "SELECT RoleName FROM tblroles WHERE RoleID=" + RoleID;
                MySqlCommand cmd = new MySqlCommand(sSql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result = dr.ItemArray[0].ToString();
                    }
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region getNewPermissionUser
        public List<AllowUsers> getNewPermissionUser(string Users, string UserList, string EmpList, string busID)
        {
            string usrs = "";

            string emplList = "";
            List<string> param = new List<string>() { "_Users", "_CustID" };
            List<string> val = new List<string>() { "'" + Users + "'", busID };
            string sSqry = "";
            sSqry = "getHighLevelUser";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (var i = 0; i < param.Count; i++)
                {
                    cmd.Parameters.Add(new MySqlParameter(param[i], val[i]));
                }
                usrs = (cmd.ExecuteScalar()).ToString() != "" | cmd.ExecuteScalar() != null ? (cmd.ExecuteScalar()).ToString() : "";
                if (usrs == "0" | usrs == "")
                {
                    emplList = "'" + getZeroLevelUsers(Users) + "',";
                    //result1.Add(new Maximus.Data.Models.AllowUsers { users = emplList, count = emplList.Count() });
                }
                else
                {
                    UserList += "'" + usrs + "',";
                    //result1.Add(new Maximus.Data.Models.AllowUsers { users = UserList, count = UserList.Count() });
                    getNewPermissionUser(usrs, UserList, emplList, busID);
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            result1.Add(new Maximus.Data.Models.AllowUsers { users = UserList, count = UserList.Count() });
            return result1;

        }
        #endregion

        #region getZeroLevelUsers

        public string getZeroLevelUsers(string users)
        {
            string result = "";
            string query = "";
            query = "SELECT GROUP_CONCAT(`EmployeeID` SEPARATOR " + Convert.ToChar(34) + "','" + Convert.ToChar(34) + ")  FROM `tblonline_userid_employee` WHERE OnlineUserID IN('" + users + "') ";
            result = ReturnValue(query);
            return result;
        }

        #endregion

        #region ReturnValue
        public string ReturnValue(string Query)
        {
            string result = "0";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                var result1 = cmd.ExecuteScalar();
                if (result1.ToString() == "")
                {
                    result = "0";
                }
                else
                {
                    result = result1.ToString();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetOnlyAllowUsers
        public string GetOnlyAllowUsers(string userId, string busID, string strAccess)
        {
            string result = "";
            string sqlUser = "";
            string parentlist = "";
            string mylist = "";
            mylist = "'" + userId + "'";
            sqlUser = "select GROUP_CONCAT(AllowUser) as UsersAllow from tblpermission_users_allow  where businessid='" + busID + "' and userid='" + userId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUser, conn);
                result = (cmd.ExecuteScalar()).ToString() != "" | cmd.ExecuteScalar() != null ? (cmd.ExecuteScalar()).ToString() : "";
                if (result == "")
                {
                    parentlist = mylist;
                }
                else
                {
                    parentlist = mylist + "," + Regex.Replace("'" + result + "'", ",", "','");
                }
                result = parentlist;

                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetDBScalarString
        public string GetDBScalarString(string sSqry)
        {
            string result = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = (cmd.ExecuteScalar()).ToString() != "" | cmd.ExecuteScalar() != null ? (cmd.ExecuteScalar()).ToString() : "";
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetEmployeeTemplate 
        public List<EmployeeViewModel> GetEmployeeTemplate(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            string strsql = "";
            bool booBudget = false;
            string StDate = "";
            string EdDate = "";
            string CustBudgetType = "";
            string CustBudgetPeriodDays = "";
            string allUsers = "";
            bool booPoints = false;
            //CustBudgetType = BusinessParam("BudgetType", busId);
            //CustBudgetPeriodDays = BusinessParam("BudgetPeriodDays", busId);
            booBudget = Convert.ToBoolean(BusinessParam("BUDGETREQ", busId));
            booPoints = Convert.ToBoolean(BusinessParam("POINTSREQ", busId));
            strsql = "SELECT e.employeeid, concat(concat(e.forename,' '),e.surname) as employeename,sop.orderdate,sop.`OrderNo`, e.EmployeeClosed AS `STATUS` ";
            if (booBudget)
            {
                strsql = strsql + ",t1.Budget as EntBudget,b.CurrBudget";
            }
            if (booPoints)
            {
                strsql = strsql + ",t2.TotalPoints as EntPoints,p.CurrPoints ";
            }
            if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            {
                strsql = strsql + ",if(s.CurrStock IS NULL,0,s.CurrStock) as empStock ";
            }
            strsql = strsql + ",e.departmentid FROM tblaccemp_employee e ";
            if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            {
                strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOQty IS NULL,0,SOQty))+SUM(if(PickQty IS NULL,0,PickQty))+SUM(if(InvQty IS NULL,0,InvQty)) AS CurrStock FROM tblaccemp_stockcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) s ON e.employeeid=s.employeeid ";
            }
            if (booBudget)
            {
                strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOValue IS NULL,0,SOValue))+SUM(if(PickValue IS NULL,0,PickValue))+SUM(if(InvValue IS NULL,0,InvValue)) AS CurrBudget FROM tblaccemp_budgetcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) b ON e.employeeid=b.employeeid " + "LEFT JOIN tblaccemp_budget t1 ON (t1.BusinessID = e.BusinessID) AND (t1.CompanyID = e.CompanyID) AND (t1.RoleID = e.RoleID) ";
            }
            if (booPoints)
            {
                strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOPoints IS NULL,0,SOPoints))+SUM(if(PickPoints IS NULL,0,PickPoints))+SUM(if(InvPoints IS NULL,0,InvPoints)) AS CurrPoints FROM tblaccemp_pointscard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' AND Year=0 GROUP BY CompanyID, BusinessID, EmployeeID) p ON e.employeeid=p.employeeid " + "LEFT JOIN tblaccemp_points t2 ON (t2.BusinessID = e.BusinessID) AND (t2.CompanyID = e.CompanyID) AND (t2.RoleID = e.RoleID) ";

            }
            if (txtUcode != "")
            {
                strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees WHERE companyid='" + strCompanyID + "' AND businessid='" + busId + "' AND ucodeid='" + txtUcodeDesc.Trim() + "') u ON e.employeeid=u.employeeid";
            }
            if (Convert.ToBoolean(BusinessParam("LimitUsrEmp", busId)))
            {
                allUsers = getPermissionUsers(OrderPermission, userId, busId, txtRole);
                strsql += " JOIN (SELECT DISTINCT employeeid FROM tblonline_userid_employee WHERE CompanyID='" + strCompanyID + "' AND onlineuserid in (" + allUsers + ") AND onlineuserid not in (" + getDenyPermissionUsers(OrderPermission, userId, busId) + ") AND businessid='" + busId + "') onlemp ON e.employeeid=onlemp.employeeid ";
            }
            if (ddlAddress != "")
            {
                strsql += " JOIN tblonline_emp_address ea ON e.businessid=ea.businessid AND e.employeeid=ea.employeeid AND ea.addressid=" + ddlAddress + "";
            }
            if (txtUcodeDesc.Trim() != "")
            {
                strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees t1 left join tblaccemp_ucodes_desc t2 on (t2.UcodeID=t1.UcodeID) WHERE t1.companyid='" + strCompanyID + "' AND t1.businessid='" + busId + "' and if(isnull(t2.Description),t1.UCodeID,t2.Description) like '% " + txtUcodeDesc.Trim() + "%') u1  ON e.employeeid=u1.employeeid";
            }
            strsql += "JOIN  (SELECT DISTINCT pinno, MAX(orderdate) orderdate, orderno FROM `tblsop_salesorder_header` WHERE  custid = '" + busId + "' GROUP BY pinno) sop ON sop.`PinNo`= e.`EmployeeID`";
            strsql += " WHERE e.companyid='" + strCompanyID + "' AND  e.businessid='" + busId + "'";

            if (txtCDepartment != "")
            {
                strsql += " AND e.departmentid='" + txtCDepartment + "'";
            }
            if (txtRole != "")
            {
                strsql += " AND e.roleid='" + txtRole + "'";
            }
            if (txtEmpNo != "")
            {
                strsql += " AND e.employeeid LIKE '" + txtEmpNo + "%'";
            }
            if (txtName != "")
            {
                strsql += " AND concat(forename,' ', surname) LIKE '%" + txtName + "%'";
            }
            if (txtStDate != "")
            {
                var mDate = txtStDate.Split('/');
                StDate = mDate[2] + "-" + mDate[1] + "-" + mDate[0];
                strsql += " AND e.StartDate>='" + StDate + "'";
            }
            strsql += " AND e.EmployeeClosed = '0'";
            //if (Convert.ToBoolean(help.BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())) & Convert.ToInt32(Session["OrderReason"]) == 3)
            if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            {
                strsql += " AND if(s.CurrStock IS NULL,0,s.CurrStock)=0";
                strsql += " ORDER BY e.StartDate DESC, e.employeeid ASC";
            }
            else
            {
                strsql += " ORDER BY e.employeeid";
            }
            try
            {
                //strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            //strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());
            string chkit = ", 0 as chekit, 0 as SelectSeq, 0 as Abort ";
            strsql = strsql.Insert(strsql.IndexOf("FROM"), chkit);
            strsql = strsql.Insert(strsql.IndexOf("FROM"), chkit);
            DataTable dt = new DataTable();
            dt = GetDataTable(strsql);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var empId = dr.ItemArray[0].ToString();
                        //var lm = GetLastOrder(empId);
                        result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[0].ToString(), EmpFirstName = dr.ItemArray[1].ToString(), Department = dr.ItemArray[3].ToString(), LastOrderNo = dr["OrderNo"].ToString() != "" ? Convert.ToInt64(dr["OrderNo"].ToString()) : 0, LastOrderDate = dr["orderdate"].ToString() != "" ? dr["orderdate"].ToString() : "", EmpIsActive = dr.ItemArray[3].ToString() == "0" ? true : false });
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return result;
        }

        #endregion

        #region  GetLastOrder
        public LastOrderModel GetLastOrder(string empId)
        {
            LastOrderModel lm = new LastOrderModel();

            lm.LastOrderNO = _salesHead.Exists(x => x.PinNo.Trim().ToLower() == empId.Trim().ToLower()) ? _salesHead.GetAll(x => x.PinNo.Trim().ToLower() == empId.Trim().ToLower()).OrderByDescending(s => s.OrderDate).First().OrderNo : 0;

            lm.LastOrderDate = _salesHead.Exists(x => x.PinNo.Trim().ToLower() == empId.Trim().ToLower()) ? _salesHead.GetAll(x => x.PinNo.Trim().ToLower() == empId.Trim().ToLower()).OrderByDescending(s => s.OrderDate).First().OrderDate.Value : DateTime.Now;
            return lm;
        }
        #endregion

        #region GetEmployee
        public List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "", string RequirePermissionUSR = "")
        {
            List<EmployeeViewModel> result1 = new List<EmployeeViewModel>();
            //var result = GetEmployeeByProcedure(busId, userId);
            //result1 = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            //if(result1.Count==0 && txtRole.ToLower()!="user")
            //{
            //    var result2 = GetUnmappedRoleEmployeesSp(busId, userId, OrderPermission);
            //    result1= result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            //}
            //return result1;
            //var dataList = list.Split(',');
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            string strsql = "";
            bool booBudget = false;
            string StDate = "";
            string EdDate = "";
            string CustBudgetType = "";
            string CustBudgetPeriodDays = "";
            string allUsers = "";
            bool booPoints = false;
            var role = _user.GetAll(x => x.UserName == userId && x.BusinessID == busId && x.Active.ToUpper() == "Y").ToList().First().AccessID;
            //CustBudgetType = BusinessParam("BudgetType", busId);
            //CustBudgetPeriodDays = BusinessParam("BudgetPeriodDays", busId);
            booBudget = Convert.ToBoolean(BusinessParam("BUDGETREQ", busId));
            booPoints = Convert.ToBoolean(BusinessParam("POINTSREQ", busId));
            strsql = "SELECT `t1`.`CompanyID` CompanyId,`t1`.`EmployeeID` EmployeeId,`t1`.`BusinessID` BuisnessId,`t3`.`Department` Department,`t1`.`Forename` EmpFirstName,`t1`.`Surname` EmpLastName,`t1`.`StartDate` StartDate,`t1`.`EndDate` EndDate ,GROUP_CONCAT(DISTINCT `t2`.`UCodeID` ORDER BY `t2`.`UCodeID`) AS EmpUcodes , tr.`RoleName` AS RoleName , MAX(`soh`.`OrderDate`) OrderDate,MAX(`soh`.`OrderNo`) OrderNo,Tpts.TotalUodePoints AS EntPoints,vu.totUsed,`ro`.`LastOrder` ,`ro`.`NextOrder`,us.`Active` usractive, t1.`EmployeeClosed` empactive FROM `tblaccemp_employee`  t1   LEFT JOIN `tblaccemp_employee_rollout` ro ON  (`t1`.`CompanyID` = `ro`.`CompanyID`)      AND(  `t1`.`EmployeeID` = `ro`.`EmployeeID`  )  AND(`t1`.`BusinessID` = `ro`.`BusinessID`) LEFT JOIN `tblusers` us ON t1.`EmployeeID`= us.`UserName` AND t1.`BusinessID`=us.`BusinessID`   LEFT JOIN (SELECT th1.`CompanyID`, th1.`BusinessID`, th1.`EmployeeID`, (IF(ISNULL(t3.TotalPoints), IF(ISNULL(t2.`TotalPoints`), 0, t2.`TotalPoints`), t3.TotalPoints)) AS TotalUodePoints  FROM  `tblaccemp_ucodesemployees` th1 LEFT JOIN tblaccemp_rollout_ucode_ref tf ON th1.CompanyID = tf.CompanyID AND th1.BusinessID = tf.BusinessID AND th1.UcodeID = tf.EmpUCodeID  LEFT JOIN `tblaccemp_ucodepoints` t2 ON th1.`CompanyID` = t2.`CompanyID` AND th1.`BusinessID` = t2.`BusinessID` AND th1.`UCodeID` = t2.`UcodeID` AND NOW() BETWEEN t2.`FromDate` AND t2.`ToDate`  LEFT JOIN `tblaccemp_ucodepoints` t3 ON tf.`CompanyID` = t3.`CompanyID`  AND tf.`BusinessID` = t3.`BusinessID` AND tf.`ROUCodeID` = t3.`UcodeID` AND NOW() BETWEEN t3.`FromDate`  AND t3.`ToDate`  WHERE th1.CompanyID = '" + cmpId + "' AND th1.BusinessID = '" + busId + "' GROUP BY th1.`CompanyID`, th1.`BusinessID`, th1.`EmployeeID`) Tpts ON Tpts.CompanyID = t1.CompanyID AND Tpts.BusinessID = t1.BusinessID AND Tpts.EmployeeID = t1.EmployeeID LEFT JOIN (SELECT SUM(totsopoints) totUsed, employeeid, businessid FROM `view_totalpointsused` GROUP BY employeeid) vu ON vu.employeeid = t1.`EmployeeID` AND vu.businessid = t1.BusinessID  LEFT JOIN `tblaccemp_ucodesemployees` t2 ON (`t1`.`CompanyID`=`t2`.`CompanyID`) AND(`t1`.`EmployeeID`=`t2`.`EmployeeID`) AND(`t1`.`BusinessID`=`t2`.`BusinessID`) LEFT JOIN `tblaccemp_departments` `t3` ON(`t1`.DepartmentID =`t3`.DepartmentID) AND(`t1`.`CompanyID`=`t3`.`CompanyID` ) AND(`t1`.`BusinessID`=`t3`.`BusinessID`) LEFT JOIN `tblroles` tr ON tr.`RoleID`= t1.`roleid` LEFT JOIN `tblsop_salesorder_header` soh ON  `t1`.`EmployeeID` = `soh`.`PinNo` AND soh.custid = t1.BusinessID AND t1.companyid = soh.companyid";

            //strsql = "SELECT e.employeeid, concat(concat(e.forename,' '),e.surname) as employeename, e.EmployeeClosed AS `STATUS` ";
            //if (booBudget)
            //{
            //    strsql = strsql + ",bud.Budget as EntBudget,b.CurrBudget";
            //}
            //if (booPoints)
            //{
            //    strsql = strsql + ",tp.TotalPoints as EntPoints,p.CurrPoints ";
            //}
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql = strsql + ",if(s.CurrStock IS NULL,0,s.CurrStock) as empStock ";
            //}
            //strsql = strsql + ",t1.departmentid FROM tblaccemp_employee t1 ";
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOQty IS NULL,0,SOQty))+SUM(if(PickQty IS NULL,0,PickQty))+SUM(if(InvQty IS NULL,0,InvQty)) AS CurrStock FROM tblaccemp_stockcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) s ON t1.employeeid=s.employeeid ";
            //}
            //if (booBudget)
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOValue IS NULL,0,SOValue))+SUM(if(PickValue IS NULL,0,PickValue))+SUM(if(InvValue IS NULL,0,InvValue)) AS CurrBudget FROM tblaccemp_budgetcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) b ON t1.employeeid=b.employeeid " + "LEFT JOIN tblaccemp_budget bud ON (t1.BusinessID = t1.BusinessID) AND (bud.CompanyID = t1.CompanyID) AND (bud.RoleID = t1.RoleID) ";
            //}
            //if (booPoints)
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOPoints IS NULL,0,SOPoints))+SUM(if(PickPoints IS NULL,0,PickPoints))+SUM(if(InvPoints IS NULL,0,InvPoints)) AS CurrPoints FROM tblaccemp_pointscard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' AND Year=0 GROUP BY CompanyID, BusinessID, EmployeeID) tp ON t1.employeeid=p.employeeid " + "LEFT JOIN tblaccemp_points tp ON (tp.BusinessID = t1.BusinessID) AND (tp.CompanyID = t1.CompanyID) AND (tp.RoleID = t1.RoleID) ";

            //}
            //if (txtUcode != "")
            //{
            //    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees WHERE companyid='" + strCompanyID + "' AND businessid='" + busId + "' AND ucodeid='" + txtUcodeDesc.Trim() + "') u ON t1.employeeid=u.employeeid";
            //}
            if (role.ToLower().Trim() != "admin")
            {
                if (Convert.ToBoolean(BusinessParam("LimitUsrEmp", busId)))
                {
                    if (RequirePermissionUSR.ToLower() == "show" && RequirePermissionUSR != "")
                    {
                        allUsers = getPermissionUsers(OrderPermission, userId, busId, role);
                        strsql += " JOIN (SELECT DISTINCT companyid,businessid,employeeid  FROM tblonline_userid_employee WHERE CompanyID='" + strCompanyID + "' AND onlineuserid in (" + allUsers + ") AND onlineuserid not in (" + getDenyPermissionUsers(OrderPermission, userId, busId) + ") AND businessid='" + busId + "') onlemp ON t1.companyid=onlemp.companyid AND t1.Businessid=onlemp.BusinessID AND t1.employeeid=onlemp.employeeid";
                    }
                }
            }
            //commented by sasi(23-09-20)
            //strsql += " WHERE t1.CompanyID = '" + cmpId + "' AND t1.`BusinessID`= '" + busId + "' AND t1.`EmployeeClosed`= 0 GROUP BY`t1`.`CompanyID`,`t1`.`EmployeeID`,`t1`.`BusinessID`,`t3`.`Department`,`t1`.`Forename`,`t1`.`Surname`,`t1`.`StartDate`,`t1`.`EndDate`";
            strsql += " WHERE t1.CompanyID = '" + cmpId + "' AND t1.`BusinessID`= '" + busId + "' GROUP BY`t1`.`CompanyID`,`t1`.`EmployeeID`,`t1`.`BusinessID`,`t3`.`Department`,`t1`.`Forename`,`t1`.`Surname`,`t1`.`StartDate`,`t1`.`EndDate`";

            //if (ddlAddress != "")
            //{
            //    strsql += " JOIN tblonline_emp_address ea ON t1.businessid=ea.businessid AND t1.employeeid=ea.employeeid AND ea.addressid=" + ddlAddress + "";
            //}
            //if (txtUcodeDesc.Trim() != "")
            //{
            //    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees bud left join tblaccemp_ucodes_desc t2 on (t2.UcodeID=bud.UcodeID) WHERE bud.companyid='" + strCompanyID + "' AND bud.businessid='" + busId + "' and if(isnull(t2.Description),bud.UCodeID,t2.Description) like '% " + txtUcodeDesc.Trim() + "%') u1  ON t1.employeeid=u1.employeeid";
            //}
            //strsql += " WHERE t1.companyid='" + strCompanyID + "' AND  t1.businessid='" + busId + "'";

            //if (txtCDepartment != "")
            //{
            //    strsql += " AND t1.departmentid='" + txtCDepartment + "'";
            //}
            //if (txtRole != "")
            //{
            //    strsql += " AND t1.roleid='" + txtRole + "'";
            //}
            //if (txtEmpNo != "")
            //{
            //    strsql += " AND t1.employeeid LIKE '" + txtEmpNo + "%'";
            //}
            //if (txtName != "")
            //{
            //    strsql += " AND concat(forename,' ', surname) LIKE '%" + txtName + "%'";
            //}
            //if (txtStDate != "")
            //{
            //    var mDate = txtStDate.Split('/');
            //    StDate = mDate[2] + "-" + mDate[1] + "-" + mDate[0];
            //    strsql += " AND t1.StartDate>='" + StDate + "'";
            //}
            //strsql += " AND t1.EmployeeClosed = '0'";
            ////if (Convert.ToBoolean(help.BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())) & Convert.ToInt32(Session["OrderReason"]) == 3)
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql += " AND if(s.CurrStock IS NULL,0,s.CurrStock)=0";
            //    strsql += " ORDER BY t1.StartDate DESC, t1.employeeid ASC";
            //}
            //else
            //{
            //    strsql += " ORDER BY t1.employeeid";
            //}
            //try
            //{
            //    //strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());
            //}
            //catch (Exception e)
            //{

            //}
            //strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());

            DataTable dt = new DataTable();
            dt = GetDataTable(strsql);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    result1 = dt.AsEnumerable().Select(s => new EmployeeViewModel { EmployeeId = s.ItemArray[1].ToString(), EmpFirstName = s.ItemArray[4].ToString(), Department = s.ItemArray[3].ToString(), EmpLastName = s.ItemArray[5].ToString(), EmpUcodes = s.ItemArray[8].ToString(), StartDate = DateTime.Parse(s.ItemArray[6].ToString()), EndDate = DateTime.Parse(s.ItemArray[7].ToString()), role = s.ItemArray[9].ToString(), LastOrderDate = s.ItemArray[10].ToString(), LastOrderNo = s.ItemArray[11].ToString() != "" ? Convert.ToInt64(s.ItemArray[11].ToString()) : 0, TotalPoints = s.ItemArray[12].ToString() == "" ? 0 : Convert.ToInt32(s.ItemArray[12].ToString()), PointsUsed = s.ItemArray[13].ToString() == "" ? 0 : Convert.ToInt32(s.ItemArray[13].ToString()), NextOrderDate = s.ItemArray[15].ToString() != "" ? DateTime.Parse(s.ItemArray[15].ToString()).ToString("dd-MM-yyyy") : "", LastOrderDate1 = s.ItemArray[14].ToString() != "" ? DateTime.Parse(s.ItemArray[14].ToString()).ToString("dd-MM-yyyy") : "", UserActive = s["usractive"].ToString() != "" ? s["usractive"].ToString() == "Y" ? true : false : false, EmpIsActive = s["empactive"].ToString() != "" ? Convert.ToInt32(s["empactive"].ToString()) == 0 ? true : false : false }).ToList();

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    var empId = dr.ItemArray[0].ToString();
                    //    result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[0].ToString(), EmpFirstName = dr.ItemArray[1].ToString(), Department = dr.ItemArray[3].ToString(), EmpIsActive = dr.ItemArray[3].ToString() == "0" ? true : false });
                    //}
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);

            }
            result = result1.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            return result;

        }
        #endregion

        #region GetUnmappedRoleEmployeesSp
        public List<EmployeeViewModel> GetUnmappedRoleEmployeesSp(string busId, string userId = "", string permission = "")
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            string onlineEmps = getPermissionUsers_Old(permission, userId, busId);
            var role = _user.GetAll(x => x.UserName == userId && x.BusinessID == busId && x.Active.ToUpper() == "Y").ToList().First().AccessID;
            string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            string sSqry = "";
            sSqry = "CALL `GetUnmappedRoleEmployeesSp`('" + strCompanyID + "','" + busId + "'," + onlineEmps + ")";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var empId = dr.ItemArray[0].ToString();
                        result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[1].ToString(), EmpFirstName = dr.ItemArray[4].ToString(), Department = dr.ItemArray[3].ToString(), EmpLastName = dr.ItemArray[5].ToString(), EmpUcodes = dr.ItemArray[8].ToString(), StartDate = DateTime.Parse(dr.ItemArray[6].ToString()), EndDate = DateTime.Parse(dr.ItemArray[7].ToString()), role = dr.ItemArray[9].ToString(), LastOrderDate = dr["OrderDate"].ToString(), LastOrderNo = dr["OrderNo"].ToString() != "" ? Convert.ToInt64(dr["OrderNo"].ToString()) : 0 });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetEmployeeByProcedure


        public List<EmployeeViewModel> GetEmployeeByProcedure(string busId, string userId = "")
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();

            var role = _user.GetAll(x => x.UserName == userId && x.BusinessID == busId && x.Active.ToUpper() == "Y").ToList().First().AccessID;
            string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            string sSqry = "";
            sSqry = "CALL `GetEmployeeByRolesLast`('" + strCompanyID + "','" + busId + "','" + userId + "','" + role + "')";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var empId = dr.ItemArray[0].ToString();
                        result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[1].ToString(), EmpFirstName = dr.ItemArray[4].ToString(), Department = dr.ItemArray[3].ToString(), EmpLastName = dr.ItemArray[5].ToString(), EmpUcodes = dr.ItemArray[8].ToString(), StartDate = DateTime.Parse(dr.ItemArray[6].ToString()), EndDate = DateTime.Parse(dr.ItemArray[7].ToString()), role = dr.ItemArray[9].ToString(), LastOrderDate = dr["OrderDate"].ToString(), LastOrderNo = dr["OrderNo"].ToString() != "" ? Convert.ToInt64(dr["OrderNo"].ToString()) : 0 });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region getDataTable
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (Exception e)
            {
                e.Data["sql"] = sql;
                throw (e);
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion


        #region UserCtrl

        public string DefaultEmployee(string companyid, string userid, string custid)
        {
            string result = "";
            string sql = "";
            int eCnt = 0;
            string mDefaultEmp = "";
            sql = "SELECT COUNT(*) FROM tblonline_userid_employee WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
            eCnt = +getCount(sql);
            if (eCnt == 1)
            {
                sql = "SELECT EmployeeID FROM tblonline_userid_employee WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
                mDefaultEmp = GetValue(sql);
            }
            else if (eCnt <= 0)
            {
                if (mDefaultEmp == "")
                {
                    sql = "SELECT COUNT(*) FROM tblonline_emp_address WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
                    eCnt = +getCount(sql);
                    if (eCnt == 1)
                    {
                        sql = "SELECT EmployeeID FROM tblonline_emp_address WHERE CompanyID='" + companyid + "' AND onlineuserid='" + userid + "' AND businessid='" + custid + "'";
                        mDefaultEmp = GetValue(sql);
                    }
                }

                return mDefaultEmp;
            }
            return result;
        }
        public string SetDefaultWarehouse(string userId, string businessId)
        {
            string wareHouse = "";
            wareHouse = BusinessParam("Warehouse", businessId.Trim().ToUpper());
            wareHouse = wareHouse == "" ? UserParam("Warehouse", userId.ToUpper().Trim()) : wareHouse;
            wareHouse = wareHouse == "" ? CompanyParam("Warehouse", System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString()) : wareHouse;
            return wareHouse;
        }

        public long Getnextno(string itmName, MySqlConnection conn)
        {
            string sSqry = "SELECT Autonumber FROM `tblgen_nextno` WHERE itemname ='" + itmName + "'";
            MySqlCommand cmd = new MySqlCommand(sSqry, conn);
            long result = 0;
            result = cmd.ExecuteScalar() != null ? Convert.ToInt64(cmd.ExecuteScalar()) : 0;
            if (result > 0)
            {
                var incVal = result + 1;
                sSqry = "Update tblgen_nextno set Autonumber=" + incVal + " where itemname ='" + itmName + "'";
                MySqlCommand cmd1 = new MySqlCommand(sSqry, conn);
                cmd1.ExecuteNonQuery();
            }
            return result;
        }
        public string BusinessParam(string paramId, string businessId)
        {
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            var data = "";
            data = _busSetValues.Exists(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId) ? _busSetValues.GetAll(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId).First().Value : "";
            if (data != "" && data != null)
            {
                return data;
            }
            else
            {
                data = _busSettings.Exists(x => x.SettingID == paramId && x.BusType.ToUpper() == "CUS") ? _busSettings.GetAll(x => x.SettingID == paramId && x.BusType.ToUpper() == "CUS").First().DefaultValue : "";
                if (data != "" && data != null)
                {
                    return data;
                }

            }
            return "";
        }

        public string CompanyParam(string paramID, string companyId)
        {
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            var data = "";
            data = _cmpDefaults.Exists(x => x.CompanyID == companyId & x.ParamID == paramID) ? _cmpDefaults.GetAll(x => x.CompanyID == companyId & x.ParamID == paramID).First().Value : "";
            if (data != "" && data != null)
            {
                return data;
            }
            else
            {
                data = getCompanyParam(paramID);
                if (data != "" && data != null)
                {
                    return data;
                }
            }
            return "";
        }
        public string UserParam(string paramId, string userId)
        {
            var result = "";
            try
            {
                var s = _genParameter.GetAll().ToList();
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            result = _genUserDefaults.Exists(x => x.ParamID.ToLower() == paramId.ToLower() && x.UserID == userId) ? _genUserDefaults.GetAll(x => x.ParamID.ToLower() == paramId.ToLower() && x.UserID == userId).First().Param_Value : "";
            if (result != "" && result != null)
            {
                return result;
            }
            else
            {
                result = _genParameter.GetAll(x => x.ParamID.ToLower() == paramId.ToLower()).First().DefaultValue;
                if (result != "" && result != null)
                {
                    return result;
                }
            }
            return result;
        }

        #endregion

        #region IsSiteCode
        public bool IsSiteCode(string custId)
        {
            bool result = false;
            string strSQl = "";
            string sortFld = "t1.SiteName,' | ',t1.SiteCode";
            string sortString = BusinessParam("SITECODE_SORTING", custId);
            if (sortString == "")
            {
                sortString = "SiteName";
            }
            if (sortString == "SiteCode")
            {
                sortFld = "t1.SiteCode,' | ',t1.SiteName";
            }
            strSQl = "SELECT DISTINCT t1.SiteCode, CAST(Concat(" + sortFld + ") AS CHAR) AS SiteCodeInfo  FROM tblonlinesop_sitecode t1  WHERE t1.Businessid='" + custId + "' ORDER BY t1." + sortString + " ASC";
            return result = GetDataTable(strSQl).Rows.Count > 0 ? true : false;
        }
        #endregion


        #region GetCustRefVisiblity

        public bool GetCustRefVisiblity(string busId)
        {
            bool result = false;
            string strSql = "SELECT DISTINCT OrderRef,CONCAT(OrderRef,' | ',NominalCode) AS OrderNomRef FROM tblbus_online_orderref_nominal WHERE businessID='" + busId + "' ORDER BY OrderRef";
            return GetDataTable(strSql).Rows.Count > 3 ? true : false;
        }
        #endregion

        #region UpdateEmployee
        public int UpdateEmployee(string cmpId, int addressId, string employeeId, string busId)
        {
            var result = -1;
            MySqlConnection CONN = new MySqlConnection(ConnectionString);
            try
            {
                string sQry = "Update tblonline_emp_address set AddressId=" + addressId + " Where EmployeeId='" + employeeId + "' and BusinessId='" + busId + "'";
                CONN.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, CONN);
                result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    string sQry1 = "Insert into tblonline_emp_address(CompanyId,AddressId,EmployeeId,BusinessId)values('" + cmpId + "'," + addressId + ",'" + employeeId + "' ,'" + busId + "')";
                    MySqlCommand cmd1 = new MySqlCommand(sQry1, CONN);
                    result = cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                CONN.Close();
            }
            return result;
        }
        #endregion

        #region DeleteEmployee
        public int DeleteEmployee(string Ucode, string employeeId, string busId)
        {
            var result = 0;
            try
            {
                string sQry = "Delete from tblaccemp_ucodesemployees where Ucode='" + Ucode + "' and EmployeeID='" + employeeId + "' and BusinessID='" + busId + "'";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return result;
        }
        #endregion

        #region getAddressID

        public int GetAddressId(string businessId, string empID)
        {
            int addId = 0;
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetBusAddressId`('" + empID + "','" + businessId + "')";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            addId = Convert.ToInt32(dr.ItemArray[0].ToString());
                        }
                    }
                    return addId;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return addId;
        }

        #endregion

        #region GetEmployeeById
        public EmployeeViewModel GetEmployeeById(string businessId, string empID)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetEmployeebyId`('" + businessId + "','" + empID + "')";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow data in dt.Rows)
                        {
                            emp.EmployeeId = data.ItemArray[1].ToString();
                            emp.EmpFirstName = data.ItemArray[4].ToString();
                            emp.Department = data.ItemArray[3].ToString();
                            emp.EmpLastName = data.ItemArray[5].ToString();
                            emp.StartDate = DateTime.Parse(data.ItemArray[6].ToString());
                            emp.EndDate = DateTime.Parse(data.ItemArray[7].ToString());
                            emp.EmpUcodes = data.ItemArray[8].ToString();
                            var s = data.ItemArray[9].ToString() == "0" ? true : false;
                            emp.EmpIsActive = Convert.ToBoolean(data.ItemArray[9].ToString()) == false ? true : false;
                        }
                    }
                    return emp;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return emp;
        }
        #endregion 

        #region GetEmployeeDetails
        public List<EmployeeViewModel> getEmployeeDetails(string BuisnessId)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetEmployeeDetailsProcedure`('" + BuisnessId + "')";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            result.Add(new EmployeeViewModel
                            {
                                Department = dr.ItemArray[3].ToString(),
                                EmpFirstName = dr.ItemArray[4].ToString(),
                                EmpLastName = dr.ItemArray[5].ToString(),
                                EmployeeId = dr.ItemArray[1].ToString(),
                                EmpUcodes = dr.ItemArray[8].ToString(),
                                EndDate = DateTime.Parse(dr.ItemArray[7].ToString()),
                                StartDate = DateTime.Parse(dr.ItemArray[6].ToString()),
                                BuisnessId = dr.ItemArray[2].ToString(),
                                CompanyId = dr.ItemArray[0].ToString()
                                //Address = getEmployeeAddress(dr.ItemArray[1].ToString(), BuisnessId)
                            });
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return result;
        }
        #endregion

        #region getstyleviewmodel

        public List<styleViewmodel> GetStyleViewModel(string Template, string busId)
        {
            List<styleViewmodel> svm = new List<styleViewmodel>();
            string sSqry = "CALL GetTemplateView('" + busId + "','" + Template + "')";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        svm.Add(new styleViewmodel
                        {
                            StyleID = dr[2].ToString(),
                            OriginalStyleid = dr[1].ToString(),
                            Description = dr[3].ToString(),
                            StyleImage = dr[4].ToString(),
                            ProductGroup = Convert.ToInt32(dr[5].ToString())
                        });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            //foreach (var item in _customerOrderTemplate.GetAll(x => x.Template == Template && x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).Select(x => new { x.Style }).Distinct().ToList())
            //{
            //    svm.Add(new styleViewmodel
            //    {
            //        StyleID = ,
            //        OriginalStyleid = item.Style,
            //        Description = _fskStyle.GetAll(x => x.StyleID == item.Style).First().Description,
            //        StyleImage = _fskStyle.GetAll(x => x.StyleID == item.Style).First().StyleImage,
            //        ProductGroup = _fskStyle.GetAll(x => x.StyleID == item.Style).First().Product_Group.Value,

            //    });
            //}

            return svm;
        }
        public string GetStyleFits(string style)
        {
            string result = "";
            string freTxt = "";
            freTxt = _fskStyleFreetext.Exists(x => x.StyleId.Trim().ToLower() == style.Trim().ToLower()) ? _fskStyleFreetext.GetAll(x => x.StyleId.Trim().ToLower() == style.Trim().ToLower()).First().FreeText : "";
            if (freTxt != "")
            {
                result = _styleByFreetext.Exists(x => x.FreeText.ToLower().Trim() == freTxt.ToLower().Trim()) ? _styleByFreetext.GetAll(x => x.FreeText.ToLower().Trim() == freTxt.ToLower().Trim()).First().StyleID : style;
            }
            else
            {
                result = style;
            }
            return result;
        }
        public List<int> GetProductGroup(string Template)
        {
            List<int> svm = new List<int>();
            foreach (var item in _customerOrderTemplate.GetAll(x => x.Template == Template).Select(x => new { x.Style }).Distinct().ToList())
            {
                svm.Add(_fskStyle.GetAll(x => x.StyleID == item.Style).First().Product_Group.Value);
            }

            return svm;
        }
        #endregion

        #region GetEmployeeDetailsForTemplates

        public List<EmployeeViewModel> getEmployeeDetailsTemplates(string BuisnessId)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetEmployeeTemplateProcedure`('" + BuisnessId + "')";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            result.Add(new EmployeeViewModel
                            {
                                Department = dr.ItemArray[3].ToString(),
                                EmpFirstName = dr.ItemArray[4].ToString(),
                                EmpLastName = dr.ItemArray[5].ToString(),
                                EmployeeId = dr.ItemArray[1].ToString(),
                                EndDate = DateTime.Parse(dr.ItemArray[7].ToString()),
                                StartDate = DateTime.Parse(dr.ItemArray[6].ToString()),
                                BuisnessId = dr.ItemArray[2].ToString(),
                                CompanyId = dr.ItemArray[0].ToString()
                            });
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return result;
        }

        #endregion

        #region GetEmployeeDetailsForTemplates

        public EmployeeViewModel getEmployeeDetailsTemplatesById(string BuisnessId, string EmpID)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetEmployeeTemplateById`('" + BuisnessId + "','" + EmpID + "')";
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sQry, con);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            result.Department = dr.ItemArray[3].ToString();
                            result.EmpFirstName = dr.ItemArray[4].ToString();
                            result.EmpLastName = dr.ItemArray[5].ToString();
                            result.EmployeeId = dr.ItemArray[1].ToString();
                            result.EndDate = DateTime.Parse(dr.ItemArray[7].ToString());
                            result.StartDate = DateTime.Parse(dr.ItemArray[6].ToString());
                            result.BuisnessId = dr.ItemArray[2].ToString();
                            result.CompanyId = dr.ItemArray[0].ToString();
                            result.EmpIsActive = dr.ItemArray[8].ToString() == "0" ? true : false;
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return result;
        }

        #endregion

        #region employeeAddress
        public string getEmployeeAddress(string EmpId, string BuisnessId)
        {
            string result = "";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetEmployeeAddressProcedure`('" + EmpId + "','" + BuisnessId + "')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, con);

                result = (cmd.ExecuteScalar()).ToString();
                if (result == "")
                {
                    string usrQry = "SELECT OnlineUserId FROM `tblonline_emp_address` t3 WHERE t3.`BusinessId` = '" + BuisnessId + "' AND t3.`OnlineUserId` IN (SELECT t1.`OnlineUserID` FROM `tblonline_userid_employee` t1 JOIN tblusers t2 ON t1.`OnlineUserID` = t2.`UserName` AND t1.`BusinessID` = t2.`BusinessID` WHERE t1.Businessid = '" + BuisnessId + "' AND t1.EmployeeID = '" + EmpId + "' AND t1.OnlineUserID <> '" + EmpId + "')";
                    MySqlCommand cmd1 = new MySqlCommand(usrQry, con);
                    string user = (cmd1.ExecuteScalar()).ToString();
                    if (user != null && user != "")
                    {
                        sQry = "CALL `GetEmployeeAddressProcedure`('" + user + "','" + BuisnessId + "')";
                        MySqlCommand cmd3 = new MySqlCommand(sQry, con);
                        result = (cmd3.ExecuteScalar()).ToString();
                    }

                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        #endregion

        #region GetAllPreviousData
        public string GetAllPreviousData(string EmpId, string BuisnessId, string styleId, long inBasket = 0)
        {
            string result = "";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetPreviousDataByEmployee`('" + styleId + "','" + BuisnessId + "','" + EmpId + "')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        result = "<tr><td>Issued: " + dr.ItemArray[4].ToString() + "</td></tr><tr><td>In Basket: " + inBasket + "</td></tr><tr><td>Order No: " + dr.ItemArray[1].ToString() + " Order Date:" + DateTime.Parse(dr.ItemArray[3].ToString()).ToString("dd-MM-yyyy") + "</td></tr></table>";
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region getReqData
        public string GetReqData(string StyleID)
        {
            string lblValue = "";
            StyleID = StyleID.Contains(",") ? StyleID.Split(',')[0] : StyleID;
            lblValue = _fskSetValues.Exists(x => x.StyleID == StyleID && x.SettingID == "REQDATA1") ? _fskSetValues.GetAll(x => x.StyleID == StyleID && x.SettingID == "REQDATA1").First().Value : "";
            if (lblValue == "")
            {
                try
                {
                    lblValue = _fskSettings.Exists(x => x.SettingID == "REQDATA1") ? _fskSettings.GetAll(x => x.SettingID == "REQDATA1").First().DefaultValue : "";
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
            }
            return lblValue;
        }
        #endregion 

        #region GetAllPreviousData
        public PreviousQty GetPreviousHistory(string EmpId, string BuisnessId, string styleId)
        {
            PreviousQty result = new PreviousQty();
            result.OrdQty = 0;
            result.Size = "";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "SELECT t2.`SizeID`,t2.`OrdQty`  FROM `tblsop_salesorder_header` t1 JOIN `tblsop_salesorder_detail` t2 ON (t1.`OrderNo`= t2.`OrderNo` ) WHERE t1.`PinNo`= '" + EmpId + "' AND t1.`CustID`= '" + BuisnessId + "' AND t2.`StyleID`= '" + styleId + "' AND t1.`OrderType`= 'SO' ORDER BY t1.`OrderNo` DESC LIMIT 1";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, con);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Size = reader.GetString(0) != "" ? reader.GetString(0) : "";
                        result.OrdQty = reader.GetString(1) != "" ? Convert.ToInt32(reader.GetString(1)) : 0;
                    }


                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region getFitallocStyle
        public string GetFitAllocString(string freeText)
        {
            string result = "";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "Select StyleId from styleby_freetextview Where FreeText='" + freeText + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, con);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetString(0);
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        #endregion

        #region Getqty
        public int Getqty(string BusinessId = "", string ParentStyle = "", string StyleId = "", long qty = 0)
        {
            int quanty = 1;
            int assmId = 0;
            try
            {
                var S = Convert.ToSByte(true);
                if (_assemblyHeader.Exists(x => x.StyleID == ParentStyle && x.CustID == BusinessId && x.Live == true && x.Enabled == true))
                {
                    assmId = _assemblyHeader.GetAll(x => x.StyleID == ParentStyle && x.CustID == BusinessId && x.Live == true && x.Enabled == true).FirstOrDefault().AssemblyID;
                }
                else if (_assemblyHeader.Exists(x => x.StyleID == ParentStyle && x.CustID.ToLower() == "all" && x.Live == true && x.Enabled == true))
                {
                    assmId = _assemblyHeader.GetAll(x => x.StyleID == ParentStyle && x.CustID.ToLower() == "all" && x.Live == true && x.Enabled == true).FirstOrDefault().AssemblyID;
                }
                int qtity = _assemblyDetail.Exists(x => x.StyleID == StyleId && x.AssemblyID == assmId) ? _assemblyDetail.GetAll(x => x.StyleID == StyleId && x.AssemblyID == assmId).FirstOrDefault().Qty.Value : 0;
                quanty = qtity;
                return quanty;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return quanty;
        }
        #endregion
        #endregion

        #region GetIssuedLst

        public List<IssuedQtyModel> GetIssuedList(string busId, string color, string empId, string style)
        {
            var result = new List<IssuedQtyModel>();
            string qry = "SELECT `tblaccemp_stockcard`.`BusinessID` AS `BusinessID`, `tblaccemp_stockcard`.`EmployeeID` AS `EmployeeID`,  `tblaccemp_stockcard`.`StyleID`    AS `StyleID`, `tblaccemp_stockcard`.`ColourID`   AS `ColourID`, IF(ISNULL(`tblaccemp_stockcard`.`SOQty`), 0,`tblaccemp_stockcard`.`SOQty`) SOQTY , IF(ISNULL(`tblaccemp_stockcard`.`PickQty`), 0,`tblaccemp_stockcard`.`PickQty`) PICKQTY, IF(ISNULL(`tblaccemp_stockcard`.`InvQty`), 0,`tblaccemp_stockcard`.`InvQty`) INVQTY FROM `tblaccemp_stockcard` WHERE(`tblaccemp_stockcard`.`Year` = 0 AND `tblaccemp_stockcard`.`BusinessID`='" + busId + "' AND `tblaccemp_stockcard`.`EmployeeID`='" + empId + "' AND `tblaccemp_stockcard`.`StyleID`='" + style + "' AND `tblaccemp_stockcard`.`ColourID`='" + color + "') GROUP BY `tblaccemp_stockcard`.`BusinessID`,`tblaccemp_stockcard`.`EmployeeID`,`tblaccemp_stockcard`.`StyleID`,`tblaccemp_stockcard`.`ColourID`";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new IssuedQtyModel { Invqty = Convert.ToInt32(dr["INVQTY"].ToString()), Pickqty = Convert.ToInt32(dr["PICKQTY"].ToString()), SOqty = Convert.ToInt32(dr["SOQTY"].ToString()) });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion


        #region Employee
        public int GetDeliveryAddressId(string employeeId, string busId, string onlineUserId)
        {

            var result = 0;
            string sSqry = employeeId != "" ? "SELECT AddressId FROM `tblonline_emp_address` WHERE employeeid='" + employeeId + "' and BusinessId='" + busId + "'" : "SELECT AddressId FROM `tblonline_emp_address` WHERE OnlineUserId='" + onlineUserId + "'  and BusinessId='" + busId + "'";
            var LstOnlineId = _onlineUserIdEmployee.Exists(x => x.BusinessID == busId && x.EmployeeID == employeeId) ? _onlineUserIdEmployee.GetAll(x => x.BusinessID == busId && x.EmployeeID == employeeId).Select(x => x.OnlineUserID).ToList() : new List<string>();
            string sQry = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    MySqlCommand cmd1 = new MySqlCommand("SELECT AddressId FROM `tblonline_emp_address` WHERE OnlineUserId='" + onlineUserId + "'", conn);
                    result = cmd1.ExecuteScalar() != null ? Convert.ToInt32(cmd1.ExecuteScalar()) : 0;
                    if (result > 0)
                    {
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                if (LstOnlineId.Count > 0)
                {
                    if (LstOnlineId.Contains(employeeId))
                    {
                        sQry = "CALL `GetEmpAddressId`('" + employeeId + "','" + busId + "')";
                        MySqlCommand cmd = new MySqlCommand(sQry, conn);
                        result = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                        if (result > 0)
                        {
                            return result;
                        }
                    }
                    foreach (var item in LstOnlineId)
                    {
                        sQry = "CALL `GetEmpAddressId`('" + item + "','" + busId + "')";
                        MySqlCommand cmd = new MySqlCommand(sQry, conn);
                        result = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                        if (result > 0)
                        {
                            return result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region usermodule

        public List<PermissionList> PermissionSettings(string busId, string userId, string controlId, string accessId)
        {

            List<PermissionList> permisson = new List<PermissionList>(); ;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string sSqry = "";
            sSqry = "SELECT * FROM tblpermission_settings_users WHERE companyid='" + cmpId + "' AND BusinessID='" + busId + "' AND UserID='" + userId + "'";
            if (userId != "")
            {
                conn.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            permisson.Add(new PermissionList { ControlId = dr["ControlID"].ToString(), Permission = dr["Permission"].ToString() });
                        }
                    }

                    sSqry = "SELECT * FROM tblpermission_settings WHERE companyid='" + cmpId + "' AND BusinessID='" + busId + "' AND AccessID='" + accessId + "'";
                    MySqlCommand cmd1 = new MySqlCommand(sSqry, conn);
                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            if (!permisson.Any(x => x.ControlId == dr["ControlID"].ToString()))
                            {
                                permisson.Add(new PermissionList { ControlId = dr["ControlID"].ToString(), Permission = dr["Permission"].ToString() });
                            }

                        }
                    }
                    sSqry = "SELECT * FROM tblpermission_settings WHERE companyid='" + cmpId + "' AND BusinessID='ALL' AND AccessID='" + accessId + "'";
                    MySqlCommand cmd3 = new MySqlCommand(sSqry, conn);
                    MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt3.Rows)
                        {
                            if (!permisson.Any(x => x.ControlId == dr["ControlID"].ToString()))
                            {
                                permisson.Add(new PermissionList { ControlId = dr["ControlID"].ToString(), Permission = dr["Permission"].ToString() });
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
                finally
                {
                    conn.Close();
                }
            }
            return permisson;
        }
        public List<EmployeeLoginModel> GetLoginDetails(string userName, string passWord)
        {
            var result = new List<EmployeeLoginModel>();

            MySqlConnection CONN = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "SELECT * FROM `tblusers` WHERE `UserName`='" + userName + "' AND `Active`='y'";
                CONN.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, CONN);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new EmployeeLoginModel
                        {
                            UserName = dr.ItemArray[0].ToString(),
                            Password = dr.ItemArray[1].ToString(),
                            ForeName = dr.ItemArray[2].ToString(),
                            SurName = dr.ItemArray[3].ToString(),
                            Active = dr.ItemArray[6].ToString(),
                            AccessID = dr.ItemArray[5].ToString(),
                            BusinessID = dr.ItemArray[7].ToString(),
                            Email_ID = dr.ItemArray[12].ToString(),
                        });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                CONN.Close();
            }
            return result;
        }

        public string getCompanyParam(string paramId)
        {
            string result = "";
            string sSqry = "SELECT DefaultValue FROM tblGen_Parameters  WHERE ParamID='" + paramId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        #region getPricewithvat
        public string GetPriceWithVat(string style, string size, string busId, string priceid, bool isPrivOrder = false)
        {
            var vatP = GetVatPercent(style, size);
            var price = GetPrice(style, size, busId, priceid, isPrivOrder);
            var vat = (vatP * Convert.ToDouble(price)) / 100;
            return RoundVATDecimals(vat + Convert.ToDouble(price)).ToString("0.00");
        }

        #endregion

        #region basket

        #region GetAllTotals
        public TotalModel GetAlltotals(List<SalesOrderHeaderViewModel> mod, double carriage, bool isEdit = false, List<ReturnOrderModel> retModel = null)
        {
            TotalModel tot = new TotalModel();
            double orgTotal = 0;
            double lineTotal = 0;
            double vatTotal = 0;
            double assemTotal = 0;
            double Total = 0;
            List<double> varpercents = new List<double>();
            double totalVat = 0; string vatSpan = "";
            if (retModel == null)
            {
                foreach (var header in mod)
                {
                    foreach (var dat in header.SalesOrderLine.Where(s => s.IsDleted == false))
                    {
                        if (!dat.isCarrline)
                        {
                            orgTotal = orgTotal + (dat.OrdQty * dat.Price);
                        }
                        totalVat = isEdit ? totalVat + GetlineVat(dat.OrdQty, dat.Price, GetVatPercent(dat.StyleID, dat.SizeID)) : totalVat + GetlineVat(dat.OrdQty, dat.Price, dat.VatPercent);
                    }
                    lineTotal = lineTotal + orgTotal;
                    vatTotal = vatTotal + totalVat;
                    orgTotal = 0;
                    totalVat = 0;
                    foreach (var line in header.SalesOrderLine.Where(s => s.IsDleted == false))
                    {
                        double VatPercent = isEdit ? GetVatPercent(line.StyleID.Trim(), line.SizeID) : line.VatPercent;
                        varpercents.Add(VatPercent);
                        //double lineVat = line.OrdQty != 0 ? ((line.OrdQty * line.Price) * VatPercent) / 100 : 0.0;
                        //totalVat = totalVat + lineVat;
                    }
                    //  vatTotal = vatTotal + totalVat;
                }
                foreach (var vats in varpercents.Distinct())
                {
                    vatSpan = vatSpan + vats + "% \n";
                }
            }
            else
            {
                foreach (var dat in retModel)
                {
                    if (!dat.isCarrline)
                    {
                        orgTotal = orgTotal + (dat.OrdQty * dat.Price);
                    }
                    totalVat = isEdit ? totalVat + GetlineVat(dat.OrdQty, dat.Price, GetVatPercent(dat.StyleId, dat.SizeId)) : totalVat + GetlineVat(dat.OrdQty, dat.Price, dat.VatPercent);
                }
                lineTotal = lineTotal + orgTotal;
                vatTotal = vatTotal + totalVat;
                orgTotal = 0;
                totalVat = 0;
                foreach (var line in retModel)
                {
                    double VatPercent = isEdit ? GetVatPercent(line.StyleId, line.SizeId) : line.VatPercent;
                    varpercents.Add(VatPercent);
                    //double lineVat = line.OrdQty != 0 ? ((line.OrdQty * line.Price) * VatPercent) / 100 : 0.0;
                    //totalVat = totalVat + lineVat;
                }
                // vatTotal = vatTotal + totalVat;

                foreach (var vats in varpercents.Distinct())
                {
                    vatSpan = vatSpan + vats + "% \n";
                }

            }
            var carriage1 = 0.0;
            foreach (var model in mod)
            {
                if (model.SalesOrderLine.Any(s => s.isCarrline))
                {
                    carriage1 = carriage1 + model.SalesOrderLine.Where(s => s.isCarrline).Sum(s => s.Price);
                }
            }
            tot.vatSpan = vatSpan;
            tot.carriage = RoundVATDecimals(carriage1);
            tot.ordeTotal = RoundVATDecimals(lineTotal);
            tot.totalVat = RoundVATDecimals(vatTotal);
            tot.Total = RoundVATDecimals(lineTotal + carriage1);
            tot.gross = RoundVATDecimals(vatTotal + lineTotal + carriage1);
            tot.gross1 = RoundVATDecimals(vatTotal + lineTotal + carriage1);
            return tot;
        }
        #endregion
        public List<OrderDisplayDetail> GetOrderDetail(int orderno)
        {
            var OrderDisplayDetail = new List<OrderDisplayDetail>();
            if (_salesDetail.Exists(s => s.OrderNo == orderno))
            {
                OrderDisplayDetail = _salesDetail.GetAll(s => s.OrderNo == orderno).Select(s => new OrderDisplayDetail
                {
                    RtnNo = s.ReturnOrderNo.Value,
                    ColourID = s.ColourID,
                    SizeID = s.SizeID,
                    StyleID = s.StyleID,
                    Description = s.Description,
                    OrdQty = s.OrdQty.Value,
                    linno = s.LineNo,
                    OrgOrderNo = s.OriginalOrderNo == null ? 0 : s.OriginalOrderNo.Value,
                    Reason = s.SOPDETAIL4,
                    ReturnOrderNo = Convert.ToInt32(s.ReturnOrderNo.Value),
                    Price = RoundVATDecimals(Convert.ToDouble(s.Price.Value)),
                    Vat = GetlineVat(Convert.ToDouble(s.OrdQty), Convert.ToDouble(s.Price.Value), (GetVatPercent(s.StyleID, s.SizeID))),
                    Total = GetlineTotals(Convert.ToDouble(s.OrdQty), Convert.ToDouble(s.Price.Value), GetVatPercent(s.StyleID, s.SizeID))
                }).ToList();
            }
            return OrderDisplayDetail;
        }

        #region GetlineTotals
        public double GetlineTotals(double qty, double price, double vat)
        {
            double tot = 0;
            tot = ((qty * vat * price) / 100) + price * qty;
            return RoundVATDecimals(tot);
        }
        #endregion

        #region GetlineVat
        public double GetlineVat(double qty, double price, double vat)
        {
            double vater = 0;
            vater = ((qty * vat * price) / 100);
            return RoundVATDecimals(vater);
        }
        #endregion

        #region RoundVATDecimals

        public double RoundVATDecimals(Double value)
        {
            double result = 0;
            if (value > 0)
            {
                result = Convert.ToDouble(decimal.Divide(Convert.ToInt64(Convert.ToDouble((value * 100).ToString("0.0000")) + 0.4), 100));
            }
            return result;
        }
        #endregion

        #region GetCostPrice
        public double GetCostPrice(string style, string size, string color, string currency, int mprice, int seqNo)
        {
            double cost = 0.0;
            string sSqry = " SELECT Price FROM tblfsk_style_sizes_prices  WHERE CompanyID='" + cmpId.Trim() + "' AND StyleID='" + style.Trim() + "' AND SizeID='" + size.Trim() + "' AND  PriceID=" + mprice + " AND Businessid='ALL' AND Country_Currency=0";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, con);
                cost = cmd.ExecuteScalar() == null ? 0.0 : Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                string createText = e.Message + " " + style + " " + DateTime.Now + " " + Environment.NewLine;
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string path = appPath + "/error.txt";
                File.WriteAllText(path, createText);
            }
            finally
            {
                con.Close();
            }
            return cost;
        }
        #endregion

        #region GetVatcode
        public int GetVatCode()
        {
            int result = 0;
            result = _accVatCodes.Exists(x => x.Description == "VAT Code 1") ? _accVatCodes.GetAll(x => x.Description == "VAT Code 1").First().VATCode : 0;
            return result;
        }
        #endregion

        #region GetDeliveryDate
        public string GetDeliveryDate(int noOfDays, bool isWeekends)
        {
            var date = DateTime.Now;

            for (int i = 0; i <= noOfDays; i++)
            {
                date = date.AddDays(1);
                DayOfWeek day = date.DayOfWeek;

                if (isWeekends == false)
                {
                    while (date.DayOfWeek == DayOfWeek.Saturday | date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        date = date.AddDays(1);
                    }
                }

            }

            return date.ToString("yyyy-MM-dd");
        }
        #endregion


        #region GetVatPercent
        public double GetVatPercent(string style, string size)
        {
            double vatPercent = 0.0;
            string sSqry = " SELECT `vatpercent`  FROM    `tblacc_vatcodes`  WHERE vatcode = (SELECT  `price`  FROM  `tblfsk_style_sizes_prices`  WHERE  `styleid`= '" + style.Trim() + "' AND BusinessId='ALL' AND sizeid = '" + size.Trim() + "' AND `priceid`= (SELECT priceid FROM `tblfsk_price` WHERE description = 'VAT'))";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                vatPercent = cmd.ExecuteScalar() != null ? Convert.ToDouble(cmd.ExecuteScalar()) : 0.0;
                return vatPercent;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                string createText = e.Message + " " + style + " " + DateTime.Now + " " + Environment.NewLine;
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string path = appPath + "/error.txt";
                File.WriteAllText(path, createText);
            }
            finally
            {
                conn.Close();
            }

            return vatPercent;
        }
        #endregion

        #region GetBooValue

        public bool GetBooValue(string sSqry)
        {
            var result = false;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region GetCarrierCmbValue
        public List<string> GetCarrierCmbValue()
        {
            var result = new List<string>();
            string sQry = "";
            sQry = sQry + "select * from tblsop_carrier where CompanyID='" + cmpId + "' order by CarrierID";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.ItemArray[0] + "|" + dr.ItemArray[1]);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        #region GetAlternateStyle
        public AlternateStyles GetAlternateStyle(string bannerStyle)
        {
            AlternateStyles clsz = new AlternateStyles();
            if (_tblAlternates.Exists(s => s.StyleId.ToLower() == bannerStyle.ToLower()))
            {
                var altSt = _tblAlternates.GetAll(s => s.StyleId.ToLower() == bannerStyle.ToLower()).First();
                clsz.BannerStyleid = bannerStyle;
                clsz.StyleID = altSt.AltStyleId;
                clsz.styleimage = _tblFskStyle.Exists(s => s.StyleID.ToLower() == altSt.AltStyleId.Trim().ToLower()) ? _tblFskStyle.GetAll(s => s.StyleID.ToLower() == altSt.AltStyleId.Trim().ToLower()).First().StyleImage : "/StyleImages/notfound.png";
            }
            return clsz;
        }
        #endregion
        #region GetCarrierStyle

        public List<string> GetCarrierStyleCmbValue(string busId = "")
        {
            var result = new List<string>();
            string sQry = "";
            string sQry1 = "";
            sQry1 = sQry1 + "SELECT DISTINCT StyleId FROM `tblonlinebus_carriage` WHERE BusinessId ='" + busId + "'";
            sQry = sQry + " SELECT DISTINCT tblfsk_style.StyleID, tblfsk_style.Description  FROM tblfsk_style INNER JOIN tblonlinesop_carriage ON (tblfsk_style.StyleID = tblonlinesop_carriage.StyleID) AND (tblfsk_style.CompanyID = tblonlinesop_carriage.CompanyID)  WHERE tblfsk_style.CompanyID='" + cmpId + "'  ORDER BY tblfsk_style.StyleID";

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry1, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.ItemArray[0].ToString());
                    }
                }
                else
                {
                    MySqlCommand cmd1 = new MySqlCommand(sQry, conn);
                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            result.Add(dr.ItemArray[0] + "|" + dr.ItemArray[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetSitecodes

        public List<SiteCodeModel> GetSitecodes(string businessId)
        {
            var result = new List<SiteCodeModel>();
            string sortString = BusinessParam("SITECODE_SORTING", businessId);
            string sortFld = "t1.SiteName,' | ',t1.SiteCode";
            string sSqry = "";
            if (sortString == "")
            {
                sortString = "SiteName";
            }
            if (sortString == "SiteCode")
            {
                sortFld = "t1.SiteCode,' | ',t1.SiteName";
            }
            sSqry = string.Format("SELECT DISTINCT t1.SiteCode, CAST(Concat(" + sortFld + ") AS CHAR) AS SiteCodeInfo  FROM tblonlinesop_sitecode t1  WHERE t1.Businessid='{0}' ", businessId);
            sSqry = sSqry + "ORDER BY t1." + sortString + " ASC";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new SiteCodeModel { SiteCode = dr.ItemArray[0].ToString(), SiteCodeInfo = dr.ItemArray[1].ToString() });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region CheckBudgetOrPoints
        public bool CheckBudgetOrPoints(string BUDGETREQ, string businessId, bool booCheck = true)
        {
            bool booReturn = true;
            bool isPersonalOrder = false;
            bool busBudgetReq = Convert.ToBoolean(BUDGETREQ);
            if (isPersonalOrder)
            {
                return true;
            }
            if (booCheck)
            {
                if (busBudgetReq)
                {

                }
                else if (Convert.ToBoolean(BusinessParam("POINTSREQ", businessId)))
                {

                }
            }
            return booReturn;
        }
        #endregion

        #region GetAddressDetails
        public BusAddress1 GetAddressDetails(string qry)
        {
            var BusAddress1 = new BusAddress1();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        BusAddress1.AddressDescription = reader.GetString("Description") != "" ? reader.GetString("Description") : "";
                        BusAddress1.Address1 = reader.GetString("Address1") != "" ? reader.GetString("Address1") : "";
                        BusAddress1.Address2 = reader.GetString("Address2") != "" ? reader.GetString("Address2") : "";
                        BusAddress1.Address3 = reader.GetString("Address3") != "" ? reader.GetString("Address3") : "";
                        BusAddress1.Town = reader.GetString("Town") != "" ? reader.GetString("Town") : "";
                        BusAddress1.City = reader.GetString("City") != "" ? reader.GetString("City") : "";
                        BusAddress1.PostCode = reader.GetString("Postcode") != "" ? reader.GetString("Postcode") : "";
                        BusAddress1.Country = reader.GetString("Country") != "" ? reader.GetString("Country") : "";
                    }
                    return BusAddress1;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return BusAddress1;
        }
        #endregion

        #region GetUserCount
        public int GetUserCount(string userName)
        {
            string sSql = "SELECT Count(*) FROM tblusers WHERE ASPUserID='" + userName + "' AND Active='Y'";
            return GetScalar(sSql) == "" ? 0 : Convert.ToInt32(GetScalar(sSql));
        }
        #endregion

        #region FillCombo_CustomerDelivery
        public List<BusAddress1> FillCombo_CustomerDelivery(string busId, string access, string orderPermit, string UserName, bool IsManpack = false, string selEmp = "")
        {
            var result = new List<BusAddress1>();
            string extraQry = "";
            string sQry = "";
            string usersLst = "";
            var usersLst1 = getPermissionUsers(GetOrderPermission(orderPermit), UserName, busId, access);
            //if (usersLst1.Contains(","))
            //{
            //    var usrArr = usersLst1.Split(',');
            //    foreach (var usr in usrArr)
            //    {
            //        if (usr != null && usr != "")
            //        {
            //            int index = Array.IndexOf(usrArr, usr);
            //            if (usrArr.Count() - 1 == index)
            //            {
            //                usersLst = usersLst + usr;
            //            }
            //            else
            //            {
            //                usersLst = usersLst + usr + ",";
            //            }
            //        }
            //    }
            //}
            //if (usersLst.Last() == ',')
            //{
            //    usersLst = usersLst.Remove(usersLst.Length - 1);
            //}


            //usersLst ===","?
            if (IsManpack)
            {
                if (usersLst1 != "")
                {
                    extraQry = extraQry + " (t3.`OnlineUserId`IN (" + usersLst1 + ") OR t3.`Employeeid` = '" + selEmp + "') ";
                }
                else
                {
                    extraQry = extraQry + " (t3.`OnlineUserId`IN ('" + usersLst1 + "') OR t3.`Employeeid` = '" + selEmp + "') ";
                }
                //extraQry = extraQry + " (onusraddr.`OnlineUserId`IN (" + getPermissionUsers(GetOrderPermission(), System.Web.HttpContext.Current.Session["UserName"].ToString(), busId) + ") OR onusraddr.`Employeeid` = '" & Emplist1.CurrentEmployee & "') ";
            }
            else
            {
                extraQry = extraQry + " t3.`OnlineUserId`='" + UserName + "' ";
            }
            if (Convert.ToBoolean(BusinessParam("LIMITUSRADDR", busId)) && !IsGetAllDelAddress(access, busId))
            {
                //commented by sasi(23-12-20)
                //sQry = sQry + "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode,  tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes  INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON  tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  JOIN tblonline_emp_address onusraddr on onusraddr.AddressID=tblbus_address.AddressID AND tblbus_address.BusinessID= onusraddr.BusinessID AND onusraddr.CompanyID=tblbus_address.CompanyID   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' AND " + extraQry + "  order by tblbus_address.Description";
                sQry = sQry + " SELECT DISTINCT t1.Description, t1.Address1, t1.Address2, t1.Address3, t1.Town, t1.City, t1.Postcode, t2.Country, t1.CountryCode, t1.AddressID,t1.ContactID FROM tblbus_address t1 JOIN tblbus_countrycodes t2 ON t2.CountryID = t1.CountryCode AND t1.`CompanyID` = t2.`CompanyID` JOIN tblonline_emp_address t3 ON t3.AddressID = t1.AddressID AND t1.BusinessID = t3.BusinessID AND t1.CompanyID = t3.CompanyID WHERE t1.BusinessID = '" + busId + "' AND t1.CompanyID = '" + cmpId + "' AND" + extraQry + "   ORDER BY t1.Description";
            }
            else
            {
                sQry = sQry + "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' order by tblbus_address.Description";
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = dt.AsEnumerable().Select(s => new BusAddress1 { AddressDescription = s.ItemArray[0].ToString(), Address1 = s.ItemArray[1].ToString(), Address2 = s.ItemArray[2].ToString(), Address3 = s.ItemArray[3].ToString(), City = s.ItemArray[5].ToString(), PostCode = s.ItemArray[6].ToString(), AddressId = Convert.ToInt32(s.ItemArray[9].ToString()), Country = s.ItemArray[7].ToString(), contactId = s.ItemArray[10].ToString() }).ToList();
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    result.Add(new BusAddress1 { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
                    //}
                }
                else
                {
                    extraQry = ""; sQry = "";
                    if (IsManpack)
                    {
                        string user = "";
                        MySqlCommand cmdUser = new MySqlCommand("SELECT OnlineUserId FROM `tblonline_emp_address` t3 WHERE t3.`BusinessId` = '" + busId + "' AND t3.`OnlineUserId` IN (SELECT t1.`OnlineUserID` FROM `tblonline_userid_employee` t1 JOIN tblusers t2 ON t1.`OnlineUserID` = t2.`UserName` AND t1.`BusinessID` = t2.`BusinessID` WHERE t1.Businessid = '" + busId + "' AND t1.EmployeeID = '" + selEmp + "' AND t1.OnlineUserID <> '" + selEmp + "')", conn);
                        user = cmdUser.ExecuteScalar() != null ? (cmdUser.ExecuteScalar()).ToString() : "";
                        if (usersLst == "")
                        {

                            extraQry = extraQry + " (t3.`OnlineUserId`IN ('" + user + "') OR t3.`Employeeid` = '" + selEmp + "') ";
                        }
                        else
                        {
                            extraQry = extraQry + " (t3.`OnlineUserId`IN (" + usersLst + ",'" + user + "') OR t3.`Employeeid` = '" + selEmp + "') ";
                        }

                        //extraQry = extraQry + " (onusraddr.`OnlineUserId`IN (" + getPermissionUsers(GetOrderPermission(), System.Web.HttpContext.Current.Session["UserName"].ToString(), busId) + ") OR onusraddr.`Employeeid` = '" & Emplist1.CurrentEmployee & "') ";
                    }
                    else
                    {
                        extraQry = extraQry + " t3.`OnlineUserId`='" + UserName + "' ";
                    }
                    if (Convert.ToBoolean(BusinessParam("LIMITUSRADDR", busId)) && !IsGetAllDelAddress(access, busId))
                    {
                        //commented by sasi(23-12-15)
                        //sQry = sQry + "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode,  tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes  INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON  tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  JOIN tblonline_emp_address onusraddr on onusraddr.AddressID=tblbus_address.AddressID AND tblbus_address.BusinessID= onusraddr.BusinessID AND onusraddr.CompanyID=tblbus_address.CompanyID   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' AND " + extraQry + "  order by tblbus_address.Description";
                        sQry = sQry + " SELECT DISTINCT t1.Description, t1.Address1, t1.Address2, t1.Address3, t1.Town, t1.City, t1.Postcode, t2.Country, t1.CountryCode, t1.AddressID,t1.ContactID FROM tblbus_address t1 JOIN tblbus_countrycodes t2 ON t2.CountryID = t1.CountryCode AND t1.`CompanyID` = t2.`CompanyID` JOIN tblonline_emp_address t3 ON t3.AddressID = t1.AddressID AND t1.BusinessID = t3.BusinessID AND t1.CompanyID = t3.CompanyID WHERE t1.BusinessID = '" + busId + "' AND t1.CompanyID = '" + cmpId + "' AND" + extraQry + "   ORDER BY t1.Description";
                    }
                    else
                    {
                        sQry = sQry + "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' order by tblbus_address.Description";
                    }
                    MySqlCommand cmd11 = new MySqlCommand(sQry, conn);
                    MySqlDataAdapter da11 = new MySqlDataAdapter(cmd11);
                    DataTable dt11 = new DataTable();
                    da11.Fill(dt11);
                    if (dt11.Rows.Count > 0)
                    {
                        result = dt11.AsEnumerable().Select(s => new BusAddress1 { AddressDescription = s.ItemArray[0].ToString(), Address1 = s.ItemArray[1].ToString(), Address2 = s.ItemArray[2].ToString(), Address3 = s.ItemArray[3].ToString(), City = s.ItemArray[5].ToString(), PostCode = s.ItemArray[6].ToString(), AddressId = Convert.ToInt32(s.ItemArray[9].ToString()), Country = s.ItemArray[7].ToString(), contactId = s.ItemArray[10].ToString() }).ToList();
                        //foreach (DataRow dr in dt11.Rows)
                        //{
                        //    result.Add(new BusAddress1 { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
                        //}
                    }
                    else
                    {
                        sQry = "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' order by tblbus_address.Description";
                        MySqlCommand cmd1 = new MySqlCommand(sQry, conn);
                        MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            result = dt1.AsEnumerable().Select(s => new BusAddress1 { AddressDescription = s.ItemArray[0].ToString(), Address1 = s.ItemArray[1].ToString(), Address2 = s.ItemArray[2].ToString(), Address3 = s.ItemArray[3].ToString(), City = s.ItemArray[5].ToString(), PostCode = s.ItemArray[6].ToString(), AddressId = Convert.ToInt32(s.ItemArray[9].ToString()), Country = s.ItemArray[7].ToString(), contactId = s.ItemArray[10].ToString() }).ToList();
                            //foreach (DataRow dr in dt1.Rows)
                            //{
                            //    result.Add(new BusAddress1 { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
                            //}
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        #endregion

        #region getDatatable
        public DataTable GetDatatableByQry(int i, string busId)
        {
            string sql = "";
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            sql = i == 0 ? "SELECT DISTINCT ToHour FROM tblaccemp_ucodes_hours WHERE BusinessID='" + busId + "' AND CompanyID='" + cmpId + "' ORDER BY ToHour" : "SELECT DISTINCT UCodeID  FROM tblaccemp_ucodes_hours  WHERE BusinessID='" + busId + "' AND CompanyID='" + cmpId + "' ORDER BY UCodeID";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion

        #region FillComboUcodesShowHours

        public DataTable FillshowhoursCmb(string strCustID, string txtEmpID, string strCompanyID)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string sSqry = "";
            if (txtEmpID == "")
            {
                sSqry = "SELECT DISTINCT t1.`CompanyID`,t1.`UCodeID`,IF (Q1.`UCodeID` IS NULL,FALSE,FALSE) AS CheckIt  FROM `tblaccemp_ucodes` t1  LEFT JOIN (SELECT CompanyID,BusinessID,UCodeID FROM `tblaccemp_ucodesemployees` WHERE `EmployeeID`='" + txtEmpID + "') Q1 ON t1.`CompanyID`=Q1.CompanyID AND t1.UCODEID=Q1.UCODEID  LEFT JOIN tblaccemp_ucodesemployees t2 ON t1.`CompanyID` = t2.`CompanyID` AND t1.`UCodeID` = t2.`UCodeID`  WHERE t2.BusinessID='" + strCustID + "' AND t2.CompanyID='" + strCompanyID + "' ORDER BY t1.UCodeID";
            }
            else
            {
                sSqry = "SELECT DISTINCT t1.`CompanyID`,t1.`UCodeID`,IF (Q1.`UCodeID` IS NULL,FALSE,TRUE) AS CheckIt FROM `tblaccemp_ucodes` t1  LEFT JOIN (SELECT CompanyID,BusinessID,UCodeID FROM `tblaccemp_ucodesemployees`   WHERE `EmployeeID`='" + txtEmpID + "') Q1 ON t1.`CompanyID`=Q1.CompanyID AND t1.UCODEID=Q1.UCODEID  LEFT JOIN tblaccemp_ucodesemployees t2 ON t1.`CompanyID` = t2.`CompanyID` AND t1.`UCodeID` = t2.`UCodeID`  WHERE t2.BusinessID='" + strCustID + "' AND t2.CompanyID='" + strCompanyID + "' ORDER BY t1.UCodeID";
            }
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        #endregion

        #region IsGetAllDelAddress
        public bool IsGetAllDelAddress(string Access, string busId)
        {
            try
            {
                if (Access.Trim().ToUpper() == "ADMIN")
                {
                    return true;
                }
                else
                {
                    return getPermission(controls.AllAddress, Access, busId).ToString().Trim().ToUpper().Equals("SHOW");
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return false;
        }
        #endregion

        //#region AddBusinessDays
        //public DateTime AddBusinessDays(int noOfdays,DateTime dt,bool includeWEnds)
        //{
        //    int dayOfWeek;
        //    DateTime date = DateTime.Now.AddDays(1);
        //    for (int i =0;i<noOfdays;i++)
        //    {
        //        date= date.AddDays(1);
        //        dayOfWeek = Weekday(date, DateTime.Now.DayOfWeek);
        //        if(includeWEnds==false)
        //        {
        //            while(dayOfWeek==Convert.ToInt32(DayOfWeek.Saturday) | dayOfWeek == Convert.ToInt32(DayOfWeek.Sunday))
        //            {
        //                date = date.AddDays(1);
        //                dayOfWeek=Weekday(date, DateTime.Now.DayOfWeek);
        //            }
        //        }
        //    }
        //    return date;
        //}

        //#endregion
        //#region
        //public static int Weekday(DateTime dt, DayOfWeek startOfWeek)
        //{
        //    return (dt.DayOfWeek - startOfWeek + 7) % 7;
        //}
        //#endregion
        #region checkBulkCarriageLine

        public bool checkBulkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder)
        {
            bool checkBulkCarriageLine = false;
            string carrstr = "";
            long irow = 0;

            var headers = currentOrder;
            var salesLines = headers.Select(x => x.SalesOrderLine).First();
            foreach (var data in salesLines.Where(s => s.IsDleted == false))
            {
                carrstr = "SELECT * FROM tblonlinesop_carriage WHERE StyleID='" + data.StyleID + "' AND CompanyID='" + cmpId + "'";
                if (qryResult(carrstr) > 0)
                {
                    checkBulkCarriageLine = true;
                }
            }
            return checkBulkCarriageLine;
        }
        #endregion

        #region checkCarriageLine
        public bool checkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder, bool isReturn = false)
        {
            bool checkCarriageLine = false;
            string carrstr = "";
            long irow = 0;
            var headers = currentOrder;

            if (isReturn)
            {
                var salesLines = headers.Select(x => x.Returnlines).First();
                foreach (var data in salesLines.Where(s => s.IsDleted == 0))
                {
                    var styl = data.StyleId.Contains("|") ? data.StyleId.Split('|')[0] : data.StyleId;
                    carrstr = "SELECT * FROM tblonlinesop_carriage WHERE StyleID='" + styl + "' AND CompanyID='" + cmpId + "'";
                    if (qryResult(carrstr) > 0)
                    {
                        checkCarriageLine = true;
                    }
                }
            }
            else
            {
                var salesLines = headers.Select(x => x.SalesOrderLine).First();
                foreach (var data in salesLines.Where(s => s.IsDleted == false))
                {
                    var styl = data.StyleID.Contains("|") ? data.StyleID.Split('|')[0] : data.StyleID;
                    carrstr = "SELECT * FROM tblonlinesop_carriage WHERE StyleID='" + styl + "' AND CompanyID='" + cmpId + "'";
                    if (qryResult(carrstr) > 0)
                    {
                        checkCarriageLine = true;
                    }
                }
            }
            return checkCarriageLine;
        }

        #endregion

        #region  getbusienssAccounts
        public TBusinessAccount GetBusinessAcount(string business)
        {
            TBusinessAccount tbusAccount = new TBusinessAccount();
            string sSqry = "";
            sSqry = BusinessAccountSQL() + " AND tblbus_account.businessid='" + business + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tbusAccount.BusinessID = dr["BusinessID"].ToString();
                        tbusAccount.VatFlag = dr["VATFlag"].ToString();
                        tbusAccount.VatCode = Convert.ToInt32(dr["VATCode"].ToString());
                        tbusAccount.RepID = Convert.ToInt32(dr["RepID"].ToString());
                        tbusAccount.ExchangeRate = Convert.ToDouble(dr["Currency_Exchange_Rate"].ToString());
                        tbusAccount.Rep_Comission = Convert.ToInt32(dr["Rep_Comission"].ToString());
                        tbusAccount.KAM_Comission = Convert.ToInt32(dr["KAM_Comission"].ToString());
                        tbusAccount.Country_CurrencyID = Convert.ToInt32(dr["Country_Currency"].ToString());
                    }
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return tbusAccount;
        }
        //public TBusinessAccount GetBusinessAccount(List<TBusinessAccount> colBuis, string business)
        //{
        //    int i;
        //    TBusinessAccount getBusinessAccount = new TBusinessAccount();
        //    string sSqry = "";
        //    sSqry = BusinessAccountSQL() + " AND tblbus_account.businessid='" + business + "'";
        //    MySqlConnection conn = new MySqlConnection(ConnectionString);
        //    TBusinessAccount tmpType;
        //    for (i = 0; i < colBuis.Count(); i++)
        //    {
        //        tmpType = colBuis[i];
        //        if (tmpType.BusinessID == business)
        //        {
        //            return tmpType;
        //        }
        //    }
        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand(sSqry, conn);
        //        var reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            getBusinessAccount = readBusinessAccount(reader);
        //        }
        //        colBuis[colBuis.Count - 1] = getBusinessAccount;
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return getBusinessAccount;
        //}
        #endregion

        //#region readBusinessAccount
        //public TBusinessAccount readBusinessAccount(MySqlDataReader reader)
        //{
        //    TBusinessAccount tmpType;
        //    tmpType.BusinessID = reader.GetString("BusinessID");
        //    tmpType.Credit_Limit = Convert.ToDouble(reader.GetString("Credit_Limit"));
        //    tmpType.Cash_Days1 = Convert.ToInt32(reader.GetString("Cash_Days1"));
        //    tmpType.Cash_Days2 = Convert.ToInt32(reader.GetString("Cash_Days2"));
        //    tmpType.Currency = reader.GetString("Currency");
        //    tmpType.VatCode = Convert.ToInt32(reader.GetString("VATCode"));
        //    if (reader.GetString("VATFlag") == "")
        //    {
        //        tmpType.VatFlag = "";
        //    }
        //    else
        //    {
        //        tmpType.VatFlag = reader.GetString("VATFlag");
        //    }
        //    tmpType.Balance = Convert.ToDouble(reader.GetString("Balance"));
        //    tmpType.RepID = Convert.ToInt32(reader.GetString("RepID"));
        //    tmpType.Rep_Comission = Convert.ToSingle(reader.GetString("Rep_Comission"));
        //    tmpType.KAM_Comission = Convert.ToSingle(reader.GetString("KAM_Comission"));
        //    tmpType.Balance = Convert.ToDouble(reader.GetString("Balance"));
        //    tmpType.PaymentTermsID = Convert.ToInt32(reader.GetString("PaymentTermsID"));
        //    tmpType.Country_CurrencyID = Convert.ToInt32(reader.GetString("Country_Currency"));
        //    tmpType.CurrencyName = reader.GetString("Currency_name");
        //    tmpType.ExchangeRate = Convert.ToDouble(reader.GetString("Currency_Exchange_Rate"));
        //    tmpType.booSet = true;
        //    return tmpType;
        //}
        //#endregion

        #region Setbusinessaccount

        public List<TBusinessAccount> SetBuisnessAccount()
        {

            List<TBusinessAccount> tmpcolBusiness = new List<TBusinessAccount>();
            TBusinessAccount tmpType;
            string sSqry = "";
            string sSqry1 = "";
            sSqry = BusinessAccountSQL();
            sSqry1 = " SELECT count(*) FROM (" + sSqry + ")";
            long i = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tmpcolBusiness.Add(new TBusinessAccount { BusinessID = dr.ItemArray[1].ToString(), Credit_Limit = Convert.ToDouble(dr.ItemArray[8].ToString()), Cash_Days1 = Convert.ToInt32(dr.ItemArray[9].ToString()), Cash_Days2 = Convert.ToInt32(dr.ItemArray[10].ToString()), Currency = dr.ItemArray[13].ToString(), VatCode = Convert.ToInt32(dr.ItemArray[14].ToString()), VatFlag = dr.ItemArray[15].ToString(), RepID = Convert.ToInt32(dr.ItemArray[26].ToString()), Rep_Comission = Convert.ToInt32(dr.ItemArray[27].ToString()), KAM_Comission = Convert.ToInt32(dr.ItemArray[28].ToString()), Balance = Convert.ToDouble(dr.ItemArray[8].ToString()), PaymentTermsID = Convert.ToInt32(dr.ItemArray[29].ToString()), Country_CurrencyID = Convert.ToInt32(dr.ItemArray[30].ToString()), CurrencyName = dr.ItemArray[31].ToString(), ExchangeRate = Convert.ToDouble(dr.ItemArray[32].ToString()), booSet = true });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return tmpcolBusiness;
        }

        #endregion

        #region  getCount
        public int GetCount(string sSqry)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);

            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region BusinessAccountSQL
        public string BusinessAccountSQL()
        {
            string result = "";
            result = " SELECT tblbus_account.*, tblbus_business.Country_Currency, tblbus_countrycodes.Currency_Name, tblbus_countrycodes.Currency_Exchange_Rate FROM (tblbus_business INNER JOIN tblbus_account ON (tblbus_business.CompanyID = tblbus_account.CompanyID) AND (tblbus_business.BusinessID = tblbus_account.BusinessID)) INNER JOIN tblbus_countrycodes ON (tblbus_business.CompanyID = tblbus_countrycodes.CompanyID) AND (tblbus_business.Country_Currency = tblbus_countrycodes.CountryID) WHERE tblbus_account.CompanyID='" + cmpId + "'";
            return result;
        }
        #endregion


        #region displayOrderListGrid

        public void displayOrderListGrid(bool booShowManpack = false)
        {
            string sql = "";
            long i;
            string xmlOrderList = "";
            string Employee = "";
            //var data = ((SalesOrderHeaderViewModel)HttpContext.Current.Session["objCurrentOrder"]).SalesOrderLine;
            //    If IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")) <> vbNullString Then
            //        Employee = IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")) & " - " & getEmpName(strCompanyID, strCustID, IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")))
            //    Else
            //        Employee = "XXX"
            //    End If
            //xmlOrderList = "<SalesOrders>";
            //for (i = 1; i <= data.Count(); i++)

            //xmlOrderList = xmlOrderList + "<OrderLine OrderLineNo=" + (char)(34) + i + (char)(34) + " lineno=" + (char)(34) + .Item(i).LineNo + (char)(34) + " basestyle=" + (char)(34) + Server.HtmlEncode(.Item(i).BaseStyleID) + (char)(34) + " style=" + (char)(34) + Server.HtmlEncode(.Item(i).StyleID) + " - " + Server.HtmlEncode(.Item(i).Description) + (char)(34) + " colour=" + (char)(34) + Server.HtmlEncode(.Item(i).ColourID) + (char)(34) + " size=" + (char)(34) + Server.HtmlEncode(.Item(i).SizeID) + (char)(34) + " issuom=" + (char)(34)

            //    Dim SQL As String
            //Dim rs As New ADODB.Recordset
            //Dim i As Long
            //Dim xmlOrderList As String
            //Dim ds As New DataSet
            //Dim Employee As String
            //With Session.Item("objCurrentOrder").SalesOrderLine
            //    If IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")) <> vbNullString Then
            //        Employee = IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")) & " - " & getEmpName(strCompanyID, strCustID, IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")))
            //    Else
            //        Employee = "XXX"
            //    End If
            //    xmlOrderList = "<SalesOrders>"
            //    For i = 1 To.Count
            //        'If .Item(i).OrdQty > 0 Then
            //        ' xmlOrderList = xmlOrderList & "<OrderLine lineno=" & Chr(34) & .Item(i).LineNo & Chr(34) & " style=" & Chr(34) & Server.HtmlEncode(.Item(i).StyleID) & " - " & Server.HtmlEncode(.Item(i).Description) & Chr(34) & " colour=" & Chr(34) & Server.HtmlEncode(.Item(i).ColourID) & Chr(34) & " size=" & Chr(34) & Server.HtmlEncode(.Item(i).SizeID) & Chr(34) & " issuom=" & Chr(34)
            //        xmlOrderList = xmlOrderList & "<OrderLine OrderLineNo=" & Chr(34) & i & Chr(34) & " lineno=" & Chr(34) & .Item(i).LineNo & Chr(34) & " basestyle=" & Chr(34) & Server.HtmlEncode(.Item(i).BaseStyleID) & Chr(34) & " style=" & Chr(34) & Server.HtmlEncode(.Item(i).StyleID) & " - " & Server.HtmlEncode(.Item(i).Description) & Chr(34) & " colour=" & Chr(34) & Server.HtmlEncode(.Item(i).ColourID) & Chr(34) & " size=" & Chr(34) & Server.HtmlEncode(.Item(i).SizeID) & Chr(34) & " issuom=" & Chr(34)
            //        ' xmlOrderList = xmlOrderList & "<OrderLine OrderLineNo=" & Chr(34) & i & Chr(34) & " lineno=" & Chr(34) & i & Chr(34) & " basestyle=" & Chr(34) & Server.HtmlEncode(.Item(i).BaseStyleID) & Chr(34) & " style=" & Chr(34) & Server.HtmlEncode(.Item(i).StyleID) & " - " & Server.HtmlEncode(.Item(i).Description) & Chr(34) & " colour=" & Chr(34) & Server.HtmlEncode(.Item(i).ColourID) & Chr(34) & " size=" & Chr(34) & Server.HtmlEncode(.Item(i).SizeID) & Chr(34) & " issuom=" & Chr(34)
            //        SQL = "SELECT UnitDescription FROM tblfsk_unitofmeasure WHERE UnitID=" & .Item(i).IssueUOM & " AND CompanyID='" & strCompanyID & "'"
            //        rs.Open(LCase(SQL), Conn)
            //        If Not rs.EOF Then
            //            xmlOrderList = xmlOrderList & Server.HtmlEncode(rs("UnitDescription").Value) & Chr(34)
            //        Else
            //            xmlOrderList = xmlOrderList & .Item(i).IssueUOM & Chr(34)
            //        End If
            //        rs.Close()
            //        xmlOrderList = xmlOrderList & " ordqty=" & Chr(34) & .Item(i).IssueQty & Chr(34) & " stkuom=" & Chr(34)
            //        SQL = "SELECT UnitDescription FROM tblfsk_unitofmeasure WHERE UnitID=" & .Item(i).StockingUOM & " AND CompanyID='" & strCompanyID & "'"
            //        rs.Open(LCase(SQL), Conn)
            //        If Not rs.EOF Then
            //            xmlOrderList = xmlOrderList & Server.HtmlEncode(rs("UnitDescription").Value) & Chr(34)
            //        Else
            //            xmlOrderList = xmlOrderList & .Item(i).StockingUOM & Chr(34)
            //        End If
            //        rs.Close()
            //        'xmlOrderList = xmlOrderList & " freetext=" & Chr(34) & Server.HtmlEncode(.Item(i).FreeText) & Chr(34) & " price=" & Chr(34) & Math.Round(.Item(i).Price, 2) & Chr(34) & " value=" & Chr(34) & Math.Round(.Item(i).IssueQty * .Item(i).Price, 2) & Chr(34) & " orderno=" & Chr(34) & 1 & Chr(34) & " empid=" & Chr(34) & Server.HtmlEncode(Employee) & Chr(34) & " reasonsorderline=" & Chr(34)
            //        xmlOrderList = xmlOrderList & " freetext=" & Chr(34) & Server.HtmlEncode(.Item(i).FreeText) & Chr(34) & " price=" & Chr(34) & Format(Val(.Item(i).Price), NumFormat) & Chr(34) & " value=" & Chr(34) & Format(Val(.Item(i).IssueQty) * Val(.Item(i).Price), NumFormat) & Chr(34) & " orderno=" & Chr(34) & 1 & Chr(34) & " empid=" & Chr(34) & Server.HtmlEncode(Employee) & Chr(34) & " reasonsorderline=" & Chr(34)
            //        If Session("OrderReason") <> "" Then
            //            SQL = "SELECT ReasonCode, Description FROM tblsop_reasoncodes WHERE ReasonCode=" & .Item(i).ReasonCodeLine & " AND BusinessID='" & strCustID & "' ORDER BY SeqNo"
            //        Else
            //            SQL = "SELECT ReasonCode, Description FROM tblsop_reasoncodes WHERE ReasonCode=" & .Item(i).ReasonCodeLine & " AND BusinessID='ALL' ORDER BY SeqNo"
            //        End If
            //        rs.Open(LCase(SQL), Conn)
            //        If Not rs.EOF Then
            //            xmlOrderList = xmlOrderList & Server.HtmlEncode(rs("Description").Value) & Chr(34)
            //        Else
            //            xmlOrderList = xmlOrderList & .Item(i).ReasonCodeLine & Chr(34)
            //        End If
            //        rs.Close()
            //        xmlOrderList = xmlOrderList & " projectcodeline=" & Chr(34) & Server.HtmlEncode(.Item(i).ProjectCode) & Chr(34)
            //        xmlOrderList = xmlOrderList & " sopdetail4=" & Chr(34) & Server.HtmlEncode(.Item(i).SOPDetail4) & Chr(34)
            //        xmlOrderList = xmlOrderList & " />"
            //        'End If
            //    Next
            //    xmlOrderList = xmlOrderList & "</SalesOrders>"
            //End With
            //If booShowManpack = False Then
            //    If xmlOrderList <> "<SalesOrders></SalesOrders>" Then
            //        ds.ReadXml(New IO.StringReader(xmlOrderList))
            //        OrderGrid1.Visible = True
            //        OrderGrid1.DataSource = ds.Tables(0)
            //        OrderGrid1.DataBind()
            //        'Code by Senthilprabhu for Amplifon Edit Order Mail on 04/07/2016
            //        'If Session("EditOrderNo") IsNot Nothing Then
            //        '    If Session("EditOrderNo").ToString.Trim <> "" Then
            //        '        If Session("OriginalOrderLines") Is Nothing Then
            //        '            Session("OriginalOrderLines") = ds.Tables(0)
            //        '        End If
            //        '        Session("ChangedOrderLines") = ds.Tables(0)
            //        '    End If
            //        'End If
            //    Else
            //        OrderGrid1.Visible = False
            //    End If
            //    If BusBudgetReq Then
            //        If Request("Pinno") <> "" Then
            //            If EmpBudgetCheckGrid(Request("Pinno"), BudgetMax, BudgetCurr(Request("Pinno")), CurrentOrder.TotalGoodsAmount - getCarriageAmt()) = False Then
            //                lblBudgetExceed.Visible = True
            //                lblBudgetExceed.Text = BusinessParam("BUDGETMSG", strCustID)
            //            Else
            //                lblBudgetExceed.Visible = False
            //                lblBudgetExceed.Text = ""
            //            End If
            //        Else
            //            lblBudgetExceed.Visible = False
            //            lblBudgetExceed.Text = ""
            //        End If
            //    End If
            //End If
            //WorkOutTotals()

        }
        #endregion

        #region getSiteCodes
        public bool GetSiteCodes(string strCustID)
        {
            string strSql = "";
            string sortString = BusinessParam("SITECODE_SORTING", strCustID);
            string sortFld = "t1.SiteName,' | ',t1.SiteCode";
            if (sortString == "")
            {
                sortString = "SiteName";
            }
            if (sortString == "SiteCode")
            {
                sortFld = "t1.SiteCode,' | ',t1.SiteName";
            }
            strSql = "SELECT DISTINCT t1.SiteCode, CAST(Concat(" + sortFld + ") AS CHAR) AS SiteCodeInfo  FROM tblonlinesop_sitecode t1  WHERE t1.Businessid='{0}'  ORDER BY t1." + sortString + " ASC";
            strSql = string.Format(strSql, strCustID);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        #endregion

        #region SetSalesHeader

        //public bool SetSalesHeader(string txtCustRef = "", string txtDelAddDesc = "", bool optNewAddr = false, string cboSiteCode = "", string txtNomCode = "", string txtNomCode1 = "", string txtNomCode2 = "", string txtNomCode3 = "", string txtNomCode4 = "", string isBulk = "", bool booBulk = false, string txtCarrierCharge = "", string txtOrdDate = "", string txtCarrier = "", string txtCommentsExternal = "", string txtReasoncode = "", string txtCustAddDesc = "", string txtCustAdd1 = "", string txtCustAdd2 = "", string txtCustAdd3 = "", string txtCustTown = "", string txtCustCity = "", string txtCustPost = "", string txtCustCountry = "", string txtDelAdd1 = "", string txtDelAdd2 = "", string txtDelAdd3 = "", string txtDelTown = "", string txtDelCity = "", string txtDelPost = "", string txtDelCountry = "")
        //{
        //    var busID = System.Web.HttpContext.Current.Session["BuisnessId"].ToString().Trim();

        //    TBusinessAccount tmpbusiness;
        //    List<object> carrArr = new List<object>();
        //    bool setSalesOrderHeader = false;
        //    string strWarehouse = "";
        //    if (BusinessParam("CusRefMan", busID) != "")
        //    {
        //        if (Convert.ToBoolean(BusinessParam("CusRefMan", busID)))
        //        {
        //            if (txtCustRef == "")
        //            {
        //                // lblCustRefStat.Visible = True
        //                return setSalesOrderHeader = false;
        //                //divData1.Style("display") = "block"
        //            }
        //            else
        //            {
        //                //            lblCustRefStat.Visible = False
        //                //            pnlDateCustRef_Collaps.AutoExpand = False
        //                //            pnlDateCustRef_Collaps.ClientState = "true"
        //                //            divData1.Style("display") = "block"
        //            }
        //        }
        //        else
        //        {
        //            //        lblCustRefStat.Visible = False
        //            //        pnlDateCustRef_Collaps.AutoExpand = False
        //            //        pnlDateCustRef_Collaps.ClientState = "true"
        //            //        divData1.Style("display") = "block"
        //        }
        //    }
        //    else
        //    {
        //        //        lblCustRefStat.Visible = False
        //        //        pnlDateCustRef_Collaps.AutoExpand = False
        //        //        pnlDateCustRef_Collaps.ClientState = "true"
        //        //        divData1.Style("display") = "block"
        //    }
        //    if (optNewAddr)
        //    {
        //        if (txtDelAddDesc == "")
        //        {
        //            //        lblDelDescStat.Visible = True
        //            return setSalesOrderHeader = false;
        //        }
        //        else
        //        {
        //            // lblDelDescStat.Visible = False
        //        }
        //    }
        //    else
        //    {
        //        //    lblDelDescStat.Visible = False
        //    }

        //    if (BusinessParam("NOMCODEMAN", busID) != "")
        //    {
        //        if (Convert.ToBoolean(BusinessParam("NOMCODEMAN", busID)))
        //        {
        //            if (Convert.ToBoolean(HttpContext.Current.Session["ONLNEREQNOM1"]))
        //            {
        //                if (GetSiteCodes())
        //                {
        //                    if (cboSiteCode == "")
        //                    {
        //                        return setSalesOrderHeader = false;
        //                    }
        //                    else
        //                    {
        //                        //     validateSiteCode.Visible = False
        //                        //lblNomCode1.Visible = False
        //                    }
        //                }
        //                else
        //                {
        //                    if (txtNomCode == "")
        //                    {
        //                        //lblNomCode1.Visible = True
        //                        //validateSiteCode.Visible = False
        //                        //SetSalesHeader = False
        //                        return setSalesOrderHeader = false;
        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //lblNomCode1.Visible = False
        //                //validateSiteCode.Visible = False
        //            }

        //            if (Convert.ToBoolean(HttpContext.Current.Session["ONLNEREQNOM2"]))
        //            {
        //                if (txtNomCode1 == "")
        //                {
        //                    return setSalesOrderHeader = false;
        //                }
        //                else
        //                {
        //                    //lblNomCode2.Visible = False
        //                }
        //            }
        //            else
        //            {
        //                //lblNomCode2.Visible = False
        //            }
        //            if (Convert.ToBoolean(HttpContext.Current.Session["ONLNEREQNOM3"]))
        //            {
        //                if (txtNomCode2 == "")
        //                {
        //                    setSalesOrderHeader = false;
        //                }
        //                else
        //                {
        //                    //lblNomCode3.Visible = False
        //                }
        //            }
        //            else
        //            {
        //                //lblNomCode3.Visible = False
        //            }
        //            if (Convert.ToBoolean(HttpContext.Current.Session["ONLNEREQNOM4"]))
        //            {
        //                if (txtNomCode3.Trim() == "")
        //                {
        //                    //lblNomCode4.Visible = True
        //                    setSalesOrderHeader = false;
        //                    return setSalesOrderHeader;
        //                }
        //                else
        //                {
        //                    //lblNomCode3.Visible = False
        //                }
        //            }
        //            else
        //            {
        //                // lblNomCode4.Visible = False
        //            }
        //            if (Convert.ToBoolean(HttpContext.Current.Session["ONLNEREQNOM5"]))
        //            {
        //                if (txtNomCode4.Trim() != "")
        //                {
        //                    setSalesOrderHeader = false;
        //                    return setSalesOrderHeader;
        //                }
        //                else
        //                {
        //                    //                lblNomCode5.Visible = False
        //                }
        //            }
        //            else
        //            {
        //                //            lblNomCode5.Visible = False
        //            }
        //            if (!CheckFreetext())
        //            {
        //                setSalesOrderHeader = false;
        //                return setSalesOrderHeader;
        //            }
        //            else
        //            {

        //            }
        //            string booCheckLine = "";
        //            int AnnualIssue = 0;
        //            if (isBulk != "")
        //            {
        //                if (!Convert.ToBoolean(booBulk))
        //                {
        //                    if (Convert.ToBoolean(HttpContext.Current.Session["POINTSREQ"]) & IsRolloutOrder)
        //                    {
        //                        booCheckLine = "";
        //                    }
        //                    else
        //                    {
        //                        //booCheckLine= EmpEntilementGridCheck(, AnnualIssue)
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (Convert.ToBoolean(HttpContext.Current.Session["POINTSREQ"]) & IsRolloutOrder)
        //                {
        //                    booCheckLine = "";
        //                }
        //                else
        //                {
        //                    //booCheckLine= EmpEntilementGridCheck(, AnnualIssue)
        //                }
        //            }
        //            if (booCheckLine != "")
        //            {
        //                setSalesOrderHeader = false;
        //                return setSalesOrderHeader;
        //            }
        //            else
        //            {

        //            }
        //            string InvalidEmpId = "";
        //            InvalidEmpId = CheckValidEmployee();
        //            if (InvalidEmpId != "")
        //            {
        //                //    If Not modMain.ControlHidden("CreateEmployee") Then
        //                //        If CBoolstr(BusinessParam("CUSTCREATEEMP", strCustID)) Then
        //                //            WriteScript("<script language='javascript'> var win1; if(win1==null || win1.closed) win1=window.open('CreateEmployee.aspx?pagefrom=1&empid=" & InvalidEmpID & "','','resizable=yes,scrollbars=yes,width=700,height=500,top=200,left=100'); </script>")
        //                //        End If
        //                //    End If
        //                //    SetSalesHeader = False
        //                //    Exit Function
        //            }
        //            tmpbusiness = GetBusinessAccount(tBusinessAccount, strCustID);
        //            var dat = (SalesOrderHeaderViewModel)HttpContext.Current.Session["objCurrentOrder"];
        //            dat.CompanyID = cmpId;
        //            dat.WarehouseID = strWarehouse;
        //            dat.CustID = strCustID;
        //            if (strCustID == "")
        //            {
        //                //        WriteScript("<script language='javascript'> alert('" & Convert.ToString(GetLocalResourceObject("Alert1.Text")) & "'); document.location.href='Online_Login.aspx'; </script>")
        //            }
        //            //    If cboCarrier.Items.Count > 0 Then
        //            //        carrArr = Split(cboCarrier.Items(cboCarrier.SelectedIndex).Value, "|")
        //            //        .Carrier = carrArr(0)
        //            //    Else
        //            //        .Carrier = 0
        //            //    End If
        //            dat.CarrierCharge = Convert.ToDecimal(txtCarrierCharge);
        //            dat.CustRef = txtCustRef == "" ? BusinessParam("CustRefDef", strCustID) : txtCustRef;
        //            dat.Currency_Exchange_Code = tmpbusiness.CurrencyName;
        //            dat.VatFlag = tmpbusiness.VatFlag;
        //            dat.VATPercent = GetVatCodes(SetVatCodes(), tmpbusiness.VatCode).VatPercent;
        //            dat.RepID = tmpbusiness.RepID;
        //            dat.OrderDate = DateTime.Parse(txtOrdDate);
        //            dat.UserID = HttpContext.Current.Session["UserName"] == null ? "" : HttpContext.Current.Session["UserName"].ToString();
        //            dat.Currency_Exchange_Rate = Convert.ToInt32(tmpbusiness.ExchangeRate) == 0 ? 1 : tmpbusiness.ExchangeRate;
        //            dat.Carrier = txtCarrier;
        //            dat.VatCode = tmpbusiness.VatCode;
        //            dat.KAMid = getKAM(SetKam(), Convert.ToInt32(dat.RepID)).KamID;
        //            //    .EmployeeID = IIf(IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")) = vbNullString, "", IIf(Request.QueryString("Pinno") = "", Session.Item("EmpID"), Request.QueryString("Pinno")))
        //            if (dat.EmployeeID == strCustID)
        //            {
        //                dat.EmployeeID = "";
        //            }
        //            dat.UCodeId = HttpContext.Current.Session["Ucode"] == null ? "" : HttpContext.Current.Session["Ucode"].ToString();
        //            dat.CommentsExternal = txtCommentsExternal;
        //            //dat.ReasonCode = txtReasoncode!=""?Convert.ToInt32(txtReasoncode):0;
        //            dat.NomCode = txtNomCode;
        //            dat.NomCode1 = txtNomCode1;
        //            dat.NomCode2 = txtNomCode2;
        //            dat.NomCode3 = txtNomCode3;
        //            dat.NomCode4 = txtNomCode4;
        //            dat.OrderType = "SO";
        //            dat.InvDesc = txtCustAddDesc;
        //            dat.InvAddress1 = txtCustAdd1;
        //            dat.InvAddress2 = txtCustAdd2;
        //            dat.InvAddress3 = txtCustAdd3;
        //            dat.DelAddress1 = txtDelAdd1;
        //            dat.DelAddress2 = txtDelAdd2;
        //            dat.DelAddress3 = txtDelAdd3;
        //            dat.DelTown = txtDelTown;
        //            dat.DelCity = txtDelCity;
        //            dat.DelPostCode = txtDelPost;
        //            dat.DelCountry = txtDelCountry;
        //            dat.DelDesc = txtDelAddDesc;
        //            dat.InvPostCode = txtCustCountry;
        //            dat.InvCountry = txtCustCountry;
        //            dat.InvCity = txtCustCity;
        //            dat.InvPostCode = txtCustPost;
        //        }
        //    }
        //    if (HttpContext.Current.Session["objCurrentOrder"] == "")
        //    {
        //        setSalesOrderHeader = false;
        //    }
        //    else
        //    {

        //    }
        //    //If cboDelAddress.Items.Count > 1 And Session.Item("objCurrentOrder").DelDesc = "" Then
        //    //    SetSalesHeader = Falsec
        //    //    divData4.Style("display") = "block"
        //    //    lbl_ValidAddress.Visible = True
        //    //    Collaps_delAdrs.Collapsed = False
        //    //    Collaps_delAdrs.ClientState = "false"
        //    //    ClientScript.RegisterStartupScript(Me.GetType(), "hash", "location.hash = '#daddress';", True)
        //    //    Exit Function
        //    //Else
        //    //    lbl_ValidAddress.Visible = False
        //    //    Collaps_delAdrs.Collapsed = True
        //    //    Collaps_delAdrs.ClientState = "true"
        //    //    '  divData4.Style("display") = "none"
        //    //End If
        //    return false;
        //}

        #endregion

        #region CheckValidEmployee
        public string CheckValidEmployee(SalesOrderHeaderViewModel objCurrentOrder, List<SalesOrderHeaderViewModel> objManPackOrderCollection, string strCustID, string empId = "")
        {
            string myEmpId = "", sql = "", booValidEmp = ""; MySqlConnection conn = new MySqlConnection(ConnectionString);
            bool isManpack = false;
            if (isManpack == false)
            {
                if (((SalesOrderHeaderViewModel)objCurrentOrder).SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                {
                    myEmpId = (objCurrentOrder).EmployeeID;
                    if (myEmpId != "")
                    {
                        sql = "SELECT EmployeeID,Title,Forename,Surname,EmployeeClosed FROM tblaccemp_employee WHERE CompanyID='" + cmpId + "' and BusinessID='" + strCustID + "' and EmployeeID = '" + myEmpId + "' order by EmployeeID";
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sql = "SELECT BusinessID FROM tblaccemp_employee WHERE CompanyID='" + cmpId + "' and BusinessID='" + myEmpId + "'";
                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    booValidEmp = myEmpId;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn(e.Message);
                            logger.Warn(e.StackTrace);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else if (isManpack)
            {
                if ((objManPackOrderCollection).Count > 0)
                {
                    var data = (objManPackOrderCollection);
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                        {
                            myEmpId = data[i].EmployeeID;
                            if (myEmpId != "")
                            {
                                sql = "SELECT EmployeeID,Title,Forename,Surname,EmployeeClosed FROM tblaccemp_employee WHERE CompanyID='" + cmpId + "' and BusinessID='" + strCustID + "' and EmployeeID = '" + myEmpId + "' order by EmployeeID";
                                try
                                {
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        booValidEmp = myEmpId;
                                    }
                                }
                                catch (Exception e)
                                {
                                    logger.Warn(e.Message);
                                    logger.Warn(e.StackTrace);
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }
                    }
                    if ((objCurrentOrder).SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                    {
                        myEmpId = (objCurrentOrder).EmployeeID;
                        if (myEmpId != "")
                        {
                            sql = "SELECT EmployeeID,Title,Forename,Surname,EmployeeClosed FROM tblaccemp_employee WHERE CompanyID='" + cmpId + "' and BusinessID='" + strCustID + "' and EmployeeID = '" + myEmpId + "' order by EmployeeID";
                            try
                            {
                                conn.Open();
                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    booValidEmp = myEmpId;
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Warn(e.Message);
                                logger.Warn(e.StackTrace);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        else
                        {
                            if ((objCurrentOrder).SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                            {
                                myEmpId = (objCurrentOrder).EmployeeID;
                                if (myEmpId != "")
                                {
                                    sql = "SELECT EmployeeID,Title,Forename,Surname,EmployeeClosed FROM tblaccemp_employee WHERE CompanyID='" + cmpId + "' and BusinessID='" + strCustID + "' and EmployeeID = '" + myEmpId + "' order by EmployeeID";
                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    if (dt.Rows.Count > 0)
                                    {
                                        booValidEmp = myEmpId;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return booValidEmp;
        }
        #endregion

        #region EmpEntilementGridCheck
        //public string EmpEntilementGridCheck(long indx=0,int annualIssue=0)
        //{

        //}
        #endregion

        #region CheckFreetext
        public bool CheckFreetext(List<SalesOrderLineViewModel> SalesOrderLines, List<SalesOrderHeaderViewModel> SalesOrderHeader, int mIndex = 0)
        {
            int errorIndx = -1;
            SalesOrderLineViewModel mline = new SalesOrderLineViewModel();
            if (mIndex == 0)
            {
                var data = (SalesOrderLines);
                var count = (SalesOrderLines).Count;
                for (int i = 0; i < count; i++)
                {
                    if (data[i].FreeText1 == "" | data[i].FreeText1.Contains("*"))
                    {
                        try
                        {
                            SalesOrderHeaderViewModel sh = new SalesOrderHeaderViewModel();
                            sh = (SalesOrderHeader)[i];
                            if (sh.EmployeeID != "")
                            {

                            }
                            else
                            {

                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn(e.Message);
                            logger.Warn(e.StackTrace);
                        }
                        errorIndx = i - 1;
                        return false;
                    }
                }

            }
            else
            {
                var data = (SalesOrderLines);
                var count = (SalesOrderLines).Count;
                for (int i = 1; i < count; i++)
                {
                    if (data[i].FreeText1 == "" | data[i].FreeText1.Contains("*"))
                    {
                        SalesOrderHeaderViewModel sh = new SalesOrderHeaderViewModel();
                        // sh = ((List<SalesOrderHeaderViewModel>)HttpContext.Current.Session["SalesOrderHeader"])[i];
                        if (mIndex > 1)
                        {
                            for (int iss = 1; iss < mIndex - 1; iss++)
                            {
                                errorIndx += (SalesOrderHeader)[i].SalesOrderLine.Where(s => s.IsDleted == false).Count();
                            }
                        }
                        errorIndx += i;
                        errorIndx -= 1;
                        return false;
                    }
                }
            }
            return true;
        }


        #endregion

        #region  setKam
        public List<TKAM> SetKam()
        {
            TKAM tmpKam = new TKAM();
            string sSqry = "";
            sSqry = "Select * from tblrep_kams";
            List<TKAM> tmpColKam = new List<TKAM>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    tmpKam.KamID = Convert.ToInt32(dr["KamID"].ToString());
                    tmpKam.RepID = Convert.ToInt32(dr["RepID"].ToString());
                    tmpKam.booSet = true;
                    tmpColKam.Add(tmpKam);
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return tmpColKam;
        }
        #endregion

        #region GetKam
        public TKAM getKAM(List<TKAM> colkam, int repId)
        {
            TKAM getKam = new TKAM();
            TKAM tmpType = new TKAM();
            foreach (var data in colkam)
            {
                tmpType = data;
                if (tmpType.RepID == repId)
                {
                    getKam = tmpType;
                }
            }
            return getKam;
        }
        #endregion

        #region useVatcode
        public int UseVatCode(string vatFlag, int styleVatcCode, int businessVatCode)
        {
            double vatPercent;
            int UseVatCode = 0;
            List<TVATCODE> tmpColVatCode = new List<TVATCODE>();
            if (vatFlag == "Y")
            {
                vatPercent = GetVatCodes(tmpColVatCode, styleVatcCode).VatPercent;
                if (vatPercent != 0)
                {
                    UseVatCode = businessVatCode;
                }
                else
                {
                    UseVatCode = styleVatcCode;
                }
            }
            else
            {
                UseVatCode = businessVatCode;
            }
            return UseVatCode;
        }

        #endregion

        #region GetStyleReps
        public TStyleReps GetStyleReps(List<TStyleReps> colStyleReps, string strStyle)
        {
            TStyleReps GetStyleReps = new TStyleReps();
            TStyleReps tmptype = new TStyleReps();
            foreach (var data in colStyleReps)
            {
                if (tmptype.StyleID.ToUpper() == strStyle.ToUpper())
                {
                    GetStyleReps = tmptype;
                }
            }
            return GetStyleReps;
        }
        #endregion

        #region SetStyleReps
        public List<TStyleReps> SetStyleReps(string strStyle)
        {
            List<TStyleReps> styleRep = new List<TStyleReps>();
            string sSqry = "";
            string sSqry1 = "";
            sSqry = " SELECT StyleID, RepID, SeqNo FROM tblfsk_style_reps  WHERE CompanyID='" + cmpId + "' AND StyleID='" + strStyle + "'";
            sSqry1 = " SELECT Count(*)   FROM tblfsk_style_reps   WHERE CompanyID='" + cmpId + "' AND StyleID='" + strStyle + "'";

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        styleRep.Add(new TStyleReps { StyleID = dr["StyleID"].ToString(), RepID = Convert.ToInt32(dr["RepID"].ToString()) });
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return styleRep;
        }
        #endregion

        #region getStyle
        public TStyle GetStyle(List<TStyle> colStyle, string strStyle, string strSize)
        {
            long i;
            TStyle tmpStyle = new TStyle();
            foreach (var data in colStyle)
            {
                tmpStyle = data;
                if (tmpStyle.StyleID.ToUpper() == strStyle.ToUpper() & tmpStyle.SizeID == strSize.ToUpper())
                {
                    return tmpStyle;
                }
            }
            return tmpStyle;
        }

        #endregion

        #region getCarrClr
        public string GetCarrClr(string StyleID)
        {
            string result = "";
            string sQry = "";
            sQry = "SELECT ColourID FROM tblfsk_style_colour WHERE CompanyID='" + cmpId + "' AND StyleID='" + StyleID + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                result = cmd.ExecuteScalar().ToString();

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region getCarrSize
        public string GetCarrSize(string StyleID)
        {
            string result = "";
            string sQry = "";
            sQry = "SELECT SizeID FROM tblfsk_style_sizes WHERE CompanyID='" + cmpId + "' AND StyleID='" + StyleID + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                result = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region qryResult
        public int qryResult(string sSqry)
        {
            int i = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = dt.Rows.Count;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return i;
        }
        #endregion

        #region SetStyle
        public List<TStyle> SetStyle(string styleId)
        {
            TStyle tmpStyleType = new TStyle();
            List<TVATCODE> tmpColVatCode = new List<TVATCODE>();
            int tmpVATCode = 0;
            string sSqry1 = "";
            string sSqry = "";
            sSqry = " SELECT tblfsk_style.Description, tblfsk_style.StyleID, tblfsk_style_sizes.SizeID, tblfsk_style.Nominal_Code, tblfsk_style.Product_Group   FROM tblfsk_style INNER JOIN tblfsk_style_sizes ON (tblfsk_style.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style.CompanyID = tblfsk_style_sizes.CompanyID)   WHERE tblfsk_style.Live<>0 and tblfsk_style.CompanyID='" + cmpId + "' and tblfsk_style.StyleID = '" + styleId + "'";
            sSqry1 = " SELECT Count(*)   FROM tblfsk_style INNER JOIN tblfsk_style_sizes ON (tblfsk_style.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style.CompanyID = tblfsk_style_sizes.CompanyID)   WHERE tblfsk_style.Live<>0 and tblfsk_style.CompanyID='" + cmpId + "'  and tblfsk_style.StyleID = '" + styleId + "'";
            List<TStyle> tmpcolStyle = new List<TStyle>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tmpVATCode = 0;
                        tmpStyleType.StyleID = dr["StyleID"].ToString();
                        tmpStyleType.SizeID = dr["SizeID"].ToString();
                        tmpStyleType.NominalCode = dr["Nominal_Code"].ToString();
                        tmpStyleType.Description = dr["Description"].ToString();
                        tmpStyleType.VatCode = tmpVATCode.ToString();
                        tmpStyleType.GroupID = dr["Product_Group"].ToString();
                        tmpColVatCode = SetVatCodes();
                        tmpStyleType.VatPercent = Convert.ToString(GetVatCodes(tmpColVatCode, tmpVATCode).VatPercent);
                        tmpStyleType.booSet = true;
                        tmpcolStyle.Add(tmpStyleType);
                    }
                }

                sSqry = " SELECT tblfsk_style_sizes_prices.StyleID, tblfsk_style_sizes_prices.SizeID, tblfsk_style.Description, tblfsk_style_sizes_prices.Price, tblfsk_style_sizes_prices.PriceID, tblacc_vatcodes.VATPercent, tblfsk_style.Nominal_Code   FROM (tblfsk_style LEFT JOIN tblfsk_style_sizes_prices ON (tblfsk_style.StyleID = tblfsk_style_sizes_prices.StyleID) AND (tblfsk_style.CompanyID = tblfsk_style_sizes_prices.CompanyID)) LEFT JOIN tblacc_vatcodes ON (tblfsk_style_sizes_prices.Price = tblacc_vatcodes.VATCode) AND (tblfsk_style_sizes_prices.CompanyID = tblacc_vatcodes.CompanyID)   WHERE tblfsk_style_sizes_prices.PriceID=6 AND tblfsk_style_sizes_prices.CompanyID='" + cmpId + "' AND tblfsk_style_sizes_prices.BusinessID='ALL' and tblfsk_style_sizes_prices.StyleID = '" + styleId + "'";
                MySqlCommand cmd2 = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var i = FindStyleIndex(tmpcolStyle, dr["StyleID"].ToString(), dr["SizeID"].ToString());
                        tmpcolStyle.Add(new TStyle { VatCode = dr["Price"].ToString(), VatPercent = dr["VATPercent"].ToString() == "" ? "0" : dr["VATPercent"].ToString() });
                    }
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return tmpcolStyle;
        }
        #endregion

        #region GetReasoncode
        public string GetReasonCodes(Int64 reasonLie, string busId)
        {
            string result = "";
            string sSqry = "select  Description from tblsop_reasoncodes where ReasonCode=" + reasonLie + " and businessid='" + busId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteScalar() != null ? cmd.ExecuteScalar().ToString() : "";
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region StyleParam
        public string StyleParam(string paramId, string styleId)
        {
            string strSql = "";
            string StyleParam = "";
            strSql = "SELECT Value FROM tblfsk_setvalues  WHERE CompanyID='" + cmpId + "' AND StyleID='" + styleId + "' AND SettingID='" + paramId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                var data = cmd.ExecuteReader();
                if (data.Read())
                {
                    StyleParam = data.GetString("DefaultValue") == "" ? "" : data.GetString("DefaultValue");
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return StyleParam;
        }
        #endregion

        #region FindStyleIndex
        public int FindStyleIndex(List<TStyle> tmpcolStyle, string StyleID, string size)
        {
            int FindStyleIndex = 0;
            foreach (var data in tmpcolStyle)
            {
                if (data.StyleID == StyleID && data.SizeID == size)
                {
                    FindStyleIndex = tmpcolStyle.IndexOf(data);
                }
            }
            return FindStyleIndex;
        }

        #endregion

        #region GetVatCodes
        public TVATCODE GetVatCodes(List<TVATCODE> colVatCode, int VatCode)
        {

            TVATCODE tmpType = new TVATCODE();
            foreach (var data in colVatCode)
            {
                tmpType = data;
            }
            return tmpType;
        }
        #endregion

        #region SetVatCodes
        public List<TVATCODE> SetVatCodes()
        {
            List<TVATCODE> SetVatCodes = new List<TVATCODE>();
            TVATCODE tmpType = new TVATCODE();
            string sSqry = "";
            string sSqry1 = "";
            sSqry = "Select * from tblacc_vatcodes where CompanyID ='" + cmpId + "' ORDER BY VATCode";
            sSqry1 = "Select count(*) from tblacc_vatcodes where CompanyID ='" + cmpId + "' ORDER BY VATCode";
            List<TVATCODE> tmpcolVatCode = new List<TVATCODE>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tmpType.VatCode = Convert.ToInt32(dr.ItemArray[1].ToString());
                        tmpType.VatPercent = Convert.ToDouble(dr.ItemArray[3].ToString());
                        tmpType.booSet = true;
                        SetVatCodes.Add(tmpType);
                    }
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return SetVatCodes;
        }

        #endregion

        #region ItemPrice
        public double ItemPrice(string mStyle, string mColour, string mSizeid, double mCustCountry, long mPriceList, double mSeqNo, string busId)
        {
            TBusinessAccount tmpBusiness;
            double ItemPrice = 0;
            string sSqry = "";
            sSqry = "SELECT tblfsk_style_sizes.StyleID, tblfsk_style_sizes.SizeID, tblfsk_style_sizes.SeqNo, tblfsk_style_sizes.CompanyID, tblfsk_style_sizes_prices.Price, tblfsk_price.Description, tblfsk_price.PriceID   FROM (tblfsk_price INNER JOIN tblfsk_style_sizes_prices ON (tblfsk_price.PriceID = tblfsk_style_sizes_prices.PriceID) AND (tblfsk_price.CompanyID = tblfsk_style_sizes_prices.CompanyID))   INNER JOIN tblfsk_style_sizes ON (tblfsk_style_sizes.CompanyID = tblfsk_style_sizes_prices.CompanyID) AND (tblfsk_style_sizes.SizeID = tblfsk_style_sizes_prices.SizeID) AND (tblfsk_style_sizes.StyleID = tblfsk_style_sizes_prices.StyleID)   AND (tblfsk_style_sizes_prices.SizeID = tblfsk_style_sizes.SizeID) AND (tblfsk_style_sizes_prices.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style_sizes_prices.CompanyID = tblfsk_style_sizes.CompanyID)   Where (((tblfsk_style_sizes.StyleID) = '" + mStyle + "') And BusinessId='" + busId + "' And tblfsk_style_sizes.SizeID='" + mSizeid + "' and  Country_Currency=" + mCustCountry + " and ((tblfsk_style_sizes.CompanyID) = '" + cmpId + "') And ((tblfsk_price.PriceId) = " + mPriceList + "))  ORDER BY tblfsk_style_sizes.SeqNo, tblfsk_price.Price_Type";
            tmpBusiness = GetBusinessAcount(busId);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);

                var reader = cmd.ExecuteReader();

                if (reader.Read() == false)
                {
                    reader.Close();
                    sSqry = "SELECT tblfsk_style_sizes.StyleID, tblfsk_style_sizes.SizeID, tblfsk_style_sizes.SeqNo, tblfsk_style_sizes.CompanyID, tblfsk_style_sizes_prices.Price, tblfsk_price.Description, tblfsk_price.PriceID   FROM (tblfsk_price INNER JOIN tblfsk_style_sizes_prices ON (tblfsk_price.PriceID = tblfsk_style_sizes_prices.PriceID) AND (tblfsk_price.CompanyID = tblfsk_style_sizes_prices.CompanyID))   INNER JOIN tblfsk_style_sizes ON (tblfsk_style_sizes.CompanyID = tblfsk_style_sizes_prices.CompanyID) AND (tblfsk_style_sizes.SizeID = tblfsk_style_sizes_prices.SizeID) AND (tblfsk_style_sizes.StyleID = tblfsk_style_sizes_prices.StyleID)  AND (tblfsk_style_sizes_prices.SizeID = tblfsk_style_sizes.SizeID) AND (tblfsk_style_sizes_prices.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style_sizes_prices.CompanyID = tblfsk_style_sizes.CompanyID)   Where (((tblfsk_style_sizes.StyleID) = '" + mStyle + "') And BusinessId='ALL' And tblfsk_style_sizes.SizeID='" + mSizeid + "' and  Country_Currency=" + mCustCountry + " and ((tblfsk_style_sizes.CompanyID) = '" + cmpId + "') And ((tblfsk_price.PriceId) = " + mPriceList + "))  ORDER BY tblfsk_style_sizes.SeqNo, tblfsk_price.Price_Type";
                    MySqlCommand cmd1 = new MySqlCommand(sSqry, conn);
                    var reader1 = cmd.ExecuteReader();
                    if (reader1.Read() == false)
                    {
                        reader1.Close();
                        sSqry = "SELECT tblfsk_style_sizes.StyleID, tblfsk_style_sizes.SizeID, tblfsk_style_sizes.SeqNo, tblfsk_style_sizes.CompanyID, tblfsk_style_sizes_prices.Price, tblfsk_price.Description, tblfsk_price.PriceID   FROM (tblfsk_price INNER JOIN tblfsk_style_sizes_prices ON (tblfsk_price.PriceID = tblfsk_style_sizes_prices.PriceID) AND (tblfsk_price.CompanyID = tblfsk_style_sizes_prices.CompanyID))   INNER JOIN tblfsk_style_sizes ON (tblfsk_style_sizes.CompanyID = tblfsk_style_sizes_prices.CompanyID) AND (tblfsk_style_sizes.SizeID = tblfsk_style_sizes_prices.SizeID) AND (tblfsk_style_sizes.StyleID = tblfsk_style_sizes_prices.StyleID)   AND (tblfsk_style_sizes_prices.SizeID = tblfsk_style_sizes.SizeID) AND (tblfsk_style_sizes_prices.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style_sizes_prices.CompanyID = tblfsk_style_sizes.CompanyID)   Where (((tblfsk_style_sizes.StyleID) = '" + mStyle + "') And tblfsk_style_sizes.SizeID='" + mSizeid + "' And ((tblfsk_style_sizes.CompanyID) = '" + cmpId + "') And ((tblfsk_price.priceid) = " + mPriceList + "))  ORDER BY tblfsk_style_sizes.SeqNo, tblfsk_price.Price_Type";
                        MySqlCommand cmd2 = new MySqlCommand(sSqry, conn);
                        MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt2.Rows)
                            {
                                tmpBusiness.ExchangeRate = tmpBusiness.ExchangeRate == 0 ? 1 : tmpBusiness.ExchangeRate;
                                ItemPrice = Math.Round((Convert.ToDouble(dr.ItemArray[4].ToString())) * tmpBusiness.ExchangeRate, 2);
                            }
                        }
                        else
                        {
                            ItemPrice = 0;
                        }
                    }
                    else
                    {
                        ItemPrice = Convert.ToDouble(reader1.GetString("Price"));
                    }
                }
                else
                {
                    ItemPrice = 0;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return ItemPrice;
        }
        #endregion

        #region GetEmpOrUserAddress


        #endregion

        #region Update SalesOrder
        public SaveResultModel UpdateSalesOrder(string access, SalesOrderHeaderViewModel salesHead, int empResetMnths, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, long salesNo = 0, string busId = "", string usrId = "", bool editFlag = false, string POINTSREQ = "", bool FreeStckCheck = false)
        {
            SaveResultModel result = new SaveResultModel();
            int execVal = 0;
            string sSqry = "";
            StringBuilder os = new StringBuilder();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlTransaction trans;
            var salLst = new List<SalesOrderHeaderViewModel>();
            salLst.Add(salesHead);
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {


                if (salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                {
                    try
                    {
                        var delcCode = Convert.ToInt32(salesHead.DelCountry);
                        var invcCode = Convert.ToInt32(salesHead.DelCountry);
                        salesHead.DelCountry = _countryCodes.Exists(x => x.CountryID == delcCode) ? _countryCodes.GetAll(x => x.CountryID == delcCode).First().Country : "";
                        salesHead.InvCountry = _countryCodes.Exists(x => x.CountryID == invcCode) ? _countryCodes.GetAll(x => x.CountryID == invcCode).First().Country : "";
                    }
                    catch (Exception e)
                    {
                        logger.Warn(e.Message);
                        logger.Warn(e.StackTrace);
                    }
                    string DefUserID = BusinessParam("DEFUSRID", busId);
                    string sqlUserXref = "";
                    string UserIDXref = "";
                    sqlUserXref = "SELECT UserID FROM tblOnline_UserID_Xref  WHERE OnlineUserID='" + salesHead.OnlineUserID + "' AND CompanyID='" + cmpId + "' AND BusinessID='" + busId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlUserXref, conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserIDXref = reader.GetString(0);
                    }
                    else if (DefUserID != "")
                    {
                        UserIDXref = DefUserID;
                    }
                    else
                    {
                        UserIDXref = usrId;
                    }
                    reader.Close();
                    StringBuilder oString;
                    string budgetString = "";
                    var partShipment = Convert.ToBoolean(BusinessParam("Partshipment", busId)) == true ? -1 : 0;
                    var cntName = salesHead.ContactName == "" | salesHead.ContactName == null ? "" : salesHead.ContactName + " mobile:" + salesHead.Mobile;
                    if (salesHead.OrderType == "SO" && salesHead.ReasonCode == 0 && CheckEmergency(salesHead.CustID, salesHead.UCodeId) == false)
                    {
                        salesHead.NomCode3 = _employeeRollout.Exists(s => s.EmployeeID == salesHead.EmployeeID && s.BusinessID == salesHead.CustID) ? _employeeRollout.GetAll(s => s.EmployeeID == salesHead.EmployeeID && s.BusinessID == salesHead.CustID).First().RolloutName : "";
                    }
                    Removeapostrophes(salesHead);
                    sSqry = "Update  tblsop_salesorder_header set CompanyID='" + cmpId + "',WarehouseId='" + salesHead.WarehouseID + "', CustID='" + busId + "',InvDesc='" + salesHead.InvDesc + "',InvAddress1='" + salesHead.InvAddress1 + "',InvAddress2='" + salesHead.InvAddress2 + "',InvAddress3='" + salesHead.InvAddress3 + "',InvCity='" + salesHead.InvCity + "',InvTown='" + salesHead.InvTown + "',InvPostCode='" + salesHead.InvPostCode + "',InvCountry='" + salesHead.InvCountry + "', DelDesc='" + salesHead.DelDesc + "',DelAddress1='" + salesHead.DelAddress1 + "',DelAddress2='" + salesHead.DelAddress2 + "',DelAddress3='" + salesHead.DelTown + "',DelCity='" + salesHead.DelCity + "',DelTown='" + salesHead.DelTown + "',DelPostCode='" + salesHead.DelPostCode + "',DelCountry='" + salesHead.DelCountry + "', CustRef='" + salesHead.CustRef + "',Carrier='" + salesHead.Carrier + "',CarrierCharge='" + salesHead.CarrierCharge + "',Comments='" + salesHead.Comments + "',CommentsExternal='" + salesHead.CommentsExternal + "',Totalgoods=" + GetAlltotals(salLst, salesHead.CarrierCharge.Value).Total + ",ordergoods=" + GetAlltotals(salLst, salesHead.CarrierCharge.Value).gross + ",Currency_Exchange_Rate=" + salesHead.Currency_Exchange_Rate + ",UserId='" + UserIDXref + "',PinNo='" + salesHead.EmployeeID + "',UCodeId='" + salesHead.UCodeId + "',Currency_Exchange_Code='" + salesHead.Currency_Exchange_Code + "',TimeOfEntry='" + DateTime.Now.ToString("hh:mm:ss") + "',RepID=" + salesHead.RepID + ",ReasonCode=" + salesHead.ReasonCode + ",OnlineUserID='" + salesHead.OnlineUserID + "', OrderAnalysisCode1='" + salesHead.NomCode + "', OrderAnalysisCode2='" + salesHead.NomCode1 + "', OrderAnalysisCode3='" + salesHead.NomCode2 + "', OrderAnalysisCode4='" + salesHead.NomCode3 + "', OrderAnalysisCode5='" + salesHead.NomCode4 + "', AllowPartShipment=" + partShipment + ", OrderType='" + salesHead.OrderType + "',`ContractRef`='" + salesHead.ContractRef + "',`EmailID`='" + salesHead.EmailID + "',`ContactName`='" + cntName + "' where OrderNo=" + salesHead.OrderNo;

                    execVal = ExecuteQuery(conn, sSqry);
                    if (execVal > 0)
                    {
                        string orderFlg = "Edit Order";
                        OrderLog(Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, salesHead.OrderNo, salesHead.OrderType.ToUpper() + "-Start", salesHead.OrderType.ToUpper() + "- Header Saved Mode : " + orderFlg);
                        if (os == null)
                        {
                            oString = new StringBuilder();
                        }
                        else
                        {
                            oString = os;
                        }
                        budgetString = salesHead.OrderDate + "," + salesHead.OrderNo + "," + salesHead.EmployeeID + "," + usrId;
                        oString.AppendLine(budgetString);
                        os = oString;
                        if (salesHead.CustRef != "")
                        {

                            string sSQL = "SELECT * FROM tblsop_customer_ref WHERE CompanyID='" + cmpId + "' AND Custid='" + salesHead.CustID + "' AND Custref='" + salesHead.CustRef + "'";
                            try
                            {
                                MySqlCommand cmd2 = new MySqlCommand(sSQL, conn);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count == 0)
                                {
                                    sSQL = "INSERT INTO tblsop_customer_ref (CompanyID,Custid,custref ) VALUES('" + cmpId + "','" + busId + "','" + salesHead.CustRef + "')";
                                    if (ExecuteQuery(conn, sSQL) == 0)
                                    {

                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Warn(e.Message);
                                logger.Warn(e.StackTrace);
                            }
                            finally
                            {

                            }

                        }
                        // saving salesorder lines
                        result = SaveSalesorderlines(IsRollOutOrder, conn, salesHead, salesNo, busId, POINTSREQ, empResetMnths, access, FreeStckCheck, true);
                        if (result.result == false)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                        }
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        #region 
        public int CheckForProjectCode(string sSql)
        {
            int result = 0;
            if (sSql != "")
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sSql, conn);
                    result = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        #endregion

        #region IsChargableItem
        public bool IsChargableItem(int assmId, int assLine)
        {
            string sqlC = "";
            bool result = false;
            sqlC = "SELECT *  FROM tblasm_assemblydetail  WHERE AssemblyID=" + assmId + " AND LineNo=" + assLine + " AND isChargeable = True";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlC, conn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region SaveSalesOrder
        public SaveResultModel SaveSalesOrder(string access, SalesOrderHeaderViewModel salesHead, int empResetMnths, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, long salesNo = 0, string busId = "", string usrId = "", bool editFlag = false, string POINTSREQ = "", bool FreeStckCheck = false)
        {
            SaveResultModel result = new SaveResultModel();
            int execVal = 0;
            string sSqry = "";
            StringBuilder os = new StringBuilder();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlTransaction trans;
            var salLst = new List<SalesOrderHeaderViewModel>();
            salLst.Add(salesHead);
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                if (salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0 && salesNo > 0)
                {
                    try
                    {
                        var delcCode = Convert.ToInt32(salesHead.DelCountry);
                        var invcCode = Convert.ToInt32(salesHead.DelCountry);
                        salesHead.DelCountry = _countryCodes.Exists(x => x.CountryID == delcCode) ? _countryCodes.GetAll(x => x.CountryID == delcCode).First().Country : "";
                        salesHead.InvCountry = _countryCodes.Exists(x => x.CountryID == invcCode) ? _countryCodes.GetAll(x => x.CountryID == invcCode).First().Country : "";
                    }
                    catch (Exception e)
                    {
                        logger.Warn(e.Message);
                        logger.Warn(e.StackTrace);

                    }
                    string DefUserID = BusinessParam("DEFUSRID", busId);
                    string sqlUserXref = "";
                    string UserIDXref = "";
                    sqlUserXref = "SELECT UserID FROM tblOnline_UserID_Xref  WHERE OnlineUserID='" + usrId + "' AND CompanyID='" + cmpId + "' AND BusinessID='" + busId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlUserXref, conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserIDXref = reader.GetString(0);
                    }
                    else if (DefUserID != "")
                    {
                        UserIDXref = DefUserID;
                    }
                    else
                    {
                        UserIDXref = usrId;
                    }

                    reader.Close();
                    StringBuilder oString;
                    string budgetString = "";
                    var partShipment = Convert.ToBoolean(BusinessParam("Partshipment", busId)) == true ? -1 : 0;
                    var cntName = salesHead.ContactName == "" | salesHead.ContactName == null ? "" : salesHead.ContactName + " mobile:" + salesHead.Mobile;
                    if (salesHead.OrderType == "SO" && salesHead.ReasonCode == 0 && CheckEmergency(salesHead.CustID, salesHead.UCodeId) == false)
                    {
                        salesHead.NomCode3 = _employeeRollout.Exists(s => s.EmployeeID == salesHead.EmployeeID && s.BusinessID == salesHead.CustID) ? _employeeRollout.GetAll(s => s.EmployeeID == salesHead.EmployeeID && s.BusinessID == salesHead.CustID).First().RolloutName : "";
                    }
                    Removeapostrophes(salesHead);
                    sSqry = "INSERT INTO tblsop_salesorder_header(CompanyID,WarehouseId,OrderNo,CustID,OrderDate,InvDesc,InvAddress1,InvAddress2,InvAddress3,InvCity,InvTown,InvPostCode,InvCountry, DelDesc,DelAddress1,DelAddress2,DelAddress3,DelCity,DelTown,DelPostCode,DelCountry, CustRef,Carrier,CarrierCharge,Comments,CommentsExternal,Totalgoods,ordergoods,Currency_Exchange_Rate,UserId,PinNo,UCodeId,Currency_Exchange_Code,TimeOfEntry,RepID,ReasonCode,OnlineUserID, OrderAnalysisCode1, OrderAnalysisCode2, OrderAnalysisCode3, OrderAnalysisCode4, OrderAnalysisCode5, AllowPartShipment, OrderType,`ContractRef`,`EmailID`,`ContactName`)  VALUES('" + cmpId + "','" + salesHead.WarehouseID + "'," + salesNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + salesHead.InvDesc + "','" + salesHead.InvAddress1 + "','" + salesHead.InvAddress2 + "','" + salesHead.InvAddress3 + "','" + salesHead.InvCity + "','" + salesHead.InvTown + "','" + salesHead.InvPostCode + "','" + salesHead.InvCountry + "','" + salesHead.DelDesc + "','" + salesHead.DelAddress1 + "','" + salesHead.DelAddress2 + "','" + salesHead.DelAddress3 + "','" + salesHead.DelCity + "','" + salesHead.DelTown + "','" + salesHead.DelPostCode + "','" + salesHead.DelCountry + "','" + salesHead.CustRef + "','" + salesHead.Carrier + "'," + salesHead.CarrierCharge + ",'" + salesHead.Comments + "','" + salesHead.CommentsExternal + "'," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).Total + "," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).gross + "," + salesHead.Currency_Exchange_Rate + ",'" + UserIDXref + "','" + salesHead.EmployeeID + "','" + salesHead.UCodeId + "','" + salesHead.Currency_Exchange_Code + "','" + DateTime.Now.ToString("hh:mm:ss") + "'," + salesHead.RepID + "," + salesHead.ReasonCode + ",'" + usrId + "','" + salesHead.NomCode + "','" + salesHead.NomCode1 +
                   "','" + salesHead.NomCode2 + "','" + salesHead.NomCode3 + "','" + salesHead.NomCode4 + "'," + partShipment + ",'" + salesHead.OrderType + "', '" + salesHead.ContractRef + "', '" + salesHead.EmailID + "','" + cntName + "')";
                    execVal = ExecuteQuery(conn, sSqry);
                    if (execVal > 0)
                    {
                        string orderFlg = editFlag ? "Edit Order" : "New Order";
                        OrderLog(Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, salesNo, salesHead.OrderType.ToUpper() + "-Start", salesHead.OrderType.ToUpper() + "- Header Saved Mode : " + orderFlg);
                        if (os == null)
                        {
                            oString = new StringBuilder();
                        }
                        else
                        {
                            oString = os;
                        }
                        budgetString = salesHead.OrderDate + "," + salesNo + "," + salesHead.EmployeeID + "," + usrId;
                        oString.AppendLine(budgetString);
                        os = oString;
                        if (salesHead.CustRef != "")
                        {
                            if (editFlag == false)
                            {
                                string sSQL = "SELECT * FROM tblsop_customer_ref WHERE CompanyID='" + cmpId + "' AND Custid='" + salesHead.CustID + "' AND Custref='" + salesHead.CustRef + "'";
                                try
                                {
                                    MySqlCommand cmd2 = new MySqlCommand(sSQL, conn);
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count == 0)
                                    {
                                        sSQL = "INSERT INTO tblsop_customer_ref (CompanyID,Custid,custref ) VALUES('" + cmpId + "','" + busId + "','" + salesHead.CustRef + "')";
                                        if (ExecuteQuery(conn, sSQL) == 0)
                                        {

                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    logger.Warn(e.Message);
                                    logger.Warn(e.StackTrace);
                                }
                                finally
                                {

                                }
                            }
                            else
                            {
                                //update
                            }
                        }
                        // saving salesorder lines
                        result = SaveSalesorderlines(IsRollOutOrder, conn, salesHead, salesNo, busId, POINTSREQ, empResetMnths, access, FreeStckCheck);
                        if (result.result == false)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                        }
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region removeapostrophes

        public void Removeapostrophes(SalesOrderHeaderViewModel vm)
        {
            vm.CommentsExternal = vm.CommentsExternal != null ? vm.CommentsExternal.Replace("'", " ") : vm.CommentsExternal;
            vm.Comments = vm.Comments != null ? vm.Comments.Replace("'", " ") : vm.Comments;
            vm.EmployeeName = vm.EmployeeName != null ? vm.EmployeeName.Replace("'", " ") : vm.EmployeeName;
            vm.OrderAnalysisCode4 = vm.OrderAnalysisCode4 != null ? vm.OrderAnalysisCode4.Replace("'", " ") : vm.OrderAnalysisCode4;
            vm.DelAddress1 = vm.DelAddress1 != null ? vm.DelAddress1.Replace("'", " ") : vm.DelAddress1;
            vm.DelAddress2 = vm.DelAddress2 != null ? vm.DelAddress2.Replace("'", " ") : vm.DelAddress2;
            vm.DelAddress3 = vm.DelAddress3 != null ? vm.DelAddress3.Replace("'", " ") : vm.DelAddress3;
            vm.DelCity = vm.DelCity != null ? vm.DelCity.Replace("'", " ") : vm.DelCity;
            vm.DelCountry = vm.DelCountry != null ? vm.DelCountry.Replace("'", " ") : vm.DelCountry;
            vm.DelDesc = vm.DelDesc != null ? vm.DelDesc.Replace("'", " ") : vm.DelDesc;
            vm.DelPostCode = vm.DelPostCode != null ? vm.DelPostCode.Replace("'", " ") : vm.DelPostCode;
            vm.DelTown = vm.DelTown != null ? vm.DelTown.Replace("'", " ") : vm.DelTown;
            vm.InvDesc = vm.InvDesc != null ? vm.InvDesc.Replace("'", " ") : vm.InvDesc;
            vm.InvAddress1 = vm.InvAddress1 != null ? vm.InvAddress1.Replace("'", " ") : vm.InvAddress1;
            vm.InvAddress2 = vm.InvAddress2 != null ? vm.InvAddress2.Replace("'", " ") : vm.InvAddress2;
            vm.InvAddress3 = vm.InvAddress3 != null ? vm.InvAddress3.Replace("'", " ") : vm.InvAddress3;
            vm.InvCity = vm.InvCity != null ? vm.InvCity.Replace("'", " ") : vm.InvCity;
            vm.InvCountry = vm.InvCountry != null ? vm.InvCountry.Replace("'", " ") : vm.InvCountry;
            vm.InvTown = vm.InvTown != null ? vm.InvTown.Replace("'", " ") : vm.InvTown;
            vm.ContactName = vm.ContactName != null ? vm.ContactName.Replace("'", " ") : vm.ContactName;
        }

        #endregion


        #region SaveSalesOrder
        public SaveResultModel SaveReturnOrder(string access, MySqlConnection conn, SalesOrderHeaderViewModel salesHead, int empResetMnths, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, long salesNo = 0, string busId = "", string usrId = "", bool editFlag = false, string POINTSREQ = "", bool isPrivate = false)
        {
            SaveResultModel result = new SaveResultModel();
            int execVal = 0;
            string sSqry = "";
            StringBuilder os = new StringBuilder();
            var salLst = new List<SalesOrderHeaderViewModel>();
            salLst.Add(salesHead);
            try
            {
                if (salesNo > 0)
                {
                    string DefUserID = BusinessParam("DEFUSRID", busId);
                    string sqlUserXref = "";
                    string UserIDXref = "";
                    sqlUserXref = "SELECT UserID FROM tblOnline_UserID_Xref  WHERE OnlineUserID='" + usrId + "' AND CompanyID='" + cmpId + "' AND BusinessID='" + busId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlUserXref, conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserIDXref = reader.GetString(0);
                    }
                    else if (DefUserID != "")
                    {
                        UserIDXref = DefUserID;
                    }
                    else
                    {
                        UserIDXref = usrId;
                    }

                    reader.Close();
                    StringBuilder oString;
                    string budgetString = "";
                    var partShipment = Convert.ToBoolean(BusinessParam("Partshipment", busId)) == true ? -1 : 0;
                    var cntName = salesHead.ContactName == "" | salesHead.ContactName == null ? "" : salesHead.ContactName + " mobile:" + salesHead.Mobile;
                    Removeapostrophes(salesHead);
                    if (salesHead.IsEditing)
                    {
                        sSqry = "Update  tblsop_salesorder_header set CompanyID='" + cmpId + "',WarehouseId='" + salesHead.WarehouseID + "', CustID='" + busId + "',InvDesc='" + salesHead.InvDesc + "',InvAddress1='" + salesHead.InvAddress1 + "',InvAddress2='" + salesHead.InvAddress2 + "',InvAddress3='" + salesHead.InvAddress3 + "',InvCity='" + salesHead.InvCity + "',InvTown='" + salesHead.InvTown + "',InvPostCode='" + salesHead.InvPostCode + "',InvCountry='" + salesHead.InvCountry + "', DelDesc='" + salesHead.DelDesc + "',DelAddress1='" + salesHead.DelAddress1 + "',DelAddress2='" + salesHead.DelAddress2 + "',DelAddress3='" + salesHead.DelTown + "',DelCity='" + salesHead.DelCity + "',DelTown='" + salesHead.DelTown + "',DelPostCode='" + salesHead.DelPostCode + "',DelCountry='" + salesHead.DelCountry + "', CustRef='" + salesHead.CustRef + "',Carrier='" + salesHead.Carrier + "',CarrierCharge='" + salesHead.CarrierCharge + "',Comments='" + salesHead.Comments + "',CommentsExternal='" + salesHead.CommentsExternal + "',Totalgoods=" + GetAlltotals(salLst, salesHead.CarrierCharge.Value).Total + ",ordergoods=" + GetAlltotals(salLst, salesHead.CarrierCharge.Value).gross + ",Currency_Exchange_Rate=" + salesHead.Currency_Exchange_Rate + ",UserId='" + UserIDXref + "',PinNo='" + salesHead.EmployeeID + "',UCodeId='" + salesHead.UCodeId + "',Currency_Exchange_Code='" + salesHead.Currency_Exchange_Code + "',TimeOfEntry='" + DateTime.Now.ToString("hh:mm:ss") + "',RepID=" + salesHead.RepID + ",ReasonCode=" + salesHead.ReasonCode + ",OnlineUserID='" + usrId + "', OrderAnalysisCode1='" + salesHead.NomCode + "', OrderAnalysisCode2='" + salesHead.NomCode1 + "', OrderAnalysisCode3='" + salesHead.NomCode2 + "', OrderAnalysisCode4='" + salesHead.NomCode3 + "', OrderAnalysisCode5='" + salesHead.NomCode4 + "', AllowPartShipment=" + partShipment + ", OrderType='" + salesHead.OrderType + "',`ContractRef`='" + salesHead.ContractRef + "',`EmailID`='" + salesHead.EmailID + "',`ContactName`='" + cntName + "' where OrderNo=" + salesHead.OrderNo;
                    }
                    else
                    {
                        sSqry = "INSERT INTO tblsop_salesorder_header(CompanyID,WarehouseId,OrderNo,CustID,OrderDate,InvDesc,InvAddress1,InvAddress2,InvAddress3,InvCity,InvTown,InvPostCode,InvCountry, DelDesc,DelAddress1,DelAddress2,DelAddress3,DelCity,DelTown,DelPostCode,DelCountry, CustRef,Carrier,CarrierCharge,Comments,CommentsExternal,Totalgoods,ordergoods,Currency_Exchange_Rate,UserId,PinNo,UCodeId,Currency_Exchange_Code,TimeOfEntry,RepID,ReasonCode,OnlineUserID, OrderAnalysisCode1, OrderAnalysisCode2, OrderAnalysisCode3, OrderAnalysisCode4, OrderAnalysisCode5, AllowPartShipment, OrderType,`ContractRef`,`EmailID`,`ContactName`)  VALUES('" + cmpId + "','" + salesHead.WarehouseID + "'," + salesNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + salesHead.InvDesc + "','" + salesHead.InvAddress1 + "','" + salesHead.InvAddress2 + "','" + salesHead.InvAddress3 + "','" + salesHead.InvCity + "','" + salesHead.InvTown + "','" + salesHead.InvPostCode + "','" + salesHead.InvCountry + "','" + salesHead.DelDesc + "','" + salesHead.DelAddress1 + "','" + salesHead.DelAddress2 + "','" + salesHead.DelAddress3 + "','" + salesHead.DelCity + "','" + salesHead.DelTown + "','" + salesHead.DelPostCode + "','" + salesHead.DelCountry + "','" + salesHead.CustRef + "','" + salesHead.Carrier + "'," + salesHead.CarrierCharge + ",'" + salesHead.Comments + "','" + salesHead.CommentsExternal + "'," + GetAlltotals(salLst, salesHead.CarrierCharge.Value, false).Total + "," + GetAlltotals(salLst, salesHead.CarrierCharge.Value, false).gross + "," + salesHead.Currency_Exchange_Rate + ",'" + UserIDXref + "','" + salesHead.EmployeeID + "','" + salesHead.UCodeId + "','" + salesHead.Currency_Exchange_Code + "','" + DateTime.Now.ToString("hh:mm:ss") + "'," + salesHead.RepID + "," + salesHead.ReasonCode + ",'" + usrId + "','" + salesHead.NomCode + "','" + salesHead.NomCode1 +
                 "','" + salesHead.NomCode2 + "','" + salesHead.NomCode3 + "','" + salesHead.NomCode4 + "'," + partShipment + ",'" + salesHead.OrderType + "', '" + salesHead.ContractRef + "', '" + salesHead.EmailID + "','" + cntName + "')";
                    }
                    execVal = ExecuteQuery(conn, sSqry);
                    if (execVal > 0)
                    {
                        string orderFlg = salesHead.IsEditing ? "Edit Order" : "New Return Order";
                        OrderLog(Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, salesNo, salesHead.OrderType.ToUpper() + "-Start", salesHead.OrderType.ToUpper() + "- Header Saved Mode : " + orderFlg);
                        if (os == null)
                        {
                            oString = new StringBuilder();
                        }
                        else
                        {
                            oString = os;
                        }
                        budgetString = salesHead.OrderDate + "," + salesNo + "," + salesHead.EmployeeID + "," + usrId;
                        oString.AppendLine(budgetString);
                        os = oString;
                        if (salesHead.CustRef != "")
                        {
                            if (editFlag == false)
                            {
                                string sSQL = "SELECT * FROM tblsop_customer_ref WHERE CompanyID='" + cmpId + "' AND Custid='" + salesHead.CustID + "' AND Custref='" + salesHead.CustRef + "'";
                                try
                                {
                                    MySqlCommand cmd2 = new MySqlCommand(sSQL, conn);
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count == 0)
                                    {
                                        sSQL = "INSERT INTO tblsop_customer_ref (CompanyID,Custid,custref ) VALUES('" + cmpId + "','" + busId + "','" + salesHead.CustRef + "')";
                                        if (ExecuteQuery(conn, sSQL) == 0)
                                        {

                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    logger.Warn(e.Message);
                                    logger.Warn(e.StackTrace);
                                }
                                finally
                                {

                                }
                            }
                            else
                            {
                                //update
                            }
                        }
                        // saving salesorder lines
                        if (isPrivate)
                        {
                            result.result = SavePrivaeOrderLines(conn, salesHead, salesNo, busId, editFlag);
                        }
                        else
                        {
                            result = SaveSalesorderlines(IsRollOutOrder, conn, salesHead, salesNo, busId, POINTSREQ, empResetMnths, access);
                        }
                        if (result.result == false)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
            }
            return result;
        }
        #endregion

        #region GetBusInfo

        public BusinessInfo GetbusInfo(string businessId)
        {
            BusinessInfo busInfo = new BusinessInfo();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            var country = _busBusiness.GetAll(x => x.BusinessID.Trim() == businessId.Trim()).First();
            conn.Open();
            try
            {
                busInfo.CurrencyExchangeRate = _countryCodes.Exists(x => x.CountryID == country.Country_Currency) ? _countryCodes.GetAll(x => x.CountryID == country.Country_Currency).First().Currency_Exchange_Rate.Value : 0;
                busInfo.Currency_Name = _countryCodes.Exists(x => x.CountryID == country.Country_Currency) ? _countryCodes.GetAll(x => x.CountryID == country.Country_Currency).First().Currency_Name : "";
                busInfo.Rep_Id = _busAccount.Exists(x => x.BusinessID == businessId) ? _busAccount.GetAll(x => x.BusinessID == businessId).First().RepID.Value : 0;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return busInfo;
        }
        #endregion

        #region OrderLog
        public void OrderLog(string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, long salesNo, string flag = "", string detail = "")
        {
            string sSqry = "INSERT INTO `onlineorder_history`(`Browser`,`OrderNo`,`Date`,`IPAddress`,`Flag`,`Detail`)  VALUES ('" + Browser + "', '" + salesNo + "', NOW(),'" + getLanIpAddress(HTTP_X_FORWARDED_FOR, REMOTE_ADDR) + "', '" + flag + "','" + detail + "')";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }

        }

        #endregion

        #region getLanIpAddress
        public string getLanIpAddress(string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR)
        {
            //HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string IP = HTTP_X_FORWARDED_FOR;
            if (IP != null)
            {
                if (IP != "")
                {
                    //IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    IP = REMOTE_ADDR;
                }
            }
            return IP;
        }
        #endregion

        #region DeleteLines
        public int DeleteLines(List<SalesOrderLineViewModel> salesLines, string ordertype, MySqlConnection conn, bool POINTSREQ, bool freestockchk = false, string busId = "")
        {
            int del = 0;
            if (salesLines.Any(x => x.IsDleted && x.Isedit))
            {
                foreach (var rest in salesLines.Where(x => x.IsDleted && x.Isedit))
                {

                    //if (_salesOrderLines.Exists(s => s.OrderNo == resultDelte.OrderNo && s.LineNo == rest.LineNo && s.StyleID.ToLower().Trim() == rest.StyleID.ToLower().Trim()))
                    //{
                    //    _salesOrderLines.Delete(s => s.OrderNo == resultDelte.OrderNo && s.LineNo == rest.LineNo && s.StyleID.ToLower().Trim() == rest.StyleID.ToLower().Trim());
                    //}
                    var sql = "";
                    var sqlIssueQty = "";
                    try
                    {
                        sql = sql + "DELETE FROM `tblsop_salesorder_detail` WHERE orderno=" + rest.OrderNo;
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        if (ordertype == "RT")
                        {
                            del = del + ExecuteQuery(conn, sql);

                            var stockCardQty = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSO;
                            var pointCardQty = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSOPoints;
                            var EmpId = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().EmployeeId;
                            if (stockCardQty > 0)
                            {
                                MySqlCommand cmdstock = new MySqlCommand("SELECT  soqty FROM `tblaccemp_stockcard` WHERE styleid='" + rest.StyleID + "' AND employeeid='" + EmpId + "'", conn);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmdstock);
                                DataTable dt1 = new DataTable();
                                da.Fill(dt1);
                                int UpdSoqty = 0;
                                if (dt1.Rows.Count > 0)
                                {
                                    UpdSoqty = dt1.AsEnumerable().ToList().Select(s => Convert.ToInt32(s["soqty"].ToString())).ToList().Sum();
                                }
                                //  var updStock = _stockCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID && s.Year == 0).First();

                                sql = "";
                                //commeneted by sasi(11-01-2021)
                                //if (rest.InvFlag == "so")
                                //{

                                UpdSoqty = UpdSoqty + Convert.ToInt32(stockCardQty);
                                sql = "UPDATE `tblaccemp_stockcard` SET `SOQty`=" + UpdSoqty + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                // sqlIssueQty = "UPDATE `tblaccemp_stockcard` SET `TotalIssues`=" + updStock.TotalIssues + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}commeneted by sasi(11-01-2021)
                                //else if (rest.InvFlag == "pick")
                                //{
                                //    updStock.PickQty = updStock.PickQty > 0 ? updStock.PickQty - Convert.ToInt32(stockCardQty) : updStock.PickQty + Convert.ToInt32(stockCardQty);
                                //    updStock.TotalIssues = updStock.TotalIssues > 0 ? updStock.TotalIssues - Convert.ToInt32(stockCardQty) : updStock.TotalIssues + Convert.ToInt32(stockCardQty);
                                //    sql = "UPDATE `tblaccemp_stockcard` SET `PickQty`=" + updStock.PickQty + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //    sqlIssueQty = "UPDATE `tblaccemp_stockcard` SET `TotalIssues`=" + updStock.TotalIssues + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}
                                //else if (rest.InvFlag == "inv")
                                //{
                                //    updStock.InvQty = updStock.InvQty > 0 ? updStock.InvQty - Convert.ToInt32(stockCardQty) : updStock.InvQty + Convert.ToInt32(stockCardQty);
                                //    updStock.TotalIssues = updStock.TotalIssues > 0 ? updStock.TotalIssues - Convert.ToInt32(stockCardQty) : updStock.TotalIssues + Convert.ToInt32(stockCardQty);
                                //    sql = "UPDATE `tblaccemp_stockcard` SET `InvQty`=" + updStock.InvQty + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //    sqlIssueQty = "UPDATE `tblaccemp_stockcard` SET `TotalIssues`=" + updStock.TotalIssues + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}

                                // MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                if (rest.HasReorder || Convert.ToBoolean(BusinessParam("RTN_ADJ_REQ", busId)))
                                {
                                    if (ExecuteQuery(conn, sql) == 0)
                                    {

                                    }
                                    //MySqlCommand cmd2 = new MySqlCommand(sqlIssueQty, conn);
                                    if (ExecuteQuery(conn, sqlIssueQty) == 0)
                                    {

                                    }
                                }
                                sql = "";
                                sqlIssueQty = "";
                            }
                            if (pointCardQty > 0)
                            {
                                MySqlCommand cmdpts = new MySqlCommand("SELECT  sopoints FROM `tblaccemp_pointscard` WHERE styleid='" + rest.StyleID + "' AND employeeid='" + EmpId + "'", conn);
                                MySqlDataAdapter da1 = new MySqlDataAdapter(cmdpts);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                int UpdSopts = 0;
                                if (dt1.Rows.Count > 0)
                                {
                                    UpdSopts = dt1.AsEnumerable().ToList().Select(s => Convert.ToInt32(s["sopoints"].ToString())).ToList().Sum();
                                }
                                //var updStock = _pointsCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID && s.Year == 0).First();

                                // updStock.SOPoints = updStock.SOPoints - Convert.ToInt32(pointCardQty);
                                //if (rest.InvFlag == "so")
                                //{

                                UpdSopts = Convert.ToInt32(pointCardQty) + UpdSopts;
                                sql = "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + UpdSopts + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}
                                //else if (rest.InvFlag == "pick")
                                //{
                                //updStock.PickPoints = updStock.PickPoints > 0 ? updStock.PickPoints - Convert.ToInt32(pointCardQty) : updStock.PickPoints + Convert.ToInt32(pointCardQty);
                                //sql = "UPDATE `tblaccemp_pointscard` SET `PickPoints`=" + updStock.PickPoints + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}
                                //else if (rest.InvFlag == "inv")
                                //{
                                //    updStock.InvPoints = updStock.InvPoints > 0 ? updStock.InvPoints - Convert.ToInt32(pointCardQty) : updStock.InvPoints + Convert.ToInt32(pointCardQty);
                                //    sql = "UPDATE `tblaccemp_pointscard` SET `InvPoints`=" + updStock.InvPoints + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                //}


                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                if (rest.HasReorder || Convert.ToBoolean(BusinessParam("RTN_ADJ_REQ", busId)))
                                {
                                    if (ExecuteQuery(conn, sql) == 0)
                                    {

                                    }
                                }
                                sql = "";
                            }
                        }
                        else
                        {
                            del = del + ExecuteQuery(conn, sql);

                            var stockCardQty = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSO;
                            var pointCardQty = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSOPoints;
                            var EmpId = salesLines.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().EmployeeId;
                            if (stockCardQty > 0)
                            {
                                MySqlCommand cmdstock = new MySqlCommand("SELECT  soqty FROM `tblaccemp_stockcard` WHERE styleid='" + rest.StyleID + "' AND employeeid='" + EmpId + "'", conn);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmdstock);
                                DataTable dt1 = new DataTable();
                                da.Fill(dt1);
                                int UpdSoqty = 0;
                                if (dt1.Rows.Count > 0)
                                {
                                    UpdSoqty = dt1.AsEnumerable().ToList().Select(s => Convert.ToInt32(s["soqty"].ToString())).ToList().Sum();
                                }
                                //var updStock = _stockCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID && s.Year == 0).First();
                                UpdSoqty = UpdSoqty > Convert.ToInt32(stockCardQty) ? UpdSoqty - Convert.ToInt32(stockCardQty) : Convert.ToInt32(stockCardQty) - UpdSoqty;

                                sql = "";
                                sql = "UPDATE `tblaccemp_stockcard` SET `SOQty`=" + UpdSoqty + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                if (ExecuteQuery(conn, sql) == 0)
                                {

                                }
                            }
                            if (freestockchk && rest.IsAlternateStyle == false && _tblAlternates.Exists(s => s.AltStyleId == rest.StyleID) == false)
                            {
                                MySqlCommand cmdstock = new MySqlCommand("SELECT sum( soqty) soqty FROM   `tblfsk_style_locations` WHERE styleid='" + rest.StyleID + "' AND colourid='" + rest.ColourID + "' AND sizeid='" + rest.SizeID + "'", conn);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmdstock);
                                DataTable dt1 = new DataTable();
                                da.Fill(dt1);
                                int UpdSoqty = 0;
                                if (dt1.Rows.Count > 0)
                                {
                                    UpdSoqty = dt1.AsEnumerable().ToList().Select(s => Convert.ToInt32(s["soqty"].ToString())).ToList().Sum();
                                }
                                UpdSoqty = UpdSoqty > Convert.ToInt32(stockCardQty) ? UpdSoqty - Convert.ToInt32(stockCardQty) : Convert.ToInt32(stockCardQty) - UpdSoqty;
                                sql = "";
                                sql = "UPDATE `tblfsk_style_locations` SET `SOQty`=" + UpdSoqty + " WHERE `StyleID`='" + rest.StyleID + "'   AND colourid='" + rest.ColourID + "' AND sizeid='" + rest.SizeID + "' AND locationid='ALL'";
                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                if (ExecuteQuery(conn, sql) == 0)
                                {

                                }
                            }
                            if (pointCardQty > 0 && POINTSREQ)
                            {
                                MySqlCommand cmdpts = new MySqlCommand("SELECT  sopoints FROM `tblaccemp_pointscard` WHERE styleid='" + rest.StyleID + "' AND employeeid='" + EmpId + "'", conn);
                                MySqlDataAdapter da1 = new MySqlDataAdapter(cmdpts);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                int UpdSopts = 0;
                                if (dt1.Rows.Count > 0)
                                {
                                    UpdSopts = dt1.AsEnumerable().ToList().Select(s => Convert.ToInt32(s["sopoints"].ToString())).ToList().Sum();
                                }
                                // var updStock = _pointsCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID && s.Year == 0).First();
                                UpdSopts = UpdSopts > Convert.ToInt32(pointCardQty) ? UpdSopts - Convert.ToInt32(pointCardQty) : Convert.ToInt32(pointCardQty) - UpdSopts;

                                sql = "";
                                sql = "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + UpdSopts + " WHERE `StyleID`='" + rest.StyleID + "' AND `EmployeeID`='" + EmpId + "'";
                                // MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                if (ExecuteQuery(conn, sql) == 0)
                                {

                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Warn(e.Message);
                        logger.Warn(e.StackTrace);
                    }



                }
            }


            return del;
        }
        #endregion

        #region DeleteLinesFrestock
        public int DeleteLinesFrestock(List<SalesOrderLineViewModel> salesLines, string ordertype, MySqlConnection conn, bool POINTSREQ, bool freestockchk = false)
        {
            int del = 0;
            string delFreeStkLinqry = "";
            string selLinQry = "";
            string ferStkQry = "";
            string stkCardQry = "";
            string empId = "";
            List<SalesOrderLineViewModel> newLst = new List<SalesOrderLineViewModel>();
            var orderno = salesLines.First().OrderNo != 0 ? salesLines.First().OrderNo : 0;
            if (salesLines.Count > 0 && _salesDetail.Exists(s => s.OrderNo == orderno))
            {
                empId = _salesHead.GetAll(s => s.OrderNo == orderno).First().PinNo;
                selLinQry = "Select lineno,styleid,colourid,sizeid,ordqty from tblsop_salesorder_Detail where orderno =" + salesLines.First().OrderNo;
                MySqlCommand cmd = new MySqlCommand(selLinQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    newLst = dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { OrdQty = Convert.ToInt32(s["ordqty"].ToString()), StyleID = s["styleid"].ToString(), ColourID = s["colourid"].ToString(), SizeID = s["sizeid"].ToString(), LineNo = Convert.ToInt32(s["lineno"].ToString()) }).ToList();
                }
                foreach (var line in newLst)
                {
                    ferStkQry = "update  tblfsk_style_locations SET `SOQty`=`SOQty`-" + line.OrdQty + " WHERE `StyleID`='" + line.StyleID + "'   AND colourid='" + line.ColourID + "' AND sizeid='" + line.SizeID + "' AND locationid='ALL'";
                    stkCardQry = "update  tblaccemp_stockcard SET `SOQty`=`SOQty`-" + line.OrdQty + " WHERE `StyleID`='" + line.StyleID + "'   AND colourid='" + line.ColourID + "' AND employeeid='" + empId + "'";
                    ExecuteQuery(conn, ferStkQry);
                    ExecuteQuery(conn, stkCardQry);
                }
                delFreeStkLinqry = "Delete from tblsop_salesorder_Detail where orderno =" + salesLines.First().OrderNo;
                del = del + ExecuteQuery(conn, delFreeStkLinqry);
                if (del > 0)
                {

                }
            }
            return del;
        }
        #endregion
        #region GetUsedPoints
        public int GetUsedPoints(string empId, MySqlConnection conn)
        {
            string usdQry = "";
            int usedPts = 0;
            usdQry = " SELECT SUM(IF(ISNULL(SOPOINTS),0,SOPOINTS)+IF(ISNULL(PICKPOINTS),0,PICKPOINTS)+IF(ISNULL(INVPOINTS),0,INVPOINTS)) USEDPOINTS FROM `tblaccemp_pointscard` WHERE EMPLOYEEID = '" + empId + "' GROUP BY EMPLOYEEID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(usdQry, conn);
                usedPts = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return usedPts;
        }
        #endregion
        #region GetUsedPoints
        public int GetUsedPointsMaternity(string busId, string empId, MySqlConnection conn)
        {
            string usdQry = "";
            int usedPts = 0;
            var matucodes = _stylePoints.Exists(s => s.BusinessID == busId && s.UcodeID.ToLower().Contains("maternit")) ? "'" + string.Join("','", _stylePoints.GetAll(s => s.BusinessID == busId && s.UcodeID.ToLower().Contains("maternit")).Select(s => s.StyleID).ToList()) + "'" : "";
            usdQry = matucodes != "" ? " SELECT SUM(IF(ISNULL(SOPOINTS),0,SOPOINTS)+IF(ISNULL(PICKPOINTS),0,PICKPOINTS)+IF(ISNULL(INVPOINTS),0,INVPOINTS)) USEDPOINTS FROM `tblaccemp_pointscard` WHERE EMPLOYEEID = '" + empId + "' and styleid in (" + matucodes + ") GROUP BY EMPLOYEEID" : " SELECT SUM(IF(ISNULL(SOPOINTS),0,SOPOINTS)+IF(ISNULL(PICKPOINTS),0,PICKPOINTS)+IF(ISNULL(INVPOINTS),0,INVPOINTS)) USEDPOINTS FROM `tblaccemp_pointscard` WHERE EMPLOYEEID = '" + empId + "' GROUP BY EMPLOYEEID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(usdQry, conn);
                usedPts = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return usedPts;
        }
        #endregion


        #region SaveSalesorderlines

        public SaveResultModel SaveSalesorderlines(bool IsRolloutOrder, MySqlConnection conn, SalesOrderHeaderViewModel saleHead, long saleno, string busId, string POINTSREQ, int empResetMnths, string access, bool freestockchk = false, bool isedit = false)
        {
            int usedPoints = 0;
            int ucodePoints = 0;
            SaveResultModel result = new SaveResultModel();
            string sSQL = "";
            string sSQLTotIsu = "";
            int sYear = 0;
            bool booStock = true;
            bool isPersonalOrder = false;
            long returnOrderNo = 0;
            long returnOrderLine = 0;
            int DEL = 0;
            if (Convert.ToBoolean(POINTSREQ))
            {
                string ucodePtsQry = "";

                try
                {
                    ucodePtsQry = "select totalpoints from tblaccemp_ucodepoints where ucodeid='" + saleHead.UCodeId + "' and businessid='" + saleHead.CustID + "'";
                    MySqlCommand ucodePtscmd = new MySqlCommand(ucodePtsQry, conn);
                    ucodePoints = ucodePtscmd.ExecuteScalar() != null ? Convert.ToInt32(ucodePtscmd.ExecuteScalar()) : 0;

                }
                catch
                {

                }
            }

            // sYear = IsRolloutOrder | Convert.ToBoolean(POINTSREQ) ? 99 : 0;
            sYear = Convert.ToBoolean(POINTSREQ) ? 0 : 0;

            if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId)) && saleHead.ReasonCode == 0)
            {
                booStock = false;
            }
            if (freestockchk)
            {
                DEL = DeleteLinesFrestock(saleHead.SalesOrderLine, saleHead.OrderType, conn, Convert.ToBoolean(POINTSREQ), freestockchk);

                if (freestockchk)
                {
                    long lineNoFre = isedit ? _salesDetail.GetAll(s => s.OrderNo == saleHead.OrderNo).Last().LineNo : 0;
                    var newResult = saleHead.SalesOrderLine.Where(s => s.IsDleted == false).GroupBy(s => new { s.StyleID, s.ColourID, s.SizeID, s.IsAlternateStyle }).
                              Select(sa => new SalesOrderLineViewModel
                              {
                                  IsAlternateStyle = sa.First().IsAlternateStyle,
                                  StyleID = sa.First().StyleID.Trim(),
                                  OrderNo = sa.First().OrderNo,
                                  ColourID = sa.First().ColourID.Trim(),
                                  SizeID = sa.First().SizeID.Trim(),
                                  OrdQty = sa.Sum(s => s.OrdQty),
                                  Description = sa.First().Description,
                                  Price = sa.First().Price,
                                  Cost1 = sa.First().Cost1,
                                  IssueUOM1 = sa.First().IssueUOM1,
                                  IssueQty1 = sa.Sum(s => s.IssueQty1),
                                  Currency_Exchange_Rate = sa.First().Currency_Exchange_Rate,
                                  StyleIDref = sa.First().StyleIDref,
                                  VatCode1 = sa.First().VatCode1,
                                  RepId = sa.First().RepId,
                                  KAMID = sa.First().KAMID,
                                  RepRate1 = sa.First().RepRate1,
                                  KAMRate1 = sa.First().KAMRate1,
                                  OriginalOrderNo = sa.First().OriginalOrderNo,
                                  AssemblyID = sa.First().AssemblyID,
                                  AsmLineNo = sa.First().AsmLineNo,
                                  ReturnOrderNo = sa.First().ReturnOrderNo,
                                  ReturnLineNo = sa.First().ReturnLineNo,
                                  SOPDetail5 = sa.First().SOPDetail5,
                                  SOPDetail4 = sa.First().SOPDetail4,
                                  DeliveryDate = sa.First().DeliveryDate,
                                  StockingUOM1 = sa.First().StockingUOM1,
                                  EmployeeId = sa.First().EmployeeId,
                                  SoqtyForempSO = sa.Sum(s => s.SoqtyForempSO),
                                  Isedit = false,
                              }).ToList();
                    for (int i = 0; i < newResult.Count; i++)
                    {
                        newResult[i].LineNo = i + 1;
                    }
                    saleHead.SalesOrderLine = newResult;
                }

            }
            else
            {
                DEL = DeleteLines(saleHead.SalesOrderLine, saleHead.OrderType, conn, Convert.ToBoolean(POINTSREQ), freestockchk, saleHead.CustID);
            }
            foreach (var line in saleHead.SalesOrderLine.Where(s => s.IsDleted == false))
            {
                if (line.OrdQty > 0)
                {
                    if (line.OriginalLineNo > 0 && saleHead.OrderType == "SO")
                    {
                        sSQL = "SELECT t2.OrderNo,t2.LineNo FROM tblsop_salesorder_detail t2 JOIN tblsop_salesorder_header t1 ON (t1.CompanyID=t2.CompanyID) AND (t1.OrderNo=t2.OrderNo)  WHERE t1.CompanyID='" + cmpId + "' AND t1.OrderType='RT'  AND t2.OriginalOrderNo=" + line.OriginalOrderNo + " AND t2.OriginalLineNo=" + line.OriginalLineNo + " ORDER BY t2.OrderNo DESC";
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand(sSQL, conn);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    returnOrderLine = Convert.ToInt32(dr["OrderNo"].ToString());
                                    returnOrderNo = Convert.ToInt32(dr["OrderNo"].ToString());
                                    line.ReturnLineNo = line.ReturnLineNo > 0 ? line.ReturnLineNo : returnOrderLine;

                                    line.ReturnOrderNo = line.ReturnOrderNo > 0 ? line.ReturnOrderNo : returnOrderNo;
                                    line.OriginalOrderNo = 0;
                                }
                            }
                            else
                            {
                                returnOrderLine = 0;
                                returnOrderNo = 0;
                                line.ReturnLineNo = line.ReturnLineNo > 0 ? line.ReturnLineNo : returnOrderLine;

                                line.ReturnOrderNo = line.ReturnOrderNo > 0 ? line.ReturnOrderNo : returnOrderNo;
                                line.OriginalOrderNo = 0;
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn(e.Message);
                            logger.Warn(e.StackTrace);
                        }
                    }
                    var orgLineno = line.OriginalLineNo == null | line.OriginalLineNo == 0 ? 0 : line.OriginalLineNo;
                    if (DEL > 0 | line.Isedit == false)
                    {
                        var delDate = DateTime.Parse(line.DeliveryDate).ToString("yyyy-MM-dd");
                        if (saleno == 0)
                        {
                            saleno = saleHead.OrderNo;
                        }
                        if (freestockchk && line.IsAlternateStyle == false && _tblAlternates.Exists(s => s.AltStyleId == line.StyleID) == false)
                        {

                            var freeStock = GetFreeStockConn(line.StyleID.Trim(), line.ColourID, line.SizeID, saleHead.WarehouseID, conn, saleHead.SalesOrderLine, isedit, false);
                            if (line.OrdQty > freeStock)
                            {
                                result.errorstring = "Freestock";
                                result.result = false;
                                return result;
                            }
                            else
                            {
                                sSQL = "INSERT INTO tblsop_salesorder_detail (CompanyID, Warehouseid, OrderNo, LineNo,   LineType , StyleID, ColourID, SizeID,  Description, Price, OrdQty, AllQty, InvQty, DespQty,  CommissionRate, Deliverydate, VatCode, RepId, KamId, KAMrate, REPRate, Currency_Exchange_Rate,styleIDref,FreeText,Cost, IssueUOM, IssueQty,StockingUOM, NomCode, OriginalOrderNo, OriginalLineNo, AssemblyID, AsmLineNo, ReasonCode, ReturnOrderNo, ReturnLineNo, SOPDETAIL5, SOPDETAIL4)  VALUES('" + cmpId + "','" + saleHead.WarehouseID + "'," + saleno + "," + line.LineNo + ",1,'" + line.StyleID.Trim() + "','" + line.ColourID.Trim() + "','" + line.SizeID.Trim() + "','" + line.Description.Trim() + "'," + line.Price + "," + line.OrdQty + "," + line.AllQty + "," + line.InvQty + "," + line.InvQty + ",0,'" + delDate + "'," + line.VatCode1 + "," + line.RepId + "," + line.KAMID + "," + line.KAMRate1 + "," + line.RepRate1 + "," + line.Currency_Exchange_Rate + ",'" + line.StyleIDref + "','" + line.FreeText1 + "'," + line.Cost1 + "," + line.IssueUOM1 + "," + line.IssueQty1 + "," + line.StockingUOM1 + ",'" + line.NomCode + "'," + line.OriginalOrderNo + "," + orgLineno + "," + line.AssemblyID + "," + line.AsmLineNo + "," + line.ReasonCodeLine + "," + line.ReturnOrderNo + "," + line.ReturnLineNo + ",'" + line.SOPDetail5 + "','" + line.SOPDetail4 + "')";
                            }

                        }
                        else
                        {
                            sSQL = "INSERT INTO tblsop_salesorder_detail (CompanyID, Warehouseid, OrderNo, LineNo,   LineType , StyleID, ColourID, SizeID,  Description, Price, OrdQty, AllQty, InvQty, DespQty,  CommissionRate, Deliverydate, VatCode, RepId, KamId, KAMrate, REPRate, Currency_Exchange_Rate,styleIDref,FreeText,Cost, IssueUOM, IssueQty,StockingUOM, NomCode, OriginalOrderNo, OriginalLineNo, AssemblyID, AsmLineNo, ReasonCode, ReturnOrderNo, ReturnLineNo, SOPDETAIL5, SOPDETAIL4)  VALUES('" + cmpId + "','" + saleHead.WarehouseID + "'," + saleno + "," + line.LineNo + ",1,'" + line.StyleID.Trim() + "','" + line.ColourID.Trim() + "','" + line.SizeID.Trim() + "','" + line.Description.Trim() + "'," + line.Price + "," + line.OrdQty + "," + line.AllQty + "," + line.InvQty + "," + line.InvQty + ",0,'" + delDate + "'," + line.VatCode1 + "," + line.RepId + "," + line.KAMID + "," + line.KAMRate1 + "," + line.RepRate1 + "," + line.Currency_Exchange_Rate + ",'" + line.StyleIDref + "','" + line.FreeText1 + "'," + line.Cost1 + "," + line.IssueUOM1 + "," + line.IssueQty1 + "," + line.StockingUOM1 + ",'" + line.NomCode + "'," + line.OriginalOrderNo + "," + orgLineno + "," + line.AssemblyID + "," + line.AsmLineNo + "," + line.ReasonCodeLine + "," + line.ReturnOrderNo + "," + line.ReturnLineNo + ",'" + line.SOPDetail5 + "','" + line.SOPDetail4 + "')";
                        }
                    }
                    else
                    {
                        if (freestockchk && line.IsAlternateStyle == false && _tblAlternates.Exists(s => s.AltStyleId == line.StyleID) == false)
                        {
                            var freeStock = GetFreeStockConn(line.StyleID.Trim(), line.ColourID, line.SizeID, saleHead.WarehouseID, conn, saleHead.SalesOrderLine, isedit, false);
                            if (line.OrdQty > freeStock)
                            {
                                result.errorstring = "Freestock";
                                result.result = false;
                                return result;
                            }
                            else
                            {
                                sSQL = "Update tblsop_salesorder_detail set Price=" + line.Price + ", OrdQty=" + line.OrdQty + ", AllQty=" + line.AllQty + ", InvQty=" + line.InvQty + ", DespQty=" + line.InvQty + ", VatCode=" + line.VatCode1 + ", RepId=" + cmpId + ",styleIDref='" + line.StyleIDref + "',FreeText='" + line.FreeText1 + "',Cost=" + line.Cost1 + ", IssueQty=" + line.IssueQty1 + ",NomCode=" + line.NomCode + ", AssemblyID=" + line.AssemblyID + ", AsmLineNo=" + line.AsmLineNo + ", ReasonCode=" + line.ReasonCodeLine + ", ReturnOrderNo=" + line.ReturnOrderNo + ", ReturnLineNo=" + line.ReturnLineNo + ", SOPDETAIL5='" + line.SOPDetail5 + "', SOPDETAIL4='" + line.SOPDetail4 + "' Where OrderNo=" + line.OrderNo + " and LineNo=" + line.LineNo + " and  StyleID='" + line.StyleID.Trim() + "' and  ColourID='" + line.ColourID.Trim() + "' and SizeID='" + line.SizeID.Trim() + "' and   Description='" + line.Description.Trim() + "'";
                            }
                        }
                        else
                        {
                            sSQL = "Update tblsop_salesorder_detail set Price=" + line.Price + ", OrdQty=" + line.OrdQty + ", AllQty=" + line.AllQty + ", InvQty=" + line.InvQty + ", DespQty=" + line.InvQty + ", VatCode=" + line.VatCode1 + ", RepId=" + cmpId + ",styleIDref='" + line.StyleIDref + "',FreeText='" + line.FreeText1 + "',Cost=" + line.Cost1 + ", IssueQty=" + line.IssueQty1 + ",NomCode=" + line.NomCode + ", AssemblyID=" + line.AssemblyID + ", AsmLineNo=" + line.AsmLineNo + ", ReasonCode=" + line.ReasonCodeLine + ", ReturnOrderNo=" + line.ReturnOrderNo + ", ReturnLineNo=" + line.ReturnLineNo + ", SOPDETAIL5='" + line.SOPDetail5 + "', SOPDETAIL4='" + line.SOPDetail4 + "' Where OrderNo=" + line.OrderNo + " and LineNo=" + line.LineNo + " and  StyleID='" + line.StyleID.Trim() + "' and  ColourID='" + line.ColourID.Trim() + "' and SizeID='" + line.SizeID.Trim() + "' and   Description='" + line.Description.Trim() + "'";
                        }
                    }
                    if (ExecuteQuery(conn, sSQL) == 0)
                    {
                        if (sSQL.ToLower().Contains("update"))
                        {
                            result.result = true;
                        }
                        else
                        {
                            result.result = false;
                            result.errorstring = "Fail";
                            return result;
                        };

                    }
                    else
                    {
                        result.result = true;
                    }
                    if (saleHead.OrderType != "RT")
                    {
                        if (isPersonalOrder)
                        {

                        }
                        if (Convert.ToBoolean(BusinessParam("EmployeeDetails", busId)))
                        {
                            if (line.EmployeeId != null && line.EmployeeId != "")
                            {
                                if (line.EmployeeId.Length > 0)
                                {
                                    if (booStock)
                                    {

                                        sSQL = "SELECT * FROM tblAccEmp_StockCard WHERE CompanyID='" + cmpId + "' AND BusinessID='" + busId + "' AND EmployeeID='" + line.EmployeeId + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                        MySqlCommand cmd1 = new MySqlCommand(sSQL, conn);
                                        MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                                        DataTable dt1 = new DataTable();
                                        da.Fill(dt1);

                                        if (dt1.Rows.Count == 0)
                                        {
                                            try
                                            {
                                                var ssssssssss = DateTime.Parse(saleHead.OrderDate);
                                            }
                                            catch (Exception e)
                                            {
                                                logger.Warn(e.Message);
                                                logger.Warn(e.StackTrace);

                                            }

                                            sSQL = "INSERT INTO tblaccemp_stockcard (CompanyID,BusinessID,EmployeeID,StyleID,ColourID,SOQty,StartIssuedate,LastIssueDate,FirstIssueDate,Year)  VALUES('" + cmpId + "','" + saleHead.CustID + "','" + line.EmployeeId + "','" + line.StyleID.Trim() + "','" + line.ColourID.Trim() + "'," + line.OrdQty + ",'" + saleHead.OrderDate + "','" + saleHead.OrderDate + "','" + saleHead.OrderDate + "'," + sYear + ")";
                                        }
                                        else
                                        {
                                            if (empResetMnths > 0)
                                            {
                                                var stockCard = dt1.AsEnumerable().Select(s => new tblaccemp_stockcard
                                                {
                                                    FirstIssueDate = DateTime.Parse(s.ItemArray[10].ToString())
                                                }).First();
                                                var date1 = DateTime.Now;
                                                var date2 = stockCard.FirstIssueDate.Value;
                                                int months = (date1.Year - date2.Year) * 12 + date1.Month - date2.Month;
                                                if (months >= empResetMnths)
                                                {
                                                    ResetStockcard(stockCard, conn);
                                                }

                                            }
                                            var empSoQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s.ItemArray[6].ToString())).ToList();


                                            long sum = 0; long totPointsSty = 0; int soqty = 0;
                                            if (line.Isedit)
                                            {
                                                totPointsSty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.LineNo == line.LineNo && x.IsDleted == false).Sum(x => x.OrdQty);
                                                soqty = Convert.ToInt32(line.SoqtyForempSO) > Convert.ToInt32(empSoQty.Sum(s => s)) ? Convert.ToInt32(line.SoqtyForempSO) - Convert.ToInt32(empSoQty.Sum(s => s)) : Convert.ToInt32(empSoQty.Sum(s => s)) - Convert.ToInt32(line.SoqtyForempSO);
                                                sum = soqty + totPointsSty;
                                                sSQL = "UPDATE tblaccemp_stockcard SET SOQty=" + sum + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;

                                            }
                                            else
                                            {

                                                long totqty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.IsDleted == false && x.LineNo == line.LineNo).Sum(x => x.OrdQty);
                                                int sOqty = Convert.ToInt32(dt1.Rows[0]["SOQty"].ToString());
                                                if (sOqty != totqty)
                                                {

                                                    sum = Convert.ToInt32(dt1.Rows[0]["SOQty"].ToString()) + (line.OrdQty);
                                                    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=" + sum + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;

                                                }
                                                else
                                                {
                                                    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=SOQty+" + sOqty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                                }
                                            }

                                        }
                                        if (freestockchk && line.IsAlternateStyle == false && _tblAlternates.Exists(s => s.AltStyleId == line.StyleID) == false)
                                        {
                                            var freeStock = GetFreeStockConn(line.StyleID.Trim(), line.ColourID, line.SizeID, saleHead.WarehouseID, conn, saleHead.SalesOrderLine, isedit, false);
                                            if (line.OrdQty > freeStock)
                                            {
                                                result.errorstring = "Freestock";
                                                result.result = false;
                                                return result;
                                            }
                                            else
                                            {
                                                if (ExecuteQuery(conn, sSQL) > 0)
                                                {
                                                    result.result = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (ExecuteQuery(conn, sSQL) > 0)
                                            {
                                                result.result = true;
                                            }
                                        }
                                        if (Convert.ToBoolean(POINTSREQ))
                                        {
                                            usedPoints = IsMatUcodeId(saleHead.UCodeId, saleHead.CustID) ? line.Isedit ? GetUsedPointsMaternity(saleHead.CustID, line.EmployeeId, conn) - line.TotalPoints : GetUsedPointsMaternity(saleHead.CustID, line.EmployeeId, conn) : line.Isedit ? GetUsedPoints(line.EmployeeId, conn) - line.TotalPoints : GetUsedPoints(line.EmployeeId, conn);
                                            if ((usedPoints + line.TotalPoints) <= ucodePoints || access.ToLower() != "user" || line.Isedit)
                                            {
                                                if (_pointsByUcode.Exists(s => s.UcodeID.ToLower().Trim() == saleHead.UCodeId.ToLower().Trim()))
                                                {
                                                    string existQry = "";
                                                    existQry = existQry + "SELECT * FROM `tblaccemp_pointscard` WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                    MySqlCommand cmd21 = new MySqlCommand(existQry, conn);
                                                    MySqlDataAdapter da21 = new MySqlDataAdapter(cmd21);
                                                    DataTable dt21 = new DataTable();
                                                    da21.Fill(dt21);
                                                    if (dt21.Rows.Count > 0)
                                                    {
                                                        string sSql1 = "";
                                                        int sum = 0;
                                                        if (empResetMnths > 0)
                                                        {
                                                            var pointsCard = dt21.AsEnumerable().Select(s => new tblaccemp_pointscard { FirstIssueDate = DateTime.Parse(s.ItemArray[9].ToString()) }).First();
                                                            var date1 = DateTime.Now;
                                                            var date2 = pointsCard.FirstIssueDate.Value;
                                                            int months = (date1.Year - date2.Year) * 12 + date1.Month - date2.Month;
                                                            if (DateTime.Now >= pointsCard.FirstIssueDate.Value.AddMonths(empResetMnths))
                                                            {
                                                                ResetPointscard(pointsCard);
                                                            }
                                                        }
                                                        if (line.Isedit)
                                                        {
                                                            var empSoQty = dt21.AsEnumerable().Select(s => Convert.ToInt32(s.ItemArray[6].ToString())).ToList();
                                                            int totPointsSty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.LineNo == line.LineNo && x.IsDleted == false).Sum(x => x.TotalPoints);
                                                            var sssoqty = Convert.ToInt32(line.SoqtyForempSOPoints) > Convert.ToInt32(empSoQty.Sum(s => s)) ? Convert.ToInt32(line.SoqtyForempSOPoints) - Convert.ToInt32(empSoQty.Sum(s => s)) : Convert.ToInt32(empSoQty.Sum(s => s)) - Convert.ToInt32(line.SoqtyForempSOPoints);
                                                            sum = sssoqty + totPointsSty;


                                                            //int canedit = Convert.ToInt32(dt.Rows[0]["SOPoints"].ToString()) - totPointsSty;
                                                            //if (canedit < 0)
                                                            //{
                                                            // sum = Convert.ToInt32(dt.Rows[0]["SOPoints"].ToString()) + (-(canedit));
                                                            sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + sum + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                            //}
                                                            //else
                                                            //{
                                                            //    sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + Convert.ToInt32(dt.Rows[0]["SOPoints"].ToString()) + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID + "' AND `Year`=" + sYear;
                                                            //}
                                                        }
                                                        else
                                                        {
                                                            int totPointsSty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.IsDleted == false && x.LineNo == line.LineNo).Sum(x => x.TotalPoints);
                                                            int soPts = Convert.ToInt32(dt21.Rows[0]["SOPoints"].ToString());
                                                            if (soPts != totPointsSty)
                                                            {
                                                                sum = Convert.ToInt32(dt21.Rows[0]["SOPoints"].ToString()) + (line.TotalPoints);
                                                                sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + sum + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                            }
                                                            else
                                                            {
                                                                sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=SOPoints+" + soPts + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                            }
                                                        }

                                                        if (ExecuteQuery(conn, sSql1) > 0)
                                                        {
                                                            result.result = true;
                                                            //AddtologStockCard(SQL)
                                                        }
                                                        else
                                                        {
                                                            result.result = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string sSql1 = "";
                                                        sSql1 = sSql1 + "INSERT INTO `tblaccemp_pointscard`(`CompanyID`,`BusinessID`,`EmployeeID`,`StyleID`,`ColourID`,`Year`,`SOPoints`,`FirstIssueDate`,`StartIssueDate`,`LastIssueDate`) VALUES ('" + cmpId + "','" + busId + "','" + saleHead.EmployeeID + "','" + line.StyleID.Trim() + "','" + line.ColourID.Trim() + "',0," + line.Points * line.OrdQty + ",'" + saleHead.OrderDate + "','" + saleHead.OrderDate + "','" + saleHead.OrderDate + "')";
                                                        if (ExecuteQuery(conn, sSql1) > 0)
                                                        {
                                                            result.result = true;
                                                            //AddtologStockCard(SQL)
                                                        }
                                                        else
                                                        {
                                                            result.result = false;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                result.result = false;
                                                result.errorstring = "PointsExceeded";
                                                return result;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (line.HasReorder || (CheckEmergency(saleHead.CustID, saleHead.UCodeId) == true && IsMatUcodeId(saleHead.UCodeId, saleHead.CustID) == false) || Convert.ToBoolean(BusinessParam("RTN_ADJ_REQ", saleHead.CustID)))
                        {
                            if (booStock)
                            {

                                sSQL = "SELECT `CompanyID`,`BusinessID`,`EmployeeID`,`StyleID`,`ColourID`,`Year`,IF(ISNULL(`SOQty`),0,`SOQty`) SOQty, IF(ISNULL(`PickQty`), 0,`PickQty`) PickQty,IF(ISNULL( `InvQty`), 0,`InvQty`) `InvQty`,`TotalIssues`,`FirstIssueDate`, `StartIssueDate`,`LastIssueDate` FROM tblAccEmp_StockCard WHERE CompanyID='" + cmpId + "' AND BusinessID='" + busId + "' AND EmployeeID='" + line.EmployeeId + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                MySqlCommand cmd1 = new MySqlCommand(sSQL, conn);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da.Fill(dt1);
                                if (empResetMnths > 0 && dt1.Rows.Count > 0)
                                {
                                    var stockCard = dt1.AsEnumerable().Select(s => new tblaccemp_stockcard
                                    {
                                        FirstIssueDate = DateTime.Parse(s.ItemArray[10].ToString())
                                    }).First();
                                    var date1 = DateTime.Now;
                                    var date2 = stockCard.FirstIssueDate.Value;
                                    int months = (date1.Year - date2.Year) * 12 + date1.Month - date2.Month;
                                    if (months >= empResetMnths)
                                    {
                                        ResetStockcard(stockCard, conn);
                                    }

                                }



                                long sum = 0;
                                long totPointsSty = 0;
                                int soqty = 0;
                                var empSoQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s.ItemArray[6].ToString())).ToList();
                                if (line.Isedit)
                                {
                                    totPointsSty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.LineNo == line.LineNo && x.IsDleted == false).Sum(x => x.OrdQty);
                                    //Added by sasi
                                    //Orderqty-SoqtyForempSO=somevalue(changes to have either negative or positive value)
                                    //sum= cardqty+somevalue
                                    //if (line.InvFlag == "so")
                                    //{
                                    //so=so-(ret-orgqty)
                                    var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["SOQty"].ToString())).ToList();
                                    var cardQty = empInvQty.Sum();
                                    var newSoqty = line.SoqtyForempSO > line.OrdQty ? cardQty + (line.SoqtyForempSO - line.OrdQty) : cardQty - (line.OrdQty - line.SoqtyForempSO);

                                    //var rtnQty = line.OrdQty;
                                    //var existingRtnQty = line.SoqtyForempSO;
                                    //var newValueRtn = existingRtnQty - rtnQty;
                                    //var cardQty = empInvQty.Sum();
                                    //var newCardQty = cardQty + newValueRtn;
                                    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=" + newSoqty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newSoqty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}commeneted by sasi(11-01-2021)
                                    //else if (line.InvFlag == "pick")
                                    //{
                                    //    var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["PickQty"].ToString())).ToList();
                                    //    var cardQty = empInvQty.Sum();
                                    //    var newpckQty = cardQty - (line.OrdQty - line.SoqtyForempSO);
                                    //    //var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["InvQty"].ToString())).ToList();
                                    //    //var rtnQty = line.OrdQty;
                                    //    //var existingRtnQty = line.SoqtyForempSO;
                                    //    //var newValueRtn = existingRtnQty - rtnQty;
                                    //    //var cardQty = empInvQty.Sum();
                                    //    //var newCardQty = cardQty + newValueRtn;

                                    //    sSQL = "UPDATE tblaccemp_stockcard SET PickQty=" + newpckQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //    sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newpckQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}
                                    //else if (line.InvFlag == "inv")
                                    //{
                                    //    var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["InvQty"].ToString())).ToList();
                                    //    var cardQty = empInvQty.Sum();
                                    //    var newinvQty = cardQty - (line.OrdQty - line.SoqtyForempSO);
                                    //    //var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["InvQty"].ToString())).ToList();
                                    //    //var rtnQty = line.OrdQty;
                                    //    //var existingRtnQty = line.SoqtyForempSO;
                                    //    //var newValueRtn =  rtnQty-existingRtnQty;
                                    //    //var cardQty = empInvQty.Sum();
                                    //    //var newCardQty = cardQty - newValueRtn;

                                    //    sSQL = "UPDATE tblaccemp_stockcard SET InvQty=" + newinvQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //    sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newinvQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}
                                }
                                else
                                {
                                    //if (line.InvFlag == "so")
                                    //{

                                    var rtnQty = line.OrdQty;
                                    var cardQty = empSoQty.Sum();
                                    var newCardQty = cardQty - line.OrdQty;

                                    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}
                                    //else if (line.InvFlag == "pick")
                                    //{
                                    //    var empPkQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["PickQty"].ToString())).ToList();
                                    //    var rtnQty = line.OrdQty;
                                    //    var cardQty = empPkQty.Sum();
                                    //    var newCardQty = cardQty - line.OrdQty;

                                    //    sSQL = "UPDATE tblaccemp_stockcard SET PickQty=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //    sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}
                                    //else if (line.InvFlag == "inv")
                                    //{
                                    //    var empInvQty = dt1.AsEnumerable().Select(s => Convert.ToInt32(s["InvQty"].ToString())).ToList();
                                    //    var rtnQty = line.OrdQty;
                                    //    var cardQty = empInvQty.Sum();
                                    //    var newCardQty = cardQty - line.OrdQty;

                                    //    sSQL = "UPDATE tblaccemp_stockcard SET InvQty=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //    sSQLTotIsu = "UPDATE tblaccemp_stockcard SET totalissues=" + newCardQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}

                                    //long totqty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.IsDleted == false).Sum(x => x.OrdQty);
                                    //int sOqty = Convert.ToInt32(dt1.Rows[0]["SOQty"].ToString());
                                    //if (sOqty != totqty)
                                    //{

                                    //    sum = Convert.ToInt32(dt1.Rows[0]["SOQty"].ToString()) + (line.OrdQty);
                                    //    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=" + sum + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;

                                    //}
                                    //else
                                    //{
                                    //    sSQL = "UPDATE tblaccemp_stockcard SET SOQty=SOQty+" + sOqty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID.Trim() + "' AND ColourID='" + line.ColourID.Trim() + "' AND Year=" + sYear;
                                    //}
                                }
                                List<string> qryLst = new List<string>();
                                qryLst.Add(sSQL);
                                // qryLst.Add(sSQLTotIsu);
                                foreach (var sql in qryLst)
                                {
                                    if (sql != "")
                                    {
                                        if (ExecuteQuery(conn, sql) > 0)
                                        {
                                            result.result = true;
                                        }
                                    }
                                }
                                if (Convert.ToBoolean(POINTSREQ))
                                {
                                    if (_pointsByUcode.Exists(s => s.UcodeID.ToLower().Trim() == saleHead.UCodeId.ToLower().Trim()))
                                    {
                                        string existQry = "";
                                        existQry = existQry + "SELECT `CompanyID`,`BusinessID`,`EmployeeID`,`StyleID`,`ColourID`,`Year`,IF(ISNULL(`SOpoints`),0,`SOpoints`) SOpoints, IF(ISNULL(`Pickpoints`), 0,`Pickpoints`) Pickpoints,IF(ISNULL( `Invpoints`), 0,`Invpoints`) `Invpoints`,`FirstIssueDate`, `StartIssueDate`,`LastIssueDate` FROM `tblaccemp_pointscard` WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                        MySqlCommand cmd21 = new MySqlCommand(existQry, conn);
                                        MySqlDataAdapter da21 = new MySqlDataAdapter(cmd21);
                                        DataTable dt21 = new DataTable();
                                        da21.Fill(dt21);
                                        if (dt21.Rows.Count > 0)
                                        {
                                            string sSql1 = "";
                                            int sumRtn = 0;
                                            if (empResetMnths > 0)
                                            {
                                                var pointsCard = dt21.AsEnumerable().Select(s => new tblaccemp_pointscard { FirstIssueDate = DateTime.Parse(s.ItemArray[9].ToString()) }).First();
                                                var date1 = DateTime.Now;
                                                var date2 = pointsCard.FirstIssueDate.Value;
                                                int months = (date1.Year - date2.Year) * 12 + date1.Month - date2.Month;
                                                if (DateTime.Now >= pointsCard.FirstIssueDate.Value.AddMonths(empResetMnths))
                                                {
                                                    ResetPointscard(pointsCard);
                                                }
                                            }
                                            if (line.Isedit)
                                            {
                                                var empSoQtyRtn = dt21.AsEnumerable().Select(s => Convert.ToInt32(s.ItemArray[6].ToString())).ToList();
                                                int totPointsStyRtn = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.LineNo == line.LineNo && x.IsDleted == false).Sum(x => x.TotalPoints);
                                                var cardQty = empSoQtyRtn.Sum();
                                                var newSoqty = line.SoqtyForempSOPoints > totPointsStyRtn ? cardQty + (line.SoqtyForempSOPoints - totPointsStyRtn) : cardQty - (totPointsStyRtn - line.SoqtyForempSOPoints);
                                                //soqty = Convert.ToInt32(line.SoqtyForempSOPoints) - Convert.ToInt32(totPointsStyRtn);
                                                //sum = Convert.ToInt32(empSoQtyRtn.Sum(s => s)) + soqty;
                                                sum = newSoqty;
                                                sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + sum + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                            }
                                            else
                                            {
                                                //commeneted by sasi(11 - 01 - 2021)
                                                //if (line.InvFlag == "so")
                                                //{
                                                int rtnPts = line.TotalPoints;
                                                int cardPts = Convert.ToInt32(dt21.Rows[0]["SOPoints"].ToString());
                                                int newCardPts = cardPts - rtnPts;
                                                sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + newCardPts + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                //}
                                                //else if (line.InvFlag == "pick")
                                                //{
                                                //    int rtnPts = line.TotalPoints;
                                                //    int cardPts = Convert.ToInt32(dt21.Rows[0]["PickPoints"].ToString());
                                                //    int newCardPts = cardPts - rtnPts;
                                                //    sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `PickPoints`=" + newCardPts + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                //}
                                                //else if (line.InvFlag == "inv")
                                                //{
                                                //    int rtnPts = line.TotalPoints;
                                                //    int cardPts = Convert.ToInt32(dt21.Rows[0]["InvPoints"].ToString());
                                                //    int newCardPts = cardPts - rtnPts;
                                                //    sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `InvPoints`=" + newCardPts + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                //}
                                                //int totPointsStyRtn = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.IsDleted == false).Sum(x => x.TotalPoints);
                                                //int soPts = Convert.ToInt32(dt21.Rows[0]["SOPoints"].ToString());
                                                //if (soPts != totPointsStyRtn)
                                                //{
                                                //    sumRtn = Convert.ToInt32(dt21.Rows[0]["SOPoints"].ToString()) + (line.TotalPoints);
                                                //    sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=" + sumRtn + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                //}
                                                //else
                                                //{
                                                //    sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`=SOPoints+" + soPts + " WHERE `CompanyID`='" + cmpId + "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID.Trim() + "' AND `ColourID`='" + line.ColourID.Trim() + "' AND `Year`=" + sYear;
                                                //}
                                            }

                                            if (ExecuteQuery(conn, sSql1) > 0)
                                            {
                                                result.result = true;
                                                //AddtologStockCard(SQL)
                                            }
                                            else
                                            {
                                                result.result = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (freestockchk && line.IsAlternateStyle == false && _tblAlternates.Exists(s => s.AltStyleId == line.StyleID) == false)
                    {
                        int soqty = 0;
                        string updateQry = "";
                        string stockQty = "select sum(soqty) SOQty  from tblfsk_style_locations    WHERE styleid = '" + line.StyleID.Trim() + "' AND colourid = '" + line.ColourID + "' AND sizeid = '" + line.SizeID + "'";
                        MySqlCommand cmdST = new MySqlCommand(stockQty, conn);
                        DataTable dtST = new DataTable();
                        MySqlDataAdapter daST = new MySqlDataAdapter(cmdST);
                        daST.Fill(dtST);
                        int sum = 0;
                        if (dtST.Rows.Count > 0)
                        {
                            soqty = Convert.ToInt32(dtST.Rows[0]["SOQty"].ToString());
                        }
                        var freeStock = GetFreeStockConn(line.StyleID.Trim(), line.ColourID, line.SizeID, saleHead.WarehouseID, conn, saleHead.SalesOrderLine, isedit, false);
                        if (line.OrdQty > freeStock)
                        {
                            result.result = false;
                            result.errorstring = "Freestock";
                            return result;
                        }
                        else
                        {
                            if (line.Isedit)
                            {

                                var newValue = line.OrdQty - line.SoqtyForempSO;
                                updateQry = "UPDATE `tblfsk_style_locations` SET soqty=soqty+(" + newValue + ")  WHERE styleid = '" + line.StyleID.Trim() + "' AND colourid = '" + line.ColourID + "' AND sizeid = '" + line.SizeID + "' AND locationid = 'All'";
                            }
                            else
                            {
                                long totqty = saleHead.SalesOrderLine.Where(x => x.StyleID == line.StyleID.Trim() && x.IsDleted == false).Sum(x => x.OrdQty);
                                if (soqty != totqty)
                                {
                                    sum = soqty + Convert.ToInt32(line.OrdQty);
                                    updateQry = "UPDATE `tblfsk_style_locations` SET soqty=  " + sum + "   WHERE styleid = '" + line.StyleID.Trim() + "' AND colourid = '" + line.ColourID + "' AND sizeid = '" + line.SizeID + "' AND locationid = 'All'";
                                }
                                else
                                {
                                    updateQry = "UPDATE `tblfsk_style_locations` SET soqty=soqty+(" + line.OrdQty + ")  WHERE styleid = '" + line.StyleID.Trim() + "' AND colourid = '" + line.ColourID + "' AND sizeid = '" + line.SizeID + "' AND locationid = 'All'";
                                }

                            }
                            if (ExecuteQuery(conn, updateQry) > 0)
                            {
                                result.result = true;
                            }
                        }
                    }
                }
            }
            if (saleHead.Reorderheader)
            {
                if (saleHead.SalesOrderLine.Count() == saleHead.SalesOrderLine.Where(s => s.IsDleted).Count())
                {
                    string delHeadSql = "delete from tblsop_salesorder_header where orderno = " + saleHead.OrderNo;
                    string DelReason = " INSERT INTO `tblonline_rejectorder_reasons`(Orderno,BusinessId,Employeeid,RejectedBy,RejectedDate,RejectedReason) VALUES(" + saleHead.OrderNo + ", '" + saleHead.CustID + "','" + saleHead.EmployeeID + "','System','" + saleHead.OrderDate + "','The reorder lines are deleted, So system removed Reorder header as well')";
                    ExecuteQuery(conn, delHeadSql);
                    ExecuteQuery(conn, DelReason);
                    result.result = true;
                    return result;
                }
            }
            return result;

        }

        #endregion

        #region ResetStockcard

        public void ResetStockcard(tblaccemp_stockcard stockCard, MySqlConnection conn)
        {
            string updQry = "Update tblaccemp_stockcard set year=1 where  `CompanyID`='" + stockCard.CompanyID + "' AND `BusinessID`='" + stockCard.BusinessID + "' AND `EmployeeID`='" + stockCard.EmployeeID + "' AND `StyleID`='" + stockCard.StyleID + "' AND `ColourID`='" + stockCard.ColourID + "'";

            try
            {

                MySqlCommand cmd = new MySqlCommand(updQry, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string insert = "";
                    insert = "INSERT INTO tblaccemp_stockcard (CompanyID,BusinessID,EmployeeID,StyleID,ColourID,SOQty,StartIssuedate,LastIssueDate,FirstIssueDate,Year)  VALUES('" + stockCard.CompanyID + "','" + stockCard.BusinessID + "','" + stockCard.EmployeeID + "','" + stockCard.StyleID + "','" + stockCard.ColourID + "'," + 0 + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + 0 + ")";
                    MySqlCommand cmd1 = new MySqlCommand(insert, conn);
                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);

            }
            finally
            {

            }

        }

        #endregion
        #region ResetStockcard

        public void ResetPointscard(tblaccemp_pointscard ptsCard)
        {
            string updQry = "Update tblaccemp_pointscard set year=1 where  `CompanyID`='" + ptsCard.CompanyID + "' AND `BusinessID`='" + ptsCard.BusinessID + "' AND `EmployeeID`='" + ptsCard.EmployeeID + "' AND `StyleID`='" + ptsCard.StyleID + "' AND `ColourID`='" + ptsCard.ColourID + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {

                MySqlCommand cmd = new MySqlCommand(updQry, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string insert = "INSERT INTO `tblaccemp_pointscard`(`CompanyID`,`BusinessID`,`EmployeeID`,`StyleID`,`ColourID`,`Year`,`SOPoints`,`FirstIssueDate`,`StartIssueDate`,`LastIssueDate`) VALUES ('" + ptsCard.CompanyID + "','" + ptsCard.BusinessID + "','" + ptsCard.EmployeeID + "','" + ptsCard.StyleID + "','" + ptsCard.ColourID + "',0," + 0 + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    MySqlCommand cmd1 = new MySqlCommand(insert, conn);
                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {

            }
        }

        #endregion


        #region override entitlement

        public bool overrideEntitlement(string OverrideEnt)
        {
            if (OverrideEnt.ToString().ToUpper().Trim() == "SHOW")
            {
                return true;
            }
            else
            { return false; }
        }

        #endregion


        #region IsCarriageStyle

        public bool IsCarriageStyle(string styleId)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string sqlC = "SELECT DISTINCT tblfsk_style.StyleID, tblfsk_style.Description   FROM tblfsk_style INNER JOIN tblonlinesop_carriage ON (tblfsk_style.StyleID = tblonlinesop_carriage.StyleID) AND (tblfsk_style.CompanyID = tblonlinesop_carriage.CompanyID)  WHERE tblfsk_style.StyleID='" + styleId + "' ORDER BY tblfsk_style.StyleID";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlC, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        #endregion

        #region FindOpenManPackOrders

        public long FindOpenManPackOrders(string strCustID, string mDelDesc, string delAddr1, string mDelPost)
        {
            string sqlTmp = "";
            int intOpenManpack = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string sql = "SELECT DISTINCT m.ManpackNo as MyManpack FROM tblsop_manpackorders m  JOIN tblsop_salesorder_header h ON (m.CompanyID=h.CompanyID) AND (m.OrderNo=h.OrderNo)  WHERE m.CustID='" + strCustID + "' AND m.OnlineConfirm=0 ";
            if (!Convert.ToBoolean(BusinessParam("OpenStack_Postcode", strCustID)))
            {
                sqlTmp += "AND h.DelDesc='" + mDelDesc + "' AND h.DelAddress1='" + delAddr1 + "' ";
            }
            sqlTmp += " AND h.DelPostCode='" + mDelPost + "' ORDER BY m.ManpackNo DESC ";
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    intOpenManpack = reader.GetString("MyManpack") != null && reader.GetString("MyManpack") != "" ? Convert.ToInt32(reader.GetString("MyManpack")) : 0;
                }
                else
                {
                    intOpenManpack = 0;
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return intOpenManpack;
        }
        #endregion

        #region PointsEntilementCheck

        public bool PointsEntilementCheck()
        {
            bool result = false;
            return result;
        }
        #endregion


        #region  EmpEntilementCheck

        public bool EmpEntilementCheck(string RolloutName, string OverrideEnt, string FITALLOC, string DIMALLOC, SalesOrderHeaderViewModel salesHead, string busId = "", int annualIssue = 0, bool isManPack = false, bool isPersonalOrder = false)
        {
            bool result = false;
            string mAllocText = "";
            bool booDimAlloc = false;
            double AnnualIssue;
            double mAnnual;
            double mCurrStock = 0;
            bool boocheck = false;
            if (isPersonalOrder)
            {
                result = true;
            }
            else if (overrideEntitlement(OverrideEnt))
            {
                result = true;
            }
            string FITALLOCvalue = FITALLOC;
            string DIMALLOCvalue = DIMALLOC;
            foreach (var line in salesHead.SalesOrderLine.Where(s => s.IsDleted == false))
            {
                if (!IsCarriageStyle(line.StyleID.Trim()))
                {
                    if (line.OriginalLineNo == 0 || line.OriginalLineNo == null)
                    {
                        if (Convert.ToBoolean(BusinessParam("DIMALLOC_LAYOUT", busId)))
                        {
                            string mysql = "SELECT DISTINCT if(isnull(FreeText),'',FreeText) as FreeText  FROM tblfsk_style_freetext WHERE StyleID='" + line.StyleID.Trim() + "' AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')";
                            MySqlConnection conn = new MySqlConnection(ConnectionString);
                            try
                            {
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand(mysql, conn);
                                var dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    mAllocText = dr.GetString("FreeText");
                                }
                                dr.Close();
                                booDimAlloc = mAllocText == "" ? false : true;
                                mAnnual = EmpAnnualIssue(line.StyleID.Trim(), FITALLOC, DIMALLOC, line.ColourID, salesHead.UCodeId, booDimAlloc);
                                AnnualIssue = mAnnual;
                                if (AnnualIssue > 0)
                                {
                                    mCurrStock = EmpStock(line.StyleID.Trim(), FITALLOC, DIMALLOC, RolloutName, busId, line.ColourID, cmpId, busId, salesHead.EmployeeID, booDimAlloc);
                                    if (true == false)
                                    {

                                    }
                                    if ((mCurrStock + line.OrdQty) > mAnnual)
                                    {
                                        boocheck = false;
                                    }
                                    else
                                    {
                                        boocheck = true;
                                    }
                                }
                                else
                                {
                                    boocheck = false;
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Warn(e.Message);
                                logger.Warn(e.StackTrace);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }

                    }

                }

            }
            //if(Convert.ToBoolean(BusinessParam("REQ_REASONPAGE",busId)) && Convert.ToInt32(str)==0)
            //{
            //    boocheck = true;
            //}
            return boocheck;
        }
        public double EmpAnnualIssue(string styleId, string FITALLOC, string DIMALLOC, string colourId, string Ucode, bool booDimAlloc = false)
        {
            double EmpAnnualIssue = 0;
            string FITALLOCvalue = FITALLOC;
            string DIMALLOCvalue = DIMALLOC;
            string sql = "";
            int reasoncode = 0;
            string mAllocText = "";
            string strReasonCode = "";
            string mPointDate = DateTime.Now.ToString("yyyy-MM-dd");
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                if (booDimAlloc == false)
                {
                    sql = "select Annualissue from tblaccemp_ucodes where companyId='" + cmpId + "' and UcodeId='" + Ucode + "' and StyleId='" + styleId + "' And ColourId='" + colourId + "'";
                }
                else
                {
                    sql = "SELECT DISTINCT FreeText   FROM tblfsk_style_freetext WHERE StyleID='" + styleId + "' AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        mAllocText = dr.GetString("FreeText");
                    }
                    dr.Close();
                    if (mAllocText != "")
                    {
                        sql = "SELECT DISTINCT PeriodQty as AnnualIssue FROM tblaccemp_ucodes_dimension uds  LEFT JOIN tblfsk_style_freetext f on uds.Dimension=f.styleid and FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')  WHERE uds.Companyid='" + cmpId + "' AND f.freetext='" + mAllocText + "' AND uds.Colourid='" + colourId + "'  AND ReasonCode=" + (strReasonCode) + " AND '" + mPointDate + "' BETWEEN StartDate AND EndDate ";
                    }
                    else
                    {
                        sql = "select Annualissue from tblaccemp_ucodes where companyId='" + cmpId + "' and UcodeId='" + Ucode + "' and StyleId='" + styleId + "' And ColourId='" + colourId + "'";
                    }

                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    var dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        EmpAnnualIssue = dr.GetString("Annualissue") == "" ? 0 : Convert.ToDouble(dr.GetString("Annualissue"));
                    }
                    else
                    {
                        dr1.Close();

                        sql = "SELECT DISTINCT FreeText  FROM tblfsk_style_freetext WHERE StyleID='" + styleId + "' AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')";

                        MySqlCommand cmd2 = new MySqlCommand(sql, conn);
                        var dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            mAllocText = dr2.GetString("FreeText");
                        }
                        dr2.Close();
                        if (mAllocText != "")
                        {
                            sql = "SELECT SUM(AnnualIssue) AS AnnualIssue FROM tblaccemp_ucodes uds  LEFT JOIN tblfsk_style_freetext f ON uds.StyleId=f.styleid AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')  WHERE uds.Companyid='" + cmpId + "' AND f.freetext='" + mAllocText + "' AND uds.`UCodeID` = '" + Ucode + "' ";
                            MySqlCommand cmd3 = new MySqlCommand(sql, conn);
                            var dr3 = cmd3.ExecuteReader();
                            if (dr3.Read())
                            {
                                EmpAnnualIssue = dr3.GetString("AnnualIssue") != "" ? Convert.ToDouble(dr3.GetString("AnnualIssue")) : 0;
                            }
                            else
                            {
                                EmpAnnualIssue = 0;
                            }
                            dr3.Close();
                            if (EmpAnnualIssue == 0)
                            {
                                sql = "SELECT SUM(AnnualIssue) AS AnnualIssue FROM tblaccemp_ucodes uds  LEFT JOIN tblfsk_style_freetext f ON uds.StyleId=f.styleid AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')  WHERE uds.Companyid='" + cmpId + "' AND f.freetext IN(SELECT DISTINCT `FreeText` FROM `tblfsk_style_freetext` df JOIN (SELECT DISTINCT `StyleId` FROM `tblfsk_style_freetext` sf JOIN (SELECT `FreeText` FROM `tblfsk_style_freetext` WHERE `StyleId` = '" + styleId + "' AND FreeTextType IN('" + FITALLOCvalue + "', '" + DIMALLOCvalue + "')) da ON sf.FreeText=da.FreeText) ds ON df.StyleID=ds.StyleID AND df.`FreeTextType`='" + DIMALLOCvalue + "') AND uds.`UCodeID` = '" + Ucode + "' ";
                                MySqlCommand cmd4 = new MySqlCommand(sql, conn);
                                var dr4 = cmd4.ExecuteReader();
                                if (dr4.Read())
                                {
                                    EmpAnnualIssue = dr4.GetString("AnnualIssue") != "" ? Convert.ToDouble(dr4.GetString("AnnualIssue")) : 0;
                                }
                                else
                                {
                                    EmpAnnualIssue = 0;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return EmpAnnualIssue;
        }

        public int EmployeeRenewDays(string businessId)
        {
            int intVal = Convert.ToInt32(BusinessParam("EmployeeRenew", businessId)) / 12;
            return (intVal * 365);
        }

        public double EmpStock(string styleid, string FITALLOC, string DIMALLOC, string RolloutName, string busId, string colourid, string companyid, string custid, string empid, bool booDimalloc = false, string OrdNo = "")
        {
            double empStock = 0;
            string FITALLOCvalue = FITALLOC;
            string DIMALLOCvalue = DIMALLOC;
            string sql = "";
            string mAllocText = "";
            int syear = RolloutName.Trim() != "" ? 99 : 0;
            bool isRolloutOrder = RolloutName != "" ? true : false;
            string attachString = isRolloutOrder ? " WHERE dss.FreeText='" + mAllocText + "'" : "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                if (booDimalloc == false)
                {
                    sql = "select * from tblaccemp_stockcard Where Companyid='" + companyid + "' and BusinessId='" + custid + "' and EmployeeId='" + empid + "' And Styleid='" + styleid + "' and Colourid='" + colourid + "' AND ADDDATE(`FirstIssueDate`, " + EmployeeRenewDays(busId) + ") > CURDATE()  and year=" + syear;
                }
                else
                {
                    sql = "SELECT DISTINCT FreeText  FROM tblfsk_style_freetext WHERE StyleID='" + styleid + "' AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        mAllocText = reader.GetString("FreeText");
                    }
                    reader.Close();
                    if (mAllocText != "")
                    {
                        sql = "select sum(soqty) as soqty, sum(pickqty) as pickqty, sum(invqty) as invqty from tblaccemp_stockcard stc  Where stc.Companyid='" + companyid + "' and stc.BusinessId='" + custid + "' and stc.EmployeeId='" + empid + "' AND ADDDATE(stc.`FirstIssueDate`, " + EmployeeRenewDays(busId) + ") > CURDATE()  AND stc.`Year`=" + syear + " AND stc.StyleID IN (SELECT DISTINCT `StyleId` FROM `tblfsk_style_freetext` dff JOIN  (SELECT `FreeText` FROM `tblfsk_style_freetext` df JOIN  (SELECT DISTINCT `StyleId` FROM `tblfsk_style_freetext` sf JOIN (SELECT `FreeText` FROM `tblfsk_style_freetext` WHERE `StyleId` IN  (SELECT `StyleId` FROM `tblfsk_style_freetext` WHERE FreeText IN (SELECT FreeText FROM tblfsk_style_freetext WHERE StyleID='" + styleid + "'))) da  ON sf.FreeText=da.FreeText) ds ON df.StyleID=ds.StyleID) dss ON dff.`FreeText`=dss.FreeText " + attachString + " ORDER BY StyleID)  group by stc.companyid, stc.businessid, stc.employeeid";
                    }
                    else
                    {
                        sql = "select * from tblaccemp_stockcard Where Companyid='" + cmpId + "' and BusinessId='" + custid + "' and EmployeeId='" + empid + "' And Styleid='" + styleid + "' and Colourid='" + colourid + "' AND ADDDATE(`FirstIssueDate`, " + EmployeeRenewDays(busId) + ") > CURDATE()  and year= " + syear;
                    }
                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    var reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        string soQty = reader1.GetString("SoQty");
                        double PickQty = reader1.GetString("PickQty") == null || reader1.GetString("PickQty") == "" ? 0 : Convert.ToDouble(reader1.GetString("PickQty"));
                        double invQty = reader1.GetString("InvQty") == null || reader1.GetString("InvQty") == "" ? 0 : Convert.ToDouble(reader1.GetString("InvQty"));
                        empStock = soQty == null || reader1.GetString("PickQty") == "" ? 0 : Convert.ToDouble(soQty) + PickQty + invQty;
                    }
                    else
                    {
                        empStock = 0;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return empStock;
        }

        #endregion

        #region  hasBudget

        public bool HasBudget(string pinNo, string busId)
        {
            bool result = false;
            string sSql = "";
            string bgtTyp = "";
            bool booBgtType = false;
            bgtTyp = BusinessParam("REQDIVBUDGET", busId);
            booBgtType = bgtTyp == "" ? false : Convert.ToBoolean(bgtTyp);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                if (booBgtType)
                {
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        //    Public Function hasBudget(ByVal PinNo As String, ByVal BusID As String) As Boolean
        //    Dim rsBudget As New ADODB.Recordset
        //    Dim SQL As String
        //    If Conn Is Nothing Then
        //        Conn = OpenDatabase()
        //    End If
        //    If Conn.State = 0 Then
        //        Conn.Open()
        //    End If

        //    'Check for Default Employee dt 19/08/09
        //    Dim BgtType As String
        //    Dim booBgtType As Boolean
        //    BgtType = BusinessParam("REQDIVBUDGET", BusID)
        //    booBgtType = IIf(BgtType = "", False, CBoolstr(BgtType))
        //    If booBgtType Then
        //        PinNo = GetDefEmp_DivBudget(BusID, PinNo)
        //    End If

        //    SQL = "SELECT tblaccemp_budget.Budget " & _
        //          "FROM tblaccemp_employee INNER JOIN tblaccemp_budget ON (tblaccemp_employee.BusinessID = tblaccemp_budget.BusinessID) AND (tblaccemp_employee.CompanyID = tblaccemp_budget.CompanyID) AND (tblaccemp_employee.RoleID = tblaccemp_budget.RoleID) " & _
        //          "WHERE tblaccemp_employee.EmployeeID='" & PinNo & "' AND tblaccemp_budget.BusinessID='" & BusID & "'"
        //    rsBudget.Open(LCase(SQL), Conn)
        //    hasBudget = Not rsBudget.EOF
        //    rsBudget.Close()
        //    rsBudget = Nothing
        //End Function
        #endregion
        #endregion

        #region commonmethods
        #region ExecuteQuery
        public int ExecuteQuery(MySqlConnection conn, string sSqry)
        {
            int result = -1;

            try
            {

                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {

            }
            return result;
        }

        public bool SaveEmailUser(string sSry = "")
        {
            bool result = false;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sSry, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public int ExecuteQuerywidTrans(string sSqry = "")
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                trans.Rollback();
            }
            finally
            {

                conn.Close();
            }
            return result;
        }
        #endregion




        #endregion
        #region
        public string GetForgetPasswordMailTemplate(tbluser user)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string forgetPasswordTemplate = System.IO.File.ReadAllText(appPath + "\\ForgetPassword.html");
            var forPwdTmpBuilder = new StringBuilder(forgetPasswordTemplate);
            forPwdTmpBuilder.Replace("{%forename%}", user.ForeName);
            forPwdTmpBuilder.Replace("{%surname%}", user.SurName);
            forPwdTmpBuilder.Replace("{%password%}", user.Password);
            return forPwdTmpBuilder.ToString();
        }
        #endregion

        #region GetEmergencyMessage
        public string GetEmergencyMessage()
        {
            var result = "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string EmergencyMessage = System.IO.File.ReadAllText(appPath + "\\EmergencyMessage.html");
            var emergencyTemplate = new StringBuilder(EmergencyMessage);
            result = "<div>" + emergencyTemplate + "</div>";
            return result;
        }


        #endregion

        #region GetPrivateMessage
        public string GetPrivateMessage()
        {
            var result = "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string PrivateMessage = System.IO.File.ReadAllText(appPath + "\\PrivateMessage.html");
            var PrivateMessageTemplate = new StringBuilder(PrivateMessage);
            result = "<div>" + PrivateMessageTemplate + "</div>";
            return result;
        }


        #endregion

        #region SendConfirmPrivateOrderMail

        public void SendConfirmPrivateOrderMail(long ordNo, string Date, string empName, string txnId, string gatewayImg, string mailUsername, string adminMail, string mailPassword, string mailPort, string mailServer, string toEmail, string onlineUsr)
        {
            string finalTemplate = "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string Confirmmess = System.IO.File.ReadAllText(appPath + "\\ConfirmPrivateorder.html");
            var ConfirmTemplate = new StringBuilder(Confirmmess);
            ConfirmTemplate.Replace("%orderno%", ordNo.ToString());
            ConfirmTemplate.Replace("%onlineusername%", onlineUsr.ToString());
            ConfirmTemplate.Replace("%orderdate%", Date);
            ConfirmTemplate.Replace("%empname%", empName);
            ConfirmTemplate.Replace("%transactionid%", txnId);
            ConfirmTemplate.Replace("%gatewayimage%", gatewayImg);
            ConfirmTemplate.Replace("%companyname%", "Uniform Express Limited");
            finalTemplate = "" + ConfirmTemplate + "";
            sendSmtpMail("Online Order Confirmed", adminMail, mailUsername, mailPassword, mailPort, mailServer, finalTemplate, toEmail, "", "");
        }
        #endregion

        #region GetPrivateOrderMailMessage
        public string GetPrivateOrderMailMessage(SalesOrderHeaderViewModel salesHead, string custLogo, string cmpLogo, long orderNO, bool print = false)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string finalEmailTemplate = "";
            string orderHeaderTemplate = System.IO.File.ReadAllText(appPath + "\\OrderHeader_Template.html");
            string orderLinesTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_Template.html");
            string emailTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_email.html");
            string orderDetailTemplate = salesHead.OrderType == "RT" ? System.IO.File.ReadAllText(appPath + "\\ReturnOrderTemplate.html") : System.IO.File.ReadAllText(appPath + "\\OrderDetail_Template.html");
            var orderLinesBuilder = new StringBuilder(emailTemplate);
            var orderHeaderbuilder = new StringBuilder(orderHeaderTemplate);
            orderHeaderbuilder = orderHeaderbuilder.Replace("%ReportTitle%", "Private Order Confirmation");
            if (custLogo != "")
            {
                if (custLogo != "")
                {
                    var custLogoPath = custLogo;
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%LogoPath%", custLogoPath);
                }
                else
                {
                    // "Images/no_image.gif"
                }

            }
            if (cmpLogo != "")
            {
                var cmpLogoPath = cmpLogo;
                orderHeaderbuilder = orderHeaderbuilder.Replace("%CompLogoPath%", cmpLogoPath);
            }
            else
            {
                // "Images/no_image.gif"
            }
            try
            {
                var cmp = _company.Exists(s => s.CompanyID == cmpId) ? _company.GetAll(s => s.CompanyID == cmpId).First() : new tblcompany();
                orderHeaderbuilder.Replace("%first_companyname%", cmp.Name);
                orderHeaderbuilder.Replace("%first_companyaddress1%", cmp.Address1);
                orderHeaderbuilder.Replace("%first_companyaddress2%", cmp.Address2);
                orderHeaderbuilder.Replace("%first_companyaddress3%", cmp.Address3);
                orderHeaderbuilder.Replace("%first_companyaddress4%", cmp.Address4);
                orderHeaderbuilder.Replace("%first_companypostcode%", cmp.PostCode);
                orderHeaderbuilder.Replace("%first_companytel%", cmp.Phone);
                orderHeaderbuilder.Replace("%first_companyfax%", cmp.Fax);
                orderHeaderbuilder.Replace("%first_companyemail%", cmp.Email); ;
                orderHeaderbuilder.Replace("%first_companyvat%", cmp.VATno); ;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }

            finalEmailTemplate = orderHeaderbuilder + "<br/><br/><br/>" + FillmailTemplate(orderDetailTemplate, salesHead, 0, orderLinesTemplate, "show", "N", "Custref", orderNO, false, null);
            try
            {
                string warehouseCompanyName = _wareHouses.Exists(s => s.WarehouseID == salesHead.WarehouseID) ? _wareHouses.GetAll(s => s.WarehouseID == salesHead.WarehouseID).First().WarehouseName : "";
                orderLinesBuilder.Replace("%first_companyname%", warehouseCompanyName);
                if (salesHead.OrderType != "rt")
                {
                    orderLinesBuilder.Replace("%returnOrdNo% ", "");
                }
                orderLinesBuilder.Replace("%first_companyname%", warehouseCompanyName);
                if (print)
                {
                    finalEmailTemplate = "<html><head></head><body><div style='width:10%;'></div><div style='width:80%;'>" + finalEmailTemplate + "</div><div style='width:10%;'></div></body></html>";
                }
                else
                {
                    finalEmailTemplate = "<html><head></head><body><div style='width:10%;'></div><div style='width:80%;'>" + finalEmailTemplate + "<br/>" + orderLinesBuilder + "</div><div style='width:10%;'></div></body></html>";
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            return finalEmailTemplate;
        }
        #endregion

        public string GetPrivateReturnMail(SalesOrderHeaderViewModel salesHead, string rolloutname, string custLogo, string cmpLogo, long manpackNo, string pricePermission, string ONLCUSREFLBL, long orderNo, bool isedit = false, UpdateMailModel updModel = null)
        {
            string result = "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string orderLinesTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_Template.html");
            string orderDetailTemplate = System.IO.File.ReadAllText(appPath + "\\PrivateReturnConfirmation.html");
            if (salesHead.SalesOrderLine != null)
            {
                result = FillmailTemplate(orderDetailTemplate, salesHead, manpackNo, orderLinesTemplate, pricePermission, "N", ONLCUSREFLBL, orderNo, isedit, updModel);
            }
            return result;
        }

        #region GetNecessaryMailTemplates

        public OrderConfirmation GetNecessaryMailTemplates(SalesOrderHeaderViewModel salesHead, string rolloutname, string custLogo, string cmpLogo, long manpackNo, string pricePermission, string ONLCUSREFLBL, long orderNo, bool isedit = false, UpdateMailModel updModel = null)
        {
            // var path =  ;
            OrderConfirmation ocnfirm = new OrderConfirmation();
            string finalEmailTemplate = "";
            List<string> mailTemplates = new List<string>();
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string orderHeaderTemplate = System.IO.File.ReadAllText(appPath + "\\OrderHeader_Template.html");
            string orderLinesTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_Template.html");
            string emailTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_email.html");
            string orderDetailTemplate = salesHead.OrderType == "RT" ? System.IO.File.ReadAllText(appPath + "\\ReturnOrderTemplate.html") : System.IO.File.ReadAllText(appPath + "\\OrderDetail_Template.html");
            string txtNomlbl = BusinessParam("ONLNETXTNOM1", salesHead.CustID);
            string reqnom = CompanyParam("ONLNEREQNOM1", cmpId);
            BusAddress1 custAdd = new BusAddress1();
            if (1 == 1)
            {
                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + salesHead.CustID + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                custAdd = GetAddressDetails(SQL);
            }
            if (txtNomlbl == "")
            {
                if (reqnom != "")
                {
                    if (Convert.ToBoolean(reqnom))
                    {
                        txtNomlbl = CompanyParam("ONLNETXTNOM1", cmpId);
                    }
                    else
                    {
                        txtNomlbl = "Nominal Code";
                    }
                }
            }
            var orderLinesBuilder = new StringBuilder(emailTemplate);
            var orderHeaderbuilder = new StringBuilder(orderHeaderTemplate);
            orderHeaderbuilder = orderHeaderbuilder.Replace("%ReportTitle%", salesHead.OrderType.ToUpper() == "RT" ? "Return Order Confirmation" : "Order Confirmation");
            if (salesHead.NomCode3 != "")
            {
                orderHeaderbuilder = orderHeaderbuilder.Replace("%RollOutName%", rolloutname);
            }
            else if (rolloutname == "")
            {

            }
            else
            {

            }
            if (custLogo != "")
            {
                if (custLogo != "")
                {
                    var custLogoPath = custLogo;
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%LogoPath%", custLogoPath);
                }
                else
                {
                    // "Images/no_image.gif"
                }

            }
            if (cmpLogo != "")
            {
                var cmpLogoPath = cmpLogo;
                orderHeaderbuilder = orderHeaderbuilder.Replace("%CompLogoPath%", cmpLogoPath);
            }
            else
            {
                // "Images/no_image.gif"
            }
            try
            {
                var cmp = _company.Exists(s => s.CompanyID == cmpId) ? _company.GetAll(s => s.CompanyID == cmpId).First() : new tblcompany();
                orderHeaderbuilder.Replace("%first_companyname%", cmp.Name);
                orderHeaderbuilder.Replace("%first_companyaddress1%", cmp.Address1);
                orderHeaderbuilder.Replace("%first_companyaddress2%", cmp.Address2);
                orderHeaderbuilder.Replace("%first_companyaddress3%", cmp.Address3);
                orderHeaderbuilder.Replace("%first_companyaddress4%", cmp.Address4);
                orderHeaderbuilder.Replace("%first_companypostcode%", cmp.PostCode);
                orderHeaderbuilder.Replace("%first_companytel%", cmp.Phone);
                orderHeaderbuilder.Replace("%first_companyfax%", cmp.Fax);
                orderHeaderbuilder.Replace("%first_companyemail%", cmp.Email); ;
                orderHeaderbuilder.Replace("%first_companyvat%", cmp.VATno); ;
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }

            if (salesHead.OrderType.ToUpper() == "RT")
            {
                finalEmailTemplate = orderHeaderbuilder + "<br/><br/><br/>" + FillmailTemplate(orderDetailTemplate, salesHead, manpackNo, orderLinesTemplate, "hide", "N", ONLCUSREFLBL, orderNo, isedit, updModel);
            }
            else
            {
                finalEmailTemplate = orderHeaderbuilder + "<br/><br/><br/>" + FillmailTemplate(orderDetailTemplate, salesHead, manpackNo, orderLinesTemplate, "hide", "N", ONLCUSREFLBL, orderNo, isedit, updModel);
            }
            try
            {
                string warehouseCompanyName = _wareHouses.Exists(s => s.WarehouseID == salesHead.WarehouseID) ? _wareHouses.GetAll(s => s.WarehouseID == salesHead.WarehouseID).First().WarehouseName : "";
                orderLinesBuilder.Replace("%first_companyname%", warehouseCompanyName);
                if (salesHead.OrderType.ToLower() != "rt")
                {
                    orderLinesBuilder.Replace("%returnOrdNo% ", "");
                }

                orderLinesBuilder.Replace("%first_companyname%", warehouseCompanyName);
                ocnfirm.OrderConfirmationPOP = "<html><head></head><body><div style='width:10%;'></div><div style='width:80%;'>" + finalEmailTemplate + "</div><div style='width:10%;'></div></body></html>";
                if (salesHead.CustRef.ToLower().Contains("private") == false || salesHead.OrderType.ToLower() == "so" || (salesHead.OrderAnalysisCode4 != "" && salesHead.OrderAnalysisCode4 != null) || (salesHead.UCodeId != "" && salesHead.UCodeId != null))
                {
                    finalEmailTemplate.Replace("%privateconfirmation%", "");
                }
                finalEmailTemplate = "<html><head></head><body><div style='width:10%;'></div><div style='width:80%;'>" + finalEmailTemplate + "<br/>" + orderLinesBuilder + "</div><div style='width:10%;'></div></body></html>";
                ocnfirm.OrderConfirmationemail = finalEmailTemplate;

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }

            return ocnfirm;

        }

        #endregion

        #region getEmergencyTemplate
        public string getEmergencyTemplate(SalesOrderHeaderViewModel saleshead, long orderNo)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string emergencyEmailTemplate = System.IO.File.ReadAllText(appPath + "\\EmergencyEmail.html");
            var emergencyBuilder = new StringBuilder(emergencyEmailTemplate);
            var compnay = _company.Exists(s => s.CompanyID == cmpId) ? _company.GetAll(s => s.CompanyID == cmpId).First().Name : "";
            emergencyBuilder.Replace("%CustName%", saleshead.CustomerName);
            emergencyBuilder.Replace("%OrderNo%", orderNo.ToString());
            emergencyBuilder.Replace("%OrdDate%", saleshead.OrderDate);
            emergencyBuilder.Replace("%EmpName%", saleshead.EmployeeName);
            emergencyBuilder.Replace("%CompanyName%", compnay);
            emergencyBuilder.Replace("%EmpID%", saleshead.EmployeeID);
            string message = "";
            message = message + "<html><head></head><body>" + emergencyBuilder + "</body></html>";
            return message;
        }
        #endregion

        #region fillmailTemplate
        public string FillmailTemplate(string detailTemp, SalesOrderHeaderViewModel saleshead, long manPack, string emailLine, string pricePermission, string carrierCharges, string ONLCUSREFLBL, long orderNo, bool isedit = false, UpdateMailModel updModel = null)
        {
            Removeapostrophes(saleshead);
            string Barcode = "";
            string stlLine = "", returnString = "";
            string strsql = "SELECT count(t1.ProjectCode) as cntproject  FROM tblsop_customerorder_template_costcentre t1 WHERE t1.Businessid='{0}'  ORDER BY t1.ProjectCode ASC";
            var builder1 = new StringBuilder(detailTemp);
            int projCode = CheckForProjectCode(strsql);
            List<SalesOrderHeaderViewModel> totLst = new List<SalesOrderHeaderViewModel>();
            totLst.Add(saleshead);
            TotalModel tot = new TotalModel();
            tot = GetAlltotals(totLst, 0.0, false);
            var carriage = saleshead.SalesOrderLine.Any(s => s.isCarrline) ? saleshead.SalesOrderLine.Where(s => s.isCarrline).Sum(s => s.Price) : 0.0;
            string empTite = "";
            try
            {
                empTite = _employee.Exists(s => s.EmployeeID == saleshead.EmployeeID) ? _employee.GetAll(s => s.EmployeeID == saleshead.EmployeeID).First().Title : "";
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            if (projCode == 0)
            {
                builder1.Replace("<th>ProjectCode</th>", "");
            }
            if (isedit == false)
            {
                builder1.Replace("%editedorderinformation%", "");
            }
            else
            {
                builder1.Replace("%editedorderinformation%", updModel.MailTemplate);
            }
            if (saleshead.OrderType == "RT" && saleshead.CustRef.ToLower().Contains("private") == false)
            {
                builder1.Replace("%privateconfirmation%", "");
                builder1.Replace("%reOrdNo%", "");
            }
            else if (saleshead.OrderType.ToLower() == "so" && saleshead.CustRef.ToLower().Contains("private"))
            {
                builder1.Replace("%reOrdNo%", "<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;background-color:#009885;color:white;'>Reorder no</th>");
                // builder1.Replace("%reordertab%", "<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;background-color:#009885;color:white;'>Reorder no</th>");
            }
            else
            {
                if (saleshead.CustRef.ToLower().Contains("private"))
                {

                }
                else
                {
                    builder1.Replace("%privateconfirmation%", "");
                    builder1.Replace("%reOrdNo%", "");
                }
            }
            builder1.Replace("%BarcodeOrderNo%", "");
            builder1.Replace("%customer_name%", saleshead.CustomerName);
            builder1.Replace("%customer_address1%", saleshead.InvAddress1);
            builder1.Replace("%customer_address2%", saleshead.InvAddress2);
            builder1.Replace("%customer_address3%", saleshead.InvAddress3);
            builder1.Replace("%customer_town%", saleshead.InvTown);
            builder1.Replace("%customer_city%", saleshead.InvCity);
            builder1.Replace("%customer_postcode%", saleshead.InvPostCode);
            builder1.Replace("%customer_country%", saleshead.InvCountry);
            if (saleshead.OrderType.ToUpper() == "RT")
            {
                builder1.Replace("%orginalorderno%", "<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;background-color:#009885;color:white;'>Original OrderNo</th>");
                builder1.Replace("%delivery_name%", saleshead.DelDesc);
                builder1.Replace("%delivery_address1%", saleshead.DelAddress1);
                builder1.Replace("%delivery_address2%", saleshead.DelAddress2);
                builder1.Replace("%delivery_address3%", saleshead.DelAddress3);
                builder1.Replace("%delivery_town%", saleshead.DelTown);
                builder1.Replace("%delivery_city%", saleshead.DelCity);
                builder1.Replace("%delivery_postcode%", saleshead.DelPostCode);
                builder1.Replace("%delivery_country%", saleshead.DelCountry);
            }
            else
            {
                builder1.Replace("%orginalorderno%", "");
                builder1.Replace("%delivery_name%", saleshead.CustomerName);
                builder1.Replace("%delivery_address1%", saleshead.DelAddress1);
                builder1.Replace("%delivery_address2%", saleshead.DelAddress2);
                builder1.Replace("%delivery_address3%", saleshead.DelAddress3);
                builder1.Replace("%delivery_town%", saleshead.DelTown);
                builder1.Replace("%delivery_city%", saleshead.DelCity);
                builder1.Replace("%delivery_postcode%", saleshead.DelPostCode);
                builder1.Replace("%delivery_country%", saleshead.DelCountry);
            }
            Barcode = CompanyParam("BARCODESOPTYPE", saleshead.CompanyID);

            //builder1.Replace("%BarcodeOrderNo%", saleshead.OrderType.ToUpper()=="RT", returnBarcode(myReader("OrderNo").Value, Barcode), ""))

            builder1.Replace("%OrderNo%", orderNo.ToString());
            builder1.Replace("%OrderDate%", DateTime.Parse(saleshead.OrderDate).ToString("dd-MM-yyyy"));
            builder1.Replace("%CustRef%", saleshead.CustRef);
            builder1.Replace("Cust Ref", ONLCUSREFLBL);
            builder1.Replace("%ManPackNo%", manPack == 0 ? "" : manPack.ToString());

            builder1.Replace("%AccountNo%", saleshead.CustID);
            builder1.Replace("%NominalCode%", saleshead.NomCode == "" ? "" : saleshead.NomCode);
            builder1.Replace("%Employee%", saleshead.EmployeeID + " - " + empTite + " " + saleshead.EmployeeName);
            try
            {
                if (saleshead.ContractRef != null)
                {
                    builder1.Replace("%RC%", saleshead.ContractRef.ToUpper() == "RC" ? "*This Return Requires Collection" + saleshead.ContactName == null ? "" : "<br /><b><u>Contact Detail</u></b><br />" + String.Format("Name: {0}, Email: {1}", saleshead.ContactName, saleshead.EmailID, "") : "");
                }
                else
                {
                    builder1.Replace("%RC%", "<br /><b><u>Contact Detail</u></b><br />" + String.Format("Name: {0}, Email: {1}", saleshead.ContactName, saleshead.EmailID, ""));
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);

            }

            foreach (var saleLine in saleshead.SalesOrderLine.Where(s => s.IsDleted == false))
            {
                var builder2 = new StringBuilder(emailLine);
                if (projCode == 0)
                {
                    builder2.Replace("<td>%ProjectCode%</td>", "");
                }
                builder2.Replace("%style%", saleLine.StyleID);
                builder2.Replace("%Description%", saleLine.Description.Trim());
                builder2.Replace("%Colour%", saleLine.ColourID);
                builder2.Replace("%Size%", saleLine.SizeID);
                //If CBool(Session.Item("UseMatrix")) Then
                //    builder2.Replace("%Colour%", rs1("ColourID").Value)
                //    builder2.Replace("%Size%", rs1("SizeID").Value)
                //End If
                builder2.Replace("%qty%", saleLine.OrdQty.ToString());
                if (pricePermission.ToUpper() == "READWRITE")
                {
                    builder2.Replace("%price%", string.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price), 2));
                    builder2.Replace("%netvalue%", string.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round((saleLine.Price) * (saleLine.OrdQty)), 2));
                    builder2.Replace("%vat%", GetlineVat(saleLine.OrdQty, saleLine.Price, GetVatPercent(saleLine.StyleID, saleLine.SizeID)).ToString());
                }
                else if (pricePermission.ToUpper() == "READONLY")
                {
                    builder2.Replace("%price%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price, 2)));
                    builder2.Replace("%netvalue%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round
                    ((saleLine.OrdQty) * saleLine.Total, 2)));
                    builder2.Replace("%vat%", GetlineVat(saleLine.OrdQty, saleLine.Price, GetVatPercent(saleLine.StyleID, saleLine.SizeID)).ToString());
                }
                else if (pricePermission.ToUpper() == "HIDE")
                {
                    if (saleshead.CustRef.ToLower().Contains("private"))
                    {
                        builder2.Replace("%price%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price, 2)));
                        builder2.Replace("%netvalue%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round
                        ((saleLine.OrdQty) * saleLine.Total, 2)));
                        builder2.Replace("%vat%", GetlineVat(saleLine.OrdQty, saleLine.Price, GetVatPercent(saleLine.StyleID, saleLine.SizeID)).ToString());
                    }
                    else
                    {
                        builder2.Replace("%price%", "N/A");
                        builder2.Replace("%netvalue%", "N/A");
                        builder2.Replace("%vat%", "N/A");
                    }
                }
                else
                {
                    builder2.Replace("%price%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price, 2)));
                    builder2.Replace("%netvalue%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round
                    ((saleLine.OrdQty) * saleLine.Total, 2)));

                    builder2.Replace("%vat%", saleLine.VAT.ToString("0.00"));
                }
                string strFreeText = StyleParam("REQDATA1", saleLine.StyleID) + " " + saleLine.FreeText1 + saleLine.NomCode;
                // builder2.Replace("%freetext%", strFreeText.Trim() == "" ? "" : "(" + strFreeText + ")");
                if (saleshead.OrderType == "RT")
                {
                    var reason = _reason.Exists(s => s.ReasonCode == saleLine.ReasonCodeLine && s.CompanyID == saleshead.CompanyID) ? _reason.GetAll(s => s.ReasonCode == saleLine.ReasonCodeLine && s.CompanyID == saleshead.CompanyID).First().Description : "";
                    builder2.Replace("%reason%", reason);
                    builder2.Replace("%returnOrdNo%", "<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>" + saleLine.OriginalOrderNo.ToString() + "</td>");
                    builder2.Replace("%reOrdNo%", "");
                }
                else
                {
                    if (saleshead.CustRef.ToLower().Contains("private") && saleshead.OrderType.ToLower() == "so")
                    {
                        var orderNO = saleLine.OrderNo > 0 ? saleLine.OrderNo : saleshead.OrderNo;
                        builder2.Replace("%reOrdNo%", "<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>" + orderNO.ToString() + "</td>");
                    }
                    else
                    {
                        builder2.Replace("%reOrdNo%", "");
                    }
                    builder2.Replace("%returnOrdNo%", "");
                    builder2.Replace("%reason%", saleLine.SOPDetail4);
                }
                if (saleshead.OrderType.ToUpper() != "RT")
                {
                    var orderNO = saleLine.OrderNo > 0 ? saleLine.OrderNo : saleshead.OrderNo;
                    builder2.Replace("%OrgOrderNo%", orderNO.ToString());
                    builder2.Replace("%OrgPORef%", saleshead.CustRef);
                }
                else
                {
                    //

                    //builder2.Replace("%OrgOrderNo%", rs1("ReturnOrderNo").Value.ToString)
                    //         builder2.Replace("%OrgPORef%", "")
                }
                builder2.Replace("%ProjectCode%", projCode.ToString());
                stlLine = stlLine + builder2;
            }
            var ss = "" + builder1 + "";
            if (saleshead.SalesOrderLine.Count > 0)
            {
                builder1.Replace("%DeliveryDate%", DateTime.Parse(saleshead.SalesOrderLine.First().DeliveryDate).ToString("dd-MM-yyyy"));
            }
            builder1.Replace("%OrderLines%", stlLine);
            builder1.Replace("%comments%", saleshead.CommentsExternal);

            var saleLst = new List<SalesOrderHeaderViewModel>();

            saleLst.Add(saleshead);
            var ordTotal = GetAlltotals(saleLst, saleshead.CarrierCharge.Value, false);

            if (pricePermission.ToLower() == "hide" && saleshead.CustRef.ToLower().Contains("private") == false)
            {
                builder1.Replace("Carrier Charges", "");
                builder1.Replace("%carriercharges%", "");
            }
            else
            {
                builder1.Replace("%carriercharges%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(carriage, 2)));
            }
            if (saleshead.CustRef.ToLower().Contains("private"))
            {
                builder1.Replace("%totalgoods%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(ordTotal.ordeTotal, 2)));
                builder1.Replace("%vattotal%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(tot.totalVat, 2)));
                builder1.Replace("%ordertotal%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(Convert.ToDouble(tot.Total), 2)));
                builder1.Replace("%grandtotal%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(Convert.ToDouble(tot.gross), 2)));
            }
            else
            {
                builder1.Replace("%totalgoods%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(ordTotal.ordeTotal, 2)));
                builder1.Replace("%vattotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(ordTotal.totalVat, 2)));
                builder1.Replace("%ordertotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(Convert.ToDouble(ordTotal.Total) + saleshead.CarrierCharge.Value, 2)));
                builder1.Replace("%grandtotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(Convert.ToDouble(ordTotal.gross) + saleshead.CarrierCharge.Value, 2)));
                //builder1.Replace()
            }
            if (saleshead.OrderType.ToUpper() != "RT")
            {
                builder1.Replace("%OrgOrdHead%", "Org.OrderNo");
                builder1.Replace("%OrgPORef%", "Org.PORef");
            }
            else
            {
                builder1.Replace("%OrgOrdHead%", "Return.No");
                builder1.Replace("%OrgPORef%", "");
            }
            returnString = returnString + builder1;
            return returnString;
        }
        #endregion

        #region UCODESTYLES

        public List<string> UcodeStyles(string ucodeId, string businessId)
        {

            return _stylePoints.Exists(s => s.UcodeID.ToLower().Trim() == ucodeId.ToLower().Trim() && s.BusinessID.ToLower().Trim() == businessId.ToLower().Trim()) ? _stylePoints.GetAll(s => s.UcodeID.ToLower().Trim() == ucodeId.ToLower().Trim() && s.BusinessID.ToLower().Trim() == businessId.ToLower().Trim()).Select(s => s.StyleID).ToList() : new List<string>();
        }
        #endregion


        #region FillExistingOrderLineMessage
        public string FillExistingOrderLineMessage(SalesOrderHeaderViewModel saleshead, string pricePermission)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string lineHeaders = System.IO.File.ReadAllText(appPath + "\\EditOrderTemplate.html");
            string emailLine = System.IO.File.ReadAllText(appPath + "\\OrderLines_Template.html");
            string returnString = "", stlLine = "";
            var builder1 = new StringBuilder(lineHeaders);
            foreach (var saleLine in saleshead.SalesOrderLine.Where(s => s.IsDleted == false))
            {
                var builder2 = new StringBuilder(emailLine);

                builder2.Replace("%style%", saleLine.StyleID);
                builder2.Replace("%Description%", saleLine.Description.Trim());
                builder2.Replace("%Colour%", saleLine.ColourID);
                builder2.Replace("%Size%", saleLine.SizeID);
                //If CBool(Session.Item("UseMatrix")) Then
                //    builder2.Replace("%Colour%", rs1("ColourID").Value)
                //    builder2.Replace("%Size%", rs1("SizeID").Value)
                //End If
                builder2.Replace("%qty%", saleLine.OrdQty.ToString());
                if (pricePermission.ToUpper() == "READWRITE")
                {
                    builder2.Replace("%price%", string.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price), 2));
                    builder2.Replace("%netvalue%", string.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round((saleLine.Price) * (saleLine.OrdQty)), 2));
                }
                else if (pricePermission.ToUpper() == "READONLY")
                {
                    builder2.Replace("%price%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleLine.Price, 2)));
                    builder2.Replace("%netvalue%", String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round
                    ((saleLine.OrdQty) * saleLine.Price, 2)));
                    builder2.Replace("%vat%", "");
                }
                else if (pricePermission.ToUpper() == "HIDE")
                {
                    builder2.Replace("%price%", "N/A");
                    builder2.Replace("%netvalue%", "N/A");
                    builder2.Replace("%vat%", "N/A");
                }
                string strFreeText = StyleParam("REQDATA1", saleLine.StyleID) + " " + saleLine.FreeText1 + saleLine.NomCode;
                // builder2.Replace("%freetext%", strFreeText.Trim() == "" ? "" : "(" + strFreeText + ")");
                builder2.Replace("%reason%", saleLine.SOPDetail4);
                if (saleshead.OrderType.ToUpper() != "RT")
                {
                    builder2.Replace("%OrgOrderNo%", saleshead.OrderNo.ToString());
                    builder2.Replace("%returnOrdNo%", "");
                    builder2.Replace("%OrgOrderNo%", saleshead.OrderNo.ToString());
                    builder2.Replace("%OrgPORef%", saleshead.CustRef);
                }
                else
                {
                    //builder2.Replace("%OrgOrderNo%", rs1("ReturnOrderNo").Value.ToString)
                    //         builder2.Replace("%OrgPORef%", "")
                }
                stlLine = stlLine + builder2;
            }
            var LineHeader = builder1.Replace("%OrderLines%", stlLine);

            returnString = returnString + LineHeader;
            return returnString;
        }
        #endregion

        #region ShowAllOrders

        public List<OrderDisplayModel> GetAllOrders(string OrderType, string busId, string userid, List<string> usrs, string role, bool boopts, string ordPerm, bool isEmergencyOrder, bool booIsConfirm = false, string RequirePermissionUSR = "")
        {
            // var matUcodes = _ucodeReason.Exists(s => s.BusinessID == busId && s.UcodeId.ToLower().Contains("maternity")) ? _ucodeReason.GetAll(s => s.BusinessID == busId && s.UcodeId.ToLower().Contains("maternity")).Select(s => s.UcodeId).ToList() : new List<string>();
            var ucodeLst = _pointsByUcode.GetAll(s => s.BusinessID == busId).Select(s => s.UcodeID).ToList();
            List<OrderDisplayModel> ShowOrdersRslt = new List<OrderDisplayModel>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            var lstRtncredited = _tblRtnCredites.GetAll(s => s.BusinessId == busId && s.CompanyId == cmpId).Select(s => Convert.ToInt64(s.OrderNo)).ToList();
            conn.Open();
            try
            {
                string qry = "";
                if (isEmergencyOrder)
                {
                    qry = getshowallordQryEmergency(OrderType, usrs, busId, role, boopts, ordPerm, userid, RequirePermissionUSR);
                }
                else
                {
                    qry = getshowallordQry(OrderType, usrs, busId, role, boopts, ordPerm, userid, booIsConfirm, RequirePermissionUSR);
                }
                if (qry != "")
                {
                    MySqlCommand cmd = new MySqlCommand(qry, conn);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (isEmergencyOrder)
                        {

                            ShowOrdersRslt = dt.AsEnumerable().Select(s => new OrderDisplayModel
                            {
                                OrderNo = s.ItemArray[0].ToString() != null && s.ItemArray[0].ToString() != "" ? Convert.ToInt32(s.ItemArray[0].ToString()) : 0,
                                OrderDate = DateTime.Parse(s.ItemArray[1].ToString()),
                                DelDesc = s.ItemArray[3].ToString() != null && s.ItemArray[3].ToString() != "" ? s.ItemArray[3].ToString() : "",
                                Address1 = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? s.ItemArray[6].ToString() : "",
                                TotalQty = s.ItemArray[4].ToString() != null && s.ItemArray[4].ToString() != "" ? Convert.ToInt64(s.ItemArray[4].ToString()) : 0,
                                GoodsValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
                                TotalIncVat = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToDouble(s.ItemArray[7].ToString()) : 0,
                                UserId = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? s.ItemArray[9].ToString() : "",
                                IsConfirmed = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? s.ItemArray[10].ToString() : "",
                                IsProcessed = s.ItemArray[11].ToString() != null && s.ItemArray[11].ToString() != "" ? s.ItemArray[11].ToString() : "",
                                CustomerRef = s.ItemArray[14].ToString() != null && s.ItemArray[14].ToString() != "" ? s.ItemArray[14].ToString() : "",
                                EmpID = s.ItemArray[16].ToString() != null && s.ItemArray[16].ToString() != "" ? s.ItemArray[16].ToString() : "",
                                PersonPackNo = s.ItemArray[17].ToString() != null && s.ItemArray[17].ToString() != "" ? Convert.ToInt32(s.ItemArray[17].ToString()) : 0,
                                EmpName = s.ItemArray[18].ToString() != null && s.ItemArray[18].ToString() != "" ? s.ItemArray[18].ToString() : "",
                                FirstDespatch = s.ItemArray[21].ToString() != null && s.ItemArray[21].ToString() != "" ? s.ItemArray[21].ToString() : "",
                                CourrierRef = s.ItemArray[22].ToString() != null && s.ItemArray[22].ToString() != "" ? s.ItemArray[22].ToString() : "",
                                DeliveryDay = s.ItemArray[24].ToString() != "" ? s.ItemArray[24].ToString() : "",
                                DeliveryWeek = s.ItemArray[23].ToString() != "" ? Convert.ToInt32(s.ItemArray[23].ToString()) : 0,
                                EmergencyReason = s.ItemArray[6].ToString() != "" ? s.ItemArray[6].ToString() : "",
                                UCODEID = s["UCODEID"].ToString() != "" ? s["UCODEID"].ToString() : "",
                                OrderType = "Emergency(" + s["UCODEID"].ToString() + ")",
                                RtnOrdNo = s["RtnOrder"].ToString() != "" ? Convert.ToInt32(s["RtnOrder"].ToString()) : 0,
                            }).ToList();
                            if (ShowOrdersRslt.Any(s => s.RtnOrdNo > 0 || s.NominalCode == ""))
                            {
                                ShowOrdersRslt.Where(s => s.RtnOrdNo > 0 || s.NominalCode == "").ToList().ForEach(s => s.OrderType = "Emergency Exchange order (" + s.UCODEID + ")");
                            }

                        }
                        else
                        {
                            if (booIsConfirm)
                            {
                                ShowOrdersRslt = dt.AsEnumerable().Select(s => new OrderDisplayModel
                                {
                                    OrderNo = s.ItemArray[0].ToString() != null && s.ItemArray[0].ToString() != "" ? Convert.ToInt32(s.ItemArray[0].ToString()) : 0,
                                    OrderDate = DateTime.Parse(s.ItemArray[1].ToString()),
                                    DelDesc = s.ItemArray[3].ToString(),
                                    Address1 = s.ItemArray[4].ToString(),
                                    TotalQty = Convert.ToInt64(s.ItemArray[5].ToString()),
                                    GoodsValue = Convert.ToDouble(s.ItemArray[7].ToString()),
                                    TotalIncVat = Convert.ToDouble(s.ItemArray[6].ToString()),
                                    UserId = s.ItemArray[8].ToString(),
                                    IsConfirmed = s.ItemArray[9].ToString(),
                                    IsProcessed = s.ItemArray[10].ToString(),
                                    CustomerRef = s.ItemArray[13].ToString(),
                                    EmpID = s.ItemArray[15].ToString(),
                                    PersonPackNo = Convert.ToInt32(s.ItemArray[16].ToString()),
                                    EmpName = s.ItemArray[17].ToString(),
                                    NominalCode = s.ItemArray[19].ToString(),
                                    FirstDespatch = s.ItemArray[21].ToString() != null && s.ItemArray[21].ToString() != "" ? s.ItemArray[21].ToString() : "",
                                    CourrierRef = s.ItemArray[22].ToString(),
                                    TotalPoints = s.ItemArray[24].ToString() != "" ? Convert.ToInt32(s.ItemArray[23].ToString()) : 0,
                                    PointsSpent = s.ItemArray[24].ToString() != "" ? Convert.ToInt32(s.ItemArray[24].ToString()) : 0,
                                    DeliveryDay = booIsConfirm ? s.ItemArray[26].ToString() != "" ? s.ItemArray[26].ToString() : "" : "",
                                    DeliveryWeek = booIsConfirm ? s.ItemArray[25].ToString() != "" ? Convert.ToInt32(s.ItemArray[25].ToString()) : 0 : 0,
                                    RtnOrdNo = s["RtnOrder"].ToString() != "" ? Convert.ToInt32(s["RtnOrder"].ToString()) : 0,
                                    UCODEID = s["ucodeid"].ToString()
                                }).ToList();
                            }
                            else
                            {
                                ShowOrdersRslt = dt.AsEnumerable().Select(s => new OrderDisplayModel
                                {

                                    OrderNo = s.ItemArray[0].ToString() != null && s.ItemArray[0].ToString() != "" ? Convert.ToInt64(s.ItemArray[0].ToString()) : 0,
                                    OrderDate = DateTime.Parse(s.ItemArray[1].ToString()),
                                    DelDesc = s.ItemArray[3].ToString(),
                                    Address1 = s.ItemArray[4].ToString(),
                                    TotalQty = Convert.ToInt64(s.ItemArray[5].ToString()),
                                    GoodsValue = Convert.ToDouble(s.ItemArray[7].ToString()),
                                    TotalIncVat = Convert.ToDouble(s.ItemArray[6].ToString()),
                                    UserId = s.ItemArray[8].ToString(),
                                    IsConfirmed = s.ItemArray[9].ToString(),
                                    IsProcessed = s.ItemArray[10].ToString(),
                                    CustomerRef = s.ItemArray[13].ToString(),
                                    EmpID = s.ItemArray[15].ToString(),
                                    PersonPackNo = Convert.ToInt32(s.ItemArray[16].ToString()),
                                    EmpName = s.ItemArray[17].ToString(),
                                    NominalCode = s.ItemArray[19].ToString(),
                                    FirstDespatch = s.ItemArray[21].ToString() != null && s.ItemArray[21].ToString() != "" ? s.ItemArray[21].ToString() : "",
                                    CourrierRef = s.ItemArray[22].ToString(),
                                    TotalPoints = s.ItemArray[24].ToString() != "" ? Convert.ToInt32(s.ItemArray[23].ToString()) : 0,
                                    PointsSpent = s.ItemArray[24].ToString() != "" ? Convert.ToInt32(s.ItemArray[24].ToString()) : 0,
                                    RtnOrdNo = s["RtnOrder"].ToString() != "" ? Convert.ToInt32(s["RtnOrder"].ToString()) : 0,
                                    UCODEID = s["ucodeid"].ToString()
                                }).ToList();

                            }
                            if (ShowOrdersRslt.Any(s => s.RtnOrdNo > 0 || s.NominalCode == "" && s.CustomerRef.ToLower().Contains("private") == false))
                            {
                                ShowOrdersRslt.Where(s => s.RtnOrdNo > 0 || s.NominalCode == "").ToList().ForEach(s => s.OrderType = "Exchange order");
                            }
                            if (ShowOrdersRslt.Any(s => s.CustomerRef.ToLower().Contains("private")))
                            {
                                ShowOrdersRslt.Where(s => s.CustomerRef.ToLower().Contains("private")).ToList().ForEach(s => s.OrderType = "PrivateOrder");
                            }
                            if (ShowOrdersRslt.Any(s => s.RtnOrdNo == 0))
                            {
                                if (OrderType == "SO")
                                {
                                    ShowOrdersRslt.Where(s => s.RtnOrdNo == 0 && s.NominalCode != "").ToList().ForEach(s => s.OrderType = "Rollout order");
                                }
                                else if (OrderType == "RT")
                                {
                                    ShowOrdersRslt.Where(s => s.RtnOrdNo == 0).ToList().ForEach(s => s.OrderType = "Return order");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            if (ShowOrdersRslt.Any(s => ucodeLst.Contains(s.UCODEID)))
            {
                ShowOrdersRslt.Where(s => lstRtncredited.Contains(s.OrderNo)).ToList().ForEach(s => s.RtnCredited = true);
                ShowOrdersRslt.Where(s => ucodeLst.Contains(s.UCODEID) && s.IsConfirmed.ToLower().Trim() == "yes").ToList().ForEach(s => s.ShowRtnCredited = true);
            }
            return ShowOrdersRslt;
        }

        #endregion
        #region getshowallordQryEmergency()
        public string getshowallordQryEmergency(string ordertype, List<string> usr, string busId, string role, bool bootpts, string OrderPermission, string user, string RequirePermissionUSR = "")
        {
            string strsql = "";
            int EmployeeRenewDays = 0;
            if (EmployeeRenewDays == 0)
            {
                int value = (Convert.ToInt32(BusinessParam("EmployeeRenew", busId)) / 12);
                EmployeeRenewDays = value * 365;
            }
            strsql = "SELECT h.OrderNo, h.OrderDate, b.Name, h.DelDesc,od.`OrdQty`,rs.`Reasons`, h.DelAddress1, h.OrderGoods, h.TotalGoods, h.OnlineUserID, if(h.OnlineConfirm=0, 'No', 'Yes') as OnlineConfirm, if(h.OnlineProcessed=0, 'No', 'Yes') as OnlineProcessed,  h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno, IF(ISNULL( m.ManPackNo),0, m.ManPackNo),concat(e.Forename,' ',e.Surname) as EmpName, if(ISNULL(h.Comments) or h.Comments='', '~~~', h.Comments) as OrdComments, h.OrderAnalysisCode4 ";
            strsql += ",ci.DespatchDate, ci.CourierRef,tnet.dweek,tnet1.dday ,H.UCODEID ";
            //added by sasi (18-01-21)
            strsql += ",MAX(IF(ISNULL(od.`ReturnOrderNo`),0,od.`ReturnOrderNo`)) RtnOrder ";
            //
            strsql += "from tblsop_salesorder_header h LEFT JOIN  `tblsop_salesorder_detail` od ON h.`OrderNo`=od.`OrderNo` AND h.`CompanyID`= od.`CompanyID` LEFT JOIN `tblsop_reasons` rs ON rs.`ID`=h.`ReasonCode` LEFT JOIN tblbus_business b ON h.CustID = b.BusinessID  AND h.companyid = b.companyid LEFT JOIN tblsop_manpackorders m ON h.CompanyID = m.CompanyID AND h.OrderNo = m.OrderNo LEFT JOIN tblaccemp_employee e ON h.CompanyID = e.CompanyID AND h.CustID = e.BusinessID AND h.Pinno = e.EmployeeID LEFT JOIN tblbus_address ba ON(h.`DelDesc` = ba.`Description`) AND (h.`CustID`= ba.BusinessID) AND(h.`Companyid` = ba.`CompanyID`)  LEFT JOIN (SELECT ContactId, IF(ISNULL(`Value`), 0,`Value`) AS Dweek FROM `tblbus_contact` WHERE contacttype_id = 19)  tnet ON tnet.contactid = ba.`ContactID`  LEFT JOIN (SELECT ContactId, (CASE WHEN ISNULL(`value`)THEN '' WHEN `VALUE` = 1 THEN 'Monday'  WHEN `VALUE` = 2 THEN 'Tuesday' WHEN `VALUE` = 3 THEN 'Wednesday' WHEN `VALUE` = 4 THEN 'Thursday' WHEN `VALUE` = 5 THEN 'Friday' END)  AS Dday FROM `tblbus_contact` WHERE contacttype_id = 17)  tnet1 ON tnet1.contactid = ba.`ContactID` LEFT JOIN ( SELECT CompanyID,CustID,OrderNo,GROUP_CONCAT(Date_Format(DespatchDate,'%d-%m-%Y')) DespatchDate,GROUP_CONCAT(CourierRef) CourierRef FROM tblsop_courier_information GROUP BY orderno ) ci  ON h.`CompanyID` = ci.`CompanyID` AND  h.`OrderNo` = ci.`OrderNo`  AND h.`CustID` = ci.CustID ";

            strsql += " WHERE h.CompanyID='" + cmpId + "' AND h.CustID='" + busId + "' AND h.`ReasonCode`>0 AND (h.`OrderAnalysisCode4` IS NULL OR h.`OrderAnalysisCode4` = '')  AND h.CustRef not like '%private%'";
            strsql += " AND h.OrderType='" + ordertype + "' ";

            if (role.ToLower() != "admin")
            {
                if (RequirePermissionUSR != "" && RequirePermissionUSR.ToLower() == "show")
                {
                    string usrlst = "";
                    usrlst = getPermissionUsers(OrderPermission, user, busId, role);
                    strsql += " AND (h.OnlineUserID IN (SELECT DISTINCT EmployeeID FROM tblonline_userid_employee WHERE OnlineUserID IN (" + usrlst + "))   OR h.OnlineUserID IN (" + usrlst + "))  AND h.OnlineUserID NOT IN (" + getDenyPermissionUsers(OrderPermission, user, busId) + ") ";
                }
            }

            strsql += "GROUP BY h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1, h.OrderGoods, h.OnlineUserID, OnlineConfirm, OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.OrderAnalysisCode4, h.Pinno, m.ManPackNo, e.forename, e.surname ORDER BY h.OrderNo DESC ";
            return strsql;
        }
        #endregion

        #region getshowallordQry()
        public string getshowallordQry(string OrderType, List<string> usr, string busId, string role, bool bootpts, string OrderPermission, string user, bool booIsConfirm = false, string RequirePermissionUSR = "")
        {
            string strsql = "";
            int EmployeeRenewDays = 0;
            if (EmployeeRenewDays == 0)
            {
                int value = (Convert.ToInt32(BusinessParam("EmployeeRenew", busId)) / 12);
                EmployeeRenewDays = value * 365;
            }


            //strsql = "SELECT h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1,  nt1.tot TotQty, h.OrderGoods, h.TotalGoods, h.OnlineUserID, if(h.OnlineConfirm=0, 'No', 'Yes') as OnlineConfirm, if(h.OnlineProcessed=0, 'No', 'Yes') as OnlineProcessed,  h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno,IF(ISNULL( m.ManPackNo),0, m.ManPackNo),concat(e.Forename,' ',e.Surname) as EmpName, if(ISNULL(h.Comments) or h.Comments='', '~~~', h.Comments) as OrdComments, h.OrderAnalysisCode4 ";
            //strsql += ", nt1.sop ";
            //strsql += ",ci.FirstDespatch, ci.CourierRef ";
            strsql = "SELECT h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1,IF(isnull(SUM(d.OrdQty)),0,SUM(d.OrdQty)) AS TotQty, h.OrderGoods, h.TotalGoods, h.OnlineUserID, IF(h.OnlineConfirm = 0, 'No', 'Yes') AS OnlineConfirm, IF(h.OnlineProcessed = 0, 'No', 'Yes') AS OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno, IF(ISNULL(m.ManPackNo), 0, m.ManPackNo), CONCAT(e.Forename, ' ', e.Surname) AS EmpName, IF( ISNULL(h.Comments) OR h.Comments = '', '~~~', h.Comments ) AS OrdComments, h.OrderAnalysisCode4, IF(isnull(MAX(d.sopdetail5)),0,MAX(d.sopdetail5)) AS sop,  IF(isnull(ci.DespatchDate),'',ci.DespatchDate), IF(isnull(ci.CourierRef),'',ci.CourierRef)";
            if (bootpts)
            {
                //strsql += ", ucp.TotalPoints, nt1.pts AS OrderPoints ";
                strsql += ", ucp.TotalPoints, SUM(d.`OrdQty` * t2.`Points`) OrderPoints";
            }
            else
            {
                strsql += ", 0 AS TotalPoints, 0 AS OrderPoints ";
            }
            if (booIsConfirm)
            {
                strsql += ",tnet.dweek,tnet1.dday ";
            }
            //Added by sasi(30-11-20)
            strsql += ",MAX(IF(ISNULL(d.`ReturnOrderNo`),0,d.`ReturnOrderNo`)) RtnOrder, h.`UCodeId` ucodeid ";
            strsql += "from tblsop_salesorder_header h LEFT JOIN tblsop_salesorder_detail d ON h.`CompanyID` = d.`CompanyID` AND h.`OrderNo` = d.`OrderNo` LEFT JOIN `tblaccemp_stylepoints` t2 ON d.`StyleID` = t2.`StyleID` AND d.`CompanyID` = t2.`CompanyID` AND d.`ColourID` = t2.`ColourID` AND h.`UCodeId` = t2.`UcodeID` AND h.`CustID` = t2.`BusinessID` LEFT JOIN tblbus_business b ON h.CustID = b.BusinessID AND h.companyid = b.companyid LEFT JOIN tblsop_manpackorders m ON h.CompanyID = m.CompanyID AND h.OrderNo = m.OrderNo";
            //strsql += "FROM (tblsop_salesorder_header h  JOIN (SELECT MAX(t1.sopdetail5) sop,t1.`CompanyID`,t2.`UcodeID`,t1.orderno,SUM(t1.ordqty) tot, t2.`BusinessID`,SUM(t1.`OrdQty`*t2.`Points`) pts,MAX(IF (ISNULL(t1.`ReturnOrderNo`),0,t1.`ReturnOrderNo`)) AS RtnOrder FROM `tblsop_salesorder_detail` t1 LEFT JOIN `tblaccemp_stylepoints` t2 ON t1.`StyleID`= t2.`StyleID` AND t1.`CompanyID`= t2.`CompanyID` AND t1.`ColourID`= t2.`ColourID`  GROUP BY t1.`OrderNo`,t2.`UcodeID`)  nt1 ON h.`UCodeId`= nt1.ucodeid AND h.`CustID`= nt1.businessid AND h.`OrderNo` = nt1.orderno ) LEFT JOIN tblbus_business b ON h.CustID = b.BusinessID AND h.companyid=b.companyid ";
            //strsql += "LEFT JOIN tblsop_manpackorders m ON h.CompanyID=m.CompanyID AND h.OrderNo=m.OrderNo ";

            if (booIsConfirm)
            {
                //strsql += " LEFT JOIN tblaccemp_employee e ON h.CompanyID=e.CompanyID AND h.CustID=e.BusinessID AND h.Pinno=e.EmployeeID LEFT JOIN tblbus_address ba ON (h.`DelDesc` = ba.`Description`) AND (h.`CustID`= ba.BusinessID) AND(h.`Companyid` = ba.`CompanyID`)   LEFT JOIN (SELECT ContactId, IF(ISNULL(`Value`), 0,`Value`) AS Dweek FROM `tblbus_contact` WHERE contacttype_id = 19)  tnet ON tnet.contactid = ba.`ContactID`  LEFT JOIN (SELECT ContactId, (CASE WHEN ISNULL(`value`)THEN '' WHEN `VALUE` = 1 THEN 'Monday' WHEN `VALUE` = 2 THEN 'Tuesday' WHEN `VALUE` = 3 THEN 'Wednesday'  WHEN `VALUE` = 4 THEN 'Thursday' WHEN `VALUE` = 5 THEN 'Friday' END)  AS Dday FROM `tblbus_contact` WHERE contacttype_id = 17)  tnet1 ON tnet1.contactid = ba.`ContactID` ";
                strsql += " LEFT JOIN tblaccemp_employee e ON h.CompanyID = e.CompanyID AND h.CustID = e.BusinessID AND h.Pinno = e.EmployeeID LEFT JOIN tblbus_address ba ON(h.`DelDesc` = ba.`Description`) AND(h.`CustID` = ba.BusinessID) AND(h.`Companyid` = ba.`CompanyID`) LEFT JOIN (SELECT ContactId, IF(ISNULL(`Value`), 0, `Value`) AS Dweek FROM `tblbus_contact` WHERE contacttype_id = 19) tnet ON tnet.contactid = ba.`ContactID` LEFT JOIN (SELECT ContactId, ( CASE WHEN ISNULL(`value`) THEN '' WHEN `VALUE` = 1 THEN 'Monday' WHEN `VALUE` = 2 THEN 'Tuesday' WHEN `VALUE` = 3 THEN 'Wednesday' WHEN `VALUE` = 4 THEN 'Thursday' WHEN `VALUE` = 5 THEN 'Friday' END ) AS Dday FROM `tblbus_contact` WHERE contacttype_id = 17) tnet1 ON tnet1.contactid = ba.`ContactID`";
            }
            else
            {
                strsql += " LEFT JOIN tblaccemp_employee e ON h.CompanyID=e.CompanyID AND h.CustID=e.BusinessID AND h.Pinno=e.EmployeeID LEFT JOIN tblonline_emp_address ea ON (e.EmployeeID = ea.EmployeeID) AND (e.`BusinessID` = ea.EmployeeID) AND (e.`CompanyID` = ea.`Companyid`)  LEFT JOIN tblbus_address ba ON (ea.AddressID = ba.AddressID) AND (ea.BusinessID = ba.BusinessID) AND (ea.`Companyid` = ba.`CompanyID`) ";
            }
            //strsql += " LEFT JOIN (SELECT CompanyId, OrderNo,CustID, MIN(DespatchDate) AS FirstDespatch, MIN(CourierRef) AS CourierRef FROM `tblsop_courier_information` GROUP BY CompanyId,OrderNo,CustID) ci ON h.`CompanyID` = ci.`CompanyID` AND h.`OrderNo` = ci.`OrderNo` AND h.`CustID` = ci.CustID ";
            strsql += "LEFT JOIN ( SELECT CompanyID,CustID,OrderNo,GROUP_CONCAT(Date_Format(DespatchDate,'%d-%m-%Y')) DespatchDate,GROUP_CONCAT(CourierRef) CourierRef FROM tblsop_courier_information GROUP BY orderno ) ci ON h.`CompanyID` = ci.`CompanyID` AND h.`OrderNo` = ci.`OrderNo` AND h.`CustID` = ci.CustID";
            if (bootpts)
            {

                // strsql = strsql + "LEFT JOIN tblaccemp_ucodepoints ucp ON h.CompanyID=ucp.CompanyID AND h.CustID=ucp.BusinessID AND h.UcodeID=ucp.UcodeID";
                strsql = strsql + " LEFT JOIN tblaccemp_ucodepoints ucp ON h.CompanyID = ucp.CompanyID AND h.CustID = ucp.BusinessID AND h.UcodeID = ucp.UcodeID";
            }

            strsql += " WHERE h.CompanyID='" + cmpId + "' AND h.CustID='" + busId + "' and h.reasoncode=0  ";
            strsql += " AND h.OrderType='" + OrderType + "' ";

            if (role.ToLower() != "admin")
            {
                if (RequirePermissionUSR != "" && RequirePermissionUSR.ToLower() == "show")
                {
                    string usrlst = "";
                    usrlst = getPermissionUsers(OrderPermission, user, busId, role);
                    strsql += " AND (h.OnlineUserID IN (SELECT DISTINCT EmployeeID FROM tblonline_userid_employee WHERE OnlineUserID IN (" + usrlst + "))   OR h.OnlineUserID IN (" + usrlst + "))  AND h.OnlineUserID NOT IN (" + getDenyPermissionUsers(OrderPermission, user, busId) + ") ";
                }
            }
            if (booIsConfirm)
            {
                strsql += " AND h.`OnlineConfirm`=0 AND h.`OnlineProcessed` =0 ";
            }
            //strsql += "GROUP BY h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1, h.OrderGoods, h.OnlineUserID, OnlineConfirm, OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.OrderAnalysisCode4, h.Pinno, m.ManPackNo, e.forename, e.surname ORDER BY h.OrderNo DESC ";
            strsql += "GROUP BY h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1, h.OrderGoods, h.TotalGoods, h.OnlineUserID, OnlineConfirm, OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno, EmpName, OrdComments, h.OrderAnalysisCode4, ucp.TotalPoints";
            if (booIsConfirm)
            {
                strsql += ", tnet.dweek, tnet1.dday";
            }
            strsql += " ORDER BY h.OrderNo DESC";

            return strsql;
        }
        #endregion

        #region GetUserLst

        public List<ImpExpUsers> GetUserLst(string busId)
        {
            string sQry = "";
            List<ImpExpUsers> usrLst = new List<ImpExpUsers>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                sQry = "SELECT  tu.`UserName` UserName, tu.`ForeName` ForeName, tu.`SurName` SurName, tu.`AccessID` AccessID, tu.`Active` Active, tu.`BusinessID` BusinessID, tu.`Email_ID` Email_ID, onu.`ONLINEUSERID` mapTo FROM `tblusers` tu LEFT JOIN (SELECT COMPANYID, BUSINESSID, GROUP_CONCAT(allowuser SEPARATOR ';')  ONLINEUSERID, userid  FROM `tblpermission_users_allow`   GROUP BY userid) onu ON tu.`UserName` = onu.`userid`  AND tu.`BusinessID` = onu.`BusinessID` WHERE tu.`BusinessID` = '" + busId + "' ORDER BY TU.CREATEDATE DESC ";
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    usrLst = dt.AsEnumerable().Select(s => new ImpExpUsers
                    {
                        AccessRole = s.ItemArray[3].ToString(),
                        Active = s.ItemArray[4].ToString() == "Y" ? true : false,
                        Active1 = s.ItemArray[4].ToString(),
                        Email = s.ItemArray[6].ToString(),
                        ForeName = s.ItemArray[1].ToString(),
                        MapTo = s.ItemArray[7].ToString(),
                        RolloutName = "",
                        SurName = s.ItemArray[2].ToString(),
                        UserName = s.ItemArray[0].ToString(),
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return usrLst;
        }
        #endregion

        #region GetEmployeeLST
        public List<EmployeeImportModel> GetEmployeeLst(string busId)
        {
            string sQry = "";
            List<EmployeeImportModel> empLst = new List<EmployeeImportModel>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                sQry = " SELECT t1.employeeid,t1.forename,t1.surname,t1.title,t1.startdate,t1.enddate,GROUP_CONCAT(DISTINCT  t3.ucodeid SEPARATOR ';') ucodeid,T5.`Description` MAPTOADDR,GROUP_CONCAT(DISTINCT   t2.onlineuserid SEPARATOR ';')  mapto FROM `tblaccemp_employee` t1 JOIN  `tblonline_userid_employee` t2 ON t1.`BusinessID`= t2.`BusinessID` AND t1.`EmployeeID`= t2.`EmployeeID` JOIN `tblaccemp_ucodesemployees` t3 ON t1.`BusinessID`= t3.`BusinessID`  AND t1.`EmployeeID`= t3.`EmployeeID`  JOIN `tblonline_emp_address` t4 ON t1.`EmployeeID`= t4.`Employeeid` AND t1.`BusinessID`= t4.`BusinessId` JOIN `tblbus_address` t5 ON t4.`AddressId`= t5.`AddressID` AND t5.`BusinessID`= t4.`BusinessId` where t1.businessid='" + busId + "' AND t1.`EmployeeClosed`=0 GROUP BY t1.`EmployeeID` ";
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    empLst = dt.AsEnumerable().Select(s => new EmployeeImportModel
                    {
                        EMPLOYEEID = s["employeeid"].ToString(),
                        FORENAME = s["forename"].ToString(),
                        SURNAME = s["surname"].ToString(),
                        TITLE = s["title"].ToString(),
                        STARTDATE = s["startdate"].ToString() != "" ? DateTime.Parse(s["startdate"].ToString()).ToString("dd-MM-yyyy") : "",
                        ENDDATE = s["enddate"].ToString() != "" ? DateTime.Parse(s["enddate"].ToString()).ToString("dd-MM-yyyy") : "",
                        UCODE = s["ucodeid"].ToString(),
                        MAPTO = s["mapto"].ToString(),
                       
                        MAPTOADDR = s["MAPTOADDR"].ToString(),
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return empLst;
        }

        #endregion

        #region GetAddressLst

        public List<AddressImportModel> GetAddressLst(string busId)
        {
            string sQry = "";
            List<AddressImportModel> addrLst = new List<AddressImportModel>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {

                conn.Open();
                sQry = "SELECT  t1.companyid,t1.`addressid`, t1.businessid, t1.address1, t1.address2, t1.address3, t1.description,  t1.town, t1.city, t1.postcode, t1.`countrycode`, t4.country, t1.`contactid`, GROUP_CONCAT(DISTINCT t13.value1 SEPARATOR ';') phone, GROUP_CONCAT(DISTINCT t14.value1 SEPARATOR ';') email, GROUP_CONCAT(DISTINCT t15.value1 SEPARATOR ';') cntname,GROUP_CONCAT(DISTINCT t17.value1 SEPARATOR ';') cc, GROUP_CONCAT(DISTINCT t2.`OnlineUserId` SEPARATOR ';') mapto FROM `tblbus_address` T1 LEFT JOIN `tblonline_emp_address` t2 ON t1.`AddressID` = t2.`AddressId`  AND t1.`BusinessID` = t2.`BusinessId`  JOIN `tblbus_contact` t3 ON t1.`ContactID`= t3.`ContactID`  LEFT JOIN (SELECT contactid, contacttype_id, GROUP_CONCAT(VALUE SEPARATOR ';')VALUE1 FROM `tblbus_contact` WHERE contacttype_id = 1  GROUP BY contactid, contacttype_id) t13 ON t3.`ContactID` = t13.`ContactID` LEFT JOIN (SELECT contactid, contacttype_id, GROUP_CONCAT(VALUE SEPARATOR ';')VALUE1 FROM `tblbus_contact` WHERE contacttype_id = 3 GROUP BY contactid, contacttype_id) t14 ON t3.`ContactID`= t14.`ContactID`  LEFT JOIN (SELECT contactid, contacttype_id, GROUP_CONCAT(VALUE SEPARATOR ';')VALUE1 FROM `tblbus_contact` WHERE contacttype_id = 6 GROUP BY contactid, contacttype_id) t15 ON t3.`ContactID`= t15.`ContactID`   LEFT JOIN  (SELECT contactid, contacttype_id, GROUP_CONCAT(VALUE SEPARATOR ';') VALUE1  FROM `tblbus_contact`  WHERE contacttype_id = 7 GROUP BY contactid, contacttype_id) t17 ON t3.`ContactID` = t17.`ContactID` JOIN `tblbus_countrycodes` t4 ON t1.`CountryCode` = t4.`CountryID`  WHERE t1.businessid = '" + busId + "' GROUP BY t1.companyid,  t1.businessid, t1.address1,  t1.address2, t1.address3, t1.description, t1.`contactid`";
                MySqlCommand cmd = new MySqlCommand(sQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    addrLst = dt.AsEnumerable().Select(s => new AddressImportModel
                    {
                        COMPANYID = s["companyid"].ToString(),
                        ADDRESSID = s["addressid"].ToString() != "" ? Convert.ToInt32(s["addressid"].ToString()) : 0,
                        BUSINESSID = s["businessid"].ToString(),
                        ADDRESS1 = s["address1"].ToString(),
                        ADDRESS2 = s["address2"].ToString(),
                        ADDRESS3 = s["address3"].ToString(),
                        DESCRIPTION = s["description"].ToString(),
                        TOWN = s["town"].ToString(),
                        CITYCOUNTY = s["city"].ToString(),
                        POSTCODE = s["postcode"].ToString(),
                        COUNTRYID = s["countrycode"].ToString(),
                        COUNTRY = s["country"].ToString(),
                        CONTACTNAME = s["cntname"].ToString(),
                        TELEPHONE = s["phone"].ToString(),
                        EMAIL = s["email"].ToString(),
                        CONTACTID = s["contactid"].ToString() == "" ? 0 : Convert.ToInt64(s["contactid"].ToString()),
                        MAPTO = s["mapto"].ToString(),
                        COSTCENTER = s["cc"].ToString(),
                    }).ToList();
                }


            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return addrLst;
        }
        #endregion
        public string empMethod(bool points, string role, string busId, string userID, string orderPermission)
        {

            string strsql = "";
            strsql = "SELECT e.employeeid, concat(e.forename,' ',e.surname) as employeename,e.EmployeeClosed AS STATUS ";
            if (points)
            {
                strsql = strsql + ",Tpts.TotalUodePoints as EntPoints,p.CurrPoints ";
            }
            strsql = strsql + ", e.departmentid FROM tblaccemp_employee e ";

            if (points)
            {
                strsql = strsql + "LEFT JOIN (SELECT t1.`CompanyID`, t1.`BusinessID`, t1.`EmployeeID`, (IF(ISNULL(t3.TotalPoints),IF(ISNULL(t2.`TotalPoints`),0,t2.`TotalPoints`),t3.TotalPoints)) As TotalUodePoints  FROM `tblaccemp_ucodesemployees` t1  LEFT JOIN tblaccemp_rollout_ucode_ref tf ON t1.CompanyID=tf.CompanyID AND t1.BusinessID=tf.BusinessID AND t1.UcodeID=tf.EmpUCodeID  LEFT JOIN `tblaccemp_ucodepoints` t2 ON t1.`CompanyID` = t2.`CompanyID` AND t1.`BusinessID` = t2.`BusinessID` AND t1.`UCodeID` = t2.`UcodeID` AND NOW() BETWEEN t2.`FromDate` AND t2.`ToDate`  LEFT JOIN `tblaccemp_ucodepoints` t3 ON tf.`CompanyID` = t3.`CompanyID` AND tf.`BusinessID` = t3.`BusinessID` AND tf.`ROUCodeID` = t3.`UcodeID` AND NOW() BETWEEN t3.`FromDate` AND t3.`ToDate`  WHERE t1.CompanyID='{0}' AND t1.BusinessID='{1}'  GROUP BY t1.`CompanyID`, t1.`BusinessID`, t1.`EmployeeID`) Tpts  ON Tpts.CompanyID=e.CompanyID AND Tpts.BusinessID=e.BusinessID AND Tpts.EmployeeID=e.EmployeeID  LEFT JOIN (SELECT CompanyID,BusinessID,employeeid,SUM((IF(ISNULL(SOPoints), 0, SOPoints)) + IF(ISNULL(PickPoints), 0, PickPoints) + IF(ISNULL(InvPoints), 0, InvPoints)) AS CurrPoints  FROM tblaccemp_pointscard WHERE CompanyID='{0}' AND BusinessID='{1}' AND `Year` IN (0,99) GROUP BY CompanyID,BusinessID,EmployeeID) p  ON e.employeeid = p.employeeid AND e.CompanyID = p.CompanyID AND e.`BusinessID` = p.BusinessID ";
            }
            if (role != "Admin")
            {
                if (Convert.ToBoolean(BusinessParam("LimitUsrEmp", busId)))
                {

                    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblonline_userid_employee WHERE CompanyID='{0}' AND onlineuserid in (" + getPermissionUsers(orderPermission, userID, busId, role) + ") AND onlineuserid not in (" + getDenyPermissionUsers(orderPermission, userID, busId) + ") AND businessid='{1}') onlemp ON e.employeeid=onlemp.employeeid ";
                }
            }

            strsql += " WHERE e.companyid='{0}' AND  e.businessid='{1}'  ORDER BY e.employeeid";
            return strsql;
        }

        #region RolloutReports
        public List<RolloutReportModel> GetRolloutReports(string busId, List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false)
        {
            List<RolloutReportModel> rollReportresult = new List<RolloutReportModel>();
            selRollout = selRollout == null ? new List<string>() : selRollout;
            int mCount = 0;
            //DateTime startdate=DateTime.Now;
            //DateTime endDate = DateTime.Now;

            string cnfOrders = uncnf ? " AND `t2`.OnlineConfirm=0 " : "";
            string sql = "", sqlGrp = "";
            if (reportName == "2")
            {
                string rolloutLst = "";
                rolloutLst = String.Join("','", selRollout);
                sql = "SELECT DISTINCT CONCAT(te.`Forename`, ' ', te.`Surname`) AS EmployeeName,te.`EmployeeID`,er.`RolloutName`,IF(te.`EmployeeClosed`=0,'Yes','No') AS IsActive, GROUP_CONCAT(DISTINCT map.`OnlineUserID`) AS 'OnlineUserID', UPPER(GROUP_CONCAT(DISTINCT usr.`AccessID`)) AS Access";
                if (pointsREq)
                {
                    sql += ",IF(ISNULL(sp.`TotalPoints`),0,sp.`TotalPoints`) totalPoints,tot.pts usedpoints";
                }
                sql += " FROM `tblaccemp_employee_rollout` er JOIN `tblaccemp_employee` te  ON te.`BusinessID`=er.`BusinessID` AND te.`CompanyID`=er.`CompanyID` AND te.`EmployeeID`=er.`EmployeeID`  LEFT JOIN `tblsop_salesorder_header` sh  ON sh.`CompanyID`= er.`CompanyID` AND sh.`PinNo`=er.`EmployeeID` AND sh.`CustID`=er.`BusinessID` ";
                if (pointsREq)
                {
                    sql += " LEFT JOIN `tblaccemp_ucodesemployees` tu ON tu.`BusinessID`= te.`BusinessID` AND tu.`CompanyID`= te.`CompanyID` AND tu.`EmployeeID`= te.`EmployeeID` LEFT JOIN `tblaccemp_ucodepoints` sp ON sp.`BusinessID`= tu.`BusinessID` AND tu.`UcodeID`= sp.`UcodeID` LEFT JOIN (SELECT uip.`CompanyID`, uip.`BusinessID`, uip.`EmployeeID`, uip.`StyleID`, uip.`ColourID`, SUM(uip.`TOTSOPOINTS`) pts FROM (SELECT `tblaccemp_pointscard`.`CompanyID`  AS `CompanyID`, `tblaccemp_pointscard`.`BusinessID` AS `BusinessID`, `tblaccemp_pointscard`.`EmployeeID` AS `EmployeeID`, `tblaccemp_pointscard`.`StyleID`    AS `StyleID`, `tblaccemp_pointscard`.`ColourID`   AS `ColourID`, SUM(IF(ISNULL(`tblaccemp_pointscard`.`SOPoints`), 0,`tblaccemp_pointscard`.`SOPoints`)) AS `TOTSOPOINTS` FROM `tblaccemp_pointscard` WHERE(`tblaccemp_pointscard`.`Year` = 0) GROUP BY `tblaccemp_pointscard`.`BusinessID`,`tblaccemp_pointscard`.`EmployeeID`, `tblaccemp_pointscard`.`StyleID`,`tblaccemp_pointscard`.`ColourID` ) uip GROUP BY uip.`CompanyID`, uip.`BusinessID`, uip.`EmployeeID` )tot ON tot.`EmployeeID`= te.`EmployeeID` AND tot.`CompanyID`=`te`.`EmployeeID` AND tot.`BusinessID`= te.`BusinessID` ";
                }
                sql += "LEFT JOIN `tblonline_userid_employee` map ON te.`BusinessID`= map.`BusinessID` AND te.`CompanyID`=map.`CompanyID` AND te.`EmployeeID`=map.`EmployeeID` AND te.`EmployeeID`=map.`OnlineUserID`  JOIN `tblusers` usr ON map.`BusinessID`=usr.`BusinessID` AND map.`OnlineUserID`=usr.`UserName`  WHERE te.`BusinessID`='" + busId + "' AND er.`PrevOrder` IS NULL AND sh.Orderno  IS NULL ";
                sql = sql + "AND er.`RolloutName` in ('" + rolloutLst + "')";
                if (pointsREq)
                {
                    sql = sql + " AND tu.ucodeid NOT IN ( 'EMERGENCY','BAR MATERNITY','BAR EMERGENCY','BAR MATERNITY F','BAR MATERNITY P','BAR TEMP')  ";
                }
                sql = sql + " GROUP BY te.`EmployeeID` ";

            }
            else
            {
                if (reportTypes == "0")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t2.CustRef,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,t1.FreeText,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t2.CustRef,t1.`StyleID`,t1.FreeText,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                else if (reportTypes == "1")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,t1.FreeText,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t1.`StyleID`,t1.FreeText,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                else if (reportTypes == "2")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t1.`StyleID`,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                else if (reportTypes == "3")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t2.CustRef,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t2.CustRef,t1.`StyleID`,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                else if (reportTypes == "4")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t2.OrderNo,t2.OrderDate AS OrderDate,t2.Pinno AS EmployeeId,CONCAT(ae.`Forename`,' ', ae.`Surname`) AS EmployeeName,t2.CustRef,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,t1.FreeText,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t2.OrderNo,t2.Pinno,EmployeeName,t2.CustRef,t1.`StyleID`,t1.FreeText,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                else if (reportTypes == "5")
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t2.Pinno AS EmployeeId,CONCAT(ae.`Forename`,' ', ae.`Surname`) AS EmployeeName,t2.CustRef,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t2.Pinno,EmployeeName,t2.CustRef";
                }
                else
                {
                    sql = "SELECT t2.`OrderAnalysisCode4` AS RolloutName,t2.CustRef,t1.`StyleID`,t1.Description,IF(ISNULL(CSMA.BaseStyle),IF(ISNULL(ASMA.BaseStyle),t1.StyleID,ASMA.BaseStyle),CSMA.BaseStyle) AS BaseStyleID,IF(ISNULL(CSMA.BaseDesc),IF(ISNULL(ASMA.BaseDesc),t1.Description,ASMA.BaseDesc),CSMA.BaseDesc) AS BaseStyleDesc,t1.`ColourID`,t1.`SizeID`,t1.FreeText,SUM(t1.OrdQty) AS TotQty, CAST(SUM(t1.OrdQty*t1.Price) AS DECIMAL (10, 2)) AS TotValue ";
                    sqlGrp = "RolloutName,t2.CustRef,t1.`StyleID`,t1.FreeText,BaseStyleID,t1.`ColourID`,t1.`SizeID`";
                }
                if (pointsREq)
                {
                    if (reportTypes == "5")
                    {
                        sql = sql + ",ucp.TotalPoints,uip.Issued AS OrderPoints ";
                        sqlGrp += ",TotalPoints,OrderPoints ";
                    }
                    else
                    {
                        sql += ",SUM(uip.points*t1.OrdQty) AS OrderPoints  ";
                    }
                }


                sql = sql + "FROM ( SELECT `CompanyID`,`OrderNo`,`StyleID`,`ColourID`,`SizeID`,`Description`,SUM(`OrdQty`) `OrdQty`,Freetext,Price,`OriginalLineNo`,`AssemblyID` FROM `tblsop_salesorder_detail` GROUP BY `CompanyID`,`OrderNo`,`StyleID`,`ColourID`,`SizeID`) t1 JOIN `tblsop_salesorder_header` t2  ON t1.`CompanyID` = t2.`CompanyID` AND t1.`OrderNo` = t2.`OrderNo`  LEFT JOIN tblaccemp_employee ae ON t2.CompanyID=ae.CompanyID AND t2.CustID=ae.BusinessID AND t2.Pinno=ae.EmployeeID  LEFT JOIN (SELECT AAH.`StyleID` AS ParentStyle,AAD.StyleID AS BaseStyle, AAD.`Description` AS BaseDesc,AAH.`AssemblyID` FROM `tblasm_assemblyheader` AAH   LEFT JOIN `tblasm_assemblydetail` AAD ON AAH.`CompanyID` = AAD.CompanyID AND AAH.`AssemblyID` = AAD.AssemblyID AND AAH.`BaseItemLine` = AAD.LineNo AND AAH.`CustID` = 'ALL') ASMA ON ASMA.ParentStyle = t1.`StyleID` AND ASMA.`AssemblyID` = t1.AssemblyID  LEFT JOIN (SELECT CAH.`CustID`, CAH.`StyleID` AS ParentStyle,CAD.StyleID AS BaseStyle, CAD.`Description` AS BaseDesc, CAH.`AssemblyID` FROM `tblasm_assemblyheader` CAH  LEFT JOIN `tblasm_assemblydetail` CAD ON CAH.`CompanyID` = CAD.CompanyID AND CAH.`AssemblyID` = CAD.AssemblyID AND CAH.`BaseItemLine` = CAD.LineNo AND CAH.`CustID` <> 'ALL') CSMA ON CSMA.ParentStyle = t1.`StyleID` AND CSMA.CustID = t2.`CustID` AND CSMA.`AssemblyID` = t1.AssemblyID ";

                if (pointsREq)
                {
                    sql = sql + "LEFT JOIN tblaccemp_ucodepoints ucp ON t2.CompanyID=ucp.CompanyID AND t2.CustID=ucp.BusinessID AND t2.UcodeID=ucp.UcodeID AND NOW() BETWEEN FromDate AND ToDate ";
                    if (reportTypes == "5")
                    {
                        sql = sql + "LEFT JOIN (SELECT sc.CompanyId,sc.BusinessID,sc.EmployeeID,sp.UcodeID,SUM((IF(ISNULL(sc.`SOQty`),0,sc.`SOQty`) + IF(ISNULL(sc.`PickQty`),0, sc.`PickQty`) + IF(ISNULL(sc.`InvQty`),0,sc.`InvQty`))*IF(ISNULL(sp.`Points`),0,sp.`Points`)) AS Issued  FROM `tblaccemp_stockcard` sc  LEFT JOIN `tblaccemp_stylepoints` sp ON sc.`CompanyID` = sp.`CompanyID` AND sc.`BusinessID` = sp.`BusinessID` AND sc.`StyleID` = sp.`StyleID` AND sc.`ColourID` = sp.`ColourID` AND NOW() BETWEEN FromDate AND ToDate  WHERE sc.CompanyID='" + cmpId + "' AND sc.BusinessID='" + busId + "' GROUP BY sc.CompanyId,sc.BusinessID,sc.EmployeeID,sp.UcodeID) uip  ON t2.CompanyID=uip.CompanyID AND t2.CustID=uip.BusinessID AND t2.Pinno=uip.EmployeeID AND t2.UcodeID=uip.UcodeID ";
                    }
                    else
                    {

                        sql = sql + "LEFT JOIN  `tblaccemp_stylepoints` uip ON uip.`BusinessID`=t2.`CustID` AND uip.`UcodeID`=t2.`UCodeId` AND uip.`StyleID`= t1.styleid AND uip.`ColourID`= t1.colourid ";
                    }
                }
                sql = sql + "WHERE NOT ISNULL(t2.`OrderAnalysisCode4`) AND t2.`OrderAnalysisCode4`<>'' AND t2.`CustID`='" + busId + "' " + cnfOrders;
                string list = "";
                if (selRollout.Count > 0)
                {
                    foreach (var str in selRollout)
                    {
                        list = list + "'" + str + "',";
                        mCount = mCount + 1;
                    }
                    if (list != "")
                    {
                        list = list.TrimEnd(',');
                        sql = sql + "AND t2.`OrderAnalysisCode4`IN (" + list + ") ";
                    }
                }
                if (embro == false)
                {
                    sql = sql + "AND t1.OriginalLineNo=0 ";
                }
                //if (startdate != null)
                //{
                //    sql = sql + "AND t2.`OrderDate`>='" + startdate.ToString("yyyy-MM-dd") + "'";
                //}
                //if(endDate!=null)
                //{
                //    sql = sql + "AND t2.`OrderDate`<='" + endDate.ToString("yyyy-MM-dd") + "'";
                //}
                sql = mCount == 1 ? sql : sql.Replace("t2.`OrderAnalysisCode4` AS RolloutName,", "");
                sqlGrp = mCount == 1 ? sqlGrp : sqlGrp.Replace("RolloutName,", "");
                sql = sql + "GROUP BY " + sqlGrp;
                if (pointsREq)
                {
                    if (reportTypes == "5")
                    {
                        sql = sql + " HAVING ucp.`TotalPoints` < OrderPoints ";
                    }
                }
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (reportName == "1")
                    {
                        if (reportTypes == "1")
                        {
                            if (dt.Columns.Count > 10)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString(),
                                    BaseStyle = s.ItemArray[3].ToString(),
                                    // Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[1].ToString(),
                                    Description = s.ItemArray[2].ToString(),
                                    BaseStyleDesc = s.ItemArray[4].ToString(),
                                    Color = s.ItemArray[5].ToString(),
                                    Size = s.ItemArray[6].ToString(),
                                    Freetext = s.ItemArray[7].ToString(),
                                    TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
                                    TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
                                    OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    BaseStyle = s.ItemArray[2].ToString(),
                                    // Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[0].ToString(),
                                    Description = s.ItemArray[1].ToString(),
                                    BaseStyleDesc = s.ItemArray[3].ToString(),
                                    Color = s.ItemArray[4].ToString(),
                                    Size = s.ItemArray[5].ToString(),
                                    Freetext = s.ItemArray[6].ToString(),
                                    TotQty = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
                                    TotValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
                                    OrdPoints = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }

                        }
                        else if (reportTypes == "2")
                        {
                            if (dt.Columns.Count > 9)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString(),
                                    BaseStyle = s.ItemArray[3].ToString(),
                                    // Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[1].ToString(),
                                    Description = s.ItemArray[2].ToString(),
                                    BaseStyleDesc = s.ItemArray[4].ToString(),
                                    Color = s.ItemArray[5].ToString(),
                                    Size = s.ItemArray[6].ToString(),
                                    // Freetext = s.ItemArray[6].ToString(),
                                    TotQty = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
                                    TotValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
                                    OrdPoints = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    BaseStyle = s.ItemArray[2].ToString(),
                                    // Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[0].ToString(),
                                    Description = s.ItemArray[1].ToString(),
                                    BaseStyleDesc = s.ItemArray[3].ToString(),
                                    Color = s.ItemArray[4].ToString(),
                                    Size = s.ItemArray[5].ToString(),
                                    // Freetext = s.ItemArray[6].ToString(),
                                    TotQty = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? Convert.ToInt32(s.ItemArray[6].ToString()) : 0,
                                    TotValue = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToDouble(s.ItemArray[7].ToString()) : 0,
                                    OrdPoints = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }

                        }
                        else if (reportTypes == "3")
                        {
                            if (dt.Columns.Count > 10)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString(),
                                    BaseStyle = s.ItemArray[4].ToString(),
                                    Custref = s.ItemArray[1].ToString(),
                                    Styleid = s.ItemArray[2].ToString(),
                                    Description = s.ItemArray[3].ToString(),
                                    BaseStyleDesc = s.ItemArray[5].ToString(),
                                    Color = s.ItemArray[6].ToString(),
                                    Size = s.ItemArray[7].ToString(),
                                    //Freetext = s.ItemArray[7].ToString(),
                                    TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
                                    TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
                                    OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    BaseStyle = s.ItemArray[3].ToString(),
                                    Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[1].ToString(),
                                    Description = s.ItemArray[2].ToString(),
                                    BaseStyleDesc = s.ItemArray[4].ToString(),
                                    Color = s.ItemArray[5].ToString(),
                                    Size = s.ItemArray[6].ToString(),
                                    //Freetext = s.ItemArray[7].ToString(),
                                    TotQty = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
                                    TotValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
                                    OrdPoints = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }

                        }
                        else if (reportTypes == "4")
                        {
                            if (dt.Columns.Count > 15)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString(),
                                    OrderNo = s.ItemArray[1].ToString() != null ? Convert.ToInt32(s.ItemArray[1].ToString()) : 0,
                                    OrderDate = s.ItemArray[2].ToString() != null ? DateTime.Parse(s.ItemArray[2].ToString()).ToString("dd-MM-yyyy") : "",
                                    Employeeid = s.ItemArray[3].ToString() != null ? s.ItemArray[3].ToString() : "",
                                    EmployeeName = s.ItemArray[4].ToString() != null ? s.ItemArray[4].ToString() : "",
                                    BaseStyle = s.ItemArray[8].ToString(),
                                    Custref = s.ItemArray[5].ToString(),
                                    Styleid = s.ItemArray[6].ToString(),
                                    Description = s.ItemArray[7].ToString(),
                                    BaseStyleDesc = s.ItemArray[9].ToString(),
                                    Color = s.ItemArray[10].ToString(),
                                    Size = s.ItemArray[11].ToString(),
                                    Freetext = s.ItemArray[12].ToString(),
                                    TotQty = s.ItemArray[13].ToString() != null && s.ItemArray[13].ToString() != "" ? Convert.ToInt32(s.ItemArray[13].ToString()) : 0,
                                    TotValue = s.ItemArray[14].ToString() != null && s.ItemArray[14].ToString() != "" ? Convert.ToDouble(s.ItemArray[14].ToString()) : 0,
                                    OrdPoints = s.ItemArray[15].ToString() != null && s.ItemArray[15].ToString() != "" ? Convert.ToInt32(s.ItemArray[15].ToString()) : 0,
                                }).OrderBy(s => s.EmployeeName).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    OrderNo = s.ItemArray[0].ToString() != null ? Convert.ToInt32(s.ItemArray[0].ToString()) : 0,
                                    OrderDate = s.ItemArray[1].ToString() != null ? DateTime.Parse(s.ItemArray[1].ToString()).ToString("dd-MM-yyyy") : "",
                                    Employeeid = s.ItemArray[2].ToString() != null ? s.ItemArray[2].ToString() : "",
                                    EmployeeName = s.ItemArray[3].ToString() != null ? s.ItemArray[3].ToString() : "",
                                    BaseStyle = s.ItemArray[7].ToString(),
                                    Custref = s.ItemArray[4].ToString(),
                                    Styleid = s.ItemArray[5].ToString(),
                                    Description = s.ItemArray[6].ToString(),
                                    BaseStyleDesc = s.ItemArray[8].ToString(),
                                    Color = s.ItemArray[9].ToString(),
                                    Size = s.ItemArray[10].ToString(),
                                    Freetext = s.ItemArray[11].ToString(),
                                    TotQty = s.ItemArray[12].ToString() != null && s.ItemArray[12].ToString() != "" ? Convert.ToInt32(s.ItemArray[12].ToString()) : 0,
                                    TotValue = s.ItemArray[13].ToString() != null && s.ItemArray[13].ToString() != "" ? Convert.ToDouble(s.ItemArray[13].ToString()) : 0,
                                    OrdPoints = s.ItemArray[14].ToString() != null && s.ItemArray[14].ToString() != "" ? Convert.ToInt32(s.ItemArray[14].ToString()) : 0,
                                }).OrderBy(s => s.EmployeeName).ToList();
                            }


                        }
                        else if (reportTypes == "5")
                        {
                            if (dt.Columns.Count > 7)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString() != null ? s.ItemArray[0].ToString() : "",
                                    Employeeid = s.ItemArray[1].ToString() != null ? s.ItemArray[1].ToString() : "",
                                    EmployeeName = s.ItemArray[2].ToString() != null ? s.ItemArray[2].ToString() : "",
                                    Custref = s.ItemArray[3].ToString(),
                                    TotQty = s.ItemArray[4].ToString() != null && s.ItemArray[4].ToString() != "" ? Convert.ToInt32(s.ItemArray[4].ToString()) : 0,
                                    TotValue = s.ItemArray[5].ToString() != null && s.ItemArray[5].ToString() != "" ? Convert.ToDouble(s.ItemArray[5].ToString()) : 0,
                                    TotPts = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? Convert.ToInt32(s.ItemArray[6].ToString()) : 0,
                                    OrdPoints = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
                                }).OrderBy(s => s.EmployeeName).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {

                                    Employeeid = s.ItemArray[0].ToString() != null ? s.ItemArray[0].ToString() : "",
                                    EmployeeName = s.ItemArray[1].ToString() != null ? s.ItemArray[1].ToString() : "",
                                    Custref = s.ItemArray[2].ToString(),
                                    TotQty = s.ItemArray[3].ToString() != null && s.ItemArray[3].ToString() != "" ? Convert.ToInt32(s.ItemArray[3].ToString()) : 0,
                                    TotValue = s.ItemArray[4].ToString() != null && s.ItemArray[4].ToString() != "" ? Convert.ToDouble(s.ItemArray[4].ToString()) : 0,
                                    TotPts = s.ItemArray[5].ToString() != null && s.ItemArray[5].ToString() != "" ? Convert.ToInt32(s.ItemArray[5].ToString()) : 0,
                                    OrdPoints = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? Convert.ToInt32(s.ItemArray[6].ToString()) : 0,
                                }).OrderBy(s => s.EmployeeName).ToList();
                            }

                        }
                        else if (reportTypes == "0")
                        {
                            if (dt.Columns.Count > 11)
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    RolloutName = s.ItemArray[0].ToString(),
                                    BaseStyle = s.ItemArray[4].ToString(),
                                    Custref = s.ItemArray[1].ToString(),
                                    Styleid = s.ItemArray[2].ToString(),
                                    Description = s.ItemArray[3].ToString(),
                                    BaseStyleDesc = s.ItemArray[5].ToString(),
                                    Color = s.ItemArray[6].ToString(),
                                    Size = s.ItemArray[7].ToString(),
                                    Freetext = s.ItemArray[8].ToString(),
                                    TotQty = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
                                    TotValue = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToDouble(s.ItemArray[10].ToString()) : 0,
                                    OrdPoints = s.ItemArray[11].ToString() != null && s.ItemArray[11].ToString() != "" ? Convert.ToInt32(s.ItemArray[11].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }
                            else
                            {
                                rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                                {
                                    BaseStyle = s.ItemArray[3].ToString(),
                                    Custref = s.ItemArray[0].ToString(),
                                    Styleid = s.ItemArray[1].ToString(),
                                    Description = s.ItemArray[2].ToString(),
                                    BaseStyleDesc = s.ItemArray[4].ToString(),
                                    Color = s.ItemArray[5].ToString(),
                                    Size = s.ItemArray[6].ToString(),
                                    Freetext = s.ItemArray[7].ToString(),
                                    TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
                                    TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
                                    OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
                                }).OrderBy(s => s.Styleid).ToList();
                            }

                        }
                        else
                        {
                            rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                            {
                                BaseStyle = s.ItemArray[3].ToString(),
                                Custref = s.ItemArray[0].ToString(),
                                Styleid = s.ItemArray[1].ToString(),
                                Description = s.ItemArray[2].ToString(),
                                BaseStyleDesc = s.ItemArray[4].ToString(),
                                Color = s.ItemArray[5].ToString(),
                                Size = s.ItemArray[6].ToString(),
                                Freetext = s.ItemArray[7].ToString(),
                                TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
                                TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
                                OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
                            }).OrderBy(s => s.Styleid).ToList();
                        }

                    }
                    else
                    {
                        rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
                        {
                            EmployeeName = s.ItemArray[0].ToString(),
                            Employeeid = s.ItemArray[1].ToString(),
                            RolloutName = s.ItemArray[2].ToString(),
                            IsActive = s.ItemArray[3].ToString(),
                            OnlineUserId = s.ItemArray[4].ToString(),
                            Access = s.ItemArray[5].ToString(),
                            UsedPoints = s["usedpoints"].ToString() == "" ? 0 : Convert.ToInt32(s["usedpoints"].ToString()),
                            TotPts = s["totalPoints"].ToString() == "" ? 0 : Convert.ToInt32(s["totalPoints"].ToString()),

                        }).OrderBy(s => s.EmployeeName).ToList();
                    }
                }

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }


            //if (reportTypes == "1")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        BaseStyle = s.ItemArray[2].ToString(),
            //        // Custref = s.ItemArray[0].ToString(),
            //        Styleid = s.ItemArray[0].ToString(),
            //        Description = s.ItemArray[1].ToString(),
            //        BaseStyleDesc = s.ItemArray[3].ToString(),
            //        Color = s.ItemArray[4].ToString(),
            //        Size = s.ItemArray[5].ToString(),
            //        Freetext = s.ItemArray[6].ToString(),
            //        TotQty = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
            //        TotValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
            //        OrdPoints = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
            //    }).ToList();
            //}
            //else if (reportTypes == "2")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        BaseStyle = s.ItemArray[2].ToString(),
            //        // Custref = s.ItemArray[0].ToString(),
            //        Styleid = s.ItemArray[0].ToString(),
            //        Description = s.ItemArray[1].ToString(),
            //        BaseStyleDesc = s.ItemArray[3].ToString(),
            //        Color = s.ItemArray[4].ToString(),
            //        Size = s.ItemArray[5].ToString(),
            //        // Freetext = s.ItemArray[6].ToString(),
            //        TotQty = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? Convert.ToInt32(s.ItemArray[6].ToString()) : 0,
            //        TotValue = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToDouble(s.ItemArray[7].ToString()) : 0,
            //        OrdPoints = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
            //    }).ToList();
            //}
            //else if (reportTypes == "3")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        BaseStyle = s.ItemArray[3].ToString(),
            //        Custref = s.ItemArray[0].ToString(),
            //        Styleid = s.ItemArray[1].ToString(),
            //        Description = s.ItemArray[2].ToString(),
            //        BaseStyleDesc = s.ItemArray[4].ToString(),
            //        Color = s.ItemArray[5].ToString(),
            //        Size = s.ItemArray[6].ToString(),
            //        //Freetext = s.ItemArray[7].ToString(),
            //        TotQty = s.ItemArray[7].ToString() != null && s.ItemArray[7].ToString() != "" ? Convert.ToInt32(s.ItemArray[7].ToString()) : 0,
            //        TotValue = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToDouble(s.ItemArray[8].ToString()) : 0,
            //        OrdPoints = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToInt32(s.ItemArray[9].ToString()) : 0,
            //    }).ToList();
            //}
            //else if (reportTypes == "4")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        OrderNo = s.ItemArray[0].ToString() != null ? Convert.ToInt32(s.ItemArray[0].ToString()) : 0,
            //        OrderDate = s.ItemArray[1].ToString() != null ? DateTime.Parse(s.ItemArray[1].ToString()).ToString("dd-MM-yyyy") : "",
            //        Employeeid = s.ItemArray[2].ToString() != null ? s.ItemArray[2].ToString() : "",
            //        EmployeeName = s.ItemArray[3].ToString() != null ? s.ItemArray[3].ToString() : "",
            //        BaseStyle = s.ItemArray[7].ToString(),
            //        Custref = s.ItemArray[4].ToString(),
            //        Styleid = s.ItemArray[5].ToString(),
            //        Description = s.ItemArray[6].ToString(),
            //        BaseStyleDesc = s.ItemArray[8].ToString(),
            //        Color = s.ItemArray[9].ToString(),
            //        Size = s.ItemArray[10].ToString(),
            //        Freetext = s.ItemArray[11].ToString(),
            //        TotQty = s.ItemArray[12].ToString() != null && s.ItemArray[12].ToString() != "" ? Convert.ToInt32(s.ItemArray[12].ToString()) : 0,
            //        TotValue = s.ItemArray[13].ToString() != null && s.ItemArray[13].ToString() != "" ? Convert.ToDouble(s.ItemArray[13].ToString()) : 0,
            //        OrdPoints = s.ItemArray[14].ToString() != null && s.ItemArray[14].ToString() != "" ? Convert.ToInt32(s.ItemArray[14].ToString()) : 0,
            //    }).ToList();

            //}
            //else if (reportTypes == "5")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {

            //        Employeeid = s.ItemArray[0].ToString() != null ? s.ItemArray[2].ToString() : "",
            //        EmployeeName = s.ItemArray[1].ToString() != null ? s.ItemArray[3].ToString() : "",
            //        Custref = s.ItemArray[2].ToString(),
            //        TotQty = s.ItemArray[3].ToString() != null && s.ItemArray[3].ToString() != "" ? Convert.ToInt32(s.ItemArray[3].ToString()) : 0,
            //        TotValue = s.ItemArray[4].ToString() != null && s.ItemArray[4].ToString() != "" ? Convert.ToDouble(s.ItemArray[4].ToString()) : 0,
            //        TotPts = s.ItemArray[5].ToString() != null && s.ItemArray[5].ToString() != "" ? Convert.ToInt32(s.ItemArray[5].ToString()) : 0,
            //        OrdPoints = s.ItemArray[6].ToString() != null && s.ItemArray[6].ToString() != "" ? Convert.ToInt32(s.ItemArray[6].ToString()) : 0,
            //    }).ToList();
            //}
            //else if (reportTypes == "0")
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        BaseStyle = s.ItemArray[3].ToString(),
            //        Custref = s.ItemArray[0].ToString(),
            //        Styleid = s.ItemArray[1].ToString(),
            //        Description = s.ItemArray[2].ToString(),
            //        BaseStyleDesc = s.ItemArray[4].ToString(),
            //        Color = s.ItemArray[5].ToString(),
            //        Size = s.ItemArray[6].ToString(),
            //        Freetext = s.ItemArray[7].ToString(),
            //        TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
            //        TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
            //        OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
            //    }).ToList();
            //}
            //else
            //{
            //    rollReportresult = dt.AsEnumerable().Select(s => new RolloutReportModel
            //    {
            //        BaseStyle = s.ItemArray[3].ToString(),
            //        Custref = s.ItemArray[0].ToString(),
            //        Styleid = s.ItemArray[1].ToString(),
            //        Description = s.ItemArray[2].ToString(),
            //        BaseStyleDesc = s.ItemArray[4].ToString(),
            //        Color = s.ItemArray[5].ToString(),
            //        Size = s.ItemArray[6].ToString(),
            //        Freetext = s.ItemArray[7].ToString(),
            //        TotQty = s.ItemArray[8].ToString() != null && s.ItemArray[8].ToString() != "" ? Convert.ToInt32(s.ItemArray[8].ToString()) : 0,
            //        TotValue = s.ItemArray[9].ToString() != null && s.ItemArray[9].ToString() != "" ? Convert.ToDouble(s.ItemArray[9].ToString()) : 0,
            //        OrdPoints = s.ItemArray[10].ToString() != null && s.ItemArray[10].ToString() != "" ? Convert.ToInt32(s.ItemArray[10].ToString()) : 0,
            //    }).ToList();
            //}
            return rollReportresult;
        }
        #endregion

        #region GetReturnOrders
        public List<EmployeeViewModel> GetReturnOrders(bool pointsReq, string role, string busId, string userID, string orderPermission, bool isEmergency = false, string rtnType = "")
        {
            var result = new List<EmployeeViewModel>();
            string sSql = "";
            sSql = getReturnOrderEmployees(pointsReq, role, busId, userID, orderPermission, isEmergency, rtnType);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (pointsReq)
                    {
                        result = dt.AsEnumerable().Select(s => new EmployeeViewModel
                        {
                            EmployeeId = s["employee"].ToString(),
                            EmpFirstName = s["forename"].ToString(),
                            EmpLastName = s["surname"].ToString(),
                            EmpUcodes = s["ucode"].ToString(),
                            LastOrderDate = s["Rtorderno"].ToString() + s["Rtorddate"].ToString(),
                            TotalPoints = s["totalpoints"].ToString() != null && s["totalpoints"].ToString() != "" ? Convert.ToInt32(s["totalpoints"].ToString()) : 0,
                            PointsUsed = s["pointsused"].ToString() != null && s["pointsused"].ToString() != "" ? Convert.ToInt32(s["pointsused"].ToString()) : 0,
                            Hasorder = s["hasorder"].ToString() != null && s["hasorder"].ToString() != "" ? true : false,
                            LastOrderNo = s["hasorder"].ToString() != null && s["hasorder"].ToString() != "" ? Convert.ToInt32(s["hasorder"].ToString()) : 0
                        }).ToList();
                    }
                    else
                    {
                        result = dt.AsEnumerable().Select(s => new EmployeeViewModel
                        {
                            EmployeeId = s["employee"].ToString(),
                            EmpFirstName = s["forename"].ToString(),
                            EmpLastName = s["surname"].ToString(),
                            EmpUcodes = s["ucode"].ToString(),
                            LastOrderDate = s["Rtorderno"].ToString() + s["Rtorddate"].ToString(),
                            Hasorder = s["hasorder"].ToString() != null && s["hasorder"].ToString() != "" ? true : false,
                            LastOrderNo = s["hasorder"].ToString() != null && s["hasorder"].ToString() != "" ? Convert.ToInt32(s["hasorder"].ToString()) : 0
                        }).ToList();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result.Where(s => s.Hasorder).ToList();
        }
        #endregion

        #region getReturnOrderEmployees
        public string getReturnOrderEmployees(bool pointsReq, string role, string busId, string userID, string orderPermission, bool isEmergency = false, string rtnType = "")
        {
            string sSql = "";

            sSql = sSql + "SELECT emp.`EmployeeID` employee,emp.`Forename` forename,emp.`Surname` surname,eu.`UCodeID` ucode, IF(sh.`OrderType`= 'RT', sh.`OrderNo`, 0) Rtorderno,max(sh.orderno) hasorder, IF(sh.`OrderType`= 'RT', sh.`OrderDate`, '') Rtorddate";
            if (pointsReq)
            {
                sSql = sSql + ",up.`TotalPoints` totalpoints, pc.TOTSOPOINTS pointsused";
            }

            sSql = sSql + " FROM `tblaccemp_employee` emp LEFT JOIN `tblaccemp_ucodesemployees` eu ON eu.`EmployeeID`= emp.`EmployeeID` AND eu.`CompanyID`= emp.`CompanyID` AND eu.`BusinessID`= emp.`BusinessID` LEFT JOIN `tblaccemp_ucodepoints` up ON up.`BusinessID`= eu.`BusinessID` AND up.`CompanyID`= eu.`CompanyID` AND up.`UcodeID`= eu.`UCodeID` LEFT JOIN `tblonline_userid_employee` ou ON ou.`BusinessID` = emp.`BusinessID` AND ou.`CompanyID`= emp.`CompanyID` AND ou.`EmployeeID`= emp.`EmployeeID`";
            if (pointsReq)
            {
                sSql = sSql + "  LEFT JOIN (SELECT `tblaccemp_pointscard`.`CompanyID`  AS `CompanyID`, `tblaccemp_pointscard`.`BusinessID` AS `BusinessID`, `tblaccemp_pointscard`.`EmployeeID` AS `EmployeeID`,  SUM(((IF(ISNULL(`tblaccemp_pointscard`.`SOPoints`),0,`tblaccemp_pointscard`.`SOPoints`) + IF(ISNULL(`tblaccemp_pointscard`.`PickPoints`),0,`tblaccemp_pointscard`.`PickPoints`)) + IF(ISNULL(`tblaccemp_pointscard`.`InvPoints`),0,`tblaccemp_pointscard`.`InvPoints`))) AS `TOTSOPOINTS` FROM `tblaccemp_pointscard` WHERE(`tblaccemp_pointscard`.`Year` = 0) GROUP BY `tblaccemp_pointscard`.`BusinessID`,`tblaccemp_pointscard`.`EmployeeID`) pc ON pc.companyid = emp.`CompanyID` AND pc.businessid = emp.`BusinessID` AND pc.employeeid = emp.`EmployeeID` ";
            }
            sSql = sSql + "LEFT JOIN  `tblsop_salesorder_header` sh ON sh.custid = emp.`BusinessID` AND sh.pinno = emp.`EmployeeID` WHERE emp.`EmployeeClosed`=0";
            if (isEmergency && rtnType == "EMERGENCY")
            {
                string reasoncode = _ucodeReason.Exists(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY" | s.UcodeId == "BAR EMERGENCY") ? string.Join(",", _ucodeReason.GetAll(s => s.UcodeId != "BAR MATERNITY P" & s.UcodeId != "BAR MATERNITY F" && s.UcodeId != "BAR MATERNITY" && s.UcodeId != "BAR EMERGENCY").Select(s => s.ReasonCodeID.ToString()).ToList()) : "";
                sSql = sSql + " AND sh.`ReasonCode` in (" + reasoncode + ") ";
            }
            else if (rtnType == "MATERNITY")
            {
                string reasoncode = _ucodeReason.Exists(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY") ? string.Join(",", _ucodeReason.GetAll(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId != "BAR MATERNITY").Select(s => s.ReasonCodeID.ToString()).ToList()) : "";
                sSql = sSql + " AND sh.`ReasonCode` in (" + reasoncode + ") ";
            }
            else if (rtnType == "PRIVATE")
            {
                sSql = sSql + " AND sh.`ReasonCode` in (" + 99 + ") and sh.custref like '%Private order%'";
            }
            sSql = sSql + " AND ou.`EmployeeID` IN(" + getPermissionUsers(orderPermission, userID, busId, role) + ") AND ou.`EmployeeID` NOT IN (" + getDenyPermissionUsers(orderPermission, userID, busId) + ") GROUP BY emp.`BusinessID`,emp.`CompanyID`,emp.`EmployeeID` ";
            return sSql;
        }
        #endregion

        #region GetAllPointsAdj

        public List<PointsAdjustmentModel> GetAllPointsAdj(string empId)
        {
            var result = new List<PointsAdjustmentModel>();
            string sSql = "";
            sSql = "SELECT * FROM  `hr_barclay_banners_styles` bs LEFT JOIN `tblaccemp_pointscard` pc ON bs.styleid = pc.styleid WHERE pc.employeeid = '" + empId + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = dt.AsEnumerable().Select(s => new PointsAdjustmentModel
                    {
                        EmployeeId = s[""].ToString() == "" ? s[""].ToString() : "",
                        BannerStyle = s[""].ToString() == "" ? s[""].ToString() : "",
                        Colourid = s[""].ToString() == "" ? s[""].ToString() : "",
                        Description = s[""].ToString() == "" ? s[""].ToString() : "",
                        PointsFromOldSystem = s[""].ToString() == "" ? Convert.ToInt32(s[""].ToString()) : 0,
                        StyleId = s[""].ToString() == "" ? s[""].ToString() : ""
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion

        #region GetReturnOrder

        public List<ReturnOrderModel> GetReturnOrder(string empId, string businessId, string userId, string OrderPermission, bool pointsReq, string role, List<string> catagory, int OrdNo, string custRef, string courierRef, int pickingSlipNo, bool isEmergency = false, string rtnType = "")
        {
            List<ReturnOrderModel> result = new List<ReturnOrderModel>();
            string strsql = "";
            string strAllocTxt = "AllocText";
            int rtnEligibleMnts = BusinessParam("MONTHAGO_RT", businessId) == "" ? 0 : Convert.ToInt32(BusinessParam("MONTHAGO_RT", businessId));
            DateTime returnEligibleDt = DateTime.Now.AddMonths(-rtnEligibleMnts);
            strsql = "SELECT DISTINCT h.OrderNo,p.flaginvoice,s.`StyleImage`,h.`UCodeId` ucode,h.`PinNo` Emp, DATE_FORMAT(h.OrderDate, '%d/%m/%Y') as OrderDate, d.LineNo, d.StyleID, d.Description, d.ColourID, d.SizeID, d.OrdQty, d.Price, p.PickingSlipNo, c.CourierRef, h.CustRef, r.RtnQty, d.FreeText " + strAllocTxt + ",d.`OriginalLineNo`";
            if (pointsReq)
            {
                strsql += ",sp.`Points` points,(sp.`Points` *  d.OrdQty) totpoints";
            }
            if (isEmergency && rtnType == "EMERGENCY")
            {
                strsql += ",d.sopdetail4 Detailreason";
            }
            strsql += "  FROM tblsop_salesorder_header h JOIN tblsop_salesorder_detail d ON h.OrderNo = d.OrderNo AND h.CompanyID = d.CompanyID  LEFT JOIN tblfsk_style s on (d.StyleID=s.StyleID) and (d.companyid=s.companyid)  LEFT JOIN `tblsop_pickingslip_detail` pd ON pd.`StyleID`=d.`StyleID` AND pd.`ColourID`=d.`ColourID` AND pd.`SizeID`=d.`SizeID` AND d.`LineNo`=pd.`SOLineNo` LEFT JOIN tblsop_pickingslip_header p ON h.orderno = p.orderno AND h.companyid = p.companyid  AND h.`CustID` = p.`CustID` AND p.`PickingSlipNo`=pd.`PickingSlipNo` ";
            if (pointsReq)
            {
                strsql += "LEFT JOIN `tblaccemp_stylepoints` sp ON d.`CompanyID`=sp.`CompanyID` AND d.`StyleID`=sp.`StyleID` AND d.`ColourID`= sp.`ColourID`";
            }
            strsql += " LEFT JOIN tblsop_courier_information c on p.orderno = c.orderno and c.deliverynote = p.pickingslipno  LEFT JOIN (SELECT t1.OriginalOrderNo,t1.OriginalLineNo,t1.styleid,t1.colourid,t1.sizeid,SUM(t1.OrdQty) as RtnQty  FROM tblsop_salesorder_detail t1  join tblsop_salesorder_header t2 on t1.orderno=t2.orderno and t1.companyid=t2.companyid WHERE t2.custid='" + businessId + "' AND t1.OriginalOrderNo>0 and t1.OriginalLineNo>0 GROUP BY t1.styleid, t1.colourid, t1.sizeid,t1.OriginalOrderNo, t1.OriginalLineNo) r on d.styleid=r.styleid and d.colourid=r.colourid and d.sizeid=r.sizeid and d.OrderNo=r.OriginalOrderNo and d.LineNo=r.OriginalLineNo  LEFT JOIN tblfsk_style_freetext f on d.companyid=f.companyid and d.warehouseid=f.warehouseid and d.styleid=f.styleid  LEFT JOIN tblonlinesop_carriage oc on d.companyid=oc.companyid and d.styleid=oc.companyid   WHERE h.CompanyID='" + cmpId + "' AND h.CustID='" + businessId + "'";
            if (role.ToLower().Trim() != "admin")
            {
                strsql += "AND h.OnlineUserID IN (" + getPermissionUsers(OrderPermission, userId, businessId, role) + ")   AND h.OnlineUserID NOT IN(" + getDenyPermissionUsers(OrderPermission, userId, businessId) + ") ";
            }
            //strsql += " AND(h.OrderType = 'SO' OR ISNULL(h.OrderType))   AND if (isnull(c.DespatchDate),h.OrderDate,c.DespatchDate)>= '" + returnEligibleDt.ToString("yyyy-MM-dd") + "'   AND d.AssemblyID = 0 AND AsmLineNo = 0 AND h.OnlineConfirm = 1 AND h.OnlineProcessed = 1 ";

            if (isEmergency && rtnType == "EMERGENCY")
            {
                string reasoncode = _ucodeReason.Exists(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY" | s.UcodeId == "BAR EMERGENCY") ? string.Join(",", _ucodeReason.GetAll(s => s.UcodeId != "BAR MATERNITY P" & s.UcodeId != "BAR MATERNITY F" && s.UcodeId != "BAR MATERNITY" && s.UcodeId != "BAR EMERGENCY").Select(s => s.ReasonCodeID.ToString()).ToList()) : "";
                strsql += " AND(h.OrderType = 'SO' OR ISNULL(h.OrderType))   AND h.reasoncode in(" + reasoncode + ")   AND c.DespatchDate>= '" + returnEligibleDt.ToString("yyyy-MM-dd") + "'   AND d.AssemblyID = 0 AND AsmLineNo = 0 AND h.OnlineConfirm = 1 AND h.OnlineProcessed = 1 ";
            }
            else if (rtnType == "MATERNITY")
            {
                string reasoncode = _ucodeReason.Exists(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY") ? string.Join(",", _ucodeReason.GetAll(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY").Select(s => s.ReasonCodeID.ToString()).ToList()) : "";
                strsql += " AND(h.OrderType = 'SO' OR ISNULL(h.OrderType))   AND h.reasoncode in(" + reasoncode + ")   AND c.DespatchDate>= '" + returnEligibleDt.ToString("yyyy-MM-dd") + "'   AND d.AssemblyID = 0 AND AsmLineNo = 0 AND h.OnlineConfirm = 1 AND h.OnlineProcessed = 1 ";
            }
            else if (rtnType == "PRIVATE")
            {
                strsql += " AND(h.OrderType = 'SO' OR ISNULL(h.OrderType))   AND h.reasoncode =99 AND h.custref like '%Private order%'  AND c.DespatchDate>= '" + returnEligibleDt.ToString("yyyy-MM-dd") + "'   AND d.AssemblyID = 0 AND AsmLineNo = 0 AND h.OnlineConfirm = 1 AND h.OnlineProcessed = 1 AND d.styleid NOT IN (SELECT styleid FROM `tblonlinebus_carriage`)   AND d.styleid NOT IN (SELECT styleid FROM `tblonlinesop_carriage`) ";
            }
            else
            {
                strsql += " AND(h.OrderType = 'SO' OR ISNULL(h.OrderType)) AND h.reasoncode=0   AND c.DespatchDate>= '" + returnEligibleDt.ToString("yyyy-MM-dd") + "'   AND d.AssemblyID = 0 AND AsmLineNo = 0 AND h.OnlineConfirm = 1 AND h.OnlineProcessed = 1 ";
            }
            if (catagory != null)
            {
                if (catagory.Count > 0)
                {
                    string grp = String.Join("','", catagory);
                    grp = "'" + grp + "'";
                    strsql += " AND s.Product_Group IN (" + strsql + ") ";
                }
            }
            if (OrdNo > 0)
            {
                strsql += " AND h.OrderNo=" + OrdNo + " ";
            }
            if (custRef != "")
            {
                strsql += " AND (h.custref LIKE '" + custRef + "%' ";
            }
            if (pickingSlipNo > 0)
            {
                strsql += " AND p.PickingSlipNo=" + pickingSlipNo + " ";
            }
            if (courierRef != "")
            {
                strsql += " AND c.CourierRef='" + courierRef + "' ";
            }

            if (empId != "")
            {
                strsql += " AND h.Pinno='" + empId + "' ";
            }
            strsql += "ORDER BY h.OrderNo, d.LineNo,d.StyleID ";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strsql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (pointsReq)
                    {
                        result = dt.AsEnumerable().Select(s => new ReturnOrderModel
                        {
                            InvFlag = s["flaginvoice"].ToString() != "" ? s["flaginvoice"].ToString() == "1" ? "inv" : "pick" : "so",
                            OrderNo = s["OrderNo"].ToString() != "" ? Convert.ToInt32(s["OrderNo"].ToString()) : 0,
                            OrderDate = s["OrderDate"].ToString() != "" ? DateTime.Parse(s["OrderDate"].ToString()).ToString("dd-MM-yyyy") : "",
                            LineNo = s["LineNo"].ToString() != "" ? Convert.ToInt32(s["LineNo"].ToString()) : 0,
                            StyleId = s["StyleID"].ToString() != "" ? s["StyleID"].ToString() : "",
                            Description = s["Description"].ToString() != "" ? s["Description"].ToString() : "",
                            ColourId = s["ColourID"].ToString() != "" ? s["ColourID"].ToString() : "",
                            SizeId = s["SizeID"].ToString() != "" ? s["SizeID"].ToString() : "",
                            OrgOrdQty = s["OrdQty"].ToString() != "" ? Convert.ToInt32(s["OrdQty"].ToString()) : 0,
                            Price = s["Price"].ToString() != "" ? Convert.ToDouble(s["Price"].ToString()) : 0,
                            PickingSlipNo = s["PickingSlipNo"].ToString() != "" ? Convert.ToInt32(s["PickingSlipNo"].ToString()) : 0,
                            CourierRef = s["CourierRef"].ToString() != "" ? s["CourierRef"].ToString() : "",
                            CustRef = s["CustRef"].ToString() != "" ? s["CustRef"].ToString() : "",
                            OrgRetOrdQty = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            OrgRetOrdQtyDel = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            StyleImage = s["StyleImage"].ToString(),
                            AllocText = s["AllocText"].ToString() != "" ? s["AllocText"].ToString() : "",
                            OriginalLineNo = s["OriginalLineNo"].ToString() != "" ? Convert.ToInt32(s["OriginalLineNo"].ToString()) : 0,
                            Points = s["points"].ToString() != "" ? Convert.ToInt32(s["points"].ToString()) : 0,
                            TotalPoints = s["totpoints"].ToString() != "" ? Convert.ToInt32(s["totpoints"].ToString()) : 0,
                            Emp = s["Emp"].ToString() != "" ? s["Emp"].ToString() : "",
                            Ucode = s["ucode"].ToString() != "" ? s["ucode"].ToString() : ""
                        }).ToList();
                    }
                    else if (rtnType == "PRIVATE")
                    {
                        result = dt.AsEnumerable().Select(s => new ReturnOrderModel
                        {

                            OrderNo = s["OrderNo"].ToString() != "" ? Convert.ToInt32(s["OrderNo"].ToString()) : 0,
                            OrderDate = s["OrderDate"].ToString() != "" ? DateTime.Parse(s["OrderDate"].ToString()).ToString("dd-MM-yyyy") : "",
                            LineNo = s["LineNo"].ToString() != "" ? Convert.ToInt32(s["LineNo"].ToString()) : 0,
                            StyleId = s["StyleID"].ToString() != "" ? s["StyleID"].ToString() : "",
                            Description = s["Description"].ToString() != "" ? s["Description"].ToString() : "",
                            ColourId = s["ColourID"].ToString() != "" ? s["ColourID"].ToString() : "",
                            SizeId = s["SizeID"].ToString() != "" ? s["SizeID"].ToString() : "",
                            OrgOrdQty = s["OrdQty"].ToString() != "" ? Convert.ToInt32(s["OrdQty"].ToString()) : 0,
                            Price = s["Price"].ToString() != "" ? Convert.ToDouble(s["Price"].ToString()) : 0,
                            PickingSlipNo = s["PickingSlipNo"].ToString() != "" ? Convert.ToInt32(s["PickingSlipNo"].ToString()) : 0,
                            CourierRef = s["CourierRef"].ToString() != "" ? s["CourierRef"].ToString() : "",
                            CustRef = s["CustRef"].ToString() != "" ? s["CustRef"].ToString() : "",
                            OrgRetOrdQty = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            OrgRetOrdQtyDel = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            StyleImage = s["StyleImage"].ToString(),
                            AllocText = s["AllocText"].ToString() != "" ? s["AllocText"].ToString() : "",
                            OriginalLineNo = s["OriginalLineNo"].ToString() != "" ? Convert.ToInt32(s["OriginalLineNo"].ToString()) : 0,
                            //Points = s["points"].ToString() != "" ? Convert.ToInt32(s["points"].ToString()) : 0,
                            //TotalPoints = s["totpoints"].ToString() != "" ? Convert.ToInt32(s["totpoints"].ToString()) : 0,
                            Emp = s["Emp"].ToString() != "" ? s["Emp"].ToString() : "",
                            Ucode = s["ucode"].ToString() != "" ? s["ucode"].ToString() : "",
                        }).ToList();
                    }
                    else
                    {
                        result = dt.AsEnumerable().Select(s => new ReturnOrderModel
                        {
                            InvFlag = s["flaginvoice"].ToString() != "" ? s["flaginvoice"].ToString() == "1" ? "inv" : "pick" : "so",
                            OrderNo = s["OrderNo"].ToString() != "" ? Convert.ToInt32(s["OrderNo"].ToString()) : 0,
                            OrderDate = s["OrderDate"].ToString() != "" ? DateTime.Parse(s["OrderDate"].ToString()).ToString("dd-MM-yyyy") : "",
                            LineNo = s["LineNo"].ToString() != "" ? Convert.ToInt32(s["LineNo"].ToString()) : 0,
                            StyleId = s["StyleID"].ToString() != "" ? s["StyleID"].ToString() : "",
                            Description = s["Description"].ToString() != "" ? s["Description"].ToString() : "",
                            ColourId = s["ColourID"].ToString() != "" ? s["ColourID"].ToString() : "",
                            SizeId = s["SizeID"].ToString() != "" ? s["SizeID"].ToString() : "",
                            OrgOrdQty = s["OrdQty"].ToString() != "" ? Convert.ToInt32(s["OrdQty"].ToString()) : 0,
                            Price = s["Price"].ToString() != "" ? Convert.ToDouble(s["Price"].ToString()) : 0,
                            PickingSlipNo = s["PickingSlipNo"].ToString() != "" ? Convert.ToInt32(s["PickingSlipNo"].ToString()) : 0,
                            CourierRef = s["CourierRef"].ToString() != "" ? s["CourierRef"].ToString() : "",
                            CustRef = s["CustRef"].ToString() != "" ? s["CustRef"].ToString() : "",
                            OrgRetOrdQty = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            OrgRetOrdQtyDel = s["RtnQty"].ToString() != "" ? Convert.ToInt32(s["RtnQty"].ToString()) : 0,
                            StyleImage = s["StyleImage"].ToString(),
                            AllocText = s["AllocText"].ToString() != "" ? s["AllocText"].ToString() : "",
                            OriginalLineNo = s["OriginalLineNo"].ToString() != "" ? Convert.ToInt32(s["OriginalLineNo"].ToString()) : 0,
                            //Points = s["points"].ToString() != "" ? Convert.ToInt32(s["points"].ToString()) : 0,
                            //TotalPoints = s["totpoints"].ToString() != "" ? Convert.ToInt32(s["totpoints"].ToString()) : 0,
                            Emp = s["Emp"].ToString() != "" ? s["Emp"].ToString() : "",
                            Ucode = s["ucode"].ToString() != "" ? s["ucode"].ToString() : "",
                            SOPDetail4 = s["Detailreason"].ToString() != "" ? s["Detailreason"].ToString() : ""
                        }).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion
        #region  GetFreeStock

        public int GetFreeStockConn(string styleid, string colourid, string sizeid, string wrehouse, MySqlConnection conn, List<SalesOrderLineViewModel> model = null, bool isedit = false, bool iscard = true)
        {
            int value = 0;
            int freeStck = 0;
            int soqtyStck = 0;
            DataTable sodt = new DataTable();
            DataTable freDt = new DataTable();
            string freDtQry = "";
            string sodtQry = "";

            try
            {
                freDtQry = "SELECT  CompanyID,WarehouseID,StyleID,ColourID,SizeID,SUM(StockQty-AllQty-SOQty) AS  FreeStock  FROM tblfsk_style_locations WHERE CompanyID='" + cmpId + "' AND  WarehouseID='" + wrehouse + "' AND StyleID='" + styleid.Trim() + "' AND  ColourID='" + colourid.Trim() + "' AND SizeID='" + sizeid.Trim() + "'  GROUP BY CompanyID,WarehouseID,StyleID,ColourID,SizeID ";
                sodtQry = "SELECT  t1.CompanyID,t2.StyleID,t2.ColourID,t2.SizeID,SUM(IF(ISNULL(t2.OrdQty),0,t2.OrdQty)) AS SOQty  FROM tblsop_salesorder_header t1 JOIN  tblsop_salesorder_detail t2  ON t1.CompanyID = t2.CompanyID AND t1.OrderNo =  t2.OrderNo  WHERE t1.CompanyID='" + cmpId + "' AND  t1.WarehouseID='" + wrehouse + "' AND t2.StyleID='" + styleid + "' AND t2.ColourID='" + colourid + "' AND t2.SizeID='" + sizeid + "'   AND t1.OnlineConfirm=0 AND t1.OnlineProcessed=0  GROUP BY CompanyID,StyleID,ColourID,SizeID ";

                MySqlCommand cmd = new MySqlCommand(freDtQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(freDt);
                MySqlCommand cmd1 = new MySqlCommand(sodtQry, conn);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(sodt);

                if (freDt.Rows.Count > 0)
                {
                    freeStck = freDt.Rows[0]["FreeStock"].ToString() != "" ? Convert.ToInt32(freDt.Rows[0]["FreeStock"]) : 0;
                }
                else
                {
                    freeStck = 0;
                }
                if (isedit)
                {
                    long uncart = 0;
                    uncart = model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit) ?
                      model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.SoqtyForempSO) : 0;

                    freeStck = freeStck + Convert.ToInt32(uncart);
                }

                value = freeStck - soqtyStck;
                if (model != null && iscard)
                {

                    var allcart = model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false) ?
                     model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                    value = value - Convert.ToInt32(allcart);
                }
                if (isedit)
                {

                    if (model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted))
                    {
                        value = value + Convert.ToInt32(model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted).Sum(s => s.OrdQty));
                    }
                }
                value = value > 0 ? value : 0;

            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {

            }
            return value;
        }
        #endregion

        #region  GetFreeStock

        public int GetFreeStock(string styleid, string colourid, string sizeid, string wrehouse, List<SalesOrderLineViewModel> model = null, bool isedit = false, bool iscard = true)
        {
            int value = 0;
            int freeStck = 0;
            int soqtyStck = 0;
            DataTable sodt = new DataTable();
            DataTable freDt = new DataTable();
            string freDtQry = "";
            string sodtQry = "";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                freDtQry = "SELECT  CompanyID,WarehouseID,StyleID,ColourID,SizeID,SUM(StockQty-AllQty-SOQty) AS  FreeStock  FROM tblfsk_style_locations WHERE CompanyID='" + cmpId + "' AND  WarehouseID='" + wrehouse + "' AND StyleID='" + styleid.Trim() + "' AND  ColourID='" + colourid.Trim() + "' AND SizeID='" + sizeid.Trim() + "'  GROUP BY CompanyID,WarehouseID,StyleID,ColourID,SizeID ";
                sodtQry = "SELECT  t1.CompanyID,t2.StyleID,t2.ColourID,t2.SizeID,SUM(IF(ISNULL(t2.OrdQty),0,t2.OrdQty)) AS SOQty  FROM tblsop_salesorder_header t1 JOIN  tblsop_salesorder_detail t2  ON t1.CompanyID = t2.CompanyID AND t1.OrderNo =  t2.OrderNo  WHERE t1.CompanyID='" + cmpId + "' AND  t1.WarehouseID='" + wrehouse + "' AND t2.StyleID='" + styleid + "' AND t2.ColourID='" + colourid + "' AND t2.SizeID='" + sizeid + "'   AND t1.OnlineConfirm=0 AND t1.OnlineProcessed=0  GROUP BY CompanyID,StyleID,ColourID,SizeID ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(freDtQry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(freDt);
                MySqlCommand cmd1 = new MySqlCommand(sodtQry, conn);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(sodt);

                if (freDt.Rows.Count > 0)
                {
                    freeStck = freDt.Rows[0]["FreeStock"].ToString() != "" ? Convert.ToInt32(freDt.Rows[0]["FreeStock"]) : 0;
                }
                else
                {
                    freeStck = 0;
                }
                if (isedit)
                {
                    long uncart = 0;
                    uncart = model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit) ?
                      model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.SoqtyForempSO) : 0;

                    freeStck = freeStck + Convert.ToInt32(uncart);
                }
                //if (sodt.Rows.Count > 0)
                //{
                //    soqtyStck = sodt.Rows[0]["SOQty"].ToString() != "" ? Convert.ToInt32(sodt.Rows[0]["SOQty"]) : 0;
                //}
                //else
                //{
                //    soqtyStck = 0;
                //}
                //if (isedit==false)
                //{
                value = freeStck - soqtyStck;
                if (model != null && iscard)
                {
                    //styleid, string colourid, string sizeid, string wrehouse, List< SalesOrderLineViewModel > model = null) 
                    var allcart = model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false) ?
                     model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                    value = value - Convert.ToInt32(allcart);
                }
                if (isedit)
                {
                    //if (model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit))
                    //{
                    //    if (model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.SoqtyForempSO) - model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.OrdQty) != 0)
                    //    {
                    //        value = model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.SoqtyForempSO) - model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false && s.Isedit).Sum(s => s.OrdQty) > 0 ? value + 1 : value - 1;
                    //    }
                    //}
                    if (model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted))
                    {
                        value = value + Convert.ToInt32(model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted).Sum(s => s.OrdQty));
                    }
                }
                value = value > 0 ? value : 0;
                //}
                //else
                //{
                //    //value = freeStck - soqtyStck;
                //if (model != null )
                //{
                //    //styleid, string colourid, string sizeid, string wrehouse, List< SalesOrderLineViewModel > model = null)

                //    var cart = model.Any(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false) ?
                //     model.Where(s => s.StyleID == styleid && s.ColourID == colourid && s.SizeID == sizeid && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                //    value = value + Convert.ToInt32(cart);
                //}
                //value = value > 0 ? value : 0;
                //}
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return value;
        }
        #endregion

        #region DeleteReturnOrder
        public bool DeleteReturnOrder(int orderno, string user)
        {
            bool isPrivateOrder = false;
            bool result = false;
            if (orderno > 0)
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                MySqlTransaction trans;
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    if (_salesDetail.Exists(s => s.OrderNo == orderno))
                    {
                        string Allreorders = "select * from tblsop_salesorder_detail where returnorderno =" + orderno + "";
                        var salesHead = _salesHead.Exists(s => s.OrderNo == orderno) ? _salesHead.GetAll(s => s.OrderNo == orderno).First() : new tblsop_salesorder_header();
                        if (salesHead.OrderNo > 0)
                        {
                            isPrivateOrder = salesHead.CustRef.ToLower().Contains("private") && (salesHead.UCodeId == "" || salesHead.UCodeId == null) ? true : false;
                        }
                        MySqlCommand cmd = new MySqlCommand(Allreorders, conn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<int> reOrderNos = new List<int>();
                            reOrderNos = dt.AsEnumerable().Select(s => Convert.ToInt32(s["orderno"].ToString())).ToList();
                            if (Deletereorders(conn, reOrderNos, salesHead, user, isPrivateOrder))
                            {
                                result = DeleteReturns(conn, orderno, salesHead, user, isPrivateOrder);
                            }

                        }
                        else
                        {
                            result = DeleteReturns(conn, orderno, salesHead, user, isPrivateOrder);
                        }
                        //List<int> Reorders = _salesDetail.Exists(s => s.ReturnOrderNo == orderno) ? _salesDetail.GetAll(s => s.ReturnOrderNo == orderno).Select(s=>s.OrderNo).ToList():new <List>;
                        //(08-01-21) hatim asked not to do this
                        //if(InvFlag=="so")
                        //{

                        //}
                        //else if(InvFlag == "pick")
                        //{
                        //    //(08-01-21) hatim asked not to do this
                        //}
                        //else if(InvFlag == "inv")
                        //{
                        //    //(08-01-21) hatim asked not to do this
                        //}
                        if (result)
                        {
                            trans.Commit();
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                    result = false;
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                }

            }
            return result;
        }
        #endregion

        #region  Deletereorders

        public bool Deletereorders(MySqlConnection conn, List<int> orderNOs, tblsop_salesorder_header salesHead, string user, bool isPrivateOrder = false)
        {
            var result = false;
            foreach (var orderno in orderNOs.Distinct())
            {
                if (isPrivateOrder)
                {
                    string roOrdDetQry = "";
                    string roOrdHedQry = "";
                    roOrdDetQry = "delete  from tblsop_salesorder_detail where orderno=" + orderno + "";
                    roOrdHedQry = "delete  from tblsop_salesorder_header where orderno=" + orderno + "";

                    if (ExecuteQuery(conn, roOrdDetQry) > 0)
                    {
                        if (ExecuteQuery(conn, roOrdHedQry) > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    bool isemergency = _pointsByUcode.Exists(s => s.UcodeID.ToLower().Trim() == salesHead.UCodeId.ToLower().Trim()) ? false : true;
                    string sql = "";
                    sql = "select * from tblsop_salesorder_detail where orderno=" + orderno + "";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (!isemergency)
                        {
                            foreach (var lline in dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { StyleID = s["StyleID"].ToString(), ColourID = s["ColourId"].ToString(), OrdQty = Convert.ToInt32(s["OrdQty"].ToString()) }).ToList())
                            {
                                int ucodPts = _stylePoints.Exists(s => s.UcodeID == salesHead.UCodeId && s.BusinessID == salesHead.CustID && s.StyleID == lline.StyleID) ? _stylePoints.GetAll(s => s.UcodeID == salesHead.UCodeId && s.BusinessID == salesHead.CustID && s.StyleID == lline.StyleID).First().Points.Value : 0;
                                string stckCardQry = "", ptsCardQry = "";
                                stckCardQry = "update `tblaccemp_stockcard` set soqty=soqty-(" + lline.OrdQty + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                                int pointsToUpdate = ucodPts * Convert.ToInt32(lline.OrdQty);
                                ptsCardQry = "update `tblaccemp_pointscard` set sopoints=sopoints-(" + pointsToUpdate + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                                if (ExecuteQuery(conn, ptsCardQry) > 0)
                                {
                                    result = true;
                                }
                                if (ExecuteQuery(conn, stckCardQry) > 0)
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                        }
                        else
                        {
                            foreach (var lline in dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { StyleID = s["StyleID"].ToString(), ColourID = s["ColourId"].ToString(), OrdQty = Convert.ToInt32(s["OrdQty"].ToString()) }).ToList())
                            {
                                string stckCardQry = "", ptsCardQry = "";
                                stckCardQry = "update `tblaccemp_stockcard` set soqty=soqty-(" + lline.OrdQty + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                                if (ExecuteQuery(conn, stckCardQry) > 0)
                                {
                                    result = true;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        string delReordqry = "Delete from tblsop_salesorder_detail where orderno=" + orderno + "";
                        MySqlCommand cmd1 = new MySqlCommand(delReordqry, conn);
                        if (cmd1.ExecuteNonQuery() > 0)
                        {
                            string delReordheadqry = "Delete from tblsop_salesorder_header where orderno=" + orderno + "";
                            MySqlCommand cmd2 = new MySqlCommand(delReordheadqry, conn);
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                        string insertDel = "";
                        insertDel = "Insert into tblonline_rejectorder_reasons(orderno,businessid,employeeid,rejectedby,rejecteddate,rejectedreason) values(" + orderno + ",'" + salesHead.CustID + "','" + salesHead.PinNo + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','')";
                        MySqlCommand cmd3 = new MySqlCommand(insertDel, conn);
                        cmd3.ExecuteNonQuery();
                    }

                }
            }
            return result;

        }
        #endregion
        #region  DeleteReturns
        public bool DeleteReturns(MySqlConnection conn, int orderNOs, tblsop_salesorder_header salesHead, string user, bool isPrivateOrder = false)
        {
            var result = false;
            if (isPrivateOrder)
            {
                string rtnDetQry = "";
                string rtnHedQry = "";
                rtnDetQry = "delete   from tblsop_salesorder_detail where orderno=" + orderNOs + "";
                rtnHedQry = "delete   from tblsop_salesorder_header where orderno=" + orderNOs + "";

                if (ExecuteQuery(conn, rtnDetQry) > 0)
                {
                    if (ExecuteQuery(conn, rtnHedQry) > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                bool isemergency = _pointsByUcode.Exists(s => s.UcodeID.ToLower().Trim() == salesHead.UCodeId.ToLower().Trim()) ? false : true;
                string sql = "select * from tblsop_salesorder_detail where orderno=" + orderNOs + "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (!isemergency)
                    {
                        foreach (var lline in dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { StyleID = s["StyleID"].ToString(), ColourID = s["ColourId"].ToString(), OrdQty = Convert.ToInt32(s["OrdQty"].ToString()), ReturnLineNo = Convert.ToInt32(s["LineNo"].ToString()) }).ToList())
                        {

                            int ucodPts = _stylePoints.Exists(s => s.UcodeID == salesHead.UCodeId && s.BusinessID == salesHead.CustID && s.StyleID == lline.StyleID) ? _stylePoints.GetAll(s => s.UcodeID == salesHead.UCodeId && s.BusinessID == salesHead.CustID && s.StyleID == lline.StyleID).First().Points.Value : 0;
                            string stckCardQry = "", ptsCardQry = "";
                            stckCardQry = "update `tblaccemp_stockcard` set soqty=soqty+(" + lline.OrdQty + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                            int pointsToUpdate = ucodPts * Convert.ToInt32(lline.OrdQty);
                            ptsCardQry = "update `tblaccemp_pointscard` set sopoints=sopoints+(" + pointsToUpdate + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                            bool hasReorder = _salesDetail.Exists(s => s.ReturnOrderNo == orderNOs && s.ReturnLineNo == lline.ReturnLineNo) ? true : false;
                            if (Convert.ToBoolean(BusinessParam("RTN_ADJ_REQ", salesHead.CustID)) || hasReorder)
                            {
                                if (ExecuteQuery(conn, stckCardQry) > 0)
                                {
                                    result = true;
                                }
                                if (ExecuteQuery(conn, ptsCardQry) > 0)
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                            else
                            {
                                result = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var lline in dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { StyleID = s["StyleID"].ToString(), ColourID = s["ColourId"].ToString(), OrdQty = Convert.ToInt32(s["OrdQty"].ToString()) }).ToList())
                        {
                            string stckCardQry = "";
                            stckCardQry = "update `tblaccemp_stockcard` set soqty=soqty+(" + lline.OrdQty + ") where styleid='" + lline.StyleID + "' and colourid='" + lline.ColourID + "' and employeeid='" + salesHead.PinNo + "'";
                            if (ExecuteQuery(conn, stckCardQry) > 0)
                            {
                                result = true;
                            }
                        }
                    }
                    if (result)
                    {
                        string delReordqry = "Delete from tblsop_salesorder_detail where orderno=" + orderNOs + "";
                        MySqlCommand cmd1 = new MySqlCommand(delReordqry, conn);
                        if (cmd1.ExecuteNonQuery() > 0)
                        {
                            string delReordheadqry = "Delete from tblsop_salesorder_header where orderno=" + orderNOs + "";
                            MySqlCommand cmd2 = new MySqlCommand(delReordheadqry, conn);
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                        string insertDel = "";
                        insertDel = "Insert into tblonline_rejectorder_reasons(orderno,businessid,employeeid,rejectedby,rejecteddate,rejectedreason) values(" + orderNOs + ",'" + salesHead.CustID + "','" + salesHead.PinNo + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','')";
                        MySqlCommand cmd3 = new MySqlCommand(insertDel, conn);
                        cmd3.ExecuteNonQuery();
                    }

                }
            }
            return result;
        }
        #endregion

        #region
        public List<styleViewmodel> GetPrivateStyles(string busId)
        {
            List<styleViewmodel> result = new List<styleViewmodel>();
            string privateUcode = "";
            privateUcode = BusinessParam("PRIVATEUCODE", busId);
            if (privateUcode != "")
            {
                string privateStyleQry = "";
                privateStyleQry = "SELECT t2.styleid,t2.description,t2.`Product_Group`,t2.`StyleImage` FROM  `tblaccemp_ucodes` t1 JOIN `tblfsk_style` t2 ON t1.`StyleID`=t2.`StyleID` AND t1.`CompanyID`=t2.`CompanyID` JOIN `tblfsk_style_groups` tg ON t2.`Product_Group`= tg.`GroupID`  WHERE T1.`UCodeID`= '" + privateUcode + "'";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(privateStyleQry, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        result = dt.AsEnumerable().Select(s => new styleViewmodel { StyleID = s["styleid"].ToString(), Description = s["description"].ToString(), StyleImage = s["StyleImage"].ToString(), ProductGroup = Convert.ToInt32(s["Product_Group"].ToString()), OriginalStyleid = s["styleid"].ToString() }).ToList();
                    }

                }
                catch (Exception e)
                {
                    logger.Warn(e.Message);
                    logger.Warn(e.StackTrace);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        #endregion

        #region GetRestockValue
        public bool GetRestockValue(string Ucodes, string busine)
        {
            bool GetRestockValue = false;
            if (Ucodes != "" && busine != "")
            {
                GetRestockValue = _ucodeOperationsTbl.Exists(s => s.BusinessID.ToLower().Trim() == busine.ToLower().Trim() && s.UcodeId.ToLower().Trim() == Ucodes.ToLower().Trim()) ? _ucodeOperationsTbl.GetAll(s => s.BusinessID.ToLower().Trim() == busine.ToLower().Trim() && s.UcodeId.ToLower().Trim() == Ucodes.ToLower().Trim()).First().FreeStkChk : false;
            }
            return GetRestockValue;
        }
        #endregion

        #region deleteOrder
        public bool DeleteOrder(int orderNO, string empId, string onlineUserId, bool pointsReq, string busId, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, bool isEmergency, string ucode)
        {
            bool result = false;
            string salesHeadQry = "", delHead = "", delLines = "";
            string salesLineQry = "";
            MySqlTransaction trans;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            trans = conn.BeginTransaction();
            var dataCar = GetCarrierStyleCmbValue(busId);
            try
            {
                if (_salesHead.GetAll(s => s.OrderNo == orderNO).First().CustRef.ToLower().Contains("private"))
                {
                    delLines = "Delete from tblsop_salesorder_detail where orderno=" + orderNO;
                    delHead = "Delete from tblsop_salesorder_header where orderno=" + orderNO;
                    if (ExecuteQuery(conn, delLines) >= 0)
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                    if (ExecuteQuery(conn, delHead) >= 0)
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    salesHeadQry = salesHeadQry + "select * from tblsop_salesorder_header where orderno=" + orderNO;
                    salesLineQry = salesLineQry + "SELECT `OrderNo`,`StyleID`,`ColourID`,`SizeID`,`Description`,`Price`,`Cost`,`OrdQty` FROM `tblsop_salesorder_detail` where orderno=" + orderNO;
                    DataTable dt = new DataTable();
                    dt = GetDataTable(salesLineQry);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dataCar.Contains(dr["StyleID"].ToString()) != true)
                            {
                                if (DeduceStockcard(dr["StyleID"].ToString(), dr["ColourID"].ToString(), empId, Convert.ToInt32(dr["OrdQty"].ToString()), conn) >= 0)
                                {
                                    if (isEmergency == false && pointsReq)
                                    {
                                        string styl = dr["StyleID"].ToString();

                                        if (DeducePointscard(dr["StyleID"].ToString(), dr["ColourID"].ToString(), empId, (Convert.ToInt32(dr["OrdQty"].ToString()) * _stylePoints.GetAll(s => s.StyleID == styl && s.UcodeID == ucode).First().Points.Value), conn) >= 0)
                                        {
                                            result = true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    result = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            if (_ucodeOperationsTbl.Exists(s => s.BusinessID == busId && s.UcodeId == ucode && s.FreeStkChk))
                            {
                                string altStyle = dr["StyleID"].ToString();
                                if (_tblAlternates.Exists(s => s.AltStyleId.Trim().ToLower() == altStyle.Trim().ToLower()) == false)
                                {
                                    if (DeduceFreeStock(dr["StyleID"].ToString(), dr["ColourID"].ToString(), dr["SizeID"].ToString(), (Convert.ToInt32(dr["OrdQty"].ToString())), conn) >= 0)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }


                    }
                    delLines = "Delete from tblsop_salesorder_detail where orderno=" + orderNO;
                    delHead = "Delete from tblsop_salesorder_header where orderno=" + orderNO;
                    if (ExecuteQuery(conn, delLines) >= 0 && result)
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                    if (ExecuteQuery(conn, delHead) >= 0 && result)
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }

                }
                if (result)
                {

                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion




        public int DeduceFreeStock(string styleid, string colourid, string size, int ordqty, MySqlConnection conn)
        {
            int result = -1;
            int soQty = 0;
            string stockDedQry = "", updQry = "";
            int newSoQty = 0;
            stockDedQry = "select soqty from tblfsk_style_locations where sizeid='" + size + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and locationid='All'";
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(stockDedQry, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                soQty = dt.AsEnumerable().Select(s => Convert.ToInt32(s["soqty"].ToString())).ToList().Sum();
            }
            newSoQty = soQty - ordqty;
            newSoQty = newSoQty > 0 ? newSoQty : 0;
            updQry = "update tblfsk_style_locations set soqty=" + newSoQty + " where sizeid='" + size + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and locationid='All'";
            result = ExecuteQuery(conn, updQry);
            return result;
        }
        public int DeduceStockcard(string styleid, string colourid, string employeeid, int ordqty, MySqlConnection conn)
        {
            int result = -1;
            int soQty = 0;
            string stockDedQry = "", updQry = "";
            int newSoQty = 0;
            stockDedQry = "select soqty from tblaccemp_stockcard where employeeid='" + employeeid + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and year=0";
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(stockDedQry, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                soQty = dt.AsEnumerable().Select(s => Convert.ToInt32(s["soqty"].ToString())).ToList().Sum();
            }
            newSoQty = soQty - ordqty;
            newSoQty = newSoQty > 0 ? newSoQty : 0;
            updQry = "update tblaccemp_stockcard set soqty=" + newSoQty + " where employeeid='" + employeeid + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and year=0";
            result = ExecuteQuery(conn, updQry);
            return result;
        }
        public int DeducePointscard(string styleid, string colourid, string employeeid, int points, MySqlConnection conn)
        {
            int result = -1;
            string stockDedQry = "", updQry = "";
            int soPts = 0;
            stockDedQry = "select sopoints from tblaccemp_Pointscard where employeeid='" + employeeid + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and year=0";
            DataTable dt = new DataTable();
            int newSoPts = 0;

            MySqlCommand cmd = new MySqlCommand(stockDedQry, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                soPts = dt.AsEnumerable().Select(s => Convert.ToInt32(s["sopoints"].ToString())).ToList().Sum();
            }
            newSoPts = soPts - points;
            newSoPts = newSoPts > 0 ? newSoPts : 0;
            updQry = "update tblaccemp_Pointscard set sopoints=" + newSoPts + " where employeeid='" + employeeid + "' and styleid='" + styleid + "' and colourid='" + colourid + "' and year=0";
            result = ExecuteQuery(conn, updQry);
            return result;
        }

        #region SaveSalesOrder
        public bool SavePrivateOrder(SalesOrderHeaderViewModel salesHead, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, long salesNo = 0, string busId = "", string usrId = "", bool editFlag = false)
        {
            Removeapostrophes(salesHead);
            bool result = false;
            int execVal = 0;
            string sSqry = "";
            StringBuilder os = new StringBuilder();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlTransaction trans;
            var salLst = new List<SalesOrderHeaderViewModel>();
            salLst.Add(salesHead);
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                if (salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0 && salesNo > 0)
                {
                    try
                    {
                        var delcCode = Convert.ToInt32(salesHead.DelCountry);
                        var invcCode = Convert.ToInt32(salesHead.DelCountry);
                        salesHead.DelCountry = _countryCodes.Exists(x => x.CountryID == delcCode) ? _countryCodes.GetAll(x => x.CountryID == delcCode).First().Country : "";
                        salesHead.InvCountry = _countryCodes.Exists(x => x.CountryID == invcCode) ? _countryCodes.GetAll(x => x.CountryID == invcCode).First().Country : "";
                    }
                    catch (Exception e)
                    {

                        logger.Warn(e.Message);
                        logger.Warn(e.StackTrace);
                    }
                    string DefUserID = BusinessParam("DEFUSRID", busId);
                    string sqlUserXref = "";
                    string UserIDXref = "";
                    sqlUserXref = "SELECT UserID FROM tblOnline_UserID_Xref  WHERE OnlineUserID='" + usrId + "' AND CompanyID='" + cmpId + "' AND BusinessID='" + busId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlUserXref, conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserIDXref = reader.GetString(0);
                    }
                    else if (DefUserID != "")
                    {
                        UserIDXref = DefUserID;
                    }
                    else
                    {
                        UserIDXref = usrId;
                    }

                    reader.Close();
                    StringBuilder oString;
                    string budgetString = "";
                    var partShipment = Convert.ToBoolean(BusinessParam("Partshipment", busId)) == true ? -1 : 0;
                    if (salesHead.Mobile != null)
                    {
                        if (salesHead.Mobile != "")
                        {
                            salesHead.ContactName = salesHead.Mobile;
                        }
                    }
                    var cntName = salesHead.ContactName == "" | salesHead.ContactName == null ? "" : salesHead.ContactName + " mobile:" + salesHead.Mobile;
                    sSqry = "INSERT INTO tblsop_salesorder_header(CompanyID,WarehouseId,OrderNo,CustID,OrderDate,InvDesc,InvAddress1,InvAddress2,InvAddress3,InvCity,InvTown,InvPostCode,InvCountry, DelDesc,DelAddress1,DelAddress2,DelAddress3,DelCity,DelTown,DelPostCode,DelCountry, CustRef,Carrier,CarrierCharge,Comments,CommentsExternal,Totalgoods,ordergoods,Currency_Exchange_Rate,UserId,PinNo,UCodeId,Currency_Exchange_Code,TimeOfEntry,RepID,ReasonCode,OnlineUserID, OrderAnalysisCode1, OrderAnalysisCode2, OrderAnalysisCode3, OrderAnalysisCode4, OrderAnalysisCode5, AllowPartShipment, OrderType,`ContractRef`,`EmailID`,`ContactName`)  VALUES('" + cmpId + "','" + salesHead.WarehouseID + "'," + salesNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + salesHead.InvDesc + "','" + salesHead.InvAddress1 + "','" + salesHead.InvAddress2 + "','" + salesHead.InvAddress3 + "','" + salesHead.InvCity + "','" + salesHead.InvTown + "','" + salesHead.InvPostCode + "','" + salesHead.InvCountry + "','" + salesHead.DelDesc + "','" + salesHead.DelAddress1 + "','" + salesHead.DelAddress2 + "','" + salesHead.DelAddress3 + "','" + salesHead.DelCity + "','" + salesHead.DelTown + "','" + salesHead.DelPostCode + "','" + salesHead.DelCountry + "','" + salesHead.CustRef + "','" + salesHead.Carrier + "'," + salesHead.CarrierCharge + ",'" + salesHead.Comments + "','" + salesHead.CommentsExternal + "'," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).Total + "," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).gross + "," + salesHead.Currency_Exchange_Rate + ",'" + UserIDXref + "','" + salesHead.EmployeeID + "','" + salesHead.UCodeId + "','" + salesHead.Currency_Exchange_Code + "','" + DateTime.Now.ToString("hh:mm:ss") + "'," + salesHead.RepID + "," + 99 + ",'" + usrId + "','" + salesHead.NomCode + "','" + salesHead.NomCode1 +
                   "','" + salesHead.NomCode2 + "','" + salesHead.NomCode3 + "','" + salesHead.NomCode4 + "'," + partShipment + ",'" + salesHead.OrderType + "', '" + salesHead.ContractRef + "', '" + salesHead.EmailID + "','" + cntName + "')";
                    execVal = ExecuteQuery(conn, sSqry);
                    if (execVal > 0)
                    {
                        string orderFlg = editFlag ? "Edit Order" : "New Order";
                        OrderLog(Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, salesNo, salesHead.OrderType.ToUpper() + "-Start", salesHead.OrderType.ToUpper() + "- Header Saved Mode : " + orderFlg);
                        if (os == null)
                        {
                            oString = new StringBuilder();
                        }
                        else
                        {
                            oString = os;
                        }
                        budgetString = salesHead.OrderDate + "," + salesNo + "," + salesHead.EmployeeID + "," + usrId;
                        oString.AppendLine(budgetString);
                        os = oString;
                        if (salesHead.CustRef != "")
                        {
                            if (editFlag == false)
                            {
                                string sSQL = "SELECT * FROM tblsop_customer_ref WHERE CompanyID='" + cmpId + "' AND Custid='" + salesHead.CustID + "' AND Custref='" + salesHead.CustRef + "'";
                                try
                                {
                                    MySqlCommand cmd2 = new MySqlCommand(sSQL, conn);
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count == 0)
                                    {
                                        sSQL = "INSERT INTO tblsop_customer_ref (CompanyID,Custid,custref ) VALUES('" + cmpId + "','" + busId + "','" + salesHead.CustRef + "')";
                                        if (ExecuteQuery(conn, sSQL) == 0)
                                        {

                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    logger.Warn(e.Message);
                                    logger.Warn(e.StackTrace);
                                }
                                finally
                                {

                                }
                            }
                            else
                            {
                                //update
                            }
                        }
                        // saving salesorder lines
                        result = SavePrivaeOrderLines(conn, salesHead, salesNo, busId);
                        if (result == false)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                        }
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion
        public bool SavePrivaeOrderLines(MySqlConnection conn, SalesOrderHeaderViewModel saleHead, long saleno, string busId, bool isedit = false)
        {
            bool result = false;
            string sSQL = "";
            long returnOrderNo = 0;
            long returnOrderLine = 0;
            int DEL = 0;
            DEL = DeleteLines(saleHead.SalesOrderLine, saleHead.OrderType, conn, false);
            foreach (var line in saleHead.SalesOrderLine.Where(s => s.IsDleted == false))
            {
                if (line.OrdQty > 0)
                {
                    if (line.OriginalLineNo > 0 && saleHead.OrderType == "SO")
                    {
                        sSQL = "SELECT t2.OrderNo,t2.LineNo FROM tblsop_salesorder_detail t2 JOIN tblsop_salesorder_header t1 ON (t1.CompanyID=t2.CompanyID) AND (t1.OrderNo=t2.OrderNo)  WHERE t1.CompanyID='" + cmpId + "' AND t1.OrderType='RT'  AND t2.OriginalOrderNo=" + line.OriginalOrderNo + " AND t2.OriginalLineNo=" + line.OriginalLineNo + " ORDER BY t2.OrderNo DESC";
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand(sSQL, conn);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    returnOrderLine = Convert.ToInt32(dr["OrderNo"].ToString());
                                    returnOrderNo = Convert.ToInt32(dr["OrderNo"].ToString());
                                    line.ReturnLineNo = line.ReturnLineNo > 0 ? line.ReturnLineNo : returnOrderLine;
                                    line.ReturnOrderNo = line.ReturnOrderNo > 0 ? line.ReturnOrderNo : returnOrderNo;
                                    line.OriginalOrderNo = 0;
                                }
                            }
                            else
                            {
                                returnOrderLine = 0;
                                returnOrderNo = 0;
                                line.ReturnLineNo = line.ReturnLineNo > 0 ? line.ReturnLineNo : returnOrderLine;

                                line.ReturnOrderNo = line.ReturnOrderNo > 0 ? line.ReturnOrderNo : returnOrderNo;
                                line.OriginalOrderNo = 0;
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn(e.Message);
                            logger.Warn(e.StackTrace);
                        }
                    }
                    var orgLineno = line.OriginalLineNo == null | line.OriginalLineNo == 0 ? 0 : line.OriginalLineNo;
                    if (DEL > 0 | line.Isedit == false)
                    {
                        var delDate = DateTime.Parse(line.DeliveryDate).ToString("yyyy-MM-dd");
                        if (saleno == 0)
                        {
                            saleno = saleHead.OrderNo;
                        }

                        sSQL = "INSERT INTO tblsop_salesorder_detail (CompanyID, Warehouseid, OrderNo, LineNo,   LineType , StyleID, ColourID, SizeID,  Description, Price, OrdQty, AllQty, InvQty, DespQty,  CommissionRate, Deliverydate, VatCode, RepId, KamId, KAMrate, REPRate, Currency_Exchange_Rate,styleIDref,FreeText,Cost, IssueUOM, IssueQty,StockingUOM, NomCode, OriginalOrderNo, OriginalLineNo, AssemblyID, AsmLineNo, ReasonCode, ReturnOrderNo, ReturnLineNo, SOPDETAIL5, SOPDETAIL4)  VALUES('" + cmpId + "','" + saleHead.WarehouseID + "'," + saleno + "," + line.LineNo + ",1,'" + line.StyleID.Trim() + "','" + line.ColourID.Trim() + "','" + line.SizeID.Trim() + "','" + line.Description.Trim() + "'," + line.Price + "," + line.OrdQty + "," + line.AllQty + "," + line.InvQty + "," + line.InvQty + ",0,'" + delDate + "'," + line.VatCode1 + "," + line.RepId + "," + line.KAMID + "," + line.KAMRate1 + "," + line.RepRate1 + "," + line.Currency_Exchange_Rate + ",'" + line.StyleIDref + "','" + line.FreeText1 + "'," + line.Cost1 + "," + line.IssueUOM1 + "," + line.IssueQty1 + "," + line.StockingUOM1 + ",'" + line.NomCode + "'," + line.OriginalOrderNo + "," + orgLineno + "," + line.AssemblyID + "," + line.AsmLineNo + "," + line.ReasonCodeLine + "," + line.ReturnOrderNo + "," + line.ReturnLineNo + ",'" + line.SOPDetail5 + "','" + line.SOPDetail4 + "')";
                    }
                    else
                    {
                        sSQL = "Update tblsop_salesorder_detail set Price=" + line.Price + ", OrdQty=" + line.OrdQty + ", AllQty=" + line.AllQty + ", InvQty=" + line.InvQty + ", DespQty=" + line.InvQty + ", VatCode=" + line.VatCode1 + ", RepId=" + cmpId + ",styleIDref='" + line.StyleIDref + "',FreeText='" + line.FreeText1 + "',Cost=" + line.Cost1 + ", IssueQty=" + line.IssueQty1 + ",NomCode=" + line.NomCode + ", AssemblyID=" + line.AssemblyID + ", AsmLineNo=" + line.AsmLineNo + ", ReasonCode=" + line.ReasonCodeLine + ", ReturnOrderNo=" + line.ReturnOrderNo + ", ReturnLineNo=" + line.ReturnLineNo + ", SOPDETAIL5='" + line.SOPDetail5 + "', SOPDETAIL4='" + line.SOPDetail4 + "' Where OrderNo=" + line.OrderNo + " and LineNo=" + line.LineNo + " and  StyleID='" + line.StyleID.Trim() + "' and  ColourID='" + line.ColourID.Trim() + "' and SizeID='" + line.SizeID.Trim() + "' and   Description='" + line.Description.Trim() + "'";
                    }
                    if (ExecuteQuery(conn, sSQL) == 0)
                    {
                        if (sSQL.ToLower().Contains("update"))
                        {
                            result = true;
                        }
                        else { return false; };

                    }
                    else
                    {
                        result = true;
                    }

                }
            }
            if (saleHead.Reorderheader)
            {
                if (saleHead.SalesOrderLine.Count() == saleHead.SalesOrderLine.Where(s => s.IsDleted).Count())
                {
                    string delHeadSql = "delete from tblsop_salesorder_header where orderno = " + saleHead.OrderNo;
                    string DelReason = " INSERT INTO `tblonline_rejectorder_reasons`(Orderno,BusinessId,Employeeid,RejectedBy,RejectedDate,RejectedReason) VALUES(" + saleHead.OrderNo + ", '" + saleHead.CustID + "','" + saleHead.EmployeeID + "','System','" + saleHead.OrderDate + "','The reorder lines are deleted, So system removed Reorder header as well')";
                    ExecuteQuery(conn, delHeadSql);
                    ExecuteQuery(conn, DelReason);
                    result = true;
                }
            }
            return result;
        }
        #region  ShowPrivateOrders
        public List<PrivateOrderResultModel> ShowPrivateOrders(string access, string onlineuserId, string busId)
        {
            List<PrivateOrderResultModel> privateResult = new List<PrivateOrderResultModel>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                string sql = "";
                sql = sql + "SELECT DISTINCT CAST(t1.`OrderNo` AS CHAR) AS orderno,t1.`OrderDate` AS ODate,DATE_FORMAT(t1.`OrderDate`,'%d-%m-%Y')  AS orderdate,   `t1`.`TotalGoods` totalgoods, (`t1`.`OrderGoods` - `t1`.`TotalGoods`) AS `vat`, `t1`.`OrderGoods` ordergoods, CONCAT(t1.DelDesc, ' - ', CONCAT(t1.`DelAddress1`, ' ', t1.`DelAddress2`, ' ', t1.`DelAddress3`, ' ', t1.`DelTown`, ' ', t1.`DelCity`, ' ', t1.`DelCountry`, ' ', t1.`DelPostCode`)) AS `deliveryto`, `t2`.`txn_id` txnid, `t2`.`txn_Ip` txnip,`t2`.`rsp_date` AS paymentdate, DATE_FORMAT(`t2`.`rsp_date`, '%d-%m-%Y') AS responsedate, IF(ISNULL(`t2`.`rsp_status`), 'NON PAID', IF(UPPER(`t2`.`rsp_status`) = 'PENDING' OR UPPER(`t2`.`rsp_status`) = 'OK' OR UPPER(`t2`.`rsp_status`) = 'COMPLETED', IF(UPPER(`t2`.`rsp_status`) = 'PENDING', 'PENDING', 'PAID'), IF(UPPER(`t2`.`rsp_status`) = 'AUTHORISED', 'PAID', CONCAT('NON PAID - ', UPPER(`t2`.`rsp_status`))))) AS responsestatus, `t2`.`GatewayImg` ,  IF(ISNULL(`t2`.`txn_Ip`), '',`t2`.`GatewayName`) AS   gateway, t1.OnlineUserID employeeid, CONCAT(t3.ForeName, ' ', t3.SurName) AS employeename, t2.SeqNo FROM `view_privateorders` t1 LEFT JOIN (SELECT * FROM `view_privateorders_np` UNION ALL SELECT * FROM `view_privateorder_pendings`UNION ALL SELECT * FROM  `view_privateorders_paid`) t2 ON t1.`CompanyID`= t2.CompanyID AND t1.CustID = t2.CustID AND t1.`OrderNo`= t2.OrderNo JOIN tblusers t3 ON t1.`OnlineUserID`= t3.`UserName` WHERE t1.CompanyID = '001' AND t1.CustID = '" + busId + "'";
                if (access.ToLower() != "admin" && access.ToLower() != "manager")
                {
                    sql = sql + " AND t1.`OnlineUserID`= '" + onlineuserId + "' ";
                }
                sql = sql + " ORDER BY t2.SeqNo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    privateResult = dt.AsEnumerable().Select(s => new PrivateOrderResultModel
                    {
                        orderno = s["orderno"].ToString() != "" ? Convert.ToInt32(s["orderno"].ToString()) : 0,
                        orderdate = s["orderdate"].ToString(),
                        totalgoods = s["totalgoods"].ToString() != "" ? Convert.ToDouble(s["totalgoods"].ToString()) : 0,
                        deliveryto = s["deliveryto"].ToString(),
                        vat = s["vat"].ToString() != "" ? Convert.ToDouble(s["vat"].ToString()) : 0,
                        ordergoods = s["ordergoods"].ToString() != "" ? Convert.ToDouble(s["ordergoods"].ToString()) : 0,
                        txnid = s["txnid"].ToString(),
                        txnip = s["txnip"].ToString(),
                        responsedate = s["responsedate"].ToString(),
                        responsestatus = s["responsestatus"].ToString(),
                        gateway = s["gateway"].ToString(),
                        employeeid = s["employeeid"].ToString(),
                        employeename = s["employeename"].ToString(),
                        paymentdate = s["paymentdate"].ToString(),
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
                logger.Warn(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return privateResult;
        }
        #endregion
        #region  GetCardReport
        public List<CardReportModel> GetCardReport(string busId, string userID, string access)
        {
            var sbyteVale = Convert.ToSByte(false);
            var model = new List<CardReportModel>();
            string qry = "SELECT DISTINCT t1.`EmployeeID` empid,CONCAT(t1.`Forename`,' ',t1.`Surname`) empname,t1.`StartDate` startdate, t1.`EndDate` enddate,t2.`NextOrder` replenishmentdate,tss.ucodeData FROM `tblaccemp_employee` t1 JOIN `tblaccemp_employee_rollout` t2 ON t1.`BusinessID`= t2.`BusinessID` AND t1.`EmployeeID`= t2.`EmployeeID` JOIN `tblsop_salesorder_header` t3 ON t1.`BusinessID` = t3.`custid` AND t1.`EmployeeID`= t3.`PinNo` JOIN(SELECT te.`EmployeeID`,GROUP_CONCAT(CONCAT('Ucode :','<b>',te.`UCodeID`,'</b>',' ',';  Total points :','<b>',tu.`TotalPoints`,'</b>'))  ucodeData  FROM `tblaccemp_ucodesemployees` te JOIN  `tblaccemp_ucodepoints` tu ON te.`BusinessID`= tu.`BusinessID` AND te.`UCodeID`= tu.`UcodeID` GROUP BY te.`EmployeeID` ) tss ON t1.`EmployeeID`= tss.employeeid WHERE t1.`EmployeeClosed`=0";
            if (access.ToLower().Trim() != "manager" && access.ToLower().Trim() != "admin")
            {
                qry = qry + " AND t1.employeeid='" + userID.Trim() + "'";
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    model = dt.AsEnumerable().Select(s => new CardReportModel
                    {
                        ucodedata = s["ucodeData"].ToString(),
                        employeeid = s["empid"].ToString(),
                        employeename = s["empname"].ToString(),
                        startdate = s["startdate"].ToString() != "" ? Convert.ToDateTime(s["startdate"].ToString()).ToString("dd-MM-yyyy") : "",
                        enddate = s["enddate"].ToString() != "" ? Convert.ToDateTime(s["enddate"].ToString()).ToString("dd-MM-yyyy") : "",
                        replenishmentdate = s["replenishmentdate"].ToString() != "" ? Convert.ToDateTime(s["replenishmentdate"].ToString()).ToString("dd-MM-yyyy") : "",
                    }).ToList();
                }

            }
            catch (Exception e)
            {

            }
            finally
            {

            }
            return model;
        }
        #endregion

        #region  GetCardReport
        public List<CardReportModel> GetdetailCard(string empId, string busId, string cardType, bool pointsreq)
        {
            List<CardReportModel> model = new List<CardReportModel>();
            try
            {
                if (cardType.ToLower().Trim() == "stock")
                {
                    if (_stockCard.Exists(s => s.EmployeeID == empId && s.BusinessID == busId))
                    {
                        model = _stockCard.GetAll(s => s.EmployeeID == empId && s.BusinessID == busId).Select(s => new CardReportModel
                        {
                            styleid = s.StyleID,
                            colour = s.ColourID,
                            soqty = s.SOQty != null ? s.SOQty.Value : 0,
                            pickqty = s.PickQty != null ? s.PickQty.Value : 0,
                            invoiceqty = s.InvQty != null ? s.InvQty.Value : 0,
                            total = GetTotalRep(s.SOQty, s.PickQty, s.InvQty),
                            // lastissuedate = s.LastIssueDate != null ? s.LastIssueDate.Value.ToString("dd-MM-yyyy") : "",
                            firstissuedate = s.FirstIssueDate != null ? s.FirstIssueDate.Value.ToString("dd-MM-yyyy") : "",
                            // startissuedate = s.StartIssueDate != null ? s.StartIssueDate.Value.ToString("dd-MM-yyyy") : "",
                            year = s.Year == 0 ? "current" : s.Year == 1 ? "Last year" : s.Year > 1 && s.Year != 99 ? s.Year + " years older" : ""
                        }).ToList();
                    }
                }
                else if (cardType.ToLower().Trim() == "points" && pointsreq)
                {
                    model = _pointsCard.GetAll(s => s.EmployeeID == empId && s.BusinessID == busId).Select(s => new CardReportModel
                    {
                        styleid = s.StyleID,
                        colour = s.ColourID,
                        sopoints = s.SOPoints != null ? s.SOPoints.Value : 0,
                        pickpoints = s.PickPoints != null ? s.PickPoints.Value : 0,
                        invoicepoints = s.InvPoints != null ? s.InvPoints.Value : 0,
                        total = GetTotalRep(s.SOPoints, s.PickPoints, s.InvPoints),
                        //lastissuedate = s.LastIssueDate != null ? s.LastIssueDate.Value.ToString("dd-MM-yyyy") : "",
                        firstissuedate = s.FirstIssueDate != null ? s.FirstIssueDate.Value.ToString("dd-MM-yyyy") : "",
                        //startissuedate = s.StartIssueDate != null ? s.StartIssueDate.Value.ToString("dd-MM-yyyy") : "",
                        year = s.Year == 0 ? "current" : s.Year == 1 ? "Last year" : s.Year > 1 && s.Year != 99 ? s.Year + " years older" : ""
                    }).ToList();
                }
                model.ForEach(s => s.styledescription = _fskStyle.Exists(sa => sa.StyleID == s.styleid) ? _fskStyle.GetAll(sa => sa.StyleID == s.styleid).First().Description : "");
            }
            catch (Exception e)
            {

            }
            return model;
        }
        #endregion
        #region GetTotalRep
        public int GetTotalRep(int? so, int? pick, int? inv)
        {
            var so1 = so.HasValue ? so.Value : 0;
            var pick1 = pick.HasValue ? pick.Value : 0;
            var inv1 = inv.HasValue ? inv.Value : 0;
            return so1 + pick1 + inv1;
        }
        #endregion


        #region
        public List<OrderDisplayModel> GetAllOrderRPT(string empId, string CardType, string busid)
        {
            List<OrderDisplayModel> model = new List<OrderDisplayModel>();
            if (_salesHead.Exists(s => s.PinNo == empId && s.ReasonCode != 99))
            {

                var ucodeLst = _pointsByUcode.GetAll(s => s.BusinessID == busid).Select(s => s.UcodeID).Distinct().ToList();
                if (_salesHead.Exists(s => s.PinNo == empId && s.ReasonCode != 99 && ucodeLst.Contains(s.UCodeId)))
                {
                    var qry = CardType.ToLower() == "stock" ? getAllords(busid, empId, false) : getAllords(busid, empId, true);
                    MySqlConnection conn = new MySqlConnection(ConnectionString);
                    conn.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(qry, conn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            model = dt.AsEnumerable().Select(s => new OrderDisplayModel
                            {
                                OrderNo = s["OrderNo"].ToString() != null && s["OrderNo"].ToString() != "" ? Convert.ToInt32(s["OrderNo"].ToString()) : 0,
                                OrderDate = DateTime.Parse(s["OrderDate"].ToString()),
                                DelDesc = s["DelDesc"].ToString() != null && s["DelDesc"].ToString().ToString() != "" ? s["DelDesc"].ToString() : "",
                                Address1 = s["DelAddress1"].ToString() != null && s["DelAddress1"].ToString() != "" ? s["DelAddress1"].ToString() : "",
                                TotalQty = s["TotQty"].ToString() != null && s["TotQty"].ToString() != "" ? Convert.ToInt64(s["TotQty"].ToString()) : 0,
                                GoodsValue = s["OrderGoods"].ToString() != null && s["OrderGoods"].ToString() != "" ? Convert.ToDouble(s["OrderGoods"].ToString()) : 0,
                                TotalIncVat = s["TotalGoods"].ToString() != null && s["TotalGoods"].ToString() != "" ? Convert.ToDouble(s["TotalGoods"].ToString()) : 0,
                                UserId = s["OnlineUserID"].ToString() != null && s["OnlineUserID"].ToString() != "" ? s["OnlineUserID"].ToString() : "",
                                IsConfirmed = s["OnlineConfirm"].ToString() != null && s["OnlineConfirm"].ToString() != "" ? s["OnlineConfirm"].ToString() : "",
                                IsProcessed = s["OnlineProcessed"].ToString() != null && s["OnlineProcessed"].ToString() != "" ? s["OnlineProcessed"].ToString() : "",
                                CustomerRef = s["CustRef"].ToString() != null && s["CustRef"].ToString() != "" ? s["CustRef"].ToString() : "",
                                EmpID = s["Pinno"].ToString() != null && s["Pinno"].ToString() != "" ? s["Pinno"].ToString() : "",
                                PersonPackNo = s["manpackno"].ToString() != null && s["manpackno"].ToString() != "" ? Convert.ToInt32(s["manpackno"].ToString()) : 0,
                                EmpName = s["EmpName"].ToString() != null && s["EmpName"].ToString() != "" ? s["EmpName"].ToString() : "",
                                TotalPoints = s["TotalPoints"].ToString() != "" ? Convert.ToInt32(s["TotalPoints"].ToString()) : 0,
                                NominalCode = s["OrderAnalysisCode4"].ToString() != "" ? s["OrderAnalysisCode4"].ToString() : "",
                                PointsSpent = s["OrderPoints"].ToString() != "" ? Convert.ToInt32(s["OrderPoints"].ToString()) : 0,
                                OrderType = s["ordertype"].ToString() != "" ? s["ordertype"].ToString() : "",
                                UCODEID = s["ucodeid"].ToString()
                            }).ToList();
                            var matUcodes = _ucodeReason.Exists(s => s.BusinessID == busid && s.UcodeId.ToLower().Contains("maternity")) ? _ucodeReason.GetAll(s => s.BusinessID == busid && s.UcodeId.ToLower().Contains("maternity")).Select(s => s.UcodeId).ToList() : new List<string>();
                            var emergencyucode = _ucodeReason.Exists(s => s.BusinessID == busid && s.UcodeId.ToLower().Contains("matern") == false) ? _ucodeReason.GetAll(s => s.BusinessID == busid && s.UcodeId.ToLower().Contains("matern") == false).Select(s => s.UcodeId).ToList() : new List<string>();
                            if (model.Any(s => s.RtnOrdNo > 0 || s.NominalCode == "" && s.CustomerRef.ToLower().Contains("private") == false && matUcodes.Contains(s.UCODEID) == false && emergencyucode.Contains(s.UCODEID)))
                            {
                                model.Where(s => s.RtnOrdNo > 0 || s.NominalCode == "" && s.CustomerRef.ToLower().Contains("private") == false && matUcodes.Contains(s.UCODEID) == false && emergencyucode.Contains(s.UCODEID)).ToList().ForEach(s => s.OrderType = "Emergency order");
                            }
                            else if (model.Any(s => matUcodes.Contains(s.UCODEID)))
                            {
                                model.Where(s => matUcodes.Contains(s.UCODEID)).ToList().ForEach(s => s.OrderType = "Maternity order");
                            }

                            model.Where(s => s.NominalCode.ToLower() != "" || (s.NominalCode == "" && emergencyucode.Contains(s.UCODEID)) == false && s.OrderType.ToLower() == "so").ToList().ForEach(s => s.OrderType = "Rollout order");
                            model.Where(s => s.OrderType.ToLower() == "rt").ToList().ForEach(s => s.OrderType = "Return order");

                        }

                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return model;
        }

        #endregion


        #region getshowallordQry()
        public string getAllords(string busId, string empid, bool bootpts, string role = "Admin")
        {
            string strsql = "";
            int EmployeeRenewDays = 0;
            if (EmployeeRenewDays == 0)
            {
                int value = (Convert.ToInt32(BusinessParam("EmployeeRenew", busId)) / 12);
                EmployeeRenewDays = value * 365;
            }
            strsql = "SELECT h.OrderNo,h.ucodeid, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1,IF(isnull(SUM(d.OrdQty)),0,SUM(d.OrdQty)) AS TotQty, h.OrderGoods, h.TotalGoods, h.OnlineUserID, IF(h.OnlineConfirm = 0, 'No', 'Yes') AS OnlineConfirm, IF(h.OnlineProcessed = 0, 'No', 'Yes') AS OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno, IF(ISNULL(m.ManPackNo), 0, m.ManPackNo) manpackno, CONCAT(e.Forename, ' ', e.Surname) AS EmpName, IF( ISNULL(h.Comments) OR h.Comments = '', '~~~', h.Comments ) AS OrdComments, h.OrderAnalysisCode4, IF(isnull(MAX(d.sopdetail5)),0,MAX(d.sopdetail5)) AS sop,h.ordertype ,  IF(isnull(ci.DespatchDate),'',ci.DespatchDate), IF(isnull(ci.CourierRef),'',ci.CourierRef)";
            if (bootpts)
            {
                strsql += ", ucp.TotalPoints, SUM(d.`OrdQty` * t2.`Points`) OrderPoints";
            }
            else
            {
                strsql += ", 0 AS TotalPoints, 0 AS OrderPoints ";
            }
            strsql += ",MAX(IF(ISNULL(d.`ReturnOrderNo`),0,d.`ReturnOrderNo`)) RtnOrder ";
            strsql += "from tblsop_salesorder_header h LEFT JOIN tblsop_salesorder_detail d ON h.`CompanyID` = d.`CompanyID` AND h.`OrderNo` = d.`OrderNo` LEFT JOIN `tblaccemp_stylepoints` t2 ON d.`StyleID` = t2.`StyleID` AND d.`CompanyID` = t2.`CompanyID` AND d.`ColourID` = t2.`ColourID` AND h.`UCodeId` = t2.`UcodeID` AND h.`CustID` = t2.`BusinessID` LEFT JOIN tblbus_business b ON h.CustID = b.BusinessID AND h.companyid = b.companyid LEFT JOIN tblsop_manpackorders m ON h.CompanyID = m.CompanyID AND h.OrderNo = m.OrderNo";
            strsql += " LEFT JOIN tblaccemp_employee e ON h.CompanyID=e.CompanyID AND h.CustID=e.BusinessID AND h.Pinno=e.EmployeeID LEFT JOIN tblonline_emp_address ea ON (e.EmployeeID = ea.EmployeeID) AND (e.`BusinessID` = ea.EmployeeID) AND (e.`CompanyID` = ea.`Companyid`)  LEFT JOIN tblbus_address ba ON (ea.AddressID = ba.AddressID) AND (ea.BusinessID = ba.BusinessID) AND (ea.`Companyid` = ba.`CompanyID`) ";
            strsql += "LEFT JOIN ( SELECT CompanyID,CustID,OrderNo,GROUP_CONCAT(Date_Format(DespatchDate,'%d-%m-%Y')) DespatchDate,GROUP_CONCAT(CourierRef) CourierRef FROM tblsop_courier_information GROUP BY orderno ) ci ON h.`CompanyID` = ci.`CompanyID` AND h.`OrderNo` = ci.`OrderNo` AND h.`CustID` = ci.CustID";
            if (bootpts)
            {
                strsql = strsql + " LEFT JOIN tblaccemp_ucodepoints ucp ON h.CompanyID = ucp.CompanyID AND h.CustID = ucp.BusinessID AND h.UcodeID = ucp.UcodeID";
            }
            strsql += " WHERE h.CompanyID='" + cmpId + "' AND h.CustID='" + busId + "' and h.pinno='" + empid + "' ";
            if (bootpts)
            {
                var ptsUcode = _pointsByUcode.GetAll(s => s.BusinessID == busId).Select(s => s.UcodeID).ToList();
                var list = "'" + string.Join("','", ptsUcode) + "'";
                strsql += " and h.ucodeid in (" + list + ")";
            }

            strsql += "GROUP BY h.OrderNo, h.OrderDate, b.Name, h.DelDesc, h.DelAddress1, h.OrderGoods, h.TotalGoods, h.OnlineUserID, OnlineConfirm, OnlineProcessed, h.CompanyID, h.CustID, h.CustRef, h.OrderAnalysisCode1, h.Pinno, EmpName, OrdComments, h.OrderAnalysisCode4";
            if (bootpts)
            {
                strsql += ", ucp.TotalPoints";
            }

            strsql += " ORDER BY h.OrderNo DESC";

            return strsql;
        }
        #endregion
        #region  GetExporterData
        public List<CardReportModel> GetExporterData(string CardType, string userId, string access)
        {
            var model = new List<CardReportModel>();
            string tablename = "";
            string qry = "";
            qry = qry + "SELECT t1.`EmployeeID` employeeid, CONCAT(t1.`Forename`, ' ', t1.`Surname`) employeename, t1.`StartDate` startdate, t1.`EndDate` enddate, t2.`StyleID` styleid,t2.`ColourID` colour, IF(t2.`Year`= 0, 'Current', IF(t2.`Year`= 1, 'Last year', CONCAT(t2.`Year`, ' ', 'years older'))) year";

            if (CardType.ToLower().Trim() == "points")
            {
                tablename = "`tblaccemp_pointscard`";
                qry = qry + ",t2.`SOPoints` sopoints, t2.`InvPoints` invoicepoints, t2.`PickPoints` pickpoints,( IF(ISNULL( t2.`SOPoints`),0, t2.`SOPoints`)+IF(ISNULL(t2.`InvPoints`),0,t2.`InvPoints`) + IF(ISNULL(t2.`PickPoints`),0,t2.`PickPoints`) ) total,";

            }
            else
            {
                tablename = "`tblaccemp_stockcard`";
                qry = qry + ",t2.`soqty` soqty, t2.`invqty` invoiceqty, t2.`pickqty` pickqty,(IF(ISNULL( t2.`soqty`),0, t2.`soqty`)  + IF(ISNULL(t2.`invqty`),0,t2.`invqty`)+ IF(ISNULL( t2.`pickqty`),0,  t2.`pickqty`)) total,";
            }
            qry = qry + "t2.`FirstIssueDate` firstissuedate, t2.`LastIssueDate` lastissuedate, t2.`StartIssueDate` startissuedate FROM `tblaccemp_employee` t1 RIGHT JOIN " + tablename + " t2 ON t1.`BusinessID`= t2.`BusinessID` AND t1.`EmployeeID`= t2.`EmployeeID` AND t1.`EmployeeClosed`= 0";
            if (access.ToLower() != "manager" && access.ToLower() != "admin")
            {
                qry = qry + " where  t1.`EmployeeID`='" + userId + "'";
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    model = dt.AsEnumerable().Select(s => new CardReportModel
                    {
                        colour = s["colour"].ToString(),
                        employeeid = s["employeeid"].ToString(),
                        employeename = s["employeename"].ToString(),
                        enddate = s["enddate"].ToString(),
                        firstissuedate = s["firstissuedate"].ToString(),
                        intyear = 0,
                        invoicepoints = CardType.ToLower().Trim() == "stock" ? 0 : s["invoicepoints"].ToString() != "" ? Convert.ToInt32(s["invoicepoints"].ToString()) : 0,
                        invoiceqty = CardType.ToLower().Trim() == "stock" ? s["invoiceqty"].ToString() != "" ? Convert.ToInt32(s["invoiceqty"].ToString()) : 0 : 0,
                        lastissuedate = s["lastissuedate"].ToString(),
                        pickpoints = CardType.ToLower().Trim() == "stock" ? 0 : s["pickpoints"].ToString() != "" ? Convert.ToInt32(s["pickpoints"].ToString()) : 0,
                        pickqty = CardType.ToLower().Trim() == "stock" ? s["pickqty"].ToString() != "" ? Convert.ToInt32(s["pickqty"].ToString()) : 0 : 0,
                        // replenishmentdate = s["replenishmentdate"].ToString(),
                        sopoints = CardType.ToLower().Trim() == "stock" ? 0 : s["sopoints"].ToString() != "" ? Convert.ToInt32(s["sopoints"].ToString()) : 0,
                        soqty = CardType.ToLower().Trim() == "stock" ? s["soqty"].ToString() != "" ? Convert.ToInt32(s["soqty"].ToString()) : 0 : 0,
                        startdate = s["startdate"].ToString(),
                        startissuedate = s["startissuedate"].ToString(),
                        styleid = s["styleid"].ToString(),
                        total = CardType.ToLower().Trim() == "stock" ? s["total"].ToString() != "" ? Convert.ToInt32(s["total"].ToString()) : 0 : 0,
                        year = s["year"].ToString(),
                    }).ToList();
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return model;
        }

        #endregion

        #region 
        public List<CardByStyle> GetOrderLinesBystyle(string styleid, string empid, string CardType)
        {
            List<CardByStyle> models = new List<CardByStyle>();
            string qry = "";

            qry = "SELECT t2.orderno,t2.orderdate orderdate,t2.`PinNo` empid,t2.ucodeid,IF(t2.`OrderType`='SO','Rollout order','Return order') ot,t1.`StyleID` styleid, t1.`ColourID` colourid, t1.`SizeID` sizeid, t1.`OrdQty` ordqty   FROM tblsop_salesorder_detail t1 JOIN tblsop_salesorder_header t2 ON t1.`CompanyID`=t2.`CompanyID` AND t1.`OrderNo`=t2.`OrderNo`  WHERE t1.`StyleID`='" + styleid + "' AND t2.`PinNo`='" + empid + "'";
            if (CardType.ToLower() == "points")
            {
                qry = qry + " AND t2.ucodeid    IN (SELECT DISTINCT ucodeid FROM  `tblaccemp_ucodepoints`)";
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    models = dt.AsEnumerable().Select(s => new CardByStyle
                    {
                        orderno = s["orderno"].ToString() != "" ? Convert.ToInt32(s["orderno"].ToString()) : 0,
                        orderdate = s["orderdate"].ToString(),
                        colourid = s["colourid"].ToString(),
                        styleid = s["styleid"].ToString(),
                        sizeid = s["sizeid"].ToString(),
                        empid = s["empid"].ToString(),
                        ucode = s["ucodeid"].ToString(),
                        ordertype = s["ot"].ToString(),
                        ordqty = s["ordqty"].ToString() != "" ? Convert.ToInt32(s["ordqty"].ToString()) : 0,
                    }).ToList();
                    models.ForEach(s => s.points = _stylePoints.Exists(sa => sa.StyleID == s.styleid) ? _stylePoints.GetAll(sa => sa.StyleID == s.styleid).First().Points.Value * s.ordqty : 0);
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                conn.Close();
            }
            return models;
        }
        #endregion
        public bool IsMatUcodeId(string ucode, string busid)
        {
            var matCodes = _ucodeReason.Exists(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY") ? string.Join(",", _ucodeReason.GetAll(s => s.UcodeId == "BAR MATERNITY P" | s.UcodeId == "BAR MATERNITY F" | s.UcodeId == "BAR MATERNITY").Select(s => s.UcodeId.ToLower().Trim().ToString()).ToList()) : "";
            return matCodes.Contains(ucode.ToLower().Trim()) && _pointsByUcode.Exists(s => s.BusinessID == busid && s.UcodeID == ucode.ToLower().Trim()) && ucode != "" ? true : false;
        }

        #region CreditreturnPoints
        public string CreditreturnPoints(int orderno, string onlineUser)
        {
            var result = "";
            string rtnDetQry = "";
            string reordLinesStr = "";
            int totalpoints = 0;
            string insertQry = "";
            List<string> reordLines = _salesDetail.Exists(s => s.ReturnOrderNo == orderno) ? _salesDetail.GetAll(s => s.ReturnOrderNo == orderno).Select(s => s.ReturnLineNo.Value.ToString()).ToList() : new List<string>();
            reordLinesStr = string.Join(",", reordLines);
            var salesHead = _salesHead.Exists(s => s.OrderNo == orderno) ? _salesHead.GetAll(s => s.OrderNo == orderno).First() : new tblsop_salesorder_header();
            rtnDetQry = reordLinesStr == "" ? "Select lineno,orderno,styleid,colourid,sizeid,ordqty from tblsop_Salesorder_detail where orderno =" + orderno + " " : "Select lineno,orderno,styleid,colourid,sizeid,ordqty from tblsop_Salesorder_detail where orderno =" + orderno + " and lineno not in(" + reordLinesStr + ")";
            if (orderno > 0 && salesHead.OnlineConfirm == 1)
            {
                MySqlTransaction trans;
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    //salesHead
                    MySqlCommand headCmd = new MySqlCommand(rtnDetQry, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(headCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (var data in dt.AsEnumerable().Select(s => new SalesOrderLineViewModel { OrderNo = s["orderno"].ToString() != "" ? Convert.ToInt64(s["orderno"].ToString()) : 0, LineNo = s["lineno"].ToString() != "" ? Convert.ToInt32(s["lineno"].ToString()) : 0, StyleID = s["styleid"].ToString(), ColourID = s["colourid"].ToString(), SizeID = s["sizeid"].ToString(), OrdQty = s["ordqty"].ToString() != "" ? Convert.ToInt32(s["ordqty"].ToString()) : 0 }))
                        {
                            if (CreditReturns(data, conn, salesHead.PinNo) == false)
                            {

                                result = "";
                                break;
                            }
                            else
                            {
                                if (data.StyleID != "")
                                {
                                    int stylePts = _stylePoints.Exists(s => s.StyleID.Trim().ToLower() == data.StyleID.Trim().ToLower()) ? _stylePoints.GetAll(s => s.StyleID.Trim().ToLower() == data.StyleID.Trim().ToLower()).First().Points.Value : 0;
                                    if (stylePts > 0)
                                    {
                                        totalpoints = totalpoints + (Convert.ToInt32(data.OrdQty) * stylePts);
                                    }
                                }
                                result = "success";
                            }
                        }
                        if (totalpoints > 0)
                        {
                            insertQry = insertQry + "insert into tblsop_return_credited(companyid,businessid,orderno,crediteddate,userid,employeeid,totalpoints) values ('" + cmpId + "','" + salesHead.CustID + "'," + orderno + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + onlineUser + "','" + salesHead.PinNo + "'," + totalpoints + ")";
                            if (ExecuteQuery(conn, insertQry) > 0)
                            {
                                result = "success";
                            }
                            else
                            {
                                result = "";
                            }
                        }
                        else
                        {
                            result = "";
                        }
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    if (result == "")
                    {
                        trans.Rollback();
                    }
                    else
                    {
                        trans.Commit();
                    }

                    conn.Close();
                }
            }
            return result;
        }

        public bool CreditReturns(SalesOrderLineViewModel saleLine, MySqlConnection conn, string empID)
        {
            bool result = false;
            int stylePts = 0;
            string stkCardqry = "", ptsCardQry = "";
            if (saleLine.OrderNo > 0 && saleLine.LineNo > 0 && saleLine.OrdQty > 0)
            {
                try
                {
                    if (saleLine.StyleID != "")
                    {
                        stylePts = _stylePoints.Exists(s => s.StyleID.Trim().ToLower() == saleLine.StyleID.Trim().ToLower()) ? _stylePoints.GetAll(s => s.StyleID.Trim().ToLower() == saleLine.StyleID.Trim().ToLower()).First().Points.Value : 0;
                        if (stylePts > 0)
                        {
                            stkCardqry = "Update tblaccemp_stockcard set soqty=soqty-(" + saleLine.OrdQty + ") where styleid='" + saleLine.StyleID + "' and colourid='" + saleLine.ColourID + "' and employeeid='" + empID + "' and year=0";
                            ptsCardQry = "Update tblaccemp_pointscard set sopoints=sopoints-(" + saleLine.OrdQty * stylePts + ") where styleid='" + saleLine.StyleID + "' and colourid='" + saleLine.ColourID + "' and employeeid='" + empID + "' and year=0";
                            if (ExecuteQuery(conn, stkCardqry) >= 0)
                            {
                                if (ExecuteQuery(conn, ptsCardQry) >= 0)
                                {
                                    result = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region getdatatble with trans 
        //create on (18-05-21)
        public DataTable GetDataTableTrans(string sql, MySqlConnection conn)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        #endregion


        #region ExecutePassList
        public bool ExecutePassList(List<string> passLst, string busId, string type, MySqlConnection conn)
        {
            var result = false;
            if (passLst.Count > 0 && type != "")
            {
                string sql = "";
                string dynamic = type.ToLower().Trim().Contains("adr") ? string.Join(",", passLst) : "'" + string.Join("','", passLst) + "'";
                bool rslt = false;

                if (type.ToLower().Trim().Contains("usr"))
                {

                    sql = "UPDATE tblUsers SET Active='N'  WHERE UserName NOT IN (" + dynamic + ") AND BusinessID='" + busId + "' AND AccessID<>'Admin'";
                    result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                }
                else if (type.ToLower().Trim().Contains("emp"))
                {
                    sql = "UPDATE tblaccemp_employee SET EmployeeClosed=1 WHERE EmployeeID NOT IN (" + dynamic + ") AND BusinessID='" + busId + "'";
                    var userCreate = Convert.ToBoolean(BusinessParam("IGNORE_USER_CREATE", busId));
                    result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                    if (!userCreate && result)
                    {
                        sql = "";
                        sql = "UPDATE tblUsers SET Active='N' WHERE UserName NOT IN (" + dynamic + ") AND BusinessID='" + busId + "' AND AccessID='User'";
                        result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                    }
                }
                else if (type.ToLower().Trim().Contains("adr"))
                {
                    sql = "DELETE FROM `tblbus_contact`   WHERE `ContactType_ID` IN (1,3,6,7) AND ContactID IN (SELECT ContactID FROM tblbus_address WHERE CompanyID='" + cmpId + "' AND BusinessID='" + busId + "' AND AddressID NOT IN (" + dynamic + "))";
                    result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                    if (result)
                    {
                        sql = "";
                        sql = "DELETE FROM tblbus_address WHERE CompanyID='" + cmpId + "' AND BusinessID='" + busId + "' AND AddressTypeID=3 AND AddressID NOT IN (" + dynamic + ")";
                        result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                    }
                }
            }
            return result;
        }
        #endregion
        #region SaveImportedUser
        public bool SaveImportedUser(UserImportModel emp, MySqlConnection conn)
        {
            bool result = false;
            string usersql = "", pmsnUsrsql = "", pmsnUsrDel = "";

            pmsnUsrsql = "";
            usersql = "INSERT INTO `tblusers`(`UserName`,`Password`,`ForeName`,`SurName`,`AccessID`,`Active`,`BusinessID`,`CreateDate`,`Email_ID`,`AspUserID`,`BusinessName`) values('" + emp.USERNAME + "','" + emp.Password + "','" + emp.FORENAME + "','" + emp.SURNAME + "','" + emp.ROLE + "','" + emp.ACTIVE + "','" + emp.BusiD + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + emp.EMAILID + "','" + emp.AspUserID + "','" + emp.BusiD + "')ON DUPLICATE KEY UPDATE ForeName='" + emp.FORENAME + "', SurName='" + emp.SURNAME + "', AccessID='" + emp.ROLE + "', Active='" + emp.ACTIVE + "',Email_ID='"+emp.EMAILID+"' ";

            if (ExecuteQuery(conn, usersql) > 0)
            {
                pmsnUsrDel = "DELETE FROM `tblpermission_users_allow` WHERE BusinessID='" + emp.BusiD + "' AND `AllowUser`='" + emp.USERNAME + "'";
                if (ExecuteQuery(conn, pmsnUsrDel) >= 0)
                {
                    foreach (var data in emp.MAPTOlst)
                    {
                        pmsnUsrsql = "INSERT INTO tblpermission_users_allow(CompanyID,BusinessID,UserID,AllowUser) VALUES ('" + cmpId + "','" + emp.BusiD + "','" + emp.USERNAME + "','" + data + "')  ON DUPLICATE KEY UPDATE UserID='" + emp.USERNAME + "', AllowUser='" + data + "'";
                        if (ExecuteQuery(conn, pmsnUsrsql) > 0)
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region enableDept
        public bool enableDept(string busid)
        {
            bool result = false;
            result = _departments.GetAll(s => s.BusinessID == busid).Count() > 0 ? true : false;
            return result;
        }
        #endregion

        #region
        public int GetAutono(string fieldName, string TblName, MySqlConnection conn)
        {
            string sql = "select autonumber from tblgen_autonumbers where fieldname ='" + fieldName + "' and tablename='" + TblName + "'";
            var result = GetScalarTrans(sql, conn);
            return result != "" ? Convert.ToInt32(result) : 0;
        }
        #endregion


        #region   SaveImportedAddress
        public SaveResultModel SaveImportedAddress(AddressImportModel address, MySqlConnection conn)
        {
            SaveResultModel rtnResult = new SaveResultModel();
            string addressIns = "";
            bool result = false;
            string usersql = "", onlineUsrsql = "";
            List<long> addrID = new List<long>();
            onlineUsrsql = "";
            string cntQry = "", telphoneQry = "", emailQry = "", cntNam = "", cc = "", cntExt = "";
            address.ADDRESSID = address.ADDRESSID > 0 ? address.ADDRESSID : GetAutono("AddressID", "tblbus_address_online", conn);
            address.CONTACTID = address.CONTACTID > 0 ? address.CONTACTID : GetAutono("ContactID", "tblbus_contact_online", conn);
            DataTable dt = new DataTable();
            addressIns = "INSERT INTO tblbus_address(CompanyID,BusinessID,AddressID,Description,Address1,Address2,Address3,Town,City,PostCode,CountryCode,AddressTypeID,ContactID) VALUES ('" + cmpId + "','" + address.BUSINESSID + "'," + address.ADDRESSID + ",'" + address.DESCRIPTION + "','" + address.ADDRESS1 + "', '" + address.ADDRESS2 + "','" + address.ADDRESS3 + "','" + address.TOWN + "','" + address.CITYCOUNTY + "','" + address.POSTCODE + "',0,3," + address.CONTACTID + ") ON DUPLICATE KEY UPDATE Description='" + address.DESCRIPTION + "', Address1='" + address.ADDRESS1 + "', Address2='" + address.ADDRESS2 + "',  Address3='" + address.ADDRESS3 + "', Town='" + address.TOWN + "', City='" + address.CITYCOUNTY + "', PostCode='" + address.POSTCODE + "', ContactID=" + address.CONTACTID;
            result = ExecuteQuery(conn, addressIns) >= 0 ? true : false;
            if (result)
            {
                cntExt = "";
                //cntExt = ""SELECT* FROM tblBus_Contact WHERE ContactID = '" & ContactID & "' AND ContactType_ID = 1 AND `Value`= '" & ph.Trim & "'"";
                if (address.TELEPHONElst != null)
                {
                    foreach (var data in address.TELEPHONElst)
                    {
                        if (data != "" && data != null)
                        {
                            var Cntdata = _cntRef.Exists(s => s.Name.ToLower().Contains("tele")) ? _cntRef.GetAll(s => s.Name.ToLower().Contains("tele")).First().ContactType_ID : 1;

                            cntExt = "SELECT* FROM tblBus_Contact WHERE ContactID = '" + address.CONTACTID + "' AND ContactType_ID = " + Cntdata + " AND `Value`= '" + data + "'";
                            dt = GetDataTableTrans(cntExt, conn);
                            if (dt.Rows.Count == 0)
                            {
                                telphoneQry = "INSERT INTO tblBus_Contact (ContactID, ContactType_ID, Value)  VALUES (" + address.CONTACTID + "," + Cntdata + " ,'" + data + "')  ON DUPLICATE KEY UPDATE Value='" + data + "'";
                                result = ExecuteQuery(conn, telphoneQry) > 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                var cnt = GetDataTableTrans(cntExt, conn).AsEnumerable().Select(s => new AddressImportModel { CONTACTID = s["ID"].ToString() != "" ? Convert.ToInt32(s["ContactID"].ToString()) : 0 }).First();
                                telphoneQry = "UPDATE tblBus_Contact SET ContactID =" + address.CONTACTID + ", ContactType_ID=" + Cntdata + " , Value ='" + data + "'  WHERE ID=" + cnt.CONTACTID;
                                result = ExecuteQuery(conn, telphoneQry) >= 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (result && address.EMAILlst != null)
                {
                    foreach (var data in address.EMAILlst)
                    {
                        if (data != "" && data != null)
                        {
                            var Cntdata = _cntRef.Exists(s => s.Name.ToLower().Contains("emai")) ? _cntRef.GetAll(s => s.Name.ToLower().Contains("emai")).First().ContactType_ID : 3;
                            cntExt = "SELECT* FROM tblBus_Contact WHERE ContactID = '" + address.CONTACTID + "' AND ContactType_ID = " + Cntdata + " AND `Value`= '" + data + "'";
                            dt = GetDataTableTrans(cntExt, conn);
                            if (dt.Rows.Count == 0)
                            {
                                emailQry = "INSERT INTO tblBus_Contact (ContactID, ContactType_ID, Value)  VALUES (" + address.CONTACTID + ", " + Cntdata + " ,'" + data + "')  ON DUPLICATE KEY UPDATE Value='" + data + "'";
                                result = ExecuteQuery(conn, emailQry) > 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                var cnt = dt.AsEnumerable().Select(s => new AddressImportModel { CONTACTID = s["ID"].ToString() != "" ? Convert.ToInt32(s["ContactID"].ToString()) : 0 }).First();
                                emailQry = "UPDATE tblBus_Contact SET ContactID =" + address.CONTACTID + ", ContactType_ID=" + Cntdata + " , Value ='" + data + "'  WHERE ID=" + cnt.CONTACTID;
                                result = ExecuteQuery(conn, emailQry) >= 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                if (result && address.CONTACTNAMElst != null)
                {
                    foreach (var data in address.CONTACTNAMElst)
                    {
                        if (data != "" && data != null)
                        {
                            var Cntdata = _cntRef.Exists(s => s.Name.ToLower().Contains("contactname")) ? _cntRef.GetAll(s => s.Name.ToLower().Contains("contactname")).First().ContactType_ID : 6;
                            cntExt = "SELECT* FROM tblBus_Contact WHERE ContactID = '" + address.CONTACTID + "' AND ContactType_ID = " + Cntdata + " AND `Value`= '" + data + "'";
                            dt = GetDataTableTrans(cntExt, conn);
                            if (dt.Rows.Count == 0)
                            {
                                cntNam = "INSERT INTO tblBus_Contact (ContactID, ContactType_ID, Value)  VALUES (" + address.CONTACTID + "," + Cntdata + " ,'" + data + "')  ON DUPLICATE KEY UPDATE Value='" + data + "'";
                                result = ExecuteQuery(conn, cntNam) > 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                var cnt = dt.AsEnumerable().Select(s => new AddressImportModel { CONTACTID = s["ID"].ToString() != "" ? Convert.ToInt32(s["ContactID"].ToString()) : 0 }).First();
                                cntNam = "UPDATE tblBus_Contact SET ContactID =" + address.CONTACTID + ", ContactType_ID=" + Cntdata + " , Value ='" + data + "'  WHERE ID=" + cnt.CONTACTID;
                                result = ExecuteQuery(conn, cntNam) >= 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                        }
                    }

                }
                if (result && address.COSTCENTERlst != null)
                {
                    foreach (var data in address.COSTCENTERlst)
                    {
                        if (data != "" && data != null)
                        {
                            var Cntdata = _cntRef.Exists(s => s.Name.ToLower().Contains("order reference")) ? _cntRef.GetAll(s => s.Name.ToLower().Contains("order reference")).First().ContactType_ID : 6;
                            cntExt = "SELECT* FROM tblBus_Contact WHERE ContactID = '" + address.CONTACTID + "' AND ContactType_ID =" + Cntdata + "  AND `Value`= '" + data + "'";
                            dt = GetDataTableTrans(cntExt, conn);
                            if (dt.Rows.Count == 0)
                            {
                                cc = "INSERT INTO tblBus_Contact (ContactID, ContactType_ID, Value)  VALUES (" + address.CONTACTID + "," + Cntdata + " ,'" + data + "')  ON DUPLICATE KEY UPDATE Value='" + data + "'";
                                result = ExecuteQuery(conn, cc) > 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                var cnt = dt.AsEnumerable().Select(s => new AddressImportModel { CONTACTID = s["ID"].ToString() != "" ? Convert.ToInt32(s["ContactID"].ToString()) : 0 }).First();
                                cc = "UPDATE tblBus_Contact SET ContactID =" + address.CONTACTID + ", ContactType_ID=" + Cntdata + " , Value ='" + data + "'  WHERE ID=" + cnt.CONTACTID;
                                result = ExecuteQuery(conn, cc) >= 0 ? true : false;
                                if (result == false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if (result && address.MAPTOlst != null)
                {
                    foreach (var data in address.MAPTOlst)
                    {
                        if (data != "" && data != null)
                        {
                            string sql = "INSERT INTO tblonline_emp_address(CompanyID,BusinessID,OnlineUserID,EmployeeID,AddressID)  VALUES ('" + cmpId + "','" + address.BUSINESSID + "','" + data.Trim() + "',''," + address.ADDRESSID + ")  ON DUPLICATE KEY UPDATE AddressID=" + address.ADDRESSID + ", BusinessID='" + address.BUSINESSID + "'";
                            result = ExecuteQuery(conn, sql) >= 0 ? true : false;
                            if (result == false)
                            {
                                break;
                            }
                        }
                    }
                }
                if (result && address.ADDRESSID > 0 && address.CONTACTID > 0)
                {
                    string addrQru, contQry = "";
                    long addIDupd = address.ADDRESSID + 1;
                    long cntIDupd = address.CONTACTID + 1;
                    addrQru = "update tblgen_autonumbers set autonumber=" + addIDupd + " where fieldname ='AddressID' and tablename='tblbus_address_online'";
                    contQry = "update tblgen_autonumbers set autonumber=" + cntIDupd + " where fieldname ='ContactID' and tablename='tblbus_contact_online'";
                    if (ExecuteQuery(conn, addrQru) >= 0)
                    {
                        result = ExecuteQuery(conn, contQry) >= 0 ? true : false;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (result)
            {
                rtnResult.result = result;
                rtnResult.addrId = address.ADDRESSID;
            }
            return rtnResult;
        }

        #endregion

        #region SaveImportedEmployee
        public bool SaveImportedEmployee(EmployeeImportModel emp, MySqlConnection conn, bool userCreate, string rndPwd, bool isnew = false)
        {
            bool result = false;
            string usrCreateQry = "";
            string employeeInsert = "", EmpDel = "", onlineUsrIns = "", ucodeQry = "", addrQry = "";

            if (enableDept(emp.BusId))
            {
                emp.DEPARTMENTID = emp.DEPARTMENT == "" ? _departments.Exists(s => s.Department.ToLower().Trim() == "default") ? _departments.GetAll(s => s.Department.ToLower().Trim() == "default").First().DepartmentID : 0 : 0;
            }

            if (isnew)
            {
                EmpDel = "UPDATE tblaccemp_employee SET EmployeeClosed=1 WHERE  CompanyID='" + cmpId + "' AND BusinessID='" + emp.BusId + "' AND `EmployeeID`='" + emp.EMPLOYEEID + "'";
                result = ExecuteQuery(conn, EmpDel) >= 0 ? true : false;
            }
            else
            {
                employeeInsert = "INSERT INTO tblaccemp_employee(CompanyID,EmployeeID,BusinessID,Title,Forename,Surname,StartDate,EndDate,DepartmentID,RoleID,GroupID,EmployeeClosed)  VALUES ('" + cmpId + "','" + emp.EMPLOYEEID + "','" + emp.BusId + "','" + emp.TITLE + "','" + emp.FORENAME + "','" + emp.SURNAME + "','" + DateTime.Parse(emp.STARTDATE).ToString("yyyy-MM-dd") + "','" + DateTime.Parse(emp.ENDDATE).ToString("yyyy-MM-dd") + "'," + emp.DEPARTMENTID + "," + emp.ROLEID + ",1,0) ON DUPLICATE KEY UPDATE Title='" + emp.TITLE + "', Forename='" + emp.FORENAME + "', Surname='" + emp.SURNAME + "',DepartmentID=" + emp.DEPARTMENTID + ", roleid=" + emp.ROLEID + ", StartDate='" + DateTime.Parse(emp.STARTDATE).ToString("yyyy-MM-dd") + "', EndDate='" + DateTime.Parse(emp.ENDDATE).ToString("yyyy-MM-dd") + "', EmployeeClosed=0";
                result = ExecuteQuery(conn, employeeInsert) > 0 ? true : false;
            }
            if (emp.UCODE != "" && emp.UCODE != null && result)
            {
                if (emp.UCODEIDlst.Count() > 0)
                {
                    foreach (var ucode in emp.UCODEIDlst)
                    {
                        if (ucode != "" && ucode != null)
                        {
                            ucodeQry = "";
                            ucodeQry = "INSERT INTO tblaccemp_ucodesemployees(CompanyID,BusinessID,EmployeeID,UCodeID)  VALUES ('" + cmpId + "','" + emp.BusId + "','" + emp.EMPLOYEEID + "','" + ucode.Trim() + "') ON DUPLICATE KEY UPDATE UCodeID='" + ucode.Trim() + "'";
                            result = ExecuteQuery(conn, ucodeQry) > 0 ? true : false;
                            if (!result)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ucodeQry = "INSERT INTO tblaccemp_ucodesemployees(CompanyID,BusinessID,EmployeeID,UCodeID)  VALUES ('" + cmpId + "','" + emp.BusId + "','" + emp.EMPLOYEEID + "','" + emp.UCODE.Trim() + "') ON DUPLICATE KEY UPDATE UCodeID='" + emp.UCODE.Trim() + "'";
                    result = ExecuteQuery(conn, ucodeQry) > 0 ? true : false;
                }

            }
            if (userCreate && result)
            {
                usrCreateQry = "INSERT INTO tblUsers(UserName,Password,ForeName,SurName,ContactNo,AccessID,Active,BusinessID,CreateDate,Email_ID,ASPUserID,BusinessName)  VALUES('" + emp.EMPLOYEEID + "','" + rndPwd + "','" + emp.FORENAME + "','" + emp.SURNAME + "','','User','Y','" + emp.BusId + "',Now(),'','" + emp.Aspuserid + "','" + emp.BusId + "') ON DUPLICATE KEY UPDATE UserName='" + emp.EMPLOYEEID + "',ForeName='" + emp.FORENAME + "',SurName='" + emp.SURNAME + "',ASPUserID='" + emp.Aspuserid + "',BusinessID='" + emp.BusId + "',BusinessName='" + emp.BusId + "' ";
                if (ExecuteQuery(conn, usrCreateQry) > 0)
                {
                    result = true;
                    if (emp.MAPTOlst.Count() > 0)
                    {
                        foreach (var ucode in emp.MAPTOlst)
                        {
                            if (ucode != "" && ucode != null)
                            {
                                onlineUsrIns = "";
                                onlineUsrIns = "INSERT INTO tblonline_userid_employee(CompanyID,BusinessID,OnlineUserID,EmployeeID)  VALUES ('" + cmpId + "','" + emp.BusId + "','" + ucode + "','" + emp.EMPLOYEEID + "') ON DUPLICATE KEY UPDATE EmployeeID='" + emp.EMPLOYEEID + "'";
                                result = ExecuteQuery(conn, onlineUsrIns) > 0 ? true : false;
                                if (!result)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        onlineUsrIns = "INSERT INTO tblonline_userid_employee(CompanyID,BusinessID,OnlineUserID,EmployeeID)  VALUES ('" + cmpId + "','" + emp.BusId + "','" + emp.MAPTO + "','" + emp.EMPLOYEEID + "') ON DUPLICATE KEY UPDATE EmployeeID='" + emp.EMPLOYEEID + "'";
                        result = ExecuteQuery(conn, onlineUsrIns) > 0 ? true : false;
                    }

                }
            }
            if (result)
            {

                if (emp.MAPTOADDRLst.Count() > 0)
                {
                    foreach (var address in emp.MAPTOADDRLst)
                    {
                        if (address != "" && address != null)
                        {
                            onlineUsrIns = "";
                            int adrId = _busAddress.Exists(s => s.Description.ToLower().Trim() == address.ToLower().Trim()) ? _busAddress.GetAll(s => s.Description.ToLower().Trim() == address.ToLower().Trim()).First().AddressID : 0;
                            if (adrId > 0)
                            {
                                addrQry = "INSERT INTO tblonline_emp_address(CompanyID,BusinessID,OnlineUserID,EmployeeID,AddressID)  VALUES ('" + cmpId + "','" + emp.BusId + "','','" + emp.EMPLOYEEID + "'," + adrId + ")  ON DUPLICATE KEY UPDATE AddressID=" + adrId;
                                result = ExecuteQuery(conn, addrQry) > 0 ? true : false;
                                if (!result)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (emp.MAPTOADDR != "" && emp.MAPTOADDR != null)
                    {
                        int adrId = _busAddress.Exists(s => s.Description.ToLower().Trim() == emp.MAPTOADDR.ToLower().Trim()) ? _busAddress.GetAll(s => s.Description.ToLower().Trim() == emp.MAPTOADDR.ToLower().Trim()).First().AddressID : 0;
                        if (adrId > 0)
                        {
                            addrQry = "INSERT INTO tblonline_emp_address(CompanyID,BusinessID,OnlineUserID,EmployeeID,AddressID)  VALUES ('" + cmpId + "','" + emp.BusId + "','','" + emp.EMPLOYEEID + "','" + adrId + "')  ON DUPLICATE KEY UPDATE AddressID=" + adrId;
                            result = ExecuteQuery(conn, addrQry) > 0 ? true : false;
                        }
                    }
                }

            }


            return result;
        }
        #endregion

        #region DeleteFromPermUser
        public bool DeleteFromPermUser(string buId, MySqlConnection conn)
        {
            bool result = false;
            string qry = "";
            try
            {
                qry = "DELETE FROM `tblpermission_users_allow` WHERE BusinessID='" + buId + "'";
                result = ExecuteQuery(conn, qry) >= 0 ? true : false;
            }
            catch (Exception e)
            {

            }
            return result;
        }
        #endregion
        //#region RemoveUser

        //public bool RemoveUser(string arr)
        //{
        //    bool result = false;
        //    string sql = "";
        //    MySqlConnection conn = new MySqlConnection(ConnectionString);
        //    MySqlTransaction trans;
        //    conn.Open();
        //    trans = conn.BeginTransaction();
        //    try
        //    {
        //        foreach (var data in arr)
        //        {
        //            sql = "update tblusers set Active='N' where username='++' and forename=''";
        //        }
        //    }
        //    catch(Exception e)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}
        //#endregion

    }

    //"SELECT distinct t1.orderno, DATE_FORMAT(t1.OrderDate, '%D/%M/%Y') as OrderDate, if(min(x.OrdCompleted) = 1, 'Yes', 'No') as ordercompleted, t1.custref, t1.pinno as EmpID, concat(t2.forename, t2.surname) as EmpName, if(min(x.OrdCompleted) = 1, DATEDIFF(max(t1.finaliseddeliverydate),t1.OrderDate)+1, 'TBC') as DayToDeliver, if(min(x.OrdCompleted) = 1,DATE_FORMAT(max(t1.finaliseddeliverydate), '%d/%m/%y'),'') as LastDespatched FROM tblcube_orderdetail t1  left join (select distinct companyid,businessid,employeeid,forename,surname,department,departmentid,styleid,colourid from tblcube_employee_card where businessid='{0}') t2 on (t1.companyid=t2.companyid) and (t1.pinno=t2.employeeid) and (t1.styleid=t2.styleid) and (t1.colourid=t2.colourid)  left join (SELECT companyid,orderno,solineno,if(max(ordqty) = SUM(pickqty),1,0) as OrdCompleted FROM tblcube_orderdetail  WHERE custid='{0}' and orderdate between '" & StDate & "' and '" & EdDate & "' and (Not socancelled And Not pscancelled And delnoteflag And delprinted)  GROUP BY companyid,orderno,solineno) x ON t1.companyid=x.companyid AND t1.orderno=x.orderno  WHERE t1.custid='{0}' AND t1.orderdate between '" & StDate & "' and '" & EdDate & "' and (Not socancelled And Not pscancelled And delnoteflag And delprinted) "
          
    //        Dim ddDepart As TextBox = DirectCast(FindControlRecursive(Page, "txtDepartment"), TextBox)
    //        If ddDepart.Text<> "" Then
    public class ColorsOb
    {
        public string Colours { get; set; }
        public int obsolete { get; set; }

    }
    public class SizeOb
    {
        public string Sizes { get; set; }
        public int obsolete { get; set; }

    }
}


