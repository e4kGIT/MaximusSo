using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class ReturnOrderModel
    {
        public bool Iscarr { get; set; }
        public bool isCarrline { get; set; }
        public bool IsCnf { get; set; }
        public string InvFlag { get; set; }
        public bool IsReorder { get; set; }
        public int IsDleted { get; set; }
        public int ReturnLineNo { get; set; }
        public int ReturnManPack { get; set; }
        public int ReOrdManPack { get; set; }
        public int ReOrderLineNo { get; set; }
        public bool IsSelect { get; set; }
        public bool IsReturn { get; set; }
        public long RtnOrderno { get; set; }
        public long ReOrderno { get; set; }
        public int OrderNo { get; set; }
        public int LineNo { get; set; }
        public bool HasCnfReorders { get; set; }
        public bool IsRetEdit { get; set; }
        public string OrderDate { get; set; }
        public string Employeename { get; set; }
        public double VAT { get; set; }
        public string StyleImage { get; set; }
        public double VatPercent { get; set; }
        public double Total { get; set; }
        public int EntQty { get; set; }
        public string FreeText1 { get; set; }
        public string DeliveryDate { get; set; }
        public int VatCode1 { get; set; }
        public int RepId { get; set; }
        public double Currency_Exchange_Rate { get; set; }
        public double Cost1 { get; set; }
        public int IssueUOM1 { get; set; }
        public int IssueQty1 { get; set; }
        public int StockingUOM1 { get; set; }
        public string SOPDetail4 { get; set; }
        public string SOPDetail5 { get; set; }
        public string OrgStyle { get; set; }
        public string StyleId { get; set; }
        public string Styleimg { get; set; }
        public string Description { get; set; }
        public string ColourId { get; set; }
        public string SizeId { get; set; }
        public int OrdQty { get; set; }
        public int OrgRetOrdQty { get; set; }
        public int OrgRetOrdQtyDel { get; set; }
        public int OrgOrdQty { get; set; }
        public int OtherReturnQty { get; set; }
        public double Price { get; set; }
        public string Reason { get; set; }
        public int ReasonCode { get; set; }
        public int PickingSlipNo { get; set; }
        public string CourierRef { get; set; }
        public string CustRef { get; set; }

        public int RtnQty { get; set; }
        public int OriginalLineNo { get; set; }
        public string AllocText { get; set; }
        public int Points { get; set; }
        public int TotalPoints { get; set; }
        public bool HideReorderBtn { get; set; }
        public string Emp { get; set; }
        public string Ucode { get; set; }

    }
}
