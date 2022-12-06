using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public Response Register(User user)
        {
            user = _uow._userRep.CreateUser(user);
            try
            {
                if (user.Error == false)
                {
                    _uow._userRep.Add(user);
                    _uow.Commit();
                    _response.Error = false;
                    _response.Msg = "Kaydınız Başarıyla Eklendi";
                    return _response;
                }
                else
                {
                    _response.Error=true;
                    _response.Msg = $"{user.Mail} zaten mevcut";
                }

            }
            catch (Exception ex)
            {
                _response.Msg=ex.Message;
                _response.Error = true;
            }
            return (_response);

        }

    }
}
