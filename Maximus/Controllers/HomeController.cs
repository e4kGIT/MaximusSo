using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maximus.Helpers;
using Maximus.Filter;

namespace Maximus.Controllers
{

    [CustomFilter]
    public class HomeController : Controller
    {
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        ControllerHelperMethods ctrlHelp = new ControllerHelperMethods();
        DataProcessing data = new DataProcessing();
        AllEnums enus = new AllEnums();
        //private int cardColumns = 0, cardRows = 0;
        #region Index
        [CustomFilter]
        public ActionResult Index()
        {
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(x => x.OrdQty) : 0 : 0;
            }
            else
            {
                Session["qty"] = 0;
            }
            return View();
        }
        #endregion

        #region getting all groups for checkboxlist
        public ActionResult GetAllGroups()
        {
            try
            {
                if (Session["UcodeStyle"] != null)
                {
                    List<UcodeModel> UcodeStyle = (List<UcodeModel>)Session["UcodeStyle"];
                    List<string> UcodeStyle1 = new List<string>();
                    UcodeStyle1 = UcodeStyle.Select(x => x.StyleId).ToList();
                    var groups = entity.tblfsk_style.Where(x => UcodeStyle1.Contains(x.StyleID)).Select(x => x.Product_Group.Value).ToList();
                    var result = entity.tblfsk_style_groups.Where(x => x.Description != "" && groups.Contains(x.GroupID)).ToList();
                    return PartialView("_getAllGroups", result);
                }
                else if (((List<string>)Session["SelectedTemplate"]).Count > 0)
                {
                    var result1 = (List<string>)Session["SelectedTemplate"];
                    var model = new List<int>();
                    foreach (var item in result1)
                    {
                        model.AddRange(data.GetProductGroup(item));
                    }
                    var result = entity.tblfsk_style_groups.Where(x => x.Description != "" && model.Contains(x.GroupID)).ToList();
                    return PartialView("_getAllGroups", result);
                }
                else
                {


                    var result = entity.tblfsk_style_groups.Where(x => x.Description != "").ToList();
                    return PartialView("_getAllGroups", result);
                }

            }
            catch (Exception e)
            {
                return null;
            }


        }
        #endregion

        #region Cardview
        [ValidateInput(false)]

        //public ActionResult CardViewPartial(string ColorId = "", string StyleID = "", string SizeId = "", decimal Price = 0, string Description = "", List<int> selectedItem = null, bool pages = false, bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        public ActionResult CardViewPartial(List<int> selectedItem = null, bool pages = false, string filterText = "", bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            string businessId = Session["BuisnessId"].ToString();
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                List<string> result = (List<string>)Session["SelectedTemplate"];
                foreach (var item in result)
                {
                    model.AddRange(data.GetStyleViewModel(item));
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                foreach (var data1 in model)
                {
                    data1.Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == data1.StyleID & d.isChargeable == 0 & d.CustID == businessId) |
                            entity.getallassemblies.Any(d => d.ParentStyleID == data1.StyleID & d.isChargeable == 0) ? 1 : 0;
                    data1.Description = entity.tblfsk_style.Where(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                }

                //if (ColorId != "" | SizeId != "" | StyleID != "" | Description != "" | BringDimension != false | (Session["GroupdeFilter"] != null))
                //{
                //    var sizeStyle = new List<string>(); var colorStyle = new List<string>(); var Styles = new List<string>(); var descStyle = new List<string>();
                //    if (selectedItem == null)
                //    {
                //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId).Select(x => x.StyleID).Distinct().ToList();
                //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId).Select(x => x.StyleID).Distinct().ToList();
                //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description)).Select(x => x.StyleID).Distinct().ToList();
                //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID).Select(x => x.StyleID).Distinct().ToList();
                //    }
                //    else
                //    {
                //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description) & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //    }
                //    if (model.Count < 1)
                //    {

                //        model = entity.styleby_freetextview.Select(x => new styleViewmodel
                //        {
                //            StyleID = x.StyleID,
                //            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                //            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                //            Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                //            ColourId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().ColourID :
                //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().ColourID,
                //            SizeId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().SizeID :
                //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().SizeID
                //        }).ToList();
                //    }

                //    if (Price != 0 && (SizeId != null & SizeId != "") && (ColorId != null & ColorId != "") && (StyleID != null & StyleID != ""))
                //    {
                //        model = model.Where(x => x.SizeId == SizeId & x.StyleID == StyleID & x.ColourId == ColorId).ToList();
                //    }
                //    else
                //    {
                //        if (StyleID != null && StyleID != "")
                //        {
                //            var model1 = model.Where(x => Styles.Contains(x.StyleID)).ToList();

                //            model = model1.Count() == 0 ? model.Where(x => x.StyleID.Contains(StyleID)).ToList() : model1;
                //        }
                //        if (ColorId != null && ColorId != "")
                //        {
                //            model = model.Any(x => colorStyle.Contains(x.StyleID)) ? model.Where(x => colorStyle.Contains(x.StyleID)).ToList() : model;
                //        }
                //        if (SizeId != null && SizeId != "")
                //        {
                //            model = model.Where(x => sizeStyle.Contains(x.StyleID)).ToList();
                //        }
                //        if (Description != null && Description != "")
                //        {
                //            var modelq = new List<styleViewmodel>();
                //            foreach (var dec in descStyle)
                //            {
                //                var svmq = new styleViewmodel();
                //                svmq = model.Any(x => x.StyleID.Contains(",")) ? model.Where(x => x.StyleID.Contains(dec)).FirstOrDefault() : model.Where(x => x.StyleID == dec).FirstOrDefault();
                //                if (svmq != null)
                //                {
                //                    if (svmq.StyleID != svm.StyleID)
                //                    {
                //                        modelq.Add(svmq);
                //                    }
                //                }
                //                svm = svmq;
                //            }
                //            model = modelq;
                //        }

                //        if (BringDimension | (bool)Session["GroupdeFilter"])
                //        {
                //            model = model.Any(x => x.isAllocated != null) ? model.Where(x => x.isAllocated).ToList() : new List<styleViewmodel>();
                //        }
                //    }
                //}
                //if (filterText != "")
                //{
                //    model = model.Where(x => x.)
                //}

                foreach (var data1 in model)
                {

                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                if (filterText != "")
                {
                    model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower())) ? model.Where(x => x.StyleID.ToLower().Contains(filterText.ToLower())).ToList() : null;
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                if (BringImages | Session["ImageFilter"] != null)
                {
                    if (BringImages | (bool)Session["ImageFilter"] != null)
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                if (selectedItem != null)
                {
                    model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.ProductGroup,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = x.Assembly,
                        ColourId = x.ColourId,
                        SizeId = x.SizeId,
                        isAllocated = x.isAllocated,
                        Dimensions = x.Dimensions,
                        Freetext = x.Freetext,
                        SeqNO = x.SeqNO,
                        OriginalStyleid = x.StyleID,
                        HasPreviousSize = x.HasPreviousSize,
                        Description = x.Description,
                        Caption = x.Caption,
                        Price = x.Price
                    }).ToList();
                }

            }
            else
            {
                try
                {
                    var freetext = Allocation.DIMALLOC.ToString();

                    string custId = Session["BuisnessId"].ToString();
                    int tempCount = ((List<UcodeModel>)Session["UcodeStyle"]) != null ? ((List<UcodeModel>)Session["UcodeStyle"]).Count : 0;
                    Session["Selected"] = selectedItem;
                    ViewBag.page = pages;
                    if (tempCount > 0)
                    {
                        string ucode = Session["SelectedUcode"].ToString();
                        List<string> freeTextLst = (List<string>)Session["UcFreeTxt"];
                        model = entity.ucodeby_freetextview.Where(x => freeTextLst.Contains(x.FreeText) & x.UCodeID == ucode).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                            Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0 & d.CustID == custId) |
                            entity.getallassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0) ? 1 : 0,
                            //Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                            isAllocated = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                            // Dimensions = x.FreeText
                            Dimensions = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                            SeqNO = x.SeqNo.Value,
                            Freetext = x.FreeText,
                            OriginalStyleid = x.StyleID
                        }).ToList();
                    }
                    else
                    {
                        model = new List<styleViewmodel>();
                    }
                    if (selectedItem != null)
                    {
                        model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.ProductGroup,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = x.Assembly,
                            ColourId = x.ColourId,
                            SizeId = x.SizeId,
                            isAllocated = x.isAllocated,
                            Dimensions = x.Dimensions,
                            Freetext = x.Freetext,
                            SeqNO = x.SeqNO,
                            OriginalStyleid = x.StyleID,
                            HasPreviousSize = x.HasPreviousSize,
                            Description = x.Description,
                            Caption = x.Caption,
                            Price = x.Price
                        }).ToList();
                    }

                    //if (ColorId != "" | SizeId != "" | StyleID != "" | Description != "" | BringDimension != false | (Session["GroupdeFilter"] != null))
                    //{
                    //    var sizeStyle = new List<string>(); var colorStyle = new List<string>(); var Styles = new List<string>(); var descStyle = new List<string>();
                    //    if (selectedItem == null)
                    //    {
                    //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId).Select(x => x.StyleID).Distinct().ToList();
                    //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId).Select(x => x.StyleID).Distinct().ToList();
                    //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description)).Select(x => x.StyleID).Distinct().ToList();
                    //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID).Select(x => x.StyleID).Distinct().ToList();
                    //    }
                    //    else
                    //    {
                    //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description) & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //    }
                    //    if (model.Count < 1)
                    //    {

                    //        model = entity.styleby_freetextview.Select(x => new styleViewmodel
                    //        {
                    //            StyleID = x.StyleID,
                    //            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                    //            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                    //            Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                    //            ColourId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().ColourID :
                    //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().ColourID,
                    //            SizeId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().SizeID :
                    //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().SizeID
                    //        }).ToList();
                    //    }

                    //    if (Price != 0 && (SizeId != null & SizeId != "") && (ColorId != null & ColorId != "") && (StyleID != null & StyleID != ""))
                    //    {
                    //        model = model.Where(x => x.SizeId == SizeId & x.StyleID == StyleID & x.ColourId == ColorId).ToList();
                    //    }
                    //    else
                    //    {
                    //        if (StyleID != null && StyleID != "")
                    //        {
                    //            var model1 = model.Where(x => Styles.Contains(x.StyleID)).ToList();

                    //            model = model1.Count() == 0 ? model.Where(x => x.StyleID.Contains(StyleID)).ToList() : model1;
                    //        }
                    //        if (ColorId != null && ColorId != "")
                    //        {
                    //            model = model.Any(x => colorStyle.Contains(x.StyleID)) ? model.Where(x => colorStyle.Contains(x.StyleID)).ToList() : model;
                    //        }
                    //        if (SizeId != null && SizeId != "")
                    //        {
                    //            model = model.Where(x => sizeStyle.Contains(x.StyleID)).ToList();
                    //        }
                    //        if (Description != null && Description != "")
                    //        {
                    //            var modelq = new List<styleViewmodel>();
                    //            foreach (var dec in descStyle)
                    //            {
                    //                var svmq = new styleViewmodel();
                    //                svmq = model.Any(x => x.StyleID.Contains(",")) ? model.Where(x => x.StyleID.Contains(dec)).FirstOrDefault() : model.Where(x => x.StyleID == dec).FirstOrDefault();
                    //                if (svmq != null)
                    //                {
                    //                    if (svmq.StyleID != svm.StyleID)
                    //                    {
                    //                        modelq.Add(svmq);
                    //                    }
                    //                }
                    //                svm = svmq;
                    //            }
                    //            model = modelq;
                    //        }

                    //        if (BringDimension |  Session["GroupdeFilter"]!=null)
                    //        {
                    //            if ((bool)Session["GroupdeFilter"] | BringDimension)
                    //            {
                    //                model = model.Any(x => x.isAllocated != null) ? model.Where(x => x.isAllocated).ToList() : new List<styleViewmodel>();
                    //            }
                    //        }
                    //    }
                    //}
                    foreach (var data1 in model)
                    {
                        //var s = entity.styleby_freetextview.Where(x => x.FreeText == data1.Freetext).ToList();
                        data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : data.GetFitAllocString(data1.Freetext);
                    }
                    foreach (var data1 in model)
                    {
                        data1.Description = entity.tblfsk_style.Where(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                        if (!data1.StyleID.Contains(","))
                        {
                            data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                        }
                        else
                        {
                            data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                        }
                        if (data1.StyleImage.Contains(":"))
                        {

                            var data = data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1);
                            if (System.IO.File.Exists(appPath + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1)) != true)
                            {
                                data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                            }
                            else
                            {
                                data1.StyleImage = Url.Content("~/" + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1));
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                            {
                                data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                            }
                            else
                            {
                                data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                            }
                        }

                    }
                    if (filterText != "")
                    {
                        model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())) ? model.Where(x => x.StyleID.ToLower().Trim().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())).ToList() : null;
                    }
                    model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                    if (BringImages | (bool)Session["ImageFilter"])
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                catch (Exception e)
                {

                }
            }
            return PartialView("_CardViewPartial", model.Distinct());
        }
        #endregion

        #region assembly

        public ActionResult AssemblyInfo(string styleId)
        {
            Session["assemList"] = new List<string>();
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            try
            {
                var custId = Session["BuisnessId"].ToString();
                var result = entity.getcustassemblies.Any(x => x.ParentStyleID == styleId & x.CustID == custId) ? entity.getcustassemblies.Where(x => x.ParentStyleID == styleId & x.CustID == custId).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList() : entity.getallassemblies.Where(x => x.ParentStyleID == styleId & x.isChargeable == 0).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList();
                foreach (var data in result)
                {
                    data.StyleImage = entity.tblfsk_style.Where(d => d.StyleID == data.StyleID).FirstOrDefault().StyleImage;
                    if (System.IO.File.Exists(appPath + data.StyleImage) != true)
                    {
                        data.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data.StyleImage = Url.Content("~/" + data.StyleImage);
                    }
                }
                return PartialView("_AssemblyInfo", result);
            }
            catch (Exception e)
            {

            }
            return null;
        }

        #endregion

        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "")
        {
            try
            {
                string businessId = Session["BuisnessId"].ToString();
                decimal result = entity.tblfsk_style_sizes_prices.Any(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId) ? (decimal)entity.tblfsk_style_sizes_prices.Where(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == businessId).FirstOrDefault().Price.Value : 0;
                result = result == 0 ? entity.tblfsk_style_sizes_prices.Any(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL") ? (decimal)entity.tblfsk_style_sizes_prices.Where(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim() & x.BusinessId == "ALL" && x.PriceID == 2).FirstOrDefault().Price.Value : result : result;
                if (result != 0)
                {
                    return System.Math.Round(result, 2);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            { }
            return 0;
        }
        #endregion

        #region GetAllColors
        public List<string> getAllcolours(string style)
        {
            List<string> selectedListqqq = new List<string>();
            selectedListqqq = entity.getstylesviews.Where(x => x.StyleID == style).Select(x => x.ColourID).Distinct().ToList();
            return (selectedListqqq);
        }

        #endregion

        #region getdata based on styleId Dropdown Box

        #region get Description
        public JsonResult DrpResultModel(string styleId)
        {
            var result = new DrpResultModel();
            var selUcode = Session["SelectedUcode"].ToString();
            result.Description = entity.tblfsk_style.Where(x => x.StyleID == styleId).First().Description;
            if (!entity.tblfsk_style_colour_size_obsolete.Any(x => x.StyleID == styleId))
            {
                result.ColorList = (List<string>)entity.tblaccemp_ucodes.Where(s => s.StyleID == styleId && s.UCodeID == selUcode).OrderBy(s => s.ColourID).Select(s => s.ColourID).Distinct().ToList();
                result.SizeList = (List<string>)entity.tblfsk_style_sizes.Where(s => s.StyleID == styleId).Distinct().OrderBy(s => s.SeqNo).Select(s => s.SizeID).ToList();
                result.Price = result.SizeList.Count > 1 ? 0 : GetPrice(styleId, result.SizeList[0]);
            }
            else
            {
                result.ColorList = (List<string>)entity.tblaccemp_ucodes.Where(s => s.StyleID == styleId && s.UCodeID == selUcode).OrderBy(s => s.ColourID).Select(s => s.ColourID).Distinct().ToList();
                result.SizeList = (List<string>)entity.tblfsk_style_colour_size_obsolete.Where(s => s.StyleID == styleId && s.Obsolete_Class == 0).Distinct().Select(s => s.SizeID).ToList();
                var data = entity.tblfsk_style_sizes.Where(x => x.StyleID == styleId).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
                if (result.SizeList.Count != data.Count)
                {
                    List<string> datar = (data.Except(result.SizeList)).ToList();
                    foreach (string s in datar)
                    {
                        data.Remove(s);
                    }
                    result.SizeList = data;
                }
                else
                {
                    result.SizeList = data;
                }
                result.Price = result.SizeList.Count > 1 ? GetPrice(styleId, result.SizeList[0]) : 0;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region GetModel
        public ActionResult GetFilter()
        {
            List<int> selectedList = (List<int>)Session["Selected"];
            var data = new FilterModel();
            List<UcodeModel> UcodeStyle = (List<UcodeModel>)Session["UcodeStyle"];
            List<string> UcodeStyle1 = new List<string>();
            UcodeStyle1 = UcodeStyle != null ? UcodeStyle.Select(x => x.StyleId).ToList() : new List<string>();
            List<int> groups = new List<int>();
            if (UcodeStyle != null)
            {
                groups = entity.tblfsk_style.Where(x => UcodeStyle1.Contains(x.StyleID)).Select(x => x.Product_Group.Value).ToList();
            }
            if (selectedList == null && (groups == null | groups.Count == 0))
            {
                data.ColorIdList = entity.getstylesviews.Where(x => x.Description != "").Select(x => x.ColourID).Distinct().ToList();
                data.SizeIdList = entity.getstylesviews.Where(x => x.Description != "").Select(x => x.SizeID).Distinct().ToList();
                data.StyleIDList = entity.getstylesviews.Where(x => x.Description != "").Select(x => x.StyleID).Distinct().ToList();
            }
            else
            {
                if (selectedList != null && (groups == null | groups.Count == 0))
                {
                    data.ColorIdList = entity.getstylesviews.Where(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = entity.getstylesviews.Where(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = entity.getstylesviews.Where(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.StyleID).Distinct().ToList();
                }
                else if (selectedList == null && (groups != null | groups.Count > 0))
                {
                    data.ColorIdList = entity.getstylesviews.Where(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = entity.getstylesviews.Where(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = entity.getstylesviews.Where(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.StyleID).Distinct().ToList();
                }
                else
                {
                    data.ColorIdList = entity.getstylesviews.Where(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = entity.getstylesviews.Where(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = entity.getstylesviews.Where(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.StyleID).Distinct().ToList();

                }

            }
            return PartialView("_FilterModel", data);
        }

        #endregion

        #region GetDimAlloc
        public ActionResult GetDimAlloc(string freeText)
        {
            ViewBag.page = false;
            //freeText = "ADC BOOT";
            var sv1 = new styleViewmodel();
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var result = new List<styleViewmodel>();
            var freeTxtType = Allocation.DIMALLOC.ToString();
            List<string> freeTxtLst2 = new List<string>();
            var freeTxtLst = entity.ucodeby_freetextview.Where(x => x.DimFreeText == freeText).Select(x => x.FreeText).Distinct().ToList();
            var styleLst = new List<string>();
            if (freeTxtLst.Count < 2)
            {
                styleLst.AddRange(entity.tblfsk_style_freetext.Where(x => x.FreeText == freeText && x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList());
            }
            else
            {
                foreach (var fretxt in freeTxtLst)
                {
                    styleLst.Add(data.getStyleFromFretxt(fretxt));
                }
            }

            if (Session["onDemand"] != null && (bool)Session["onDemand"] == true)
            {
                var result1 = entity.tblfsk_style_freetext.Where(x => x.FreeText == freeText & x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList();
                //var s = (bool)Session["onDemand"];
                return PartialView("_DimAllocDemandPartial", result1);
            }
            else
            {
                try
                {
                    foreach (var styles in styleLst)
                    {
                        styleViewmodel svm = new styleViewmodel();
                        svm = data.GetDimallocStyles(styles);
                        if (styles.Contains(","))
                        {
                            svm.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), styles);
                        }
                        else
                        {
                            svm.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), styles.Split(',')[0]);
                        }
                        if (svm != null)
                        {
                            result.Add(svm);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                foreach (var data1 in result)
                {
                    //data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : data.GetFitAllocString(data1.Freetext);
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                return PartialView("_DimAllocPartial", result);
            }
        }
        #endregion

        #region  getCard
        public ActionResult GetCard(string StyleID, string Orgstyle)
        {
            //StyleID = "TSB LJ1/L";
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string ucode = Session["SelectedUcode"].ToString();

            var hasFit = entity.tblfsk_style_freetext.Where(x => x.StyleId == StyleID).Any(x => x.FreeTextType == "FITALLOC") ? entity.tblfsk_style_freetext.Where(x => x.StyleId == StyleID & x.FreeTextType == "FITALLOC").First().FreeText : "";
            List<styleViewmodel> model = new List<styleViewmodel>();
            if (hasFit == "")
            {
                model.Add(entity.ucodeby_freetextview.Where(x => x.StyleID == StyleID).Select(x => new styleViewmodel
                {
                    StyleID = x.StyleID,
                    ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                    StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                    Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                    OriginalStyleid = Orgstyle
                }).FirstOrDefault());
                foreach (var data1 in model)
                {
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {

                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);

                    }
                    if (data1.StyleImage.Contains(":"))
                    {

                        var data = data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1);
                        if (System.IO.File.Exists(appPath + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1)) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1));
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                        }
                    }
                }
            }
            else
            {
                string style = "";
                var curStyle = entity.styleby_freetextview.Where(x => x.FreeText == hasFit).Select(x => x.StyleID).FirstOrDefault();

                var s11 = entity.styleby_freetextview.Where(x => x.FreeText == hasFit).FirstOrDefault();

                var S1 = entity.ucodeby_freetextview.Where(x => x.StyleID == StyleID).Select(x => new styleViewmodel
                {
                    StyleID = curStyle,
                    ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                    StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                    Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                    OriginalStyleid = Orgstyle
                }).FirstOrDefault();
                if (S1 != null)
                {
                    model.Add(new styleViewmodel
                    {
                        StyleID = curStyle,
                        ProductGroup = S1.ProductGroup,
                        StyleImage = S1.StyleImage,
                        Assembly = S1.Assembly,
                        OriginalStyleid = Orgstyle
                    });
                }
                else
                {
                    model.Add(new styleViewmodel
                    {
                        StyleID = curStyle,
                        ProductGroup = s11.Product_Group != null ? s11.Product_Group.Value : 0,
                        StyleImage = s11.StyleImage == "" | s11.StyleImage == null ? "/StyleImages/notfound.png" : s11.StyleImage,
                        Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == s11.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == s11.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                        OriginalStyleid = Orgstyle
                    });

                }
                foreach (var data1 in model)
                {
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.OriginalStyleid);
                    }
                    else
                    {

                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);

                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
            }
            return PartialView("_StyleByCardPop", model);
        }

        #endregion

        #region ondemandCards
        public ActionResult GetcardOnDemand(string StyleID)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string ucode = Session["SelectedUcode"].ToString();
            List<styleViewmodel> model = new List<styleViewmodel>();
            model.Add(entity.ucodeby_freetextview.Where(x => x.StyleID == StyleID).Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0
            }).FirstOrDefault());
            foreach (var data1 in model)
            {
                if (!data1.StyleID.Contains(","))
                {
                    data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                }
                else
                {

                    data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);

                }
                if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                {
                    data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                }
                else
                {
                    data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                }
            }
            return PartialView("Model/_CardviewByStyle", model);
        }
        #endregion

        #region GetSelectedColourSizes
        public JsonResult GetSelectedColourSizes(string Style, string Color)
        {
            //if (Style.Contains(','))
            //{
            //  var styleArr=  Style.Split(',');
            //    var style1 = styleArr[0];
            //    var result = entity.tblfsk_style_colour_size_obsolete.Where(x => x.StyleID == style1 & x.ColourID == Color && (x.Obsolete_Class == 4)).Distinct().Select(x => x.SizeID).ToList();
            //    var data = entity.tblfsk_style_sizes.Where(x => x.StyleID == style1).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
            //    foreach (var res in result)
            //    {
            //        data.Remove(res);
            //    }
            //    return Json(data, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            var result = entity.tblfsk_style_colour_size_obsolete.Where(x => x.StyleID == Style & x.ColourID == Color && (x.Obsolete_Class == 4)).Distinct().Select(x => x.SizeID).ToList();
            var data1 = entity.tblfsk_style_sizes.Where(x => x.StyleID == Style).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
            foreach (var res in result)
            {
                data1.Remove(res);
            }
            return Json(data1, JsonRequestBehavior.AllowGet);
            //}
        }
        #endregion

        #region AddItemsToCart
        public JsonResult AddToCart(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "")
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string result = "";
            var salesOrderLines = new List<SalesOrderLineViewModel>();
            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            long lineNo = 0;
            if (salesOrderHeader.Count != 0)
            {
                salesOrderLines = salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine != null ?
                  salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList() : new List<SalesOrderLineViewModel>();
            }
            else
            {
                var address1 = data.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                salesOrderHeader.Add(new SalesOrderHeaderViewModel
                {
                    DelDesc = addresArr.Count() > 0 ? addresArr[0] : "",
                    DelAddress1 = addresArr.Count() > 0 ? addresArr[1] : "",
                    DelAddress2 = addresArr.Count() > 0 ? addresArr[2] : "",
                    DelAddress3 = addresArr.Count() > 0 ? addresArr[3] : "",
                    DelTown = addresArr.Count() > 0 ? addresArr[4] : "",
                    DelCity = addresArr.Count() > 0 ? addresArr[5] : "",
                    DelPostCode = addresArr.Count() > 0 ? addresArr[6] : "",
                    DelCountry = addresArr.Count() > 0 ? addresArr[7] : "",
                    EmployeeName = Session["EmpName"].ToString(),
                    EmployeeID = Session["SelectedEmp"].ToString(),
                    CustRef = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                    Comments = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
                });
            }
            if (salesOrderLines.Count > 0)
            {
                lineNo = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;
            }
            else
            {
                lineNo = salesOrderLines.Any(x => x.EmployeeId == Session["SelectedEmp"].ToString()) ? salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).Count() + 1 : 1;
            }

            var chargableAssembs = new List<SalesOrderLineViewModel>();
            var OptionalAssembs = new List<SalesOrderLineViewModel>();
            if (description != "" && price != "" && size != "" && color != "" && qty != "")
            {
                try
                {
                    salesOrderLines.Add(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDecimal(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString(), StyleImage = entity.ucodeby_freetextview.Where(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage, orgStyleId = orgStyl });
                }
                catch (Exception e)
                {
                    var EmployeeId = Session["SelectedEmp"].ToString();
                    var EmployeeName = Session["EmpName"].ToString();
                }

                chargableAssembs = ctrlHelp.GetChargableAssembly(style, lineNo, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), Session["BuisnessId"].ToString());
                if (chargableAssembs.Count > 0)
                {
                    salesOrderLines.AddRange(chargableAssembs);
                }
                OptionalAssembs = new List<SalesOrderLineViewModel>();

                if ((List<string>)Session["assemList"] != null)
                {
                    if (((List<string>)Session["assemList"]).Count > 0)
                    {
                        OptionalAssembs = ctrlHelp.GetOptionalAssembly((List<string>)Session["assemList"], style, lineNo, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), salesOrderLines.Count, Session["BuisnessId"].ToString());
                    }
                }
                if (OptionalAssembs.Count > 0)
                {
                    salesOrderLines.AddRange(OptionalAssembs);
                }
                foreach (var data in salesOrderLines)
                {

                    if (System.IO.File.Exists(appPath + data.StyleImage) != true)
                    {
                        data.StyleImage = Url.Content("~/StyleImages/notfound.png");

                    }
                    else
                    {
                        data.StyleImage = Url.Content("~/" + data.StyleImage);

                    }
                }
                salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine = salesOrderLines;
                Session["SalesOrderHeader"] = salesOrderHeader;
                Session["assemList"] = null;
                Session["SalesOrderLines"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).ToList();
                Session["qty"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString() && x.OriginalLineNo==null).Sum(x => x.OrdQty);
                result = "<button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AddAssemblyList
        public string AddAssemblyList(string style = "")
        {
            if (style != "")
            {
                if (Session["assemList"] != null)
                {
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Add(style);
                    Session["assemList"] = assemList;
                }
                else
                {
                    Session["assemList"] = new List<string>();
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Add(style);
                    Session["assemList"] = assemList;
                }
                return "1";
            }
            return "";
        }
        #endregion

        #region remove assembly from list
        public string RemoveAssemblyList(string style = "")
        {
            if (style != "" & ((List<string>)Session["assemList"]).Count != 0)
            {
                if (Session["assemList"] != null)
                {
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Remove(style);
                    Session["assemList"] = assemList;
                }
                return "1";
            }
            return "";
        }
        #endregion

        #region GetEntitlement
        public JsonResult GetEntitlement(string StyleId = "", string ColorId = "", string orgStyl = "")
        {
            EntitlementModel em = new EntitlementModel();
            //if(orgStyl.Contains(','))
            //{

            string Ucodes = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();
            em.EmpId = "<b>" + Session["SelectedEmp"].ToString() + "</b> to style: <b>" + StyleId + "</b>";
            if (ColorId != "" && orgStyl != "")
            {
                string result = "";
                var entitlement = entity.tblaccemp_ucodes.Any(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes.Where(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                entitlement = entitlement == 0 ? entity.tblaccemp_ucodes.Where(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : entitlement;
                string PreviousOrder = data.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), orgStyl);
                PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
                result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;

                em.Result = result;

                return Json(em);
            }
            em.Result = "<table class=\"table\"><tr><td>Entitlement:  0</td></tr><tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>";
            return Json(em);
            //}
            //else
            //{
            //    string Ucodes = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();
            //    em.EmpId = Session["SelectedEmp"].ToString() + " orgStyl: " + orgStyl;
            //    if (ColorId != "" && orgStyl != "")
            //    {
            //        string result = "";
            //        var entitlement = entity.tblaccemp_ucodes.Any(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes.Where(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
            //        string PreviousOrder = data.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), orgStyl);
            //        PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
            //        result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;

            //        em.Result = result;

            //        return Json(em);
            //    }
            //    em.Result = "<table class=\"table\"><tr><td>Entitlement:  0</td></tr><tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>";
            //    return Json(em);
            //}

        }
        #endregion

        #region GetBtnStatus
        [HttpPost]
        public string GetBtnStatus(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "")
        {
            string result = "";
            string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
            string busId = "";
            string empId = "";
            var issuedDiff = 0;
            var salesOrderLines = ((List<SalesOrderLineViewModel>)Session["SalesOrderLines"]).Where(X => X.orgStyleId != null).ToList();
            var onCartLst = salesOrderLines.Where(x => x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList();
            var onCartVal = onCartLst.Sum(x => x.OrdQty);
            if (ordQty != "" & color != "" & style != "" & qty != "")
            {
                int difference = 0;
                int oQty = Convert.ToInt32(ordQty);
                var entitlement = entity.tblaccemp_ucodes.Any(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes.Where(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                var issuedLst = entity.tblaccemp_stockcard.Any(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? entity.tblaccemp_stockcard.Where(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                var issued = 0;
                if (issuedLst.Count > 0)
                {
                    foreach (var data in issuedLst)
                    {
                        issued = issued + data.Invqty + data.Pickqty + data.SOqty;
                    }
                }
                else
                {
                    issued = 0;
                }
                if (entitlement != 0)
                {
                    issuedDiff = entitlement.Value - issued;
                }
                if (onCartVal != 0)
                {
                    issuedDiff = (int)issuedDiff - (int)onCartVal;
                }

                if (issuedDiff > 0)
                {
                    result = Convert.ToInt32(qty) <= issuedDiff ? "enabled" : "";
                }
            }
            return result;
        }
        #endregion

        #region Getlast Seleceted Size based on style
        public JsonResult GetLastSize(string style = "")
        {
            var result = default(object);
            string businessId = Session["BuisnessId"].ToString();
            if (style != "")
            {
                var prevHistory = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), style);

                if (prevHistory.Size != "")
                {
                    prevHistory.price = entity.tblfsk_style_sizes_prices.Any(x => x.StyleID == style && x.SizeID == prevHistory.Size && x.PriceID == 2) ? entity.tblfsk_style_sizes_prices.Where(x => x.StyleID == style && x.SizeID == prevHistory.Size && x.PriceID == 2 && x.BusinessId == businessId).First().Price.ToString() : "";
                }
                result = prevHistory;
                return Json(result);
            }
            return Json(result);
        }
        #endregion

        #region Cardviewnew
        public ActionResult CardViewPartialnew(List<int> selectedItem = null, bool pages = false, string filterText = "", bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            string businessId = Session["BuisnessId"].ToString();
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                List<string> result = (List<string>)Session["SelectedTemplate"];
                foreach (var item in result)
                {
                    model.AddRange(data.GetStyleViewModel(item));
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                foreach (var data1 in model)
                {
                    data1.Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == data1.StyleID & d.isChargeable == 0 & d.CustID == businessId) |
                            entity.getallassemblies.Any(d => d.ParentStyleID == data1.StyleID & d.isChargeable == 0) ? 1 : 0;
                    data1.Description = entity.tblfsk_style.Where(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                }

                //if (ColorId != "" | SizeId != "" | StyleID != "" | Description != "" | BringDimension != false | (Session["GroupdeFilter"] != null))
                //{
                //    var sizeStyle = new List<string>(); var colorStyle = new List<string>(); var Styles = new List<string>(); var descStyle = new List<string>();
                //    if (selectedItem == null)
                //    {
                //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId).Select(x => x.StyleID).Distinct().ToList();
                //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId).Select(x => x.StyleID).Distinct().ToList();
                //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description)).Select(x => x.StyleID).Distinct().ToList();
                //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID).Select(x => x.StyleID).Distinct().ToList();
                //    }
                //    else
                //    {
                //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description) & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                //    }
                //    if (model.Count < 1)
                //    {

                //        model = entity.styleby_freetextview.Select(x => new styleViewmodel
                //        {
                //            StyleID = x.StyleID,
                //            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                //            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                //            Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                //            ColourId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().ColourID :
                //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().ColourID,
                //            SizeId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().SizeID :
                //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().SizeID
                //        }).ToList();
                //    }

                //    if (Price != 0 && (SizeId != null & SizeId != "") && (ColorId != null & ColorId != "") && (StyleID != null & StyleID != ""))
                //    {
                //        model = model.Where(x => x.SizeId == SizeId & x.StyleID == StyleID & x.ColourId == ColorId).ToList();
                //    }
                //    else
                //    {
                //        if (StyleID != null && StyleID != "")
                //        {
                //            var model1 = model.Where(x => Styles.Contains(x.StyleID)).ToList();

                //            model = model1.Count() == 0 ? model.Where(x => x.StyleID.Contains(StyleID)).ToList() : model1;
                //        }
                //        if (ColorId != null && ColorId != "")
                //        {
                //            model = model.Any(x => colorStyle.Contains(x.StyleID)) ? model.Where(x => colorStyle.Contains(x.StyleID)).ToList() : model;
                //        }
                //        if (SizeId != null && SizeId != "")
                //        {
                //            model = model.Where(x => sizeStyle.Contains(x.StyleID)).ToList();
                //        }
                //        if (Description != null && Description != "")
                //        {
                //            var modelq = new List<styleViewmodel>();
                //            foreach (var dec in descStyle)
                //            {
                //                var svmq = new styleViewmodel();
                //                svmq = model.Any(x => x.StyleID.Contains(",")) ? model.Where(x => x.StyleID.Contains(dec)).FirstOrDefault() : model.Where(x => x.StyleID == dec).FirstOrDefault();
                //                if (svmq != null)
                //                {
                //                    if (svmq.StyleID != svm.StyleID)
                //                    {
                //                        modelq.Add(svmq);
                //                    }
                //                }
                //                svm = svmq;
                //            }
                //            model = modelq;
                //        }

                //        if (BringDimension | (bool)Session["GroupdeFilter"])
                //        {
                //            model = model.Any(x => x.isAllocated != null) ? model.Where(x => x.isAllocated).ToList() : new List<styleViewmodel>();
                //        }
                //    }
                //}
                //if (filterText != "")
                //{
                //    model = model.Where(x => x.)
                //}

                foreach (var data1 in model)
                {

                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                if (filterText != "")
                {
                    model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower())) ? model.Where(x => x.StyleID.ToLower().Contains(filterText.ToLower())).ToList() : null;
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                if (BringImages | Session["ImageFilter"] != null)
                {
                    if (BringImages | (bool)Session["ImageFilter"] != null)
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                if (selectedItem != null)
                {
                    model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.ProductGroup,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = x.Assembly,
                        ColourId = x.ColourId,
                        SizeId = x.SizeId,
                        isAllocated = x.isAllocated,
                        Dimensions = x.Dimensions,
                        Freetext = x.Freetext,
                        SeqNO = x.SeqNO,
                        OriginalStyleid = x.StyleID,
                        HasPreviousSize = x.HasPreviousSize,
                        Description = x.Description,
                        Caption = x.Caption,
                        Price = x.Price
                    }).ToList();
                }

            }
            else
            {
                try
                {
                    var freetext = Allocation.DIMALLOC.ToString();

                    string custId = Session["BuisnessId"].ToString();
                    int tempCount = ((List<UcodeModel>)Session["UcodeStyle"]) != null ? ((List<UcodeModel>)Session["UcodeStyle"]).Count : 0;
                    Session["Selected"] = selectedItem;
                    ViewBag.page = pages;
                    if (tempCount > 0)
                    {
                        string ucode = Session["SelectedUcode"].ToString();
                        List<string> freeTextLst = (List<string>)Session["UcFreeTxt"];
                        model = entity.ucodeby_freetextview.Where(x => freeTextLst.Contains(x.FreeText) & x.UCodeID == ucode).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                            Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0 & d.CustID == custId) |
                            entity.getallassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0) ? 1 : 0,
                            //Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                            isAllocated = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                            // Dimensions = x.FreeText
                            Dimensions = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                            SeqNO = x.SeqNo.Value,
                            Freetext = x.FreeText,
                            OriginalStyleid = x.StyleID
                        }).ToList();
                    }
                    else
                    {
                        model = new List<styleViewmodel>();
                    }
                    if (selectedItem != null)
                    {
                        model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.ProductGroup,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = x.Assembly,
                            ColourId = x.ColourId,
                            SizeId = x.SizeId,
                            isAllocated = x.isAllocated,
                            Dimensions = x.Dimensions,
                            Freetext = x.Freetext,
                            SeqNO = x.SeqNO,
                            OriginalStyleid = x.StyleID,
                            HasPreviousSize = x.HasPreviousSize,
                            Description = x.Description,
                            Caption = x.Caption,
                            Price = x.Price
                        }).ToList();
                    }

                    //if (ColorId != "" | SizeId != "" | StyleID != "" | Description != "" | BringDimension != false | (Session["GroupdeFilter"] != null))
                    //{
                    //    var sizeStyle = new List<string>(); var colorStyle = new List<string>(); var Styles = new List<string>(); var descStyle = new List<string>();
                    //    if (selectedItem == null)
                    //    {
                    //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId).Select(x => x.StyleID).Distinct().ToList();
                    //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId).Select(x => x.StyleID).Distinct().ToList();
                    //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description)).Select(x => x.StyleID).Distinct().ToList();
                    //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID).Select(x => x.StyleID).Distinct().ToList();
                    //    }
                    //    else
                    //    {
                    //        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description) & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    //    }
                    //    if (model.Count < 1)
                    //    {

                    //        model = entity.styleby_freetextview.Select(x => new styleViewmodel
                    //        {
                    //            StyleID = x.StyleID,
                    //            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                    //            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                    //            Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                    //            ColourId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().ColourID :
                    //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().ColourID,
                    //            SizeId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().SizeID :
                    //            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().SizeID
                    //        }).ToList();
                    //    }

                    //    if (Price != 0 && (SizeId != null & SizeId != "") && (ColorId != null & ColorId != "") && (StyleID != null & StyleID != ""))
                    //    {
                    //        model = model.Where(x => x.SizeId == SizeId & x.StyleID == StyleID & x.ColourId == ColorId).ToList();
                    //    }
                    //    else
                    //    {
                    //        if (StyleID != null && StyleID != "")
                    //        {
                    //            var model1 = model.Where(x => Styles.Contains(x.StyleID)).ToList();

                    //            model = model1.Count() == 0 ? model.Where(x => x.StyleID.Contains(StyleID)).ToList() : model1;
                    //        }
                    //        if (ColorId != null && ColorId != "")
                    //        {
                    //            model = model.Any(x => colorStyle.Contains(x.StyleID)) ? model.Where(x => colorStyle.Contains(x.StyleID)).ToList() : model;
                    //        }
                    //        if (SizeId != null && SizeId != "")
                    //        {
                    //            model = model.Where(x => sizeStyle.Contains(x.StyleID)).ToList();
                    //        }
                    //        if (Description != null && Description != "")
                    //        {
                    //            var modelq = new List<styleViewmodel>();
                    //            foreach (var dec in descStyle)
                    //            {
                    //                var svmq = new styleViewmodel();
                    //                svmq = model.Any(x => x.StyleID.Contains(",")) ? model.Where(x => x.StyleID.Contains(dec)).FirstOrDefault() : model.Where(x => x.StyleID == dec).FirstOrDefault();
                    //                if (svmq != null)
                    //                {
                    //                    if (svmq.StyleID != svm.StyleID)
                    //                    {
                    //                        modelq.Add(svmq);
                    //                    }
                    //                }
                    //                svm = svmq;
                    //            }
                    //            model = modelq;
                    //        }

                    //        if (BringDimension |  Session["GroupdeFilter"]!=null)
                    //        {
                    //            if ((bool)Session["GroupdeFilter"] | BringDimension)
                    //            {
                    //                model = model.Any(x => x.isAllocated != null) ? model.Where(x => x.isAllocated).ToList() : new List<styleViewmodel>();
                    //            }
                    //        }
                    //    }
                    //}
                    foreach (var data1 in model)
                    {
                        //var s = entity.styleby_freetextview.Where(x => x.FreeText == data1.Freetext).ToList();
                        data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : data.GetFitAllocString(data1.Freetext);
                    }
                    foreach (var data1 in model)
                    {
                        data1.Description = entity.tblfsk_style.Where(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                        if (!data1.StyleID.Contains(","))
                        {
                            data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                        }
                        else
                        {
                            data1.HasPreviousSize = data.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                        }
                        if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                        }
                    }
                    if (filterText != "")
                    {
                        model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())) ? model.Where(x => x.StyleID.ToLower().Trim().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())).ToList() : null;
                    }
                    model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                    if (BringImages | (bool)Session["ImageFilter"])
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                catch (Exception e)
                {

                }
            }
            return PartialView("_CardViewPartial", model.Distinct());
        }
        #endregion

        #region  GetClrImg
        public string GetClrImg(string style = "")
        {
            string result = "";
            if (style != "")
            {
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                var stylClr = style.Split('-');
                var styl = stylClr[0];
                var clr = stylClr[1];
                try
                {
                    var dat = entity.tblfsk_style_colour.Any(x => x.StyleID.ToLower() == styl && x.ColourID.Contains(clr)) ? entity.tblfsk_style_colour.Where(x => x.StyleID.ToLower() == styl && x.ColourID.Contains(clr)).First().StyleImage : "";

                    if (System.IO.File.Exists(appPath + dat) != true)
                    {
                        dat = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        dat = Url.Content("~/" + dat);
                    }

                    result = "<img src='" + dat + "' height='230' width='200' onclick=\"Getimage('" + dat + "')\" />";
                }
                catch (Exception e)
                {

                }
            }
            return result;
        }
        #endregion

    }
}