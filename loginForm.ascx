<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="loginForm.ascx.cs" Inherits="AssignmentBAIT2113.home" %>
<link href="Style.css" rel="stylesheet" type="text/css" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>

    <div id="form">
        <div class="container">
            <div  id="row" class="row justify-content-center align-items-center">
                <div id="column" class="col-md-6">
                    <div id="box" class="col-md-12">
                         
                            <h1 style="text-shadow: 0 0 3px #FF0000, 0 0 5px #0000FF" class="text-center  pt-5">User Login</h1>
                            <div style="margin-left:10px ; margin-right:10px" >
                                <asp:Label ID="lblLogin" runat="server" Text="Username"></asp:Label>
                                <asp:TextBox ID="txtLogin" class="form-control" runat="server" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Username" CssClass="errorIn" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
                            </div>
                            <div style="margin-left:10px ; margin-right:10px" >
                                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label><br>
                                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your password" CssClass="errorIn" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </div>
                            <div style="margin-left:10px ; margin-right:10px" >
                                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me"/>                                
                                <br />
                                <asp:CustomValidator ID="cvNotMatched" runat="server" CssClass="errorIn" ErrorMessage="Username or Password incorrect. Please try again" OnDataBinding="btnLogin_Click"></asp:CustomValidator>
                                <br />
                            </div>
                            <div style="margin-left:10px ; margin-right:10px" >                               
                                <asp:Button ID="btnLogin" type="submit" class="btn btn-primary " runat="server" Text="Login" OnClick="btnLogin_Click" ForeColor="White" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" class="btn btn-primary " runat="server" Text="Reset" CausesValidation="False" OnClick="btnReset_Click" ForeColor="White" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

