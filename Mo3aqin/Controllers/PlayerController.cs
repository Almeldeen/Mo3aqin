using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

                    data.BirthOfDateImage = await Help.SaveFileAsync(player.BirthOfDateImage, FilePath.EmpPath);
                    data.PlayerImage = await Help.SaveFileAsync(player.PlayerImage, FilePath.EmpPath);
                    data.DisableImg = await Help.SaveFileAsync(player.DisableImg, FilePath.EmpPath);
                    data.PassportImg = await Help.SaveFileAsync(player.PassportImg, FilePath.EmpPath);
                    data.MedicalReportImg = await Help.SaveFileAsync(player.MedicalReportImg, FilePath.EmpPath);
                    data.PlayerCity = await Help.SaveFileAsync(player.PlayerCityImg, FilePath.EmpPath);

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

    }
}
