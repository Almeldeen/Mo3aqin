using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Constane;
using Mo3aqin.Data;
using Mo3aqin.Helpers;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public PlayerController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            this.mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PlayerForm()
        {
            ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>PlayerForm(Player_VM player)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Player>(player);

                    data.BirthOfDateImage = data.BirthOfDateImage==null?null: await Help.SaveFileAsync(player.BirthOfDateImage, FilePath.PlayerPath);
                    data.PlayerImage = data.PlayerImage == null ? null : await Help.SaveFileAsync(player.PlayerImage, FilePath.PlayerPath);
                    data.DisableImg = data.DisableImg == null ? null : await Help.SaveFileAsync(player.DisableImg, FilePath.PlayerPath);
                    data.PassportImg = data.PassportImg == null ? null : await Help.SaveFileAsync(player.PassportImg, FilePath.PlayerPath);
                    data.MedicalReportImg = data.MedicalReportImg == null ? null : await Help.SaveFileAsync(player.MedicalReportImg, FilePath.PlayerPath);
                    data.PlayerCity = data.PlayerCity == null ? null : await Help.SaveFileAsync(player.PlayerCityImg, FilePath.PlayerPath);
                   await db.Players.AddAsync(data);
                    await db.SaveChangesAsync();
                    List<PlayerGames> playerGames = new List<PlayerGames>();
                    foreach (var item in player.GameIds)
                    {
                        playerGames.Add(new PlayerGames { PlayerId = data.PlayerId, GameId = item });
                    }
                    await db.PlayerGames.AddRangeAsync(playerGames);
                   await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
                return View(player); 
            }catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(player);
            }

            
        }
        public async Task<IActionResult> LoadAllPlayers(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var coach = await db.Players.Select(x => new Player_VM
                {
                    PlayerId = x.PlayerId,
                    PlayerName = x.PlayerName,
                    PlayerImageStr = x.PlayerImage
                }).ToListAsync();
                var pagedData = Pagination.PagedResult(coach, pageNumber, pageSize);
                return Json(pagedData);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        public async Task<IActionResult> DeletPlayer(int id)
        {
            try
            {
                var player = await db.Players.Where(x => x.PlayerId == id).FirstOrDefaultAsync();
                if (player == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Players.Remove(player);
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

                return Json(false);
            }


        }
        public async Task<IActionResult> ViewPlayer(int playerId)
        {
            ViewBag.playerId = playerId;
            ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
            return View();
        }
        public async Task<IActionResult> GetPlayerById(int playerId)
        {
            var coach = await db.Players.Where(x => x.PlayerId == playerId).Select(x => new Player_VM
            {
                BirthOfDate = x.BirthOfDate,
                BirthOfDateImageStr = x.BirthOfDateImage,
                ClassId = x.ClassId,
                Disabality = x.Disabality,
                DisableImgStr = x.DisableImg,
                DocRecommendation = x.DocRecommendation,
                Gada = x.Gada,
                Governorate = x.Governorate,
                MedicalReportImgStr = x.MedicalReportImg,
                MemberId = x.MemberId,
                OtherNumber = x.OtherNumber,
                ParentNumber = x.ParentNumber,
                PassportNum = x.PassportNum,
                PassportImgStr = x.PassportImg,
                PlayerCityImgStr = x.PlayerCity,
                PlayerId = x.PlayerId,
                PlayerImageStr = x.PlayerImage,
                PlayerName = x.PlayerName,
                Plot = x.Plot,
                Regain = x.Regain,
                WorkPlace = x.WorkPlace,
                CivilianNumber = x.CivilianNumber,
                HomeNumber = x.HomeNumber,
                MaritalStatus = x.MaritalStatus,
                NationalityId = x.NationalityId,
                Notes = x.Notes,
                PassportExpDate = x.PassportExpDate,
                PhoneNumber = x.PhoneNumber,
                Active = x.Active == true ? (byte)1 : (byte)0,
                GameIds = db.PlayerGames.Where(x => x.PlayerId == playerId).Select(x => x.GameId).ToArray(),
                RegDate=x.RegDate,
            }).FirstOrDefaultAsync();
            return Json(coach);
        }
        public async Task<IActionResult> EditPlayer(int playerId)
        {
            ViewBag.playerId = playerId;
            ViewBag.Games = await db.Games.Select(x => new Game_VM { GameId = x.GameId, GameName = x.GameName }).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPlayerById(Player_VM player_)
        {
            try
            {
                
                    var player = await db.Players.Where(x => x.PlayerId == player_.PlayerId).FirstOrDefaultAsync();
                if (player == null)
                {
                    return Json(false);
                }
                else
                {
                    player.PassportNum = player_.PassportNum;
                    player.PhoneNumber = player_.PhoneNumber;
                    player.PlayerCity= player_.PlayerCityImg == null ? player.PlayerCity : await Help.SaveFileAsync(player_.PlayerCityImg, FilePath.PlayerPath);
                    player.PassportImg = player_.PassportImg == null ? player.PassportImg : await Help.SaveFileAsync(player_.PassportImg, FilePath.PlayerPath);
                    player.PassportExpDate = player_.PassportExpDate;                  
                    player.PlayerImage= player_.PlayerImage == null ? player.PlayerImage : await Help.SaveFileAsync(player_.PlayerImage, FilePath.PlayerPath);
                    player.Active =player_.Active==1?true:false;
                    player.BirthOfDate = player_.BirthOfDate;
                    player.BirthOfDateImage= player_.BirthOfDateImage == null ? player.BirthOfDateImage : await Help.SaveFileAsync(player_.BirthOfDateImage, FilePath.PlayerPath);
                    player.CivilianNumber = player_.CivilianNumber;
                    player.ClassId = player_.ClassId;
                    player.Disabality = player_.Disabality;
                    player.DisableImg= player_.DisableImg == null ? player.DisableImg : await Help.SaveFileAsync(player_.DisableImg, FilePath.PlayerPath);
                    player.DocRecommendation = player_.DocRecommendation;
                    player.Gada = player_.Gada;
                    player.Governorate = player_.Governorate;
                    player.HomeNumber = player_.HomeNumber;
                    player.MaritalStatus = player_.MaritalStatus;
                    player.MedicalReportImg= player_.MedicalReportImg == null ? player.MedicalReportImg : await Help.SaveFileAsync(player_.MedicalReportImg, FilePath.PlayerPath);
                    player.MemberId = player_.MemberId;
                    player.NationalityId = player_.NationalityId;
                    player.Notes = player_.Notes;
                    player.OtherNumber = player_.OtherNumber;
                    player.ParentNumber = player_.ParentNumber;
                    player.PlayerName = player_.PlayerName;
                    player.Plot = player_.Plot;
                    player.Regain = player_.Regain;
                    player.WorkPlace = player_.WorkPlace;
                    var gameids = await db.PlayerGames.Where(x=> x.PlayerId==player_.PlayerId).ToArrayAsync();
                    player_.GameIds= JsonConvert.DeserializeObject<int[]>(player_.GameIds2);
                    if (gameids.Length!=player_.GameIds.Length)
                    {
                        db.PlayerGames.RemoveRange(gameids);
                        List<PlayerGames> playerGames = new List<PlayerGames>();
                        foreach (var item in player_.GameIds)
                        {
                            playerGames.Add(new PlayerGames { PlayerId = player_.PlayerId, GameId = item });
                        }
                        await db.PlayerGames.AddRangeAsync(playerGames);
                    }
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

                return Json(false);
            }


        }
        public IActionResult PlayerDecision()
        {
            return View();
        }
        public async Task<IActionResult> AddPlayerDec(Decision_VM decision)
        {
            try
            {
                var Dec = new PlayerDecision() { PlayerId = decision.Id, DecDate = decision.DecDate,Notes=decision.Notes };
                Dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.PlayerPath);
                await db.playerDecisions.AddAsync(Dec);
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
            catch (Exception ex)
            {

                return Json(false);
            }
            
        }
        public async Task<IActionResult> GetPlayerDec(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var Dec = await db.playerDecisions.Select(x => new Decision_VM { Name = x.Player.PlayerName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId }).ToListAsync();

                var pagedData = Pagination.PagedResult(Dec, pageNumber, pageSize);
                return Json(pagedData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> GetDecById(int DecId)
        {
            try
            {
                return Json(await db.playerDecisions.Where(x => x.DecId == DecId).Select(x => new Decision_VM { Name = x.Player.PlayerName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId ,Id=x.PlayerId}).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> EditPlayerDec(Decision_VM decision)
        {
            try
            {
                var dec = await db.playerDecisions.Where(x => x.DecId == decision.DecId).FirstOrDefaultAsync();
                dec.PlayerId = decision.Id;
                dec.DecDate = decision.DecDate;
                dec.Notes = decision.Notes;
                dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.PlayerPath);
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
            catch (Exception ex)
            {

                return Json(false);
            }
        }
        public async Task<IActionResult> DeletDec(int id)
        {
            try
            {
                var dec = await db.playerDecisions.Where(x => x.DecId == id).FirstOrDefaultAsync();
                db.playerDecisions.Remove(dec);
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
            catch (Exception ex)
            {

                return Json(false);
            }
        }
        public IActionResult PlayerHistory()
        {
            return View();
        }
        public async Task<IActionResult> AddPlayerHistory(History_VM history)
        {
            try
            {
                var His = new PlayerHistory() { PlayerId = history.Id, HisDate = history.HisDate, Notes = history.Notes ,ChampName=history.ChampName,playerRating=history.playerRating,PlyerNum=history.PlyerNum};
               
                await db.PlayerHistories.AddAsync(His);
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
            catch (Exception ex)
            {

                return Json(false);
            }

        }
        public async Task<IActionResult> GetPlayerHistory(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var Dec = await db.PlayerHistories.Select(x => new History_VM { Name = x.Player.PlayerName, HisDate = x.HisDate, Notes = x.Notes, HisId = x.HisId,playerRating=x.playerRating,
                ChampName=x.ChampName,PlyerNum=x.PlyerNum}).ToListAsync();

                var pagedData = Pagination.PagedResult(Dec, pageNumber, pageSize);
                return Json(pagedData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> GetHistoryById(int HistoryId)
        {
            try
            {
                return Json(await db.PlayerHistories.Where(x => x.HisId == HistoryId).Select(x => new History_VM { Name = x.Player.PlayerName, HisDate = x.HisDate, Notes = x.Notes, HisId = x.HisId, Id = x.PlayerId,ChampName=x.ChampName,
                playerRating=x.playerRating,PlyerNum=x.PlyerNum}).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> EditPlayerHistory(History_VM history)
        {
            try
            {
                var His = await db.PlayerHistories.Where(x => x.HisId == history.HisId).FirstOrDefaultAsync();
                His.PlayerId = history.Id;
                His.HisDate = history.HisDate;
                His.Notes = history.Notes;
                His.playerRating = history.playerRating;
                His.PlyerNum = history.PlyerNum;
                His.ChampName = history.ChampName;
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
            catch (Exception ex)
            {

                return Json(false);
            }
        }
        public async Task<IActionResult> DeletHistory(int id)
        {
            try
            {
                var His = await db.PlayerHistories.Where(x => x.HisId == id).FirstOrDefaultAsync();
                db.PlayerHistories.Remove(His);
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
            catch (Exception ex)
            {

                return Json(false);
            }
        }

        #region Country
        public async Task<IActionResult> Country()
        {
            return View();
        }
        public async Task<IActionResult> GetAllCountry()
        {
            var res = await db.Countries.ToListAsync();
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddCountry(Country country)
        {          
            await db.Countries.AddAsync(country);
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
        public async Task<IActionResult> GetCountryById(int CountryId)
        {
            try
            {
                return Json(await db.Countries.Where(x => x.CountryId == CountryId).Select(x => x.CountryName).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> UpdateCountryById(Country _country)
        {
            try
            {
                var country = await db.Countries.Where(x => x.CountryId == _country.CountryId).FirstOrDefaultAsync();
                if (country == null)
                {
                    return Json(false);
                }
                else
                {
                    country.CountryName = _country.CountryName;
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
        public async Task<IActionResult> DeletCountry(int Id)
        {
            try
            {
                var country = await db.Countries.Where(x => x.CountryId == Id).FirstOrDefaultAsync();
                if (country == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Countries.Remove(country);
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
