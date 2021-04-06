using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.models;
using System.Data;
using System.Globalization;

namespace Maximus.Services
{
    public class BasketService : IBasket
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly CustomAssembly _customAssembly;
        public readonly Departments _departments;
        public readonly Employee _employee;
        public readonly EmployeeRollout _employeeRollout;
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
        public readonly BusAddress _busAddress;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointStyle _pointStyle;
        public readonly DataProcessing _dp;
        public readonly FskStyleLocations _fskStyleLocations;
        public readonly tblSalesOrderHeader _tblSalesHeader;
        public readonly tblSalesLines _tblSalesLines;
        public readonly PointsCard _pointsCard;
        public readonly PointStyle _pointsStyle;
        public readonly User _tblUser;
        public readonly UcodeOperationsTbl _ucodeOperationsTbl;
        public readonly RejectReasonTbl _rejectReasonTbl;
        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            FskStyle fskStyle = new FskStyle(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            UcodeOperationsTbl ucodeOperationsTbl = new UcodeOperationsTbl(_unitOfWork);
            RejectReasonTbl rejectReasonTbl = new RejectReasonTbl(_unitOfWork);
            FskStyleLocations fskStyleLocations = new FskStyleLocations(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
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
            EmployeeRollout employeeRollout = new EmployeeRollout(_unitOfWork);
            User tblUser = new User(_unitOfWork);
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            tblSalesOrderHeader tblSalesHeader = new tblSalesOrderHeader(_unitOfWork);
            tblSalesLines tblSalesLines = new tblSalesLines(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            PointStyle pointsStyle = new PointStyle(_unitOfWork);
            _tblSalesHeader = tblSalesHeader;
            _tblSalesLines = tblSalesLines;
            _tblUser = tblUser;
            _pointsCard = pointsCard;
            _pointsStyle = pointsStyle;
            _fskStyle = fskStyle;
            _fskStyleLocations = fskStyleLocations;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _employeeRollout = employeeRollout;
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
            _dp = dp;
            _ucodeOperationsTbl = ucodeOperationsTbl;
            _rejectReasonTbl = rejectReasonTbl;
            _pointsByUcode = pointsByUcode;
            _pointStyle = pointStyle;
        }



        #region  AcceptOrder 
        public AcceptResultSet AcceptOrder(string access, string cmpId, bool IsManPack, string busId, List<SalesOrderHeaderViewModel> salesHeaderLst, string addDesc, bool isRollOutOrder, bool isRollOutOrderEst, string OverrideEnt, bool CusRefMan, string POINTSREQ, List<BusAddress1> busAddress, string DIFF_MANPACK_INFO, string NOMCODEMAN, string ONLNEREQNOM1, string ONLNEREQNOM2, string ONLNEREQNOM3, string ONLNEREQNOM4, string ONLNEREQNOM5, string RolloutName, string selectedcar, string UserName, string DELADDR_USER_CREATE, double CARRPERCENT, double CARRREQAMT, string FITALLOC, string DIMALLOC, string BUDGETREQ, bool FreeStckCheck, string Browser, string REMOTE_ADDR, string ONLCUSREFLBL, string cmpLogo, string custLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string ueMailEMail, string HTTP_X_FORWARDED_FOR, bool isedit, bool boolDeleteConfirm, string pnlCarriageReason, bool booPtsReq, int empResetMnths, string pricePermission, UpdateMailModel updModel, bool booAutoConfirm = false)
        {
            SaveResultModel savModel = new SaveResultModel();
            int addressId = 0;
            bool booCheck = true;
            //bool booAutoConfirm = false;
            long mStackManPack = 0;
            bool optNew = false;
            long intSalesOrderNo = isedit ? salesHeaderLst.First().OrderNo : 0;
            long intnext = 0;
            string tmpMsg = "";

            bool StrSQL = false;
            long i = 0;
            string mCDate;
            bool booNotSAP = true;
            long intManPackNext = 0;
            string mOrdDate = "";
            string mySqlInv = "";
            long txtOrderNo = isedit ? salesHeaderLst.Where(x => x.IsEditing).First().OrderNo : 0;
            BusAddress1 invAddress = new BusAddress1();
            bool booEmpPointEntitleCheck = true;
            bool booPE = true;
            bool busBudgetReq = false;
            var ResultSet = new List<SaveOrderResultSet>();
            var AcceptResultSet = new AcceptResultSet();
            bool isPersonalOrder = false;
            double carriage = 0.0;
            TotalModel tot = new TotalModel();
            tot = tot = _dp.GetAlltotals(salesHeaderLst, carriage);
            bool booExistInManpack = false;
            bool booStackOrder;
            bool overrideEntitlement = false;
            overrideEntitlement = OverrideEnt.ToString().ToUpper().Trim() == "SHOW" ? true : false;
            var lastObj = salesHeaderLst.Last();
            booStackOrder = Convert.ToBoolean(_dp.BusinessParam("STACKORDERS", busId));
            NOMCODEMAN = _dp.BusinessParam(NOMCODEMAN, busId);

            if (CusRefMan)
            {
                if (salesHeaderLst.Any(x => x.CustRef == null || x.CustRef == ""))
                {
                    AcceptResultSet.results = ResultSet;
                    AcceptResultSet.type = "Please select Customer Po Reference for " + salesHeaderLst.Where(x => x.CustRef == null || x.CustRef == "").First().EmployeeName + "";
                    return AcceptResultSet;
                }
            }

            if (IsManPack)
            {
                if ((salesHeaderLst).Count == 0)
                {

                }
            }
            if (booCheck)
            {
                if (isRollOutOrder == false)
                {
                    if (_dp.CheckBudgetOrPoints(BUDGETREQ, busId) == false)
                    {

                    }
                }
            }
            if (Convert.ToBoolean(POINTSREQ) && Convert.ToBoolean(isRollOutOrder))
            {
                if (IsManPack == false)
                {

                }
                else
                {
                    foreach (var order in (salesHeaderLst))
                    {
                        foreach (var lines in order.SalesOrderLine.Where(s => s.IsDleted == false))
                        {
                            if (lines.OrdQty == 0)
                            {
                                continue;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            var list = busAddress;
            long addid = 0;
            try
            {
                addid = Convert.ToInt64(addDesc);
            }
            catch
            {

            }
            addressId = list.Any(x => x.AddressDescription == addDesc) ? list.Where(x => x.AddressDescription == addDesc).First().AddressId : list.Any(x => x.AddressId == addid) ? list.Where(x => x.AddressId == addid).First().AddressId : 0;

            int myAddressID = 0, myContactID = 0, myCountryID = 0;
            myAddressID = addressId;
            myContactID = Convert.ToInt32((busAddress).Where(x => x.AddressId == addressId).First().contactId);
            myCountryID = Convert.ToInt32((busAddress).Where(x => x.AddressId == addressId).First().CountryCode);
            if (!isPersonalOrder)
            {
                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                invAddress = _dp.GetAddressDetails(SQL);
            }
            if (!CheckCarriage(tot, IsManPack, CARRPERCENT, salesHeaderLst, CARRREQAMT, busId))
            {
                //SetTempData()
                if (IsManPack)
                {
                    if (booStackOrder == false)
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("CarrierPrompt", busId)) && pnlCarriageReason.ToLower() != "hide")
                        {
                            foreach (var saleshead in salesHeaderLst)
                            {
                                if (saleshead.SalesOrderLine.Any(s => s.isCarrline && s.IsDleted == false) == false)
                                {
                                    AcceptResultSet.results = ResultSet;
                                    AcceptResultSet.type = "Please select Carrier style for " + saleshead.EmployeeName + "";
                                    return AcceptResultSet;
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToInt32(txtOrderNo) > 0)
                            {
                                string sSqry = "SELECT * FROM tblsop_manpackorders WHERE OrderNo=" + txtOrderNo;
                                booExistInManpack = _dp.GetBooValue(sSqry);
                            }
                            if (booExistInManpack == false)
                            {
                            }
                        }
                    }
                }
                else
                {
                    if (booStackOrder == false)
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("CarrierPrompt", busId)))
                        {
                            AcceptResultSet.results = ResultSet;
                            AcceptResultSet.type = "Carrier style is Mandatory";
                        }
                        else
                        {
                            if (Convert.ToInt32(txtOrderNo) > 0)
                            {
                                string sSqry = "SELECT * FROM tblsop_manpackorders WHERE OrderNo=" + txtOrderNo;
                                booExistInManpack = _dp.GetBooValue(sSqry);
                            }
                            if (booExistInManpack == false)
                            {
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var salesHead in salesHeaderLst)
                {
                    if (salesHead.SalesOrderLine.Any(s => s.isCarrline && s.IsDleted))
                    {
                        var carrLines = salesHead.SalesOrderLine.Where(s => s.isCarrline && s.IsDleted).First();
                        salesHead.SalesOrderLine.Remove(carrLines);
                    }
                }
            }


            double currentBudget;
            if (IsManPack == false)
            {
                if (false == false)
                {
                    _dp.displayOrderListGrid();
                }
                foreach (var saleshead in salesHeaderLst)
                {
                    if (saleshead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0 | boolDeleteConfirm)
                    {
                        tblgen_nextno nextNo = new tblgen_nextno();
                        nextNo = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName == "SALE ORDER").First();
                        intSalesOrderNo = nextNo.AutoNumber.Value;
                        //                mCurrBudget = BudgetCurr(CurrentOrder.EmployeeID)
                        if (isPersonalOrder != true)
                        {
                            saleshead.InvDesc = invAddress.AddressDescription;
                            saleshead.InvAddress1 = invAddress.Address1;
                            saleshead.InvAddress2 = invAddress.Address2;
                            saleshead.InvAddress3 = invAddress.Address3;
                            saleshead.InvCity = invAddress.City;
                            saleshead.InvCountry = invAddress.Country;
                            saleshead.InvPostCode = invAddress.PostCode;
                            saleshead.InvTown = invAddress.Town;
                            bool booOrderInfo = Convert.ToBoolean(DIFF_MANPACK_INFO);
                            if (myAddressID > 0)
                            {
                                saleshead.DelDesc = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Description;
                                saleshead.DelAddress1 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address1;
                                saleshead.DelAddress2 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address2;
                                saleshead.DelAddress3 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address3;
                                saleshead.DelCity = _busAddress.GetAll(x => x.AddressID == myAddressID).First().City;
                                saleshead.DelCountry = _countryCodes.GetAll(x => x.CountryID == myCountryID).First().Country;
                                saleshead.DelPostCode = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Postcode;
                                saleshead.DelTown = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Town;
                                saleshead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            }
                            //                ResetAssemblyLineNo(Session.Item("objCurrentOrder"))
                            //                If EditFlag Then
                            //                    Dim objorderlines As SalesOrderLine = DirectCast(Session.Item("objCurrentOrder").SalesOrderLine, SalesOrderLine)
                            //                    getNarateEditDetailMail(objorderlines)
                            //                End If
                            if (isRollOutOrderEst)
                            {
                                if (saleshead.NomCode3.ToString().Trim() == "")
                                {
                                    saleshead.NomCode3 = RolloutName;
                                }
                            }
                            else
                            {
                                if (saleshead.NomCode3.ToString().Trim() != "")
                                {
                                    saleshead.NomCode3 = "";
                                }
                            }
                        }
                    }
                }


            }
            else
            {
                if (salesHeaderLst.Count == 0)
                {
                    AcceptResultSet.results = ResultSet;
                    return AcceptResultSet;
                }
                bool booOrderInfo = Convert.ToBoolean(DIFF_MANPACK_INFO);
                foreach (var salesHead in salesHeaderLst)
                {

                    if (Convert.ToBoolean(CusRefMan))
                    {
                        if (salesHead.CustRef == "" || salesHead.CustRef == null)
                        {

                        }
                    }
                    if (Convert.ToBoolean(NOMCODEMAN))
                    {
                        if (Convert.ToBoolean(ONLNEREQNOM1))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(ONLNEREQNOM2))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(ONLNEREQNOM3))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(ONLNEREQNOM4))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(ONLNEREQNOM5))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                    }
                    salesHead.InvDesc = invAddress.AddressDescription;
                    salesHead.InvAddress1 = invAddress.Address1;
                    salesHead.InvAddress2 = invAddress.Address2;
                    salesHead.InvAddress3 = invAddress.Address3;
                    salesHead.InvCity = invAddress.City;
                    salesHead.InvCountry = invAddress.Country;
                    salesHead.InvPostCode = invAddress.PostCode;
                    salesHead.InvTown = invAddress.Town;
                    if (Convert.ToBoolean(_dp.BusinessParam("DEFEMPDELADDR", busId)) && booOrderInfo == false)
                    {
                        if (salesHead.Template != "" && salesHead.Template != null)
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelPostCode;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelTown;
                            salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            if (salesHead.DelDesc == "")
                            {
                                salesHead.DelDesc = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Description;
                                salesHead.DelAddress1 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address1;
                                salesHead.DelAddress2 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address2;
                                salesHead.DelAddress3 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address3;
                                salesHead.DelCity = _busAddress.GetAll(x => x.AddressID == myAddressID).First().City;
                                salesHead.DelCountry = _countryCodes.GetAll(x => x.CountryID == myCountryID).First().Country;
                                salesHead.DelPostCode = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Postcode;
                                salesHead.DelTown = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Town;
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            }
                        }
                        else if (salesHead.EmployeeID != "" && salesHead.EmployeeID != null)
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelPostCode;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelTown;
                            salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            if (salesHead.DelDesc == "")
                            {
                                salesHead.DelDesc = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Description;
                                salesHead.DelAddress1 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address1;
                                salesHead.DelAddress2 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address2;
                                salesHead.DelAddress3 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address3;
                                salesHead.DelCity = _busAddress.GetAll(x => x.AddressID == myAddressID).First().City;
                                salesHead.DelCountry = _countryCodes.GetAll(x => x.CountryID == myCountryID).First().Country;
                                salesHead.DelPostCode = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Postcode;
                                salesHead.DelTown = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Town;
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            }
                        }

                    }
                    else if (optNew && booOrderInfo == false)
                    {
                        if (salesHead.Template != "")
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCountry;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelTown;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            if (salesHead.DelDesc == "")
                            {
                                salesHead.DelDesc = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Description;
                                salesHead.DelAddress1 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address1;
                                salesHead.DelAddress2 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address2;
                                salesHead.DelAddress3 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address3;
                                salesHead.DelCity = _busAddress.GetAll(x => x.AddressID == myAddressID).First().City;
                                salesHead.DelCountry = _countryCodes.GetAll(x => x.CountryID == myCountryID).First().Country;
                                salesHead.DelPostCode = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Postcode;
                                salesHead.DelTown = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Town;
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            }
                        }
                        else if (salesHead.EmployeeID != "")
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelCountry;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().DelTown;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            if (salesHead.DelDesc == "")
                            {
                                salesHead.DelDesc = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Description;
                                salesHead.DelAddress1 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address1;
                                salesHead.DelAddress2 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address2;
                                salesHead.DelAddress3 = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Address3;
                                salesHead.DelCity = _busAddress.GetAll(x => x.AddressID == myAddressID).First().City;
                                salesHead.DelCountry = _countryCodes.GetAll(x => x.CountryID == myCountryID).First().Country;
                                salesHead.DelPostCode = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Postcode;
                                salesHead.DelTown = _busAddress.GetAll(x => x.AddressID == myAddressID).First().Town;
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0).Last().CustRef;
                            }
                        }
                    }
                }
                if (booStackOrder == false)
                {

                }
                if (booStackOrder == false)
                {
                    if (isedit)
                    {

                    }
                    else
                    {
                        intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                    }
                }
            }

            foreach (var salesHead in salesHeaderLst)
            {
                try
                {
                    if (checkForAddressChange(salesHead, UserName))
                    {
                        int res = _dp.GetDeliveryAddressId(salesHead.EmployeeID, salesHead.CustID, UserName);
                        if (res > 0)
                        {
                            var address = _busAddress.Exists(s => s.AddressID == res) ? _busAddress.GetAll(s => s.AddressID == res).First() : new tblbus_address();
                            salesHead.AddressId = address.AddressID;
                            salesHead.DelDesc = address.Description;
                            salesHead.DelAddress1 = address.Address1;
                            salesHead.DelAddress2 = address.Address2;
                            salesHead.DelAddress3 = address.Address3;
                            salesHead.DelCity = address.City;
                            salesHead.DelPostCode = address.Postcode;
                            salesHead.DelTown = address.Town;
                        }
                    }
                }
                catch (Exception e)
                {

                }
                /// added by sasi(maternity orders needed autocnf so added this bit(02-01-2021)) 
                bool ucodeCnf = _ucodeOperationsTbl.Exists(s => s.BusinessID == busId && s.UcodeId == salesHead.UCodeId) ? _ucodeOperationsTbl.GetAll(s => s.BusinessID == busId && s.UcodeId == salesHead.UCodeId).First().IsAutoCnf : false;
                ///
                string sSql = "";
                booEmpPointEntitleCheck = booPtsReq ? true : overrideEntitlement ? overrideEntitlement : _dp.EmpEntilementCheck(RolloutName, OverrideEnt, FITALLOC, DIMALLOC, salesHead, busId, 0, IsManPack, false);
                if (isedit == false)
                {
                    tblgen_nextno nextNo = new tblgen_nextno();
                    nextNo = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName == "SALE ORDER").First();
                    intSalesOrderNo = nextNo.AutoNumber.Value;
                    if (intSalesOrderNo > 0)
                    {
                        nextNo.AutoNumber = nextNo.AutoNumber.Value + 1;
                        _nextno.Update(nextNo);

                    }
                }
                if (salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
                {

                    if (isRollOutOrderEst)
                    {
                        if (salesHead.NomCode3 == null)
                        {
                            salesHead.NomCode3 = RolloutName.ToString();
                        }
                        else if (salesHead.NomCode3 == "")
                        {
                            salesHead.NomCode3 = RolloutName.ToString();
                        }
                    }
                    else
                    {
                        if (salesHead.NomCode3 != null)
                        {
                            salesHead.NomCode3 = "";
                        }
                        else if (salesHead.NomCode3 != "")
                        {
                            salesHead.NomCode3 = "";
                        }
                    }
                    salesHead.Carrier = selectedcar.ToString().Trim().Substring(0, selectedcar.ToString().Trim().IndexOf('|'));
                    salesHead.CarrierCharge = carriage;
                    salesHead.ReasonCode = salesHead.ReasonCode == null ? 0 : salesHead.ReasonCode;
                    if (isRollOutOrderEst)
                    {
                        if (salesHead.NomCode3 == null | salesHead.NomCode3 == "")
                        {
                            if (_employeeRollout.Exists(s => s.EmployeeID == salesHead.EmployeeID))
                            {
                                salesHead.NomCode3 = _employeeRollout.GetAll(s => s.EmployeeID == salesHead.EmployeeID).First().RolloutName;
                            }
                        }
                    }
                    else
                    {
                        if (salesHead.NomCode3 != null | salesHead.NomCode3 != "")
                        {
                            salesHead.NomCode3 = "";
                        }
                    }
                    if (isedit)
                    {
                        savModel = _dp.UpdateSalesOrder(access, salesHead, empResetMnths, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, isRollOutOrder, salesHead.OrderNo, busId, UserName.ToString(), isedit, POINTSREQ, FreeStckCheck);
                        if (savModel.result)
                        {
                            if (isedit == false)
                            {

                            }
                            else
                            {
                                intSalesOrderNo = salesHead.OrderNo;
                            }
                            if (isRollOutOrder)
                            {
                                if (!Convert.ToBoolean(_dp.BusinessParam("ROLLOUT_CFM_ORDER", busId)))
                                {
                                    goto skip;
                                }
                            }

                            if (busBudgetReq == true)
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
                                    {

                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(_dp.BusinessParam("ONLEntExceed", busId)) && Convert.ToBoolean(_dp.BusinessParam("REQALLOCEMAIL", busId)))
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) | ucodeCnf)
                                    {
                                        if (booEmpPointEntitleCheck)
                                        {
                                            sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                            int res = _dp.ExecuteQuerywidTrans(sSql);
                                            if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                            if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                            {
                                                sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "' WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                                _dp.ExecuteQuerywidTrans(sSql);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed", isedit = true });
                                    }
                                }
                                else
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
                                    {

                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed", isedit = true });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                            {
                                if (booStackOrder == false)
                                {
                                    if (booEmpPointEntitleCheck)
                                    {
                                        sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                        int res = _dp.ExecuteQuerywidTrans(sSql);
                                        if (Convert.ToBoolean(DELADDR_USER_CREATE) == false)
                                        {
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "and also confirmed", isedit = true });
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "\nOrder has not been Confirmed.\nEntitlement Exceed\n\n", isedit = true });
                                    }
                                }
                                else
                                {
                                    ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed", isedit = true });
                                }
                            }
                            else
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed", isedit = true });
                            }
                            if (booStackOrder)
                            {
                                if (mStackManPack == -1)
                                {
                                    //intManPackNext=
                                }
                                else if (mStackManPack == -2)
                                {
                                    intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                }
                                else
                                {
                                    long checkManPack = _dp.FindOpenManPackOrders(salesHead.DelDesc, salesHead.DelAddress1, salesHead.DelPostCode, busId);
                                    if (checkManPack == 0)
                                    {
                                        intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                    }
                                    else if (checkManPack > 0)
                                    {
                                        intManPackNext = checkManPack;
                                    }
                                }
                            }
                            string sql = "";
                            if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                            {
                                if (booStackOrder == false)
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm, OnlineConfirmDate, OnlineConfirmedBy)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',1,'" + salesHead.OrderDate + "','" + UserName.ToString() + "')";
                                }
                                else
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',0)";
                                }
                            }
                            else
                            {
                                sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',0)";
                            }
                            _dp.ExecuteQuerywidTrans(sql);
                            skip:;
                            if (!ResultSet.Any(x => x.OrderNo == intSalesOrderNo))
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "", isedit = true });
                            }
                            try
                            {
                                if (_pointsByUcode.Exists(s => s.UcodeID == salesHead.UCodeId))
                                {
                                    var message = GetEmailMessage(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo, true, updModel);

                                    ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message.OrderConfirmationemail, salesHead.CustID, salesHead.OnlineUserID, salesHead.EmployeeID, "sasidharan@e4k.co", "", "");

                                    ResultSet.First().OrderConfirmationPop = message.OrderConfirmationPOP;
                                }
                                else
                                {
                                    var message1 = GetEmailMessage(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo, true, updModel);
                                    var message = GetEmergencyMail(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo);
                                    ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message1.OrderConfirmationemail, salesHead.CustID, salesHead.OnlineUserID, salesHead.EmployeeID, "sasidharan@e4k.co", "", "");
                                    //EmergencyMailingProcedure("Emergency Order! Order (" + intSalesOrderNo + ") has not been confirmed...", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message, salesHead.CustID, salesHead.EmployeeID, "", "");
                                    ResultSet.First().OrderConfirmationPop = message1.OrderConfirmationPOP;
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                    else
                    {
                        savModel = _dp.SaveSalesOrder(access, salesHead, empResetMnths, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, isRollOutOrder, intSalesOrderNo, busId, UserName.ToString(), isedit, POINTSREQ, FreeStckCheck);
                        if (savModel.result)
                        {

                            if (isedit == false)
                            {

                            }
                            else
                            {

                            }
                            if (isRollOutOrder)
                            {
                                if (!Convert.ToBoolean(_dp.BusinessParam("ROLLOUT_CFM_ORDER", busId)))
                                {
                                    goto skip;
                                }
                            }

                            if (busBudgetReq == true)
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                                    {

                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(_dp.BusinessParam("ONLEntExceed", busId)) && Convert.ToBoolean(_dp.BusinessParam("REQALLOCEMAIL", busId)))
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                                    {
                                        if (booEmpPointEntitleCheck)
                                        {
                                            sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                            int res = _dp.ExecuteQuerywidTrans(sSql);
                                            if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                            {

                                            }
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has been confirmed" });
                                        }
                                        else
                                        {
                                            if (booAutoConfirm)
                                            {
                                                sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "' WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                                _dp.ExecuteQuerywidTrans(sSql);
                                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has been confirmed" });
                                            }
                                            else
                                            {
                                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                                if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                                {
                                                    sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "' WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                                    _dp.ExecuteQuerywidTrans(sSql);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                    }
                                }
                                else
                                {
                                    if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || ucodeCnf)
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                        if (Convert.ToBoolean(DELADDR_USER_CREATE))
                                        {
                                            sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "' WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                            _dp.ExecuteQuerywidTrans(sSql);
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                            {
                                if (booStackOrder == false)
                                {
                                    if (booEmpPointEntitleCheck)
                                    {
                                        sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + UserName + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                        int res = _dp.ExecuteQuerywidTrans(sSql);
                                        if (Convert.ToBoolean(DELADDR_USER_CREATE) == false)
                                        {
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "and also confirmed" });
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "\nOrder has not been Confirmed.\nEntitlement Exceed\n\n" });
                                    }
                                }
                                else
                                {
                                    ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                }
                            }
                            else
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                            }
                            if (booStackOrder)
                            {
                                if (mStackManPack == -1)
                                {
                                    //intManPackNext=
                                }
                                else if (mStackManPack == -2)
                                {
                                    intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                }
                                else
                                {
                                    long checkManPack = _dp.FindOpenManPackOrders(salesHead.DelDesc, salesHead.DelAddress1, salesHead.DelPostCode, busId);
                                    if (checkManPack == 0)
                                    {
                                        intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                    }
                                    else if (checkManPack > 0)
                                    {
                                        intManPackNext = checkManPack;
                                    }
                                }
                            }
                            string sql = "";
                            if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm || ucodeCnf)
                            {
                                if (booStackOrder == false)
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm, OnlineConfirmDate, OnlineConfirmedBy)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',1,'" + salesHead.OrderDate + "','" + UserName.ToString() + "')";
                                }
                                else
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',0)";
                                }
                            }
                            else
                            {
                                sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + UserName.ToString() + "',0)";
                            }
                            _dp.ExecuteQuerywidTrans(sql);
                            skip:;
                            if (!ResultSet.Any(x => x.OrderNo == intSalesOrderNo))
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "" });
                            }
                            try
                            {
                                if (_pointsByUcode.Exists(s => s.UcodeID == salesHead.UCodeId))
                                {
                                    var message = GetEmailMessage(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo, false);
                                    ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message.OrderConfirmationemail, salesHead.CustID, salesHead.UserID, salesHead.EmployeeID, "sasidharan@e4k.co", "", "");

                                    ResultSet.First().OrderConfirmationPop = message.OrderConfirmationPOP;
                                }
                                else
                                {
                                    var message1 = GetEmailMessage(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo, false);
                                    var message = GetEmergencyMail(salesHead, RolloutName, intManPackNext, pricePermission, ONLCUSREFLBL, cmpLogo, custLogo, intSalesOrderNo);
                                    ConfirmationMailProcedure("Order confirmation", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message1.OrderConfirmationemail, salesHead.CustID, salesHead.UserID, salesHead.EmployeeID, "sasidharan@e4k.co", "", "");
                                    EmergencyMailingProcedure("Emergency Order! Order (" + intSalesOrderNo + ") has not been confirmed...", ueMailEMail, adminMail, mailUsername, mailPassword, mailPort, mailServer, message, salesHead.CustID, salesHead.EmployeeID, "", "");
                                    ResultSet.First().OrderConfirmationPop = message1.OrderConfirmationPOP;
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                else
                {
                    break;
                }
                if (savModel.errorstring != null && savModel.errorstring != "")
                {
                    if (FreeStckCheck && ResultSet.Count == 0 && savModel.errorstring.ToLower() == "freestock")
                    {
                        var newResult = salesHead.SalesOrderLine.GroupBy(s => new { s.StyleID, s.ColourID, s.SizeID, s.IsDleted, s.IsAlternateStyle }).
                               Select(sa => new SalesOrderLineViewModel
                               {
                                   IsAlternateStyle = sa.First().IsAlternateStyle,
                                   StyleID = sa.First().StyleID.Trim(),
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
                                   IsDleted = sa.First().IsDleted
                               }).ToList();
                        string retunCnt = "";
                        if (isedit)
                        {
                            foreach (var line in newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false))
                            {

                                var freeStock = _dp.GetFreeStock(line.StyleID, line.ColourID, line.SizeID, salesHead.WarehouseID, salesHead.SalesOrderLine, true, false);
                                //freeStock = freeStock +Convert.ToInt32 (line.OrdQty);
                                if (line.OrdQty > freeStock)
                                {
                                    var freeStock1 = freeStock - line.OrdQty > 0 ? freeStock - line.OrdQty : 0;
                                    retunCnt = retunCnt + "{%FREESTOCKERROR%}The ordered quantity(" + line.OrdQty + ") for product " + line.Description + "(" + line.StyleID + ") " + line.ColourID + " " + line.SizeID + " is grater than the available freestock quantity (" + freeStock + ")\n";

                                }
                                else
                                {
                                    retunCnt = retunCnt + "";
                                }
                            }
                        }
                        else
                        {
                            foreach (var line in newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false))
                            {
                                var freeStock = _dp.GetFreeStock(line.StyleID, line.ColourID, line.SizeID, salesHead.WarehouseID, null, isedit);
                                if (line.OrdQty > freeStock)
                                {
                                    retunCnt = retunCnt + "{%FREESTOCKERROR%}The ordered quantity(" + line.OrdQty + ") for product " + line.Description + "(" + line.StyleID + ") " + line.ColourID + " " + line.SizeID + " is grater than the available freestock quantity (" + freeStock + ")\n";

                                }
                                else
                                {
                                    retunCnt = retunCnt + "";
                                }

                            }
                        }
                        AcceptResultSet.type = retunCnt;
                    }
                    else if (savModel.errorstring.ToLower() == "pointsexceeded")
                    {
                        AcceptResultSet.type = "The orderded points has exceeded the maximum points.";
                    }
                }
                else
                {
                    AcceptResultSet.results = ResultSet;
                    AcceptResultSet.type = "";
                }
            }
            return AcceptResultSet;
        }

        private bool checkForAddressChange(SalesOrderHeaderViewModel salesHead, string usr = "")
        {
            var result = false;
            int res = _dp.GetDeliveryAddressId(salesHead.EmployeeID, salesHead.CustID, usr);
            result = res > 0 ? res == salesHead.AddressId ? false : true : false;
            return result;
        }
        #endregion
        #region EmergencyMailingProcedure
        public void EmergencyMailingProcedure(string subject, string ueMailEMail, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string message, string busId, string empId, string bcc, string cc)
        {
            string headOfficeEmail = "";
            if (Convert.ToBoolean(_dp.BusinessParam("REQALLOCEMAIL", busId)))
            {
                if (Convert.ToBoolean(_dp.BusinessParam("SEND_ENTITLE_EMAIL", busId)))
                {
                    //sending emergency order to the  user logged in and usedid employee
                    string sSql = "";
                    sSql = sSql + "SELECT UserName, Email_ID, ForeName, SurName FROM tblusers t1 JOIN tblonline_userid_employee t2 ON t1.BusinessID=t2.BusinessID AND t1.UserName=t2.OnlineUserID  WHERE t1.Active='Y' AND t2.EmployeeID='" + empId + "' AND t2.BusinessID='" + busId + "'";
                    DataTable dt = _dp.GetDataTable(sSql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            _dp.sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, message, dr["Email_ID"].ToString(), bcc, cc);
                        }
                    }

                    headOfficeEmail = _dp.BusinessParam("HeadOfficeEmail", busId);
                    if (headOfficeEmail != "")
                    {
                        _dp.sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, message, headOfficeEmail, bcc, cc);
                    }
                }
            }
        }
        #endregion

        #region ConfirmationMailProcedure
        public void ConfirmationMailProcedure(string subject, string ueMailEMail, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string message, string busId, string userID, string empId, string tomail, string bcc, string cc)
        {
            string ueMail = _dp.BusinessParam("UsersManageEmail", busId);
            string userMail = "";
            string OrgOnlineUserID = "";
            bool enableAdminMail = Convert.ToBoolean(_dp.BusinessParam("EnableAdminMail", busId));
            ueMail = ueMail == "" ? ueMailEMail : ueMail;
            string adminMailId = adminMail;
            var user = _tblUser.GetAll(s => s.UserName == userID && s.BusinessID == busId).First();
            if (user != null)
            {
                if (user.Email_ID != "")
                {
                    tomail = user.Email_ID;
                    //tomail = "sasidharan@e4k.co";
                }
                if (enableAdminMail)
                {
                    bcc = ueMail;
                }
                if (OrgOnlineUserID != "")
                {
                    var orgUser = _tblUser.GetAll(s => s.UserName == OrgOnlineUserID && s.BusinessID == busId).Distinct().First();
                    if (orgUser != null)
                    {
                        if (orgUser.Email_ID != "")
                        {
                            cc = orgUser.Email_ID;
                        }
                    }
                }
                _dp.sendSmtpMail(subject, adminMail, mailUsername, mailPassword, mailPort, mailServer, message, tomail, bcc, cc);
            }
            //    Dim UEEmailID As String = BusinessParam("UsersManageEmail", Session("CustID"))
            //Dim UserMailID As String = ""
            //Dim EnableAdminMail As Boolean = CBoolstr(BusinessParam("EnableAdminMail", Session("CustID")))
            //UEEmailID = IIf(UEEmailID = "", ConfigurationSettings.AppSettings.Item("EmailID"), UEEmailID)
            //Dim AdminEmail As String = ConfigurationSettings.AppSettings.Item("AdminEmail")
            //sql = "SELECT * FROM tblusers WHERE UserName='" & Session("UserID") & "' AND BusinessID='" & Session("CustID") & "'"
            //    If Not rsEmail.EOF Then
            //    LoginUser = " - " & rsEmail("ForeName").Value & " " & rsEmail("SurName").Value
            //    If IsDBNull(rsEmail("Email_ID").Value) = False Then
            //        UserMailID = rsEmail("Email_ID").Value
            //        ObjMail1.To = rsEmail("Email_ID").Value
            //        If EnableAdminMail Then
            //            ObjMail1.Bcc = IIf(AdminEmail = UEEmailID, Nothing, AdminEmail)
            //        End If
            //        ObjMail1.From = ConfigurationSettings.AppSettings.Item("EmailID")
            //        If Trim(Session("OrgOnlineUserID")) <> "" Then
            //            orgUserEmail = GetDBScalarString("SELECT DISTINCT Email_ID FROM tblusers WHERE UserName='" & Trim(Session("OrgOnlineUserID")) & "' AND BusinessID='" & Session("CustID") & "'")
            //            If orgUserEmail <> "" And UCase(orgUserEmail) <> UCase(ObjMail1.To) Then
            //                ObjMail1.Cc = orgUserEmail
            //            End If
            //        End If
            //        ObjMail1.Subject = "Online Order Confirmation..."
            //        ObjMail1.BodyFormat = MailFormat.Html
            //        ObjMail1.Body = "<HTML><HEAD></HEAD><BODY>"
            //        'ObjMail1.Body &= "Dear <B>Mr/Ms. " & rsEmail("ForeName").Value & " " & rsEmail("SurName").Value & "</B><BR>"
            //        ObjMail1.Body &= htmlstr
            //        ObjMail1.Body &= "</BODY></HTML>"
            //        SmtpMail.SmtpServer = ConfigurationSettings.AppSettings.Item("smtpserver")
            //        Try
            //            SMTPClientMethodToSendMail(ObjMail1)

            //            'SmtpMail.Send(ObjMail1)
            //            ' WriteScript("<script language='javascript'>alert('" & Convert.ToString(GetLocalResourceObject("Alert2.Text")) & "');</script>")
            //        Catch exe As Exception
            //            WriteScript("<script language='javascript'>alert('" & Convert.ToString(GetLocalResourceObject("Alert3.Text")) & "');</script>")
            //        End Try
            //        'Response.Write(ObjMail1.Body)
            //    Else
            //        WriteScript("<script language='javascript'>alert('" & Convert.ToString(GetLocalResourceObject("Alert4.Text")) & "');</script>")
            //    End If
            //End If
            //rsEmail.Close()
        }
        #endregion

        #region GetUpdateMailMessages
        public string GetOlderOrderInfoMail(SalesOrderHeaderViewModel salesHead, string pricePermission)
        {

            string message = _dp.FillExistingOrderLineMessage(salesHead, "hide");
            return message;
        }
        #endregion

        #region SendEmail
        public OrderConfirmation GetEmailMessage(SalesOrderHeaderViewModel salesHead, string rolloutname, long manpackNo, string pricePermission, string ONLCUSREFLBL, string cmpLogo, string custLogo, long orderNo, bool isedit = false, UpdateMailModel updModel = null)
        {
            DataTable saleOrder = new DataTable();
            OrderConfirmation message = _dp.GetNecessaryMailTemplates(salesHead, rolloutname, custLogo, cmpLogo, manpackNo, pricePermission, ONLCUSREFLBL, orderNo, isedit, updModel);
            return message;
        }

        #endregion

        #region GetEmergencyMail
        public string GetEmergencyMail(SalesOrderHeaderViewModel salesHead, string rolloutname, long manpackNo, string pricePermission, string ONLCUSREFLBL, string cmpLogo, string custLogo, long orderNo)
        {
            string message = "";
            message = _dp.getEmergencyTemplate(salesHead, orderNo);
            return message;
        }

        #endregion



        #region  ReplaceArr
        public List<string> GetAllReplaceStrings()
        {
            List<string> results = new List<string>(); results.Add("%BarcodeOrderNo%");
            results.Add("%customer_name%");
            results.Add("%ReportTitle%"); results.Add("%customer_address1%"); results.Add("%delivery_address1%"); results.Add("%customer_address2%"); results.Add("%delivery_address2%"); results.Add("%customer_address3%"); results.Add("%delivery_address3%"); results.Add("%customer_town%"); results.Add("%delivery_town%"); results.Add("%customer_city%"); results.Add("%delivery_city%"); results.Add("%customer_postcode%"); results.Add("%delivery_postcode%"); results.Add("%customer_country%"); results.Add("%delivery_country%"); results.Add("%OrderNo%");
            results.Add("%OrderDate%");
            results.Add("%AccountNo%");
            results.Add("%ManPackNo%");
            results.Add("%NominalCode%"); results.Add("%Employee%");
            results.Add("%OrgOrdHead%");
            results.Add("%OrgPORef%");
            results.Add("%OrderLines%"); results.Add("%totalgoods%");
            results.Add("%comments%");
            results.Add("%carriercharges%"); results.Add("%ordertotal%");
            results.Add("%vattotal%");
            results.Add("%grandtotal%"); results.Add("%RC%");
            results.Add("%PaymentDetail%");
            results.Add("%ReportTitle%"); results.Add("%CompLogoPath%");
            results.Add("%LogoPath%");
            results.Add("%first_companyname%");
            results.Add("%style%"); results.Add("%Description%");
            results.Add("%Colour%");
            results.Add("%Size%"); results.Add("%qty%");
            results.Add("%price%");
            results.Add("%netvalue%");
            results.Add("%vat%");
            results.Add("%reason%");
            results.Add("%OrgOrderNo%");
            results.Add("%OrgPORef%");
            results.Add("%freetext%");
            return results;
        }
        #endregion

        #region CheckCarriage

        public bool CheckCarriage(TotalModel tot, bool IsManPack, double CARRPERCENT, List<SalesOrderHeaderViewModel> SalesOrderHeader, double CARRREQAMT, string businessId)
        {
            bool checkCarriage = false;
            if (IsManPack == false)
            {
                if ((_dp.checkBulkCarriageLine((SalesOrderHeader)) == false))
                {
                    if (CARRPERCENT > 0)
                    {
                        checkCarriage = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(tot.Total) < Convert.ToDouble(CARRREQAMT))
                        {
                            checkCarriage = false;
                        }
                        else
                        {
                            checkCarriage = true;
                        }
                    }
                }
                else
                {
                    checkCarriage = true;
                }
            }
            else
            {
                if (_dp.checkCarriageLine(SalesOrderHeader) == false)
                {

                    if (Convert.ToDouble(CARRPERCENT) > 0)
                    {
                        checkCarriage = false;
                    }
                    else
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("REQCARR_WO_AMTCHK", businessId)))
                        {
                            checkCarriage = false;
                        }
                        else
                        {
                            if (Convert.ToDouble(tot.Total) < Convert.ToDouble(CARRREQAMT))
                            {
                                checkCarriage = false;
                            }
                            else
                            {
                                checkCarriage = true;
                            }
                        }
                    }
                }
                else
                {
                    checkCarriage = true;
                }
            }
            return checkCarriage;
        }
        #endregion

        #region FillCombo_CustomerDelivery
        public List<BusAddress1> FillCombo_CustomerDelivery(string busId, string access, string orderPermit, string UserName, bool IsManpack = false, string selEmp = "")
        {
            return _dp.FillCombo_CustomerDelivery(busId, access, orderPermit, UserName, IsManpack, selEmp);
        }


        #endregion
        #region GetPointsModel
        public PointsModel GetPointsModel(string uCode, string busId)
        {
            PointsModel ptsModel = new PointsModel();
            var result = _pointsByUcode.GetAll(x => x.BusinessID == busId && x.UcodeID == uCode).FirstOrDefault();
            if (result != null)
            {
                ptsModel.BusinessID = result.BusinessID;
                ptsModel.CompanyID = result.CompanyID;
                ptsModel.UcodeID = result.UcodeID;
                ptsModel.TotalPoints = result.TotalPoints.Value;
                ptsModel.FromDate = result.FromDate;
                ptsModel.ToDate = result.ToDate;
                ptsModel.LstStyles = _pointStyle.GetAll(x => x.UcodeID == uCode && x.BusinessID == busId).Select(x => new PointsStyle { Points = x.Points.Value, Style = x.StyleID }).ToList();
            }

            return ptsModel;
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
        #region DeleteOrder
        public bool DeleteOrder(int orderNO, string empId, string onlineUserId, bool pointsReq, string busId, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, bool isEmergency, string reason = "")
        {
            bool result = false;
            var dataCar = _dp.GetCarrierStyleCmbValue(busId);
            try
            {
                if (_tblSalesHeader.Exists(s => s.OrderNo == orderNO))
                {
                    var salesHead = _tblSalesHeader.GetAll(s => s.OrderNo == orderNO).First();

                    //var salesLines = _tblSalesLines.GetAll(s => s.OrderNo == orderNO).ToList();
                    //foreach (var saleL in salesLines)
                    //{
                    //    if (dataCar.Contains(saleL.StyleID) != true)
                    //    {
                    //        var EmpSo = _stockCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == empId && s.StyleID == saleL.StyleID).First();
                    //        EmpSo.SOQty = EmpSo.SOQty - Convert.ToInt32(saleL.OrdQty.Value);
                    //        EmpSo.SOQty = EmpSo.SOQty > 0 ? EmpSo.SOQty : 0;
                    //        _stockCard.Update(EmpSo);
                    //        if (isEmergency == false)
                    //        {

                    //            if (pointsReq)
                    //            {
                    //                var ptsCard = _pointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == empId && s.StyleID == saleL.StyleID).First();
                    //                ptsCard.SOPoints = ptsCard.SOPoints - (Convert.ToInt32(saleL.OrdQty) * _pointsStyle.GetAll(s => s.StyleID == saleL.StyleID && s.UcodeID == salesHead.UCodeId).First().Points.Value);
                    //                ptsCard.SOPoints = ptsCard.SOPoints > 0 ? ptsCard.SOPoints : 0;
                    //                _pointsCard.Update(ptsCard);
                    //            }
                    //        }
                    //    }
                    //}
                    //if (_ucodeOperationsTbl.Exists(s => s.BusinessID == busId && s.UcodeId == salesHead.UCodeId && s.FreeStkChk))
                    //{
                    //    foreach (var saleL in salesLines)
                    //    {
                    //        var so = _fskStyleLocations.GetAll(s => s.StyleID == saleL.StyleID && s.ColourID == saleL.ColourID && s.SizeID == saleL.SizeID && s.LocationId=="All").First();
                    //        so.SOQty = so.SOQty - Convert.ToInt32(saleL.OrdQty.Value);
                    //        _fskStyleLocations.Update(so);
                    //    }
                    //}
                    //_tblSalesLines.Delete(s => s.OrderNo == salesHead.OrderNo);
                    //_tblSalesHeader.Delete(s => s.OrderNo == salesHead.OrderNo);

                    if (_dp.DeleteOrder(orderNO, empId, onlineUserId, pointsReq, busId, adminMail, mailUsername, mailPassword, mailPort, mailServer, isEmergency, salesHead.UCodeId))
                    {
                        var rejectReason = new tblonline_rejectorder_reasons();
                        rejectReason.BusinessId = busId;
                        rejectReason.OrderNo = orderNO;
                        rejectReason.EmployeeId = empId;
                        rejectReason.RejectedBy = onlineUserId;
                        rejectReason.RejectedDate = DateTime.Now;
                        rejectReason.RejectedReason = reason;
                        _rejectReasonTbl.Insert(rejectReason);
                        _dp.sendDeleteMail(orderNO, reason, busId, onlineUserId, salesHead.PinNo, adminMail, mailUsername, mailPassword, mailPort, mailServer);
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }


        #endregion

        #endregion




    }
}
