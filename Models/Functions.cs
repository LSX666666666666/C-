using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Hotel.Models
{
    public class Functions
    {
        private SqlConnection Con;//连接数据库
        private SqlCommand Cmd;//可以对数据库对象进行基础操作
        private DataTable dt;//处理数据的临时表格类
        private SqlDataAdapter sda;//是DataSet和SQL Sever之间的连接器，填充和更新DataSet数据
        private string ConStr;

        public int setData(string Query)
        {
            int Cnt;
            if (Con.State == ConnectionState.Closed)//判断数据库的状态
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();//执行目标操作，更新数据
            Con.Close();
            return Cnt;
        }

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



        public Functions()
        {
            string basePath = Directory.GetCurrentDirectory(); // 获取当前工作目录
            string relativePath = "\\config.txt"; // 相对路径
            string filePath = Path.Combine(basePath, relativePath); // 组合路径

            //string fullPath = "Hotel\\config.txt"; // 文本文件路径
            string ConStr = " ";


            //ConStr = File.ReadAllText(filePath);
            ConStr = DecryptFileContent(filePath);

            //ConStr = @"Data Source=;Initial Catalog = EHOTELDB.MDF;Integrated Security=True;";

            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;//只允许在指定的数据库上执行操作

        }
        public DataTable GetData(string Query)//将查询到的数据返回到以表格形式出现，填充表
        {
            string basePath = Directory.GetCurrentDirectory(); // 获取当前工作目录
            string relativePath = "config.txt"; // 相对路径
            string fliePath = Path.Combine(basePath, relativePath); // 组合路径

            string filePath = "H:\\BaiduNetdiskDownload\\酒店管理系统\\Hotel\\config.txt"; // 文本文件路径
            dt = new DataTable();
            ConStr = File.ReadAllText(filePath);
            sda = new SqlDataAdapter(Query,ConStr);
            sda.Fill(dt);
            return dt;
        }

        
    }
}