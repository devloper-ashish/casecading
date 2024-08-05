using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                CountryBind();

            }

    }



    protected void CountryBind()
    {
        DataSet ds = new DataSet();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_country_all", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
               
            }
        }
        ddlCountry.Items.Clear();
        if (ds != null)
        {
            if (ds.Tables.Count >0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountry.DataSource = ds;
                    ddlCountry.DataTextField = "cntryName";
                    ddlCountry.DataValueField = "cntryID";
                    ddlCountry.DataBind();
                }
            }
        }

        ddlCountry.Items.Insert(0, new ListItem("Select", "0"));


    }
    protected void StateBind(string id)
    {
        DataSet ds = new DataSet();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("ups_tbl_State_GetByCountryId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }
        ddlstate.Items.Clear();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlstate.DataSource = ds;
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataValueField = "stateID";
                    ddlstate.DataBind();
                }
            }
        }
        ddlstate.Items.Insert(0, new ListItem("Select", "0"));


    }

     


    protected void DistBind(string id)
    {
        DataSet ds = new DataSet();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("ups_tbl_dist_GetByStateId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stateID", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }
        ddldist.Items.Clear();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddldist.DataSource = ds;
                    ddldist.DataTextField = "distName";
                    ddldist.DataValueField = "distId";
                    ddldist.DataBind(); 
                }
            }
        }
        ddldist.Items.Insert(0, new ListItem("Select", "0"));


    }




    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateBind(ddlCountry.SelectedValue);
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DistBind(ddlstate.SelectedValue);
    }
}
