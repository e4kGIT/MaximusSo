using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class BusAddress
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public string contactId { get; set; }
        public string AddressDescription { get; set; }
    }
    public class EmployeeViewModel
    {
        public string role { get; set; }
        public string BuisnessId { get; set; }
        public string CompanyId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string EmpFirstName { get; set; }
        [Required]
        public string EmpLastName { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public int Entitlement { get; set; }
        public List<string> Templates { get; set; }
        [Required]
        public string EmpUcodes { get; set; }
        [Required]
        public BusAddress Address { get; set; }
        public bool EmpIsActive { get; set; }
        public bool chkMapEmp { get; set; }
        public bool chkMapAddr { get; set; }
        public List<string> DepartmentLst { get; set; }
        public List<BusAddress> AddressLst { get; set; }
        public List<string> Ucodes { get; set; }
        public List<string> ucodeLst { get; set; }
        public List<string> Roles { get; set; }
        public string roleId { get; set; }
    }
}