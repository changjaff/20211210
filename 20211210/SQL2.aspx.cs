using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; //必須先匯入
using System.Data.SqlClient; //必須先匯入

namespace _20211210
{
    public partial class SQL2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Data Source = (localdb)\\MSSQLLocalDB;
            //Initial Catalog = Test; Integrated Security = True;
            //Connect Timeout = 30; Encrypt = False;
            //TrustServerCertificate = False;
            //ApplicationIntent = ReadWrite; MultiSubnetFailover = False;
            //User ID = sa; Password = 12345

            string s_Conns = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;" + //必須要多斜線
                             "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                             "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                             "MultiSubnetFailover=False;" +
                             "User ID = sa; Password = 12345";

            try
            {
                SqlConnection o_Conn = new SqlConnection(s_Conns);
                SqlCommand o_Com = new SqlCommand("Select * from Users", o_Conn);
                o_Conn.Open();
                SqlDataReader o_R = o_Com.ExecuteReader();
                for (; o_R.Read();)
                {
                    for(int i_Col=0; i_Col < o_R.FieldCount; i_Col++)
                    {
                        Response.Write("&nbsp;&nbsp" + o_R[i_Col].ToString());
                    }
                    Response.Write("<br />");
                }
                o_Conn.Close();

            }

            catch (Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }

        }
    }
    }
