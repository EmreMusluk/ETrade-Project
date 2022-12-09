using ETrade.DTO;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUow _uow;
        Response _response;
        public AuthController(Response response,IUow uow)
        {
            _uow = uow;
            _response = response;
        }
        [HttpPost]
        public Response Register(UserDTO user)
        {
            user = _uow._userRep.CreateUser(user);
            try
            {
                if (user.Error)
                {
                    _response.Error = true;
                    _response.Msg = user.Msg;
                }
                else
                {
                    _uow._userRep.Add(user.Map());
                    var x = user.Map(); ;
                    _uow.Commit();
                    _response.Error = false;
                    _response.Msg = "Kaydınız Başarıyla Eklendi";
                    return _response;
                }
            }
            catch (Exception ex)
            {
                _response.Msg=ex.Message;
                _response.Error = true;
            }

            return (_response);
        }

        [HttpPost]
        public Response Login(UserDTO userDto)
        {
            UserDTO user = _uow._userRep.Login(userDto.Mail, userDto.Password);

            if (user.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));

                if (user.Role == "Admin")
                {
                    _response.Error = false;
                    _response.Msg = "Admin girişi başarılı";
                }
                else
                {
                    _response.Error = false;
                    _response.Msg = "User girişi başarılı"; 
                }
            }
            else
            {
                _response.Error = true;
                _response.Msg = user.Msg;
            }

            return _response;
        }

    }
}
