using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        ShopOnline db =null;
        public UserDao()
        {
            db = new ShopOnline();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if(user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if(string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;    
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = entity.ModifiedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public IEnumerable<User>ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<User> model = db.Users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x=> x.UserName == userName);
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string UserName , string Password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName ); 
           if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }

                else
                {
                    if(result.Password == Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
          
        }



        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception )
            {
                return false;
            }
            
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
           
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }


        public bool CheckUserName (string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
