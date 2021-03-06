﻿using Maximus.Data.models;
using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
    public interface IUser
    {
        List<EmployeeLoginModel> GetLoginDetails(string userName, string passWord);
        SiteCodeUserAddress GetSiteCodeAndUserAddress(string userName, string busId);
        tblbus_address GetUserAddress(string userName, string busId);
        bool HasCostCenter(string busId);
        int GetUserCount(string userName);
        string GetWelcome(string busId);
        bool SetWelcomeText(string htmlTxt, string busId);
        void ResetPassword(tbluser user, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer);

    }
}
