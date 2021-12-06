using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Constane;
using Mo3aqin.Data;
using Mo3aqin.Helpers;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ChampionshipController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            this.mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ChampionshipForm()
        {
            ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
            ViewBag.Country = await db.Countries.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChampionshipForm(Championship_VM championship)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Championship>(championship);
                    data.Invitaion = await Help.SaveFileAsync(championship.Invitaion, FilePath.ChampPath);
                    await db.Championships.AddAsync(data);
                    await db.SaveChangesAsync();
                    List<ChampionshipGames> championship_Games = new List<ChampionshipGames>();
                    //for (int i = 0; i < championship.GameIds.Length; i++)
                    //{
                    //    championship_Games.Append(new Championship_Games { ChampId = data.ChampId, GameId = championship.GameIds[i] });
                    //}
                    foreach (var item in championship.GameIds)
                    {
                        ChampionshipGames games = new ChampionshipGames() { ChampId = data.ChampId, GameId = item };
                        championship_Games.Add(games);
                    }
                    await db.ChampionshipGames.AddRangeAsync(championship_Games);
                    int res = await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
                ViewBag.Country = await db.Countries.ToListAsync();
                return View(championship);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> ChampionshipQuery()
        {
            ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
            ViewBag.Country = await db.Countries.ToListAsync();
            return View();
        }
        public async Task<IActionResult> ChampionshipFiltr(Championship_VM championship)
        {
            try
            {
                var date = new DateTime();
                List<SqlParameter> parms = new List<SqlParameter>
            {
                 new SqlParameter { ParameterName = "@startdate",SqlDbType=System.Data.SqlDbType.DateTime, Value = championship.StartDate==date?DBNull.Value:championship.StartDate },
                 new SqlParameter { ParameterName = "@enddate", SqlDbType=System.Data.SqlDbType.DateTime,Value = championship.EndDate==date?DBNull.Value:championship.EndDate },
                 new SqlParameter { ParameterName = "@name", Value = championship.ChampName==null?DBNull.Value:championship.ChampName },
                 new SqlParameter { ParameterName = "@season", Value = championship.Season==null?DBNull.Value:championship.Season },
                 new SqlParameter { ParameterName = "@country",SqlDbType=System.Data.SqlDbType.Int, Value = championship.CountryId==-1?DBNull.Value:championship.CountryId },
                 new SqlParameter { ParameterName = "@city", Value = championship.City==null?DBNull.Value:championship.City },

            };
                if (championship.GameIds2!="[]")
                {
                    var list = new List<Champ>();
                    int[] GameIds = JsonConvert.DeserializeObject<int[]>(championship.GameIds2);
                    
                    foreach (var item in GameIds)
                    {
                        parms.Add(new SqlParameter { ParameterName = "@game", SqlDbType = System.Data.SqlDbType.Int, Value = item });
                        list.AddRange(await db.champs.FromSqlRaw("EXECUTE FilterChamp @startdate,@enddate,@name,@season,@country,@city,@game", parms.ToArray()).ToListAsync());
                        parms.Remove(parms.Last());
                    }
                    return Json(list);
                }
                
                var data = await db.champs.FromSqlRaw("EXECUTE FilterChamp @startdate,@enddate,@name,@season,@country,@city", parms.ToArray()).ToListAsync();
                return Json(data);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
            
        }
        public async Task<IActionResult> ChampionshipStatus()
        {
            ViewBag.Champ = await db.Championships.Select(x => new Championship_VM { ChampName = x.ChampName, ChampId = x.ChampId }).ToListAsync();
            return View();
        }
        public async Task<IActionResult> GetChampById(int champid)
        {
            var chek =await db.ChampStatuses.Where(x => x.ChampId == champid).FirstOrDefaultAsync();
            var data = new ChampStatus_VM();
            if (chek!=null)
            {
                 data = await db.ChampStatuses.Where(x => x.ChampId == champid).Select(x => new ChampStatus_VM
                {
                    GameIds = string.Join("-", db.ChampionshipGames.Where(x => x.ChampId == champid).Select(x => x.Game.GameName).ToList()),
                    ChampName = x.Championship.ChampName,
                    StartDate = x.Championship.StartDate,
                    EndDate = x.Championship.EndDate,
                    City = x.Championship.City,
                    ChampInvChek = x.ChampInvChek,
                    AddresTheauthChek = x.AddresTheauthChek,
                    BookTicketChek = x.BookTicketChek,
                    DelegChek = x.DelegChek,
                    FinancialChek = x.FinancialChek,
                    NominationPlayerChek = x.NominationPlayerChek,
                    PayOfFeesChek = x.PayOfFeesChek,
                    PRChek = x.PRChek,
                    PromisChek = x.PromisChek,
                    RegByNamesChek = x.RegByNamesChek,
                    RegNumChek = x.RegNumChek,
                    RePortChek = x.RePortChek,
                    ResidenceChek = x.ResidenceChek,
                    ResultsChek = x.ResultsChek,
                    SportFreeTimeChek = x.SportFreeTimeChek,
                    UniformChek = x.UniformChek,
                    VisaChek = x.VisaChek,
                }).FirstOrDefaultAsync();
            }
            else
            {
                data = await db.Championships.Where(x => x.ChampId == champid).Select(x => new ChampStatus_VM
                {
                    GameIds = string.Join("-", db.ChampionshipGames.Where(x => x.ChampId == champid).Select(x => x.Game.GameName).ToList()),
                    ChampName = x.ChampName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    City = x.City,
                }).FirstOrDefaultAsync();
            }
           
            return Json(data);
        }
        public async Task<IActionResult> AddChampStatus(ChampStatus champStatus)
        {
            try
            {
                var chamstatus = await db.ChampStatuses.Where(x => x.ChampId == champStatus.ChampId).FirstOrDefaultAsync();
                if (chamstatus == null)
                {
                    await db.ChampStatuses.AddAsync(champStatus);
                    int res = await db.SaveChangesAsync();
                    if (res >0)
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                else
                {
                    chamstatus.AddresTheauthChek = champStatus.AddresTheauthChek;
                    chamstatus.BookTicketChek = champStatus.BookTicketChek;
                    chamstatus.ChampInvChek = champStatus.ChampInvChek;
                    chamstatus.DelegChek = champStatus.DelegChek;
                    chamstatus.FinancialChek = champStatus.FinancialChek;
                    chamstatus.NominationPlayerChek = champStatus.NominationPlayerChek;
                    chamstatus.PayOfFeesChek = champStatus.PayOfFeesChek;
                    chamstatus.PRChek = champStatus.PRChek;
                    chamstatus.PromisChek = champStatus.PromisChek;
                    chamstatus.RegByNamesChek = champStatus.RegByNamesChek;
                    chamstatus.RegNumChek = champStatus.RegNumChek;
                    chamstatus.RePortChek = champStatus.RePortChek;
                    chamstatus.ResidenceChek = champStatus.ResidenceChek;
                    chamstatus.ResultsChek = champStatus.ResultsChek;
                    chamstatus.SportFreeTimeChek = champStatus.SportFreeTimeChek;
                    chamstatus.UniformChek = champStatus.UniformChek;
                    chamstatus.VisaChek = champStatus.VisaChek;
                    int res = await db.SaveChangesAsync();
                    if (res > 0)
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
            }
            catch (Exception)
            {

                return Json(false);
            }
           
        }
        public async Task<IActionResult> ChampionshipPlayers()
        {
            ViewBag.Champ = await db.Championships.Select(x => new Championship_VM { ChampName = x.ChampName, ChampId = x.ChampId }).ToListAsync();
            return View();
        }
        public async Task<IActionResult> GetChampPlayerById(int champid)
        {
            var data = await db.Championships.Where(x => x.ChampId == champid).Select(x => new ChampPlayers_VM
            {
                ChampName=x.ChampName,
                GameIds= string.Join("-", db.ChampionshipGames.Where(x => x.ChampId == champid).Select(x => x.Game.GameName).ToList()),
                Comptions= string.Join("-", db.ChampionshipGames.Where(x => x.ChampId == champid).Select(x => x.Game.Competition.CompetitionName).ToList()),
                //players=db.PlayerGames.Where(g=> g.GameId==x.ChampionshipGames.GameId ).Select(g=> new Player_VM {PlayerId=g.PlayerId,PlayerName=g.Player.PlayerName }).ToList(),
                PlayerschIds=db.ChampPLayers.Where(x=> x.ChampId==champid).Select(x=> x.PlayerId).ToArray()
            }).FirstOrDefaultAsync();
            return Json(data);
        }
        public async Task<IActionResult> AddChampPlayers(ChampPlayers_VM players_VM)
        {
            try
            {
                List<ChampPLayers> champPLayers = new List<ChampPLayers>();
                var Playerids = JsonConvert.DeserializeObject<int[]>(players_VM.PlayersIds);
                var data = await db.ChampPLayers.Where(x => x.ChampId == players_VM.ChampId).ToListAsync();
                foreach (var item in Playerids)
                {
                    champPLayers.Add(new ChampPLayers { ChampId = players_VM.ChampId, PlayerId = item });
                }
                if (data==null)
                {
                    await db.ChampPLayers.AddRangeAsync(champPLayers);
                }
                else if(data.Count()!=Playerids.Length)
                {
                     db.RemoveRange(data);
                    await db.ChampPLayers.AddRangeAsync(champPLayers);
                }
                
                int res = await db.SaveChangesAsync();
                if (res >0)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception ex)
            {

                return Json(false);
            }
           

        }
    }
}
