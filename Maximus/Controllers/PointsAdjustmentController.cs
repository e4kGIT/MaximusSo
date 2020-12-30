using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    public class PointsAdjustmentController : Controller
    {
        // GET: PointsAdjustment
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPointsAdjustment _pointsAdjustment;

        //private readonly IUnitOfWork _unitOfWork;

        public PointsAdjustmentController(IUnitOfWork unitOfWork)
        {
            PointsAdjustmentService pointsAdjustment = new PointsAdjustmentService(_unitOfWork);
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index()
        {
            var ss = _pointsAdjustment.GetAllPointsAdj("G07167542");
            return View();
        }
    }
}