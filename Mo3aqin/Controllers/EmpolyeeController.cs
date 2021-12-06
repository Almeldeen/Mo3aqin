using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class EmpolyeeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public EmpolyeeController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            this.mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmpolyeeForm()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmpolyeeForm(Employee_VM emp)
        {

            #region//d.EmpName = emp.EmpName;
            //d.JopName = emp.JopName;
            //d.PassportExpDate = emp.PassportExpDate;
            //d.MaritalStatus = emp.MaritalStatus;
            //d.TimeType = emp.TimeType;
            //d.CivilianNumber = emp.CivilianNumber;
            //d.Address = emp.Address;
            //d.PhoneNumber = emp.PhoneNumber;
            //d.HomeNumber = emp.HomeNumber;
            //d.Notes = emp.Notes;
            #endregion

            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Employee>(emp);


                    data.EmpImage = await Help.SaveFileAsync(emp.EmpImage, FilePath.EmpPath);
                    data.CivilianEmp = await Help.SaveFileAsync(emp.CivilianEmp, FilePath.EmpPath);
                    data.PassportImage = await Help.SaveFileAsync(emp.PassportImage, FilePath.EmpPath);

                    db.Employees.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(emp); 
            }catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(emp);
            }
        }
        public async Task<IActionResult> LoadAllEmps(int pageNumber = 1, int pageSize = 10)
        {
            var coach = await db.Employees.Select(x => new Employee_VM
            {
               EmpId=x.EmpId,
               EmpName=x.EmpName,
               EmpImageString=x.EmpImage
            }).ToListAsync();
            var pagedData = Pagination.PagedResult(coach, pageNumber, pageSize);
            return Json(pagedData);
        }
        public async Task<IActionResult> DeletEmp(int id)
        {
            try
            {
                var Emp = await db.Employees.Where(x => x.EmpId == id).FirstOrDefaultAsync();
                if (Emp == null)
                {
                    return Json(false);
                }
                else
                {
                    db.Employees.Remove(Emp);
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
        public async Task<IActionResult> ViewEmpolyee(int empId)
        {
            ViewBag.empId = empId;
            return View();
        }
        public async Task<IActionResult> GetEmpById(int empId)
        {
            var coach = await db.Employees.Where(x => x.EmpId == empId).Select(x => new Employee_VM
            {
                EmpId = x.EmpId,
                JopName=x.JopName,
                Address = x.Address,
                Birthdate = x.Birthdate,
                CivilianEmpString = x.CivilianEmp,
                CivilianNumber = x.CivilianNumber,
                EmpImageString = x.EmpImage,
                EmpName = x.EmpName,
                HomeNumber = x.HomeNumber,
                MaritalStatus = x.MaritalStatus,
                NationalityId = x.NationalityId,
                Notes = x.Notes,
                PassportExpDate = x.PassportExpDate,
                PassportImageString = x.PassportImage,
                PassportNumber = x.PassportNumber,
                PhoneNumber = x.PhoneNumber,
                TimeType = x.TimeType,
                Active = x.Active == true ?(byte)1 :(byte)0
            }).FirstOrDefaultAsync();
            return Json(coach);
        }
        public async Task<IActionResult> EditEmployee(int empId)
        {
            ViewBag.empId = empId;
            return View();
        }
        public async Task<IActionResult> EditEmpById(Employee_VM emp)
        {
            try
            {
                var Emp = await db.Employees.Where(x => x.EmpId == emp.EmpId).FirstOrDefaultAsync();
                if (Emp == null)
                {
                    return Json(false);
                }
                else
                {
                    Emp.Address = emp.Address;
                    Emp.Birthdate = emp.Birthdate;
                    Emp.CivilianEmp = emp.CivilianEmp == null ? Emp.CivilianEmp : await Help.SaveFileAsync(emp.CivilianEmp, FilePath.CoachPath);
                    Emp.CivilianNumber = emp.CivilianNumber;
                    Emp.EmpImage = emp.EmpImage == null ? Emp.EmpImage : await Help.SaveFileAsync(emp.EmpImage, FilePath.CoachPath);
                    Emp.EmpName = emp.EmpName;
                    Emp.HomeNumber = emp.HomeNumber;
                    Emp.MaritalStatus = emp.MaritalStatus;
                    Emp.NationalityId = emp.NationalityId;
                    Emp.Notes = emp.Notes;
                    Emp.PassportExpDate = emp.PassportExpDate;
                    Emp.PassportImage = emp.PassportImage == null ? Emp.PassportImage : await Help.SaveFileAsync(emp.PassportImage, FilePath.CoachPath);
                    Emp.PassportNumber = emp.PassportNumber;
                    Emp.PhoneNumber = emp.PhoneNumber;
                    Emp.TimeType = emp.TimeType;
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
        public IActionResult EmployeeDecision()
        {
            return View();
        }
        public async Task<IActionResult> AddEmpDec(Decision_VM decision)
        {
            try
            {
                var Dec = new EmployeeDecision() { EmpId = decision.Id, DecDate = decision.DecDate, Notes = decision.Notes };
                Dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.EmpPath);
                await db.EmployeeDecisions.AddAsync(Dec);
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
        public async Task<IActionResult> GetEmpDec(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var Dec = await db.EmployeeDecisions.Select(x => new Decision_VM { Name = x.Employee.EmpName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId }).ToListAsync();

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
                return Json(await db.EmployeeDecisions.Where(x => x.DecId == DecId).Select(x => new Decision_VM { Name = x.Employee.EmpName, DecDate = x.DecDate, Notes = x.Notes, DecId = x.DecId, Id = x.EmpId }).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> EditEmpDec(Decision_VM decision)
        {
            try
            {
                var dec = await db.EmployeeDecisions.Where(x => x.DecId == decision.DecId).FirstOrDefaultAsync();
                dec.EmpId = decision.Id;
                dec.DecDate = decision.DecDate;
                dec.Notes = decision.Notes;
                dec.DecFile = decision.DecFile == null ? null : await Help.SaveFileAsync(decision.DecFile, FilePath.EmpPath);
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
                var dec = await db.EmployeeDecisions.Where(x => x.DecId == id).FirstOrDefaultAsync();
                db.EmployeeDecisions.Remove(dec);
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
    }
}
