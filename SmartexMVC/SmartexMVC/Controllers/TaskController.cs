using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using SmartexMVC.Controllers.BO.Impl;
using SmartexMVC.Models;

namespace SmartexMVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task


        //public ActionResult Index()
        //{
        //    //Task taskobj = new Task();
        //    //ModelState.Clear();
        //    //ViewData["Prolist"] = taskobj.GetProjectDetails();            
        //    //return View();

        //    ProjectDTO p = new ProjectDTO();
        //    List<ProjectDTO> Li = new List<ProjectDTO>();
        //    Li = p.GetProjectDetails();
        //    ViewData["Prolist"] = Li;
        //    return View();
        //}
        
        [HttpGet]
        public ActionResult AddTask( )
        {
            ProjectDTO p = new ProjectDTO();
            TaskNewDTO taskobj = new TaskNewDTO();
            //TaskDTO taskobj = new TaskNewDTO();
            //IEnumerable<SelectListItem> Ilist ;
            IEnumerable<ProjectDTO> Li = p.GetProjectDetails();
            // Li = p.GetProjectDetails();
            //ViewData["Prolist"] = Li.AsEnumerable();
            List<SelectListItem> project = new List<SelectListItem>();
            taskobj.projectlist = Li.Select(x=> new SelectListItem { Value=x.ProjectID.ToString(),Text=x.ProjectName});
            //foreach (var c in Li)
            //{
            //    project.Add(new SelectListItem
            //    {
            //        Text = c.ProjectName,
            //        Value = c.ProjectID.ToString()
            //    });
            //}
            //ViewData["Prolist"] = project;
            return View(taskobj);
        }



        [HttpPost]
        public ActionResult CreateTask(TaskNewDTO taskobj1)
        {

            Task taskobjne = new Task();
            taskobj1.ProjectID =Convert.ToInt32( taskobj1.selectedValue);
            if (taskobjne.SaveTask(taskobj1) == 0)
            {
                ViewBag.Message = "Task details added successfully";
            }

            ProjectDTO p = new ProjectDTO();
            TaskNewDTO taskobj = new TaskNewDTO();
            //taskobj.sav
            //IEnumerable<SelectListItem> Ilist ;
            IEnumerable<ProjectDTO> Li = p.GetProjectDetails();
            // Li = p.GetProjectDetails();
            //ViewData["Prolist"] = Li.AsEnumerable();
            List<SelectListItem> project = new List<SelectListItem>();
            taskobj.projectlist = Li.Select(x => new SelectListItem { Value = x.ProjectID.ToString(), Text = x.ProjectName });
            //foreach (var c in Li)
            //{
            //    project.Add(new SelectListItem
            //    {
            //        Text = c.ProjectName,
            //        Value = c.ProjectID.ToString()
            //    });
            //}
            //ViewData["Prolist"] = project;
            return View("~/views/Task/AddTask.cshtml" ,taskobj);
        }
         

        // GET: Task/Details/5
        [HttpGet]
        public ActionResult GetAllProject()
        {
            Task taskobj = new Task();            
            ModelState.Clear();
            ViewData["Prolist"] = taskobj.GetProjectDetails();
            return View(taskobj.GetProjectDetails());

        }
        [HttpGet]
        public ActionResult GetAllProjectList()
        {
            //Task taskobj = new Task();
            ProjectDTO obj = new ProjectDTO();
            IEnumerable<ProjectDTO> projectobj = obj.ProjectList as IEnumerable<ProjectDTO>;
            //projectobj = new SelectList(taskobj.GetProjectList(), "ProjectID", "ProjectName"); // model binding
            return View(projectobj);

        }
        [HttpGet]
        public ActionResult GetAllTask()
        {
            Task taskobj = new Task();
            ModelState.Clear();
            return View(taskobj.GetTaskDetails());
        }
        // GET: Task/ProjectIDs/5    
        public ActionResult GetTaskByPID(Int64 TaskID,int id)
        {
            Task taskobj = new Task();
            return View(taskobj.GetTskByProjectID(TaskID,id).ProjectID==id);

        }
        
        [HttpPost]
        public ActionResult AddTask(Models.TaskNewDTO task)
        {
            try
            {
                if (ModelState.IsValid)
                
                {
                    //ProjectDTO obj = new ProjectDTO();
                    
                   // ViewData["ProList"] = new SelectList(obj.GetProjectDetails(), "ProjectID", "ProjectName");
                    Task taskobj = new Task();

                    if (taskobj.SaveTask(task) == 0)
                    {
                        ViewBag.Message = "Task details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/EditTaskDetails/5
        [HttpGet]
        public ActionResult EditTaskDetails(Int64 id)
        {
            ProjectDTO p = new ProjectDTO();
            TaskNewDTO taskobjnew = new TaskNewDTO();            
            IEnumerable<ProjectDTO> Li = p.GetProjectDetails();            
            List<SelectListItem> project = new List<SelectListItem>();
            taskobjnew.projectlist = Li.Select(x => new SelectListItem { Value = x.ProjectID.ToString(), Text = x.ProjectName });
            Task taskobj = new Task();
            return View(taskobj.GetTaskDetails().Find(task => task.TaskID == id));

        }

        // POST: Task/EditTaskDetails/5    
        [HttpPost]

        public ActionResult EditTaskDetails(Int64 id, Models.TaskDTO obj)
        {
            try
            {
                Task taskobj = new Task();
                taskobj.UpdateTask(obj, id);
                ProjectDTO p = new ProjectDTO();
                TaskNewDTO taskobjnew = new TaskNewDTO();
                IEnumerable<ProjectDTO> Li = p.GetProjectDetails();
                List<SelectListItem> project = new List<SelectListItem>();
                taskobjnew.projectlist = Li.Select(x => new SelectListItem { Value = x.ProjectID.ToString(), Text = x.ProjectName });
                return RedirectToAction("GetAllTask");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddProject(Models.ProjectDTO project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Task taskobj = new Task();

                    if (taskobj.SaveProject(project) == 0)
                    {
                        ViewBag.Message = "Project details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


    }
}
