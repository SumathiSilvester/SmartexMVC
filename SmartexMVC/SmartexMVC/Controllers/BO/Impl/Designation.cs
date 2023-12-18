using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace SmartexMVC.Controllers.BO.Impl
{
    public class Designation : IDesignation
    {
        static List<Designation> _designation = new List<Designation>();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        string ConStr = "Data Source=DESKTOP-3MD3TD4;Initial Catalog=HR;Integrated Security=True;TrustServerCertificate=True";
        

        public Models.Designation GetDesigantionByID(int ID)
        {
            Models.Designation designation = GetDesignation().FirstOrDefault(e => e.DesigID == ID);
            return designation;
            //List<SmartexMVC.Models.Designation> _designations = new List<SmartexMVC.Models.Designation>();
            //try
            //{
            //    con = new SqlConnection(ConStr);
            //    con.Open();
            //    cmd = new SqlCommand("Select * from Designation Where DesigID="+DesigID, con);
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        SmartexMVC.Models.Designation Obj = new SmartexMVC.Models.Designation();
            //        Obj.DesigID = Convert.ToInt32(dr["Desigid"]);
            //        Obj.DesigName = dr["DesigName"].ToString();
            //        _designations.Add(Obj);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    con.Close();
            //}
            //return _designations;
        }

        public List<Models.Designation> GetDesignation()
        {
            List<SmartexMVC.Models.Designation> _designations = new List<SmartexMVC.Models.Designation>();
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Select * from Designation", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SmartexMVC.Models.Designation Obj = new SmartexMVC.Models.Designation();
                    Obj.DesigID = Convert.ToInt32(dr["Desigid"]);
                    Obj.DesigName = dr["DesigName"].ToString();
                    _designations.Add(Obj);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return _designations;
        }

        public int SaveDesignation(Models.Designation objdesig)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Designation_Crud_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DesigName", objdesig.DesigName);
                cmd.Parameters.AddWithValue("@SavedBy", System.Web.HttpContext.Current.Session["UserName"]);
                cmd.Parameters.AddWithValue("@DesigID", 0);
                cmd.Parameters.AddWithValue("@Flag", 0);                
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

        public int UpdateDesignation(Models.Designation objdesig, int DesigID)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Designation_Crud_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DesigName", objdesig.DesigName);
                cmd.Parameters.AddWithValue("@SavedBy", System.Web.HttpContext.Current.Session["UserName"]);
                cmd.Parameters.AddWithValue("@DesigID", DesigID);
                cmd.Parameters.AddWithValue("@Flag", 1);
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
        public int DeleteDesignation(int desigid)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("Designation_Crud_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DesigName", "");
                cmd.Parameters.AddWithValue("@SavedBy", System.Web.HttpContext.Current.Session["UserName"]);
                cmd.Parameters.AddWithValue("@DesigID", 0);
                cmd.Parameters.AddWithValue("@Flag", 2);
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