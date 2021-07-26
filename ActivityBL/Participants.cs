using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ActivitiesBL
{
    public class Participants
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Participant"].ToString());
                sqlConObj.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong !");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstPart = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Participant"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Participants", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drPart = sqlCmdObj.ExecuteReader();
                while (drPart.Read())
                {
                    lstPart.Add(String.Concat(drPart["PSNo"] + "  ", drPart["ParticipantsName"] + "  ", drPart["ParticipantsEmailID"]));
                }
                return lstPart;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstPart;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
