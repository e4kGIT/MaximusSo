using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
  public  class UserImportModel
    {
        public string  USERNAME { get; set; }
        public string AspUserID { get; set; }
        public string Password { get; set; }
        public string FORENAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAILID { get; set; }
        public string ROLE { get; set; }
        public string ACTIVE { get; set; }
        public string MAPTO { get; set; }
        public List<string> MAPTOlst { get; set; }
        public string BusiD { get; set; }
    }
    public class AddressImportModel
    {
        public string COMPANYID  { get; set; }
        public string BUSINESSID { get; set; }
        public string ADDRESS1 { get; set; }
        public string DESCRIPTION { get; set; }
         public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string TOWN { get; set; }
        public string CITYCOUNTY { get; set; }
        public string COUNTRYID { get; set; }
        public string POSTCODE { get; set; }
        public string COUNTRY { get; set; }
        public string CONTACTNAME { get; set; }
        public string CONTACTID { get; set; }
        public  string EMAIL { get; set; }
        public  string COSTCENTER { get; set; }
        public string MAPTO { get; set; }
    }
    public class EmployeeImportModel
    {
        public string EMPLOYEEID { get; set; }
        public string TITLE { get; set; }
        public string DEPARTMENT { get; set; }
        public string FORENAME { get; set; }
        public string SURNAME { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public string UCODE { get; set; }
        public string MAPTO { get; set; }
        public List<string> MAPTOlst { get; set; }
        public List<string> UCODEIDlst{ get; set; }
    }
}
