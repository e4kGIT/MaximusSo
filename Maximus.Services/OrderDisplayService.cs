using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using System.Globalization;

namespace Maximus.Services
{
    public class OrderDisplayService : IOrderDisplay
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly tblSalesOrderHeader _salesOrderHeader;
        public readonly tblSalesLines _salesOrderLines;
        public readonly tblManPackOrders _manPackOrders;
        public readonly tblCourrierRef _courrierRef;
        public readonly Employee _employee;
        public readonly PointsCard _pointsCard;
        public readonly ViewPointsCard _vuPointsCard;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointStyle _pointsStyle;
        public readonly DataProcessing _dp;
        public readonly tblManPackOrders _tblManpack;
        public readonly User _users;
        public readonly Company _tblCompany;
        public readonly BusBusiness _busBusiness;
        public readonly tblManPackOrders _manpack;
        public readonly Warehouses _wareHouses;
        public readonly User _user;
        public readonly Company _comapany;
        public readonly Ucode_Description _ucodes;
        public OrderDisplayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Company comapany = new Company(_unitOfWork);
            tblSalesOrderHeader salesOrderHeader = new tblSalesOrderHeader(_unitOfWork);
            User user = new User(_unitOfWork);
            tblSalesLines salesOrderLines = new tblSalesLines(_unitOfWork);
            tblManPackOrders manPackOrders = new tblManPackOrders(_unitOfWork);
            tblCourrierRef courrierRef = new tblCourrierRef(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            ViewPointsCard vuPointsCard = new ViewPointsCard(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointStyle pointsStyle = new PointStyle(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            tblManPackOrders tblManpack = new tblManPackOrders(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            User users = new User(_unitOfWork);
            Company tblCompany = new Company(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            tblManPackOrders manpack = new tblManPackOrders(_unitOfWork);
            Warehouses wareHouses = new Warehouses(_unitOfWork);
            Ucode_Description ucodes = new Ucode_Description(_unitOfWork);
            _salesOrderHeader = salesOrderHeader;
            _users = users;
            _pointsStyle = pointsStyle;
            _salesOrderLines = salesOrderLines;
            _manPackOrders = manPackOrders;
            _courrierRef = courrierRef;
            _employee = employee;
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _vuPointsCard = vuPointsCard;
            _dp = dp;
            _tblManpack = tblManpack;
            _tblCompany = tblCompany;
            _busBusiness = busBusiness;
            _manpack = manpack;
            _wareHouses = wareHouses;
            _user = user;
            _comapany = comapany;
            _ucodes = ucodes;
        }
        public List<OrderDisplayModel> GetAllOrders(string OrderType, string busId, bool booPoints, string userId, List<string> usrs, string role, string orderPermission, bool isEmergencyOrder = false, bool booIsConfirm = false, bool isPrnt = false,string RequirePermissionUSR="")
        {
            List<OrderDisplayModel> lst = new List<OrderDisplayModel>();
            if (isPrnt == false)
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = DateTime.Now.AddMonths(-3);
            }
            if (booIsConfirm)
            {
                lst = _dp.GetAllOrders(OrderType, busId, userId, usrs, role, booPoints, orderPermission,isEmergencyOrder, booIsConfirm,RequirePermissionUSR);
            }
            else
            {
                lst = _dp.GetAllOrders(OrderType,busId, userId, usrs, role, booPoints, orderPermission, isEmergencyOrder,false, RequirePermissionUSR);
            }
            //var soh = _salesOrderHeader.GetAll(s => s.CustID == busId && usrs.Contains(s.OnlineUserID)).OrderByDescending(s => s.OrderNo).ToList();
            //foreach (var sod in soh)
            //{
            //    var totalQty = _salesOrderLines.GetAll(s => s.OrderNo == sod.OrderNo && s.OriginalLineNo == 0).Sum(s => s.OrdQty);
            //    var manPackNo = _manPackOrders.Exists(s => s.OrderNo == sod.OrderNo) ? _manPackOrders.GetAll(s => s.OrderNo == sod.OrderNo).First().ManPackNo : 0;
            //    var courrierRef = _courrierRef.Exists(s => s.OrderNo == sod.OrderNo) ? _courrierRef.GetAll(s => s.OrderNo == sod.OrderNo).First().CourierRef : "";
            //    var firstDespatch = _courrierRef.Exists(s => s.OrderNo == sod.OrderNo) ? _courrierRef.GetAll(s => s.OrderNo == sod.OrderNo).First().DespatchDate : null;
            //    var empName = _employee.Exists(s => s.EmployeeID == sod.PinNo) ? _employee.GetAll(s => s.EmployeeID == sod.PinNo).First().Forename + " " + _employee.GetAll(s => s.EmployeeID == sod.PinNo).First().Surname : "";
            //    var totPoints = _pointsByUcode.Exists(s => s.UcodeID == sod.UCodeId) ? _pointsByUcode.GetAll(s => s.UcodeID == sod.UCodeId).First().TotalPoints : 0;
            //    var usedPoints = 0;
            //   // usedPoints = GetOrderPoints(sod);
            //    var saledetail = _salesOrderLines.GetAll(s => s.OrderNo == sod.OrderNo).Select(s => new SalesOrderLineViewModel { StyleID = s.StyleID, ColourID = s.ColourID, SizeID = s.SizeID, OrdQty = s.OrdQty.Value }).ToList();
            //    lst.Add(new OrderDisplayModel { Address1 = sod.DelAddress1, CustomerRef = sod.CustRef, DelDesc = sod.DelDesc, EmpID = sod.PinNo, UserId = sod.OnlineUserID, FirstDespatch = firstDespatch, CourrierRef = courrierRef, IsConfirmed = Convert.ToBoolean(sod.OnlineConfirm) ? "YES" : "NO", IsProcessed = Convert.ToBoolean(sod.OnlineProcessed) ? "YES" : "NO", NominalCode = sod.OrderAnalysisCode1, OrderDate = sod.OrderDate.Value, OrderNo = sod.OrderNo, PersonPackNo = manPackNo, TotalQty = totalQty.Value, EmpName = empName, PointsSpent = usedPoints, TotalPoints = totPoints.Value, GoodsValue = sod.OrderGoods.Value, TotalIncVat = sod.TotalGoods.Value, saleDetail = saledetail });
            //}
            return lst;
        }
        public int GetOrderPoints(tblsop_salesorder_header saleHed)
        {
            int points = 0;
            var ucodeExistance = _pointsByUcode.Exists(s => s.UcodeID == saleHed.UCodeId && s.BusinessID == saleHed.CustID);
            if (saleHed.ReasonCode == 0 && ucodeExistance)
            {
                try
                {
                    var lines = _salesOrderLines.GetAll(s => s.OrderNo == saleHed.OrderNo).ToList();
                    foreach (var line in lines)
                    {

                        int ss = _pointsStyle.GetAll(s => s.UcodeID == saleHed.UCodeId && s.StyleID == line.StyleID).First().Points.Value * Convert.ToInt32(line.OrdQty);
                        points = points + ss;
                    }
                }
                catch (Exception e)
                {

                }
            }
            return points;
        }

        public bool ConfirmOrders(List<SalesConfirmModel> orderLst, bool isManpack, string userId, string cmpLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string busId,bool isemergency)
        {
            bool result = false;
            bool REQ_ORD_CONFM_MAIL = _dp.BusinessParam("REQ_ORD_CONFM_MAIL", busId) != "" ? Convert.ToBoolean(_dp.BusinessParam("REQ_ORD_CONFM_MAIL", busId)) : false;
            try
            {
                if (orderLst.Count > 0)
                {
                    string onlineUserid = "";
                    string pinNo = "";
                    string cmp = "";
                    double total = 0;
                    foreach (var orderNos in orderLst)
                    {
                        int Out;
                        int orderNo = int.TryParse(orderNos.SalesOrderNo, out Out) ? Convert.ToInt32(orderNos.SalesOrderNo) : 0;
                        int manPackOno = int.TryParse(orderNos.ManPackNo, out Out) ? Convert.ToInt32(orderNos.ManPackNo) : 0;
                        if (orderNo > 0 && manPackOno > 0)
                        {
                            if (_salesOrderHeader.Exists(s => s.OrderNo == orderNo))
                            {
                                var salesHead = _salesOrderHeader.GetAll(s => s.OrderNo == orderNo).First();
                                salesHead.OnlineConfirm = Convert.ToSByte(true);
                                salesHead.OnlineConfirmDate = DateTime.Now;
                                salesHead.OnlineConfirmedBy = userId;
                                _salesOrderHeader.Update(salesHead);
                                onlineUserid = salesHead.OnlineUserID;
                                pinNo = salesHead.PinNo;
                                cmp = salesHead.CompanyID;
                                total = salesHead.TotalGoods.Value;
                            }
                            if (isManpack)
                            {
                                if (_manPackOrders.Exists(s => s.ManPackNo == manPackOno && s.OrderNo == orderNo))
                                {
                                    var manPack = _manPackOrders.GetAll(s => s.OrderNo == orderNo && s.ManPackNo == manPackOno).First();
                                    manPack.OnlineConfirm = Convert.ToSByte(true);
                                    manPack.OnlineConfirmDate = DateTime.Now;
                                    _manPackOrders.Update(manPack);
                                }

                            }
                            result = true;
                        }
                        if (result == true)
                        {
                            if (REQ_ORD_CONFM_MAIL || isemergency)
                            {
                                OrderConfirmationMail(orderNo, manPackOno, onlineUserid, userId, pinNo, cmpLogo, adminMail, mailUsername, mailPassword, mailPort, mailServer, cmp, total);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }
        public void OrderConfirmationMail(int orderNO, int manPackno, string onlineUserid, string userI, string empId, string cmpLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string cmp, double total)
        {
            string subject = "";
            string mailMessage = "";
            string empname = "";
            string adminname = "";
            string onlineuserName = "";
            string orguserMail = "";
            string bcc = "";
            string cc = "";
            string toemail = "";
            string cmpId = "";
            subject = "Online Order Confirmed";
            cmpId = _tblCompany.GetAll(s => s.CompanyID == cmp).First().Name;
            toemail = _users.Exists(s => s.UserName == onlineUserid) ? _users.GetAll(s => s.UserName == onlineUserid).First().Email_ID : "";
            onlineuserName = _users.Exists(s => s.UserName == onlineUserid) ? _users.GetAll(s => s.UserName == onlineUserid).First().ForeName + " " + _users.GetAll(s => s.UserName == onlineUserid).First().SurName : "";
            empname = _users.Exists(s => s.UserName == empId) ? _users.GetAll(s => s.UserName == empId).First().ForeName + " " + _users.GetAll(s => s.UserName == empId).First().SurName : "";
            adminname = _users.Exists(s => s.UserName == userI) ? _users.GetAll(s => s.UserName == userI).First().ForeName + " " + _users.GetAll(s => s.UserName == userI).First().SurName : "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string ConfirmOrderTemplate = System.IO.File.ReadAllText(appPath + "\\ConfirmOrderTemplate.html");
            StringBuilder confirmOrderBuilder = new StringBuilder(ConfirmOrderTemplate);
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%orderno%", orderNO.ToString());
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%orderdate%", DateTime.Now.ToString("dd-MM-yyyy"));
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%cmplogo%", cmpLogo);
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%total%", total.ToString());
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%adminname%", adminname);
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%onlineusername%", onlineuserName);
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%companyname%", cmpId);
            ConfirmOrderTemplate = ConfirmOrderTemplate.Replace("%empname%", empname);
            if (toemail != "")
            {
                _dp.sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, ConfirmOrderTemplate, toemail, bcc, cc);
            }

        }

        public string GetPrintTemplate(int fromOrdNo, int toOrdNo, string cmpLogo, string custlogo, string userId, string pricePermission, string ONLCUSREFLBL)
        {
            string result = "";
            try
            {
                if (fromOrdNo > 0 && toOrdNo > 0)
                {
                    if (_salesOrderHeader.Exists(s => s.OrderNo == fromOrdNo || s.OrderNo == toOrdNo))
                    {
                        var saleLst = _salesOrderHeader.GetAll(s => s.OrderNo >= fromOrdNo && s.OrderNo <= toOrdNo).ToList();
                        if (saleLst.Count > 0)
                        {
                            result = GetConfirmPrintTemplate(saleLst, cmpLogo, custlogo, userId, pricePermission, ONLCUSREFLBL);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                result = "";
            }

            return result;
        }

        #region GetConfirmPrintTemplate

        public string GetConfirmPrintTemplate(List<tblsop_salesorder_header> salesHeadLst, string cmplogo, string custLogo, string userId, string pricePermission, string ONLCUSREFLBL)
        {
            string result = "";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates";
            string orderHeaderTemplate = System.IO.File.ReadAllText(appPath + "\\OrderHeader_Template.html");
            string eachorderTemp = "";
            string orderHeaderTemplateMess = "";
            string FillmailTemplatemess = "";
            string companyID = salesHeadLst.First().CompanyID;
            foreach (var salesHead in salesHeadLst)
            {
                string orderLinesTemplate = System.IO.File.ReadAllText(appPath + "\\OrderLines_Template.html");
                string orderDetailTemplate = System.IO.File.ReadAllText(appPath + "\\OrderDetail_Template.html");
                string txtNomlbl = _dp.BusinessParam("ONLNETXTNOM1", salesHead.CustID);
                string reqnom = _dp.CompanyParam("ONLNEREQNOM1", salesHead.CompanyID);
                BusAddress1 custAdd = new BusAddress1();
                if (1 == 1)
                {
                    string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + salesHead.CustID + "' and tblbus_countrycodes.CompanyID = '" + salesHead.CompanyID + "' Order By tblbus_address.Description";
                    custAdd = _dp.GetAddressDetails(SQL);
                }
                if (txtNomlbl == "")
                {
                    if (reqnom != "")
                    {
                        if (Convert.ToBoolean(reqnom))
                        {
                            txtNomlbl = _dp.CompanyParam("ONLNETXTNOM1", salesHead.CompanyID);
                        }
                        else
                        {
                            txtNomlbl = "Nominal Code";
                        }
                    }
                }
                FillmailTemplatemess = FillmailTemplatemess + FillmailTemplate(orderDetailTemplate, salesHead, orderLinesTemplate, pricePermission, ONLCUSREFLBL) + "<br/><br/><br/><br/><br/>";

            }
            if (orderHeaderTemplate != "")
            {
                string txtNomlbl = _dp.BusinessParam("ONLNETXTNOM1", salesHeadLst.First().CustID);
                string reqnom = _dp.CompanyParam("ONLNEREQNOM1", salesHeadLst.First().CompanyID);

                var custAdd = new BusAddress1();
                if (1 == 1)
                {
                    string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + salesHeadLst.First().CustID + "' and tblbus_countrycodes.CompanyID = '" + salesHeadLst.First().CompanyID + "' Order By tblbus_address.Description";
                    custAdd = _dp.GetAddressDetails(SQL);
                }
                if (txtNomlbl == "")
                {
                    if (reqnom != "")
                    {
                        if (Convert.ToBoolean(reqnom))
                        {
                            txtNomlbl = _dp.CompanyParam("ONLNETXTNOM1", salesHeadLst.First().CompanyID);
                        }
                        else
                        {
                            txtNomlbl = "Nominal Code";
                        }
                    }
                }
                var orderHeaderbuilder = new StringBuilder(orderHeaderTemplate);

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
                if (cmplogo != "")
                {
                    var cmpLogoPath = cmplogo;
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%CompLogoPath%", cmpLogoPath);
                }
                else
                {
                    // "Images/no_image.gif"
                }
                try
                {
                    var cmp = _comapany.Exists(s => s.CompanyID == companyID) ? _comapany.GetAll(s => s.CompanyID == companyID).First() : new tblcompany();
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyname%", cmp.Name);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyaddress1%", cmp.Address1);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyaddress2%", cmp.Address2);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyaddress3%", cmp.Address3);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyaddress4%", cmp.Address4);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companypostcode%", cmp.PostCode);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companytel%", cmp.Phone);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyfax%", cmp.Fax);
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyemail%", cmp.Email); ;
                    orderHeaderbuilder = orderHeaderbuilder.Replace("%first_companyvat%", cmp.VATno); ;
                }
                catch (Exception e)
                { }
                orderHeaderTemplateMess = orderHeaderTemplateMess + orderHeaderbuilder;
            }
            result = result + "<html><head></head><body>" + orderHeaderTemplateMess + "<br/><br/><br/>" + FillmailTemplatemess + "</body></html>";
            return result;


        }
        #endregion
        #region fillmailTemplate
        public string FillmailTemplate(string detailTemp, tblsop_salesorder_header saleshead, string emailLine, string pricePermission, string ONLCUSREFLBL)
        {
            string empname = "";
            string Barcode = "";
            string carrierCharges = "N";
            string stlLine = "", returnString = "";
            string strsql = "SELECT count(t1.ProjectCode) as cntproject  FROM tblsop_customerorder_template_costcentre t1 WHERE t1.Businessid='{0}'  ORDER BY t1.ProjectCode ASC";
            var builder1 = new StringBuilder(detailTemp);
            int projCode = _dp.CheckForProjectCode(strsql);
            string empTite = "";
            var manpack = _manpack.Exists(s => s.OrderNo == saleshead.OrderNo) ? _manpack.GetAll(s => s.OrderNo == saleshead.OrderNo).First().ManPackNo : 0;
            try
            {
                empname = _user.Exists(s => s.UserName == saleshead.PinNo) ? _user.GetAll(s => s.UserName == saleshead.PinNo).First().ForeName + " " + _user.GetAll(s => s.UserName == saleshead.PinNo).First().SurName : "";
                empTite = _employee.Exists(s => s.EmployeeID == saleshead.PinNo) ? _employee.GetAll(s => s.EmployeeID == saleshead.PinNo).First().Title : "";
            }
            catch (Exception e)
            {

            }
            if (projCode == 0)
            {
                builder1.Replace("<th>ProjectCode</th>", "");
            }
            builder1.Replace("%BarcodeOrderNo%", "");
            builder1.Replace("%customer_name%", _busBusiness.Exists(s => s.BusinessID == saleshead.CustID) ? _busBusiness.GetAll(s => s.BusinessID == saleshead.CustID).First().Name : "");
            builder1.Replace("%customer_address1%", saleshead.InvAddress1);
            builder1.Replace("%customer_address2%", saleshead.InvAddress2);
            builder1.Replace("%customer_address3%", saleshead.InvAddress3);
            builder1.Replace("%customer_town%", saleshead.InvTown);
            builder1.Replace("%customer_city%", saleshead.InvCity);
            builder1.Replace("%customer_postcode%", saleshead.InvPostCode);
            builder1.Replace("%customer_country%", saleshead.InvCountry);
            if (saleshead.OrderType.ToUpper() == "RT")
            {

            }
            else
            {
                builder1.Replace("%delivery_name%", _busBusiness.Exists(s => s.BusinessID == saleshead.CustID) ? _busBusiness.GetAll(s => s.BusinessID == saleshead.CustID).First().Name : "");
                builder1.Replace("%delivery_address1%", saleshead.DelAddress1);
                builder1.Replace("%delivery_address2%", saleshead.DelAddress2);
                builder1.Replace("%delivery_address3%", saleshead.DelAddress3);
                builder1.Replace("%delivery_town%", saleshead.DelTown);
                builder1.Replace("%delivery_city%", saleshead.DelCity);
                builder1.Replace("%delivery_postcode%", saleshead.DelPostCode);
                builder1.Replace("%delivery_country%", saleshead.DelCountry);
            }
            Barcode = _dp.CompanyParam("BARCODESOPTYPE", saleshead.CompanyID);

            //builder1.Replace("%BarcodeOrderNo%", saleshead.OrderType.ToUpper()=="RT", returnBarcode(myReader("OrderNo").Value, Barcode), ""))
            builder1.Replace("%OrderNo%", saleshead.OrderNo.ToString());
            builder1.Replace("%OrderDate%", saleshead.OrderDate.Value.ToString("dd-MM-yyyy"));
            builder1.Replace("%CustRef%", saleshead.CustRef);
            builder1.Replace("Cust Ref", ONLCUSREFLBL);
            builder1.Replace("%ManPackNo%", manpack == 0 ? "" : manpack.ToString());

            builder1.Replace("%AccountNo%", saleshead.CustID);
            builder1.Replace("%NominalCode%", saleshead.OrderAnalysisCode1 == "" ? "" : saleshead.OrderAnalysisCode1);
            builder1.Replace("%Employee%", saleshead.PinNo + " - " + empTite + " - " + empname);
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

            }
            if (_salesOrderLines.Exists(s => s.OrderNo == saleshead.OrderNo))
            {
                foreach (var saleLine in _salesOrderLines.GetAll(s => s.OrderNo == saleshead.OrderNo))
                {
                    var builder2 = new StringBuilder(emailLine);
                    if (projCode == 0)
                    {
                        builder2.Replace("<td>%ProjectCode%</td>", "");
                    }
                    builder2.Replace("%style%", saleLine.StyleID);
                    builder2.Replace("%Description%", saleLine.Description);
                    builder2.Replace("%Colour%", saleLine.ColourID);
                    builder2.Replace("%Size%", saleLine.SizeID);
                    //If CBool(Session.Item("UseMatrix")) Then
                    //    builder2.Replace("%Colour%", rs1("ColourID").Value)
                    //    builder2.Replace("%Size%", rs1("SizeID").Value)
                    //End If
                    builder2.Replace("%qty%", saleLine.OrdQty.ToString());
                    if (pricePermission.ToUpper() == "READWRITE")
                    {
                        builder2.Replace("%price%", string.Format(CultureInfo.InvariantCulture, "{0:F}", saleLine.Price.ToString()));
                        builder2.Replace("%netvalue%", saleshead.TotalGoods.ToString());
                    }
                    else if (pricePermission.ToUpper() == "READONLY")
                    {
                        builder2.Replace("%price%", String.Format(CultureInfo.InvariantCulture, "{0:F}", saleLine.Price.ToString()));
                        builder2.Replace("%netvalue%", String.Format(CultureInfo.InvariantCulture, "{0:F}", saleshead.TotalGoods.ToString()));
                        builder2.Replace("%vat%", _dp.GetlineTotals(Convert.ToDouble(saleLine.OrdQty), Convert.ToDouble(saleLine.Price), _dp.GetVatPercent(saleLine.StyleID, saleLine.SizeID)).ToString());
                    }
                    else if (pricePermission.ToUpper() == "HIDE")
                    {
                        builder2.Replace("%price%", "N/A");
                        builder2.Replace("%netvalue%", "N/A");
                        builder2.Replace("%vat%", "N/A");
                    }
                    string strFreeText = _dp.StyleParam("REQDATA1", saleLine.StyleID) + " " + saleLine.FreeText + saleLine.NomCode;
                    // builder2.Replace("%freetext%", strFreeText.Trim() == "" ? "" : "(" + strFreeText + ")");
                    builder2.Replace("%reason%", saleLine.SOPDETAIL4);
                    if (saleshead.OrderType.ToUpper() != "RT")
                    {
                        builder2.Replace("%OrgOrderNo%", saleshead.OrderNo.ToString());
                        builder2.Replace("%OrgPORef%", saleshead.CustRef);
                    }
                    else
                    {
                        //builder2.Replace("%OrgOrderNo%", rs1("ReturnOrderNo").Value.ToString)
                        //         builder2.Replace("%OrgPORef%", "")
                    }
                    builder2.Replace("%ProjectCode%", projCode.ToString());
                    stlLine = stlLine + builder2;
                }
                builder1.Replace("%DeliveryDate%", saleshead.OrderDate.Value.ToString("dd-MM-yyyy"));
                builder1.Replace("%OrderLines%", stlLine);
                builder1.Replace("%comments%", saleshead.CommentsExternal);
                builder1.Replace("%totalgoods%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleshead.TotalGoods.Value, 2)));
                if (carrierCharges.ToLower() == "hide")
                {
                    builder1.Replace("Carrier Charges", "");
                    builder1.Replace("%carriercharges%", "");
                }
                else
                {
                    builder1.Replace("%carriercharges%", pricePermission.ToUpper() == "HIDE" ? "N/A" : String.Format(CultureInfo.InvariantCulture, "{0:F}", Math.Round(saleshead.CarrierCharge.Value, 2)));
                }
                builder1.Replace("%vattotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : "");
                builder1.Replace("%ordertotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : (Convert.ToDouble(saleshead.CarrierCharge.Value) + saleshead.TotalGoods.Value).ToString());
                builder1.Replace("%grandtotal%", pricePermission.ToUpper() == "HIDE" ? "N/A" : (Convert.ToDouble(saleshead.CarrierCharge.Value) + saleshead.TotalGoods.Value).ToString());
                //builder1.Replace()
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

            }
            return returnString;
        }
        #region GetOrderDetail
        public List<OrderDisplayDetail> GetOrderDetail(int orderno)
        {
            var OrderDisplayDetail = new List<OrderDisplayDetail>();
            if (_salesOrderLines.Exists(s => s.OrderNo == orderno))
            {
                OrderDisplayDetail = _salesOrderLines.GetAll(s=>s.OrderNo==orderno).Select(s=> new OrderDisplayDetail {
                    ColourID=s.ColourID,
                    SizeID=s.SizeID,StyleID=s.StyleID,
                    Description=s.Description,
                    OrdQty=s.OrdQty.Value,
                    linno=s.LineNo,
                    OrgOrderNo= s.OriginalOrderNo==null?0:s.OriginalOrderNo.Value,
                    Reason=s.SOPDETAIL4,
                    ReturnOrderNo=Convert.ToInt32(s.ReturnOrderNo.Value)
                }).ToList();
            }
            return OrderDisplayDetail;
        }

        
        #endregion
        //public List<int> GetPrintRange(string busid, string userid, List<string> usrLst, string empid = "", string empname = "", string ucode = "", string ucodedesc = "", string address = "", Nullable<DateTime> startdate = null, int firstOrdNo = 0, int lastOrdNo = 0, Nullable<DateTime> frsOrdDate = null, Nullable<DateTime> lstOrdDate = null)
        //{
        //    List<int> result = new List<int>();
        //    var ucodlst = _ucodes.Exists(s => s.Description.Contains(ucodedesc)) ? _ucodes.GetAll(s => s.Description.Contains(ucodedesc)).Select(s => s.UCodeID).ToList() : new List<string>();
        //    if (_salesOrderHeader.Exists(s => s.CustID == busid && usrLst.Contains(s.OnlineUserID)))
        //    {
        //        var data = _salesOrderHeader.GetAll(s => s.CustID == busid && usrLst.Contains(s.OnlineUserID)).ToList();
        //        if(empid!="")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid).ToList(): new List<tblsop_salesorder_header>();
        //        }
        //        else if (ucode != "")
        //        {

        //            data = data.Any(s => s.UCodeId.Contains(ucode)) ? data.Where(s => s.UCodeId.Contains(ucode)).ToList() : new List<tblsop_salesorder_header>();
        //        }
        //        else if (ucodedesc != "")
        //        {

        //            data = data.Any(s =>ucodlst.Contains(s.UCodeId)) ? data.Where(s => ucodlst.Contains(s.UCodeId)).ToList() : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empname != "")
        //        {
        //            var empLst = data.Select(s => s.PinNo).ToList();
        //            var userLst = _user.Exists(s => empLst.Contains(s.UserName)) ? _user.GetAll(s => empLst.Contains(s.UserName)) : new List<tbluser>();
        //            var empnamLst = userLst.Any(s => s.ForeName.Contains(empname) | s.SurName.Contains(empname)) ? userLst.Where(s => s.ForeName.Contains(empname) | s.SurName.Contains(empname)).Select(s => s.UserName).ToList() : new List<string>();
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => empnamLst.Contains(s.PinNo)).ToList() : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //        else if (empid != "")
        //        {
        //            data = data.Any(s => s.PinNo == empid) ? data.Where(s => s.PinNo == empid) : new List<tblsop_salesorder_header>();
        //        }
        //    }
        //    return result;
        //}
        #endregion
    }
}
