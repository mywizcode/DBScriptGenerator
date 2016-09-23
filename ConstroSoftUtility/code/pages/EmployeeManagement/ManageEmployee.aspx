<%@ Page Title="<%$ Resources:Labels, empm_page_title%>" Language="C#" MasterPageFile="~/CSMasterPage.master"
    AutoEventWireup="true" Inherits="ManageEmployee" Codebehind="ManageEmployee.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GroupRadioButton" Namespace="Vladsm.Web.UI.WebControls" TagPrefix="vs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ui/pages/js/ManageEmployee.js" type="text/javascript"></script>
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
                            <i class="fa fa-user-plus"></i> <%=Resources.Labels.empm_submenu_manage_employee%>
                        </div>
                        <div class="nav-tabs-custom">
                            <asp:HiddenField ID="activeTabHdn" runat="server" Value="tab1AnchorId" />
                            <asp:HiddenField ID="pageModeHdn" runat="server" Value="false" />
                            <ul class="nav nav-tabs">
                                <li><asp:HyperLink runat="server" href="#tab1Content" class="storeTabName" id="tab1AnchorId" data-toggle="tab"><%=Resources.Labels.empm_sm_manage_enq_tab1_name%></asp:HyperLink></li>
                                <li><asp:HyperLink runat="server" href="#tab2Content" class="storeTabName" id="tab2AnchorId" data-toggle="tab"></asp:HyperLink></li>
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
                                            <asp:DropDownList ID="drpSearchBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="onSearchBy" />
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
                                            <asp:HiddenField ID="jumpToEmployeeHdnId" runat="server" Value=""/>
                                            <div id="empSearchBtnDiv" class="hidden">
                                                <asp:Button ID="btnAddEmployee" class="btn btn-primary btn-sm" runat="server" Text="Add"
                                                      tooltip="Add Employee" OnClick="onClickAddEmployeeBtn" ValidationGroup="report" />
                                                <asp:Button ID="btnModifyEmployee" class="btn btn-primary btn-sm" runat="server" Text="Modify"
                                                    tooltip="Modify Employee" OnClick="onClickModifyEmployeeBtn" ValidationGroup="report" />
                                                <asp:Button ID="btnDeleteEmployee" class="btn btn-primary btn-sm hidden" runat="server" Text="Delete"
                                                    tooltip="Delete Employee" OnClick="deleteEmployee" ValidationGroup="report" />
                                                <asp:Button ID="btnDeleteEmployeeHdn" class="btn btn-primary btn-sm" runat="server" Text="Delete"
                                                    tooltip="Delete Employee" data-delete-title="Delete Employee" data-delete-button="btnDeleteEmployee"
	                                                data-delete-message="Do you want to delete selected Employee?"
                                                    OnClientClick="return confirmSelectedDelete(this);" />
                                            </div>
                                        	<asp:GridView ID="employeeGrid" runat="server" AutoGenerateColumns="False"
                                                width="100%" ShowHeaderWhenEmpty="true" CssClass="table table-striped table-bordered">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-Width="5%" ItemStyle-CssClass="align-center">
                                                        <ItemTemplate>
                                                            <div class="radio radio-primary radio-inline paddingleft0">
                                                                <vs:GroupRadioButton id="rdEmployeeSelect" OnCheckedChanged="selectEmployee" AutoPostBack="true" runat="server" GroupName="selectEmployee" />
                                                                <label></label>
                                                            </div>
                                                            <asp:Button ID="btnEmpRowIdentifier" runat="server" row-identifier='<%# Eval("Id") %>' CssClass="hidden row-identifier"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FirstName" HeaderText="Name" HeaderStyle-Width="20%"/>
                                                    <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="Department.Name" HeaderText="Department" HeaderStyle-Width="12%"/>
                                                    <asp:BoundField DataField="Designation.Name" HeaderText="Designation" HeaderStyle-Width="13%"/>
                                                    <asp:BoundField DataField="ContactInfo.Contact" HeaderText="Contact" HeaderStyle-Width="10%"/>
                                                    <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-Width="15%"/>
                                                    <asp:BoundField DataField="ContactInfo.Email" HeaderText="Email" HeaderStyle-Width="15%"/>
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
		                                            ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_first_name_required %>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon dropdown">
                                                    <asp:DropDownList ID="drpSalutation" runat="server"/>
                                                </span>
                                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control input-sm" ValidationGroup="tab2Error" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Middle Name" AssociatedControlID="txtMiddleName">
                                            </asp:Label>
                                            <asp:TextBox ID="txtMiddleName" runat="server" class="form-control input-sm" MaxLength="100"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="Last Name" AssociatedControlID="txtLastName">
                                            </asp:Label>
                                            <asp:TextBox ID="txtLastName" runat="server" class="form-control input-sm"  MaxLength="100"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label7" CssClass="control-label required" runat="server" Text="Gender" AssociatedControlID="drpGender">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpGender"
                                                    InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_gender_required %>"
                                                    ValidationGroup="tab2Error">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpGender" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label8" runat="server" CssClass="control-label required" Text="Date of Birth" AssociatedControlID="txtDOB">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDOB"
		                                            ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_dob_required %>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control input-sm" ValidationGroup="tab2Error"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="label9" CssClass="control-label required" runat="server" Text="Marital Status" AssociatedControlID="drpMaritalStatus">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpMaritalStatus"
                                                    InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_marital_status_required %>"
                                                    ValidationGroup="tab2Error">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="drpMaritalStatus" runat="server" />
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label11" runat="server" CssClass="control-label required" Text="Contact" AssociatedControlID="txtContact">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContact"
		                                            ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_contact_required%>">&nbsp;</asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtContact" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" ValidationGroup="tab2Error" MaxLength="15"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label12" runat="server" CssClass="control-label" Text="Alternate Contact" AssociatedControlID="txtAltContact"/>
                                            <asp:TextBox ID="txtAltContact" runat="server" class="form-control input-sm" onkeypress="return ValidateNumberOnly(event)" MaxLength="15"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row margintop5">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:Label ID="Label24" runat="server" CssClass="control-label" Text="Email" AssociatedControlID="txtEmail">
                                                <asp:RegularExpressionValidator
		                                            ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
		                                            ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_correct_email%>"
		                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">&nbsp;</asp:RegularExpressionValidator>
                                            </asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control input-sm" ValidationGroup="tab2Error" MaxLength="100"></asp:TextBox>
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
		                                    <asp:Label ID="Label14" runat="server" CssClass="control-label required" Text="Address Line 1" AssociatedControlID="txtCurrentAddressLine1">
			                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCurrentAddressLine1"
				                                    ValidationGroup="tab2Error" ErrorMessage="<%$ Resources:Messages, validation_address_line1_required%>">&nbsp;</asp:RequiredFieldValidator>
		                                    </asp:Label>
		                                    <asp:TextBox ID="txtCurrentAddressLine1" runat="server" class="form-control input-sm" ValidationGroup="tab2Error" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label15" runat="server" CssClass="control-label" Text="Address Line 2" AssociatedControlID="txtCurrentAddressLine2"/>
		                                    <asp:TextBox ID="txtCurrentAddressLine2" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label16" runat="server" CssClass="control-label" Text="Town" AssociatedControlID="txtCurrentTown"/>
		                                    <asp:TextBox ID="txtCurrentTown" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label17" runat="server" CssClass="control-label" Text="City" AssociatedControlID="txtCurrentCity"/>
		                                    <asp:TextBox ID="txtCurrentCity" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
                                    </div>
                                    <div class="row margintop5">
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label18" runat="server" CssClass="control-label" Text="State" AssociatedControlID="txtCurrentState"/>
		                                    <asp:TextBox ID="txtCurrentState" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label19" runat="server" CssClass="control-label" Text="Country" AssociatedControlID="txtCurrentCountry"/>
		                                    <asp:TextBox ID="txtCurrentCountry" runat="server" class="form-control input-sm" MaxLength="50"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label20" runat="server" CssClass="control-label" Text="PIN" AssociatedControlID="txtCurrentPIN"/>
		                                    <asp:TextBox ID="txtCurrentPIN" runat="server" class="form-control input-sm" 
			                                    onkeypress="return ValidateNumberOnly(event)" MaxLength="20"></asp:TextBox>
	                                    </div>
	                                    <div class="col-sm-3 col-md-3">
	                                    </div>
                                    </div>
                                    <div class="row margintop10">
	                                    <div class="col-sm-12 col-md-12 col-lg-12 section-header">
		                                    <asp:Label ID="Label21" runat="server" Text="Other Information"/>
		                                    <hr/>
	                                    </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-9 col-md-9 col-lg-9">
                                            <div class="row">
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="label42" CssClass="control-label" runat="server" Text="Department" AssociatedControlID="drpDepartment">
                                                        <asp:Label ID="Label26" runat="server" ForeColor="Red" Text="&nbsp;*"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="drpDepartment"
                                                            InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_department_required %>"
                                                            ValidationGroup="tab2Error">&nbsp;</asp:RequiredFieldValidator>
                                                        <asp:LinkButton ID="addDepartmentBtn" ToolTip="Add Department" runat="server" OnClientClick="return addDepartment()"
                                                            CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                        </asp:LinkButton>
                                                    </asp:Label>
                                                    <asp:DropDownList ID="drpDepartment" runat="server" />
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label23" runat="server" CssClass="control-label" Text="Joining Date" AssociatedControlID="txtJoiningDate"/>
		                                            <asp:TextBox ID="txtJoiningDate" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="label3" CssClass="control-label" runat="server" Text="Designation" AssociatedControlID="drpDesignation">
                                                        <asp:Label ID="Label27" runat="server" ForeColor="Red" Text="&nbsp;*"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpDesignation"
                                                            InitialValue="" ErrorMessage="<%$ Resources:Messages, validation_designation_required %>"
                                                            ValidationGroup="tab2Error">&nbsp;</asp:RequiredFieldValidator>
                                                        <asp:LinkButton ID="addDesignationBtn" ToolTip="Add Designation" runat="server" OnClientClick="return addDesignation()"
                                                            CssClass="btn btn-primary btn-xxs no-focus-outline glyphicon glyphicon-plus-sign">
                                                        </asp:LinkButton>
                                                    </asp:Label>
                                                    <asp:DropDownList ID="drpDesignation" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row margintop5">
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label22" runat="server" CssClass="control-label" Text="Qualification" AssociatedControlID="txtQualification"/>
		                                            <asp:TextBox ID="txtQualification" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 col-md-4 col-lg-4">
                                                    <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="Employee Id" AssociatedControlID="txtEmployeeId"/>
		                                            <asp:TextBox ID="txtEmployeeId" ReadOnly="true" runat="server" class="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
	                                    <div class="col-sm-3 col-md-3">
		                                    <asp:Label ID="Label25" runat="server" CssClass="control-label" Text="Description" AssociatedControlID="txtDescription"/>
		                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control input-sm" Height="85px"
		                                        MaxLength="255" TextMode="MultiLine"></asp:TextBox>
	                                    </div>
                                    </div>
                                    <hr/>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 align-right">
                                            <asp:Button ID="btnAddSubmit" class="btn btn-primary btn-sm" runat="server" Text="Submit"
                                                ValidationGroup="tab2Error" tooltip="Add Employee" OnClick="addEmployee" />
                                            <asp:Button ID="btnUpdateSubmit" class="btn btn-primary btn-sm" Visible="false" runat="server" Text="Submit"
                                                ValidationGroup="tab2Error" tooltip="Update Employee" OnClick="updateEmployee" />
                                            <asp:Button ID="Button2" class="btn btn-primary btn-sm" runat="server" Text="Cancel"
                                                tooltip="Cancel Changes" OnClick="cancelEmployee" />
                                        </div>
                                    </div>
                                </div><!-- Tab 2 Ends here -->
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
