using AutoMapper;
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
        private readonly IMapper mapper;
        public GameController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            this.mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Game = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();

            return View();
        }
        #region Competition
        public async Task<IActionResult> Competition()
        {
            return View();
        }
        public async Task<JsonResult> GetAllCompetition()
        {
            var res = await db.Competitions.Select(x => new Competition_VM { CompetitionId = x.CompetitionId, CompetitionName = x.CompetitionName }).ToListAsync();
            return Json(res);
        }
        [HttpPost]
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
        #region Game
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
        public async Task<IActionResult> GameDetails(int Gameid)
        {
            ViewBag.Game = await db.Games.Where(x => x.GameId == Gameid).Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).FirstOrDefaultAsync();
            ViewBag.Coach = await db.Coaches.Where(x => x.Active == 1).Select(x => new Coach_VM { CoachId = x.CoachId, CoachName = x.CoachName }).ToListAsync();
            ViewBag.Emp = await db.Employees.Where(x => x.Active == true).Select(x => new Employee_VM { EmpId = x.EmpId, EmpName = x.EmpName }).ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GameDetails(GameDetail_VM gameDetail)
        {
            if(!ModelState.IsValid){
                ViewBag.Game = await db.Games.Where(x => x.GameId == gameDetail.GameId).Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).FirstOrDefaultAsync();
                return View(gameDetail);
            }
            var data = mapper.Map<GameDetails>(gameDetail);
            await db.GameDetails.AddAsync(data);
           await db.SaveChangesAsync();
            return RedirectToAction("index");

        }

        #endregion
        #region Class
        public async Task<IActionResult> Class()
        {
            return View();
        }
        public async Task<IActionResult> AddClass(Class cla)
        {

            await db.Classes.AddAsync(cla);
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
        public async Task<JsonResult> GetAllClass()
        {
            var res = await db.Classes.Select(x => new Class_VM { ClassId=x.ClassId,ClassName=x.ClassName,ClassDis=x.ClassDis }).ToListAsync();
            return Json(res);
        }
        public async Task<IActionResult> GetClassById(int ClassId)
        {
            try
            {
                return Json(await db.Classes.Where(x => x.ClassId == ClassId).Select(x=> x.ClassName).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> UpdateClassById(Class_VM class_VM)
        {
            try
            {
                var NClass = await db.Classes.Where(x => x.ClassId == class_VM.ClassId).FirstOrDefaultAsync();
                if (NClass == null)
                {
                    return Json(false);
                }
                else
                {
                    NClass.ClassName = class_VM.ClassName;
                    NClass.ClassDis = class_VM.ClassDis;
                    var res = await db.SaveChangesAsync();
                    if (res > 0)
                    {
                        class_VM.ClassId = NClass.ClassId;
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
        public async Task<IActionResult> DeletClass(int id)
        {
            try
            {
                var game = await db.Classes.Where(x => x.ClassId == id).FirstOrDefaultAsync();
                if (game == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Classes.Remove(game);
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

    }
}
