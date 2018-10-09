using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvc.QuickStart.Models;

namespace AspNetMvc.QuickStart.Controllers
{
    //[Authorize]
    public class StudentsController : Controller
    {
        private AppDbContext db = new AppDbContext();


        private List<SelectListItem> GetMajorList()
        {
            var majors = db.Students.OrderBy(m => m.Major).Select(m => m.Major).Distinct();

            var items = new List<SelectListItem>();
            foreach (string major in majors)
            {
                items.Add(new SelectListItem
                {
                    Text = major,
                    Value = major
                });
            }
            return items;
        }

        // GET: Students
        public ActionResult Index()
        {
            ViewBag.MajorList = GetMajorList();
            return View(db.Students.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Major, string Name)
        {
            var students = db.Students as IQueryable<Student>;
            if (!String.IsNullOrEmpty(Name))
            {
                students = students.Where(m => m.Name.Contains(Name));
            }

            if (!String.IsNullOrEmpty(Major))
            {
                students = students.Where(m => m.Major == Major);
            }

            ViewBag.MajorList = GetMajorList();
            return View(students.ToList());
        }

        // GET: Students
        //public ActionResult Index()
        //{
        //    var checkStudents = from c in db.Students
        //                        //where c.Major == "软件工程"
        //                        select c;
        //    return View(checkStudents.ToList());
        //}

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.GenderList = GetGenderList();
            return View();
        }

        // POST: Students/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Major,EntranceDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderList = GetGenderList();
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            //
            ViewBag.GenderList = GetGenderList();
            return View(student);
        }

        // POST: Students/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Major,EntranceDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderList = GetGenderList();
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<SelectListItem> GetGenderList()
        {
            return new List<SelectListItem>() {
              new SelectListItem
              {
                     Text = "男",
                     Value = "1"
              },new SelectListItem
              {
                     Text = "女",
                     Value = "0"
              }
       };
        }
    }
}
