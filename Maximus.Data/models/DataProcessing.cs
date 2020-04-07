using System;
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

namespace Maximus.Data.Models
{
    public class DataProcessing
    {
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
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly Nextno _nextno;
        public readonly StockCard _stockCard;
        public readonly Style_Colour _style_Colour;
        public readonly Style_Sizes _style_Sizes;
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
        public readonly GenParameter _genParameter;
        public readonly BusAccount _busAccount;
        public readonly StyleByTemplateView _styleByTemplateView;
        public DataProcessing(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            AllAssemblies allAssembly = new AllAssemblies(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            FskStyleFreetext fskStyleFreetext = new FskStyleFreetext(_unitOfWork);
            Nextno nextno = new Nextno(_unitOfWork);
            StockCard stockCard = new StockCard(_unitOfWork);
            Style_Colour style_Colour = new Style_Colour(_unitOfWork);
            Style_Sizes style_Sizes = new Style_Sizes(_unitOfWork);
            StyleByFreetext styleByFreetext = new StyleByFreetext(_unitOfWork);
            StyleColorSizeObsolete styleColorSizeObsolete = new StyleColorSizeObsolete(_unitOfWork);
            StyleGroups styleGroups = new StyleGroups(_unitOfWork);
            StylesView stylesView = new StylesView(_unitOfWork);
            TblFskStyle tblFskStyle = new TblFskStyle(_unitOfWork);
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            User user = new User(_unitOfWork);
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
            _styleByTemplateView = styleByTemplateView;
            _user = user;
            _busAccount = busAccount;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _busContact = busContact;
            _countryCodes = countryCodes;
            _customAssembly = customAssembly;
            _departments = departments;
            _employee = employee;
            _fskStyleFreetext = fskStyleFreetext;
            _nextno = nextno;
            _stockCard = stockCard;
            _style_Colour = style_Colour;
            _style_Sizes = style_Sizes;
            _styleByFreetext = styleByFreetext;
            _styleColorSizeObsolete = styleColorSizeObsolete;
            _styleGroups = styleGroups;
            _stylesView = stylesView;
            _tblFskStyle = tblFskStyle;
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
            _fskSetValues = fskSetValues;
            _fskSettings = fskSettings;
            _customerOrderTemplate = customerOrderTemplate;
            _busSetValues = busSetValues;
            _cmpDefaults = cmpDefaults;
            _busSettings = busSettings;
            _genParameter = genParameter;
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

            }
            return null;
        }
        #endregion

        public List<UcodeModel> GetAllUcodeLst(string ucode)
        {
            List<UcodeModel> lst = new List<UcodeModel>();
            string sqry = "select StyleID,FreeText from ucodeby_freetextview where UcodeID='" + ucode + "'";
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {

                    MySqlCommand cmd = new MySqlCommand(sqry, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lst.Add(new UcodeModel { StyleId = dr[0].ToString(), FreeText = dr[1].ToString() });
                        }
                        return lst;
                    }
                }
            }
            catch (Exception e)
            {
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
                sSqry = sSqry + "SELECT DISTINCT tblaccemp_ucodesemployees.UCodeID, IF(ISNULL(tblaccemp_ucodes_desc.Description),tblaccemp_ucodesemployees.UCodeID,tblaccemp_ucodes_desc.Description) AS Description FROM tblaccemp_ucodesemployees LEFT JOIN tblaccemp_ucodes_desc ON tblaccemp_ucodesemployees.UCodeID = tblaccemp_ucodes_desc.UCodeID WHERE tblaccemp_ucodesemployees.BusinessID = '" + businessId + "'";
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
                string sqry = "SELECT RoleID, Description FROM tblaccemp_budget WHERE CompanyID = '" + cmpId + "' AND BusinessID='" + busId + "'";
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

        #region AddressUserCreate
        public bool AddressUserCreate(string busId = "")
        {
            return Convert.ToBoolean(BusinessParam("DELADDR_USER_CREATE", busId.Trim()));
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
            }
            finally
            {
                conn.Close();
            }
            return varPermission;
        }
        #endregion

        #region GetPrice

        public decimal GetPrice(string StyleID = "", string SizeId = "", string busId = "")
        {
            decimal result = 0;
            string sSqry = "", sSqry1 = "";
            string res1 = "", res2 = "";
            try
            {
                string businessId = busId;
                if (StyleID.Contains(",") == false)
                {
                    sSqry = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='" + businessId + "' and PriceID=2";
                    sSqry1 = "select price from tblfsk_style_sizes_prices where SizeID='" + SizeId.Trim() + "' and StyleID='" + StyleID.Trim() + "' and BusinessId='All' and PriceID=2";
                    res1 = GetScalar(sSqry);
                    res2 = GetScalar(sSqry1);
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
            { }
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

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        //#region GetBulkPrice
        //public decimal GetBulkPrice(int qty, string StyleID = "", string SizeId = "", string busId = "")
        //{
        //    decimal resPric = 0;
        //    List<BulkOrderModel> qtyMode = new List<BulkOrderModel>();
        //    qtyMode = (List<BulkOrderModel>)HttpContext.Current.Session["BulkQtyModel"];

        //    if (qtyMode.Count > 0)
        //    {
        //        if (qtyMode.Any(x => x.style.ToString().ToLower() == StyleID.ToLower() && x.size.ToLower() == SizeId.ToLower()))
        //        {
        //            qtyMode.Remove(qtyMode.Where(x => x.style.ToString().ToLower() == StyleID.ToLower() && x.size.ToLower() == SizeId.ToLower()).First());
        //        }
        //    }
        //    try
        //    {
        //        if (qty > 0)
        //        {
        //            qtyMode.Add(new BulkOrderModel { size = SizeId, style = StyleID, qty = qty });

        //            string businessId = busId;
        //            decimal result = _styleSizePrice.Exists(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId && x.PriceID == 2) ? (decimal)_styleSizePrice.GetAll(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId && x.PriceID == 2).FirstOrDefault().Price.Value : 0;
        //            result = result == 0 ? _styleSizePrice.Exists(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL" && x.PriceID == 2) ? (decimal)_styleSizePrice.GetAll(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL" && x.PriceID == 2).FirstOrDefault().Price.Value : result : result;
        //            if (result != 0)
        //            {
        //                resPric = System.Math.Round(result, 2);
        //                qtyMode.Where(x => x.style.ToString().ToLower() == StyleID.ToLower() && x.size.ToLower() == SizeId.ToLower()).First().price = resPric * qty;
        //            }
        //            else
        //            {
        //                qtyMode.Where(x => x.style.ToString().ToLower() == StyleID.ToLower() && SizeId.ToLower() == SizeId.ToLower()).First().price = 0 * qty;
        //            }
        //            HttpContext.Current.Session["BulkQtyModel"] = qtyMode;
        //        }
        //        return qtyMode.Where(x => x.style.ToLower() == StyleID.ToLower()).Sum(x => x.price);
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    return 0;
        //}
        //#endregion

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

            }
            finally
            {

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
        public string getPermissionUsers(string Permission, string CurrUser, string busID)
        {
            string result = "", mRole = "", AllowUsers = "", Users = "";
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
                    newAllUser = newAllUser + data.users;
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
                            foreach (DataRow dr in dt.Rows)
                            {
                                strFlds += "'" + dr.ItemArray[0].ToString() + "',";
                            }
                        }
                        strFlds = strFlds.Remove(strFlds.LastIndexOf(","), 1);
                        result = "'" + CurrUser + "'," + strFlds;
                    }
                }
                else
                {
                    result = "'" + CurrUser + "'";
                }
                if (strFlds != "")
                {
                    sqlUser += "AND(" + strFlds + ")";
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
                    foreach (DataRow dr in dt1.Rows)
                    {
                        tmpStr += "'" + dr.ItemArray[0].ToString() + "',";
                    }
                    if (tmpStr != "")
                    {
                        tmpStr = "'" + CurrUser + "'," + tmpStr.Substring(0, tmpStr.Length - 1);
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
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt3.Rows)
                    {
                        if (dr.ItemArray[0].ToString().Trim() != CurrUser)
                        {
                            tmpOrdStr += "'" + dr.ItemArray[0].ToString() + "',";
                        }

                    }

                }
                if (tmpOrdStr != "")
                {
                    tmpOrdStr = tmpOrdStr.Substring(0, tmpOrdStr.Length - 1);
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

            }
            return result;
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
                    emplList = "" + getZeroLevelUsers(Users) + ",";
                    result1.Add(new Maximus.Data.Models.AllowUsers { users = emplList, count = emplList.Count() });
                }
                else
                {
                    UserList += "'" + usrs + "',";
                    result1.Add(new Maximus.Data.Models.AllowUsers { users = UserList, count = UserList.Count() });
                    getNewPermissionUser(usrs, UserList, emplList, busID);
                }
            }
            catch (Exception e)
            {

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
            List<string> userLst = new List<string>();
            users = users.Replace("'", "");
            var userArr = users.Split(',');

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                foreach (var arr in userArr)
                {
                    MySqlCommand command = new MySqlCommand("GetZeroLevelUsersSp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new MySqlParameter("Users", arr));
                    result = (command.ExecuteScalar()).ToString() != "" | command.ExecuteScalar() != null ? (command.ExecuteScalar()).ToString() : "";
                    result = result != "" ? result.Substring(result.Length - 1) == "'" ? "'" + result : "'" + result + "'" : "'" + result + "'";
                    userLst.Add(result);
                }
                var result2 = "";
                foreach (var data in userLst)
                {
                    if (data != "")
                    {

                        result2 = result2 + data;

                    }
                }
                //result2 = result2 + "";
                return result2;
            }
            catch (Exception e)
            {

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
            strsql = "SELECT e.employeeid, concat(concat(e.forename,' '),e.surname) as employeename, e.EmployeeClosed AS `STATUS` ";
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
                allUsers = getPermissionUsers(OrderPermission, userId, busId);
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
                        result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[0].ToString(), EmpFirstName = dr.ItemArray[1].ToString(), Department = dr.ItemArray[3].ToString(), EmpIsActive = dr.ItemArray[3].ToString() == "0" ? true : false });
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        #endregion

        #region GetEmployee
        public List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            List<EmployeeViewModel> result1 = new List<EmployeeViewModel>();
            var result = GetEmployeeByProcedure(busId, userId);
            result1 = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            return result1;
            ////var dataList = list.Split(',');
            //List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            //string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            //string strsql = "";
            //bool booBudget = false;
            //string StDate = "";
            //string EdDate = "";
            //string CustBudgetType = "";
            //string CustBudgetPeriodDays = "";
            //string allUsers = "";
            //bool booPoints = false;
            ////CustBudgetType = BusinessParam("BudgetType", busId);
            ////CustBudgetPeriodDays = BusinessParam("BudgetPeriodDays", busId);
            //booBudget = Convert.ToBoolean(BusinessParam("BUDGETREQ", busId));
            //booPoints = Convert.ToBoolean(BusinessParam("POINTSREQ", busId));
            //strsql = "SELECT e.employeeid, concat(concat(e.forename,' '),e.surname) as employeename, e.EmployeeClosed AS `STATUS` ";
            //if (booBudget)
            //{
            //    strsql = strsql + ",t1.Budget as EntBudget,b.CurrBudget";
            //}
            //if (booPoints)
            //{
            //    strsql = strsql + ",t2.TotalPoints as EntPoints,p.CurrPoints ";
            //}
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql = strsql + ",if(s.CurrStock IS NULL,0,s.CurrStock) as empStock ";
            //}
            //strsql = strsql + ",e.departmentid FROM tblaccemp_employee e ";
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOQty IS NULL,0,SOQty))+SUM(if(PickQty IS NULL,0,PickQty))+SUM(if(InvQty IS NULL,0,InvQty)) AS CurrStock FROM tblaccemp_stockcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) s ON e.employeeid=s.employeeid ";
            //}
            //if (booBudget)
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOValue IS NULL,0,SOValue))+SUM(if(PickValue IS NULL,0,PickValue))+SUM(if(InvValue IS NULL,0,InvValue)) AS CurrBudget FROM tblaccemp_budgetcard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' GROUP BY CompanyID, BusinessID, EmployeeID) b ON e.employeeid=b.employeeid " + "LEFT JOIN tblaccemp_budget t1 ON (t1.BusinessID = e.BusinessID) AND (t1.CompanyID = e.CompanyID) AND (t1.RoleID = e.RoleID) ";
            //}
            //if (booPoints)
            //{
            //    strsql = strsql + "LEFT JOIN (SELECT employeeid,SUM(if(SOPoints IS NULL,0,SOPoints))+SUM(if(PickPoints IS NULL,0,PickPoints))+SUM(if(InvPoints IS NULL,0,InvPoints)) AS CurrPoints FROM tblaccemp_pointscard " + "WHERE CompanyID='" + strCompanyID + "' AND BusinessID='" + busId + "' AND Year=0 GROUP BY CompanyID, BusinessID, EmployeeID) p ON e.employeeid=p.employeeid " + "LEFT JOIN tblaccemp_points t2 ON (t2.BusinessID = e.BusinessID) AND (t2.CompanyID = e.CompanyID) AND (t2.RoleID = e.RoleID) ";

            //}
            //if (txtUcode != "")
            //{
            //    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees WHERE companyid='" + strCompanyID + "' AND businessid='" + busId + "' AND ucodeid='" + txtUcodeDesc.Trim() + "') u ON e.employeeid=u.employeeid";
            //}
            //if (Convert.ToBoolean(BusinessParam("LimitUsrEmp", busId)))
            //{
            //    allUsers = getPermissionUsers(OrderPermission, userId, busId);
            //    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblonline_userid_employee WHERE CompanyID='" + strCompanyID + "' AND onlineuserid in (" + allUsers + ") AND onlineuserid not in (" + getDenyPermissionUsers(OrderPermission, userId, busId) + ") AND businessid='" + busId + "') onlemp ON e.employeeid=onlemp.employeeid ";
            //}
            //if (ddlAddress != "")
            //{
            //    strsql += " JOIN tblonline_emp_address ea ON e.businessid=ea.businessid AND e.employeeid=ea.employeeid AND ea.addressid=" + ddlAddress + "";
            //}
            //if (txtUcodeDesc.Trim() != "")
            //{
            //    strsql += " JOIN (SELECT DISTINCT employeeid FROM tblaccemp_ucodesemployees t1 left join tblaccemp_ucodes_desc t2 on (t2.UcodeID=t1.UcodeID) WHERE t1.companyid='" + strCompanyID + "' AND t1.businessid='" + busId + "' and if(isnull(t2.Description),t1.UCodeID,t2.Description) like '% " + txtUcodeDesc.Trim() + "%') u1  ON e.employeeid=u1.employeeid";
            //}
            //strsql += " WHERE e.companyid='" + strCompanyID + "' AND  e.businessid='" + busId + "'";

            //if (txtCDepartment != "")
            //{
            //    strsql += " AND e.departmentid='" + txtCDepartment + "'";
            //}
            //if (txtRole != "")
            //{
            //    strsql += " AND e.roleid='" + txtRole + "'";
            //}
            //if (txtEmpNo != "")
            //{
            //    strsql += " AND e.employeeid LIKE '" + txtEmpNo + "%'";
            //}
            //if (txtName != "")
            //{
            //    strsql += " AND concat(forename,' ', surname) LIKE '%" + txtName + "%'";
            //}
            //if (txtStDate != "")
            //{
            //    var mDate = txtStDate.Split('/');
            //    StDate = mDate[2] + "-" + mDate[1] + "-" + mDate[0];
            //    strsql += " AND e.StartDate>='" + StDate + "'";
            //}
            //strsql += " AND e.EmployeeClosed = '0'";
            ////if (Convert.ToBoolean(help.BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())) & Convert.ToInt32(Session["OrderReason"]) == 3)
            //if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId.Trim().ToUpper())))
            //{
            //    strsql += " AND if(s.CurrStock IS NULL,0,s.CurrStock)=0";
            //    strsql += " ORDER BY e.StartDate DESC, e.employeeid ASC";
            //}
            //else
            //{
            //    strsql += " ORDER BY e.employeeid";
            //}
            //try
            //{
            //    //strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());
            //}
            //catch (Exception e)
            //{

            //}
            ////strsql = string.Format(strsql, strCompanyID, busId, txtUcode, txtCDepartment, txtRole, txtEmpNo, txtName, userId, Convert.ToInt32(ddlAddress), txtUcodeDesc.Trim());
            //string chkit = ", 0 as chekit, 0 as SelectSeq, 0 as Abort ";
            //strsql = strsql.Insert(strsql.IndexOf("FROM"), chkit);
            //strsql = strsql.Insert(strsql.IndexOf("FROM"), chkit);
            //DataTable dt = new DataTable();
            //dt = GetDataTable(strsql);
            //try
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            var empId = dr.ItemArray[0].ToString();
            //            result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[0].ToString(), EmpFirstName = dr.ItemArray[1].ToString(), Department = dr.ItemArray[3].ToString(), EmpIsActive = dr.ItemArray[3].ToString() == "0" ? true : false });
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception e)
            //{

            //}

            //return GetDataTable(strsql);
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

            }
            finally
            {

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
        public int UpdateEmployee(int cmpId, int addressId, string employeeId, string busId)
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
                    string sQry1 = "Insert into tblonline_emp_address(CompanyId,AddressId,EmployeeId,BusinessId)values(" + cmpId + "," + addressId + ",'" + employeeId + "' ,'" + busId + "')";
                    MySqlCommand cmd1 = new MySqlCommand(sQry1, CONN);
                    result = cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

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
            }
            catch (Exception e)
            {

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

            }
            return quanty;
        }
        #endregion
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
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region basket

        #region GetAllTotals
        public TotalModel GetAlltotals(List<SalesOrderHeaderViewModel> mod, double carriage)
        {
            TotalModel tot = new TotalModel();
            double orgTotal = 0;
            double lineTotal = 0;
            double vatTotal = 0;
            double assemTotal = 0;
            double Total = 0;
            List<double> varpercents = new List<double>();
            double totalVat = 0;
            foreach (var header in mod)
            {
                foreach (var dat in header.SalesOrderLine)
                {
                    orgTotal = orgTotal + (dat.OrdQty * dat.Price);
                    totalVat = totalVat + GetlineVat(dat.OrdQty, dat.Price, dat.VatPercent);
                }
                lineTotal = lineTotal + orgTotal;
                vatTotal = vatTotal + totalVat;
                orgTotal = 0;
                totalVat = 0;
                foreach (var line in header.SalesOrderLine)
                {
                    double VatPercent = line.VatPercent;
                    varpercents.Add(VatPercent);
                    double lineVat = line.OrdQty != 0 ? ((line.OrdQty * line.Price) * VatPercent) / 100 : 0.0;
                    totalVat = totalVat + lineVat;
                }
            }
            string vatSpan = "";
            foreach (var vats in varpercents.Distinct())
            {
                vatSpan = vatSpan + vats + "% \n";
            }
            tot.vatSpan = vatSpan;
            tot.carriage = RoundVATDecimals(carriage);
            tot.ordeTotal = RoundVATDecimals(lineTotal + carriage);
            tot.totalVat = RoundVATDecimals(vatTotal);
            tot.Total = RoundVATDecimals(lineTotal);
            tot.gross = RoundVATDecimals(vatTotal + lineTotal);
            return tot;
        }
        #endregion

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
                result = Convert.ToDouble(decimal.Divide(Convert.ToInt32(Convert.ToDouble((value * 100).ToString("0.0000")) + 0.4), 100));
            }
            return result;
        }
        #endregion

        #region GetCostPrice
        public double GetCostPrice(string style, string size, string color, string currency, int mprice, int seqNo)
        {
            double cost = 0.0;
            string sSqry = " SELECT Price FROM tblfsk_style_sizes_prices  WHERE CompanyID='" + cmpId + "' AND StyleID='" + style + "' AND SizeID='" + size + "' AND  PriceID=" + mprice + " AND Businessid='ALL' AND Country_Currency=0";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, con);
                cost = cmd.ExecuteScalar() == null ? 0.0 : Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch
            {

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

            for (int i = 0; i < noOfDays; i++)
            {
                date = date.AddDays(i);
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
            string sSqry = " SELECT `vatpercent`  FROM    `tblacc_vatcodes`  WHERE vatcode = (SELECT  `price`  FROM  `tblfsk_style_sizes_prices`  WHERE  `styleid`= '" + style + "' AND BusinessId='ALL' AND sizeid = '" + size + "' AND `priceid`= (SELECT priceid FROM `tblfsk_price` WHERE description = 'VAT'))";
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
            catch
            {

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

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region GetCarrierStyle

        public List<string> GetCarrierStyleCmbValue()
        {
            var result = new List<string>();
            string sQry = "";
            sQry = sQry + " SELECT DISTINCT tblfsk_style.StyleID, tblfsk_style.Description  FROM tblfsk_style INNER JOIN tblonlinesop_carriage ON (tblfsk_style.StyleID = tblonlinesop_carriage.StyleID) AND (tblfsk_style.CompanyID = tblonlinesop_carriage.CompanyID)  WHERE tblfsk_style.CompanyID='" + cmpId + "'  ORDER BY tblfsk_style.StyleID";
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
            catch
            {

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

            }
            finally
            {
                conn.Close();
            }
            return BusAddress1;
        }
        #endregion

        #region FillCombo_CustomerDelivery
        public List<BusAddress1> FillCombo_CustomerDelivery(string busId, string access, string orderPermit, string UserName, bool IsManpack = false, string selEmp = "")
        {
            var result = new List<BusAddress1>();
            string extraQry = "";
            string sQry = "";

            if (IsManpack)
            {
                extraQry = extraQry + " (onusraddr.`OnlineUserId`IN (" + getPermissionUsers(GetOrderPermission(orderPermit), UserName, busId) + ") OR onusraddr.`Employeeid` = '" + selEmp + "') ";
                //extraQry = extraQry + " (onusraddr.`OnlineUserId`IN (" + getPermissionUsers(GetOrderPermission(), System.Web.HttpContext.Current.Session["UserName"].ToString(), busId) + ") OR onusraddr.`Employeeid` = '" & Emplist1.CurrentEmployee & "') ";
            }
            else
            {
                extraQry = extraQry + " onusraddr.`OnlineUserId`='" + UserName + "' ";
            }
            if (Convert.ToBoolean(BusinessParam("LIMITUSRADDR", busId)) && !IsGetAllDelAddress(access, busId))
            {
                sQry = sQry + "SELECT DISTINCT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode,  tblbus_countrycodes.Country, tblbus_address.CountryCode, tblbus_address.AddressID,tblbus_address.ContactID   FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes  INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON  tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  JOIN tblonline_emp_address onusraddr on onusraddr.AddressID=tblbus_address.AddressID AND tblbus_address.BusinessID= onusraddr.BusinessID AND onusraddr.CompanyID=tblbus_address.CompanyID   WHERE tblbus_addresstype_ref.Actual_TypeID=2 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID ='" + cmpId + "' AND " + extraQry + "  order by tblbus_address.Description";
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
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new BusAddress1 { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
                    }
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
                        foreach (DataRow dr in dt1.Rows)
                        {
                            result.Add(new BusAddress1 { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
                        }
                    }
                }
            }
            catch (Exception e)
            {
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
            catch
            {
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

            }
            return false;
        }
        #endregion

        #region checkBulkCarriageLine

        public bool checkBulkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder)
        {
            bool checkBulkCarriageLine = false;
            string carrstr = "";
            long irow = 0;

            var headers = currentOrder;
            var salesLines = headers.Select(x => x.SalesOrderLine).First();
            foreach (var data in salesLines)
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
        public bool checkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder)
        {
            bool checkCarriageLine = false;
            string carrstr = "";
            long irow = 0;

            var headers = currentOrder;
            var salesLines = headers.Select(x => x.SalesOrderLine).First();
            foreach (var data in salesLines)
            {
                carrstr = "SELECT * FROM tblonlinesop_carriage WHERE StyleID='" + data.StyleID + "' AND CompanyID='" + cmpId + "'";
                if (qryResult(carrstr) > 0)
                {
                    checkCarriageLine = true;
                }
            }
            return checkCarriageLine;
        }

        #endregion

        #region  getbusienssAccounts
        public TBusinessAccount GetBusinessAccount(List<TBusinessAccount> colBuis, string business)
        {
            int i;
            TBusinessAccount getBusinessAccount = new TBusinessAccount();
            string sSqry = "";
            sSqry = BusinessAccountSQL() + " AND tblbus_account.businessid='" + business + "'";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            TBusinessAccount tmpType;
            for (i = 0; i < colBuis.Count(); i++)
            {
                tmpType = colBuis[i];
                if (tmpType.BusinessID == business)
                {
                    return tmpType;
                }
            }
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    getBusinessAccount = readBusinessAccount(reader);
                }
                colBuis[colBuis.Count - 1] = getBusinessAccount;
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return getBusinessAccount;
        }
        #endregion

        #region readBusinessAccount
        public TBusinessAccount readBusinessAccount(MySqlDataReader reader)
        {
            TBusinessAccount tmpType;
            tmpType.BusinessID = reader.GetString("BusinessID");
            tmpType.Credit_Limit = Convert.ToDouble(reader.GetString("Credit_Limit"));
            tmpType.Cash_Days1 = Convert.ToInt32(reader.GetString("Cash_Days1"));
            tmpType.Cash_Days2 = Convert.ToInt32(reader.GetString("Cash_Days2"));
            tmpType.Currency = reader.GetString("Currency");
            tmpType.VatCode = Convert.ToInt32(reader.GetString("VATCode"));
            if (reader.GetString("VATFlag") == "")
            {
                tmpType.VatFlag = "";
            }
            else
            {
                tmpType.VatFlag = reader.GetString("VATFlag");
            }
            tmpType.Balance = Convert.ToDouble(reader.GetString("Balance"));
            tmpType.RepID = Convert.ToInt32(reader.GetString("RepID"));
            tmpType.Rep_Comission = Convert.ToSingle(reader.GetString("Rep_Comission"));
            tmpType.KAM_Comission = Convert.ToSingle(reader.GetString("KAM_Comission"));
            tmpType.Balance = Convert.ToDouble(reader.GetString("Balance"));
            tmpType.PaymentTermsID = Convert.ToInt32(reader.GetString("PaymentTermsID"));
            tmpType.Country_CurrencyID = Convert.ToInt32(reader.GetString("Country_Currency"));
            tmpType.CurrencyName = reader.GetString("Currency_name");
            tmpType.ExchangeRate = Convert.ToDouble(reader.GetString("Currency_Exchange_Rate"));
            tmpType.booSet = true;
            return tmpType;
        }
        #endregion

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
            catch
            {

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
            catch
            {

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
                if (((SalesOrderHeaderViewModel)objCurrentOrder).SalesOrderLine.Count > 0)
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
                        catch
                        {

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
                        if (data[i].SalesOrderLine.Count > 0)
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
                                catch
                                {

                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }
                    }
                    if ((objCurrentOrder).SalesOrderLine.Count > 0)
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
                            catch
                            {

                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        else
                        {
                            if ((objCurrentOrder).SalesOrderLine.Count > 0)
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
                                errorIndx += (SalesOrderHeader)[i].SalesOrderLine.Count();
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
            catch
            {
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
            catch
            {

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
            catch
            {

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
            catch
            {

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
            catch
            {

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

            }
            finally
            {
                conn.Close();
            }
            return tmpcolStyle;
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
            catch
            {
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
            catch
            {

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
            tmpBusiness = GetBusinessAccount(tBusinessAccount, busId);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sSqry = "SELECT tblfsk_style_sizes.StyleID, tblfsk_style_sizes.SizeID, tblfsk_style_sizes.SeqNo, tblfsk_style_sizes.CompanyID, tblfsk_style_sizes_prices.Price, tblfsk_price.Description, tblfsk_price.PriceID   FROM (tblfsk_price INNER JOIN tblfsk_style_sizes_prices ON (tblfsk_price.PriceID = tblfsk_style_sizes_prices.PriceID) AND (tblfsk_price.CompanyID = tblfsk_style_sizes_prices.CompanyID))   INNER JOIN tblfsk_style_sizes ON (tblfsk_style_sizes.CompanyID = tblfsk_style_sizes_prices.CompanyID) AND (tblfsk_style_sizes.SizeID = tblfsk_style_sizes_prices.SizeID) AND (tblfsk_style_sizes.StyleID = tblfsk_style_sizes_prices.StyleID)  AND (tblfsk_style_sizes_prices.SizeID = tblfsk_style_sizes.SizeID) AND (tblfsk_style_sizes_prices.StyleID = tblfsk_style_sizes.StyleID) AND (tblfsk_style_sizes_prices.CompanyID = tblfsk_style_sizes.CompanyID)   Where (((tblfsk_style_sizes.StyleID) = '" + mStyle + "') And BusinessId='ALL' And tblfsk_style_sizes.SizeID='" + mSizeid + "' and  Country_Currency=" + mCustCountry + " and ((tblfsk_style_sizes.CompanyID) = '" + cmpId + "') And ((tblfsk_price.PriceId) = " + mPriceList + "))  ORDER BY tblfsk_style_sizes.SeqNo, tblfsk_price.Price_Type";
                    MySqlCommand cmd1 = new MySqlCommand(sSqry, conn);
                    var reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
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
                    ItemPrice = Convert.ToDouble(reader.GetString("Price"));
                }
            }
            catch
            {

            }
            finally
            {

            }
            return ItemPrice;
        }
        #endregion

        #region GetEmpOrUserAddress


        #endregion


        #region SaveSalesOrder
        public bool SaveSalesOrder(SalesOrderHeaderViewModel salesHead, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, long salesNo = 0, string busId = "", string usrId = "", bool editFlag = false, string POINTSREQ = "")
        {
            bool result = false;
            int execVal = 0;
            string sSqry = "";
            StringBuilder os = new StringBuilder();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlTransaction trans;
            var salLst = new List<SalesOrderHeaderViewModel>();
            salLst.Add(salesHead);
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                if (salesHead.SalesOrderLine.Count > 0 && salesNo > 0)
                {
                    try
                    {
                        var delcCode = Convert.ToInt32(salesHead.DelCountry);
                        var invcCode = Convert.ToInt32(salesHead.DelCountry);
                        salesHead.DelCountry = _countryCodes.Exists(x => x.CountryID == delcCode) ? _countryCodes.GetAll(x => x.CountryID == delcCode).First().Country : "";
                        salesHead.InvCountry = _countryCodes.Exists(x => x.CountryID == invcCode) ? _countryCodes.GetAll(x => x.CountryID == invcCode).First().Country : "";
                    }
                    catch
                    {


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
                    sSqry = "INSERT INTO tblsop_salesorder_header(CompanyID,WarehouseId,OrderNo,CustID,OrderDate,InvDesc,InvAddress1,InvAddress2,InvAddress3,InvCity,InvTown,InvPostCode,InvCountry, DelDesc,DelAddress1,DelAddress2,DelAddress3,DelCity,DelTown,DelPostCode,DelCountry, CustRef,Carrier,CarrierCharge,Comments,CommentsExternal,Totalgoods,ordergoods,Currency_Exchange_Rate,UserId,PinNo,UCodeId,Currency_Exchange_Code,TimeOfEntry,RepID,ReasonCode,OnlineUserID, OrderAnalysisCode1, OrderAnalysisCode2, OrderAnalysisCode3, OrderAnalysisCode4, OrderAnalysisCode5, AllowPartShipment, OrderType,`ContractRef`,`EmailID`,`ContactName`)  VALUES('" + cmpId + "','" + salesHead.WarehouseID + "'," + salesNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + salesHead.InvDesc + "','" + salesHead.InvAddress1 + "','" + salesHead.InvAddress2 + "','" + salesHead.InvAddress3 + "','" + salesHead.InvCity + "','" + salesHead.InvTown + "','" + salesHead.InvPostCode + "','" + salesHead.InvCountry + "','" + salesHead.DelDesc + "','" + salesHead.DelAddress1 + "','" + salesHead.DelAddress2 + "','" + salesHead.DelAddress3 + "','" + salesHead.DelCity + "','" + salesHead.DelTown + "','" + salesHead.DelPostCode + "','" + salesHead.DelCountry + "','" + salesHead.CustRef + "','" + salesHead.Carrier + "'," + salesHead.CarrierCharge + ",'" + salesHead.Comments + "','" + salesHead.CommentsExternal + "'," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).Total + "," + GetAlltotals(salLst, salesHead.CarrierCharge.Value).gross + "," + salesHead.Currency_Exchange_Rate + ",'" + UserIDXref + "','" + salesHead.EmployeeID + "','" + salesHead.UCodeId + "','" + salesHead.Currency_Exchange_Code + "','" + DateTime.Now.ToString("hh:mm:ss") + "'," + salesHead.RepID + "," + salesHead.ReasonCode + ",'" + usrId + "','" + salesHead.NomCode + "','" + salesHead.NomCode1 +
                   "','" + salesHead.NomCode2 + "','" + salesHead.NomCode3 + "','" + salesHead.NomCode4 + "'," + partShipment + ",'" + salesHead.OrderType + "', '" + salesHead.ContractRef + "', '" + salesHead.EmailID + "','" + cntName + "')";
                    execVal = ExecuteQuery(sSqry);
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
                                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count == 0)
                                    {
                                        sSQL = "INSERT INTO tblsop_customer_ref (CompanyID,Custid,custref ) VALUES('" + cmpId + "','" + busId + "','" + salesHead.CustRef + "')";
                                        if (ExecuteQuery(sSQL) == 0)
                                        {

                                        }
                                    }
                                }
                                catch (Exception e)
                                {

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
                        result = SaveSalesorderlines(IsRollOutOrder, conn, salesHead, salesNo, busId, POINTSREQ);
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

            }
            finally
            {
                conn.Close();
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
            catch
            {
            }
            finally
            {
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

        #region SaveSalesorderlines

        public bool SaveSalesorderlines(bool IsRolloutOrder, MySqlConnection conn, SalesOrderHeaderViewModel saleHead, long saleno, string busId, string POINTSREQ)
        {
            bool result = false;
            string sSQL = "";
            int sYear = 0;
            bool booStock = true;
            bool isPersonalOrder = false;
            long returnOrderNo = 0;
            long returnOrderLine = 0;
            sYear = IsRolloutOrder ? 99 : 0;

            if (Convert.ToBoolean(BusinessParam("REQ_REASONPAGE", busId)) && saleHead.ReasonCode == 0)
            {
                booStock = false;
            }
            foreach (var line in saleHead.SalesOrderLine)
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
                                    line.OriginalLineNo = 0;
                                    line.OriginalOrderNo = 0;
                                }
                            }
                            else
                            {
                                returnOrderLine = 0;
                                returnOrderNo = 0;
                                line.OriginalLineNo = 0;
                                line.OriginalOrderNo = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    var orgLineno = line.OriginalLineNo == null ? 0 : line.OriginalLineNo;
                    sSQL = "INSERT INTO tblsop_salesorder_detail (CompanyID, Warehouseid, OrderNo, LineNo,   LineType , StyleID, ColourID, SizeID,  Description, Price, OrdQty, AllQty, InvQty, DespQty,  CommissionRate, Deliverydate, VatCode, RepId, KamId, KAMrate, REPRate, Currency_Exchange_Rate,styleIDref,FreeText,Cost, IssueUOM, IssueQty,StockingUOM, NomCode, OriginalOrderNo, OriginalLineNo, AssemblyID, AsmLineNo, ReasonCode, ReturnOrderNo, ReturnLineNo, SOPDETAIL5, SOPDETAIL4)  VALUES('" + cmpId + "','" + saleHead.WarehouseID + "'," + saleno + "," + line.LineNo + ",1,'" + line.StyleID + "','" + line.ColourID + "','" + line.SizeID + "','" + line.Description + "'," + line.Price + "," + line.OrdQty + "," + line.AllQty + "," + line.InvQty + "," + line.InvQty + ",0,'" + line.DeliveryDate + "'," + line.VatCode1 + "," + line.RepId + "," + line.KAMID + "," + line.KAMRate1 + "," + line.RepRate1 + "," + line.Currency_Exchange_Rate + ",'" + line.StyleIDref + "','" + line.FreeText1 + "'," + line.Cost1 + "," + line.IssueUOM1 + "," + line.IssueQty1 + "," + line.StockingUOM1 + ",'" + line.NomCode + "'," + line.OriginalOrderNo + "," + orgLineno + "," + line.AssemblyID + "," + line.AsmLineNo + "," + line.ReasonCodeLine + "," + returnOrderNo + "," + returnOrderLine + ",'" + line.SOPDetail5 + "','" + line.SOPDetail4 + "')";
                    if (ExecuteQuery(sSQL) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        result = true;
                    }
                    if (saleHead.OrderType != "RT")
                    {
                        if (isPersonalOrder)
                        {

                        }
                        if (Convert.ToBoolean(BusinessParam("EmployeeDetails", busId)))
                        {
                            if (line.EmployeeId != null)
                            {
                                if (line.EmployeeId.Length > 0)
                                {
                                    if (booStock)
                                    {
                                        sSQL = "SELECT * FROM tblAccEmp_StockCard WHERE CompanyID='" + cmpId + "' AND BusinessID='" + busId + "' AND EmployeeID='" + line.EmployeeId + "' AND StyleID='" + line.StyleID + "' AND ColourID='" + line.ColourID + "' AND Year=" + sYear;
                                        MySqlCommand cmd1 = new MySqlCommand(sSQL, conn);
                                        MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                                        DataTable dt1 = new DataTable();
                                        da.Fill(dt1);
                                        if (dt1.Rows.Count == 0)
                                        {
                                            sSQL = "INSERT INTO tblaccemp_stockcard (CompanyID,BusinessID,EmployeeID,StyleID,ColourID,SOQty,StartIssuedate,LastIssueDate,FirstIssueDate,Year)  VALUES('" + cmpId + "','" + saleHead.CustID + "','" + line.EmployeeId + "','" + line.StyleID + "','" + line.ColourID + "'," + line.OrdQty + ",'" + saleHead.OrderDate + "','" + saleHead.OrderDate + "','" + saleHead.OrderDate + "'," + sYear + ")";
                                        }
                                        else
                                        {
                                            sSQL = "UPDATE tblaccemp_stockcard SET SOQty=SOQty+" + line.OrdQty + " WHERE CompanyID='" + cmpId + "' AND BusinessID='" + saleHead.CustID + "' AND EmployeeID='" + saleHead.EmployeeID + "' AND StyleID='" + line.StyleID + "' AND ColourID='" + line.ColourID + "' AND Year=" + sYear;
                                        }
                                        if (ExecuteQuery(sSQL) > 0)
                                        {
                                            result = true;
                                            //AddtologStockCard(SQL)
                                        }
                                        if (Convert.ToBoolean(POINTSREQ))
                                        {
                                            string existQry = "";
                                            existQry = existQry + "SELECT * FROM `tblaccemp_pointscard` WHERE `CompanyID`='"+cmpId+ "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID + "' AND `ColourID`='" + line.ColourID + "' AND `Year`=0";
                                            DataTable dt = new DataTable();
                                            dt = GetDataTable(existQry);
                                            if (dt.Rows.Count > 0)
                                            {
                                                string sSql1 = "";
                                                int sum = Convert.ToInt32(dt.Rows[0]["SOPoints"].ToString()) + (line.TotalPoints);
                                                sSql1 = sSql1 + "UPDATE `tblaccemp_pointscard` SET `SOPoints`="+ sum + " WHERE `CompanyID`='"+cmpId+ "' AND `BusinessID`='" + busId + "' AND `EmployeeID`='" + line.EmployeeId + "' AND `StyleID`='" + line.StyleID + "' AND `ColourID`='" + line.ColourID + "' AND `Year`=0";
                                                if (ExecuteQuery(sSql1) > 0)
                                                {
                                                    result = true;
                                                    //AddtologStockCard(SQL)
                                                }
                                                else
                                                {
                                                    result = false;
                                                }
                                            }
                                            else
                                            {
                                                string sSql1 = "";
                                                sSql1 = sSql1 + "INSERT INTO `tblaccemp_pointscard`(`CompanyID`,`BusinessID`,`EmployeeID`,`StyleID`,`ColourID`,`Year`,`SOPoints`,`FirstIssueDate`,`StartIssueDate`,`LastIssueDate`) VALUES ('" + cmpId + "','" + busId + "','" + saleHead.EmployeeID + "','" + line.StyleID + "','" + line.ColourID + "',0," + line.Points * line.OrdQty + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                                                if (ExecuteQuery(sSql1) > 0)
                                                {
                                                    result = true;
                                                    //AddtologStockCard(SQL)
                                                }
                                                else
                                                {
                                                    result = false;
                                                }
                                            }
                                           
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;

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
            catch
            {

            }
            finally
            {

            }
            return intOpenManpack;
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
            foreach (var line in salesHead.SalesOrderLine)
            {
                if (!IsCarriageStyle(line.StyleID))
                {
                    if (line.OriginalLineNo == 0 || line.OriginalLineNo == null)
                    {
                        if (Convert.ToBoolean(BusinessParam("DIMALLOC_LAYOUT", busId)))
                        {
                            string mysql = "SELECT DISTINCT if(isnull(FreeText),'',FreeText) as FreeText  FROM tblfsk_style_freetext WHERE StyleID='" + line.StyleID + "' AND FreeTextType IN ('" + FITALLOCvalue + "','" + DIMALLOCvalue + "')";
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
                                mAnnual = EmpAnnualIssue(line.StyleID, FITALLOC, DIMALLOC, line.ColourID, salesHead.UCodeId, booDimAlloc);
                                AnnualIssue = mAnnual;
                                if (AnnualIssue > 0)
                                {
                                    mCurrStock = EmpStock(line.StyleID, FITALLOC, DIMALLOC, RolloutName, busId, line.ColourID, cmpId, busId, salesHead.EmployeeID, booDimAlloc);
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
                            catch
                            {
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
            catch
            {

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
            catch
            {

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
            catch
            {

            }
            finally
            {

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
        public int ExecuteQuery(string sSqry = "")
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sSqry, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

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

    }
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