using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConstroSoft;
using System.Globalization;
using Vladsm.Web.UI.WebControls;

public partial class ManageEmployee : System.Web.UI.Page
{
    private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    string tab1ValidationGrp = "tab1Error";
    string tab2ValidationGrp = "tab2Error";
    string VS_EMPLOYEE_LIST = "EMPLOYEE_LIST";
    string VS_SELECTED_EMPLOYEE = "SELECTED_EMPLOYEE";
    DropdownBO drpBO = new DropdownBO();
    EmployeeBO employeeBO = new EmployeeBO();
    MasterDataBO masterDataBO = new MasterDataBO();
    DepartmentBO departmentBO = new DepartmentBO();
    string[] selectItem = { Constants.DropDownItem.SELECT, Constants.DropDownItem.SELECT_VALUE };
    protected void Page_Load(object sender, EventArgs e)
    {
        clearMessages();
        if (!IsPostBack)
        {
            if (Session[Constants.Session.USERNAME] != null)
            {
                resetForm(PageMode.NONE, tab1AnchorId.ID);
                initDropdowns();
                populateEmployeeGrid();
            }
            else
            {
                Response.Redirect(Constants.URL.LOGIN, false);
            }
        }
    }
    private void initDropdowns()
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        drpBO.drpGeneric(drpSalutation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.SALUTATION, null, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpDesignation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.DESIGNATION, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpSearchBy, Constants.DropDownType.STATIC_VALUE, DrpDataType.EMPLOYEE_SEARCH_BY, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpGender, Constants.DropDownType.STATIC_VALUE, DrpDataType.GENDER, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpMaritalStatus, Constants.DropDownType.STATIC_VALUE, DrpDataType.MARITAL_STATUS, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpDepartment, Constants.DropDownType.DB_VALUE, DrpDataType.DEPARTMENT, null, selectItem, userDefDto.FirmNumber);
    }
    /**
     * This method is called just before the page is rendered. So any change in state of the element is applied.
     **/
    protected void Page_PreRender(object sender, EventArgs e)
    {
        applyEntitlement();
        initBootstrapComponantsFromServer();
        setEmployeeGridJumpToField();
    }
    private bool isViewOnlyUser()
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        bool isViewOnlyUser = !CommonUtil.hasEntitlement(userDefDto, Constants.Entitlement.FIRM_ACCOUNT_ADD_UPDATE);
        return isViewOnlyUser;
    }
    private void applyEntitlement()
    {
        if (isViewOnlyUser())
        {
            pageModeHdn.Value = PageMode.VIEW.ToString();
            btnAddEmployee.Visible = false;
            btnModifyEmployee.Visible = false;
            btnDeleteEmployee.Visible = false;
        }
    }
    public void setErrorMessage(string message, string group)
    {
        CustomValidator val = new CustomValidator();
        val.IsValid = false;
        val.ErrorMessage = message;
        val.ValidationGroup = group;
        this.Page.Validators.Add(val);
    }

    public void setSuccessMessage(string msg, string tabNo)
    {
        if ("1".Equals(tabNo))
        {
            lbTab1Success.Text = msg;
            tab1SuccessPanel.Visible = true;
            activeTabHdn.Value = tab1AnchorId.ID;
        }
        else if ("2".Equals(tabNo))
        {
            lbTab2Success.Text = msg;
            tab2SuccessPanel.Visible = true;
            activeTabHdn.Value = tab2AnchorId.ID;
        }
    }
    public void initBootstrapComponantsFromServer()
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BootStrapComponants", "initBootstrapComponants()", true);
    }
    private void clearMessages()
    {
        tab1SuccessPanel.Visible = false;
        lbTab1Success.Text = "";
        tab2SuccessPanel.Visible = false;
        lbTab2Success.Text = "";
    }
    private UserDefinitionDTO getUserDefinitionDTO()
    {
        return (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
    }
    public void resetForm(PageMode pageMode, string activeAnchorId)
    {
        populateUIFieldsFromDTO(null);
        setTabInfo(pageMode, activeAnchorId);
    }

    private void setTabInfo(PageMode pageMode, string activeAnchorId)
    {
        tab2AnchorId.Visible = true;
        activeTabHdn.Value = activeAnchorId;
        pageModeHdn.Value = pageMode.ToString();
        addDepartmentBtn.Visible = true;
        addDesignationBtn.Visible = true;
        if (PageMode.ADD == pageMode)
        {
            tab2AnchorId.Text = Resources.Labels.empm_sm_manage_enq_tab2_add_name;
            btnAddSubmit.Visible = true;
            btnUpdateSubmit.Visible = false;
        }
        else if (PageMode.MODIFY == pageMode)
        {
            tab2AnchorId.Text = Resources.Labels.empm_sm_manage_enq_tab2_update_name;
            btnAddSubmit.Visible = false;
            btnUpdateSubmit.Visible = true;
        }
        else if (PageMode.VIEW == pageMode)
        {
            tab2AnchorId.Text = Resources.Labels.empm_sm_manage_enq_tab2_view_name;
            btnAddSubmit.Visible = false;
            btnUpdateSubmit.Visible = false;
            addDepartmentBtn.Visible = false;
            addDesignationBtn.Visible = false;
        }
        else
        {
            activeTabHdn.Value = tab1AnchorId.ID;
            tab2AnchorId.Visible = false;
        }
    }
    public void deSelectEmployeeGrid()
    {
        if (employeeGrid.Rows.Count > 0)
        {
            foreach (GridViewRow row in employeeGrid.Rows)
            {
                GroupRadioButton radioBtn = (GroupRadioButton)row.FindControl("rdEmployeeSelect");
                if (radioBtn != null) radioBtn.Checked = false;
            }
        }
        ViewState[VS_SELECTED_EMPLOYEE] = null;
    }
    private void setEmployeeGridJumpToField()
    {
        FirmMemberDTO selectedEmployee = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
        jumpToEmployeeHdnId.Value = null;
        if (selectedEmployee != null) jumpToEmployeeHdnId.Value = selectedEmployee.Id.ToString();
    }
    protected void saveModalData(object sender, EventArgs e)
    {
        String errorMsg = "";
        UserDefinitionDTO userDefDto = getUserDefinitionDTO();
        if (modalHdnType.Value == "DEPARTMENT")
        {
            DepartmentDTO departmentDto = CommonUtil.populateDepartmentDTOAdd(modalInput1.Text,
                     modalInput2.Text, userDefDto);
            errorMsg = validateDepartmentModalInput(departmentDto);
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                departmentBO.saveDepartment(departmentDto);
                drpBO.drpGeneric(drpDepartment, Constants.DropDownType.DB_VALUE, DrpDataType.DEPARTMENT, null, selectItem, userDefDto.FirmNumber);
                modalIdentifierHdn.Value = "";
            }
        }
        else if (modalHdnType.Value == "DESIGNATION")
        {
            MasterControlDataDTO masterDataDto = CommonUtil.populateMasterDataDTOAdd(Constants.MCDType.DESIGNATION, modalInput1.Text,
                   modalInput2.Text, userDefDto);
            errorMsg = validateMasterDataModalInput(masterDataDto, "Designation");
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                masterDataBO.saveMasterData(masterDataDto);
                drpBO.drpGeneric(drpDesignation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.DESIGNATION, selectItem, userDefDto.FirmNumber);
                modalIdentifierHdn.Value = "";
            }
        }

        if (!string.IsNullOrWhiteSpace(errorMsg))
        {
            modalErrorMsg.Value = errorMsg;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "setModalErrorMsg", "setModalErrorMsg()", true);
        }
        else
        {
            //Reset the modal fields
            modalInput1.Text = "";
            modalInput2.Text = "";
            modalHdnType.Value = "";
            modalActionHdn.Value = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "closeDialogClient", "closeDialogClient()", true);
        }
    }
    private string validateDepartmentModalInput(DepartmentDTO departmentDto)
    {
        string errorMsg = "";
        if (string.IsNullOrWhiteSpace(departmentDto.Name))
        {
            errorMsg = "Department Name is required";
        }
        else if (departmentBO.isAlreadyExist(departmentDto))
        {
            errorMsg = "Department with same name already exist";
        }
        return errorMsg;
    }
    private string validateMasterDataModalInput(MasterControlDataDTO masterDataDto, string type)
    {
        string errorMsg = "";
        if (string.IsNullOrWhiteSpace(masterDataDto.Name))
        {
            errorMsg = "Designation is required";
        }
        else if (masterDataBO.isAlreadyExist(masterDataDto))
        {
            errorMsg = type + " with same name already exist";
        }
        return errorMsg;
    }
    private void populateEmployeeGrid()
    {
        try
        {
            UserDefinitionDTO userDefDto = getUserDefinitionDTO();
            long Id = -1;
            if (!string.IsNullOrWhiteSpace(drpSearchByValue.Text)) Id = long.Parse(drpSearchByValue.Text);
            IList<FirmMemberDTO> results = employeeBO.fetchEmployeeGridData(userDefDto.FirmNumber, drpSearchBy.Text, Id);
            ViewState[VS_EMPLOYEE_LIST] = results;
            employeeGrid.DataSource = results;
            employeeGrid.DataBind();
            ViewState[VS_SELECTED_EMPLOYEE] = null;
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(Resources.Messages.system_error, tab1ValidationGrp);
        }
    }
    protected void onSearchBy(object sender, EventArgs e)
    {
        UserDefinitionDTO userDefDto = getUserDefinitionDTO();
        if (Constants.DropDownItem.EmployeeSearchBy.EMPLOYEE_ID.Equals(drpSearchBy.Text))
        {

        }
        else if (Constants.DropDownItem.EmployeeSearchBy.DEPARTMENT.Equals(drpSearchBy.Text))
        {
            drpBO.drpGeneric(drpSearchByValue, Constants.DropDownType.DB_VALUE, DrpDataType.DEPARTMENT, null, selectItem, userDefDto.FirmNumber);
        }
    }
    protected void onSearchByValue(object sender, EventArgs e)
    {
        populateEmployeeGrid();
        resetForm(PageMode.NONE, tab1AnchorId.ID);
    }
    protected void selectEmployee(object sender, EventArgs e)
    {
        try
        {
            GroupRadioButton rd = (GroupRadioButton)sender;
            resetForm(PageMode.VIEW, tab1AnchorId.ID);
            if (rd.Checked)
            {
                string strId = ((Button)(((GridViewRow)rd.NamingContainer).FindControl("btnEmpRowIdentifier"))).Attributes["row-identifier"];
                FirmMemberDTO firmMemberDto = employeeBO.fetchEmployee(long.Parse(strId));
                ViewState[VS_SELECTED_EMPLOYEE] = firmMemberDto;
                populateUIFieldsFromDTO(firmMemberDto);
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message, exp);
            setErrorMessage(Resources.Messages.system_error, tab1ValidationGrp);
        }
    }
    /*
     * This method is called on click of ADD button in datatable top bar.
     */
    protected void onClickAddEmployeeBtn(object sender, EventArgs e)
    {
        deSelectEmployeeGrid();
        resetForm(PageMode.ADD, tab2AnchorId.ID);
    }
    protected void onClickModifyEmployeeBtn(object sender, EventArgs e)
    {
        try
        {
            if (validateEmployeeSelected())
            {
                resetForm(PageMode.MODIFY, tab2AnchorId.ID);
                FirmMemberDTO firmMemberDto = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
                populateUIFieldsFromDTO(firmMemberDto);
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message, exp);
            setErrorMessage(Resources.Messages.system_error, tab1ValidationGrp);
        }

    }
    protected void deleteEmployee(object sender, EventArgs e)
    {
        try
        {
            if (validateEmployeeSelected())
            {
                FirmMemberDTO firmMemberDto = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
                employeeBO.deleteEmployee(firmMemberDto.Id);
                populateEmployeeGrid();
                resetForm(PageMode.NONE, tab1AnchorId.ID);
                setSuccessMessage("Employee deleted successfully", "1");
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab1ValidationGrp);
        }
    }
    protected void addEmployee(object sender, EventArgs e)
    {
        try
        {
            FirmMemberDTO firmMemberDto = populateEmployeeDTOAdd();
            long Id = employeeBO.saveEmployee(firmMemberDto);
            populateEmployeeGrid();
            setSuccessMessage("Employee added successfully", "2");
            reSelectEmployeeForUpdate(Id, null, tab2AnchorId.ID);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab1ValidationGrp);
        }
    }
    protected void updateEmployee(object sender, EventArgs e)
    {
        try
        {
            FirmMemberDTO firmMemberDto = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
            populateEmployeeDTOFromUI(firmMemberDto);
            employeeBO.updateEmployee(firmMemberDto);
            populateEmployeeGrid();
            setSuccessMessage("Employee updated successfully", "2");
            reSelectEmployeeForUpdate(firmMemberDto.Id, null, tab2AnchorId.ID);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    private void reSelectEmployeeForUpdate(long Id, FirmMemberDTO firmMemberDto, string activeTabId)
    {
        if (employeeGrid.Rows.Count > 0)
        {
            foreach (GridViewRow row in employeeGrid.Rows)
            {
                GroupRadioButton radioBtn = (GroupRadioButton)row.FindControl("rdEmployeeSelect");
                Button rowIdenBtn = (Button)row.FindControl("btnEmpRowIdentifier");
                if (radioBtn != null)
                {
                    radioBtn.Checked = false;
                    if (rowIdenBtn != null && Id.ToString().Equals(rowIdenBtn.Attributes["row-identifier"]))
                    {
                        radioBtn.Checked = true;
                        setTabInfo(PageMode.VIEW, activeTabId);
                        break;
                    }
                }
            }
            if(firmMemberDto == null) firmMemberDto = employeeBO.fetchEmployee(Id);
            ViewState[VS_SELECTED_EMPLOYEE] = firmMemberDto;
            populateUIFieldsFromDTO(firmMemberDto);
        }

    }
    protected void cancelEmployee(object sender, EventArgs e)
    {
        resetForm(PageMode.NONE, tab1AnchorId.ID);
        FirmMemberDTO firmMemberDto = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
        populateEmployeeGrid();
        if(firmMemberDto != null) {
            reSelectEmployeeForUpdate(firmMemberDto.Id, null, tab1AnchorId.ID);
        }
    }
    private bool validateEmployeeSelected()
    {
        bool isSelected = true;
        FirmMemberDTO firmMemberDto = (FirmMemberDTO)ViewState[VS_SELECTED_EMPLOYEE];
        if (firmMemberDto == null)
        {
            isSelected = false;
            resetForm(PageMode.NONE, tab1AnchorId.ID);
            setErrorMessage("Please select an Employee.", tab1ValidationGrp);
        }
        return isSelected;
    }
    private FirmMemberDTO populateEmployeeDTOAdd()
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        FirmMemberDTO firmMemberDto = new FirmMemberDTO();
        populateEmployeeDTOFromUI(firmMemberDto);
        firmMemberDto.FirmNumber = userDefDto.FirmNumber;
        firmMemberDto.InsertUser = userDefDto.Username;
        return firmMemberDto;
    }
    private void populateEmployeeDTOFromUI(FirmMemberDTO firmMemberDto)
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        firmMemberDto.Salutation = CommonUtil.getMasterControlDTO(drpSalutation.Text);
        firmMemberDto.FirstName = txtFirstName.Text;
        firmMemberDto.MiddleName = txtMiddleName.Text;
        firmMemberDto.LastName = txtLastName.Text;
        firmMemberDto.ContactInfo = new ContactInfoDTO();
        firmMemberDto.ContactInfo.Gender = drpGender.Text;
        firmMemberDto.ContactInfo.Dob = DateTime.ParseExact(txtDOB.Text, Constants.DATE_FORMAT, CultureInfo.InvariantCulture);
        firmMemberDto.ContactInfo.MaritalStatus = drpMaritalStatus.Text;
        firmMemberDto.ContactInfo.Contact = txtContact.Text;
        firmMemberDto.ContactInfo.AltContact = txtAltContact.Text;
        firmMemberDto.ContactInfo.Email = txtEmail.Text;
        /*firmMemberDto.ContactInfo.CurrentAddressLine1 = txtCurrentAddressLine1.Text;
        firmMemberDto.ContactInfo.CurrentAddressLine2 = txtCurrentAddressLine2.Text;
        firmMemberDto.ContactInfo.CurrentTown = txtCurrentTown.Text;
        firmMemberDto.ContactInfo.CurrentCity = txtCurrentCity.Text;
        firmMemberDto.ContactInfo.CurrentState = txtCurrentState.Text;
        firmMemberDto.ContactInfo.CurrentCountry = txtCurrentCountry.Text;
        firmMemberDto.ContactInfo.CurrentPin = txtCurrentPIN.Text;*/

        firmMemberDto.Department = CommonUtil.getDepartmentDTO(drpDepartment.Text);
        if (!string.IsNullOrWhiteSpace(txtJoiningDate.Text)) firmMemberDto.JoiningDate = DateTime.ParseExact(txtJoiningDate.Text, Constants.DATE_FORMAT, CultureInfo.InvariantCulture); else firmMemberDto.JoiningDate = null;
        firmMemberDto.Designation = CommonUtil.getMasterControlDTO(drpDesignation.Text);
        firmMemberDto.Description = txtDescription.Text;
        firmMemberDto.Qualification = txtQualification.Text;
        firmMemberDto.UpdateUser = userDefDto.Username;
    }
    private void populateUIFieldsFromDTO(FirmMemberDTO firmMemberDto)
    {
        if (firmMemberDto != null) drpSalutation.Text = firmMemberDto.Salutation.Id.ToString(); else drpSalutation.ClearSelection();
        if (firmMemberDto != null) txtFirstName.Text = firmMemberDto.FirstName; else txtFirstName.Text = null;
        if (firmMemberDto != null) txtMiddleName.Text = firmMemberDto.MiddleName; else txtMiddleName.Text = null;
        if (firmMemberDto != null) txtLastName.Text = firmMemberDto.LastName; else txtLastName.Text = null;
        if (firmMemberDto != null) drpGender.Text = firmMemberDto.ContactInfo.Gender; else drpGender.ClearSelection();
        if (firmMemberDto != null && firmMemberDto.ContactInfo.Dob != null) txtDOB.Text = firmMemberDto.ContactInfo.Dob.Value.ToString(Constants.DATE_FORMAT); else txtDOB.Text = null;
        if (firmMemberDto != null) drpMaritalStatus.Text = firmMemberDto.ContactInfo.MaritalStatus; else drpMaritalStatus.ClearSelection();
        if (firmMemberDto != null) txtContact.Text = firmMemberDto.ContactInfo.Contact; else txtContact.Text = null;
        if (firmMemberDto != null) txtAltContact.Text = firmMemberDto.ContactInfo.AltContact; else txtAltContact.Text = null;
        if (firmMemberDto != null) txtEmail.Text = firmMemberDto.ContactInfo.Email; else txtEmail.Text = null;
        /*if (firmMemberDto != null) txtCurrentAddressLine1.Text = firmMemberDto.ContactInfo.CurrentAddressLine1; else txtCurrentAddressLine1.Text = null;
        if (firmMemberDto != null) txtCurrentAddressLine2.Text = firmMemberDto.ContactInfo.CurrentAddressLine2; else txtCurrentAddressLine2.Text = null;
        if (firmMemberDto != null) txtCurrentTown.Text = firmMemberDto.ContactInfo.CurrentTown; else txtCurrentTown.Text = null;
        if (firmMemberDto != null) txtCurrentCity.Text = firmMemberDto.ContactInfo.CurrentCity; else txtCurrentCity.Text = null;
        if (firmMemberDto != null) txtCurrentState.Text = firmMemberDto.ContactInfo.CurrentState; else txtCurrentState.Text = null;
        if (firmMemberDto != null) txtCurrentCountry.Text = firmMemberDto.ContactInfo.CurrentCountry; else txtCurrentCountry.Text = null;
        if (firmMemberDto != null) txtCurrentPIN.Text = firmMemberDto.ContactInfo.CurrentPin; else txtCurrentPIN.Text = null;*/

        if (firmMemberDto != null && firmMemberDto.Department != null) drpDepartment.Text = firmMemberDto.Department.Id.ToString(); else drpDepartment.ClearSelection();
        if (firmMemberDto != null && firmMemberDto.JoiningDate != null) txtJoiningDate.Text = firmMemberDto.JoiningDate.Value.ToString(Constants.DATE_FORMAT); else txtJoiningDate.Text = null;
        if (firmMemberDto != null && firmMemberDto.Designation != null) drpDesignation.Text = firmMemberDto.Designation.Id.ToString(); else drpDesignation.ClearSelection();
        if (firmMemberDto != null) txtDescription.Text = firmMemberDto.Description; else txtDescription.Text = null;
        if (firmMemberDto != null) txtQualification.Text = firmMemberDto.Qualification; else txtQualification.Text = null;
        if (firmMemberDto != null) txtEmployeeId.Text = firmMemberDto.EmployeeId; else txtEmployeeId.Text = null;
    }
}
