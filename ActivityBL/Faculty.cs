using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace ActivitiesBL
{
    public class Faculty
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Faculty"].ToString());
                sqlConObj.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstFaculty = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Faculty"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Faculty", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drFaculty = sqlCmdObj.ExecuteReader();
                while (drFaculty.Read())
                {
                    lstFaculty.Add(String.Concat(drFaculty["PSNO"] + "  ", drFaculty["EmailId"] + "  ", drFaculty["FacultyName"]));
                }
                return lstFaculty;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstFaculty;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
