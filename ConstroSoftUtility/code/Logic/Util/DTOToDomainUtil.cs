
/// <summary>
/// Summary description for CommonUtil
/// </summary>
using ConstroSoft;
using System.Collections.Generic;
using System;
namespace ConstroSoft
{
    public class DTOToDomainUtil
    {
        public DTOToDomainUtil() { }

        public static void copyToContactInfo(ContactInfo contactInfo, ContactInfoDTO contactInfoDto)
        {
            contactInfo.Contact = contactInfoDto.Contact;
            contactInfo.AltContact = contactInfoDto.AltContact;
            contactInfo.Email = contactInfoDto.Email;
            contactInfo.AltEmail = contactInfoDto.AltEmail;
            contactInfo.Gender = contactInfoDto.Gender;
            contactInfo.MaritalStatus = contactInfoDto.MaritalStatus;
            contactInfo.Dob = contactInfoDto.Dob;
        }
        public static MasterControlData copyMasterControlId(MasterControlData masterControlData, MasterControlDataDTO masterControlDataDto)
        {
            MasterControlData tmpMasterControlData = masterControlData;
            if (masterControlDataDto == null ) tmpMasterControlData = null;
            else if (masterControlData == null || (masterControlData.Id != masterControlDataDto.Id))
            {
                tmpMasterControlData = new MasterControlData();
                tmpMasterControlData.Id = masterControlDataDto.Id;
            }
            return tmpMasterControlData;
        }
        public static Firm copyFirmId(Firm firm, FirmDTO firmDto)
        {
            Firm tmpFirm = firm;
            if (firmDto == null) tmpFirm = null;
            else if (firm == null || (firm.Id != firmDto.Id))
            {
                tmpFirm = new Firm();
                tmpFirm.Id = firmDto.Id;
            }
            return tmpFirm;
        }
        public static Country copyCountryId(Country country, CountryDTO countryDto)
        {
            Country tmpCountry = country;
            if (countryDto == null) tmpCountry = null;
            else if (country == null || (country.Id != countryDto.Id))
            {
                tmpCountry = new Country();
                tmpCountry.Id = countryDto.Id;
            }
            return tmpCountry;
        }
        public static State copyStateId(State state, StateDTO stateDto)
        {
            State tmpState = state;
            if (stateDto == null) tmpState = null;
            else if (state == null || (state.Id != stateDto.Id))
            {
                tmpState = new State();
                tmpState.Id = stateDto.Id;
            }
            return tmpState;
        }
        public static City copyCityId(City city, CityDTO cityDto)
        {
            City tmpCity = city;
            if (cityDto == null) tmpCity = null;
            else if (city == null || (city.Id != cityDto.Id))
            {
                tmpCity = new City();
                tmpCity.Id = cityDto.Id;
            }
            return tmpCity;
        }
        public static Property copyPropertyId(Property property, PropertyDTO propertyDto)
        {
            Property tmpProperty = property;
            if (propertyDto == null) tmpProperty = null;
            else if (property == null || (property.Id != propertyDto.Id))
            {
                tmpProperty = new Property();
                tmpProperty.Id = propertyDto.Id;
            }
            return tmpProperty;
        }
        public static FirmMember copyFirmMemberId(FirmMember firmMember, FirmMemberDTO firmMemberDto)
        {
            FirmMember tmpFirmMember = firmMember;
            if (firmMemberDto == null) tmpFirmMember = null;
            else if (firmMember == null || (firmMember.Id != firmMemberDto.Id))
            {
                tmpFirmMember = new FirmMember();
                tmpFirmMember.Id = firmMemberDto.Id;
            }
            return tmpFirmMember;
        }
        public static EnquiryDetail copyEnquiryDetailId(EnquiryDetail enquiryDetail, EnquiryDetailDTO enquiryDetailDto)
        {
            EnquiryDetail tmpEnquiryDetail = enquiryDetail;
            if (enquiryDetailDto == null) tmpEnquiryDetail = null;
            else if (enquiryDetail == null || (enquiryDetail.Id != enquiryDetailDto.Id))
            {
                tmpEnquiryDetail = new EnquiryDetail();
                tmpEnquiryDetail.Id = enquiryDetailDto.Id;
            }
            return tmpEnquiryDetail;
        }
        public static Department copyDepartmentId(Department department, DepartmentDTO departmentDto)
        {
            Department tmpDepartment = department;
            if (departmentDto == null) tmpDepartment = null;
            else if (department == null || (department.Id != departmentDto.Id))
            {
                tmpDepartment = new Department();
                tmpDepartment.Id = departmentDto.Id;
            }
            return tmpDepartment;
        }
        public static FirmAccount copyFirmAccountId(FirmAccount firmAccount, FirmAccountDTO firmAccountDto)
        {
            FirmAccount tmpFirmAccount = firmAccount;
            if (firmAccountDto == null) tmpFirmAccount = null;
            else if (firmAccount == null || (firmAccount.Id != firmAccountDto.Id))
            {
                tmpFirmAccount = new FirmAccount();
                tmpFirmAccount.Id = firmAccountDto.Id;
            }
            return tmpFirmAccount;
        }
        //Department
        public static Department populateDepartmentAddFields(DepartmentDTO departmentDto)
        {
            Department department = new Department();
            department.Id = departmentDto.Id;
            department.FirmNumber = departmentDto.FirmNumber;
            department.InsertUser = departmentDto.InsertUser;
            populateDepartmentUpdateFields(department, departmentDto);
            return department;
        }
        public static void populateDepartmentUpdateFields(Department department, DepartmentDTO departmentDto)
        {
            department.Name = departmentDto.Name;
            department.Description = departmentDto.Description;
            department.UpdateDate = DateTime.Now;
            department.Version = departmentDto.Version;
            department.UpdateUser = departmentDto.UpdateUser;
        }
        //MasterControlData
        public static MasterControlData populateMasterDataAddFields(MasterControlDataDTO masterDataDto)
        {
            MasterControlData masterData = new MasterControlData();
            masterData.Id = masterDataDto.Id;
            masterData.Type = masterDataDto.Type;
            masterData.SystemDefined = masterDataDto.SystemDefined;
            masterData.FirmNumber = masterDataDto.FirmNumber;
            masterData.InsertUser = masterDataDto.InsertUser;
            populateMasterDataUpdateFields(masterData, masterDataDto);
            return masterData;
        }
        public static void populateMasterDataUpdateFields(MasterControlData masterData, MasterControlDataDTO masterDataDto)
        {
            masterData.Name = masterDataDto.Name;
            masterData.Description = masterDataDto.Description;
            masterData.UpdateDate = DateTime.Now;
            masterData.Version = masterDataDto.Version;
            masterData.UpdateUser = masterDataDto.UpdateUser;
        }
        //FirmAccount
        public static FirmAccount populateFirmAccountAddFields(FirmAccountDTO firmAccountDto)
        {
            FirmAccount firmAccount = new FirmAccount();
            firmAccount.Id = firmAccountDto.Id;
            firmAccount.FirmNumber = firmAccountDto.FirmNumber;
            firmAccount.InsertUser = firmAccountDto.InsertUser;
            firmAccount.Firm = DTOToDomainUtil.copyFirmId(firmAccount.Firm, firmAccountDto.Firm);
            populateFirmAccountUpdateFields(firmAccount, firmAccountDto);
            return firmAccount;
        }
        public static void populateFirmAccountUpdateFields(FirmAccount firmAccount, FirmAccountDTO firmAccountDto)
        {
            firmAccount.Name = firmAccountDto.Name;
            firmAccount.AccountNo = firmAccountDto.AccountNo;
            firmAccount.AccountType = DTOToDomainUtil.copyMasterControlId(firmAccount.AccountType, firmAccountDto.AccountType);
            firmAccount.AccountBalance = firmAccountDto.AccountBalance;
            firmAccount.IfscCode = firmAccountDto.IfscCode;
            firmAccount.BankName = firmAccountDto.BankName;
            firmAccount.Branch = firmAccountDto.Branch;
            firmAccount.City = DTOToDomainUtil.copyCityId(firmAccount.City, firmAccountDto.City);
            firmAccount.State = DTOToDomainUtil.copyStateId(firmAccount.State, firmAccountDto.State);
            firmAccount.Country = DTOToDomainUtil.copyCountryId(firmAccount.Country, firmAccountDto.Country);
            firmAccount.UpdateDate = DateTime.Now;
            firmAccount.Version = firmAccountDto.Version;
            firmAccount.UpdateUser = firmAccountDto.UpdateUser;
        }
        //Enquiry
        public static EnquiryDetail populateEnquiryDetailAddFields(EnquiryDetailDTO enquiryDto)
        {
            EnquiryDetail enquiryDetail = new EnquiryDetail();
            enquiryDetail.FirmNumber = enquiryDto.FirmNumber;
            enquiryDetail.InsertUser = enquiryDto.InsertUser;
            enquiryDetail.ContactInfo = new ContactInfo();
            populateEnquiryDetailUpdateFields(enquiryDetail, enquiryDto);
            return enquiryDetail;
        }
        public static void populateEnquiryDetailUpdateFields(EnquiryDetail enquiryDetail, EnquiryDetailDTO enquiryDto)
        {
            enquiryDetail.Salutation = DTOToDomainUtil.copyMasterControlId(enquiryDetail.Salutation, enquiryDto.Salutation);
            enquiryDetail.FirstName = enquiryDto.FirstName;
            enquiryDetail.MiddleName = enquiryDto.MiddleName;
            enquiryDetail.LastName = enquiryDto.LastName;
            DTOToDomainUtil.copyToContactInfo(enquiryDetail.ContactInfo, enquiryDto.ContactInfo);
            enquiryDetail.Occupation = DTOToDomainUtil.copyMasterControlId(enquiryDetail.Occupation, enquiryDto.Occupation);
            enquiryDetail.EnquiryDate = enquiryDto.EnquiryDate;
            enquiryDetail.PropertyType = DTOToDomainUtil.copyMasterControlId(enquiryDetail.PropertyType, enquiryDto.PropertyType);
            enquiryDetail.PropertyLocation = DTOToDomainUtil.copyMasterControlId(enquiryDetail.PropertyLocation, enquiryDto.PropertyLocation);
            enquiryDetail.Property = DTOToDomainUtil.copyPropertyId(enquiryDetail.Property, enquiryDto.Property);
            enquiryDetail.PrUnitType = DTOToDomainUtil.copyMasterControlId(enquiryDetail.PrUnitType, enquiryDto.PrUnitType);
            enquiryDetail.EnquirySource = DTOToDomainUtil.copyMasterControlId(enquiryDetail.EnquirySource, enquiryDto.EnquirySource);
            enquiryDetail.Budget = enquiryDto.Budget;
            enquiryDetail.FirmMember = DTOToDomainUtil.copyFirmMemberId(enquiryDetail.FirmMember, enquiryDto.FirmMember);
            enquiryDetail.Status = enquiryDto.Status;
            enquiryDetail.FollowupDate = enquiryDto.FollowupDate;
            enquiryDetail.Comments = enquiryDto.Comments;
            enquiryDetail.CloseReason = enquiryDto.CloseReason;
            enquiryDetail.UpdateDate = DateTime.Now;
            enquiryDetail.UpdateUser = enquiryDto.UpdateUser;
        }
        //Enquiry Follow up
        public static EnquiryFollowup populateEnquiryFollowupAddFields(EnquiryFollowupDTO enquiryFollowupDto)
        {
            EnquiryFollowup enquiryFollowup = new EnquiryFollowup();
            enquiryFollowup.Id = enquiryFollowupDto.Id;
            enquiryFollowup.FollowupDate = enquiryFollowupDto.FollowupDate;
            enquiryFollowup.FirmNumber = enquiryFollowupDto.FirmNumber;
            enquiryFollowup.InsertUser = enquiryFollowupDto.InsertUser;
            enquiryFollowup.EnquiryDetail = DTOToDomainUtil.copyEnquiryDetailId(enquiryFollowup.EnquiryDetail, enquiryFollowupDto.EnquiryDetail);
            enquiryFollowup.FirmMember = DTOToDomainUtil.copyFirmMemberId(enquiryFollowup.FirmMember, enquiryFollowupDto.FirmMember);
            populateEnquiryFollowupUpdateFields(enquiryFollowup, enquiryFollowupDto);
            return enquiryFollowup;
        }
        public static void populateEnquiryFollowupUpdateFields(EnquiryFollowup enquiryFollowup, EnquiryFollowupDTO enquiryFollowupDto)
        {
            enquiryFollowup.Comments = enquiryFollowupDto.Comments;
            enquiryFollowup.CommunicationMedia = DTOToDomainUtil.copyMasterControlId(enquiryFollowup.CommunicationMedia, enquiryFollowupDto.CommunicationMedia);
            enquiryFollowup.UpdateDate = DateTime.Now;
            enquiryFollowup.UpdateUser = enquiryFollowupDto.UpdateUser;
            enquiryFollowup.Version = enquiryFollowupDto.Version;
        }
        //Firm Member
        public static FirmMember populateFirmMemberAddFields(FirmMemberDTO firmMemberDto)
        {
            FirmMember firmMember = new FirmMember();
            firmMember.Id = firmMemberDto.Id;
            firmMember.EmployeeId = firmMemberDto.EmployeeId;
            firmMember.FirmNumber = firmMemberDto.FirmNumber;
            firmMember.InsertUser = firmMemberDto.InsertUser;
            firmMember.ContactInfo = new ContactInfo();
            populateFirmMemberUpdateFields(firmMember, firmMemberDto);
            return firmMember;
        }
        public static void populateFirmMemberUpdateFields(FirmMember firmMember, FirmMemberDTO firmMemberDto)
        {
            firmMember.EmployeeId = firmMemberDto.EmployeeId;
            firmMember.FirstName = firmMemberDto.FirstName;
            firmMember.MiddleName = firmMemberDto.MiddleName;
            firmMember.LastName = firmMemberDto.LastName;
            firmMember.JoiningDate = firmMemberDto.JoiningDate;
            firmMember.Qualification = firmMemberDto.Qualification;
            firmMember.Description = firmMemberDto.Description;
            DTOToDomainUtil.copyToContactInfo(firmMember.ContactInfo, firmMemberDto.ContactInfo);
            firmMember.Department = DTOToDomainUtil.copyDepartmentId(firmMember.Department, firmMemberDto.Department);
            firmMember.Salutation = DTOToDomainUtil.copyMasterControlId(firmMember.Salutation, firmMemberDto.Salutation);
            firmMember.Designation = DTOToDomainUtil.copyMasterControlId(firmMember.Designation, firmMemberDto.Designation);
            firmMember.UpdateDate = DateTime.Now;
            firmMember.Version = firmMemberDto.Version;
            firmMember.UpdateUser = firmMemberDto.UpdateUser;
        }
        //Firm Account Deposites
        public static FirmAcntDeposite populateFirmAcntDepositeAddFields(FirmAcntDepositeDTO firmAcntDepositeDto)
        {
            FirmAcntDeposite firmAcntDeposite = new FirmAcntDeposite();
            firmAcntDeposite.Id = firmAcntDepositeDto.Id;
            firmAcntDeposite.DepositeDate = firmAcntDepositeDto.DepositeDate;
            firmAcntDeposite.Amount = firmAcntDepositeDto.Amount;
            firmAcntDeposite.PymtMode = firmAcntDepositeDto.PymtMode;
            firmAcntDeposite.BankName = firmAcntDepositeDto.BankName;
            firmAcntDeposite.ChequeNo = firmAcntDepositeDto.ChequeNo;
            firmAcntDeposite.ChequeDate = firmAcntDepositeDto.ChequeDate;
            firmAcntDeposite.Status = firmAcntDepositeDto.Status;
            firmAcntDeposite.FirmNumber = firmAcntDepositeDto.FirmNumber;
            firmAcntDeposite.InsertDate = firmAcntDepositeDto.InsertDate;
            firmAcntDeposite.InsertUser = firmAcntDepositeDto.InsertUser;
            firmAcntDeposite.FirmAccount = DTOToDomainUtil.copyFirmAccountId(firmAcntDeposite.FirmAccount, firmAcntDepositeDto.FirmAccount);
            populateFirmAcntDepositeUpdateFields(firmAcntDeposite, firmAcntDepositeDto);
            return firmAcntDeposite;
        }
        public static void populateFirmAcntDepositeUpdateFields(FirmAcntDeposite firmAcntDeposite, FirmAcntDepositeDTO firmAcntDepositeDto)
        {
            firmAcntDeposite.Description = firmAcntDepositeDto.Description;
            firmAcntDeposite.UpdateDate = DateTime.Now;
            firmAcntDeposite.UpdateUser = firmAcntDepositeDto.UpdateUser;
            firmAcntDeposite.Version = firmAcntDepositeDto.Version;
        }
    }
}