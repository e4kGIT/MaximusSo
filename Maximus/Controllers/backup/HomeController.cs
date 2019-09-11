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

namespace Maximus.Controllers
{
    public class HomeController : Controller
    {
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        ControllerHelperMethods ctrlHelp = new ControllerHelperMethods();
        DataProcessing data = new DataProcessing();
        AllEnums enus = new AllEnums();
        //private int cardColumns = 0, cardRows = 0;
        #region Index
        public ActionResult Index()
        {
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

        public ActionResult CardViewPartial(string ColorId = "", string StyleID = "", string SizeId = "", decimal Price = 0, string Description = "", List<int> selectedItem = null, bool pages = false, bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        {
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            try
            {
                var freetext = Allocation.DIMALLOC.ToString();
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                string custId = Session["BuisnessId"].ToString();
                int tempCount = ((List<UcodeModel>)Session["UcodeStyle"]) != null ? ((List<UcodeModel>)Session["UcodeStyle"]).Count : 0;
                Session["Selected"] = selectedItem;
                ViewBag.page = pages;
                if (tempCount > 0)
                {
                    List<string> freeTextLst = (List<string>)Session["UcFreeTxt"];
                    model = entity.styleby_freetextview.Where(x => freeTextLst.Contains(x.FreeText)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                        Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0 & d.CustID == custId) |
                      entity.getallassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0) ? 1 : 0,
                        //Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                        isAllocated = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                        Dimensions = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : ""
                    }).ToList();


                }
                else
                {
                    model = entity.styleby_freetextview.Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                        Assembly = entity.getcustassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0 & d.CustID == custId) |
                      entity.getallassemblies.Any(d => d.ParentStyleID == x.StyleID & d.isChargeable == 0) ? 1 : 0,
                        isAllocated = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                        Dimensions = x.StyleID.Contains(",") ? entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : entity.tblfsk_style_freetext.Any(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? entity.tblfsk_style_freetext.Where(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",

                    }).ToList();
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
                        Dimensions = x.Dimensions
                    }).ToList();
                }

                if (ColorId != "" | SizeId != "" | StyleID != "" | Description != "" | BringDimension != false)
                {
                    var sizeStyle = new List<string>(); var colorStyle = new List<string>(); var Styles = new List<string>(); var descStyle = new List<string>();
                    if (selectedItem == null)
                    {
                        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId).Select(x => x.StyleID).Distinct().ToList();
                        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId).Select(x => x.StyleID).Distinct().ToList();
                        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description)).Select(x => x.StyleID).Distinct().ToList();
                        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID).Select(x => x.StyleID).Distinct().ToList();
                    }
                    else
                    {
                        sizeStyle = entity.getstylesviews.Where(x => x.SizeID == SizeId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                        colorStyle = entity.getstylesviews.Where(x => x.ColourID == ColorId & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                        Styles = entity.getstylesviews.Where(x => x.StyleID == StyleID & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                        descStyle = entity.getstylesviews.Where(x => x.Description.Contains(Description) & selectedItem.Contains(x.Product_Group.Value)).Select(x => x.StyleID).Distinct().ToList();
                    }
                    if (model.Count < 1)
                    {

                        model = entity.styleby_freetextview.Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                            ColourId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().ColourID :
                            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().ColourID,
                            SizeId = x.StyleID.Contains(",") ? entity.getstylesviews.Where(s => s.StyleID == x.StyleID.Substring(0, x.StyleID.IndexOf(","))).FirstOrDefault().SizeID :
                            entity.getstylesviews.Where(s => s.StyleID == x.StyleID).FirstOrDefault().SizeID
                        }).ToList();
                    }
                    if (Price != 0 && (SizeId != null & SizeId != "") && (ColorId != null & ColorId != "") && (StyleID != null & StyleID != ""))
                    {
                        model = model.Where(x => x.SizeId == SizeId & x.StyleID == StyleID & x.ColourId == ColorId).ToList();
                    }
                    else
                    {
                        if (StyleID != null && StyleID != "")
                        {
                            var model1 = model.Where(x => Styles.Contains(x.StyleID)).ToList();

                            model = model1.Count() == 0 ? model.Where(x => x.StyleID.Contains(StyleID)).ToList() : model1;
                        }
                        if (ColorId != null && ColorId != "")
                        {
                            model = model.Any(x => colorStyle.Contains(x.StyleID)) ? model.Where(x => colorStyle.Contains(x.StyleID)).ToList() : model;
                        }
                        if (SizeId != null && SizeId != "")
                        {
                            model = model.Where(x => sizeStyle.Contains(x.StyleID)).ToList();
                        }
                        if (Description != null && Description != "")
                        {
                            var modelq = new List<styleViewmodel>();
                            foreach (var dec in descStyle)
                            {
                                var svmq = new styleViewmodel();
                                svmq = model.Any(x => x.StyleID.Contains(",")) ? model.Where(x => x.StyleID.Contains(dec)).FirstOrDefault() : model.Where(x => x.StyleID == dec).FirstOrDefault();
                                if (svmq != null)
                                {
                                    if (svmq.StyleID != svm.StyleID)
                                    {
                                        modelq.Add(svmq);
                                    }
                                }
                                svm = svmq;
                            }
                            model = modelq;
                        }
                        if (BringDimension)
                        {
                            model = model.Any(x => x.isAllocated != null) ? model.Where(x => x.isAllocated).ToList() : new List<styleViewmodel>();
                        }
                    }
                }
                foreach (var data in model)
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
                if (BringImages)
                {
                    model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                }

            }
            catch (Exception e)
            {

            }
            return PartialView("_CardViewPartial", model);
        }
        #endregion

        #region setcardRows and columns
        public string SetRowsnColumns(string rowVal, string columnVal)
        {
            if (rowVal != "" || columnVal != "")
            {
                Session["cardColumns"] = Convert.ToInt16(columnVal);
                Session["cardRows"] = Convert.ToInt16(rowVal);
                return "success";
            }
            return "failed";
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
                var result = entity.getcustassemblies.Any(x => x.ParentStyleID == styleId & x.isChargeable == 0 & x.CustID == custId) ? entity.getcustassemblies.Where(x => x.ParentStyleID == styleId & x.isChargeable == 0 & x.CustID == custId).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList() : entity.getallassemblies.Where(x => x.ParentStyleID == styleId & x.isChargeable == 0).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList();
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
                decimal result = (decimal)entity.getstylesviews.Where(x => x.StyleID == StyleID.Trim() & x.SizeID == SizeId.Trim()).FirstOrDefault().Price.Value;
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
            result.Description = entity.tblfsk_style.Where(x => x.StyleID == styleId).First().Description;
            if (!entity.tblfsk_style_colour_size_obsolete.Any(x => x.StyleID == styleId))
            {
                result.ColorList = (List<string>)entity.tblfsk_style_colour_size.Where(s => s.StyleID == styleId).OrderBy(s => s.ColourID).Select(s => s.ColourID).Distinct().ToList();
                result.SizeList = (List<string>)entity.tblfsk_style_sizes.Where(s => s.StyleID == styleId).Distinct().OrderBy(s => s.SeqNo).Select(s => s.SizeID).ToList();
                result.Price = result.SizeList.Count > 1 ? 0 : GetPrice(styleId, result.SizeList[0]);
            }
            else
            {
                result.ColorList = (List<string>)entity.tblfsk_style_colour_size_obsolete.Where(s => s.StyleID == styleId && s.Obsolete_Class == 0).OrderBy(s => s.ColourID).Select(s => s.ColourID).Distinct().ToList();
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
            UcodeStyle1 = UcodeStyle.Select(x => x.StyleId).ToList();
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
            var styleLst = entity.tblfsk_style_freetext.Where(x => x.FreeText == freeText & x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList();
            try
            {

                foreach (var styles in styleLst)
                {
                    styleViewmodel svm = new styleViewmodel();
                    svm = entity.styleby_freetextview.Any(x => x.StyleID.Contains(styles)) ? entity.styleby_freetextview.Where(x => x.StyleID.Contains(styles)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                        Dimensions = "",
                        isAllocated = false
                    }).FirstOrDefault() : null;
                    if (svm != null)
                    {
                        if (svm.StyleID != sv1.StyleID)
                        {
                            result.Add(svm);
                        }
                    }
                    sv1 = svm;
                }
            }
            catch (Exception e)
            {

            }
            foreach (var data in result)
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
            if (Session["onDemand"] != null && (bool)Session["onDemand"] == true)
            {
                var s = (bool)Session["onDemand"];
                return PartialView("_DimAllocDemandPartial", result);
            }
            else
            {
                return PartialView("_DimAllocPartial", result);
            }
        }
        #endregion

        #region SetDimensionFlag
        public bool SetDimensionFlag(bool onDemandflag)
        {
            if (onDemandflag != null)
            {
                Session["onDemand"] = onDemandflag;
                return true;
            }
            return false;
        }
        #endregion

        #region ondemandCards
        public ActionResult GetcardOnDemand(string StyleID)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = entity.styleby_freetextview.Where(x => x.StyleID == StyleID).Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                Assembly = entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID).Any() ? entity.getcustassemblies.Where(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0

            }).ToList();
            foreach (var data in model)
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
        public JsonResult AddToCart(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "")
        {
            string result = "";
            var salesOrderLines = new List<SalesOrderLineViewModel>();
            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
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
                    DelDesc = addresArr[0],
                    DelAddress1 = addresArr[1],
                    DelAddress2 = addresArr[2],
                    DelAddress3 = addresArr[3],
                    DelTown = addresArr[4],
                    DelCity = addresArr[5],
                    DelPostCode = addresArr[6],
                    DelCountry = addresArr[7],
                    EmployeeName = Session["EmpName"].ToString(),
                    EmployeeID = Session["SelectedEmp"].ToString(),
                    CustRef = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                    Comments = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
                });
            }
            int lineNo = salesOrderLines.Any(x=>x.EmployeeId== Session["SelectedEmp"].ToString())? salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).Count()+1:1 ;
            var chargableAssembs = new List<SalesOrderLineViewModel>();
            var OptionalAssembs = new List<SalesOrderLineViewModel>();
            if (description != "" && price != "" && size != "" && color != "" && qty != "")
            {
                salesOrderLines.Add(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDecimal(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString() });
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
                salesOrderHeader.Where(x=>x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine = salesOrderLines;
                Session["SalesOrderHeader"] = salesOrderHeader;
                Session["assemList"] = null;
                Session["SalesOrderLines"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).ToList();
                Session["qty"] = salesOrderLines.Where(x=>x.EmployeeId== Session["SelectedEmp"].ToString()).Sum(x => x.OrdQty);
                result = "<div class=\"col-md-10\"></div><div class=\"col-md-2 pull-right\"><button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:black;color:gold\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:gold;font-size:30px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button></div>";
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

    }
}