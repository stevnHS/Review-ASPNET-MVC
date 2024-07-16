using Review_ASPNET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Review_ASPNET_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        dbEmpEntities db = new dbEmpEntities();
        // GET: Employees
        public ActionResult Index()
        {
            var emps = db.tEmployees.ToList();
            return View(emps);
        }


        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(tEmployee employee)
        {

            if (ModelState.IsValid)
            {
                // 判斷 id 是否重複，若重複就不新增
                ViewBag.Error = false;
                var temp = db.tEmployees
                    .Where(m => m.fEmpId == employee.fEmpId)
                    .FirstOrDefault();

                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(employee);
                }
                db.tEmployees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(employee);

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string fEmpid)
        {
            var employee = db.tEmployees.Where(m => m.fEmpId == fEmpid).FirstOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(tEmployee inputEmp)
        {
            if (!ModelState.IsValid) return View(inputEmp);

            // 若資料格式驗證成功，就修改資料
            var dbEmp = db.tEmployees
                .Where(e=>e.fEmpId==inputEmp.fEmpId)
                .FirstOrDefault();
            dbEmp.fName = inputEmp.fName;
            dbEmp.fSalary = inputEmp.fSalary;
            dbEmp.fGender = inputEmp.fGender;
            dbEmp.fMail = inputEmp.fMail;
            dbEmp.fEmploymentDate = inputEmp.fEmploymentDate;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string fEmpId)
        {
            var emp = db.tEmployees.FirstOrDefault(x=>x.fEmpId.Equals(fEmpId));
            db.tEmployees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
