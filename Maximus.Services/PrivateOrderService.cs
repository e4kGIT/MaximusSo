using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Services.Interface;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.Models;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;

namespace Maximus.Services
{
    public class PrivateOrderService : IPrivateOrder
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
        public PrivateOrderService(IUnitOfWork unitOfWork)
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
        private bool checkForAddressChange(SalesOrderHeaderViewModel salesHead, string usr = "")
        {
            var result = false;
            int res = _dp.GetDeliveryAddressId(salesHead.EmployeeID, salesHead.CustID, usr);
            result = res > 0 ? res == salesHead.AddressId ? false : true : false;
            return result;
        }
        public AcceptResultSet AcceptOrder(string cmpId, bool IsManPack, string busId, List<SalesOrderHeaderViewModel> salesHeaderLst, List<BusAddress1> busAddress, string selectedcar, string UserName, double CARRPERCENT, double CARRREQAMT, string Browser, string REMOTE_ADDR, string cmpLogo, string custLogo, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string ueMailEMail, string HTTP_X_FORWARDED_FOR, bool isedit, bool boolDeleteConfirm, string pnlCarriageReason, string pricePermission, UpdateMailModel updModel)
        {
            long intSalesOrderNo = isedit ? salesHeaderLst.First().OrderNo : 0;
            long txtOrderNo = isedit ? salesHeaderLst.Where(x => x.IsEditing).First().OrderNo : 0;
            BusAddress1 invAddress = new BusAddress1();
            var ResultSet = new List<SaveOrderResultSet>();
            var AcceptResultSet = new AcceptResultSet();
            double carriage = 0.0;
            AcceptResultSet.results = new List<SaveOrderResultSet>();
            TotalModel tot = new TotalModel();
            tot = tot = _dp.GetAlltotals(salesHeaderLst, carriage);
            bool booExistInManpack = false;
            bool booStackOrder;
            bool overrideEntitlement = false;

            var lastObj = salesHeaderLst.Last();
            booStackOrder = Convert.ToBoolean(_dp.BusinessParam("STACKORDERS", busId));

            if (!CheckCarriage(tot, IsManPack, CARRPERCENT, salesHeaderLst, CARRREQAMT, busId))
            {
                if (IsManPack)
                {
                    if (booStackOrder == false)
                    {
                        if (Convert.ToBoolean(_dp.BusinessParam("CarrierPromptPvt", salesHeaderLst.First().CustID)) && salesHeaderLst.First().SalesOrderLine.Any(s => s.isCarrline) == false)
                        {
                            AcceptResultSet.type = "CarrierPrompt";
                            return AcceptResultSet;
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
                        if (Convert.ToBoolean(_dp.BusinessParam("CarrierPromptPvt", busId)))
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
            foreach (var salesHead in salesHeaderLst)
            {
                try
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
                    salesHead.CustRef = "Private order";
                    salesHead.UCodeId = "";
                    salesHead.Carrier = selectedcar.ToString().Trim().Substring(0, selectedcar.ToString().Trim().IndexOf('|'));
                    salesHead.CarrierCharge = carriage;
                    salesHead.ReasonCode = salesHead.ReasonCode == null ? 0 : salesHead.ReasonCode;
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
                    if (salesHead.SalesOrderLine.Any(s => s.IsDleted == false))
                    {
                        if (isedit)
                        {
                            AcceptResultSet.results.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo });
                            AcceptResultSet.type = "";
                        }
                        else
                        {
                            if (_dp.SavePrivateOrder(salesHead, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, intSalesOrderNo, busId, UserName.ToString(), false))
                            {
                                ConfirmationMailProcedure("Order Confirmation",ueMailEMail,adminMail,mailUsername,mailPassword,mailPort,mailServer,_dp.GetPrivateOrderMailMessage(salesHead, custLogo, cmpLogo, intSalesOrderNo),busId,UserName,salesHead.EmployeeID,salesHead.EmailID,"","");
                                AcceptResultSet.results.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo });
                                AcceptResultSet.type = "";
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    AcceptResultSet.type = "Failed";
                }

            }
            return AcceptResultSet;
        }
        #region ConfirmationMailProcedure
        public void ConfirmationMailProcedure(string subject, string ueMailEMail, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer, string message, string busId, string userID, string empId, string tomail, string bcc, string cc)
        {
            string ueMail ="";
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

        public List<PrivateOrderResultModel> ShowPrivateOrders(string access, string onlineuserId, string busId)
        {
          return  _dp.ShowPrivateOrders(access, onlineuserId, busId);
        }

    }
}


 