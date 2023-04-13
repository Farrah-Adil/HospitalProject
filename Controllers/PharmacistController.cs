using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HospitalProject.Controllers
{
    public class PharmacistController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}





        private readonly ProjectDbContext _Db;
        public PharmacistController(ProjectDbContext Db)

        {
            _Db = Db;
        }
        public IActionResult PharmacistList()
        {
            try
            {


                var PharmacistList = from a in _Db.tblPharmacist
                              join b in _Db.tblPharmacy
                              on a.PharmacyId equals b.PharmacyId
                              into Pharmacy
                              from b in Pharmacy.DefaultIfEmpty()




                              select new PharmacistEntity
                              {
                                  Name = a.Name,
                                  Age = a.Age,
                                  PhoneNo = a.PhoneNo,
                                  
                                  Gender = a.Gender,
                                  PharmacyId=a.PharmacyId,
                                  
                                  
                                 PharmacyName = b == null ? "" : b.PharName



                              };


                return View(PharmacistList);
            }
            catch (Exception ex)
            {
                return View();

            }

        }













        //Method to Load Categories in Add Item View Page

        private void loadPharmacy()
        {
            try
            {
                List<PharmacyEntity> PharmacyList = new List<PharmacyEntity>();
                PharmacyList = _Db.tblPharmacy.ToList();

                PharmacyList.Insert(0, new PharmacyEntity { PharmacyId = 0, PharName = "Please Select" });

                ViewBag.PharmacyList = PharmacyList;

            }
            catch (Exception ex)
            {


            }
        }








        
        public async Task<IActionResult> AddPharmacist(PharmacistEntity obj)
        {
            loadPharmacy();
            return View(obj);
        }
        public async Task<IActionResult> SavePharmacist(PharmacistEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.pharmacistId == 0)
                    {
                        _Db.tblPharmacist.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("PharmacistList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("PharmacistList");
            }
        }
        public async Task<IActionResult> DeletePharmacist(int pharmacistId)
        {
            try
            {
                var item = await _Db.tblPharmacist.FindAsync(pharmacistId);
                if (item != null)
                {
                    _Db.tblPharmacist.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("PharmacistList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("PharmacistList");
            }
        }
    }
}
    

