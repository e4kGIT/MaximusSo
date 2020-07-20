using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;

namespace Maximus.Services.Interface
{
  public  interface IOrderDisplay
    {
        List<OrderDisplayModel> GetAllOrders(string busId, string userId, List<string> usrs);
    }
}
