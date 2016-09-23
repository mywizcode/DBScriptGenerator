<%@ Page Title="<%$ Resources:Labels, dashboard_page_title%>" Language="C#" MasterPageFile="~/CSMasterPage.master" AutoEventWireup="true" Inherits="Dashboard" Codebehind="Dashboard.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ui/pages/js/Dashboard.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnBuilderId" runat="server" />
            <asp:Panel ID="Panel2" runat="server">
            <div class="box-inner">
                <div class="box-header well">
                    <i class="fa fa-tachometer"></i> Dashboard
                </div>
                <div class="box-content">
                    <div class="ch-container">
                        <div class="row">
		                    <div class="col-sm-6 col-md-6">
		                        <div class="row">
		                            <div class="col-sm-6 col-md-6">
		                                <label class="control-label" for="txtBuildername">
		                                    <asp:Literal ID="Literal2" runat="server" Text="Builder Name" /><asp:Label
		                                        ID="Label1" runat="server" ForeColor="Red" Text="&nbsp;*"></asp:Label>
		                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBuildername"
		                                        ValidationGroup="addBuilder" ErrorMessage="Please enter name">&nbsp;</asp:RequiredFieldValidator>
		                                </label>
		                                <asp:TextBox ID="txtBuildername" runat="server" class="form-control input-sm"
		                                    ValidationGroup="addBuilder" MaxLength="255"></asp:TextBox>
		                            </div>
		                            <div class="col-sm-6 col-md-6">
		                                <asp:Label ID="labelPropertyNameDrp" CssClass="control-label" runat="server"
                                            AssociatedControlID="drpPropertyName">
                                            <asp:Literal ID="Literal17" runat="server" Text="Property Name" /></asp:Label>
                                        <asp:DropDownList ID="drpPropertyName" runat="server" AutoPostBack="True"
                                            data-live-search="true">
                                        </asp:DropDownList>
		                            </div>
		                        </div>
		                        <div class="row margintop5">
		                            <div class="col-sm-6 col-md-6">
		                                <label class="control-label" for="inputSuccess1">
		                                    <asp:Literal ID="Literal4" runat="server" Text="Email" /><asp:RegularExpressionValidator
		                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailId"
		                                        ValidationGroup="addBuilder" ErrorMessage="Please enter email"
		                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
		                                </label>
		                                <asp:TextBox ID="txtEmailId" runat="server" class="form-control input-sm" ValidationGroup="addBuilder"
		                                    MaxLength="255"></asp:TextBox>
		                            </div>
		                            <div class="col-sm-6 col-md-6">
		                            </div>
		                        </div>
		                    </div>
		                    <div class="col-sm-3 col-md-3">
		                        <label class="control-label" for="inputSuccess1">
		                            Address<asp:Label ID="Label6" runat="server" ForeColor="Red"
		                                Text="&nbsp;*"></asp:Label>
		                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
		                                ValidationGroup="addBuilder" ErrorMessage="Please enter address">&nbsp;</asp:RequiredFieldValidator>
		                        </label>
		                        <asp:TextBox ID="txtAddress" runat="server" class="form-control input-sm"
		                            Height="80px" ValidationGroup="addBuilder" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
		                    </div>
		                    <div class="col-sm-3 col-md-3">
		                        <label class="control-label" for="inputSuccess1">
		                            <asp:Literal ID="Literal6" runat="server" Text="Description" /></label>
		                        <asp:TextBox ID="txtDescription" runat="server" class="form-control input-sm" TextMode="MultiLine"
		                            Height="80px" MaxLength="300"></asp:TextBox>
		                    </div>
		                </div>
                        <hr />
                        <div class="row margintop10">
                            <div class="col-sm-12 col-md-12">
                                <asp:Button ID="btn_Save" class="btn btn-primary btn-sm" runat="server" Text="Save"
                                    OnClick="save" ValidationGroup="addBuilder" />
                                <asp:Button ID="btn_Update" class="btn btn-primary btn-sm" runat="server" Text="Update"
                                    Visible="False" OnClick="save" ValidationGroup="addBuilder" />
                                <asp:Button ID="btn_Cancel" class="btn btn-primary btn-sm" runat="server" CausesValidation="False"
                                    Text="Cancel" OnClick="save" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
