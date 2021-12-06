using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Constane;
using Mo3aqin.Data;
using Mo3aqin.Helpers;
using Mo3aqin.Models;
using Mo3aqin.ViewModels;
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Controllers
{
    public class CoachController : Controller
    {
        private readonly ApplicationDbContext db;
        public CoachController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CoachForm()
        {
            return View();
        }
        public async Task<IActionResult> AddCoach(Coach_VM coach)
        {
            try
            {
                Coach coac = new Coach();
                coac.Address = coach.Address;
                coac.Birthdate = coach.Birthdate;
                coac.CivilianCoach = await Help.SaveFileAsync(coach.CivilianCoach, FilePath.CoachPath);
                coac.CivilianNumber = coach.CivilianNumber;
                coac.CoachImage = await Help.SaveFileAsync(coach.CoachImage, FilePath.CoachPath);
                coac.CoachName = coach.CoachName;
                coac.HomeNumber = coach.HomeNumber;
                coac.MaritalStatus = coach.MaritalStatus;
                coac.NationalityId = coach.NationalityId;
                coac.Notes = coach.Notes;
                coac.PassportExpDate = coach.PassportExpDate;
                coac.PassportImage = await Help.SaveFileAsync(coach.PassportImage, FilePath.CoachPath);
                coac.PassportNumber = coach.PassportNumber;
                coac.PhoneNumber = coach.PhoneNumber;
                coac.TimeType = coach.TimeType;
                coac.Active = coach.Active;
                await db.Coaches.AddAsync(coac);
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
            catch (Exception ex)
            {

                return Json(false);
            }
            
        }
    
        public async Task<IActionResult> LoadAllCoachs(int pageNumber=1,int pageSize = 10)
        {
            var coach = await db.Coaches.Select(x => new Coach_VM
            {
                CoachId = x.CoachId,
                CoachName = x.CoachName,
                CoachImageString = x.CoachImage
            }).ToListAsync();
            var pagedData = Pagination.PagedResult(coach, pageNumber, pageSize);
            return Json(pagedData);
        }
        public async Task<IActionResult> EditCoach(int coachId)
        {
            ViewBag.coachId = coachId;
            return View();
        }
        public async Task<IActionResult> GetCoachById(int coachId)
        {
            var coach = await db.Coaches.Where(x => x.CoachId == coachId).Select(x => new Coach_VM
            {
                CoachId = x.CoachId,
                Address = x.Address,
                Birthdate = x.Birthdate,
                CivilianCoachString = x.CivilianCoach,
                CivilianNumber = x.CivilianNumber,
                CoachImageString = x.CoachImage,
                CoachName = x.CoachName,
                HomeNumber = x.HomeNumber,
                MaritalStatus = x.MaritalStatus,
                NationalityId=x.NationalityId,
                Notes = x.Notes,
                PassportExpDate = x.PassportExpDate,
                PassportImageString = x.PassportImage,
                PassportNumber = x.PassportNumber,
                PhoneNumber = x.PhoneNumber,
                TimeType = x.TimeType
            }).FirstOrDefaultAsync();
            return Json(coach);
        }
        public async Task<IActionResult> EditCoachById(Coach_VM coach_)
        {
            try
            {
                var coach = await db.Coaches.Where(x => x.CoachId == coach_.CoachId).FirstOrDefaultAsync();
                if (coach == null)
                {
                    return Json(false);
                }
                else
                {
                    coach.Address = coach_.Address;
                    coach.Birthdate = coach_.Birthdate;
                    coach.CivilianCoach = coach_.CivilianCoach == null ? coach.CivilianCoach : await Help.SaveFileAsync(coach_.CivilianCoach, FilePath.CoachPath);
                    coach.CivilianNumber = coach_.CivilianNumber;
                    coach.CoachImage = coach_.CoachImage == null ? coach.CoachImage : await Help.SaveFileAsync(coach_.CoachImage, FilePath.CoachPath);
                    coach.CoachName = coach_.CoachName;
                    coach.HomeNumber = coach_.HomeNumber;
                    coach.MaritalStatus = coach_.MaritalStatus;
                    //coach.Nationality = coach_.Nationality;
                    coach.Notes = coach_.Notes;
                    coach.PassportExpDate = coach_.PassportExpDate;
                    coach.PassportImage = coach_.PassportImage == null ? coach.PassportImage : await Help.SaveFileAsync(coach_.PassportImage, FilePath.CoachPath);
                    coach.PassportNumber = coach_.PassportNumber;
                    coach.PhoneNumber = coach_.PhoneNumber;
                    coach.TimeType = coach_.TimeType;
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
        public async Task<IActionResult> DeletCoach(int id)
        {
            try
            {
                var coach = await db.Coaches.Where(x => x.CoachId == id).FirstOrDefaultAsync();
                if (coach == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Coaches.Remove(coach);
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
        public async Task<IActionResult> ViewCoach(int coachId)
        {

            ViewBag.coachId = coachId;
            return View();
        }
        public IActionResult CoachDecision()
        {
            return View();
        }
        public async Task<IActionResult> AddCoachDec(Decision_VM decision)
        {
            try
            {
                var Dec = new CoachDecision() { CoachId = decision.Id, DecDate = decision.DecDate, Notes = decision.Notes };
                Dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.CoachPath);
                await db.CoachDecisions.AddAsync(Dec);
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
        public async Task<IActionResult> GetCoachDec(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var Dec = await db.CoachDecisions.Select(x => new Decision_VM { Name = x.Coach.CoachName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId }).ToListAsync();

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
                return Json(await db.CoachDecisions.Where(x => x.DecId == DecId).Select(x => new Decision_VM { Name = x.Coach.CoachName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId, Id = x.CoachId }).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> EditCoachDec(Decision_VM decision)
        {
            try
            {
                var dec = await db.CoachDecisions.Where(x => x.DecId == decision.DecId).FirstOrDefaultAsync();
                dec.CoachId = decision.Id;
                dec.DecDate = decision.DecDate;
                dec.Notes = decision.Notes;
                dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.CoachPath);
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
                var dec = await db.CoachDecisions.Where(x => x.DecId == id).FirstOrDefaultAsync();
                db.CoachDecisions.Remove(dec);
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
        #region Nationality
        public async Task<IActionResult> Nationality()
        {
            return View();
        }
        public async Task<JsonResult> GetAllNationality()
        {
            var res = await db.Nationalities.ToListAsync();
            return Json(res);
        }
        public async Task<IActionResult> AddNationality(Nationality nationality)
        {  
            await db.Nationalities.AddAsync(nationality);
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
        public async Task<IActionResult> GetNationalityById(int NationalityId)
        {
            try
            {
                return Json(await db.Nationalities.Where(x => x.NationalityId == NationalityId).Select(x => x.NationalityName).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
        public async Task<IActionResult> UpdateNationalityById(int Id, string Name)
        {
            try
            {
                var copm = await db.Nationalities.Where(x => x.NationalityId == Id).FirstOrDefaultAsync();
                if (copm == null)
                {
                    return Json(false);
                }
                else
                {
                    copm.NationalityName = Name;
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
        public async Task<IActionResult> DeletNationality(int NationalityId)
        {
            try
            {
                var copm = await db.Nationalities.Where(x => x.NationalityId == NationalityId).FirstOrDefaultAsync();
                if (copm == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Nationalities.Remove(copm);
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
