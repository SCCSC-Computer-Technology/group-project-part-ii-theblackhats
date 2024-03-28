using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data;
using System.Diagnostics;

namespace TeamBlackHatsAPI.Controllers
{
    [Route("api/nba")]
    [ApiController]
    public class NBAController : ControllerBase
    {
        [HttpGet]
        [Route("players")]
        public JsonResult GetAllNBAPlayers()
        {
            string query = "select * from dbo.NBA_Player_Stats";
            DataTable table = NFLDBConnection.ReadWithSql(query);

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("teams")]
        public JsonResult GetAllNBATeams()
        {
            string query = "select * from dbo.nba_team_stats_00_to_21";
            DataTable table = NFLDBConnection.ReadWithSql(query);

            return new JsonResult(table);
        }
    }
}
