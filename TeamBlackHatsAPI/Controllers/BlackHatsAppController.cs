﻿using Microsoft.AspNetCore.Http;
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
            string? query = $"SELECT PlayerName, playerID, Season, weight, height, bats, throws, League, Team FROM dbo.MLBStats WHERE season IN ('2016', '2015', '2014') ORDER BY playerID";
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
        [Route("GetMLBTeamStats")]

        public JsonResult GetMLBTeamStats()
        {
            string? query = $"SELECT Team, playerID, teamID, Season, League, Franchise FROM dbo.MLBStats WHERE season IN ('2016', '2015', '2014') ORDER BY playerID";
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
        [Route("GetNBAPlayerStats")]

        public JsonResult GetNBAPlayerStats()
        {
            string? query = "SELECT Player, Pos, Tm, FG, TRB, FT, AST, STL, BLK FROM dbo.NBA_Player_Stats WHERE Year IN ('1997-1998') ORDER BY Player";
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
            string? query = "SELECT TEAM, GP, W, L, PTS, FGA, REB, AST, BLK from dbo.nba_team_stats_00_to_21 WHERE SEASON IN ('2020-21') ORDER BY TEAM";
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

        [HttpGet]
        [Route("GetUsers")]

        public JsonResult GetUsers()
        {
            string? query = "select * from dbo.Users";
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

        [HttpPost]
        [Route("AddUsers")]

        public IActionResult AddUsers(User user)
        {
            string? query = "INSERT INTO dbo.Users (Username, Password) VALUES (@Username, @Password)";
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Username", user.Username);
                    myCommand.Parameters.AddWithValue("@Password", user.Password);
                    myCommand.ExecuteNonQuery();
                }
            }

            return Ok("User added successfully.");
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult AuthenticateUser(User user)
        {
            string query = "SELECT Userid FROM dbo.Users WHERE Username = @username AND Password = @password";
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@username", user.Username);
                    myCommand.Parameters.AddWithValue("@password", user.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpDelete]
        [Route("DeleteUsers")]
        public IActionResult DeleteUsers(string Username)
        {
            string? query = "DELETE FROM dbo.Users WHERE Username = @Username";
            string? sqlDatasource = _configuration.GetConnectionString("blackHatsDBCon");

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Username", Username);
                    myCommand.ExecuteNonQuery();
                }
            }

            return Ok("User deleted successfully.");
        }
    }
}
