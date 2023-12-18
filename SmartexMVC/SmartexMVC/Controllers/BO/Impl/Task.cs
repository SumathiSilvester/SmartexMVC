using SmartexMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace SmartexMVC.Controllers.BO.Impl
{
    public class Task : ITask
    {
        static List<Task> _designation = new List<Task>();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        string ConStr = "Data Source=DESKTOP-3MD3TD4;Initial Catalog=HR;Integrated Security=True;TrustServerCertificate=True";

        //public IEnumerable<ProjectDTO> GetProjectList()
        //{
        //    List<Models.ProjectDTO> _task = new List<Models.ProjectDTO>();
        //    try
        //    {
        //        con = new SqlConnection(ConStr);
        //        con.Open();
        //        cmd = new SqlCommand("Select * from ProjectTbl", con);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Models.ProjectDTO Obj = new Models.ProjectDTO();
        //            Obj.ProjectID = Convert.ToInt32(dr["ProjectID"]);
        //            Obj.ProjectName = dr["ProjectName"].ToString();
        //            _task.Add(Obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return _task.AsEnumerable();
        //}
        public List<ProjectDTO> GetProjectDetails()
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
        public IEnumerable<ProjectDTO> GetProjectList()
        {
            List<ProjectDTO> Project = GetProjectDetails();
            return Project;
        }

        public List<Models.TaskDTO> GetTaskDetails()
        {
            List<Models.TaskDTO> _task = new List<Models.TaskDTO>();
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Select * from TaskTbl", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Models.TaskDTO Obj = new Models.TaskDTO();
                    Obj.TaskID = Convert.ToInt64(dr["TaskID"]);
                    Obj.Task = dr["Task"].ToString();
                    Obj.ProjectID =Convert.ToInt32( dr["ProjectID"]);
                    Obj.InitiatedBy = dr["InitiatedBy"].ToString();
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
    

        public Models.TaskDTO GetTskByProjectID(Int64 TaskID,int ID)
        {
            Models.TaskDTO task = GetTaskDetails().FirstOrDefault(e => e.ProjectID == ID);
            return task;
        }

        public int SaveProject(ProjectDTO objproject)
        {
            try {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("SaveProject_Insert_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectName", objproject.ProjectName);                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            { }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int SaveTask(Models.TaskDTO objtask)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("TaskProjectMappinp_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskID", 0);
                cmd.Parameters.AddWithValue("@Task", objtask.Task);
                cmd.Parameters.AddWithValue("@ProjectID", objtask.ProjectID);
                cmd.Parameters.AddWithValue("@InitiatedBy", objtask.InitiatedBy);                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int SaveTask(Models.TaskNewDTO objtask)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("TaskProjectMappinp_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskID", 0);
                cmd.Parameters.AddWithValue("@Task", objtask.Task);
                cmd.Parameters.AddWithValue("@ProjectID", objtask.ProjectID);
                cmd.Parameters.AddWithValue("@InitiatedBy", objtask.InitiatedBy);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int UpdateTask(Models.TaskDTO objtask, Int64 TaskID)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("TaskProjectMappinp_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskID", objtask.TaskID);
                cmd.Parameters.AddWithValue("@Task", objtask.Task);
                cmd.Parameters.AddWithValue("@ProjectID", objtask.ProjectID);
                cmd.Parameters.AddWithValue("@InitiatedBy", objtask.InitiatedBy);                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
    
}
