using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public enum Allocation
    {
        DIMALLOC = 1
    }
    public enum SizesENUM
    {
        NOSIZESFOUND = 1
    }
    public enum ReturnTypes
    {
        RETURNS = 1,
        EMERGENCY = 2,
        MATERNITY = 3,
        PRIVATE=4
    }
    public enum controls
    {
        Price,
        Orders,
        Employee,
        OrderDelete,
        NomCode,
        Access,
        SAP,
        OrderConfirm,
        AllowOverrideEntitlement,
        OverrideEntitlementWithReason,
        AllAddress,
        UserAddressMapping,
        ShowStockcard,
        ROLLOUTEMPDELADDR_CHG,
        SuperUser
    }
    public class AllEnums
    {

    }
}