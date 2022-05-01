﻿using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {

        ShopOnline db = null;
        public ProductCategoryDao()
        {
            db = new ShopOnline();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x=> x.Status==true).OrderBy(x=> x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
