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
        public string TELEPHONE { get; set; }
        public List<string> TELEPHONElst { get; set; }
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
        public List<string> CONTACTNAMElst { get; set; }
        public long CONTACTID { get; set; }
        public long ADDRESSID { get; set; }
        public  string EMAIL { get; set; }
        public List<string> EMAILlst { get; set; }
        public  string COSTCENTER { get; set; }
        public List<string> COSTCENTERlst { get; set; }
        public string MAPTO { get; set; }
        public List<string> MAPTOlst { get; set; }
    }
    public class EmployeeImportModel
    {
        public string EMPLOYEEID { get; set; }
        public string Aspuserid { get; set; }
        public string BusId { get; set; }
        public string TITLE { get; set; }
        public string DEPARTMENT { get; set; }
        public int DEPARTMENTID { get; set; }
        public int ROLEID { get; set; }
        public string FORENAME { get; set; }
        public string SURNAME { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public string UCODE { get; set; }
        public string MAPTO { get; set; }
        public string MAPTO1 { get; set; }
        public string MAPTOADDR { get; set; }

        public List<string> MAPTOADDRLst { get; set; }
        public List<string> MAPTOlst { get; set; }
        public List<string> UCODEIDlst{ get; set; }
    }
}
