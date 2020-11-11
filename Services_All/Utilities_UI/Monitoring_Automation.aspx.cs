using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Monitoring_Automation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                SetObj();
                if (!Page.IsPostBack)
                {
                   
                    Load_DDL();
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.InnerException + ex.Message;
            }

        }

        private ExtraClasses.Monitoring_Automation obj;
        private void SetObj()
        {
            try
            {
                ExtraClasses.Monitoring_Automation obj = new ExtraClasses.Monitoring_Automation();
                this.obj = obj;
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }

        protected void ddl_operations_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_operations.SelectedValue.ToLower() == "service")
                {
                    pnl_server.Visible = false;
                    pnl_logs.Visible = false;
                    pnl_service.Visible = true;
                }
                else if (ddl_operations.SelectedValue.ToLower() == "log")
                {
                    pnl_server.Visible = false;
                    pnl_logs.Visible = true;
                    pnl_service.Visible = false;
                }
                else if (ddl_operations.SelectedValue.ToLower() == "server")
                {
                    pnl_server.Visible = true;
                    pnl_logs.Visible = false;
                    pnl_service.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.InnerException + ex.Message;
            }
        }

        protected void Load_DDL()
        {
            try
            {
                DataTable dt_client = obj.Get_Clients();

                ddl_client.DataSource = dt_client;
                ddl_client.DataValueField = "Id";
                ddl_client.DataTextField = "Description";
                ddl_client.DataBind();

                DataTable dt_product = obj.Get_Products(int.Parse(ddl_client.Items[0].Value));
                ddl_products.DataSource = dt_product;
                ddl_products.DataValueField = "Id";
                ddl_products.DataTextField = "Description";
                ddl_products.DataBind();


                DataTable dt_service = obj.Get_Services(int.Parse(ddl_products.Items[0].Value));
                ddl_services.DataSource = dt_service;
                ddl_services.DataValueField = "Id";
                ddl_services.DataTextField = "Description";
                ddl_services.DataBind();


                DataTable dt_Logs = obj.Get_Logs(int.Parse(ddl_services.Items[0].Value));
                if (dt_Logs != null)
                    if (dt_Logs.Rows.Count > 0)
                    {
                        ddl_logs.DataSource = dt_Logs;
                        ddl_logs.DataValueField = "Id";
                        ddl_logs.DataTextField = "Description";
                        ddl_logs.DataBind();
                    }
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }
        protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_products.DataSource = obj.Get_Products(int.Parse(ddl_client.SelectedValue));
                ddl_products.DataBind();
                ddl_services.DataSource = obj.Get_Services(int.Parse(ddl_products.SelectedValue));
                ddl_services.DataBind();
                ddl_logs.DataSource = obj.Get_Logs(int.Parse(ddl_services.SelectedValue));
                ddl_logs.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }
        protected void ddl_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_services.DataSource = obj.Get_Services(int.Parse(ddl_products.SelectedValue));
                ddl_services.DataBind();

                if (ddl_services.SelectedValue.Length > 0)
                {
                    ddl_logs.DataSource = obj.Get_Logs(int.Parse(ddl_services.SelectedValue));
                    ddl_logs.DataBind();
                }
                else
                {
                    ddl_logs.DataSource = null;
                    ddl_logs.DataBind();
                }


            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }
        protected void ddl_services_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_logs.DataSource = obj.Get_Logs(int.Parse(ddl_services.SelectedValue));
                ddl_logs.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }

        protected void btn_service_Click(object sender, EventArgs e)
        {
            try
            {
                string operation = rdl_servicesoperation.SelectedValue.ToLower();
                txt_richbox.InnerText = obj.Service(operation, int.Parse(ddl_services.SelectedValue));

            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }
        protected void btn_logs_Click(object sender, EventArgs e)
        {
            try
            {
                string operation = rdl_logs.SelectedValue.ToLower();
                string lines = txt_logs_numberoflines.Text;
                txt_richbox.InnerText = obj.Log(operation, lines, int.Parse(ddl_logs.SelectedValue));


            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }
        protected void btn_server_Click(object sender, EventArgs e)
        {
            try
            {
                string operation = rdl_server.SelectedValue.ToLower();
                txt_richbox.InnerText = obj.Server(operation, int.Parse(ddl_services.SelectedValue));

            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
                Logger.Info(ex);
            }
        }


    }
}