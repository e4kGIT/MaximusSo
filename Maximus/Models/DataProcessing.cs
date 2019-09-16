using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using Maximus.Utilities;
using System.Text.RegularExpressions;

namespace Maximus.Models
{
    public class DataProcessing
    {
        #region parameter Declaration
        List<AllowUsers> result1 = new List<AllowUsers>();
        e4kmaximusdbEntities enty = new e4kmaximusdbEntities();
        Log log = new Log();
        private static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Maximus"].ConnectionString;
        private static string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"];
        public static string appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
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
                log.Error(e.Message);
            }
            return null;
        }
        #endregion

        #region getFreeTextStyles
        public List<styleViewmodel> getFreeTextStyles(string freeText, string selectedEmp, string buisnessId)
        {
            var result = new List<styleViewmodel>();
            List<string> getFreTxt = new List<string>();
            var freeTxtType = Allocation.DIMALLOC.ToString();
            var freeTxtLst = enty.ucodeby_freetextview.Where(x => x.DimFreeText == freeText).Select(x => x.FreeText).Distinct().ToList();
            var styleLst = new List<string>();
            var requestContext = HttpContext.Current.Request.RequestContext;

            try
            {
                if (freeTxtLst.Count < 2)
                {
                    styleLst.AddRange(enty.tblfsk_style_freetext.Where(x => x.FreeText == freeText && x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList());
                }
                else
                {
                    foreach (var fretxt in freeTxtLst)
                    {
                        styleLst.Add(getStyleFromFretxt(fretxt));
                    }
                }
                foreach (var styles in styleLst)
                {
                    styleViewmodel svm = new styleViewmodel();
                    svm = getDimStylandImg(styles);
                    if (svm.StyleImage.Contains(":"))
                    {
                        if (System.IO.File.Exists(appPath + svm.StyleImage.Substring(svm.StyleImage.IndexOf(":") + 1, svm.StyleImage.Length - svm.StyleImage.IndexOf(":") - 1)) != true)
                        {
                            svm.StyleImage = "/StyleImages/notfound.png";
                        }
                        else
                        {
                            var data = svm.StyleImage.Substring(svm.StyleImage.IndexOf(":") + 1, svm.StyleImage.Length - svm.StyleImage.IndexOf(":") - 1);
                            svm.StyleImage = data.Replace("\\", "/");
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(appPath + svm.StyleImage) != true)
                        {
                            svm.StyleImage = "/StyleImages/notfound.png";
                        }
                        else
                        {
                            svm.StyleImage = svm.StyleImage;
                        }
                    }
                    if (svm != null)
                    {
                        result.Add(svm);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return result;
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
                log.Error(e.Message);
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
                log.Error(e.Message);
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
                            svm.Assembly = enty.getcustassemblies.Where(d => d.ParentStyleID == style).Any() ? enty.getcustassemblies.Where(d => d.ParentStyleID == style && d.isChargeable == 0).Any() ? 1 : 0 : 0;
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
                log.Error(e.Message);
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
                            svm.Assembly = enty.getcustassemblies.Where(d => d.ParentStyleID == style).Any() ? enty.getcustassemblies.Where(d => d.ParentStyleID == style && d.isChargeable == 0).Any() ? 1 : 0 : 0;
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
                log.Error(e.Message);
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
                log.Error(e.Message);
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

        #region GetOrderPermission
        public string GetOrderPermission()
        {
            return System.Web.HttpContext.Current.Session["OrderPermit"].ToString() == "" ? "" : System.Web.HttpContext.Current.Session["OrderPermit"].ToString();
        }

        #endregion

        #region GetUcodeList
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
                log.Error(e.Message);
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
                log.Error(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region LimitEmpUsers
        public bool LimitEmpUsers(string access)
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
                    return Convert.ToBoolean(BusinessParam("LimitUsrEmp", System.Web.HttpContext.Current.Session["BuisnessId"].ToString().Trim()));
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
            { ControlName = "OVERRIDE_ENT_WITH_REASON"; }
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
                //DataTable dt = new DataTable();
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        result = dr.ItemArray[0].ToString();
                //    }
                //    return result;
                //}
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
        //    Public Function getRoleName(ByVal RoleID As Integer) As String
        //    Dim rs As New ADODB.Recordset
        //    Dim sql As String
        //    If Conn Is Nothing Then
        //        Conn = OpenDatabase()
        //    End If
        //    If Conn.State = 0 Then
        //        Conn.Open()
        //    End If
        //    sql = "SELECT RoleName FROM tblroles WHERE RoleID=" & RoleID
        //    rs.Open(sql, Conn)
        //    If Not rs.EOF Then
        //        getRoleName = rs("RoleName").Value
        //    Else
        //        getRoleName = ""
        //    End If
        //    rs.Close()
        //    rs = Nothing
        //End Function
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
            //Dim val() As String = { "'" & Users & "'", HttpContext.Current.Session("CustID")}
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
                    emplList = "'" + getZeroLevelUsers(Users) + ",";
                    result1.Add(new Models.AllowUsers { users = emplList, count = emplList.Count() });
                }
                else
                {
                    UserList += "'" + usrs + "',";
                    result1.Add(new Models.AllowUsers { users = UserList, count = UserList.Count() });
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
            result1.Add(new Models.AllowUsers { users = UserList, count = UserList.Count() });
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
                    result = result.Substring(result.Length - 1) == "'" ? "'" + result : "'" + result + "'";
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

        //public string getZeroLevelUsersTest(string param)
        //{
        //    string qry = "CALL GetZeroLevelUsersSp('Ady Hussain')";
        //    MySqlConnection conn = new MySqlConnection(ConnectionString);
        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand command = new MySqlCommand("GetZeroLevelUsersSp", conn);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new MySqlParameter("Users", "Ady Hussain"));
        //        var  result = (command.ExecuteScalar());
        //        return "";
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return "";
        //}

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
                //      If IsDBNull(rsUser("UsersAllow").Value) Then
                //    parentlist = mylist
                //Else
                //    parentlist = mylist & "," & Replace(("'" & rsUser("UsersAllow").Value & "'"), ",", "','")
                //End If
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

        #region GetEmployee
        public List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            List<EmployeeViewModel> result1 = new List<EmployeeViewModel>();
            return result1 = GetEmployeeByProcedure(busId, userId);

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
            return result1;
            //return GetDataTable(strsql);
        }
        #endregion

        #region GetEmployeeByProcedure

        public List<EmployeeViewModel> GetEmployeeByProcedure(string busId, string userId = "")
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            var role = enty.tblusers.Where(x => x.UserName == userId && x.BusinessID == busId && x.Active == "Y").First().AccessID;
            string strCompanyID = ConfigurationManager.AppSettings["CompanyId"].ToString();
            string sSqry = "";
            sSqry = "CALL `GetEmployeeByRoles1`('" + strCompanyID + "','" + busId + "','" + userId + "','" + role + "')";
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
                        result.Add(new EmployeeViewModel { EmployeeId = dr.ItemArray[1].ToString(), EmpFirstName = dr.ItemArray[4].ToString(), Department = dr.ItemArray[3].ToString(), EmpLastName = dr.ItemArray[5].ToString(), EmpUcodes = dr.ItemArray[8].ToString(), StartDate = DateTime.Parse(dr.ItemArray[6].ToString()), EndDate = DateTime.Parse(dr.ItemArray[7].ToString()), role = dr.ItemArray[9].ToString() });
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
            data = enty.tblbus_setvalues.Any(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId) ? enty.tblbus_setvalues.Where(x => x.BusinessID == businessId & x.CompanyID == cmpId & x.SettingID == paramId).First().Value : "";
            if (data != "" && data != null)
            {
                return data;
            }
            else
            {
                data = enty.tblbus_settings.Where(x => x.SettingID == paramId).First().DefaultValue;
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
            data = enty.tblcmp_defaults.Where(x => x.CompanyID == companyId & x.ParamID == paramID).First().Value;
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
            result = enty.tblgen_user_defaults.Where(x => x.ParamID == paramId && x.UserID == userId).First().Param_Value;
            if (result != "" && result != null)
            {
                return result;
            }
            else
            {
                result = enty.tblgen_user_parameters.Where(x => x.ParamID == paramId).First().Default_Value;
                if (result != "" && result != null)
                {
                    return result;
                }
            }
            return result;
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
                log.Error(e.Message);
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
                log.Error(e.Message);
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
                log.Error(e.Message);
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
                            emp.EmpIsActive = data.ItemArray[9].ToString() == "0" ? true : false;
                        }
                    }
                    return emp;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
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
                    cmd.CommandTimeout = 10000;
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
                log.Error(e.Message);
            }
            return result;
        }
        #endregion

        #region getstyleviewmodel

        public List<styleViewmodel> GetStyleViewModel(string Template)
        {
            List<styleViewmodel> svm = new List<styleViewmodel>();
            foreach (var item in enty.tblsop_customerorder_template.Where(x => x.Template == Template).Select(x => new { x.Style }).Distinct().ToList())
            {
                svm.Add(new styleViewmodel
                {
                    StyleID = item.Style,
                    Description = enty.tblfsk_style.Where(x => x.StyleID == item.Style).First().Description,
                    StyleImage = enty.tblfsk_style.Where(x => x.StyleID == item.Style).First().StyleImage,
                    ProductGroup = enty.tblfsk_style.Where(x => x.StyleID == item.Style).First().Product_Group.Value,

                });
            }

            return svm;
        }
        public List<int> GetProductGroup(string Template)
        {
            List<int> svm = new List<int>();
            foreach (var item in enty.tblsop_customerorder_template.Where(x => x.Template == Template).Select(x => new { x.Style }).Distinct().ToList())
            {
                svm.Add(enty.tblfsk_style.Where(x => x.StyleID == item.Style).First().Product_Group.Value);
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
                    cmd.CommandTimeout = 10000;
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
                log.Error(e.Message);
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
                    cmd.CommandTimeout = 10000;
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
                log.Error(e.Message);
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
                cmd.CommandTimeout = 10000;
                result = (cmd.ExecuteScalar()).ToString();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        #endregion

        #region GetAllPreviousData
        public string GetAllPreviousData(string EmpId, string BuisnessId, string styleId)
        {
            string result = "";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                DataTable dt = new DataTable();
                string sQry = "CALL `GetPreviousDataByEmployee`('" + styleId + "','" + BuisnessId + "','" + EmpId + "')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sQry, con);
                cmd.CommandTimeout = 10000;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        result = "<tr><td>Issued: " + dr.ItemArray[4].ToString() + "</td></tr><tr><td>Orderno: " + dr.ItemArray[1].ToString() + " Orderdate:" + DateTime.Parse(dr.ItemArray[3].ToString()).ToString("dd-MM-yyyy") + "</td></tr></table>";
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
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
                string sQry = "CALL `GetPreviousHistory`('" + styleId + "','" + BuisnessId + "','" + EmpId + "')";
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
                log.Error(e.Message);
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
                log.Error(e.Message);
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
            try
            {
                var S = Convert.ToSByte(true);
                var assemblyId = enty.tblasm_assemblyheader.Where(x => x.StyleID == ParentStyle && x.CustID == BusinessId && x.Live == 1 && x.Enabled == 1).FirstOrDefault().AssemblyID;
                int qtity = enty.tblasm_assemblydetail.Any(x => x.StyleID == StyleId && x.AssemblyID == assemblyId) ? enty.tblasm_assemblydetail.Where(x => x.StyleID == StyleId && x.AssemblyID == assemblyId).FirstOrDefault().Qty.Value : 0;
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

        #region usermodule

        public string PermissionSettings(string busId, string userId, string controlId, string accessId)
        {
            string permisson = "";
            if (userId != "")
            {
                //if (enty.tblpermission_settings_users.Any(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.UserID.ToLower().Trim() == userId.ToLower().Trim() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                //{
                //    permisson = enty.tblpermission_settings_users.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.UserID.ToLower().Trim() == userId.ToLower().Trim() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                //}
                //else if (enty.tblpermission_settings.Any(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                //{
                //    permisson = enty.tblpermission_settings.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                //}
                //else if (enty.tblpermission_settings.Any(x => x.BusinessID.ToLower().Trim() == "all" && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                //{
                //    permisson = enty.tblpermission_settings.Where(x => x.BusinessID.ToLower().Trim() == "all" && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                //}
                //else
                //{
                //    permisson = enty.tblpermission_controls.Any(x => x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()) ? enty.tblpermission_controls.Where(x => x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Defaults : "HIDE";
                //}
                if (enty.tblpermission_controls.Any(x => x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                {
                    permisson = enty.tblpermission_controls.Any(x => x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()) ? enty.tblpermission_controls.Where(x => x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Defaults : "HIDE";
                    if(enty.tblpermission_settings.Any(x => x.BusinessID.ToLower().Trim() == "all" && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                    {
                        permisson = enty.tblpermission_settings.Where(x => x.BusinessID.ToLower().Trim() == "all" && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                      
                    }
                    else if(enty.tblpermission_settings.Any(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                    {
                        permisson = enty.tblpermission_settings.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.AccessID.ToLower() == accessId.Trim().ToLower() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                      
                    }
                    else if (enty.tblpermission_settings_users.Any(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.UserID.ToLower().Trim() == userId.ToLower().Trim() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()))
                    {
                        permisson = enty.tblpermission_settings_users.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.UserID.ToLower().Trim() == userId.ToLower().Trim() && x.ControlID.ToLower().Trim() == controlId.ToLower().Trim()).First().Permission;
                    }
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
                log.Error(e.Message);
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
                if(dt.Rows.Count>0)
                {
                   foreach(DataRow dr in dt.Rows)
                    {
                        result.Add(dr.ItemArray[0] + "|" + dr.ItemArray[1] + "|" + dr.ItemArray[2]);
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
                        result.Add(dr.ItemArray[0] + "|" + dr.ItemArray[1] );
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

        public BusAddress GetAddressDetails(string qry)
        {
            var BusAddress = new BusAddress();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        BusAddress.AddressDescription = reader.GetString("Description") != "" ? reader.GetString("Description") : "";
                        BusAddress.Address1 = reader.GetString("Address1") != "" ? reader.GetString("Address1") : "";
                        BusAddress.Address2 = reader.GetString("Address2") != "" ? reader.GetString("Address2") : "";
                        BusAddress.Address3 = reader.GetString("Address3") != "" ? reader.GetString("Address3") : "";
                        BusAddress.AddressDescription = reader.GetString("Town") != "" ? reader.GetString("Town") : "";
                        BusAddress.City = reader.GetString("City") != "" ? reader.GetString("City") : "";
                        BusAddress.PostCode = reader.GetString("Postcode") != "" ? reader.GetString("Postcode") : "";
                        BusAddress.Country = reader.GetString("Country") != "" ? reader.GetString("Country") : "";
                    }
                    return BusAddress;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return BusAddress;
        }
        public List<BusAddress> FillCombo_CustomerDelivery(bool IsManpack = false)
        {
            var result = new List<BusAddress>();
            string extraQry = "";
            string sQry = "";
            string busId = System.Web.HttpContext.Current.Session["BuisnessId"].ToString();
            if (IsManpack)
            {
                //extraQry = extraQry + " (onusraddr.`OnlineUserId`IN (" + getPermissionUsers(GetOrderPermission(), System.Web.HttpContext.Current.Session["UserName"].ToString(), busId) + ") OR onusraddr.`Employeeid` = '" & Emplist1.CurrentEmployee & "') ";
            }
            else
            {
                extraQry = extraQry + " onusraddr.`OnlineUserId`='" + System.Web.HttpContext.Current.Session["UserName"].ToString() + "' ";
            }
            if (Convert.ToBoolean(BusinessParam("LIMITUSRADDR", busId)) && !IsGetAllDelAddress())
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
                        result.Add(new BusAddress { AddressDescription = dr.ItemArray[0].ToString(), Address1 = dr.ItemArray[1].ToString(), Address2 = dr.ItemArray[2].ToString(), Address3 = dr.ItemArray[3].ToString(), City = dr.ItemArray[5].ToString(), PostCode = dr.ItemArray[6].ToString(), AddressId = Convert.ToInt32(dr.ItemArray[9].ToString()), Country = dr.ItemArray[7].ToString(), contactId = dr.ItemArray[10].ToString() });
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

        public bool IsGetAllDelAddress()
        {
            try
            {
                if (HttpContext.Current.Session["Access"].ToString().ToUpper() == "ADMIN")
                {
                    return true;
                }
                else
                {
                    return getPermission(controls.AllAddress, HttpContext.Current.Session["Access"].ToString(), HttpContext.Current.Session["BuisnessId"].ToString()).ToString().Trim().ToUpper().Equals("SHOW");
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }
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