using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

                    Employee d = new Employee();
                    d.EmpImage = await Help.SaveFileAsync(emp.EmpImage, FilePath.EmpPath);
                    d.CivilianCoach = await Help.SaveFileAsync(emp.CivilianCoach, FilePath.EmpPath);
                    d.PassportImage = await Help.SaveFileAsync(emp.PassportImage, FilePath.EmpPath);

                    db.Employees.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("EmpolyeeForm");
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
    }
}
