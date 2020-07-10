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
    public partial class ACM_Parser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Loaddropdownclient();
        }


        public void Loaddropdownclient()
        {
            ddl_client.DataSource = CreateDataSource();
            ddl_client.DataTextField = "Text";
            ddl_client.DataValueField = "Value";
            ddl_client.DataBind();

        }
        ICollection CreateDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Text", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));

            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/ACM_Server.csv")))
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
        DataRow CreateRow(string Text, string Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Value;
            dr[1] = Text;

            return dr;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sections_list = new List<string>();
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                if (txt_transID.Text.Length > 1)
                {
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = txt_transID.Text.Split(differences, StringSplitOptions.RemoveEmptyEntries);

                    string value = ddl_client.SelectedItem.Value;

                    ExtraClasses.ACM_LogParser obj = new ExtraClasses.ACM_LogParser();
                    string result = obj.Excetue(carry, value);

                    string[] lines = result.Split('\n');
                   
                    int index = 0;
                    foreach (string line in lines)
                    {

                        if (line.Contains("**"))
                        {
                            sections_list.Add(line.Split('|')[0].ToString());
                            index = index + 1;
                        }
                        if (line.Length > 1 && line.Contains("**") == false && line.Contains("----------------------") == false) 
                        {
                            keyValuePairs.Add(sections_list[index], line);
                        }

                    }

                }


                ddl_sections.Items.Insert(0, "ALL");
                for(int i=0;i<sections_list.Count;i++)
                {
                    ddl_sections.Items.Insert(i, sections_list[i]);
                }
            }

            catch (Exception ex)
            {
                lbl_message.InnerText = ex.InnerException.ToString();
            }
        }

        protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lbl_message.InnerText = ex.Message;
            }
        }

        protected void ddl_sections_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lbl_message.InnerText = ex.Message;
            }
        }
    }
}