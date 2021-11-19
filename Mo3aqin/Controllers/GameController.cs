using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Data;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext db;
        public GameController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Competition
        public async Task<IActionResult> AddCompetition()
        {
            var res = await db.Competitions.Select(x => new Competition_VM { CompetitionId = x.CompetitionId, CompetitionName = x.CompetitionName }).ToListAsync();
            return View(res);
        }
        public async Task<JsonResult> GetAllCompetition()
        {
            var res = await db.Competitions.Select(x => new Competition_VM { CompetitionId = x.CompetitionId, CompetitionName = x.CompetitionName }).ToListAsync();
            return Json(res);
        }
        public async Task<IActionResult> AddCompetition(Competition_VM competition)
        {
            
                
            Competition comp = new Competition() { CompetitionName = competition.CompetitionName };
            await db.Competitions.AddAsync(comp);
                var res =await db.SaveChangesAsync();
            if (res>0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
            
        }
        public async Task<IActionResult> GetCompetitionById(int CompetitionId)
        {
            try
            {
                return Json (await db.Competitions.Where(x => x.CompetitionId == CompetitionId).Select(x => x.CompetitionName).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> UpdateCompetitionById(int Id,string Name)
        {
            try
            {
                var copm = await db.Competitions.Where(x => x.CompetitionId == Id).FirstOrDefaultAsync();
                if (copm==null)
                {
                    return Json(false);
                }
                else
                {
                    copm.CompetitionName = Name;
                    var res = await db.SaveChangesAsync();
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
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> DeletCompetition(int CompetitionId)
        {
            try
            {
                var copm = await db.Competitions.Where(x => x.CompetitionId == CompetitionId).FirstOrDefaultAsync();
                if (copm == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Competitions.Remove(copm);
                    var res = await db.SaveChangesAsync();
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
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        #endregion

        public async Task<IActionResult> NewGame()
        {
            return View();
        }
        public async Task<IActionResult> AddNewGame(Game game)
        {

            await db.Games.AddAsync(game);
            var res = await db.SaveChangesAsync();
            if (res > 0)
            {
                
                return Json(new Game_VM {GameId=game.GameId,CompetitionName=db.Competitions.Where(x=> x.CompetitionId==game.CompetitionId).Select(x=> x.CompetitionName).FirstOrDefault(),GameName=game.GameName,Notes=game.Notes });
            }
            else
            {
                return Json(false);
            }
        }
        public async Task<JsonResult> GetAllGames()
        {
            var res = await db.Games.Select(x => new Game_VM { GameId = x.GameId,GameName=x.GameName, CompetitionName = x.Competition.CompetitionName,Notes=x.Notes }).ToListAsync();
            return Json(res);
        }
        public async Task<IActionResult> GetGameById(int GameId)
        {
            try
            {
                return Json(await db.Games.Where(x => x.GameId == GameId).Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName, CompetitionName = x.Competition.CompetitionName,CompetitionId=x.CompetitionId,Notes=x.Notes }).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> UpdateGameById(Game_VM game)
        {
            try
            {
                var NGame = await db.Games.Where(x => x.GameId == game.GameId).FirstOrDefaultAsync();
                if (NGame == null)
                {
                    return Json(false);
                }
                else
                {
                    NGame.GameName = game.GameName;
                    NGame.CompetitionId = game.CompetitionId;
                    NGame.Notes = game.Notes;
                    var res = await db.SaveChangesAsync();
                    if (res > 0)
                    {
                        game.GameId = NGame.GameId;
                        game.CompetitionName = db.Competitions.Where(x => x.CompetitionId == game.CompetitionId).Select(x => x.CompetitionName).FirstOrDefault();
                        return Json(game);
                    }
                    else
                    {
                        return Json(false);
                    }
                }

            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> DeletGame(int id)
        {
            try
            {
                var game = await db.Games.Where(x => x.GameId == id).FirstOrDefaultAsync();
                if (game == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Games.Remove(game);
                    var res = await db.SaveChangesAsync();
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
            catch (Exception ex)
            {

                return Json(ex);
            }
        }


    }
}
