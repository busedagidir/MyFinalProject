using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip
    //IEntity : IEntity olabilri veya IEntity implemente eden bir nesne olabilri
    public interface IEntityRepo<T> where T:class, IEntity  //bana calisacagin tipi soyle
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //eticaret sitelerinde filtreleme yapmani saglayan kod
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
