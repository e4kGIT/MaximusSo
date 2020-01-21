using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Maximus.Data.models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.Models;

namespace Maximus.Data.InterFace
{
  public class UnitOfWork : IUnitOfWork
    {
        private readonly e4kmaximusdbEntities _dbContext;
        public UnitOfWork()
        {
            _dbContext = new e4kmaximusdbEntities();
        }

       
        public DbContext Db
        {
            get
            {
                 return _dbContext; 
            }
        }

        public void Dispose()
        {
           
        }
    }
}
