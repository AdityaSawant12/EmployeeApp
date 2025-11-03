\
        <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
        <!DOCTYPE html>
        <html>
        <head runat="server">
            <title>Employee Manager - Minimal App</title>
            <style>
                body { font-family: Arial, sans-serif; margin: 30px; }
                label { display: inline-block; width: 120px; vertical-align: top; }
                .row { margin-bottom: 10px; }
                textarea { width: 300px; height: 80px; }
                input[type=text] { width: 300px; }
                .buttons { margin-top: 15px; }
            </style>
        </head>
        <body>
            <form id="form1" runat="server">
            <h2>Employee Manager</h2>
            <div class="row">
                <label>Employee</label>
                <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged" />
            </div>
            <div class="row">
                <label>Employee ID</label>
                <asp:TextBox ID="txtID" runat="server" ReadOnly="true" />
            </div>
            <div class="row">
                <label>Name</label>
                <asp:TextBox ID="txtName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Required" Display="Dynamic" ForeColor="Red" />
            </div>
            <div class="row">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" Display="Dynamic" ForeColor="Red" />
            </div>
            <div class="row">
                <label>Address</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="4" Columns="40" />
            </div>
            <div class="row">
                <label>Phone</label>
                <asp:TextBox ID="txtPhone" runat="server" />
            </div>

            <div class="buttons">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Delete this employee?');" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            </div>

            <h4>Navigation</h4>
            <div class="buttons">
                <asp:Button ID="btnFirst" runat="server" Text="|&lt; First" OnClick="btnFirst_Click" />
                <asp:Button ID="btnPrev" runat="server" Text="&lt; Previous" OnClick="btnPrev_Click" />
                <asp:Button ID="btnNext" runat="server" Text="Next &gt;" OnClick="btnNext_Click" />
                <asp:Button ID="btnLast" runat="server" Text="Last &gt;|" OnClick="btnLast_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
            </form>
        </body>
        </html>
