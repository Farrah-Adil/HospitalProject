using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HospitalProject.Controllers
{
    public class PharmacyController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        private readonly ProjectDbContext _Db;
        public PharmacyController(ProjectDbContext Db)

        {
            _Db = Db;
        }

        public IActionResult PharmacyList()
        {
            return View(_Db.tblPharmacy.ToList());
        }
        public async Task<IActionResult> AddPharmacy(PharmacyEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SavePharmacy(PharmacyEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.PharmacyId == 0)
                    {
                        _Db.tblPharmacy.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("PharmacyList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("PharmacyList");
            }
        }
        public async Task<IActionResult> DeletePharmacy(int PharmacyId)
        {
            try
            {
                var item = await _Db.tblPharmacy.FindAsync(PharmacyId);
                if (item != null)
                {
                    _Db.tblPharmacy.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("PharmacyList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("PharmacyList");
            }
        }
    }
}






    

