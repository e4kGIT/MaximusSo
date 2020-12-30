using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class UpdateMailModel
    {
        public long OrderNo { get; set; }
        public string MailTemplate { get; set; }
    }
}
