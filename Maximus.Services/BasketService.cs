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
        public readonly UcodeByFreeTextView _ucodeByFreeText;
        public readonly UcodeEmployees _ucodeEmployees;
        public readonly Ucodes _ucodes;
        public readonly BusAddress _busAddress;
        public readonly PointsByUcode _pointsByUcode; 
             public readonly PointStyle _pointStyle;
        public readonly DataProcessing _dp;
        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            PointStyle pointStyle= new PointStyle(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
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
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
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
            _dp = dp;
            _pointsByUcode = pointsByUcode;
            _pointStyle = pointStyle;
        }



        #region  AcceptOrder 
        public AcceptResultSet AcceptOrder(string cmpId, bool IsManPack, string busId, List<SalesOrderHeaderViewModel> salesHeaderLst, string addDesc, bool isRollOutOrder, string OverrideEnt, bool CusRefMan, string POINTSREQ, List<BusAddress1> busAddress, string DIFF_MANPACK_INFO, string NOMCODEMAN, string ONLNEREQNOM1, string ONLNEREQNOM2, string ONLNEREQNOM3, string ONLNEREQNOM4, string ONLNEREQNOM5, string RolloutName, string selectedcar, string UserName, string DELADDR_USER_CREATE, double CARRPERCENT, double CARRREQAMT, string FITALLOC, string DIMALLOC, string BUDGETREQ, string Browser, string HTTP_X_FORWARDED_FOR, string REMOTE_ADDR, bool boolDeleteConfirm)
         {
            int addressId = 0;
            bool booCheck = true; bool booAutoConfirm = false; long mStackManPack = 0;
            bool optNew = false;
            long intSalesOrderNo = 0;
            long intnext = 0;
            string tmpMsg = "";
            bool EditFlag = false;
            bool StrSQL = false;
            long i = 0;
            string mCDate;
            bool booNotSAP = true;
            long intManPackNext = 0;
            string mOrdDate = "";
            string mySqlInv = "";
            string txtOrderNo = "0";
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
                    AcceptResultSet.type = "Po reference is Mandatory";
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
                        foreach (var lines in order.SalesOrderLine)
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
            var sss = list.Any(x => x.AddressId == addressId);
            int myAddressID = 0, myContactID = 0, myCountryID = 0;
            myAddressID = addressId;
            myContactID = Convert.ToInt32((busAddress).Where(x => x.AddressId == addressId).First().contactId);
            myCountryID = Convert.ToInt32((busAddress).Where(x => x.AddressId == addressId).First().CountryCode);
            if (!isPersonalOrder)
            {
                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                invAddress = _dp.GetAddressDetails(SQL);
            }
            if (!CheckCarriage(tot, IsManPack, CARRPERCENT, salesHeaderLst, CARRREQAMT))
            {
                //SetTempData()
                if (IsManPack)
                {
                    if (booStackOrder == false)
                    {
                        //_dp.InsertManpackCarriage(lastObj, Session["CARRPRICE"].ToString());
                    }
                }
                else
                {
                    if (booStackOrder == false)
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("CarrierPrompt", busId)))
                        {
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
            }

            if (Convert.ToInt32(txtOrderNo) == 0)
            {
                EditFlag = false;
            }
            else
            {
                EditFlag = true;
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
                    if (saleshead.SalesOrderLine.Count > 0 | boolDeleteConfirm)
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
                                saleshead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                            }
                            //                ResetAssemblyLineNo(Session.Item("objCurrentOrder"))
                            //                If EditFlag Then
                            //                    Dim objorderlines As SalesOrderLine = DirectCast(Session.Item("objCurrentOrder").SalesOrderLine, SalesOrderLine)
                            //                    getNarateEditDetailMail(objorderlines)
                            //                End If
                            if (isRollOutOrder)
                            {
                                if (saleshead.NomCode3.ToString().Trim() == "")
                                {
                                    saleshead.NomCode3 = RolloutName;
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
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelPostCode;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelTown;
                            salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().CustRef;
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
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                            }
                        }
                        else if (salesHead.EmployeeID != "" && salesHead.EmployeeID != null)
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelPostCode;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelTown;
                            salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().CustRef;
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
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                            }
                        }

                    }
                    else if (optNew && booOrderInfo == false)
                    {
                        if (salesHead.Template != "")
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().DelTown;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.IsTemplate && x.SalesOrderLine.Count > 0).Last().CustRef;
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
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                            }
                        }
                        else if (salesHead.EmployeeID != "")
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelTown = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().DelTown;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.EmployeeID == salesHead.EmployeeID && x.SalesOrderLine.Count > 0).Last().CustRef;
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
                                salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                            }
                        }
                    }
                }
                if (booStackOrder == false)
                {

                }
                if (booStackOrder == false)
                {
                    intManPackNext = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                }
            }
            foreach (var salesHead in salesHeaderLst)
            {
                string sSql = "";
                booEmpPointEntitleCheck = overrideEntitlement ? overrideEntitlement : _dp.EmpEntilementCheck(RolloutName, OverrideEnt, FITALLOC, DIMALLOC, salesHead, busId, 0, IsManPack, false);
                tblgen_nextno nextNo = new tblgen_nextno();
                nextNo = _nextno.GetAll(x => x.CompanyID == cmpId && x.ItemName == "SALE ORDER").First();
                intSalesOrderNo = nextNo.AutoNumber.Value;
                if (intSalesOrderNo > 0)
                {
                    nextNo.AutoNumber = nextNo.AutoNumber.Value + 1;
                    _nextno.Update(nextNo);

                }
                if (salesHead.SalesOrderLine.Count > 0)
                {

                    if (isRollOutOrder)
                    {
                        if (salesHead.NomCode3 == null)
                        {
                            salesHead.NomCode3 = RolloutName.ToString();
                        }
                    }
                    salesHead.Carrier = selectedcar.ToString().Trim().Substring(0, selectedcar.ToString().Trim().IndexOf('|'));
                    salesHead.CarrierCharge = carriage;
                    salesHead.ReasonCode = 0;
                    if (_dp.SaveSalesOrder(salesHead, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, isRollOutOrder, intSalesOrderNo, busId, UserName.ToString(), EditFlag,POINTSREQ))
                    {
                        if (EditFlag == false)
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
                                if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
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
                                    ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                }
                            }
                            else
                            {
                                if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)))
                                {

                                }
                                else
                                {
                                    ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                }
                            }
                        }
                        else if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
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
                        if (Convert.ToBoolean(_dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
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
                    }
                }
                else
                {
                    break;
                }
                AcceptResultSet.results = ResultSet;
                AcceptResultSet.type = "";
            }
            return AcceptResultSet;
        }
        #endregion



        #region CheckCarriage

        public bool CheckCarriage(TotalModel tot, bool IsManPack, double CARRPERCENT, List<SalesOrderHeaderViewModel> SalesOrderHeader, double CARRREQAMT)
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
        #endregion


    }
}
