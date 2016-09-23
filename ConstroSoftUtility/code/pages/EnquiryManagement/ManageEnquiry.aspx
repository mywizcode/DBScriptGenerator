<%@ Page Title="<%$ Resources:Labels, enqm_page_title%>" Language="C#" MasterPageFile="~/CSMasterPage.master"
    AutoEventWireup="true" Inherits="ManageEnquiry" Codebehind="ManageEnquiry.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ui/pages/js/ManageEnquiry.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <!-- Below hidden button click event is invoked from Modal to save data in modalDialogue
                       NOTE: validation group is neccessary to invoke server side code-->
                <asp:Button ID="btSaveModalId" class="btn btn-primary btn-sm hidden" runat="server"
                    Text="" OnClick="saveModalData" ValidationGroup="modalvalidationGrp" />
                <asp:HiddenField ID="modalErrorMsg" runat="server" />
                <div id="modalDialogue" class="hidden">
                    <div id="modalForm">
                        <div id="form-group">
                            <div id="modalErrorDivId" class="alert alert-danger marginbottom5 hidden">
                                <span id="modalErrorId" class="modal-error-msg"></span>
                            </div>
                            <asp:HiddenField ID="modalHdnType" runat="server" />
                            <asp:HiddenField ID="modalActionHdn" runat="server" />
                            <asp:HiddenField ID="modalIdentifierHdn" runat="server" />
                            <div class="row">
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label id="modalInput1Label" class="control-label required space">
                                    </label>
                                </div>
                                <div class="col-sm-9 col-md-9 col-lg-9">
                                    <asp:TextBox ID="modalInput1" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row margintop10">
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label id="modalInput2Label" class="control-label">
                                    </label>
                                </div>
                                <div class="col-sm-9 col-md-9 col-lg-9">
                                    <asp:TextBox ID="modalInput2" runat="server" class="form-control  input-sm" Height="85px"
                                        TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row margintop10">
                                <div class="col-sm-12 col-md-12 col-lg-12">
                                    <button type="submit" id="saveModalBtnId" class="btn btn-primary btn-sm" onclick="saveModalDataClient()">
                                        Save</button>
                                    <button type="submit" id="closeModalBtnId" class="btn btn-primary btn-sm" onclick="closeDialogClient()">
                                        Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <section class="content">
                    <div class="box-inner">
                        <div class="box-header well">
                            <i class="fa fa-industry"></i> <%=Resources.Labels.enqm_submenu_manage_enquiry%>
                        </div>
                        <div class="nav-tabs-custom">
                            <div id="customBtnDiv" class="hidden">
                                <asp:Button id="addEnquiryBtn" ToolTip="Add Enquiry" runat="server" OnCommand="onClickAddEnquiryBtn"
                                    CommandName="val1" CommandArgument='' ValidationGroup="report" 
                                    CssClass="btn btn-primary btn-sm" Text="Add">
                                </asp:Button>
                            </div>
                            <asp:HiddenField ID="activeTabHdn" runat="server" Value="#tab1Content" />
                            <asp:HiddenField ID="viewOnlyTableHdn" runat="server" Value="false" />
                            <ul class="nav nav-tabs">
                                <li><asp:HyperLink runat="server" href="#tab1Content" class="storeTabName" id="tab1AnchorId" data-toggle="tab"><%=Resources.Labels.enqm_sm_manage_enq_tab1_name%></asp:HyperLink></li>
                                <li><asp:HyperLink runat="server" href="#tab2Content" class="storeTabName" id="tab2AnchorId" data-toggle="tab"><%=Resources.Labels.enqm_sm_manage_enq_tab2_add_name%></asp:HyperLink></li>
                                <li><asp:HyperLink runat="server" href="#tab3Content" class="storeTabName" id="tab3AnchorId" data-toggle="tab"><%=Resources.Labels.enqm_sm_manage_enq_tab3_add_name%></asp:HyperLink></li>
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
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label CssClass="control-label" runat="server" AssociatedControlID="drpSearchBy">
                                            	<asp:Literal ID="Literal1" runat="server" Text="Search By" />
                                            </asp:Label>
                                            <asp:DropDownList ID="drpSearchBy" runat="server" AutoPostBack="True" data-live-search="true"
                                                OnSelectedIndexChanged="onSearchBy">
                                            </asp:DropDownList> 
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label1" CssClass="control-label" runat="server" AssociatedControlID="drpSearchByValue">
                                            	<asp:Literal ID="Literal2" runat="server" Text="Search By" />
                                            </asp:Label>
                                            <asp:DropDownList ID="drpSearchByValue" runat="server" AutoPostBack="True" data-live-search="true"
                                                OnSelectedIndexChanged="onSearchByValue">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 col-lg-12">
                                            <asp:HiddenField ID="jumpToEnquiryHdnId" runat="server" Value=""/>
                                        	<asp:GridView ID="enquiryGrid" runat="server" AutoGenerateColumns="False"
                                                width="100%" ShowHeaderWhenEmpty="true" CssClass="table table-striped table-bordered">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="6%" ItemStyle-CssClass="align-center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button1" runat="server" row-identifier='<%# Eval("Id") %>' CssClass="hidden row-identifier"/>
                                                            <asp:LinkButton ID="editLinkBtn" ToolTip="Edit" runat="server" OnCommand="selectForEditEnquiry"
                                                                CommandName="val1" CommandArgument='<%# Eval("Id") %>' CssClass="editRowBtn btn btn-primary btn-xs glyphicon glyphicon-pencil">
                                                            </asp:LinkButton>
                                                            <asp:Button ID="deletePymtHistoryHdnTableBtn" ToolTip="Delete" runat="server" OnCommand="deleteEnquiry"
                                                                CommandName="val1" CommandArgument='<%# Eval("Id") %>' ValidationGroup="report" 
                                                                CssClass="hidden deleteHdnTableBtn btn btn-primary btn-xs no-focus-outline glyphicon glyphicon-pencil">
                                                            </asp:Button>
                                                            <asp:LinkButton ID="deleteLinkBtn" ToolTip="Cancel" runat="server"
                                                                    data-delete-title="Delete Enquiry"
                                                                    data-delete-message="Do you want to delete Enquiry of '{0}'?"
                                                                    data-delete-message-opt-0='<%# Eval("Id") %>'
                                                                    CssClass="deleteRowBtn btn btn-danger btn-xs no-focus-outline glyphicon glyphicon-trash"
                                                                OnClientClick="return confirmModalDelete(this, true);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FirstName" HeaderText="Name" HeaderStyle-Width="30%"/>
                                                    <asp:BoundField DataField="EnquiryDate" HeaderText="Enquiry Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="PropertyType.Name" HeaderText="Property Type" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="Property.Name" HeaderText="Property Name" HeaderStyle-Width="12%"/>
                                                    <asp:BoundField DataField="PropertyLocation.Name" HeaderText="Property Location" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="PrUnitType.Name" HeaderText="Property Unit Type" HeaderStyle-Width="14%"/>
                                                    <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-Width="8%"/>
                                                </Columns>
                                            </asp:GridView>
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
                                            <asp:Label ID="Label4" runat="server" Text="Personal Information"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label5" runat="server" CssClass="control-label required" Text="First Name" AssociatedControlID="txtFirstName">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirstName"
		                                            ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_first_name_required %>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon dropdown">
                                                    <asp:DropDownList ID="drpSalutation" runat="server"/>
                                                </span>
                                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Middle Name" AssociatedControlID="txtMiddleName">
                                            </asp:Label>
                                            <asp:TextBox ID="txtMiddleName" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="Last Name" AssociatedControlID="txtLastName">
                                            </asp:Label>
                                            <asp:TextBox ID="txtLastName" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label7" CssClass="control-label required" runat="server" Text="Gender" AssociatedControlID="drpGender">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpGender"
                                                    InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_gender_required %>"
                                                    ValidationGroup="tab1Error">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpGender" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label8" runat="server" CssClass="control-label required" Text="Date of Birth" AssociatedControlID="txtDOB">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDOB"
		                                            ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_dob_required %>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control input-sm" ValidationGroup="tab1Error"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label9" CssClass="control-label required" runat="server" Text="Marital Status" AssociatedControlID="drpMaritalStatus">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpMaritalStatus"
                                                    InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_marital_status_required %>"
                                                    ValidationGroup="tab1Error">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpMaritalStatus" runat="server" />
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="Occupation" AssociatedControlID="drpOccupation">
                                                <asp:LinkButton ID="LinkButton2" ToolTip="Add Occupation" runat="server" OnClientClick="return addOccupation()"
                                                    CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                </asp:LinkButton>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpOccupation" runat="server"  data-live-search="true"/>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label11" runat="server" CssClass="control-label required" Text="Contact" AssociatedControlID="txtContact">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContact"
		                                            ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_contact_required%>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtContact" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" ValidationGroup="tab1Error" MaxLength="15"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label12" runat="server" CssClass="control-label" Text="Alternate Contact" AssociatedControlID="txtAltContact"/>
                                            <asp:TextBox ID="txtAltContact" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" ValidationGroup="tab1Error" MaxLength="15"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label24" runat="server" CssClass="control-label" Text="Email" AssociatedControlID="txtEmail">
                                                <asp:RegularExpressionValidator
		                                            ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
		                                            ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_correct_email%>"
		                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row margintop10">
	                                    <div class="col-sm-12 col-md-12 col-lg-12 section-header">
		                                    <asp:Label ID="Label13" runat="server" Text="Primary Address"/>
		                                    <hr/>
	                                    </div>
                                    </div>
                                    <div class="row">
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label14" runat="server" CssClass="control-label required" Text="Address Line 1" AssociatedControlID="txtPrimAddressLine1">
			                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrimAddressLine1"
				                                    ValidationGroup="tab1Error" ErrorMessage="<%$ Resources:Messages, validation_address_line1_required%>">&nbsp;</asp:RequiredFieldValidator>
		                                    </asp:Label>
		                                    <asp:TextBox ID="txtPrimAddressLine1" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label15" runat="server" CssClass="control-label" Text="Address Line 2" AssociatedControlID="txtPrimAddressLine2"/>
		                                    <asp:TextBox ID="txtPrimAddressLine2" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label16" runat="server" CssClass="control-label" Text="Town" AssociatedControlID="txtPrimTown"/>
		                                    <asp:TextBox ID="txtPrimTown" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label17" runat="server" CssClass="control-label" Text="City" AssociatedControlID="txtPrimCity"/>
		                                    <asp:TextBox ID="txtPrimCity" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
                                    </div>
                                    <div class="row margintop5">
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label18" runat="server" CssClass="control-label" Text="State" AssociatedControlID="txtPrimState"/>
		                                    <asp:TextBox ID="txtPrimState" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label19" runat="server" CssClass="control-label" Text="Country" AssociatedControlID="txtPrimCountry"/>
		                                    <asp:TextBox ID="txtPrimCountry" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label20" runat="server" CssClass="control-label" Text="PIN" AssociatedControlID="txtPrimPIN"/>
		                                    <asp:TextBox ID="txtPrimPIN" runat="server" class="form-control input-sm" 
			                                    onkeypress="return ValidateNumberOnly(event)" MaxLength="20"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
	                                    </div>
                                    </div>
                                    <div class="row margintop10">
	                                    <div class="col-sm-12 col-md-12 col-lg-12 section-header">
		                                    <asp:Label ID="Label21" runat="server" Text="Secondary Address"/>
		                                    <hr/>
	                                    </div>
                                    </div>
                                    <div class="row">
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label22" runat="server" CssClass="control-label" Text="Address Line 1" AssociatedControlID="txtSecAddressLine1" />
		                                    <asp:TextBox ID="txtSecAddressLine1" runat="server" class="form-control input-sm" ValidationGroup="tab1Error" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label23" runat="server" CssClass="control-label" Text="Address Line 2" AssociatedControlID="txtSecAddressLine2"/>
		                                    <asp:TextBox ID="txtSecAddressLine2" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label25" runat="server" CssClass="control-label" Text="Town" AssociatedControlID="txtSecTown"/>
		                                    <asp:TextBox ID="txtSecTown" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label26" runat="server" CssClass="control-label" Text="City" AssociatedControlID="txtSecCity"/>
		                                    <asp:TextBox ID="txtSecCity" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
                                    </div>
                                    <div class="row margintop5">
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label27" runat="server" CssClass="control-label" Text="State" AssociatedControlID="txtSecState"/>
		                                    <asp:TextBox ID="txtSecState" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label28" runat="server" CssClass="control-label" Text="Country" AssociatedControlID="txtSecCountry"/>
		                                    <asp:TextBox ID="txtSecCountry" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label29" runat="server" CssClass="control-label" Text="PIN" AssociatedControlID="txtSecPIN"/>
		                                    <asp:TextBox ID="txtSecPIN" runat="server" class="form-control input-sm" 
			                                    onkeypress="return ValidateNumberOnly(event)" MaxLength="20"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
	                                    </div>
                                    </div>
                                    <hr/>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">
                                            <asp:Button ID="btnNext" class="btn btn-primary btn-sm" runat="server" Text="Next"
                                               tooltip="Next Page" OnClientClick="return showTab3();" />
                                        </div>
                                    </div>
                                </div><!-- Tab 2 Ends here -->
                                <div class="tab-pane" id="tab3Content">
                                    <asp:Panel ID="tab3SuccessPanel" runat="server" class="alert alert-success margintop5" Visible="False">
                                        <asp:Label ID="lbTab3Success" runat="server" Font-Bold="True"></asp:Label>
                                    </asp:Panel>
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="true"
                                        ValidationGroup="tab3Error" Font-Bold="True" CssClass="alert alert-danger margintop5" />
                                    <div class="row margintop10">
                                        <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                            <asp:Label ID="Label3" runat="server" Text="Enquiry Details"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label30" runat="server" CssClass="control-label required" Text="Enquiry Date" AssociatedControlID="txtEnquiryDate">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEnquiryDate"
		                                            ValidationGroup="tab3Error" ErrorMessage="<%$ Resources:Messages, validation_enquiry_date_required %>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtEnquiryDate" runat="server" class="form-control input-sm" ValidationGroup="tab1Error"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label31" CssClass="control-label required" runat="server" Text="Employee" AssociatedControlID="drpEmployee">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpEmployee"
                                                    InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_employee_required %>"
                                                    ValidationGroup="tab3Error">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpEmployee" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label32" CssClass="control-label" runat="server" Text="Property Type" AssociatedControlID="drpPropertyType">
                                                <asp:LinkButton ID="addPropertyTypeBtn" ToolTip="Add Property Type" runat="server" OnClientClick="return addPropertyType()"
                                                    CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                </asp:LinkButton>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpPropertyType" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label34" CssClass="control-label" runat="server" Text="Property Location" AssociatedControlID="drpPropertyLocation">
                                                <asp:LinkButton ID="addPropertyLocationBtn" ToolTip="Add Property Location" runat="server" OnClientClick="return addLocation()"
                                                    CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                </asp:LinkButton>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpPropertyLocation" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label35" CssClass="control-label" runat="server" Text="Property Name" AssociatedControlID="drpProperty"/>
                                            <asp:DropDownList ID="drpProperty" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label33" CssClass="control-label" runat="server" Text="Property Unit Type" AssociatedControlID="drpPropUnitType">
                                                <asp:LinkButton ID="addPropUnitTypeBtn" ToolTip="Add Property Unit Type" runat="server" OnClientClick="return addPropUnitType()"
                                                    CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                </asp:LinkButton>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpPropUnitType" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label36" runat="server" CssClass="control-label" Text="Contact" AssociatedControlID="txtBudget"/>
                                            <asp:TextBox ID="txtBudget" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" ValidationGroup="tab1Error" MaxLength="15"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label37" CssClass="control-label" runat="server" Text="Enquiry Source" AssociatedControlID="drpEnquirySource">
                                                <asp:LinkButton ID="LinkButton1" ToolTip="Add Enquiry Source" runat="server" OnClientClick="return addEnquirySource()"
                                                    CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                </asp:LinkButton>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpEnquirySource" runat="server"  data-live-search="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row margintop10">
                                        <div class="col-sm-12 col-md-12 col-lg-12 section-header">
                                            <asp:Label ID="Label38" runat="server" Text="Enquiry Tracking"/>
                                            <hr/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6 col-lg-6">
                                            <div class="row">
                                                <div class="col-sm-6 col-md-6 col-lg-6">
                                                    <asp:Label ID="label39" CssClass="control-label" runat="server" Text="Status" AssociatedControlID="drpEnquiryStatus"/>
                                                    <asp:DropDownList ID="drpEnquiryStatus" runat="server"  data-live-search="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-6 col-md-6 col-lg-6">
                                                    <asp:Label ID="Label40" runat="server" CssClass="control-label" Text="Follow-up Date" AssociatedControlID="txtFollowupDate"/>
                                                    <asp:TextBox ID="txtFollowupDate" runat="server" class="form-control input-sm"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label41" runat="server" CssClass="control-label" Text="Comments" AssociatedControlID="txtComments"/>
		                                    <asp:TextBox ID="txtComments" runat="server" class="form-control input-sm" Height="85px"
		                                        MaxLength="255" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr/>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">
                                            <asp:Button ID="btnAcntSave" class="btn btn-primary btn-sm" runat="server" Text="Save"
                                                tooltip="Save Enquiry" OnClick="addEnquiry" ValidationGroup="tab3Error" />
                                            <asp:Button ID="btnAcntUpdate" class="btn btn-primary btn-sm" runat="server" Text="Update"
                                                tooltip="Update Enquiry" Visible="False" OnClick="updateEnquiry" ValidationGroup="tab2Error" />
                                            <asp:Button ID="btnAcntCancel" class="btn btn-primary btn-sm" runat="server" CausesValidation="False"
                                                tooltip="Cancel Changes" Text="Cancel" OnClick="cancelEnquiry" />
                                        </div>
                                    </div>
                                </div><!-- Tab 3 Ends here -->
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
