<%@ Page Title="Voucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TP3_RodriguezChristian.Principal" %>
<asp:Content ID="voucher" ContentPlaceHolderID="cuerpo" runat="server">

    <center> 
    <div>
          
        <h1 class="font-weight-bold" style="margin-top: 20px">Ingresá tu código del voucher!!</h1>

    </div>
    <div>

        <asp:TextBox ID="Voucher"  runat="server"></asp:TextBox>
    </div>
            <div style="display:flex;">
      <div style="width: 20%; float:left;">
    
<p>               </p>

</div>
</div>     
   
    <div>

        <asp:Button ID="btn_participar" runat="server" Text="Canjear"></asp:Button>

    </div>
        </center>

</asp:Content>
