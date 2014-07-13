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

        string myRealAddress = null;
        try
        {
            IPTracker ipt = new IPTracker();
            myRealAddress = ipt.GetIpRealWorldAddress(ClientHostIP);
        }
        catch
        {
            myRealAddress = "δ֪��ַ - BELEM";
        }

        try
        {
            checkFilter(theUser, ClientHostIP, myRealAddress);
        }
        catch
        {
            ;
        }

        
    }

    private void checkFilter(string theUser, string CurrentClientIP, string theRealAddress)
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString();
        
        string sqlC = "SELECT DISTINCT [SpaceAlias], [FilterIP] FROM [IPTrackIPFilter] WHERE (SpaceAlias = '"+ theUser +"')";
        SqlDataAdapter dadpt = new SqlDataAdapter(sqlC, connstr);
        DataSet ds = new DataSet();
        dadpt.Fill(ds, "ips");

        int i = 0;

        int j = 0;

        for (i = 0; i < ds.Tables["ips"].Rows.Count; i++)
        {
            string sFilterIP = ds.Tables["ips"].Rows[i]["FilterIP"].ToString();
            if (CurrentClientIP == sFilterIP)
            {
                j++;
            }

        }

        if (j == 0)
        {
            InsertIPs(Server.HtmlEncode(theUser), CurrentClientIP, System.DateTime.Now, theRealAddress);
        }

        ds.Clear();
        dadpt.Dispose();

    }

    private void InsertIPs(string user, string clientIP, DateTime dt, string realAddress)
    {
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString());
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
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString());
            objConn.Open();

            SqlCommand cmd = objConn.CreateCommand();
            string strSql = "BEL_IpsTrackingV2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;

            cmd.Parameters.Clear();

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@SpaceAlias",SqlDbType.VarChar,50),
             new SqlParameter("@IPs",SqlDbType.VarChar,50),
             new SqlParameter("@IPTime",SqlDbType.DateTime),
             new SqlParameter("@RealAddress",SqlDbType.NVarChar,128)
            };

            parameters[0].Value = user;
            parameters[1].Value = clientIP;
            parameters[2].Value = dt;
            parameters[3].Value = realAddress;

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
