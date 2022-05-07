using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;using System.Diagnostics;

namespace DotNetAppSqlDb.Controllers
{
    public class TodosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Todos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {

            Trace.WriteLine("GET /Todos/Index1");
            return View(db.Todoes.ToList());
        }
        /*
        public ActionResult Index([Bind(Include = "Name")] Todo todo)
        {

            Trace.WriteLine("GET /Todos/IndexDet");


            TodoDetail todo1 = db.TodoesDet.Find(name);

            return View(db.Todoes.ToList());
        }
        */
        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            Trace.WriteLine("GET /Todos/Details/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Todos/Create");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Category,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Todos/Create");
            if (ModelState.IsValid)
            {
                db.Todoes.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Todos/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Category,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Todos/Edit/" + todo.ID);
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Todos/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Todos/Delete/" + id);
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------------------------
        
        public ActionResult IndexDet()
        {
            
            Trace.WriteLine("GET /Todos/IndexDet");
            return View(db.TodoesDet.ToList());
        }
        
        [HttpGet]
        
        public ActionResult IndexDet1(Todo todo)
        {
            
            Trace.WriteLine("GET /Todos/IndexDet");
            return View(db.TodoesDet.SqlQuery("select * from TodoDetails where name = @p0",todo.Name).ToList());
        }




        // GET: Todos/Details/5
        public ActionResult DetailsDet(int? id)
        {
            Trace.WriteLine("GET /Todos/DetailsDet/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todo = db.TodoesDet.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todos/Create
        public ActionResult CreateDet()
        {
            Trace.WriteLine("GET /Todos/CreateDet");
            return View(new TodoDetail { value = 0 });
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDet([Bind(Include = "Name,Category,year,value,country")] TodoDetail todo)
        {
            Trace.WriteLine("POST /Todos/CreateDet");
            if (ModelState.IsValid)
            {
                db.TodoesDet.Add(todo);
                db.SaveChanges();
                return RedirectToAction("IndexDet");
            }

            return View(todo);
        }

        // GET: Todos/Edit/5
        public ActionResult EditDet(int? id)
        {
            Trace.WriteLine("GET /Todos/EditDet/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todo = db.TodoesDet.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDet([Bind(Include = "id,Name,Category,year,value,country")] TodoDetail todo)
        {
            Trace.WriteLine("POST /Todos/EditDet/" + todo.ID);
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDet");
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public ActionResult DeleteDet(int? id)
        {
            Trace.WriteLine("GET /Todos/DeleteDet/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoDetail todo = db.TodoesDet.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("DeleteDet")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedDet(int id)
        {
            Trace.WriteLine("POST /Todos/DeleteDet/" + id);
            TodoDetail todo = db.TodoesDet.Find(id);
            db.TodoesDet.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("IndexDet");
        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
