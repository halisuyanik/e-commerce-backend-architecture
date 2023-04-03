using e_commerce.Application.Repositories;
using e_commerce.Domain.Entities;
using e_commerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Persistence.Repositories
{
    public class EfProductReadDal : EfEntityReadRepositoryBase<Product>, IProductReadDal
    {
        public EfProductReadDal(dbContext context) : base(context)
        {
        }
    }
}
