using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace TeamBlackHatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackHatsAppController : ControllerBase
    {
        private IConfiguration _configuration;

        public BlackHatsAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetMLBStats")]

        public JsonResult GetMLBStats()
        {
            string? query = "select * from dbo.MLBStats";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader=myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNBAPlayerStats")]

        public JsonResult GetNBAPlayerStats()
        {
            string? query = "select * from dbo.NBA_Player_Stats";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNBATeamStats")]

        public JsonResult GetNBATeamStats()
        {
            string? query = "select * from dbo.nba_team_stats_00_to_21";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLCoaches")]

        public JsonResult GetNFLCoaches()
        {
            string? query = "select * from dbo.Coaches";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLDefense")]

        public JsonResult GetNFLDefense()
        {
            string? query = "select * from dbo.Defense";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLInjury")]

        public JsonResult GetNFLInjury()
        {
            string? query = "select * from dbo.Injury";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLMVP")]

        public JsonResult GetNFLMVP()
        {
            string? query = "select * from dbo.MVP";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLOffense")]

        public JsonResult GetNFLOffense()
        {
            string? query = "select * from dbo.Offense";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLSchedule")]

        public JsonResult GetNFLSchedule()
        {
            string? query = "select * from dbo.Schedule";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLSpecialTeam")]

        public JsonResult GetNFLSpecialTeam()
        {
            string? query = "select * from dbo.SpecialTeam";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLTeamHx")]

        public JsonResult GetNFLTeamHx()
        {
            string? query = "select * from dbo.TeamHx";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetNFLTeamStats")]

        public JsonResult GetNFLTeamStats()
        {
            string? query = "select * from dbo.TeamStats";
            DataTable table = new DataTable();
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
