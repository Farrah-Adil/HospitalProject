using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HospitalProject.Controllers
{
    public class HospitalController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}



        private readonly ProjectDbContext _Db;
        public HospitalController(ProjectDbContext Db)

        {
            _Db = Db;
        }

        public IActionResult HospitalList()
        {
            return View(_Db.tblHospital.ToList());
        }
        public async Task<IActionResult> AddHospital(HospitalEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SaveHospital(HospitalEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.HospitalId == 0)
                    {
                        _Db.tblHospital.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("HospitalList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("HospitalList");
            }
        }
        public async Task<IActionResult> DeleteHospital(int HospitalId)
        {
            try
            {
                var item = await _Db.tblHospital.FindAsync(HospitalId);
                if (item != null)
                {
                    _Db.tblHospital.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("HospitalList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("HospitalList");
            }
        }
    }
}

