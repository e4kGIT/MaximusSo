using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services
{
    public class ReturnService : IReturn
    {
        #region declarations
        public readonly IUnitOfWork _unitOfWork;
        public readonly BasketService _basket;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly CustomAssembly _customAssembly;
        public readonly Departments _departments;
        public readonly Employee _employee;
        public readonly User _user;
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly FskStyle _fskStyle;
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
        public readonly UcodeByFreeTextView _ucodeByFreeText;
        public readonly UcodeEmployees _ucodeEmployees;
        public readonly Ucodes _ucodes;
        public readonly DataProcessing _dp;
        public readonly CUstomerOrderTemplateCostcenters _costcenters;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsCard _pointsCard;
        public readonly PointStyle _pointStyle;
        public readonly Gallery _gallery;
        public readonly Company _company;
        public readonly Warehouses _warehouses;

        #endregion
        public ReturnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CUstomerOrderTemplateCostcenters costcenters = new CUstomerOrderTemplateCostcenters(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            FskStyleFreetext fskStyleFreetext = new FskStyleFreetext(_unitOfWork);
            Nextno nextno = new Nextno(_unitOfWork);
            BasketService basket = new BasketService(_unitOfWork);
            Warehouses warehouses = new Warehouses(_unitOfWork);
            StockCard stockCard = new StockCard(_unitOfWork);
            Style_Colour style_Colour = new Style_Colour(_unitOfWork);
            Style_Sizes style_Sizes = new Style_Sizes(_unitOfWork);
            FskStyle _fskStyle = new FskStyle(_unitOfWork);
            StyleByFreetext styleByFreetext = new StyleByFreetext(_unitOfWork);
            StyleColorSizeObsolete styleColorSizeObsolete = new StyleColorSizeObsolete(_unitOfWork);
            StyleGroups styleGroups = new StyleGroups(_unitOfWork);
            StylesView stylesView = new StylesView(_unitOfWork);
            TblFskStyle tblFskStyle = new TblFskStyle(_unitOfWork);
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            User user = new User(_unitOfWork);
            Gallery gallery = new Gallery(_unitOfWork);
            Company company = new Company(_unitOfWork);
            _dp = dp;
            _user = user;
            _company = company;
            _basket = basket;
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _pointStyle = pointStyle;
            _costcenters = costcenters;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _warehouses = warehouses;
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
            _gallery = gallery;
            _stylesView = stylesView;
            _tblFskStyle = tblFskStyle;
            _ucode_Description = ucode_Description;
            _ucodeByFreeText = ucodeByFreeText;
            _ucodeEmployees = ucodeEmployees;
            _ucodes = ucodes;
        }
        //public AcceptResultSet AcceptReturns(List<SalesOrderHeaderViewModel> salesHead, string cmpId, double CARRPERCENT, string CARRPRICE_RTN, string CARRPRICE_XCHG,int empResetMnths,string Browser,string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder,  string usrId,bool editFlag,string POINTSREQ, int collectionStatus = 0)
        //{

        //}
        public void InsertReturnManpackCarriage(SalesOrderHeaderViewModel salesHead, string CARRPRICE_RTN)
        {
            var returnLinesCnt = salesHead.SalesOrderLine != null ? salesHead.SalesOrderLine.Count : 0;

            if (returnLinesCnt > 0)
            {
                var carriageReturnLine = new SalesOrderLineViewModel();
                var linenO = salesHead.SalesOrderLine.Last().LineNo + 1;
                carriageReturnLine = GetCarrStyleLine(CARRPRICE_RTN, salesHead.CustID, salesHead.SalesOrderLine.Last().Currency_Exchange_Rate, Convert.ToInt32(linenO));
                salesHead.SalesOrderLine.Add(carriageReturnLine);
            }

        }
        public List<ReturnOrderModel> GetOrderToReturn(string empId, string businessId, string userId, string OrderPermission, string role, bool pointsReq, List<string> catagory, int OrdNo = 0, string custRef = "", string courierRef = "", int pickingSlipNo = 0, bool isEmergency = false, string rtnType = "")
        {

            List<ReturnOrderModel> result = new List<ReturnOrderModel>();
            result = _dp.GetReturnOrder(empId, businessId, userId, OrderPermission, pointsReq, role, catagory, OrdNo, custRef, courierRef, pickingSlipNo, isEmergency, rtnType);
            return result;
        }
        #region CheckCarriage

        public bool CheckCarriage(List<SalesOrderHeaderViewModel> header, bool isReturn, double CARRPERCENT, string CARRPRICE_RTN, string CARRPRICE_XCHG)
        {
            bool checkCar = false;
            if (_dp.checkCarriageLine(header, isReturn) == false)
            {
                if (CARRPERCENT > 0)
                {
                    checkCar = false;
                }
                else
                {
                    if (isReturn && CARRPRICE_RTN != "")
                    {
                        checkCar = false;
                    }
                    else if (CARRPRICE_XCHG != "")
                    {
                        checkCar = false;
                    }
                }
            }
            else
            {
                checkCar = true;
            }
            return checkCar;
        }
        #endregion
        #region AcceptReturns
        public AcceptResultSet AcceptReturns(string access, string conString, List<SalesOrderHeaderViewModel> salesHead, string cmpId, double CARRPERCENT, string CARRPRICE_RTN, bool DELADDR_USER_CREATE, string OverrideEnt, string CARRPRICE_XCHG, string RTN_Collection_Style, string PriceList, string FITALLOC, string DIMALLOC, string rolloutName, string WAREHOUSE_RTN, string pnlCarriageReason, string selectedCarr, bool IsManPack, int empResetMnths, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool IsRollOutOrder, string usrId, bool editFlag, string POINTSREQ, string ONLCUSREFLBL, string cmpLogo, string custLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string ueMailEMail, string permissionPrice, int collectionStatus = 0, bool isPrivateRtn = false)
        {
            var booAutoConfirm = false; bool busBudgetReq = false; long mStackManPack = 0;
            bool booStackOrder = Convert.ToBoolean(_dp.BusinessParam("STACKORDERS", salesHead.First().CustID)), booEmpPointEntitleCheck = true;
            string busId = salesHead.First().CustID;
            MySqlConnection conn = new MySqlConnection(conString);
            MySqlTransaction trans;
            long returnOrderNo = 0;
            bool overrideEntitlement = false;
            overrideEntitlement = OverrideEnt.ToString().ToUpper().Trim() == "SHOW" ? true : false;
            long reOrderNo = 0;
            List<SaveOrderResultSet> ResultSet = new List<SaveOrderResultSet>();
            AcceptResultSet result = new AcceptResultSet();
            ResultSet.Add(new SaveOrderResultSet { IsReturn = true });
            ResultSet.Add(new SaveOrderResultSet { IsReturn = false });
            var returnRes = new ReturnResult();
            if (salesHead.Count > 0)
            {
                var delAddress = _warehouses.Exists(s => s.CompanyID == cmpId && s.WarehouseID == WAREHOUSE_RTN) ? _warehouses.GetAll(s => s.CompanyID == cmpId && s.WarehouseID == WAREHOUSE_RTN).First() : new tblwho_warehouses();
                if (delAddress.CompanyID != "")
                {
                    var selectedCarriage = selectedCarr.ToString().Trim().Contains('|') ? selectedCarr.ToString().Trim().Substring(0, selectedCarr.ToString().Trim().IndexOf('|')) : selectedCarr;
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.OrderType = "RT");
                    salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.OrderType = "SO");
                    salesHead.ForEach(s => s.Carrier = selectedCarriage);
                    if (salesHead.Where(s => s.Returnheader).Any(s => s.CustRef.ToLower().Contains("/ret")) == false)
                    {
                        salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.CustRef = s.CustRef + "/Returns");
                    }

                    foreach (var header in salesHead.Where(s => s.Returnheader).ToList())
                    {
                        header.DelAddress1 = delAddress.Address1 != "" ? delAddress.Address1 : "";
                        header.DelDesc = delAddress.WarehouseName != "" ? delAddress.WarehouseName : "";
                        header.DelAddress2 = delAddress.Address2 != "" ? delAddress.Address2 : "";
                        header.DelAddress3 = delAddress.Address3 != "" ? delAddress.Address3 : "";
                        header.DelCountry = "UK";
                        header.DelPostCode = delAddress.PostCode != "" ? delAddress.PostCode : "";
                        header.DelTown = "";
                        header.DelCity = "";
                    }

                    var address1 = _dp.getEmployeeAddress(salesHead.First().EmployeeID, salesHead.First().CustID);
                    var addArr = new string[] { };
                    var addresArr = address1.Contains(",-,") ? System.Text.RegularExpressions.Regex.Split(address1, ",-,") : addArr;
                    int ds = addresArr.Count();
                    //added by sasi(22-01-20)
                    if (isPrivateRtn == false)
                    {
                        foreach (var header in salesHead.Where(s => s.Reorderheader).ToList())
                        {
                            header.DelAddress1 = ds > 0 ? addresArr[2] : "";
                            header.DelAddress2 = ds > 0 ? addresArr[3] : "";
                            header.DelAddress3 = ds > 0 ? addresArr[4] : "";
                            header.DelTown = ds > 0 ? addresArr[5] : "";
                            header.DelCity = ds > 0 ? addresArr[6] : "";
                            header.DelPostCode = ds > 0 ? addresArr[7] : "";
                            header.DelCountry = ds > 0 ? addresArr[8] : "";
                            header.DelCountry = "UK";
                            header.DelDesc = ds > 0 ? addresArr[1] : "";
                            header.CustRef = ds > 0 ? addresArr[1] : "";
                        }
                    }
                    ///
                    string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + salesHead.First().CustID + "' and tblbus_countrycodes.CompanyID = '" + salesHead.First().CompanyID + "' Order By tblbus_address.Description";
                    var invAddress = _dp.GetAddressDetails(SQL);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvAddress1 = invAddress.Address1);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvAddress2 = invAddress.Address2);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvAddress3 = invAddress.Address3);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvDesc = invAddress.AddressDescription);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvPostCode = invAddress.PostCode);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvTown = invAddress.Town);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvCity = invAddress.City);
                    salesHead.Where(s => s.Returnheader).ToList().ForEach(s => s.InvCountry = invAddress.Country);
                    salesHead.ToList().ForEach(s => s.CarrierCharge = 0.0);
                    if (isPrivateRtn == false)
                    {

                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvAddress1 = invAddress.Address1);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvAddress2 = invAddress.Address2);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvAddress3 = invAddress.Address3);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvDesc = invAddress.AddressDescription);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvPostCode = invAddress.PostCode);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvTown = invAddress.Town);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvCity = invAddress.City);
                        salesHead.Where(s => s.Reorderheader).ToList().ForEach(s => s.InvCountry = invAddress.Country);

                    }

                }
                if (!CheckCarriage(salesHead, true, CARRPERCENT, CARRPRICE_RTN, CARRPRICE_XCHG))
                {
                    if (collectionStatus == 0)
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("CollectPrompt", salesHead.First().CustID)) && Convert.ToBoolean(salesHead.First().HasContactDetail) == false)
                        {
                            result.type = "CollectPrompt";
                            return result;
                        }
                    }
                    else if (collectionStatus == 1)
                    {

                    }
                    if (Convert.ToBoolean(_dp.BusinessParam("CarrierPrompt", salesHead.First().CustID)) && salesHead.Where(s => s.Returnheader).First().SalesOrderLine.Any(s => s.isCarrline) == false)
                    {
                        result.type = "CarrierPrompt";
                        return result;
                    }
                    else
                    {
                        if (CARRPRICE_RTN != "")
                        {
                            InsertReturnManpackCarriage(salesHead.Where(s => s.Returnheader).First(), CARRPRICE_RTN);
                        }
                    }
                }
                else
                {
                    if (Convert.ToBoolean(_dp.BusinessParam("CarrierPrompt", salesHead.First().CustID)) && pnlCarriageReason.ToLower() != "hide")
                    {
                        result.type = "CarrierPrompt";
                        return result;
                    }
                    else
                    {
                        if (CARRPRICE_RTN != "")
                        {
                            InsertReturnManpackCarriage(salesHead.Where(s => s.Returnheader).First(), CARRPRICE_RTN);
                        }
                    }
                }
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    foreach (var headers in salesHead.Where(s => s.SalesOrderLine.Count() > 0))
                    {
                        var lst = new List<SalesOrderHeaderViewModel>();
                        // headers.OrderNo = headers.SalesOrderLine.First().OrderNo;
                        if (headers.Returnheader)
                        {

                            lst.Add(headers);
                            long rtnOrdNo = 0;
                            long manPckRtnNo = 0; bool cnf = false;
                            try
                            {
                                var cmpid = salesHead.First().CompanyID;
                                manPckRtnNo = _dp.Getnextno("MANPACK RETURN", conn);
                                rtnOrdNo = headers.IsEditing ? headers.OrderNo : _dp.Getnextno("RETURN ORDER", conn);
                            }
                            catch (Exception e)
                            { }
                            headers.OrderNo = rtnOrdNo;
                            headers.ReasonCode = headers.ReasonCode == null ? 0 : headers.ReasonCode;
                            if (collectionStatus != 2)
                            {
                                if (!InsertCOllectionStyle(headers, RTN_Collection_Style, PriceList))
                                {
                                    result.type = "failure";
                                }
                            }
                            bool isPrivate = headers.CustRef.ToLower().Contains("private") && (headers.UCodeId == "" || headers.UCodeId == null) ? true : false;
                            returnRes.RtnResult = _dp.SaveReturnOrder(access, conn, headers, empResetMnths, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, IsRollOutOrder, rtnOrdNo, headers.CustID, usrId, editFlag, POINTSREQ, isPrivate).result;


                            if (returnRes.RtnResult)
                            {
                                if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM_RTN", headers.CustID)) | booAutoConfirm)
                                {
                                    var ordCnfQry = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + headers.OrderDate + "', OnlineConfirmedBy='" + usrId + "' WHERE OrderNo=" + rtnOrdNo + " AND CompanyID='" + headers.CompanyID + "'";
                                    if (_dp.ExecuteQuery(conn, ordCnfQry) > 0)
                                    {
                                        cnf = true;
                                    }
                                }
                                var manPaxRtn = "";
                                if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM_RTN", headers.CustID)) | booAutoConfirm)
                                {
                                    manPaxRtn = "INSERT INTO tblsop_manpackreturns (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm, OnlineConfirmDate, OnlineConfirmedBy)  VALUES ('" + headers.CompanyID + "'," + manPckRtnNo + "," + rtnOrdNo + ",'" + headers.CustID + "','" + headers.OrderDate + "','" + usrId + "',1,'" + headers.OrderDate + "','" + usrId + "')";
                                }
                                else
                                {
                                    manPaxRtn = "INSERT INTO tblsop_manpackreturns (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + headers.CompanyID + "'," + manPckRtnNo + "," + rtnOrdNo + ",'" + headers.CustID + "','" + headers.OrderDate + "','" + usrId + "',0)";
                                }
                                if (_dp.ExecuteQuery(conn, manPaxRtn) > 0)
                                {

                                }
                                try
                                {
                                    var message = new OrderConfirmation();
                                    try
                                    {
                                        message = _basket.GetEmailMessage(headers, "", manPckRtnNo, permissionPrice, ONLCUSREFLBL, cmpLogo, custLogo, rtnOrdNo, false);
                                    }
                                    catch (Exception e)
                                    {

                                    }

                                    //_basket.ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message.OrderConfirmationemail, headers.CustID, usrId, headers.EmployeeID, "sasidharan@e4k.co", "", "");
                                    ResultSet.Where(s => s.IsReturn).First().EmployeeId = headers.EmployeeID;
                                    ResultSet.Where(s => s.IsReturn).First().OrderNo = rtnOrdNo;
                                    ResultSet.Where(s => s.IsReturn).First().OrderConfirmation = cnf ? "and also confirmed" : "has not been confirmed";
                                    ResultSet.Where(s => s.IsReturn).First().OrderConfirmationPop = message.OrderConfirmationPOP;
                                    ResultSet.Where(s => s.IsReturn).First().isedit = headers.IsEditing;
                                    ///commented by asasi(28-12-20)
                                    //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = rtnOrdNo, OrderConfirmation = cnf ? "and also confirmed" : "has not been confirmed", IsReturn = true, OrderConfirmationPop = message.OrderConfirmationPOP, isedit = headers.IsEditing });
                                }
                                catch (Exception e)
                                {

                                }
                                returnOrderNo = rtnOrdNo;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            string sSql = "";
                            headers.SalesOrderLine.ForEach(s => s.OriginalOrderNo = 0);
                            headers.ReasonCode = headers.ReasonCode == null ? 0 : headers.ReasonCode;
                            var cmpid = salesHead.First().CompanyID;
                            long reOrdNo = headers.IsEditing ? headers.OrderNo : _dp.Getnextno("SALE ORDER", conn); ;
                            long manPckReord = _dp.Getnextno("MANPACK ORDER", conn);
                            headers.SalesOrderLine.ForEach(s => s.ReturnOrderNo = returnOrderNo);
                            bool isPrivate = headers.CustRef.ToLower().Contains("private") && (headers.UCodeId == "" || headers.UCodeId == null) ? true : false;
                            returnRes.ReOrdResult = _dp.SaveReturnOrder(access, conn, headers, empResetMnths, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, IsRollOutOrder, reOrdNo, headers.CustID, usrId, editFlag, POINTSREQ, isPrivate).result;
                            booEmpPointEntitleCheck = Convert.ToBoolean(POINTSREQ) ? true : overrideEntitlement ? overrideEntitlement : _dp.EmpEntilementCheck(rolloutName, OverrideEnt, FITALLOC, DIMALLOC, headers, busId, 0, IsManPack, false);
                            headers.OrderNo = reOrdNo;
                            if (returnRes.ReOrdResult)
                            {
                                if (busBudgetReq == true)
                                {
                                    if (booStackOrder == false)
                                    {
                                        if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", headers.CustID)))
                                        {

                                        }
                                        else
                                        {
                                            ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                            //commented by sasi(28-12-20)
                                            //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo });
                                        }
                                    }
                                }
                                else if (Convert.ToBoolean(_dp.BusinessParam("ONLEntExceed", busId)) && Convert.ToBoolean(_dp.BusinessParam("REQALLOCEMAIL", busId)))
                                {
                                    if (booStackOrder == false)
                                    {
                                        if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
                                        {
                                            if (booEmpPointEntitleCheck)
                                            {
                                                sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + headers.OrderDate + "', OnlineConfirmedBy='" + usrId + "'  WHERE OrderNo=" + reOrdNo + " AND CompanyID='" + cmpId + "'";
                                                int res = _dp.ExecuteQuery(conn, sSql);
                                                if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                                {

                                                }
                                            }
                                            else
                                            {
                                                ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                                ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                                ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "Order has not been confirmed";
                                                //commented by sasi(28-12-20)
                                                //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "Order has not been confirmed" });
                                                if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                                {
                                                    sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + headers.OrderDate + "', OnlineConfirmedBy='" + usrId + "' WHERE OrderNo=" + reOrdNo + " AND CompanyID='" + cmpId + "'";
                                                    _dp.ExecuteQuery(conn, sSql);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "Order has not been confirmed";
                                            //commented by sasi(28-12-20)
                                            //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "Order has not been confirmed" });
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
                                        {

                                        }
                                        else
                                        {
                                            ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "Order has not been confirmed";
                                            //commented by sasi(28-12-20)
                                            //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "Order has not been confirmed" });
                                        }
                                    }
                                }
                                else if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
                                {
                                    if (booStackOrder == false)
                                    {
                                        if (booEmpPointEntitleCheck)
                                        {
                                            sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + headers.OrderDate + "', OnlineConfirmedBy='" + usrId + "'  WHERE OrderNo=" + reOrdNo + " AND CompanyID='" + cmpId + "'";
                                            int res = _dp.ExecuteQuery(conn, sSql);
                                            if (Convert.ToBoolean(DELADDR_USER_CREATE) == false)
                                            {
                                                ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                                ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                                ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "and also confirmed";
                                                //commented by sasi(28-12-20)
                                                // ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "and also confirmed" });
                                            }
                                        }
                                        else
                                        {
                                            ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                            ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "\nOrder has not been Confirmed.\nEntitlement Exceed\n\n";
                                            ResultSet.Where(s => s.IsReturn == false).First().isedit = headers.IsEditing;
                                            //commented by sasi(28-12-20)
                                            // ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "\nOrder has not been Confirmed.\nEntitlement Exceed\n\n", isedit = headers.IsEditing });
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                        ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                        ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "Order has not been confirmed";
                                        ResultSet.Where(s => s.IsReturn == false).First().isedit = headers.IsEditing;
                                        //commented by sasi(28-12-20)
                                        //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "Order has not been confirmed", isedit = headers.IsEditing });
                                    }
                                }
                                else
                                {
                                    ResultSet.Where(s => s.IsReturn == false).First().EmployeeId = headers.EmployeeID;
                                    ResultSet.Where(s => s.IsReturn == false).First().OrderNo = reOrdNo;
                                    ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmation = "Order has not been confirmed";
                                    ResultSet.Where(s => s.IsReturn == false).First().isedit = headers.IsEditing;
                                    //commented by sasi(28-12-20)
                                    //ResultSet.Add(new SaveOrderResultSet { EmployeeId = headers.EmployeeID, OrderNo = reOrdNo, OrderConfirmation = "Order has not been confirmed", isedit = headers.IsEditing });
                                }
                                if (booStackOrder)
                                {
                                    if (mStackManPack == -1)
                                    {
                                        //intManPackNext=
                                    }
                                    else if (mStackManPack == -2)
                                    {
                                        manPckReord = _dp.Getnextno("MANPACK ORDER", conn);
                                    }
                                    else
                                    {
                                        long checkManPack = _dp.FindOpenManPackOrders(headers.DelDesc, headers.DelAddress1, headers.DelPostCode, busId);
                                        if (checkManPack == 0)
                                        {
                                            manPckReord = _dp.Getnextno("MANPACK ORDER", conn);
                                        }
                                        else if (checkManPack > 0)
                                        {
                                            manPckReord = checkManPack;
                                        }
                                    }
                                }
                                string sql = "";
                                if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
                                {
                                    if (booStackOrder == false)
                                    {
                                        sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm, OnlineConfirmDate, OnlineConfirmedBy)  VALUES ('" + cmpId + "'," + manPckReord + "," + reOrdNo + ",'" + busId + "','" + headers.OrderDate + "','" + usrId + "',1,'" + headers.OrderDate + "','" + usrId + "')";
                                    }
                                    else
                                    {
                                        sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + manPckReord + "," + reOrdNo + ",'" + busId + "','" + headers.OrderDate + "','" + usrId + "',0)";
                                    }
                                }
                                else
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + manPckReord + "," + reOrdNo + ",'" + busId + "','" + headers.OrderDate + "','" + usrId + "',0)";
                                }
                                _dp.ExecuteQuery(conn, sql);
                            }
                            try
                            {
                                var message = _basket.GetEmailMessage(headers, "", manPckReord, permissionPrice, ONLCUSREFLBL, cmpLogo, custLogo, reOrdNo, false);

                                //_basket.ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message.OrderConfirmationemail, headers.CustID, usrId, headers.EmployeeID, "sasidharan@e4k.co", "", "");

                                ResultSet.Where(s => s.IsReturn == false).First().OrderConfirmationPop = message.OrderConfirmationPOP;
                            }
                            catch
                            {

                            }
                            reOrderNo = reOrdNo;
                        }
                    }
                    if (salesHead.Any(s => s.Reorderheader))
                    {
                        if (salesHead.Where(s => s.Reorderheader).Any(s => s.SalesOrderLine.Count > 0))
                        {
                            if (returnRes.RtnResult & returnRes.ReOrdResult)
                            {
                                trans.Commit();
                                foreach (var resu in ResultSet)
                                {
                                    _basket.ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, resu.OrderConfirmationPop, busId, usrId, resu.EmployeeId, "sasidharan@e4k.co", "", "");
                                }

                            }
                            else
                            {
                                trans.Rollback();
                            }
                        }
                        else
                        {
                            if (returnRes.RtnResult)
                            {
                                trans.Commit();
                                foreach (var resu in ResultSet)
                                {
                                    _basket.ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, resu.OrderConfirmationPop, busId, usrId, resu.EmployeeId, "sasidharan@e4k.co", "", "");
                                }

                            }
                            else
                            {
                                trans.Rollback();
                            }
                        }
                    }
                    else
                    {
                        if (returnRes.RtnResult)
                        {
                            trans.Commit();
                            foreach (var resu in ResultSet)
                            {
                                _basket.ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, resu.OrderConfirmationPop, busId, usrId, resu.EmployeeId, "sasidharan@e4k.co", "", "");
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
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                }

                //if(!createcolllectionline)
            }
            if (ResultSet.Count > 0)
            {
                if (salesHead.Any(s => s.Returnheader && s.CustRef.ToLower().Contains("private") && (s.UCodeId == "" || s.UCodeId == null
                 )))
                {
                    if (ResultSet.Any(s => s.IsReturn))
                    {
                        var privateReord = PrintPrivateReturns(salesHead, custLogo, cmpLogo, 0, ONLCUSREFLBL, editFlag);
                        var message = ResultSet.Where(s => s.IsReturn).First().OrderConfirmationPop;
                        message = message.Replace("%privateconfirmation%", privateReord);
                        ResultSet.Where(s => s.IsReturn).First().OrderConfirmationPop = message;
                    }
                }
                if (salesHead.Any(s => s.Reorderheader))
                {
                    if (salesHead.Where(s => s.Reorderheader).First().SalesOrderLine != null)
                    {
                        if (salesHead.Where(s => s.Reorderheader).First().SalesOrderLine.Count > 0)
                        {
                            if (ResultSet.Where(s => s.IsReturn == false).First().OrderNo > 0)
                            {
                                result.results = ResultSet;
                                result.type = "success";
                            }
                            else
                            {
                                result.type = "failure";
                            }
                        }
                        else
                        {
                            ResultSet.Remove(ResultSet.Where(s => s.IsReturn == false).First());
                            result.results = ResultSet;
                            result.type = "success";
                        }

                    }
                    else
                    {
                        ResultSet.Remove(ResultSet.Where(s => s.IsReturn == false).First());
                        result.results = ResultSet;
                        result.type = "success";
                    }
                }
                else
                {
                    ResultSet.Remove(ResultSet.Where(s => s.IsReturn == false).First());
                    result.results = ResultSet;
                    result.type = "success";
                }
                //if (ResultSet.Any(s => s.IsReturn == false))
                //{
                //    if (ResultSet.Count > 1)
                //    {

                //        result.results = ResultSet;
                //        result.type = "success";
                //    }
                //    else
                //    {
                //        result.type = "failure";
                //    }
                //}
                //else
                //{
                //    if (ResultSet.Count > 1)
                //    {
                //        result.results = ResultSet;
                //        result.type = "success";
                //    }
                //    else
                //    {

                //    }
                //}

            }
            else
            {

                result.type = "failure";
            }
            return result;
        }

        private bool InsertCOllectionStyle(SalesOrderHeaderViewModel headers, string rTN_Collection_Style, string PriceList)
        {

            if (headers.SalesOrderLine.Count > 0)
            {
                if (Convert.ToBoolean(_dp.BusinessParam("CollectPrompt", headers.CustID)))
                {
                    if (rTN_Collection_Style != "")
                    {
                        try
                        {
                            long lineNo = 0;
                            lineNo = headers.SalesOrderLine.Last().LineNo + 1;
                            SalesOrderLineViewModel line = new SalesOrderLineViewModel();
                            var CollectionStyle = _dp.SetStyle(rTN_Collection_Style);
                            if (CollectionStyle.Count > 0)
                            {
                                line.OrdQty = 1;
                                line.LineNo = lineNo;
                                line.AllQty = 0;
                                line.InvQty = 0;
                                line.ColourID = "NONE";
                                line.StyleID = CollectionStyle.First().StyleID;
                                line.SizeID = CollectionStyle.First().SizeID;
                                line.Price = Convert.ToDouble(_dp.GetPrice(rTN_Collection_Style, CollectionStyle.First().SizeID, headers.CustID, PriceList));
                                line.DeliveryDate = headers.SalesOrderLine.Last().DeliveryDate;
                                line.VatCode1 = Convert.ToInt32(CollectionStyle.First().VatCode);
                                line.VatPercent = Convert.ToDouble(CollectionStyle.First().VatPercent);
                                line.Currency_Exchange_Rate = headers.SalesOrderLine.Last().Currency_Exchange_Rate;
                                line.NomCode1 = Convert.ToInt32(CollectionStyle.First().VatPercent);
                            }
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public SalesOrderLineViewModel GetCarrStyleLine(string styleId, string busId, double CurrencyExchangeRate, int lineNo)
        {
            SalesOrderLineViewModel salesVumodel = new SalesOrderLineViewModel();
            salesVumodel.StyleID = styleId;
            salesVumodel.ColourID = _dp.GetCarrClr(styleId);
            salesVumodel.SizeID = _dp.GetCarrSize(styleId);
            var tmpBusiness = _dp.GetBusinessAcount(busId);
            var price = _dp.ItemPrice(styleId, salesVumodel.ColourID, salesVumodel.SizeID, tmpBusiness.Country_CurrencyID, Convert.ToInt64(_dp.BusinessParam("PriceList", busId)), 0, busId);
            salesVumodel.Price = Math.Round(Convert.ToDouble(price), 2);
            var styleFsk = _fskStyle.GetAll(x => x.StyleID == styleId).First();
            salesVumodel.OrdQty = 1;
            salesVumodel.AllQty = 0;
            salesVumodel.InvQty = 0;
            salesVumodel.DespQty = 0;
            salesVumodel.LineNo = lineNo;
            salesVumodel.DeliveryDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            salesVumodel.Description = styleFsk.Description;
            var dblCostPrice = _dp.ItemPrice(styleId, salesVumodel.ColourID, salesVumodel.SizeID, tmpBusiness.Country_CurrencyID, Convert.ToInt64(_dp.BusinessParam("PriceList", busId)), 0, busId);
            salesVumodel.Cost1 = dblCostPrice;
            salesVumodel.VatCode1 = _dp.UseVatCode(tmpBusiness.VatFlag, _dp.GetVatCode(), tmpBusiness.VatCode);
            salesVumodel.RepRate = tmpBusiness.Rep_Comission;
            salesVumodel.KAMRate = tmpBusiness.KAM_Comission;
            salesVumodel.Currency_Exchange_Rate = CurrencyExchangeRate;
            salesVumodel.VatPercent = _dp.GetVatPercent(styleId, salesVumodel.SizeID);
            salesVumodel.isCarrline = true;
            var reqData = _dp.GetReqData(salesVumodel.StyleID);
            if (reqData != "")
            {
                salesVumodel.RequireData = reqData;
                salesVumodel.FreeText1 = "(" + reqData + ")";
            }
            salesVumodel.IssueQty1 = 1;
            salesVumodel.StockingUOM1 = 1;
            salesVumodel.Ratio1 = 1;
            return salesVumodel;
        }

        #region DeleteReturnOrders
        public bool DeleteReturnOrders(int orderno, string user)
        {
            return _dp.DeleteReturnOrder(orderno, user);

        }
        #endregion

        #region PrintPrivateReturns
        public string PrintPrivateReturns(List<SalesOrderHeaderViewModel> lst,string custLogo,string cmpLogo,int manpck,string ONLCUSREFLBL,bool isedit=false)
        {
            var reult = "";
            if (lst.Any(s => s.Reorderheader))
            {
                foreach (var lines in lst.Where(s => s.Reorderheader))
                {
                    reult = reult+ _dp.GetPrivateReturnMail(lines,"",custLogo,cmpLogo,lines.manPack,"readonly",ONLCUSREFLBL,lines.OrderNo,isedit,null);
                }
            }
            return reult;
        }
        #endregion


        #endregion

    }
}
