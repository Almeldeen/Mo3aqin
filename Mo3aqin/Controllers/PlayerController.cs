using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Constane;
using Mo3aqin.Data;
using Mo3aqin.Helpers;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
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
        public IActionResult PlayerForm()
        {
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

                    data.BirthOfDateImage = await Help.SaveFileAsync(player.BirthOfDateImage, FilePath.PlayerPath);
                    data.PlayerImage = await Help.SaveFileAsync(player.PlayerImage, FilePath.PlayerPath);
                    data.DisableImg = await Help.SaveFileAsync(player.DisableImg, FilePath.PlayerPath);
                    data.PassportImg = await Help.SaveFileAsync(player.PassportImg, FilePath.PlayerPath);
                    data.MedicalReportImg = await Help.SaveFileAsync(player.MedicalReportImg, FilePath.PlayerPath);
                    data.PlayerCity = await Help.SaveFileAsync(player.PlayerCityImg, FilePath.PlayerPath);

                    db.Players.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
            var coach = await db.Players.Select(x => new Player_VM
            {
             PlayerId=x.PlayerId,
             PlayerName=x.PlayerName,
             PlayerImageStr=x.PlayerImage
            }).ToListAsync();
            var pagedData = Pagination.PagedResult(coach, pageNumber, pageSize);
            return Json(pagedData);
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
            return View();
        }
        public async Task<IActionResult> GetPlayerById(int playerId)
        {
            var coach = await db.Players.Where(x => x.PlayerId == playerId).Select(x => new Player_VM
            {
                BirthOfDate=x.BirthOfDate,
                BirthOfDateImageStr=x.BirthOfDateImage,
                ClassId=x.ClassId,
                Disabality=x.Disabality,
                DisableImgStr=x.DisableImg,
                DocRecommendation=x.DocRecommendation,
                Gada=x.Gada,
                Governorate=x.Governorate,
                MedicalReportImgStr=x.MedicalReportImg,
                MemberId=x.MemberId,
                OtherNumber=x.OtherNumber,
                ParentNumber=x.ParentNumber,
                PassportNum=x.PassportNum,
                PassportImgStr=x.PassportImg,
                PlayerCityImgStr=x.PlayerCity,
                PlayerId=x.PlayerId,
                PlayerImageStr=x.PlayerImage,
                PlayerName=x.PlayerName,
                Plot=x.Plot,
                Regain=x.Regain,
                WorkPlace=x.WorkPlace,             
                CivilianNumber = x.CivilianNumber,              
                HomeNumber = x.HomeNumber,
                MaritalStatus = x.MaritalStatus,
                NationalityId = x.NationalityId,
                Notes = x.Notes,
                PassportExpDate = x.PassportExpDate,              
                PhoneNumber = x.PhoneNumber,     
                Active = x.Active == true ? (byte)1 : (byte)0
            }).FirstOrDefaultAsync();
            return Json(coach);
        }
        public async Task<IActionResult> EditPlayer(int playerId)
        {
            ViewBag.playerId = playerId;
            return View();
        }
        public async Task<IActionResult> EditEmpById(Player_VM player_)
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

    }
}
