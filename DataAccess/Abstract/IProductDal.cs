using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //interface metodları default publictir
    public interface IProductDal : IEntityRepo<Product>
    {
        
    }
}
