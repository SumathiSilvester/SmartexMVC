using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DBCon"]);
        //public string SessionUserName;
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult AddTask()
        {
            return View();
        }
        public ActionResult EditTaskDetails()
        {
            return View();
        }

        public JsonResult LoginUser(loginMaster p)
        {
            try
            {

                DataTable dt = getLoginDetails(p, "USER_LOGIN");
                if (dt != null && dt.Rows.Count > 0)
                {
                    p.UserName = dt.Rows[0]["UserName"].ToString();
                    System.Web.HttpContext.Current.Session["UserName"] = p.UserName;
                }
                else
                {
                    p.UserName = "0";
                }
            }
            catch (Exception)
            {
                p.UserName = "0";
            }
            return Json(p, JsonRequestBehavior.AllowGet);
        }
        public DataTable getLoginDetails(loginMaster Objp, string ProcName)
        {
            DataTable dtt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName",Objp.UserName),
                new SqlParameter("@password",Objp.Password)
            };
            dtt = ExecProcDataTable(ProcName, param);
            return dtt;
        }
        public DataTable ExecProcDataTable(string ProName, SqlParameter[] Param)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(ProName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter prm in Param)
                {
                    cmd.Parameters.Add(prm);
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public class loginMaster
        {
            public string UserName { get; set; }
            
            public string Password { get; set; }
        }
       
    }
}
