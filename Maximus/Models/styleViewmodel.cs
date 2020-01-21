using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    #region styleViewmodel
    public class styleViewmodel
    {

        public string StyleID { get; set; }
        public string Description { get; set; }
        public string StyleImage { get; set; }
        public string ColourId { get; set; }
        public string SizeId { get; set; }
        public int ProductGroup { get; set; }
        public decimal Price { get; set; }
        public int Assembly { get; set; }
        public string Dimensions { get; set; }
        public bool isAllocated { get; set; }
        public string Caption { get; set; }
        public int SeqNO { get; set; }
        public PreviousQty HasPreviousSize { get; set; }
        public string OriginalStyleid { get; set; }
        public string Freetext { get; set; }
        public string Entitlement { get; set; }
        public string Reqdata { get; set; }
    }
    #endregion
}
    