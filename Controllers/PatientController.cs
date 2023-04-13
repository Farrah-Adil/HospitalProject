using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HospitalProject.Controllers
{
    public class PatientController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();

        private readonly ProjectDbContext _Db;
        public PatientController(ProjectDbContext Db)

        {
            _Db = Db;
        }


        public IActionResult PatientList()
        {
            try
            {

                var PatientList = from a in _Db.tblPatients
                                  join b in _Db.tblHospital
                                  on a.HosId equals b.HospitalId /*into Hospital*/
                                  join c in _Db.tblDepartments
                                  on a.DepId equals c.DepId
                                  //into departments
                                  //from b in Hospital.DefaultIfEmpty()
                                  //from c in departments.DefaultIfEmpty()


                                  select new PatientEntity
                                  {
                                      Name = a.Name,
                                      Age = a.Age,
                                      Gender = a.Gender,
                                      Address = a.Address,
                                      HosId = a.HosId,
                                      HosName = b == null ? "" : b.Name,
                                      DepId = a.DepId,
                                      DepName = c == null ? "" : c.DepName
                                  };


                return View(PatientList);
            }
            catch (Exception ex)
            {
                return View();

            }

        }







        //public IActionResult PatientList()
        //{
        //    try
        //    {


        //        var PatientList = from a in _Db.tblPatients
        //                          join b in _Db.tblHospital
        //                          on a.HosId equals b.HospitalId
        //                          into Hospital
        //                          from b in Hospital.DefaultIfEmpty()




        //                          select new PatientEntity
        //                          {
        //                              Name = a.Name,
        //                              Age = a.Age,
        //                              Gender = a.Gender,
        //                              Address = a.Address,
        //                              HosId = a.HosId,
        //                              HosName = b == null ? "" : b.Name



        //                          };


        //        return View(PatientList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();

        //    }

        //}





        //public IActionResult PatientList()
        //{
        //    try
        //    {


        //        var PatientList = from a in _Db.tblPatients
        //                          join b in _Db.tblDepartments
        //                          on a.DepId equals b.DepId
        //                          into Department
        //                          from b in Department.DefaultIfEmpty()




        //                          select new PatientEntity
        //                          {
        //                              Name = a.Name,
        //                              Age = a.Age,
        //                              Gender = a.Gender,
        //                              Address = a.Address,
        //                              DepId = a.DepId,
        //                              DepName = b == null ? "" : b.DepName



        //                          };


        //        return View(PatientList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();

        //    }

        //}

























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
  
        
        public async Task<IActionResult> AddPatient(PatientEntity obj)
        {
                loadDepartment();
            loadHospital();
            return View(obj);
        }
        public async Task<IActionResult> SavePatient(PatientEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.PtId == 0)
                    {
                        _Db.tblPatients.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("PatientList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("PatientList");
            }
        }
        public async Task<IActionResult> DeletePatient(int PtId)
        {
            try
            {
                var item = await _Db.tblPatients.FindAsync(PtId);
                if (item != null)
                {
                    _Db.tblPatients.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("PatientList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("PatientList");
            }
        }
    }
}