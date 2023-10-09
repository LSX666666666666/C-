using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.View.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            ShowCategories();

            LogeUser.InnerText = Session["UserName"] as string;

        }
        private void ShowCategories()
        {
            string Query = "select CatId as Id,CatName as Categories,CatRemarks from CatgoryTbl";

            CategoriesGV.DataSource = Con.GetData(Query);

            CategoriesGV.DataBind();

            CategoriesGV.HeaderRow.Cells[1].Text = "序号";

            CategoriesGV.HeaderRow.Cells[2].Text = "房型";

            CategoriesGV.HeaderRow.Cells[3].Text = "标签";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)//保存
        {
            try
            {
                string CatName = CatNameTb.Value;

                string Rem = RemarkTb.Value;

                string Query = "Insert into CatgoryTbl values('{0}','{1}')";

                Query = string.Format(Query, CatName, Rem);

                Con.setData(Query);

                ShowCategories();

                ErrMsg.InnerText = "房型已添加!";

            }catch(Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
        int Key = 0;

        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)//选择
        {
            Key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);

            CatNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;

            RemarkTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;

        }

        protected void EditBtn_Click(object sender, EventArgs e)//编辑
        {
            try
            {
                string CatName = CatNameTb.Value;

                string Rem = RemarkTb.Value;

                string Query = "update CatgoryTbl set CatName='{0}',CatRemarks='{1}' where CatId={2}";

                Query = string.Format(Query, CatName, Rem,CategoriesGV.SelectedRow.Cells[1].Text);

                Con.setData(Query);

                ShowCategories();

                ErrMsg.InnerText = "房型已更新!";

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;

                string Rem = RemarkTb.Value;

                string Query = "delete from CatgoryTbl where CatId={0}";

                Query = string.Format(Query,CategoriesGV.SelectedRow.Cells[1].Text
                    );

                Con.setData(Query);

                ShowCategories();

                ErrMsg.InnerText = "房型已删除!";


            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}