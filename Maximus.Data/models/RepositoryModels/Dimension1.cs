﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class Dimension1 : BaseRepository<tblfskstyle_dimension1>
    {
        public Dimension1(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}