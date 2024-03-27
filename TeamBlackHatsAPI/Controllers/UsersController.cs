using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data;

namespace TeamBlackHatsAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public JsonResult GetAllUsers()
        {
            string query = "select * from dbo.Users";
            DataTable table = NFLDBConnection.ReadWithSql(query);

            return new JsonResult(table);

        }
    }
}
