using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class LabController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();

        private readonly ProjectDbContext _Db;
        public LabController(ProjectDbContext Db)

        {
            _Db = Db;
        }

        public IActionResult LabList()
        {
            return View(_Db.tblLab.ToList());
        }
        public async Task<IActionResult> AddLab(LabEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SaveLab(LabEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.LabId == 0)
                    {
                        _Db.tblLab.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("LabList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("LabList");
            }
        }
        public async Task<IActionResult> DeleteLab(int LabId)
        {
            try
            {
                var item = await _Db.tblLab.FindAsync(LabId);
                if (item != null)
                {
                    _Db.tblLab.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("LabList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("LabList");
            }
        }
    }
}

