<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Hotel.View.Users.Booking" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <div class="mb-3">
    <label for="RoomTb" class="form-label">客房名称</label>
    <input type="text" class="form-control" id="RoomTb" runat="server">
  </div>
                         <div class="mb-3">
    <label for="DateInTb" class="form-label">入住时间</label>
    <input type="date" class="form-control" id="DateInTb" runat="server">
  </div>
                            </div>
                            <div class="col">
                                <div class="mb-3">
    <label for="DateOutTb" class="form-label">退房时间</label>
    <input type="date" class="form-control" id="DateOutTb" runat="server">
  </div>
                         <div class="mb-3">
    <label for="AmountTb" class="form-label">价格</label>
    <input type="text" class="form-control" id="AmountTb" runat="server">
  </div>
                            </div>
                        </div>
                         
                         
                        <div class="row">
                            <div class="col">
                                <div>
                        <label id="ErrMsg" runat="server" class="text-danger"></label>
                        <asp:Button ID="BookBtn" runat="server" Text="预定" class="btn btn-warning" OnClick="BookBtn_Click"/>
                        <asp:Button ID="ResetBtn" runat="server" Text="重置" class="btn btn-danger"/>
                    </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3 class="text-primary">客房信息</h3>
                 <asp:GridView ID="RoomsGV" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="选择"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
            <div class="col">
               <div class="row">
                   <div class="col"></div>
                   <div class="col"><h2 class="text-primary">客房订单结算</h2></div>
               </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="BookingGV" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="选择"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
        </div>
    </div>
</asp:Content>
