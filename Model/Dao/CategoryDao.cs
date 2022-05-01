using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        ShopOnline db = null;

        public CategoryDao()
        {
            db = new ShopOnline();
        }

        public List<Category> ListAll()
        {
            return  db.Categories.Where(x=>x.Status == true).ToList();
        }


        public  ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }


        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
    }
}
