using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartexMVC.Models
{
    public class TaskDTO
    {
        public Int64 TaskID { get; set; }
       
        public int ProjectID { get; set; }

        public SelectListItem ProjectIDNews { get; set; }
        public int ProjectIDNew { get; set; }
        public string Task { get; set; }
        public string InitiatedBy { get; set; }
        [ForeignKey("ProjectID")]
        public virtual ProjectDTO ProjectDTO { get; set; }

        public string selectedValue { get; set; }

        public TaskDTO()
        {
            ProjectList = new List<SelectListItem>();
        }

        [DisplayName("ProjectName")]
        public List<SelectListItem> ProjectList { get; set; }

        public IEnumerable<SelectListItem> projectlist { get; set; }
        

    }


    public class TaskNewDTO
    {
        public Int64 TaskID { get; set; }

        public int ProjectID { get; set; }

       
        public int ProjectIDNew { get; set; }
        public string Task { get; set; }
        public string InitiatedBy { get; set; }

        public string selectedValue { get; set; }




        public IEnumerable<SelectListItem> projectlist { get; set; }


    }

    public class ProjectDTO
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public ProjectDTO()
        {
            ProjectList = new List<SelectListItem>();
        }

        [DisplayName("ProjectName")]
        public List<SelectListItem> ProjectList { get; set; }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        string ConStr = "Data Source=DESKTOP-3MD3TD4;Initial Catalog=HR;Integrated Security=True;TrustServerCertificate=True";
        public IEnumerable<ProjectDTO> GetProjectDetails()
        {

            List<Models.ProjectDTO> _task = new List<Models.ProjectDTO>();
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Select * from ProjectTbl", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Models.ProjectDTO Obj = new Models.ProjectDTO();
                    Obj.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    Obj.ProjectName = dr["ProjectName"].ToString();
                    _task.Add(Obj);
                }               


            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return _task;

        }


    }   
}