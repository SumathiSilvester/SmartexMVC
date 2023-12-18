using System.Collections.Generic;
using System.Web.Mvc;
using SmartexMVC.Controllers.BO;
using SmartexMVC.Controllers.BO.Impl;


namespace SmartexMVC.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation/GetAllDesignationDetails    
        public ActionResult GetAllDesignation()
        {

            Designation desigobj = new Designation();
            ModelState.Clear();
            return View(desigobj.GetDesignation());
        }
        // GET: Designation/AddDesignation  
        [HttpGet]
        public ActionResult AddDesignation()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        // POST: Designation/AddDesignation   
        [HttpPost]
        public ActionResult AddDesignation(Models.Designation Desig)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Designation desigobj = new Designation();

                    if (desigobj.SaveDesignation(Desig) == 0)
                    {
                        ViewBag.Message = "Designation details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Designation/EditDesignationDetails/5    
        public ActionResult EditDesignationDetails(int id)
        {
            Designation desigobj = new Designation();
            return View(desigobj.GetDesignation().Find(desig => desig.DesigID == id));

        }

        // POST: Designation/EditDesignationDetails/5    
        [HttpPost]

        public ActionResult EditDesignationDetails(int id, Models.Designation obj)
        {
            try
            {
                Designation desigobj = new Designation();

                desigobj.UpdateDesignation(obj, id);
                return RedirectToAction("GetAllDesignation");
            }
            catch
            {
                return View();
            }
        }

        // GET: Designation/DeleteDesig/5    
        [HttpDelete]
        public ActionResult DeleteDesignation(int id)
        {
            try
            {
                Designation desigobj = new Designation();
                if (desigobj.DeleteDesignation(id) == 0)
                {
                    ViewBag.AlertMsg = "Designation details deleted successfully";

                }
                return RedirectToAction("GetAllDesignationDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}