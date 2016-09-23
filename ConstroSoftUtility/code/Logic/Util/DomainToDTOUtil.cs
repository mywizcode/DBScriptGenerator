
/// <summary>
/// Summary description for CommonUtil
/// </summary>
using ConstroSoft;
using System.Collections.Generic;
namespace ConstroSoft
{
    public class DomainToDTOUtil
    {
        public DomainToDTOUtil() { }
        public static ContactInfoDTO convertToContactInfoDTO(ContactInfo contactInfo)
        {
            ContactInfoDTO contactInfoDto = null;
            if (contactInfo != null)
            {
                contactInfoDto = new ContactInfoDTO();
                contactInfoDto.Id = contactInfo.Id;
                contactInfoDto.Contact = contactInfo.Contact;
                contactInfoDto.AltContact = contactInfo.AltContact;
                contactInfoDto.Gender = contactInfo.Gender;
                contactInfoDto.MaritalStatus = contactInfo.MaritalStatus;
                contactInfoDto.Dob = contactInfo.Dob;
                contactInfoDto.Email = contactInfo.Email;
                contactInfoDto.AltEmail = contactInfo.AltEmail;
            }
            return contactInfoDto;
        }
        public static FirmDTO convertToFirmDTO(Firm firm, bool allFields)
        {
            FirmDTO firmDto = null;
            if (firm != null)
            {
                firmDto = new FirmDTO();
                firmDto.Id = firm.Id;
                firmDto.Name = firm.Name;
                firmDto.FirmNumber = firm.FirmNumber;
                if (allFields)
                {
                    firmDto.RegistrationNo = firm.RegistrationNo;
                    firmDto.WebSite = firm.WebSite;
                    firmDto.Description = firm.Description;
                    firmDto.InsertDate = firm.InsertDate;
                    firmDto.UpdateDate = firm.UpdateDate;
                    firmDto.Version = firm.Version;
                    firmDto.InsertUser = firm.InsertUser;
                    firmDto.UpdateUser = firm.UpdateUser;
                    firmDto.ContactInfo = DomainToDTOUtil.convertToContactInfoDTO(firm.ContactInfo);
                }
            }
            return firmDto;
        }

        public static FirmAccountDTO convertToFirmAccountDTO(FirmAccount firmAccount, bool allFields)
        {
            FirmAccountDTO firmAccountDto = null;
            if (firmAccount != null)
            {
                firmAccountDto = new FirmAccountDTO();
                firmAccountDto.Id = firmAccount.Id;
                firmAccountDto.Name = firmAccount.Name;
                firmAccountDto.AccountNo = firmAccount.AccountNo;
                if (allFields)
                {
                    firmAccountDto.AccountType = DomainToDTOUtil.convertToMasterControlDTO(firmAccount.AccountType, false);
                    firmAccountDto.AccountBalance = firmAccount.AccountBalance;
                    firmAccountDto.IfscCode = firmAccount.IfscCode;
                    firmAccountDto.BankName = firmAccount.BankName;
                    firmAccountDto.Branch = firmAccount.Branch;
                    firmAccountDto.City = DomainToDTOUtil.convertToCityDTO(firmAccount.City, false);
                    firmAccountDto.State = DomainToDTOUtil.convertToStateDTO(firmAccount.State, false);
                    firmAccountDto.Country = DomainToDTOUtil.convertToCountryDTO(firmAccount.Country, false);
                    firmAccountDto.FirmNumber = firmAccount.FirmNumber;
                    firmAccountDto.UpdateDate = firmAccount.UpdateDate;
                    firmAccountDto.Version = firmAccount.Version;
                    firmAccountDto.InsertUser = firmAccount.InsertUser;
                    firmAccountDto.UpdateUser = firmAccount.UpdateUser;
                }
            }
            return firmAccountDto;
        }
        public static EnquiryDetailDTO convertToEnquiryDetailDTO(EnquiryDetail enquiryDetail)
        {
            EnquiryDetailDTO enquiryDto = null;
            if (enquiryDetail != null)
            {
                enquiryDto = new EnquiryDetailDTO();
                enquiryDto.Id = enquiryDetail.Id;
                enquiryDto.Salutation = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.Salutation, false);
                enquiryDto.FirstName = enquiryDetail.FirstName;
                enquiryDto.MiddleName = enquiryDetail.MiddleName;
                enquiryDto.LastName = enquiryDetail.LastName;
                enquiryDto.ContactInfo = DomainToDTOUtil.convertToContactInfoDTO(enquiryDetail.ContactInfo);
                enquiryDto.Occupation = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.Occupation, false);
                enquiryDto.EnquiryDate = enquiryDetail.EnquiryDate;
                enquiryDto.PropertyType = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.PropertyType, false);
                enquiryDto.PropertyLocation = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.PropertyLocation, false);
                enquiryDto.Property = DomainToDTOUtil.convertToPropertyDTO(enquiryDetail.Property, false);
                enquiryDto.PrUnitType = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.PrUnitType, false);
                enquiryDto.EnquirySource = DomainToDTOUtil.convertToMasterControlDTO(enquiryDetail.EnquirySource, false);
                enquiryDto.Budget = enquiryDetail.Budget;
                enquiryDto.FirmMember = DomainToDTOUtil.convertToFirmMemberDTO(enquiryDetail.FirmMember, false);
                enquiryDto.FirmNumber = enquiryDetail.FirmNumber;
                enquiryDto.Status = enquiryDetail.Status;
                enquiryDto.FollowupDate = enquiryDetail.FollowupDate;
                enquiryDto.Comments = enquiryDetail.Comments;
                enquiryDto.CloseReason = enquiryDetail.CloseReason;
                enquiryDto.InsertUser = enquiryDetail.InsertUser;
                enquiryDto.UpdateUser = enquiryDetail.UpdateUser;
                enquiryDto.InsertDate = enquiryDetail.InsertDate;
                enquiryDto.UpdateDate = enquiryDetail.UpdateDate;
                enquiryDto.Version = enquiryDetail.Version;
            }
            return enquiryDto;
        }
        public static EnquiryFollowupDTO convertToEnquiryFollowupDTO(EnquiryFollowup enquiryFollowup, bool allFields)
        {
            EnquiryFollowupDTO enquiryFollowupDto = null;
            if (enquiryFollowup != null)
            {
                enquiryFollowupDto = new EnquiryFollowupDTO();
                enquiryFollowupDto.Id = enquiryFollowup.Id;
                if (allFields)
                {
                    enquiryFollowupDto.FollowupDate = enquiryFollowup.FollowupDate;
                    enquiryFollowupDto.Comments = enquiryFollowup.Comments;
                    enquiryFollowupDto.FirmNumber = enquiryFollowup.FirmNumber;
                    enquiryFollowupDto.CommunicationMedia = DomainToDTOUtil.convertToMasterControlDTO(enquiryFollowup.CommunicationMedia, false);
                    enquiryFollowupDto.FirmMember = DomainToDTOUtil.convertToFirmMemberDTO(enquiryFollowup.FirmMember, false);
                    enquiryFollowupDto.InsertDate = enquiryFollowup.InsertDate;
                    enquiryFollowupDto.UpdateDate = enquiryFollowup.UpdateDate;
                    enquiryFollowupDto.Version = enquiryFollowup.Version;
                    enquiryFollowupDto.InsertUser = enquiryFollowup.InsertUser;
                    enquiryFollowupDto.UpdateUser = enquiryFollowup.UpdateUser;
                }
            }
            return enquiryFollowupDto;
        }
        public static DepartmentDTO convertToDepartmentDTO(Department department, bool allFields)
        {
            DepartmentDTO departmentDto = null;
            if (department != null)
            {
                departmentDto = new DepartmentDTO();
                departmentDto.Id = department.Id;
                departmentDto.Name = department.Name;
                if (allFields)
                {
                    departmentDto.Description = department.Description;
                    departmentDto.FirmNumber = department.FirmNumber;
                    departmentDto.InsertDate = department.InsertDate;
                    departmentDto.UpdateDate = department.UpdateDate;
                    departmentDto.Version = department.Version;
                    departmentDto.InsertUser = department.InsertUser;
                    departmentDto.UpdateUser = department.UpdateUser;
                }
            }
            return departmentDto;
        }
        public static PropertyDTO convertToPropertyDTO(Property property, bool allFields)
        {
            PropertyDTO propertyDto = null;
            if (property != null)
            {
                propertyDto = new PropertyDTO();
                propertyDto.Id = property.Id;
                propertyDto.Name = property.Name;
                if (allFields)
                {
                }
            }
            return propertyDto;
        }
        public static FirmMemberDTO convertToFirmMemberDTO(FirmMember firmMember, bool allFields)
        {
            FirmMemberDTO firmMemberDto = null;
            if (firmMember != null)
            {
                firmMemberDto = new FirmMemberDTO();
                firmMemberDto.EmployeeId = firmMember.EmployeeId;
                firmMemberDto.Id = firmMember.Id;
                firmMemberDto.Salutation = DomainToDTOUtil.convertToMasterControlDTO(firmMember.Salutation, false);
                firmMemberDto.FirstName = firmMember.FirstName;
                firmMemberDto.MiddleName = firmMember.MiddleName;
                firmMemberDto.LastName = firmMember.LastName;
                if (allFields)
                {
                    firmMemberDto.JoiningDate = firmMember.JoiningDate;
                    firmMemberDto.Qualification = firmMember.Qualification;
                    firmMemberDto.Description = firmMember.Description;
                    firmMemberDto.FirmNumber = firmMember.FirmNumber;
                    firmMemberDto.ContactInfo = DomainToDTOUtil.convertToContactInfoDTO(firmMember.ContactInfo);
                    firmMemberDto.Department = DomainToDTOUtil.convertToDepartmentDTO(firmMember.Department, false);
                    firmMemberDto.Designation = DomainToDTOUtil.convertToMasterControlDTO(firmMember.Designation, false);
                    firmMemberDto.InsertDate = firmMember.InsertDate;
                    firmMemberDto.UpdateDate = firmMember.UpdateDate;
                    firmMemberDto.Version = firmMember.Version;
                    firmMemberDto.InsertUser = firmMember.InsertUser;
                    firmMemberDto.UpdateUser = firmMember.UpdateUser;
                }
            }
            return firmMemberDto;
        }
        public static FirmAcntDepositeDTO convertToFirmAcntDepositeDTO(FirmAcntDeposite firmAcntDeposite, bool allFields)
        {
            FirmAcntDepositeDTO firmAcntDepositeDto = null;
            if (firmAcntDeposite != null)
            {
                firmAcntDepositeDto = new FirmAcntDepositeDTO();
                firmAcntDepositeDto.Id = firmAcntDeposite.Id;
                if (allFields)
                {
                    firmAcntDepositeDto.DepositeDate = firmAcntDeposite.DepositeDate;
                    firmAcntDepositeDto.Amount = firmAcntDeposite.Amount;
                    firmAcntDepositeDto.PymtMode = firmAcntDeposite.PymtMode;
                    firmAcntDepositeDto.BankName = firmAcntDeposite.BankName;
                    firmAcntDepositeDto.ChequeNo = firmAcntDeposite.ChequeNo;
                    firmAcntDepositeDto.ChequeDate = firmAcntDeposite.ChequeDate;
                    firmAcntDepositeDto.Description = firmAcntDeposite.Description;
                    firmAcntDepositeDto.Status = firmAcntDeposite.Status;
                    firmAcntDepositeDto.FirmNumber = firmAcntDeposite.FirmNumber;
                    firmAcntDepositeDto.InsertDate = firmAcntDeposite.InsertDate;
                    firmAcntDepositeDto.UpdateDate = firmAcntDeposite.UpdateDate;
                    firmAcntDepositeDto.Version = firmAcntDeposite.Version;
                    firmAcntDepositeDto.InsertUser = firmAcntDeposite.InsertUser;
                    firmAcntDepositeDto.UpdateUser = firmAcntDeposite.UpdateUser;
                    firmAcntDepositeDto.FirmAccount = DomainToDTOUtil.convertToFirmAccountDTO(firmAcntDeposite.FirmAccount, false);
                }
            }
            return firmAcntDepositeDto;
        }
        public static MasterControlDataDTO convertToMasterControlDTO(MasterControlData masterControlData, bool allFields)
        {
            //Populate only basic fields, if allFields is true then only copy all fields.
            MasterControlDataDTO masterControlDataDto = null;
            if (masterControlData != null)
            {
                masterControlDataDto = new MasterControlDataDTO();
                masterControlDataDto.Id = masterControlData.Id;
                masterControlDataDto.Name = masterControlData.Name;
                if (allFields)
                {
                    masterControlDataDto.Type = masterControlData.Type;
                    masterControlDataDto.Description = masterControlData.Description;
                    masterControlDataDto.SystemDefined = masterControlData.SystemDefined;
                    masterControlDataDto.UpdateDate = masterControlData.UpdateDate;
                    masterControlDataDto.Version = masterControlData.Version;
                    masterControlDataDto.InsertUser = masterControlData.InsertUser;
                    masterControlDataDto.UpdateUser = masterControlData.UpdateUser;
                }
            }
            return masterControlDataDto;
        }
        public static CountryDTO convertToCountryDTO(Country country, bool allFields)
        {
            //Populate only basic fields, if allFields is true then only copy all fields.
            CountryDTO countryDto = null;
            if (country != null)
            {
                countryDto = new CountryDTO();
                countryDto.Id = country.Id;
                countryDto.Name = country.Name;
                countryDto.Abbreviation = country.Abbreviation;
            }
            return countryDto;
        }
        public static StateDTO convertToStateDTO(State state, bool allFields)
        {
            //Populate only basic fields, if allFields is true then only copy all fields.
            StateDTO stateDto = null;
            if (state != null)
            {
                stateDto = new StateDTO();
                stateDto.Id = state.Id;
                stateDto.Name = state.Name;
                stateDto.Abbreviation = state.Abbreviation;
            }
            return stateDto;
        }
        public static CityDTO convertToCityDTO(City city, bool allFields)
        {
            //Populate only basic fields, if allFields is true then only copy all fields.
            CityDTO cityDto = null;
            if (city != null)
            {
                cityDto = new CityDTO();
                cityDto.Id = city.Id;
                cityDto.Name = city.Name;
                cityDto.Abbreviation = city.Abbreviation;
            }
            return cityDto;
        }
    }
}