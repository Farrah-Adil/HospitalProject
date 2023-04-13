using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HospitalProject.Controllers
{
    public class DrController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ProjectDbContext _Db;
        public DrController(ProjectDbContext Db)

        {
            _Db = Db;
        }
        //Method to Load Categories in Add Item View Page

        private void loadHospital()
        {
            try
            {
                List<HospitalEntity> HospitalList = new List<HospitalEntity>();
                HospitalList = _Db.tblHospital.ToList();

                HospitalList.Insert(0, new HospitalEntity { HospitalId = 0, Name = "Please Select" });

                ViewBag.HospitalList = HospitalList;

            }
            catch (Exception ex)
            {


            }
        }
        //Method to Load Categories in Add Item View Page

        private void loadDepartment()
        {
            try
            {
                List<DepartmentEntity> DepList = new List<DepartmentEntity>();
                DepList = _Db.tblDepartments.ToList();

                DepList.Insert(0, new DepartmentEntity { DepId = 0, DepName = "Please Select" });

                ViewBag.DepList = DepList;

            }
            catch (Exception ex)
            {


            }

        }

        public IActionResult DrList()
        {
            return View(_Db.tblDr.ToList());
        }
        public async Task<IActionResult> AddDoctor(DrEntity obj)
        {
            loadDepartment();
            loadHospital();
            return View(obj);
        }
        public async Task<IActionResult> SaveDoctor(DrEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.DrId == 0)
                    {
                        _Db.tblDr.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("DrList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("DrList");
            }
        }
        public async Task<IActionResult> DeleteDoctor(int DrId)
        {
            try
            {
                var item = await _Db.tblDr.FindAsync(DrId);
                if (item != null)
                {
                    _Db.tblDr.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("DrList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("DrList");
            }
        }
    }
}














    

