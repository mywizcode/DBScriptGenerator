<%@ Page Title="<%$ Resources:Labels, firm_page_title%>" Language="C#" MasterPageFile="~/CSMasterPage.master"
    AutoEventWireup="true" Inherits="ManageFirm" Codebehind="ManageFirm.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GroupRadioButton" Namespace="Vladsm.Web.UI.WebControls" TagPrefix="vs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ui/pages/js/ManageFirm.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <section class="content">
                    <div class="box-inner">
                        <div class="box-header well">
                            <i class="fa fa-industry"></i> <%=Resources.Labels.firm_submenu_firm_details%>
                        </div>
                        <div class="nav-tabs-custom">
                            <asp:HiddenField ID="activeTabHdn" runat="server" Value="#tab1Content" />
                            <asp:HiddenField ID="viewOnlyTableHdn" runat="server" Value="false" />
                            <ul class="nav nav-tabs">
                                <li><asp:HyperLink runat="server" href="#tab1Content" class="storeTabName" id="tab1AnchorId" data-toggle="tab"><%=Resources.Labels.firm_sm_firm_dtls_tab_firm_details%></asp:HyperLink></li>
                                <li><asp:HyperLink runat="server" href="#tab2Content" class="storeTabName" id="tab2AnchorId" data-toggle="tab"><%=Resources.Labels.firm_sm_firm_dtls_tab_manage_acnt%></asp:HyperLink></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane" id="tab1Content">
                                    <asp:Panel ID="tab1SuccessPanel" runat="server" class="alert alert-success margintop5" Visible="False">
                                        <asp:Label ID="lbTab1Success" runat="server" Font-Bold="True"></asp:Label>
                                    </asp:Panel>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                                        ValidationGroup="tab1Error" Font-Bold="True" CssClass="alert alert-danger margintop5" />
                                    <!-- Till this line code structure should be same in all tab implemented pages.  -->
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                            <asp:Label ID="Label6" runat="server" Text="Primary Information"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-9 col-md-9 col-lg-9">
                                            <div class="row">
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label5" runat="server" CssClass="control-label required" Text="Name" AssociatedControlID="txtFirmName">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirmName"
		                                                    ValidationGroup="tab1Error" ErrorMessage="Please enter name">&nbsp;</asp:RequiredFieldValidator>
                                                    </asp:Label>
                                                    <asp:TextBox ID="txtFirmName" ReadOnly="true" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label25" runat="server" CssClass="control-label" Text="Registration Number" AssociatedControlID="txtRegistrationNo"/>
		                                            <asp:TextBox ID="txtRegistrationNo" runat="server" class="form-control input-sm" MaxLength="100"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label1" runat="server" CssClass="control-label required" Text="Contact" AssociatedControlID="txtContact">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContact"
		                                                    ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_contact_required%>">&nbsp;</asp:RequiredFieldValidator>
                                                    </asp:Label>
                                                    <asp:TextBox ID="txtContact" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" ValidationGroup="tab1Error" MaxLength="15"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row margintop5">
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label24" runat="server" CssClass="control-label" Text="Email" AssociatedControlID="txtEmail">
                                                        <asp:RegularExpressionValidator
		                                                    ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
		                                                    ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_correct_email%>"
		                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                                    </asp:Label>
                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label23" runat="server" CssClass="control-label" Text="Web Site" AssociatedControlID="txtWebSite"/>
		                                            <asp:TextBox ID="txtWebSite" runat="server" class="form-control input-sm" MaxLength="150"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label22" runat="server" CssClass="control-label" Text="Description" AssociatedControlID="txtDescription"/>
		                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control input-sm" Height="85px"
		                                        MaxLength="255" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row margintop10">
                                        <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                            <asp:Label ID="Label7" runat="server" Text="Address"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label8" runat="server" CssClass="control-label required" Text="Address Line 1" AssociatedControlID="txtAddressLine1">
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddressLine1"
		                                            ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_address_line1_required%>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtAddressLine1" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="255"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Address Line 2" AssociatedControlID="txtAddressLine2"/>
		                                    <asp:TextBox ID="txtAddressLine2" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="Town" AssociatedControlID="txtTown"/>
                                            <asp:TextBox ID="txtTown" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label11" runat="server" CssClass="control-label" Text="City" AssociatedControlID="txtCity"/>
                                            <asp:TextBox ID="txtCity" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label12" runat="server" CssClass="control-label" Text="State" AssociatedControlID="txtState"/>
                                            <asp:TextBox ID="txtState" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label13" runat="server" CssClass="control-label" Text="Country" AssociatedControlID="txtCountry"/>
                                            <asp:TextBox ID="txtCountry" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                            <asp:Label ID="Label14" runat="server" CssClass="control-label" Text="PIN" AssociatedControlID="txtPIN"/>
		                                    <asp:TextBox ID="txtPIN" runat="server" class="form-control input-sm" 
                                                onkeypress="return ValidateNumberOnly(event)" MaxLength="20"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3">
                                        </div>
                                    </div>
                                    <hr/>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 align-right">
                                            <asp:Button ID="btnUpdate" class="btn btn-primary btn-sm" runat="server" Text="Submit"
                                               tooltip="Update Firm" OnClick="updateFirmDetails" ValidationGroup="tab1Error" />
                                        </div>
                                    </div>
                                </div><!-- Tab 1 Ends-->
                                <div class="tab-pane" id="tab2Content">
                                    <asp:Panel ID="tab2SuccessPanel" runat="server" class="alert alert-success margintop5" Visible="False">
                                        <asp:Label ID="lbTab2Success" runat="server" Font-Bold="True"></asp:Label>
                                    </asp:Panel>
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true"
                                        ValidationGroup="tab2Error" Font-Bold="True" CssClass="alert alert-danger margintop5" />
                                    <div class="row margintop10">
                                        <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                            <asp:Label ID="Label4" runat="server" Text="Account Details"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 col-lg-12">
                                            <div id="customBtnDiv" class="hidden">
                                                <asp:Button ID="addAccountBtn" class="btn btn-primary btn-sm" runat="server" Text="Add"
                                                      tooltip="Add Account" OnClick="onClickAddAccountBtn" ValidationGroup="report" />
                                                <asp:Button ID="updateAccountBtn" class="btn btn-primary btn-sm" runat="server" Text="Update"
                                                    tooltip="Update Account" OnClick="editSelectedAccount" ValidationGroup="report" />
                                                <asp:Button ID="deleteAccountBtn" class="btn btn-primary btn-sm hidden deleteHdnTableBtn" runat="server" Text="Delete"
                                                    tooltip="Delete Account" OnClick="deleteAccount" ValidationGroup="report" />
                                                <asp:Button ID="deleteAccountHdnBtn" class="btn btn-primary btn-sm" runat="server" Text="Delete"
                                                    tooltip="Delete Account" data-delete-title="Delete Account"
	                                                data-delete-message="Do you want to delete selected Account?"
                                                    OnClientClick="return confirmModalDelete(this, true);" />
                                            </div>
                                            <asp:HiddenField ID="jumpToAcntHdnId" runat="server" Value=""/>
                                        	<asp:GridView ID="accountGrid" runat="server" AutoGenerateColumns="False" Width="100%"
                                                ShowHeaderWhenEmpty="true" CssClass="table table-striped table-bordered">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <div class="radio radio-primary radio-inline paddingleft0">
                                                                <vs:GroupRadioButton ID="rdAccountSelect" OnCheckedChanged="selectAccount" AutoPostBack="true" runat="server" GroupName="selectAcnt" />
                                                                <label></label>
                                                            </div>
                                                        	<asp:Button ID="acntRowIndBtn" runat="server" row-identifier='<%# Eval("Id") %>' CssClass="hidden row-identifier"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="AccountNo" HeaderText="Acnt Number" HeaderStyle-Width="14%"/>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="15%"/>
                                                    <asp:BoundField DataField="AccountType.Name" HeaderText="Account Type" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" HeaderStyle-Width="15%"/>
                                                    <asp:BoundField DataField="AccountBalance" HeaderText="Account Balance" HeaderStyle-Width="11%"/>
                                                    <asp:BoundField DataField="IfscCode" HeaderText="IFSC Code" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="City" HeaderText="City" HeaderStyle-Width="10%"/>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlAccountAdd" runat="server" Visible = "false">
                                        <div class="row margintop10">
                                            <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                                <asp:Label ID="lbAcntAction" runat="server" Text="Add Account"/>
                                                <hr/>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label required" Text="Account Name" AssociatedControlID="txtAcntName">
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAcntName"
		                                                ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_account_name_required%>">&nbsp;</asp:RequiredFieldValidator>
                                                </asp:Label>
                                                <asp:TextBox ID="txtAcntName" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="label26" CssClass="control-label" runat="server" Text="Account Type" AssociatedControlID="drpAcntType"/>
                                                <asp:DropDownList ID="drpAcntType" runat="server" AutoPostBack="True"
                                                    data-live-search="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label required" Text="Account Number" AssociatedControlID="txtAcntNumber">
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAcntNumber"
		                                                ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_account_number_required%>">&nbsp;</asp:RequiredFieldValidator>
                                                </asp:Label>
                                                <asp:TextBox ID="txtAcntNumber" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label15" runat="server" CssClass="control-label" Text="Account Balance" AssociatedControlID="txtAcntBalance"/>
                                                <asp:TextBox ID="txtAcntBalance" ReadOnly="true" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row margintop5">
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label16" runat="server" CssClass="control-label" Text="IFSC Code" AssociatedControlID="txtAcntIFSCCode"/>
		                                        <asp:TextBox ID="txtAcntIFSCCode" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="50"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label17" runat="server" CssClass="control-label" Text="Bank Name" AssociatedControlID="txtAcntBankName"/>
		                                        <asp:TextBox ID="txtAcntBankName" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label18" runat="server" CssClass="control-label" Text="Branch" AssociatedControlID="txtAcntBranch"/>
		                                        <asp:TextBox ID="txtAcntBranch" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label19" runat="server" CssClass="control-label" Text="City" AssociatedControlID="txtAcntCity"/>
		                                        <asp:TextBox ID="txtAcntCity" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row margintop10">
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label20" runat="server" CssClass="control-label" Text="State" AssociatedControlID="txtAcntState"/>
		                                        <asp:TextBox ID="txtAcntState" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-md-3 col-lg-3">
                                                <asp:Label ID="Label21" runat="server" CssClass="control-label" Text="Country" AssociatedControlID="txtAcntCountry"/>
		                                        <asp:TextBox ID="txtAcntCountry" runat="server" class="form-control input-sm" ValidationGroup="accountGrp" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <hr/>
                                        <div class="row">
                                            <div class="col-sm-12 col-md-12 align-right">
                                                <asp:Button ID="btnAcntSave" class="btn btn-primary btn-sm" runat="server" Text="Submit"
                                                   tooltip="Add Account" OnClick="addNewAccount" ValidationGroup="tab2Error" />
                                                <asp:Button ID="btnAcntUpdate" class="btn btn-primary btn-sm" runat="server" Text="Submit"
                                                   tooltip="Update Account" Visible="False" OnClick="updateAccount" ValidationGroup="tab2Error" />
                                                <asp:Button ID="btnAcntCancel" class="btn btn-primary btn-sm" runat="server" CausesValidation="False"
                                                   tooltip="Cancel Changes" Text="Cancel" OnClick="cancelAccount" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div><!-- Tab 2 Ends here -->
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
