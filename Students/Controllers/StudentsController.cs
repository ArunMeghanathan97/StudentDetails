using Students.ListAdapter;
using Students.Models;
using Students.Models.Repository;
using Students.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {
        StudentRepository db = new StudentRepository();
        //
        // GET: /Students/

        public ActionResult Index()
        {
            Dictionary<string, string> dictionary = null ;
            List<Dictionary<string, string>> pass = null;
            try
            {
                var model = (from stu in db.Student
                             join add in db.Address on stu.StudentsId equals add.StudentsId into bookingmGroup
                             from add_value in bookingmGroup.DefaultIfEmpty()
                             select new
                             {
                                 StudentsId = stu.StudentsId,
                                 Name = stu.Name,
                                 Mobile = stu.Mobile,
                                 Email = stu.Email,
                                 Address = add_value.Street + ", " + add_value.City + ", " + add_value.State + ", " + add_value.Country
                             }).ToList();
                 if (model != null)
                {
                    pass = new List<Dictionary<string, string>>();
                    foreach (var item in model)
                    {
                        dictionary = new  Dictionary<string, string>();
                        dictionary.Add("Name", item.Name);
                        dictionary.Add("Mobile", item.Mobile);
                        dictionary.Add("Email", item.Email);
                        dictionary.Add("Address", item.Address);
                        dictionary.Add("StudentsId", item.StudentsId+"");
                        pass.Add(dictionary);
                    }
                }
            }catch(Exception e){
                Response.Write("<script>alert('"+e.Message+"')</script>");
            }
            ViewBag.listVal = pass;
            return View("");
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include="Name,Mobile,Email")]Student student)
        {
            if (ModelState.IsValid) {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult AddAddress() {
            var list = new List<MyListTable>();
            var user = db.Student.ToList();
            var add = db.Address.ToList();
            Boolean flg=false;
            foreach(var item in user){
                flg = false;
                foreach (var it in add) 
                    if (it.StudentsId == item.StudentsId) flg = true;
                
                if (flg == false)
                    list.Add(new MyListTable
                    {
                        Key = item.StudentsId.ToString(),
                        Display = item.Name
                    });                
            }
            ViewBag.Std = new SelectList(list, "Key", "Display");
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress([Bind(Include = "Street,City,State,Country,StudentsId")]Address address) {
            if (ModelState.IsValid) {
                db.Address.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        [HttpGet]
        public ActionResult Edit(int StudentsId)
        {
            if (StudentsId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Student.Find(StudentsId);
            if (model == null) {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include="StudentsId,Name,Mobile,Email")]Student student) {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult ChangeAddress(int StudentsId)
        {
            if (StudentsId == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var address = db.Address.ToList();
            ViewBag.address = address;
            ViewBag.StudentsId = StudentsId;
            return View("");
        }

        [HttpPost]
        public ActionResult ChangeAddress(int StudentsId, int Id=0, int rm=0)
        {
            if (StudentsId == null || Id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Id == 0) {
                return RedirectToAction("Index");
            }else{
                List<Address> results = (from a in db.Address where a.StudentsId == StudentsId select a).ToList();
                foreach (var a in results)
                {
                    a.StudentsId = 0;
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                }
                Address add = new Address();
                add = (from ad in db.Address where ad.Id == Id select ad).SingleOrDefault();
                if (rm == 0)
                {
                    add.StudentsId = StudentsId;
                }
                else
                {
                    int temp = new int();
                    temp = 0;
                    add.StudentsId = temp;
                }
                db.Entry(add).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
