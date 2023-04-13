using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HospitalProject.Controllers
{
    public class DepartmentController : Controller
    {
        //public IActionResult Index()
        //{
        //return View();
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


     private readonly ProjectDbContext _Db;
        public DepartmentController(ProjectDbContext Db)

        {
            _Db = Db;
        }

 public IActionResult DepList()
        {
            try
            {


                var DepList = from a in _Db.tblDepartments
                              join b in _Db.tblHospital
                              on a.HosId equals b.HospitalId
                              into Hospital
                              from b in Hospital.DefaultIfEmpty()




                              select new DepartmentEntity
                              {
DepName = a.DepName,
DepHead = a.DepHead,
DepPhone = a.DepPhone,
DepEmail = a.DepEmail,
HosId = a.HosId , 
HosName = b == null? "": b .Name 



                              };


                return View(DepList);
            }
            catch (Exception ex)
            {
                return View();

            }

        }

        public async Task<IActionResult> AddDepartment(DepartmentEntity obj)
        {
            loadHospital();
            return View(obj);
        }
        public async Task<IActionResult> SaveDepartment(DepartmentEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.DepId == 0)
                    {
                        _Db.tblDepartments.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("DepList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("DepList");
            }
        }
        public async Task<IActionResult> DeleteDepartment(int DepId)
        {
            try
            {
                var item = await _Db.tblDepartments.FindAsync(DepId);
                if (item != null)
                {
                    _Db.tblDepartments.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("DepList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("DepList");

            }
        }
    }
}

        

    













        



    

