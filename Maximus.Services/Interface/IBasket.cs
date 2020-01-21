﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.models;

namespace Maximus.Services.Interface
{
    public interface IBasket
    {


        AcceptResultSet AcceptOrder(string cmpId, bool IsManPack, string busId, List<SalesOrderHeaderViewModel> salesHeaderLst, string addDesc, bool isRollOutOrder, string OverrideEnt, bool CusRefMan, string POINTSREQD, List<BusAddress1> busAddress, string DIFF_MANPACK_INFO, string NOMCODEMAN, string ONLNEREQNOM1, string ONLNEREQNOM2, string ONLNEREQNOM3, string ONLNEREQNOM4, string ONLNEREQNOM5, string RolloutName, string selectedcar, string UserName, string DELADDR_USER_CREATE, double CARRPERCENT, double CARRREQAMT, string FITALLOC, string DIMALLOC, string BUDGETREQ, string Browser,  string REMOTE_ADDR,string HTTP_X_FORWARDED_FOR="");

        bool CheckCarriage(TotalModel tot, bool IsManPack, double CARRPERCENT, List<SalesOrderHeaderViewModel> SalesOrderHeader, double CARRREQAMT);

        List<BusAddress1> FillCombo_CustomerDelivery(string busId, string access, string orderPermit, string UserName, bool IsManpack = false, string selEmp = "");
        //List<SalesOrderLineViewModel> DeleteCartviewDetailGridView(SalesOrderLineViewModel item, SalesOrderHeaderViewModel result);
        //List<SalesOrderHeaderViewModel> DeleteCarView(SalesOrderHeaderViewModel item, string empId = "", List<SalesOrderHeaderViewModel> model = null);
        //List<string> FillCarrierDropdown();
        //List<string> FillCarrierStyle();
        //List<SiteCodeModel> FillSiteCode(string busId);
        //List<SalesOrderLineViewModel> GetAssemblyList(int LineNo, List<SalesOrderLineViewModel> result = null);
        //List<SalesOrderHeaderViewModel> GetCartView(string empid = "", List<SalesOrderHeaderViewModel> mod = null, string clickedEmp = "");
        //List<SalesOrderLineViewModel> GetCartviewDetailGridView(string empId = "", string appPath = "", string buss = "", List<SalesOrderHeaderViewModel> salesHeaders = null, string clickedEmp = "", string thisEmp = "");
        //List<SalesOrderHeaderViewModel> GetEmployee();
        //string GetEmployeeDeliveryAddress(string ctrl, string business);
        //bool GetEntitlement(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "", long lineNo = 0, string OverrideEnt = "", string Ucodes = "", List<SalesOrderLineViewModel> salesOrderLines = null);
        //List<SalesOrderHeaderViewModel> UpdateCartView(SalesOrderHeaderViewModel item, List<SalesOrderHeaderViewModel> model);
        //List<SalesOrderLineViewModel> UpdateCartviewDetailGridView(SalesOrderLineViewModel item, SalesOrderHeaderViewModel entQty = null, List<SalesOrderLineViewModel> result = null, string businessId = "", string Price = "");
        //List<BusAddress1> FillCombo_CustomerDelivery(bool value, string empId);

    }
}