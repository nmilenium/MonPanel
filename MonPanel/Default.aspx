<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Панель мониторинга серверов</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/Site.css" />
</head>
<body class="bg-light p-4">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" />
        <h1>MonPanel</h1>
        <div class="card p-3">
            <div class="card-body row g-2">
                <h3>Добавление нового сервера</h3>
                <div class="col-md-2">
                    <label>IP-адрес</label>
                    <asp:TextBox ID="txtIPAddress" runat="server" />
                </div>
                <div class="col-md-2">
                    <label>Порт</label>
                    <asp:TextBox ID="txtPort" runat="server" />
                </div>
                <div class="col-md-3">
                    <label>Дополнительная информация</label>
                    <asp:TextBox ID="txtAdditionalInfo" runat="server" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnAddServer" runat="server" Text="Добавить сервер" CssClass="btn btn-dark" OnClick="btnAddHost_Click" />
                </div>
            </div>
        </div>
        <div class="card p-3">
            <h3>Зарегистрированные серверы</h3>
            <div class="card-body p-0">
                <contenttemplate>
                    <asp:GridView ID="gvHosts" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="IpAddress"
                        OnRowEditing="gvHosts_RowEditing"
                        OnRowCancelingEdit="gvHosts_RowCancelingEdit"
                        OnRowUpdating="gvHosts_RowUpdating"
                        OnRowDeleting="gvHosts_RowDeleting"
                        CssClass="table table-striped table-hover mb-0 align-middle">
                        <Columns>
                            <asp:BoundField DataField="Hostname" HeaderText="Имя хоста" ReadOnly="True" />
                            <asp:BoundField DataField="IpAddress" HeaderText="IP-адрес" ReadOnly="True" />
                            <asp:BoundField DataField="Port" HeaderText="Порт" ReadOnly="True" />
                            <asp:BoundField DataField="OsType" HeaderText="ОС" ReadOnly="True" />
                            <asp:CheckBoxField DataField="IsOnline" HeaderText="Активен" ReadOnly="True" />
                            <asp:BoundField DataField="LastUpdated" HeaderText="Последний опрос" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Дополнительная информация">
                                <ItemTemplate>
                                    <%# Eval("AdditionalInfo") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditAdditionalInfo" runat="server" Text='<%# Bind("AdditionalInfo") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>
                </contenttemplate>
            </div>
        </div>
    </form>
</body>
</html>
