using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class IdamDha : System.Web.UI.Page
    {

        public static string uid = "ffffffff-c3a6-1e23-218b-c8c60033c587-EClaim";
        public static string APIVersion = "3.0";
        public static string DeviceType = "ANDROID";
        public static string AppId = "EClaim";
        public static string AESKey = "r8li9SQw6BmU5iSB8dwYxg==";
        public static string url = "https://eservices.dha.gov.ae/UserManagementApi/CoreManagement/AuthenticateUser";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string str2 = string.Concat(new string[] { "DeviceId=", uid, "&DeviceType=", DeviceType, "&UserId=", txt_username.Text, "&AppId=", AppId, "&Password=", txt_password.Text });
                byte[] numArray = Convert.FromBase64String(AESKey);
                Encoding uTF8 = Encoding.UTF8;
                DateTime now = DateTime.Now;
                byte[] numArray1 = this.AesEncrypt(uTF8.GetBytes(string.Concat(uid, ":", now.ToString("MM/dd/yyyy HH-mm-ss"))), numArray);
                if (numArray1 != null)
                {
                    string base64String = Convert.ToBase64String(numArray1);
                    string resultpost = POST_Call(url, str2, base64String);
                    JObject jObjects = JObject.Parse(resultpost);

                    lbl_message.InnerText = jObjects["AuthMessage"].ToString();
                    lbl_message.InnerText += jObjects.ToString();
                }
            }
            catch (Exception ex)
            {
                lbl_message.InnerText = ex.Message;
            }
        }

        private byte[] AesEncrypt(byte[] bytes, byte[] key)
        {
            Console.WriteLine("Encrypting data");
            byte[] array;
            if (bytes == null || bytes.Length == 0 || key == null || key.Length == 0)
            {
                throw new ArgumentNullException();
            }
            byte[] numArray = new byte[] { 64, 36, 38, 7, 122, 35, 43, 47, 105, 125, 115, 40, 92, 72, 25, 37 };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged rijndaelManaged = new RijndaelManaged()
                {
                    Key = key,
                    IV = numArray,
                    Padding = PaddingMode.PKCS7,
                    Mode = CipherMode.CBC
                })
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(key, numArray), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, (int)bytes.Length);
                    }
                }
                array = memoryStream.ToArray();
            }
            return array;
        }
        private static string POST_Call(string URL, string postdata, string staticToken)
        {
            Console.WriteLine("Executing the Post Call");
            HttpWebRequest length = (HttpWebRequest)WebRequest.Create(URL);
            byte[] bytes = Encoding.ASCII.GetBytes(postdata);
            length.Headers.Add(HttpRequestHeader.Authorization, string.Concat("Basic ", staticToken));
            length.Accept = "application/json";
            length.Headers.Add("APIVERSION", APIVersion);
            length.Headers.Add("uid", uid);
            length.Method = "POST";
            length.ContentType = "application/x-www-form-urlencoded";
            length.ContentLength = (long)((int)bytes.Length);
            using (Stream requestStream = length.GetRequestStream())
            {
                requestStream.Write(bytes, 0, (int)bytes.Length);
            }
            return (new StreamReader(((HttpWebResponse)length.GetResponse()).GetResponseStream())).ReadToEnd();
        }
    }
}