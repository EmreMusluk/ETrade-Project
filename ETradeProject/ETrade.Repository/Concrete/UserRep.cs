using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
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

        public UserDTO CreateUser(UserDTO userDto)
        {
            User selectedUser = Get(x => x.Mail == userDto.Mail);
            if (selectedUser != null)
            {
                userDto.Error = true;
                userDto.Msg = "var bu.";
                return userDto;
            }
            if (userDto.Password.Length < 7 || !(userDto.Password.Any(char.IsLower)) || !(userDto.Password.Any(char.IsUpper)))
            {
                userDto.Error = true;
                userDto.Msg = "7 az.";
                return userDto;

            }
            if (userDto.Password != userDto.RePassword)
            {
                userDto.Error = true;
                userDto.Msg = "aynı değil";
                return userDto;
            }

            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            userDto.Role = "User";

            return userDto;
        }

        public UserDTO Login(string Mail, string Password)
        {
            User selectedUser = Get(x => x.Mail == Mail);
            UserDTO user = new UserDTO();
            user.Mail = Mail;

            if (selectedUser != null)
            {
                user.Error = false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            else
            {
                user.Msg = "Kullanıcı adı ya da şfr hatalı";
                user.Error = true;
            }
            return user;
        }
    }
}
