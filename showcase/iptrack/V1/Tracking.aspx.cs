using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Tracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string theUser;

        theUser = Server.UrlDecode(this.Request.Params["user"].Trim());
        //Label1.Text = Server.HtmlEncode(theUser);

        //string ClientHostName = Request.UserHostName.ToString();
        string ClientHostIP = Request.UserHostAddress.ToString();

        //Label1.Text = Server.HtmlEncode(theUser) +  ClientHostIP;

        if (theUser == "yyyako")
        {
            theUser = "yy-yako";
        }

        if (theUser == "gb2312")
        {
            theUser = "gb-2312";
        }

        InsertIPs(Server.HtmlEncode(theUser), ClientHostIP, System.DateTime.Now);
    }

    private void InsertIPs(string user, string clientIP, DateTime dt)
    {
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Belem_ADongNiConnectionString"].ToString());
        //objConn.Open();
        //string strSql = "BEL_IpsTracking";
        //SqlCommand strComm = new SqlCommand(strSql, objConn);
        //strComm.CommandType = CommandType.StoredProcedure;

        //SqlParameter[] parameters = new SqlParameter[]
        //{
        // new SqlParameter("@SpaceAlias",SqlDbType.VarChar,50),
        // new SqlParameter("@IPs",SqlDbType.VarChar,50),
        // new SqlParameter("@IPTime",SqlDbType.DateTime)
        //};

        //parameters[0].Value = user;
        //parameters[1].Value = clientIP;
        //parameters[2].Value = dt;

        //System.Data.SqlClient.SqlParameter[] sqlparas = new System.Data.SqlClient.SqlParameter[3];
        //sqlparas[0] = new System.Data.SqlClient.SqlParameter("@SpaceAlias", SqlDbType.VarChar, 50);
        //sqlparas[0].Value = user;
        //sqlparas[1] = new System.Data.SqlClient.SqlParameter("@IPs", SqlDbType.VarChar, 50);
        //sqlparas[1].Value = clientIP;
        //sqlparas[2] = new System.Data.SqlClient.SqlParameter("@IPTime", SqlDbType.DateTime);
        //sqlparas[2].Value = dt;

        //strComm.ExecuteNonQuery();
        //objConn.Close();



        try
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Belem_ADongNiConnectionString"].ToString());
            objConn.Open();

            SqlCommand cmd = objConn.CreateCommand();
            string strSql = "BEL_IpsTracking";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;

            cmd.Parameters.Clear();

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@SpaceAlias",SqlDbType.VarChar,50),
             new SqlParameter("@IPs",SqlDbType.VarChar,50),
             new SqlParameter("@IPTime",SqlDbType.DateTime)
            };

            parameters[0].Value = user;
            parameters[1].Value = clientIP;
            parameters[2].Value = dt;

            foreach (SqlParameter sqlp in parameters)
                cmd.Parameters.Add(sqlp);

            cmd.ExecuteNonQuery();
            objConn.Close();
        }

        catch 
        
        {
            ;
        }
    
    }
}
