using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ETrade.Core;
using ETrade.Dal;
using ETrade.Entities.Concrete;
using ETrade.Repository.Abstract;

namespace ETrade.Repository.Concrete
{
    public class UserRep<T> : BaseRepository<User>, IUserRep where T : class
    {
        ETradeContext _db;
        public UserRep(ETradeContext db) : base(db)
        {
            _db = db;
        }

        public User CreateUser(User user)
        {
            User selectedUser = _db.Set<User>().FirstOrDefault(x => x.Mail == user.Mail);
            if (selectedUser ==null)
            {
                user.Error = false;
            }
            else
            {
                user.Error = true;
            }

            if (user.Password.Length>7 && user.Password.Length <65)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            }
            else
            {
               return user.m
            }
            user.Role = "User";
            return user;

        }

        public User Login(string Mail, string Password)
        {
            User selectedUser = _db.Set<User>().FirstOrDefault(x=>x.Mail == Mail);
            User user = new User();
            user.Mail = Mail;
            if (selectedUser==null)
            {
                user.Error = true;
            }
            else
            {
                user.Error=false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password,selectedUser.Password);
                if (verified==true)
                {
                    user.Role = selectedUser.Role;
                    user.Id =selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            return user;
        }
    }
}
