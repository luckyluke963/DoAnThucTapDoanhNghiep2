using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        ShopOnline db = null;

        public MenuDao()
        {
            db = new ShopOnline();
        }

        public List<Menu> ListByGroupId(int groupID)
        {
            return db.Menus.Where(x=>x.TypeID == groupID && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
