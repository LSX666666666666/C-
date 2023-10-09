using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            Session["UserName"] = "";
            Session["UId"] = "";
        }

        Models.Functions Con;
        static string DecryptFileContent(string filePath)
        {
            string decryptedText = string.Empty;

            // 检查文件是否存在
            if (File.Exists(filePath))
            {
                try
                {
                    // 读取文件内容
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string encryptedText = reader.ReadToEnd();

                        // 解密每个字符并拼接到解密文本中
                        foreach (char c in encryptedText)
                        {
                            char decryptedChar = (char)(c - 4);
                            decryptedText += decryptedChar;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while decrypting the file: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File not found: " + filePath);
            }

            return decryptedText;
        }


        protected void LoginBtn_Click(object sender, EventArgs e)
        {
           
            string basePath = Directory.GetCurrentDirectory(); // 获取当前工作目录
            string relativePath1 = "\\username.txt"; // 相对路径
            string usernamepath = Path.Combine(basePath, relativePath1); // 组合路径
            string username = File.ReadAllText(usernamepath);

            
            string relativePath2 = "\\password.txt"; // 相对路径
            string passwordpath = Path.Combine(basePath, relativePath2); // 组合路径
           // string password = File.ReadAllText(passwordpath);


            string password = DecryptFileContent(passwordpath);




            //Response.Redirect("https://localhost:44312/View/Admin/Rooms.aspx");
            if (AdminCb.Checked)
            {

                if (UserTb.Value == username && PasswordTb.Value == password)
                {

                    Session["UserName"] = username;
                    Response.Redirect("https://localhost:44312/View/Admin/Rooms.aspx");

                }
                else
                {
                    ErrMsg.InnerText = "无效的管理员！！！";
                }
            }
            else
            {
                string Query="select UId,UName,UPass from UserTbl where UName='{0}' and UPass='{1}'";
                Query = string.Format(Query, UserTb.Value, PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.InnerText = "无效的用户！！！";
                }
                else
                {
                    Session["UserName"] = dt.Rows[0][1].ToString();
                    Session["UId"] = dt.Rows[0][0].ToString();
                    Response.Redirect("https://localhost:44312/View/Users/Booking.aspx");
                }
            }
        }

        protected void signup_Click(object sender, EventArgs e)
        {

            //Response.Redirect("https://localhost:44312//View//Users//signup2.aspx");
            Response.Redirect("https://localhost:44312/View/Users/signup2.aspx");
        }
    }
}