using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Yesbd
{
    public class DatabaseFunctions
    {
        public static String connection = ConfigurationManager.ConnectionStrings["Yes_bd"].ToString();

        public static void dropDownAdd(DropDownList ob, String sql)
        {
            List<String> List = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); List.Clear();
                //List.Add("Select");
                while (rd.Read())
                {
                    List.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                for (int i = 0; i < List.Count; i++)
                {
                    ob.Items.Add(List[i].ToString());
                }
            }
            catch { }
        }


        public static void dropDownAddWithSelect(DropDownList ob, String sql)
        {
            List<String> List = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); List.Clear();
                List.Add("Select");
                while (rd.Read())
                {
                    List.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                for (int i = 0; i < List.Count; i++)
                {
                    ob.Items.Add(List[i].ToString());
                }
            }
            catch { }
        }

        public static void dropDownAddSelectTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                listName.Add("--SELECT--");
                listValue.Add("--SELECT--");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void editableDropDownAdd(DropDownList ob, String sql)
        {
            List<String> List = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); List.Clear();
                List.Add("Select");
                while (rd.Read())
                {
                    List.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                for (int i = 0; i < List.Count; i++)
                {
                    ob.Items.Add(List[i].ToString());
                }
            }
            catch { }
        }

        public static void listAdd(ListBox ob, String sql)
        {
            List<String> List = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                List.Clear();
                while (rd.Read())
                {
                    List.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                for (int i = 0; i < List.Count; i++)
                {
                    ob.Items.Add(List[i].ToString());
                }
            }
            catch { }
        }
        public static void txtAdd(String sql, TextBox txtadd)
        {
            //String mystring = "";
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtadd.Text = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch { }
            //return List;
        }

        public static void lblAdd(String sql, Label lblAdd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblAdd.Text = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch { }
        }

        public static string StringData(String sql)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {

            }
            return data;
        }

        public static int IntegerData(String sql)
        {
            int data = 0;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = Convert.ToInt32(reader[0].ToString());
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                // ignored
            }
            return data;
        }

        public static void hdnAdd(String sql, HiddenField hdnAdd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hdnAdd.Value = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                // ignored
            }
        }


        public static void ltlAdd(String sql, Literal ltlAdd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ltlAdd.Text = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                // ignored
            }
        }

        public static void gridViewAdd(GridView ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch { }
            //return List;
        }
        public static string Dayformat(DateTime dt)
        {
            string mydate = dt.ToString("dd/MM/yyyy");
            return mydate;
        }
        public static string DayformatHifen(DateTime dt)
        {
            string mydate = dt.ToString("dd-MMM-yyyy");
            return mydate;
        }
        public static string TimeFormat(DateTime Tt)
        {
            string myTime = Tt.ToString("HH:mm:ss");
            return myTime;
        }
        public string monformat(DateTime mm)
        {
            string mymonth = mm.ToString("MMM");
            return mymonth;
        }

        public static DateTime Timezone(DateTime datetime)
        {
            TimeZoneInfo timeZoneInfo;
            //timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(datetime, timeZoneInfo);
            return PrintDate;
        }

        public static DateTime Dayformat1(DateTime dt)
        {
            TimeZoneInfo timeZoneInfo; timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            return PrintDate;
        }

        public static string IpAddress()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            return ipAddress.ToString();
        }

        public static string UserPc()
        {
            return Dns.GetHostName();
        }
    }
}