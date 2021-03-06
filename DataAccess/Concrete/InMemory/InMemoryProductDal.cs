﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, MongoDb, Postgres
            _products = new List<Product> 
            { 
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15}, //heapte olusturmus oluyorum boyle suslu parntez var dikkat
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product) //parametrede referans gostermiş olduk ama heapte olusturdugumuz adreslerle aynı adresi göstermez burdaki referans no
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); //bu sekilde listeden silemezsin.

            //LINQ-language integrated query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //foreach görevi görür
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() //vtabanındakı datayı businesa vermem lazım
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //foreach görevi görür
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
