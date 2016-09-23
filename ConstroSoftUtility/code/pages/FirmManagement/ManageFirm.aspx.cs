using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConstroSoft;
using Vladsm.Web.UI.WebControls;

public partial class ManageFirm : System.Web.UI.Page
{
    private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    string tab1Id = "#tab1Content";
    string tab2Id = "#tab2Content";
    string tab1ValidationGrp = "tab1Error";
    string tab2ValidationGrp = "tab2Error";
    string VS_FIRM = "FIRM";
    string VS_SELECTED_ACNT = "SELECTED_ACNT";
    DropdownBO drpBO = new DropdownBO();
    FirmBO firmBO = new FirmBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        clearMessages();
        if (!IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                resetAccountDetailFormWithSelection();
                initDropdowns();
                populateFirmDetails();
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
        drpBO.drpGeneric(drpAcntType, Constants.DropDownType.DB_VALUE, DrpDataType.MASTER_CONTROL_DATA, Constants.MCDType.ACCOUNT_TYPE, null, userDefDto.FirmNumber);
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
            btnUpdate.Visible = false;
            viewOnlyTableHdn.Value = "true";
            accountGrid.Columns[0].Visible = false;
            addAccountBtn.Visible = false;
        }
    }
    private void clearMessages()
    {
        tab1SuccessPanel.Visible = false;
        lbTab1Success.Text = "";
        tab2SuccessPanel.Visible = false;
        lbTab2Success.Text = "";
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

    public void resetAllFormInputs()
    {
        resetAccountDetailFormWithSelection();
    }

    public void resetAccountDetailForm()
    {
        txtAcntName.Text = null;
        txtAcntNumber.Text = null;
        drpAcntType.ClearSelection();
        txtAcntBalance.Text = null;
        txtAcntIFSCCode.Text = null;
        txtAcntBankName.Text = null;
        txtAcntBranch.Text = null;
        txtAcntCity.Text = null;
        txtAcntState.Text = null;
        txtAcntCountry.Text = null;
        pnlAccountAdd.Visible = false;
    }
    public void resetAccountDetailFormWithSelection()
    {
        resetAccountDetailForm();
        if (accountGrid.Rows.Count > 0)
        {
            foreach (GridViewRow row in accountGrid.Rows)
            {
                GroupRadioButton radioBtn = (GroupRadioButton)row.FindControl("rdAccountSelect");
                if (radioBtn != null) radioBtn.Checked = false;
            }
        }
        ViewState[VS_SELECTED_ACNT] = null;
    }
    private void initAccountAddUpdateSection(bool isAdd)
    {
        lbAcntAction.Text = (isAdd) ? "Add Account" : "Update Account";
        pnlAccountAdd.Visible = true;
        btnAcntSave.Visible = isAdd;
        btnAcntUpdate.Visible = !isAdd;
    }

    private void setTabInfo(PageMode pageMode, string activeTabValue)
    {
        if (PageMode.ADD == pageMode)
        {
            tab2AnchorId.Text = Resources.Labels.firm_sm_firm_dtls_tab_manage_acnt;
        }
        else if (PageMode.MODIFY == pageMode)
        {
        }
        else
        {
        }
        activeTabHdn.Value = activeTabValue;
    }
    
    public void initBootstrapComponantsFromServer()
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BootStrapComponants", "initBootstrapComponants()", true);
    }
    private void populateFirmDetails()
    {
        try
        {
            UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
            FirmDTO firmDto = firmBO.fetchFirmDetails(userDefDto.FirmNumber);
            ViewState[VS_FIRM] = null;
            ViewState[VS_FIRM] = firmDto;
            if (firmDto != null)
            {
                txtFirmName.Text = firmDto.Name;
                txtRegistrationNo.Text = firmDto.RegistrationNo;
                txtContact.Text = firmDto.ContactInfo.Contact;
                txtDescription.Text = firmDto.Description;
                txtEmail.Text = firmDto.ContactInfo.Email;
                txtWebSite.Text = firmDto.WebSite;
                /*txtAddressLine1.Text = firmDto.ContactInfo.CurrentAddressLine1;
                txtAddressLine2.Text = firmDto.ContactInfo.CurrentAddressLine2;
                txtTown.Text = firmDto.ContactInfo.CurrentTown;
                txtCity.Text = firmDto.ContactInfo.CurrentCity;
                txtState.Text = firmDto.ContactInfo.CurrentState;
                txtCountry.Text = firmDto.ContactInfo.CurrentCountry;
                txtPIN.Text = firmDto.ContactInfo.CurrentPin;*/
                accountGrid.DataSource = firmDto.FirmAccounts;
                accountGrid.DataBind();
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(Resources.Messages.system_error, tab1ValidationGrp);
        }
    }
    
    /*
     * This method is called on click of ADD button in datatable top bar.
     */
    protected void onClickAddAccountBtn(object sender, EventArgs e)
    {
        resetAccountDetailFormWithSelection();
        initAccountAddUpdateSection(true);
    }
    protected void selectAccount(object sender, EventArgs e)
    {
        GroupRadioButton rd = (GroupRadioButton)sender;
        resetAccountDetailForm();
        if (rd.Checked)
        {
            string strId = ((Button)(((GridViewRow)rd.NamingContainer).FindControl("acntRowIndBtn"))).Attributes["row-identifier"];
            FirmAccountDTO accountDto = getAccountDto(strId);
            ViewState[VS_SELECTED_ACNT] = accountDto;
        }
    }
    protected void editSelectedAccount(object sender, EventArgs e)
    {
        if (validateAccountSelected())
        {
            FirmAccountDTO accountDto = (FirmAccountDTO)ViewState[VS_SELECTED_ACNT];
            txtAcntName.Text = accountDto.Name;
            drpAcntType.Text = accountDto.AccountType.Id.ToString();
            txtAcntNumber.Text = accountDto.AccountNo;
            txtAcntBalance.Text = accountDto.AccountBalance.ToString();
            txtAcntIFSCCode.Text = accountDto.IfscCode;
            txtAcntBankName.Text = accountDto.BankName;
            txtAcntBranch.Text = accountDto.Branch;
            /*txtAcntCity.Text = accountDto.City;
            txtAcntState.Text = accountDto.State;
            txtAcntCountry.Text = accountDto.Country;*/
            initAccountAddUpdateSection(false);
        }
    }
    private bool validateAccountSelected()
    {
        bool isSelected = true;
        FirmAccountDTO accountDto = (FirmAccountDTO)ViewState[VS_SELECTED_ACNT];
        if (accountDto == null)
        {
            isSelected = false;
            resetAccountDetailFormWithSelection();
            setErrorMessage("Please select an account.", tab2ValidationGrp);
        }
        return isSelected;
    }
    private FirmAccountDTO getAccountDto(string accountId)
    {
        FirmDTO firmDto = (FirmDTO)ViewState[VS_FIRM];
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
    protected void deleteAccount(object sender, EventArgs e)
    {
        try
        {
            if (validateAccountSelected())
            {
                FirmAccountDTO accountDto = (FirmAccountDTO)ViewState[VS_SELECTED_ACNT];
                firmBO.deleteFirmAccount(accountDto.Id);
                resetAccountDetailFormWithSelection();
                populateFirmDetails();
                setSuccessMessage(Resources.Messages.firm_success_acnt_delete, tab2Id);
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void addNewAccount(object sender, EventArgs e)
    {
        try
        {
            FirmAccountDTO firmAccountDto = populateAccountDTO();
            firmBO.saveFirmAccount(firmAccountDto);
            resetAccountDetailFormWithSelection();
            populateFirmDetails();
            setSuccessMessage(Resources.Messages.firm_success_acnt_add, tab2Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void updateAccount(object sender, EventArgs e)
    {
        try
        {
            if (validateAccountSelected())
            {
                FirmAccountDTO accountDto = (FirmAccountDTO)ViewState[VS_SELECTED_ACNT];
                UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
                populateAccountFromUI(accountDto, userDefDto);
                firmBO.updateFirmAccount(accountDto);
                resetAccountDetailFormWithSelection();
                populateFirmDetails();
                setSuccessMessage(Resources.Messages.firm_success_acnt_update, tab2Id);
            }
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab2ValidationGrp);
        }
    }
    protected void cancelAccount(object sender, EventArgs e)
    {
        resetAccountDetailFormWithSelection();
    }
    protected void updateFirmDetails(object sender, EventArgs e)
    {
        try
        {
            FirmDTO firmDto = (FirmDTO)ViewState[VS_FIRM];
            UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
            populateFirmFromUI(firmDto, userDefDto);
            firmBO.updateFirm(firmDto);
            resetAccountDetailFormWithSelection();
            populateFirmDetails();
            setSuccessMessage(Resources.Messages.firm_success_firm_update, tab1Id);
        }
        catch (Exception exp)
        {
            log.Error(exp.Message);
            setErrorMessage(exp.Message, tab1ValidationGrp);
            populateFirmDetails();
        }
    }
    private void populateFirmFromUI(FirmDTO firmDto, UserDefinitionDTO userDefDto)
    {
        firmDto.RegistrationNo = txtRegistrationNo.Text;
        firmDto.ContactInfo.Contact = txtContact.Text;
        firmDto.Description = txtDescription.Text;
        firmDto.ContactInfo.Email = txtEmail.Text;
        firmDto.WebSite = txtWebSite.Text;
        /*firmDto.ContactInfo.CurrentAddressLine1 = txtAddressLine1.Text;
        firmDto.ContactInfo.CurrentAddressLine2 = txtAddressLine2.Text;
        firmDto.ContactInfo.CurrentTown = txtTown.Text;
        firmDto.ContactInfo.CurrentCity = txtCity.Text;
        firmDto.ContactInfo.CurrentState = txtState.Text;
        firmDto.ContactInfo.CurrentCountry = txtCountry.Text;
        firmDto.ContactInfo.CurrentPin = txtPIN.Text;*/
        firmDto.UpdateUser = userDefDto.Username;
    }
    private FirmAccountDTO populateAccountDTO()
    {
        UserDefinitionDTO userDefDto = (UserDefinitionDTO)Session[Constants.Session.USERDEFINITION];
        FirmDTO firmDto = (FirmDTO)ViewState[VS_FIRM];
        FirmAccountDTO accountDto = new FirmAccountDTO();
        populateAccountFromUI(accountDto, userDefDto);
        accountDto.FirmNumber = userDefDto.FirmNumber;
        accountDto.InsertUser = userDefDto.Username;
        accountDto.Firm = firmDto;
        return accountDto;
    }
    private void populateAccountFromUI(FirmAccountDTO accountDto, UserDefinitionDTO userDefDto)
    {
        accountDto.Name = txtAcntName.Text;
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
        /*accountDto.City = txtAcntCity.Text;
        accountDto.State = txtAcntState.Text;
        accountDto.Country = txtAcntCountry.Text;*/
        accountDto.UpdateUser = userDefDto.Username;
    }
}
