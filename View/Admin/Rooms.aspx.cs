using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.View.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            GetCategories();
        }
        private void ShowRooms()
        {
            string Query = "select *from RoomsTbl";
            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
            RoomsGV.HeaderRow.Cells[1].Text = "房号";
            RoomsGV.HeaderRow.Cells[2].Text = "客房名称";
            RoomsGV.HeaderRow.Cells[3].Text = "房型";
            RoomsGV.HeaderRow.Cells[4].Text = "位置";
            RoomsGV.HeaderRow.Cells[5].Text = "价格";
            RoomsGV.HeaderRow.Cells[6].Text = "标签";
            RoomsGV.HeaderRow.Cells[7].Text = "状态";
        }//显示表格数据
        private void GetCategories()
        {
            string Query = "Select*from CatgoryTbl";
            if (!Page.IsPostBack)
            {
                CatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
                CatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
                CatCb.DataSource = Con.GetData(Query);
                CatCb.DataBind();
            }
            
        }//获取房型数据

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Rem = RemarksTb.Value;
                string Status = "空闲";
                string Query = "insert into RoomsTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, RName, RCat,Rloc,Cost,Rem,Status);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "客房已添加!";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                RemarksTb.Value = "";

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }//保存事件监听
        int Key = 0;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            Key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            CatCb.SelectedValue = RoomsGV.SelectedRow.Cells[3].Text;
            LocationTb.Value = RoomsGV.SelectedRow.Cells[4].Text;
            CostTb.Value = RoomsGV.SelectedRow.Cells[5].Text;
            RemarksTb.Value = RoomsGV.SelectedRow.Cells[6].Text;

        }//表格选择事件监听

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;

                string RCat = CatCb.SelectedValue.ToString();

                string Rloc = LocationTb.Value;


                string Cost = CostTb.Value;

                string Rem = RemarksTb.Value;


                string Status = StatusCb.SelectedValue.ToString();

                string Query = "update RoomsTbl set RName='{0}',RCategory='{1}',RLocation='{2}',RCost='{3}',RRemarks='{4}',Status='{5}'where RId={6}";
                Query = string.Format(Query, RName, RCat, Rloc, Cost, Rem, Status,RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);

                ShowRooms();

                ErrMsg.InnerText = "客房信息已更新!";

                RNameTb.Value = "";

                CatCb.SelectedIndex = -1;

                LocationTb.Value = "";

                CostTb.Value = "";

                RemarksTb.Value = "";

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }//编辑按钮事件监听

        protected void DeleteBtn_Click(object sender, EventArgs e)//删除按钮事件监听
        {
            try
            {
                string Query = "delete from RoomsTbl where RId={0}";

                Query = string.Format(Query, RoomsGV.SelectedRow.Cells[1].Text);


                Con.setData(Query);

                ShowRooms();

                ErrMsg.InnerText = "客房信息已删除!";

                RNameTb.Value = "";

                CatCb.SelectedIndex = -1;

                LocationTb.Value = "";

                CostTb.Value = "";

                RemarksTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}