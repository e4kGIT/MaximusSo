using System;
using System.Collections.Generic;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Services.Interface;
using Maximus.Data.Models;

namespace Maximus.Services
{
    public class PointsAdjustmentService: IPointsAdjustment
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataProcessing _dp;
        public PointsAdjustmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DataProcessing dp = new DataProcessing(_unitOfWork);
            _dp = dp;
        }

        public List<PointsAdjustmentModel> GetAllPointsAdj(string empId)
        {
            var result = new List<PointsAdjustmentModel>();
            result = _dp.GetAllPointsAdj(empId);
            return result;
        }
    }
}