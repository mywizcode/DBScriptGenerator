using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConstroSoft;

public partial class ManageEnquiry : System.Web.UI.Page
{
    private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    string tab1Id = "#tab1Content";
    string tab2Id = "#tab2Content";
    string tab1ValidationGrp = "tab1Error";
    string tab2ValidationGrp = "tab2Error";
    string VS_ENQUIRY_LIST = "ENQUIRY_LIST";
    string VS_SELECTED_ENQUIRY = "SELECTED_ENQUIRY";
    DropdownBO drpBO = new DropdownBO();
    EnquiryBO enquiryBO = new EnquiryBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        clearMessages();
        if (!IsPostBack)
        {
            if (Session[Constants.Session.USERNAME] != null)
            {
                resetAllFormInputs();
                initDropdowns();
                populateEnquiryDetails();
            }
            else
            {
                Response.Redirect(Constants.URL.LOGIN, false);
            }
        }
    }
    private void initDropdowns()
    {
        //TODO - Bind dropdown fields here
        string[] selectItem = {Constants.DropDownItem.SELECT, Constants.DropDownItem.SELECT_VALUE};
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        drpBO.drpGeneric(drpSalutation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.SALUTATION, null, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpOccupation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.OCCUPATION, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpPropertyType, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.PROPERTY_TYPE, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpPropertyLocation, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.PROPERTY_LOCATION, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpPropUnitType, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.PR_UNIT_TYPE, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpEnquirySource, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.ENQUIRY_SOURCE, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpProperty, Constants.DropDownType.DB_VALUE, DrpDataType.PROPERTY_NAME, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpEmployee, Constants.DropDownType.DB_VALUE, DrpDataType.EMPLOYEE_NAME, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpSearchBy, Constants.DropDownType.STATIC_VALUE, DrpDataType.ENQUIRY_SEARCH_BY, null, selectItem, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpGender, Constants.DropDownType.STATIC_VALUE, DrpDataType.GENDER, null, null, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpMaritalStatus, Constants.DropDownType.STATIC_VALUE, DrpDataType.MARITAL_STATUS, null, null, userDefDto.FirmNumber);
        drpBO.drpGeneric(drpEnquiryStatus, Constants.DropDownType.STATIC_VALUE, DrpDataType.ENQUIRY_STATUS, null, null, userDefDto.FirmNumber);
    }
    /**
     * This method is called just before the page is rendered. So any change in state of the element is applied.
     **/
    protected void Page_PreRender(object sender, EventArgs e)
    {
        applyEntitlement();
        initBootstrapComponantsFromServer();
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
            //TODO - Hide buttons when read only user
            //btnUpdate.Visible = false;
            viewOnlyTableHdn.Value = "true";
            //accountGrid.Columns[0].Visible = false;
            addEnquiryBtn.Visible = false;
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

    public void setSuccessMessage(string msg, string tab)
    {
        if (tab1Id.Equals(tab))
        {
            lbTab1Success.Text = msg;
            tab1SuccessPanel.Visible = true;
            activeTabHdn.Value = tab1Id;
        }
        else if (tab2Id.Equals(tab))
        {
            lbTab2Success.Text = msg;
            tab2SuccessPanel.Visible = true;
            activeTabHdn.Value = tab2Id;
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
    public void resetAllFormInputs()
    {
        ViewState[VS_SELECTED_ENQUIRY] = null;
        tab2AnchorId.Visible = false;
        tab3AnchorId.Visible = false;
    }

    private void setTabInfo(PageMode pageMode, string activeTabValue)
    {
        if (PageMode.ADD == pageMode)
        {
            tab2AnchorId.Text = Resources.Labels.enqm_sm_manage_enq_tab2_add_name;
            tab3AnchorId.Text = Resources.Labels.enqm_sm_manage_enq_tab3_add_name;
        }
        else if (PageMode.MODIFY == pageMode)
        {
        } else
        {
        }
        activeTabHdn.Value = activeTabValue;
    }
    
    protected void saveModalData(object sender, EventArgs e)
    {
        String errorMsg = "";
        if (modalHdnType.Value == "PROPERTY_TYPE")
        {
            //errorMsg = validatePropTypeModalInput(modalInput1.Text);
            if (string.IsNullOrWhiteSpace(modalInput1.Text)) errorMsg = "Property Type is required";
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
              //  db.insert("insert into tbl_Type (type,typedescription) values ('" + modalInput1.Text + "','" + modalInput2.Text + "') ");
               // bind.PropertyTypeBind(drpPropertyType);
                modalIdentifierHdn.Value = "";
            }
        }
        else if (modalHdnType.Value == "PROPERTY_LOCATION")
        {
            //errorMsg = validateLocationModalInput(modalInput1.Text);
            if (string.IsNullOrWhiteSpace(modalInput1.Text)) errorMsg = "Property Location is required";
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
              //  db.insert("insert into tbl_location (location,locdescription) values ('" + modalInput1.Text + "','" + modalInput2.Text + "')");
               // bind.bindLocation(drpLocation);
                modalIdentifierHdn.Value = "";
            }
        }
        else if (modalHdnType.Value == "PROPERTY_UNIT_TYPE")
        {
            //errorMsg = validateAmenityInputs();
            if (string.IsNullOrWhiteSpace(modalInput1.Text)) errorMsg = "Property Unit Type is required";
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
              //  updateAmenityGrid();
            }
        }
        else if (modalHdnType.Value == "ENQUIRY_SOURCE")
        {
            //errorMsg = validateAmenityInputs();
            if (string.IsNullOrWhiteSpace(modalInput1.Text)) errorMsg = "Enquiry Source is required";
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                //  updateAmenityGrid();
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
            //NOTE: modalIdentifierHdn is not reset because when row is selected for EDIT in datatable, after update same page should be shown in datatable.
            //modalIdentifierHdn.Value = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "closeDialogClient", "closeDialogClient()", true);
        }

    }
    private void populateEnquiryDetails()
    {
        try
        {
            UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
            IList<EnquiryDetailDTO> results = enquiryBO.fetchEnquiryGridData(userDefDto.FirmNumber);
            ViewState[VS_ENQUIRY_LIST] = null;
            ViewState[VS_ENQUIRY_LIST] = results;
            enquiryGrid.DataSource = results;
            enquiryGrid.DataBind();
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(Resources.Messages.system_error, tab1ValidationGrp);
        }
    }
    private void initAccountAddUpdateSection(bool isAdd)
    {
        //lbAcntAction.Text = (isAdd) ? "Add Account" : "Update Account";
        //pnlAccountAdd.Visible = true;
        //btnAcntSave.Visible = isAdd;
        //btnAcntUpdate.Visible = !isAdd;
    }
    protected void onSearchBy(object sender, EventArgs e)
    {
    }
    protected void onSearchByValue(object sender, EventArgs e)
    {
    }
    /*
     * This method is called on click of ADD button in datatable top bar.
     */
    protected void onClickAddEnquiryBtn(object sender, CommandEventArgs e)
    {
        resetAllFormInputs();
        tab2AnchorId.Visible = true;
        tab3AnchorId.Visible = true;
        initAccountAddUpdateSection(true);
    }
    protected void selectForEditEnquiry(object sender, EventArgs e)
    {
        /*string accountId = e.CommandArgument.ToString();
        resetTabInfo(true, Resources.Labels.firm_sm_firm_dtls_tab_manage_acnt, tab2Id);
        FirmAccountDTO accountDto = getAccountDto(accountId);
        ViewState[VS_SELECTED_ENQUIRY] = accountDto;
        /*txtAcntName.Text = accountDto.Name;
        drpAcntType.Text = accountDto.AccountType.Id.ToString();
        txtAcntNumber.Text = accountDto.AccountNo;
        txtAcntBalance.Text = accountDto.AccountBalance.ToString();
        txtAcntIFSCCode.Text = accountDto.IfscCode;
        txtAcntBankName.Text = accountDto.BankName;
        txtAcntBranch.Text = accountDto.Branch;
        txtAcntCity.Text = accountDto.City;
        txtAcntState.Text = accountDto.State;
        txtAcntCountry.Text = accountDto.Country;*/

        initAccountAddUpdateSection(false);
    }
    private FirmAccountDTO getAccountDto(string accountId)
    {
        FirmDTO firmDto = (FirmDTO)ViewState[VS_ENQUIRY_LIST];
        long acntId = long.Parse(accountId);
        FirmAccountDTO selectedAccountDto = null;
        foreach (FirmAccountDTO accountDto in firmDto.FirmAccounts)
        {
            if (acntId == accountDto.Id)
            {
                selectedAccountDto = accountDto;
                break;
            }
        }
        return selectedAccountDto;
    }
    protected void deleteEnquiry(object sender, CommandEventArgs e)
    {
        try
        {
            string accountId = e.CommandArgument.ToString();
            long id = long.Parse(accountId);
            //firmBO.deleteFirmAccount(id);
            resetAllFormInputs();
            populateEnquiryDetails();
            setSuccessMessage(Resources.Messages.firm_success_acnt_delete, tab2Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void addEnquiry(object sender, EventArgs e)
    {
        try
        {
           // FirmAccountDTO firmAccountDto = populateEnquiryDetailDTO();
            //firmBO.saveFirmAccount(firmAccountDto);
            resetAllFormInputs();
            populateEnquiryDetails();
            setSuccessMessage(Resources.Messages.firm_success_acnt_add, tab2Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void updateEnquiry(object sender, EventArgs e)
    {
        try
        {
            FirmAccountDTO accountDto = (FirmAccountDTO)ViewState[VS_SELECTED_ENQUIRY];
            UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
            //populateAccountFromUI(accountDto, userDefDto);
            //firmBO.updateFirmAccount(accountDto);
            //resetTabInfo(true, Resources.Labels.firm_sm_firm_dtls_tab_manage_acnt, tab2Id);
            //populateEnquiryDetails();
            setSuccessMessage(Resources.Messages.firm_success_acnt_update, tab2Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void cancelEnquiry(object sender, EventArgs e)
    {
        resetAllFormInputs();
    }
    protected void updateFirmDetails(object sender, EventArgs e)
    {
        try
        {
            FirmDTO firmDto = (FirmDTO)ViewState[VS_ENQUIRY_LIST];
            UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
            populateFirmFromUI(firmDto, userDefDto);
            //firmBO.updateFirm(firmDto);
            resetAllFormInputs();
            populateEnquiryDetails();
            setSuccessMessage(Resources.Messages.firm_success_firm_update, tab1Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab1ValidationGrp);
            populateEnquiryDetails();
        }
    }
    private void populateFirmFromUI(FirmDTO firmDto, UserDefinitionDTO userDefDto)
    {
       /* firmDto.RegistrationNo = txtRegistrationNo.Text;
        firmDto.ContactInfo.Contact = txtContact.Text;
        firmDto.Description = txtDescription.Text;
        firmDto.ContactInfo.Email = txtEmail.Text;
        firmDto.WebSite = txtWebSite.Text;
        firmDto.ContactInfo.PrimAddressLine1 = txtAddressLine1.Text;
        firmDto.ContactInfo.PrimAddressLine2 = txtAddressLine2.Text;
        firmDto.ContactInfo.PrimTown = txtTown.Text;
        firmDto.ContactInfo.PrimCity = txtCity.Text;
        firmDto.ContactInfo.PrimState = txtState.Text;
        firmDto.ContactInfo.PrimCountry = txtCountry.Text;
        firmDto.ContactInfo.PrimPin = txtPIN.Text;
        firmDto.UpdateUser = userDefDto.Username;*/
    }
    private EnquiryDetailDTO populateEnquiryDetailDTO()
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        FirmDTO firmDto = (FirmDTO)ViewState[VS_ENQUIRY_LIST];
        EnquiryDetailDTO enquiryDetailDto = new EnquiryDetailDTO();
        populateEnquiryDetailFromUI(enquiryDetailDto, userDefDto);
        enquiryDetailDto.FirmNumber = userDefDto.FirmNumber;
        enquiryDetailDto.InsertUser = userDefDto.Username;
        //enquiryDetailDto.Firm = firmDto;
        return enquiryDetailDto;
    }
    private void populateEnquiryDetailFromUI(EnquiryDetailDTO enquiryDetailDto, UserDefinitionDTO userDefDto)
    {
        enquiryDetailDto.Salutation = CommonUtil.getMasterControlDTO(drpSalutation.Text);
        enquiryDetailDto.FirstName = txtFirstName.Text;
        enquiryDetailDto.MiddleName = txtMiddleName.Text;
        enquiryDetailDto.LastName = txtLastName.Text;
        //enquiryDetailDto.ContactInfo = DomainToDTOUtil.convertToContactInfoDTO(enquiryDetail.ContactInfo);
        enquiryDetailDto.Occupation = CommonUtil.getMasterControlDTO(drpOccupation.Text);
        //enquiryDetailDto.EnquiryDate = txtEnquiryDate.Text;
        enquiryDetailDto.PropertyType = CommonUtil.getMasterControlDTO(drpPropertyType.Text);
        enquiryDetailDto.PropertyLocation = CommonUtil.getMasterControlDTO(drpPropertyLocation.Text);
        /*enquiryDetailDto.Property = DomainToDTOUtil.convertToPropertyDTO(enquiryDetail.Property, false);
        enquiryDetailDto.PrUnitType = CommonUtil.getMasterControlDTO(enquiryDetail.PrUnitType, false);
        enquiryDetailDto.EnquirySource = CommonUtil.getMasterControlDTO(enquiryDetail.EnquirySource, false);
        enquiryDetailDto.Budget = enquiryDetail.Budget;
        enquiryDetailDto.FirmMember = DomainToDTOUtil.convertToFirmMemberDTO(enquiryDetail.FirmMember, false);
        enquiryDetailDto.FirmNumber = enquiryDetail.FirmNumber;
        enquiryDetailDto.Status = enquiryDetail.Status;
        enquiryDetailDto.FollowupDate = enquiryDetail.FollowupDate;
        enquiryDetailDto.Comments = enquiryDetail.Comments;
        enquiryDetailDto.CloseReason = enquiryDetail.CloseReason;
        enquiryDetailDto.InsertUser = enquiryDetail.InsertUser;
        enquiryDetailDto.UpdateUser = enquiryDetail.UpdateUser;
        enquiryDetailDto.InsertDate = enquiryDetail.InsertDate;
        enquiryDetailDto.UpdateDate = enquiryDetail.UpdateDate;
        enquiryDetailDto.Version = enquiryDetail.Version;
      /*  accountDto.Name = txtAcntName.Text;
        long selectedAcntTypeId = long.Parse(drpAcntType.Text);
        if (accountDto.AccountType == null || accountDto.AccountType.Id != selectedAcntTypeId)
        {
            MasterControlDataDTO accountType = new MasterControlDataDTO();
            accountType.Id = selectedAcntTypeId;
            accountDto.AccountType = accountType;
        }
        accountDto.AccountNo = txtAcntNumber.Text;
        accountDto.IfscCode = txtAcntIFSCCode.Text;
        accountDto.BankName = txtAcntBankName.Text;
        accountDto.Branch = txtAcntBranch.Text;
        accountDto.City = txtAcntCity.Text;
        accountDto.State = txtAcntState.Text;
        accountDto.Country = txtAcntCountry.Text;
        accountDto.UpdateUser = userDefDto.Username;*/
    }
}
