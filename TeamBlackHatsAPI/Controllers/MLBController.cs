using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TeamBlackHatsAPI.Controllers
{
    [Route("api/mlb")]
    [ApiController]
    public class MLBController : ControllerBase
    {
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("stats")]
        public JsonResult GetAllMLBPlayerStats()
        {
            string query = "select * from dbo.MLBStats";
            DataTable table = NFLDBConnection.ReadWithSql(query);

            return new JsonResult(table);

        }
    }
    }
}
