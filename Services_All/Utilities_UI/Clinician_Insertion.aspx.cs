using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services_All.ExtraClasses;

namespace Services_All.Utilities_UI
{
    public partial class Clinician_Insertion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            try
            {
                string license = txt_License.Text;
                string username = txt_username.Text;
                string password = txt_password.Text;
                string licensefrom = txt_pnl6_transFromDate.Text;
                string licenseto = txt_pnl6_transToDate.Text;
                string result = string.Empty;

                if (license.Length > 1 && username.Length > 1 && licenseto.Length > 1)
                {
                    

                    string ConnectionERX = "Data Source=" + Connections.run_singlevalue("ERX", "server") + ";Initial Catalog=" + Connections.run_singlevalue("ERX", "database") + ";User ID=" + Connections.run_singlevalue("ERX", "username") + ";Password=" + Connections.run_singlevalue("ERX", "password") + ";Connection Timeout=30;";
                    string queryERX = "update top(1) Clinician set VerificationUsername='" + username + "', VerificationPassword='" + password + "', ActiveFrom='" + licensefrom + "', ActiveTo='" + licenseto + "' where License='" + license + "'";

                    result += "\n\nRunning ERX query " + queryERX;
                    result += "\nERX result : " + Insert_Query(ConnectionERX, queryERX);

                    string ConnectionDHPO = "Data Source=" + Connections.run_singlevalue("DHPO", "server") + ";Initial Catalog=" + Connections.run_singlevalue("DHPO", "database") + ";User ID=" + Connections.run_singlevalue("DHPO", "username") + ";Password=" + Connections.run_singlevalue("DHPO", "password") + ";Connection Timeout=30;";
                    string queryDHPO = "update top(1) Clinicians set Username='" + username + "', Password='" + password + "', LicenseStartDate='" + licensefrom + "', LicenseEndDate='" + licenseto + "' where ClinicianLicense='" + license + "'";

                    result += "\n\nRunning DHPO Query " + queryDHPO;
                    result += "\nDHPO Result : " + Insert_Query(ConnectionDHPO, queryDHPO);

                    lbl_message.InnerText = result;

                }
                else
                {
                    lbl_message.InnerText = "Please enter all details in the fielsds";
                }
            }
            catch (Exception ex)
            {
                lbl_message.InnerText = ex.InnerException.ToString() ;
            }

        }

        private DataTable Execute_Query(string connection, string query)
        {
            DataTable dt = new DataTable();
            try
            {
                Logger.Info("SELECT query in progress");
                Logger.Info("Connection: " + connection);

                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.SelectCommand.CommandTimeout = 1800;
                            da.Fill(dt);
                            Logger.Info("Query executed successfully");
                        }
                        con.Close();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        private bool Insert_Query(string connection, string query)
        {
            bool result = false;
            try
            {
                Logger.Info("Insert query in progress");
                Logger.Info("Connection: " + connection);
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            result = true;
                            Logger.Info("Query executed successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                result = false;
            }
            return result;
        }
    }
}