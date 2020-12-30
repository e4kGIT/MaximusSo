using Maximus.Data.models;
using System.Collections.Generic;

namespace Maximus.Services.Interface
{
    public interface IPointsAdjustment
    {
        List<PointsAdjustmentModel> GetAllPointsAdj(string empId);
    }
}