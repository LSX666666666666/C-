using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.View.Users
{
    
    public partial class Booking : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            ShowBookings();
        }

        private void ShowRooms()
        {
            string St = "空闲";
            string Query = "select RId as Id,RName as Name,RCategory as categories,RCost as Cost,Status as Status from RoomsTbl where Status = '"+St+"'";
            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
            RoomsGV.HeaderRow.Cells[1].Text = "房号";
            RoomsGV.HeaderRow.Cells[2].Text = "客房名称";
            RoomsGV.HeaderRow.Cells[3].Text = "房型";
            //RoomsGV.HeaderRow.Cells[4].Text = "位置";
            RoomsGV.HeaderRow.Cells[4].Text = "价格";
            //RoomsGV.HeaderRow.Cells[6].Text = "标签";
            RoomsGV.HeaderRow.Cells[5].Text = "状态";
        }//显示客房信息
        private void ShowBookings()
        {
           
            string Query = "select* from BookingTbl";
            BookingGV.DataSource = Con.GetData(Query);
            BookingGV.DataBind();
            BookingGV.HeaderRow.Cells[1].Text = "订单号";
            BookingGV.HeaderRow.Cells[2].Text = "当前日期";
            BookingGV.HeaderRow.Cells[3].Text = "客房序号";

            BookingGV.HeaderRow.Cells[4].Text = "用户ID";

            BookingGV.HeaderRow.Cells[5].Text = "入住时间";
            BookingGV.HeaderRow.Cells[6].Text = "退房时间";
            BookingGV.HeaderRow.Cells[7].Text = "总价";
        }//显示订单信息
        int Key = 0;
        int Days = 1;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RoomTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            int Cost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
            AmountTb.Value = Cost.ToString();
        }//选择按钮事件监听
        private void UpdateRoom()
        {
            try
            {
                string st= "已预定";
                string Query = "update RoomsTbl set Status='{0}' where RId={1}";
                Query = string.Format(Query, st,RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "客房信息已更新!";
                
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }//更新客房信息
        int TCost;
        private void GetCost()
        {
            DateTime DIn = Convert.ToDateTime(DateInTb.Value);
            DateTime DOut = Convert.ToDateTime(DateOutTb.Value);
            TimeSpan value = DOut.Subtract(DIn);
            int Days = Convert.ToInt32(value.TotalDays);
            TCost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
        }//获取订单总价
        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RId = RoomsGV.SelectedRow.Cells[1].Text;
                string BDate = System.DateTime.Today.Date.ToString();
                string InDate = DateInTb.Value;
                string OutDate = DateOutTb.Value;
                string Agent = Session["UId"] as string;
                GetCost();
                int Amount = Convert.ToInt32(AmountTb.Value.ToString());
                string Query = "insert into BookingTbl values('{0}',{1},{2},'{3}','{4}',{5})";
                Query = string.Format(Query, BDate, RId, Agent, InDate, OutDate, TCost);
                Con.setData(Query);
                UpdateRoom();
                ShowRooms();
                ShowBookings();
                ErrMsg.InnerText = "客房已预定!";
                RoomTb.Value = "";
              
                AmountTb.Value = "";
                

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }//预定按钮事件监听
    }
}