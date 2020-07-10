using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Sql_lists_QueryMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_dropdowns();
            }
        }


        void fill_ddl_Connection()
        {
            Logger.Info("Fill DDL Connection has been called");
            try
            {
                ddl_Connecion.DataSource = CreateDataSource();
                ddl_Connecion.DataTextField = "Text";
                ddl_Connecion.DataValueField = "Value";
                ddl_Connecion.DataBind();
                Logger.Info("Fill DDL Connection success");
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }

            //txt_UserName.Text = login(ddl_caller.SelectedValue);
            //txt_Password.Text = password(ddl_caller.SelectedValue);
        }

        ICollection CreateDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Text", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));

            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/sql_master_query.csv")))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    dt.Rows.Add(CreateRow(values[0], values[1], dt));
                }
            }
            DataView dv = new DataView(dt);
            return dv;
        }

        void fill_ddl_databases()
        {
            Logger.Info("Fill DDL Databases has been called");
            try
            {
                ddl_databases.DataSource = CreateDataSource_DataTable(1);
                ddl_databases.DataTextField = "Text";
                ddl_databases.DataValueField = "Value";
                ddl_databases.DataBind();
                Logger.Info("Fill DDL Databases success");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        void fill_ddl_tables()
        {
            Logger.Info("Fill DDL Tables has been called");
            try
            {
                ddl_tables.DataSource = CreateDataSource_DataTable(2);
                ddl_tables.DataTextField = "Text";
                ddl_tables.DataValueField = "Value";
                ddl_tables.DataBind();
                Logger.Info("Fill DDL Databases success");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        void fill_ddl_columns()
        {
            Logger.Info("Fill DDL Columns has been called");
            try
            {
                ddl_columns.DataSource = CreateDataSource_DataTable(3);
                ddl_columns.DataTextField = "Text";
                ddl_columns.DataValueField = "Value";
                ddl_columns.DataBind();
                Logger.Info("Fill DDL Databases success");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        ICollection CreateDataSource_DataTable(int Case)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Text", typeof(string)));
                dt.Columns.Add(new DataColumn("Value", typeof(string)));

                DataTable dt_db = null;

                switch(Case)
                {
                    case 1:
                        Logger.Info("Run Query; Connection:" + ddl_Connecion.SelectedItem.Text);
                        dt_db = Run_Query_DataBases(ddl_Connecion.SelectedItem.Text);
                        break;
                    case 2:
                        Logger.Info("Run Query; Connection:" + ddl_Connecion.SelectedItem.Text + " Database:" + ddl_databases.SelectedItem.Text);
                        dt_db = Run_Query_Tables(ddl_Connecion.SelectedItem.Text,ddl_databases.SelectedItem.Text);
                        break;
                    case 3:
                        Logger.Info("Run Query; Connection:" + ddl_Connecion.SelectedItem.Text + " Database:" + ddl_databases.SelectedItem.Text + " Table:" + ddl_tables.SelectedItem.Text);
                        dt_db = Run_Query_Columns(ddl_Connecion.SelectedItem.Text, ddl_databases.SelectedItem.Text, ddl_tables.SelectedItem.Text);
                        break;
                }
                if (dt_db != null)
                {
                    Logger.Info("Query returned not null");
                    if (dt_db.Rows.Count > 0)
                    {
                        Logger.Info("DataTable has " + dt_db.Rows.Count + " rows");
                        for (int i = 0; i < dt_db.Rows.Count; i++)
                        {
                            dt.Rows.Add(CreateRow(dt_db.Rows[i]["Row#"].ToString(), dt_db.Rows[i]["name"].ToString(), dt));
                        }
                        Logger.Info("All rows added");
                    }
                    DataView dv = new DataView(dt);
                    return dv;
                }
                else
                {
                    Logger.Info("Null returned");
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        DataRow CreateRow(string Text, string Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Value;
            dr[1] = Text;

            return dr;
        }

        

        private void fill_dropdowns()
        {
            Logger.Info("Fill DropDowns has been called");
            try
            {
                fill_ddl_Connection();
                //fill_ddl_databases();
                //fill_ddl_tables();
                //fill_ddl_columns();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private DataTable Run_Query_DataBases(string connection)
        {
            return ExtraClasses.SQL_Master.Execute_Query(connection, "select ROW_NUMBER() OVER(ORDER BY name ASC) AS Row#,name from master.dbo.sysdatabases order by name asc");
        }

        private DataTable Run_Query_Tables(string connection,string database)
        {
            return ExtraClasses.SQL_Master.Execute_Query(connection, "USE " + database + " select ROW_NUMBER() OVER(ORDER BY name ASC) AS Row#,name from sys.tables order by name asc");
        }

        private DataTable Run_Query_Columns(string connection,string database,string tablename)
        {
            return ExtraClasses.SQL_Master.Execute_Query(connection, "use " + database + " select ROW_NUMBER() OVER(ORDER BY Column_Name ASC) AS Row#,Column_Name as 'name' from Information_Schema.Columns where table_Name = '" + tablename+"'");
        }

        private DataTable Run_Query_Grid(string connection,string database,string tablename,string column)
        {
            return ExtraClasses.SQL_Master.Execute_Query(connection, "use " + database + " select top 5 * from ["+database+"].[dbo].[" + tablename + "] order by " + column + " asc  ");
        }

        private DataTable Run_Query_Master(string connection, string database, string Query)
        {
            return ExtraClasses.SQL_Master.Execute_Query(connection, "use " + database + " " + Query);
        }

        private void nullify()
        {
            //ddl_Connecion.DataSource = null;
            ddl_databases.DataSource = null;
            ddl_tables.DataSource = null;
            ddl_columns.DataSource = null;

            pnl_database.Visible = false;
            pnl_table.Visible = false;
            pnl_columns.Visible = false;
            pnl_submit.Visible = false;
            grid_view.DataSource = null;
            grid_view.DataBind();
        }

        protected void ddl_Connecion_SelectedIndexChanged(object sender, EventArgs e)
        {
            nullify();
            pnl_database.Visible = true;
            fill_ddl_databases();
        }

        protected void ddl_databases_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nullify();
            grid_view.DataSource = null;
            grid_view.DataBind();

            pnl_table.Visible = true;
            fill_ddl_tables();
        }

        protected void ddl_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nullify();
            grid_view.DataSource = null;
            grid_view.DataBind();

            pnl_columns.Visible = true;
            pnl_submit.Visible = true;
            fill_ddl_columns();
            grid_view.DataSource = Run_Query_Grid(ddl_Connecion.SelectedItem.Text, ddl_databases.SelectedItem.Text, ddl_tables.SelectedItem.Text, ddl_columns.SelectedItem.Text);
            grid_view.DataBind();
        }

        protected void ddl_columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_view.DataSource = Run_Query_Grid(ddl_Connecion.SelectedItem.Text, ddl_databases.SelectedItem.Text, ddl_tables.SelectedItem.Text, ddl_columns.SelectedItem.Text);
            grid_view.DataBind();
        }

        protected void grid_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Logger.Info("Submitting query to be executed");
            try
            {
                if (txt_richbox.InnerText.Length > 0) 
                {
                    string checker = txt_richbox.InnerText.ToUpper();
                    if (!checker.Contains("UPDATE") && !checker.Contains("INSERT"))
                    {
                        Logger.Info("Query:" + txt_richbox.InnerText);
                        grid_view.DataSource = Run_Query_Master(ddl_Connecion.SelectedItem.Text, ddl_databases.SelectedItem.Text, txt_richbox.InnerText);
                        grid_view.DataBind();
                    }
                    else
                    {
                        lbl_result.Text = "You shall not pass !";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}