<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="Hotel.View.Admin.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
   <!--<h1 class="text-success">客房管理</h1>-->
    <div class="container-fluid">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success text-center">客房管理</h1></div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
  <div class="mb-3">
    <label for="RNameTb" class="form-label">客房名称</label>
    <input type="text" class="form-control" id="RNameTb" runat="server" required="required">
  </div>
  <div class="mb-3">
    <label for="CatCb" class="form-label">房型</label>
      <asp:DropDownList ID="CatCb" runat="server" class="form-control"></asp:DropDownList>
  </div>
  <div class="mb-3">
    <label for="LocationTb" class="form-label">位置</label>
    <input type="text" class="form-control" id="LocationTb" runat="server" required="required">
  </div>
    <div class="mb-3">
    <label for="CostTb" class="form-label">价格</label>
    <input type="text" class="form-control" id="CostTb" runat="server" required="required">
  </div>
  <div class="mb-3">
    <label for="RemarksTb" class="form-label">标签</label>
    <input type="text" class="form-control" id="RemarksTb" runat="server" required="required">
  </div>
  <div class="mb-3">
    <label for="CatCb" class="form-label">状态</label>
      <asp:DropDownList ID="StatusCb" runat="server" class="form-control">
          <asp:ListItem>空闲</asp:ListItem>
          <asp:ListItem>已预定</asp:ListItem>
      </asp:DropDownList>
  </div>
  <div class="row">
    <div class="col d-grid">
        <asp:Button ID="EditBtn" runat="server" Text="编辑" class="btn btn-warning btn-block" OnClick="EditBtn_Click"/>
    </div>
    <div class="col d-grid">
        <asp:Button ID="DeleteBtn" runat="server" Text="删除" class="btn btn-danger btn-block" OnClick="DeleteBtn_Click"/>
    </div>           
 </div>
                    <br />
                    <div class="d-grid">
                        <label id="ErrMsg" runat="server" class="text-danger"></label>
                        <asp:Button ID="SaveBtn" runat="server" Text="保存" class="btn btn-success btn-block" OnClick="SaveBtn_Click"/>
                    </div>
                  
  
                    <br />
</form>
            </div>
            <div class="col-md-9">
                <asp:GridView ID="RoomsGV" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
