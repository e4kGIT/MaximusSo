﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class PickingSlipDetail : BaseRepository<tblsop_pickingslip_detail>
    {
        public PickingSlipDetail(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
