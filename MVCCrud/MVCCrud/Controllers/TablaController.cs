using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CRUDREntities db = new CRUDREntities())
            {
                lst = (from d in db.PERSONAL
                           select new ListTablaViewModel
                           {
                               ID = d.ID,
                               NOMBRE = d.NOMBRE,
                               APELLIDO_P = d.APELLIDO_P,
                               APELLIDO_M = d.APELLIDO_M,
                               EDAD =(int) d.EDAD,
                               IsActive = (bool) d.IsActive
                           }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDREntities db = new CRUDREntities())
                    {
                        var oTabla = new PERSONAL();
                        oTabla.NOMBRE = model.NOMBRE;
                        oTabla.APELLIDO_P = model.APELLIDO_P;
                        oTabla.APELLIDO_M = model.APELLIDO_M;
                     oTabla.EDAD = model.EDAD;
                        oTabla.IsActive = model.IsActive;

                        db.PERSONAL.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int ID)
        {
            TablaViewModel model = new TablaViewModel();
            using (CRUDREntities db= new CRUDREntities())
            {
                var oTabla = db.PERSONAL.Find(ID);
                model.NOMBRE = oTabla.NOMBRE;
                model.APELLIDO_P = oTabla.APELLIDO_P;
                model.APELLIDO_M = oTabla.APELLIDO_M;
                model.EDAD =(int)oTabla.EDAD;
                model.IsActive = (bool) oTabla.IsActive;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDREntities db = new CRUDREntities())
                    {
                        var oTabla = db.PERSONAL.Find(model.ID);
                        oTabla.NOMBRE = model.NOMBRE;
                        oTabla.APELLIDO_P = model.APELLIDO_P;
                        oTabla.APELLIDO_M = model.APELLIDO_M;
                        oTabla.EDAD = model.EDAD;
                        oTabla.IsActive = model.IsActive;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int ID)
        {
            using (CRUDREntities db = new CRUDREntities())
            {
              
                var oTabla = db.PERSONAL.Find(ID);
                db.PERSONAL.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }

    }
}