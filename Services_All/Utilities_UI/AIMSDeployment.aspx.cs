using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class AIMSDeployment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_rich_box.InnerText = string.Empty;
            
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            List<string> modules = new List<string>();
            string portal_version = string.Empty;
            string connectapi_versions = string.Empty;
            string esb_ver = string.Empty;
            string jboss_ver = string.Empty;
            string edi_ver = string.Empty;
            string workflow = string.Empty;
            string po_ver = string.Empty;
            string validation_ver = string.Empty;
            string ireports_ver = string.Empty;
            string features_ver = string.Empty;
            string datasynch_ver = string.Empty;
            string eauth_downloader_ver = string.Empty;
            string gateway_ver = string.Empty;

            foreach(ListItem s in chk_modules.Items)
            {
                if (s.Selected)
                {
                    modules.Add(s.Value);
                    if (s.Value == "Portal" && txt_portal.Text.Length > 0)
                    {
                        portal_version = txt_portal.Text;
                    }
                    else if (s.Value == "ConnectAPI" && txt_connectapi.Text.Length > 0) 
                    {
                        connectapi_versions = txt_connectapi.Text;
                    }

                    else if (s.Value == "Jboss" && txt_jboss_version.Text.Length > 0)
                    {
                        jboss_ver = txt_jboss_version.Text;
                    }

                    else if (s.Value == "ESB" && txt_ESB_version.Text.Length > 0)
                    {
                        esb_ver = txt_ESB_version.Text;
                    }
                    
                    else if (s.Value == "EDI" && txt_EDI_version.Text.Length > 0)
                    {
                        edi_ver = txt_EDI_version.Text;
                    }
                    else if (s.Value == "Workflow" && txt_Workflow_version.Text.Length > 0)
                    {
                        workflow = txt_Workflow_version.Text;
                    }
                    else if (s.Value == "PO" && txt_PO_version.Text.Length > 0)
                    {
                        po_ver = txt_PO_version.Text;
                    }
                    else if(s.Value == "Validation" && txt_Validation_version.Text.Length >0)
                    {
                        validation_ver = txt_Validation_version.Text;
                    }
                    else if(s.Value == "Integration-Reports" && txT_IReports_version.Text.Length>0)
                    {
                        ireports_ver = txT_IReports_version.Text;
                    }
                    else if(s.Value == "features" && txt_features_version.Text.Length>0)
                    {
                        features_ver = txt_features_version.Text;
                    }
                    else if(s.Value == "DataSync" && txt_datasynch_version.Text.Length>0)
                    {
                        datasynch_ver = txt_datasynch_version.Text;
                    }
                    else if(s.Value == "EAuth-Downloader" && txt_eauth_downloader.Text.Length>0)
                    {
                        eauth_downloader_ver = txt_eauth_downloader.Text;
                    }
                    else if(s.Value == "Gateway" && txt_gateway.Text.Length>0)
                    {
                        gateway_ver = txt_gateway.Text;
                    }

                }
            }


            if (modules.Count > 0)
            {
                if (rd_Process_list.SelectedValue == "deploy")
                {
                    txt_rich_box.InnerText = ExtraClasses.Aims_Deployment.First_Deployment(ddl_servers_list.SelectedValue, modules, 
                        connectapi_versions, portal_version,jboss_ver,esb_ver, gateway_ver, edi_ver,workflow,po_ver,validation_ver,ireports_ver,features_ver,datasynch_ver,eauth_downloader_ver);
                }
                else if(rd_Process_list.SelectedValue == "Start" || rd_Process_list.SelectedValue == "Stop" || rd_Process_list.SelectedValue == "Switch")
                {
                    if (txt_connectAPI_port.Text.Length == 0)
                    {
                        txt_rich_box.InnerText = ExtraClasses.Aims_Deployment.Operations_Server(ddl_servers_list.SelectedValue, modules, rd_Process_list.SelectedValue);
                    }
                    else if(txt_connectAPI_port.Text.Length >0)
                    {
                        txt_rich_box.InnerText = ExtraClasses.Aims_Deployment.Operations_Server(ddl_servers_list.SelectedValue, modules, rd_Process_list.SelectedValue, txt_connectAPI_port.Text);

                    }
                }
               

            }
        }

        protected void chk_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            hide_all_div();
            if (rd_Process_list.SelectedValue == "deploy")
            {
                foreach (ListItem s in chk_modules.Items)
                {
                    if(s.Selected)
                    {
                        switch (s.Value)
                        {
                            case "Portal":
                                tbl_row_portal.Visible = true;
                                break;
                            case "ConnectAPI":
                                tbl_row_connectAPI.Visible = true;
                                break;
                            case "Jboss":
                                tbl_row_jboss.Visible = true;
                                break;
                            case "ESB":
                                tbl_row_esb.Visible = true;
                                break;
                            case "EDI":
                                tbl_row_edi.Visible = true;
                                break;
                            case "Workflow":
                                tbl_row_workflow.Visible = true;
                                break;
                            case "PO":
                                tbl_row_po.Visible = true;
                                break;
                            case "Validation":
                                tbl_row_validation.Visible = true;
                                break;
                            case "Integration-Reports":
                                tbl_row_IReports.Visible = true;
                                break;
                            case "features":
                                tbl_row_features.Visible = true;
                                break;
                            case "DataSync":
                                tbl_row_datasynch.Visible = true;
                                break;
                            case "EAuth-Downloader":
                                tbl_row_eauth_downloader.Visible = true;
                                break;
                            case "Gateway":
                                tbl_row_gateway.Visible = true;
                                break;
                        }
                    }
                }
            }
            else if (rd_Process_list.SelectedValue == "Start" || rd_Process_list.SelectedValue == "Stop")
            {
                hide_all_div();
                foreach (ListItem s in chk_modules.Items)
                {
                    if (s.Value == "ConnectAPI" && s.Selected == true)
                    {
                        tbl_row_connectAPI_operation.Visible = true;
                    }
                }
            }
  
        }

        protected void rd_Process_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            hide_all_div();
            if (rd_Process_list.SelectedValue == "Switch")
            {
                foreach (ListItem item in chk_modules.Items)
                {
                    if (item.Value == "Gateway")
                    {
                        item.Selected = true;
                        tbl_row_connectAPI_operation.Visible = true;
                        item.Enabled = false;
                    }
                    else 
                    {
                        item.Selected = false;
                        item.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (ListItem list in chk_modules.Items)
                {
                    list.Enabled = true;
                    list.Selected = false;
                }
            }
        }


        private void hide_all_div()
        {
            tbl_row_connectAPI.Visible = false;
            tbl_row_connectAPI_operation.Visible = false;
            tbl_row_edi.Visible = false;
            tbl_row_esb.Visible = false;
            tbl_row_jboss.Visible = false;
            tbl_row_po.Visible = false;
            tbl_row_portal.Visible = false;
            tbl_row_workflow.Visible = false;
            tbl_row_validation.Visible = false;
            tbl_row_IReports.Visible = false;
            tbl_row_features.Visible = false;
            tbl_row_datasynch.Visible = false;
            tbl_row_eauth_downloader.Visible = false;
            tbl_row_gateway.Visible = false;
        }
    }
}