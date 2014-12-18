using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Mobile 的摘要说明
/// </summary>
public class Mobile
{
	public Mobile()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    

    public Dictionary<string,string> GetMobileArea(string MobileNumber)
    {
        using (SqlConnection cn = new SqlConnection(DBConnect.GetDbStringOfLink()))
        {
            string number = (MobileNumber.Length > 7) ? MobileNumber.Substring(0, 7) : "0";
            string sqlstr = @"select * from dm_mobile where mobilenumber=@mobilenumber";
            SqlCommand cmd = new SqlCommand(sqlstr, cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@mobilenumber", SqlDbType.VarChar, 10).Value = number;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MobileProv", "");
            dic.Add("MobileCity", "");
            string[] str;
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                str = rd["mobileArea"].ToString().Split(' ');
                dic["MobileProv"] = str[0];
                dic["MobileCity"] = str[1];
            }
            rd.Close();
            cn.Close();
            return dic;
        }
    }

    public DataSet GetLink()
    {
        using (SqlConnection cn = new SqlConnection(DBConnect.GetDbStringOfLink()))
        {
            string sqlstr = @"select 会员名称,登录名,联系人手机,归属地A1='',归属地A2='',直接人手机,归属地B1='',归属地B2='' from linkman";
            SqlCommand cmd = new SqlCommand(sqlstr, cn);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(ds);
            cn.Close();
            //循环查询归属地
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dic = GetMobileArea(row["联系人手机"].ToString());
                row["归属地A1"] = dic["MobileProv"];
                row["归属地A2"] = dic["MobileCity"];
            }
            return ds;
        }
    }

    public DataSet GetLinkYCJ_GR()
    {
        using (SqlConnection cn = new SqlConnection(DBConnect.GetDbStringOfLink()))
        {
            string sqlstr = @"select 排名,会员名称,直接人手机,归属地A1='',归属地A2='' from ycj_gr";
            SqlCommand cmd = new SqlCommand(sqlstr, cn);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(ds);
            cn.Close();
            //循环查询归属地
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dic = GetMobileArea(row["直接人手机"].ToString());
                row["归属地A1"] = dic["MobileProv"];
                row["归属地A2"] = dic["MobileCity"];
            }
            return ds;
        }
    }

    public DataSet GetLinkYCJ_GS()
    {
        using (SqlConnection cn = new SqlConnection(DBConnect.GetDbStringOfLink()))
        {
            string sqlstr = @"select 排名,会员名称,直接人手机,归属地A1='',归属地A2='' from ycj_gs";
            SqlCommand cmd = new SqlCommand(sqlstr, cn);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(ds);
            cn.Close();
            //循环查询归属地
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dic = GetMobileArea(row["直接人手机"].ToString());
                row["归属地A1"] = dic["MobileProv"];
                row["归属地A2"] = dic["MobileCity"];
            }
            return ds;
        }
    }

    public DataSet GetLinkYCJ_HC()
    {
        using (SqlConnection cn = new SqlConnection(DBConnect.GetDbStringOfLink()))
        {
            string sqlstr = @"select 地区,公司,联系人,电话,归属地A1='',归属地A2='' from ycj_hc";
            SqlCommand cmd = new SqlCommand(sqlstr, cn);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(ds);
            cn.Close();
            //循环查询归属地
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dic = GetMobileArea(row["电话"].ToString());
                row["归属地A1"] = dic["MobileProv"];
                row["归属地A2"] = dic["MobileCity"];
            }
            return ds;
        }
    }


}