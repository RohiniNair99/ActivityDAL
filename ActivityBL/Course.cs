using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ActivitiesBL
{
    public class Course
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Course"].ToString());
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
            List<String> lstCourses = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Course"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Courses", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drCourses = sqlCmdObj.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(String.Concat(drCourses["CourseId"] + "  ", drCourses["CourseTitle"] + "  ", drCourses["CourseDuration"] + "  ", drCourses["CourseMode"] + "  ", drCourses["Curriculum"]));
                }
                return lstCourses;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstCourses;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
