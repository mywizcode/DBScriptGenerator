using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstroSoft;

/// <summary>
/// Summary description for UserDefinitionDTO
/// </summary>
namespace ConstroSoft
{
    [Serializable]
    public class AccountTransactionDTO
    {
        public AccountTransactionDTO() { }
        public long Id { get; set; }
        public System.DateTime TxDate { get; set; }
        public decimal Amount { get; set; }
        public string TxType { get; set; }
        public string Comments { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public FirmAccountDTO FirmAccount { get; set; }
        public PaymentTransactionDTO PaymentTransaction { get; set; }
    }
    [Serializable]
    public class AddressDTO
    {
        public AddressDTO() { }
        public long Id { get; set; }
        public string PreferredAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string Pin { get; set; }
        public MasterControlDataDTO AddressType { get; set; }
        public CityDTO City { get; set; }
        public StateDTO State { get; set; }
        public CountryDTO Country { get; set; }
        public ISet<EntityAddressDTO> EntityAddresses { get; set; }
    }
    [Serializable]
    public class BulkDemandLetterDTO
    {
        public BulkDemandLetterDTO() { }
        public long Id { get; set; }
        public byte[] DemandLetter { get; set; }
        public string ErrorMessage { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public RequestDTO Request { get; set; }
        public PrUnitSaleDetailDTO PrUnitSaleDetail { get; set; }
    }
    [Serializable]
    public class CityDTO
    {
        public CityDTO() { }
        public long Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public ISet<AddressDTO> Addresses { get; set; }
        public StateDTO State { get; set; }
        public ISet<FirmAccountDTO> FirmAccounts { get; set; }
    }
    [Serializable]
    public class CoCustomerDTO
    {
        public CoCustomerDTO() { }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Pan { get; set; }
        public string IsPoa { get; set; }
        public string FirmNumber { get; set; }
        public CustomerDTO Customer { get; set; }
        public MasterControlDataDTO SalutationId { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public MasterControlDataDTO RelationWhPrimCust { get; set; }
        public MasterControlDataDTO Occupation { get; set; }
    }
    [Serializable]
    public class ContactInfoDTO
    {
        public ContactInfoDTO() { }
        public long Id { get; set; }
        public string Contact { get; set; }
        public string AltContact { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public System.Nullable<System.DateTime> Dob { get; set; }
    }
    [Serializable]
    public class ContractorDTO
    {
        public ContractorDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public MasterControlDataDTO MasterControlData { get; set; }
        public ISet<ContractorPaymentDTO> ContractorPayments { get; set; }
    }
    [Serializable]
    public class ContractorPaymentDTO
    {
        public ContractorPaymentDTO() { }
        public long Id { get; set; }
        public System.Nullable<System.DateTime> FromDate { get; set; }
        public System.Nullable<System.DateTime> ToDate { get; set; }
        public System.Nullable<decimal> Tds { get; set; }
        public System.Nullable<decimal> OtherDeduction { get; set; }
        public System.Nullable<decimal> Tax { get; set; }
        public string Description { get; set; }
        public System.Nullable<decimal> PaymentAmt { get; set; }
        public System.Nullable<decimal> TotalAmt { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContractorDTO Contractor { get; set; }
        public PropertyDTO Property { get; set; }
        public FirmAccountDTO FirmAccount { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
    }
    [Serializable]
    public class CountryDTO
    {
        public CountryDTO() { }
        public long Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public ISet<AddressDTO> Addresses { get; set; }
        public ISet<FirmAccountDTO> FirmAccounts { get; set; }
        public ISet<StateDTO> States { get; set; }
    }
    [Serializable]
    public class CustomerDTO
    {
        public CustomerDTO() { }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Pan { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<CoCustomerDTO> CoCustomers { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public MasterControlDataDTO Salutation { get; set; }
        public MasterControlDataDTO Occupation { get; set; }
        public ISet<PrUnitSaleDetailDTO> PrUnitSaleDetails { get; set; }
    }
    [Serializable]
    public class DepartmentDTO
    {
        public DepartmentDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public FirmDTO Firm { get; set; }
        public ISet<FirmMemberDTO> FirmMembers { get; set; }
    }
    [Serializable]
    public class DocumentDTO
    {
        public DocumentDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceType { get; set; }
        public System.Nullable<long> ParentId { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO DocumentType { get; set; }
    }
    [Serializable]
    public class EnquiryDetailDTO
    {
        public EnquiryDetailDTO() { }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.Nullable<System.DateTime> EnquiryDate { get; set; }
        public System.Nullable<decimal> Budget { get; set; }
        public string Status { get; set; }
        public System.Nullable<System.DateTime> FollowupDate { get; set; }
        public string Comments { get; set; }
        public string CloseReason { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public MasterControlDataDTO Occupation { get; set; }
        public MasterControlDataDTO PropertyType { get; set; }
        public MasterControlDataDTO PropertyLocation { get; set; }
        public PropertyDTO Property { get; set; }
        public MasterControlDataDTO PrUnitType { get; set; }
        public MasterControlDataDTO EnquirySource { get; set; }
        public MasterControlDataDTO Salutation { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
        public ISet<EnquiryFollowupDTO> EnquiryFollowups { get; set; }
    }
    [Serializable]
    public class EnquiryFollowupDTO
    {
        public EnquiryFollowupDTO() { }
        public long Id { get; set; }
        public System.Nullable<System.DateTime> FollowupDate { get; set; }
        public string Comments { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public EnquiryDetailDTO EnquiryDetail { get; set; }
        public MasterControlDataDTO CommunicationMedia { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
    }
    [Serializable]
    public class EntityAddressDTO
    {
        public EntityAddressDTO() { }
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string ParentType { get; set; }
        public AddressDTO Address { get; set; }
    }
    [Serializable]
    public class EventlogDTO
    {
        public EventlogDTO() { }
        public long Id { get; set; }
        public string Title { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
    }
    [Serializable]
    public class FirmDTO
    {
        public FirmDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirmNumber { get; set; }
        public string RegistrationNo { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public ISet<DepartmentDTO> Departments { get; set; }
        public ISet<FirmAccountDTO> FirmAccounts { get; set; }
    }
    [Serializable]
    public class FirmAccountDTO
    {
        public FirmAccountDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public decimal AccountBalance { get; set; }
        public string IfscCode { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<AccountTransactionDTO> AccountTransactions { get; set; }
        public CityDTO City { get; set; }
        public ISet<ContractorPaymentDTO> ContractorPayments { get; set; }
        public CountryDTO Country { get; set; }
        public FirmDTO Firm { get; set; }
        public MasterControlDataDTO AccountType { get; set; }
        public StateDTO State { get; set; }
        public ISet<FirmAcntDepositeDTO> FirmAcntDeposites { get; set; }
        public ISet<PropertyDTO> Properties { get; set; }
        public ISet<PurchaseMasterDTO> PurchaseMasters { get; set; }
    }
    [Serializable]
    public class FirmAcntDepositeDTO
    {
        public FirmAcntDepositeDTO() { }
        public long Id { get; set; }
        public System.DateTime DepositeDate { get; set; }
        public System.Nullable<decimal> Amount { get; set; }
        public string PymtMode { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public System.Nullable<System.DateTime> ChequeDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public FirmAccountDTO FirmAccount { get; set; }
    }
    [Serializable]
    public class FirmMemberDTO
    {
        public FirmMemberDTO() { }
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.Nullable<System.DateTime> JoiningDate { get; set; }
        public string Qualification { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public ISet<ContractorPaymentDTO> ContractorPayments { get; set; }
        public DepartmentDTO Department { get; set; }
        public ISet<EnquiryDetailDTO> EnquiryDetails { get; set; }
        public ISet<EnquiryFollowupDTO> EnquiryFollowups { get; set; }
        public MasterControlDataDTO Salutation { get; set; }
        public MasterControlDataDTO Designation { get; set; }
        public ISet<PrUnitSaleDetailDTO> PrUnitSaleDetails { get; set; }
        public ISet<PropertyExpenseDTO> PropertyExpenses { get; set; }
        public ISet<PurchaseMasterDTO> PurchaseMasters { get; set; }
    }
    [Serializable]
    public class MasterControlDataDTO
    {
        public MasterControlDataDTO() { }
        public long Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SystemDefined { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
    }
    [Serializable]
    public class PaymentMasterDTO
    {
        public PaymentMasterDTO() { }
        public long Id { get; set; }
        public string PymtSource { get; set; }
        public System.Nullable<decimal> TotalAmt { get; set; }
        public System.Nullable<decimal> TotalPaid { get; set; }
        public System.Nullable<decimal> TotalPending { get; set; }
        public System.Nullable<decimal> TotalPdcAmt { get; set; }
        public string Status { get; set; }
        public System.Nullable<long> OrgPymtId { get; set; }
        public string PymtFlow { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<PaymentTransactionDTO> PaymentTransactions { get; set; }
        public ISet<PrPostDatedChequeDTO> PrPostDatedCheques { get; set; }
    }
    [Serializable]
    public class PaymentTransactionDTO
    {
        public PaymentTransactionDTO() { }
        public long Id { get; set; }
        public System.DateTime TxDate { get; set; }
        public System.Nullable<decimal> Balance { get; set; }
        public decimal Paid { get; set; }
        public System.Nullable<decimal> Pending { get; set; }
        public string Status { get; set; }
        public string PymtMode { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public System.Nullable<System.DateTime> PymtModeTxDate { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<AccountTransactionDTO> AccountTransactions { get; set; }
        public PaymentMasterDTO PaymentMaster { get; set; }
        public PaymentTransactionDTO CancelledPaymentTransaction { get; set; }
    }
    [Serializable]
    public class PropertyDTO
    {
        public PropertyDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public System.Nullable<decimal> PropertyArea { get; set; }
        public string Description { get; set; }
        public System.Nullable<decimal> EstimatedAmt { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public FirmAccountDTO FirmAccount { get; set; }
        public MasterControlDataDTO TypeId { get; set; }
        public MasterControlDataDTO LocationId { get; set; }
        public ISet<PropertyAmenityDTO> PropertyAmenities { get; set; }
        public ISet<PropertyChargeDTO> PropertyCharges { get; set; }
        public ISet<PropertyExpenseDTO> PropertyExpenses { get; set; }
        public ISet<PropertyTaxDetailDTO> PropertyTaxDetails { get; set; }
        public ISet<PropertyTowerDTO> PropertyTowers { get; set; }
    }
    [Serializable]
    public class PropertyAmenityDTO
    {
        public PropertyAmenityDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public PropertyDTO Property { get; set; }
    }
    [Serializable]
    public class PropertyChargeDTO
    {
        public PropertyChargeDTO() { }
        public long Id { get; set; }
        public System.Nullable<decimal> ChargeValue { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO ChargeType { get; set; }
        public PropertyDTO Property { get; set; }
    }
    [Serializable]
    public class PropertyExpenseDTO
    {
        public PropertyExpenseDTO() { }
        public long Id { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public System.Nullable<decimal> Amount { get; set; }
        public string Comments { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
        public MasterControlDataDTO ExpenseType { get; set; }
        public PropertyDTO Property { get; set; }
    }
    [Serializable]
    public class PropertyParkingDTO
    {
        public PropertyParkingDTO() { }
        public long Id { get; set; }
        public string ParkingNo { get; set; }
        public System.Nullable<decimal> Area { get; set; }
        public string CommonParking { get; set; }
        public string Status { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO MasterControlData { get; set; }
        public PropertyTowerDTO PropertyTower { get; set; }
        public ISet<PropertyUnitDTO> PropertyUnits { get; set; }
    }
    [Serializable]
    public class PropertyScheduleDTO
    {
        public PropertyScheduleDTO() { }
        public long Id { get; set; }
        public string Stage { get; set; }
        public System.Nullable<decimal> Percentage { get; set; }
        public string Status { get; set; }
        public System.Nullable<int> StageNumber { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public PropertyTowerDTO PropertyTower { get; set; }
    }
    [Serializable]
    public class PropertyTaxDetailDTO
    {
        public PropertyTaxDetailDTO() { }
        public long Id { get; set; }
        public System.Nullable<decimal> TaxPercentage { get; set; }
        public string IncludeInTotalPymt { get; set; }
        public System.Nullable<decimal> TaxAmtLimit { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO TaxType { get; set; }
        public PropertyDTO Property { get; set; }
    }
    [Serializable]
    public class PropertyTowerDTO
    {
        public PropertyTowerDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public System.Nullable<decimal> Rate { get; set; }
        public System.Nullable<System.DateTime> LaunchDate { get; set; }
        public System.Nullable<System.DateTime> PossessionDate { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public PropertyDTO Property { get; set; }
        public ISet<PropertyScheduleDTO> PropertySchedules { get; set; }
        public ISet<PropertyUnitDTO> PropertyUnits { get; set; }
    }
    [Serializable]
    public class PropertyUnitDTO
    {
        public PropertyUnitDTO() { }
        public long Id { get; set; }
        public string Wing { get; set; }
        public System.Nullable<decimal> FloorNo { get; set; }
        public string UnitNo { get; set; }
        public decimal BuildupArea { get; set; }
        public System.Nullable<decimal> CarpetArea { get; set; }
        public System.Nullable<decimal> BalconyArea { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO UnitTypeId { get; set; }
        public MasterControlDataDTO Facing { get; set; }
        public MasterControlDataDTO Direction { get; set; }
        public ISet<PrUnitSaleDetailDTO> PrUnitSaleDetails { get; set; }
        public ISet<PropertyParkingDTO> PropertyParkings { get; set; }
        public PropertyTowerDTO PropertyTower { get; set; }
    }
    [Serializable]
    public class PrPostDatedChequeDTO
    {
        public PrPostDatedChequeDTO() { }
        public long Id { get; set; }
        public System.DateTime TxDate { get; set; }
        public System.Nullable<System.DateTime> ChequeDate { get; set; }
        public decimal PymtAmt { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public PaymentMasterDTO PaymentMaster { get; set; }
    }
    [Serializable]
    public class PrUnitSaleDetailDTO
    {
        public PrUnitSaleDetailDTO() { }
        public long Id { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.Nullable<decimal> SaleRate { get; set; }
        public System.Nullable<System.DateTime> PossessionDate { get; set; }
        public string IsPossessionDone { get; set; }
        public System.Nullable<System.DateTime> AgreementDate { get; set; }
        public string IsAgreementDone { get; set; }
        public string LoanBankName { get; set; }
        public string LoanBankBranch { get; set; }
        public System.Nullable<decimal> LoanAmt { get; set; }
        public System.Nullable<decimal> DiscountAdjAmt { get; set; }
        public decimal AgreementAmt { get; set; }
        public System.Nullable<decimal> TotalTaxAmt { get; set; }
        public System.Nullable<decimal> TotalOtherAmt { get; set; }
        public decimal TotalPymtAmt { get; set; }
        public System.Nullable<decimal> TotalCashAmt { get; set; }
        public decimal TotalPackageCost { get; set; }
        public System.Nullable<decimal> CancellationFee { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<BulkDemandLetterDTO> BulkDemandLetters { get; set; }
        public CustomerDTO Customer { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
        public PropertyUnitDTO PropertyUnit { get; set; }
        public ISet<PrUnitSalePymtDTO> PrUnitSalePymts { get; set; }
        public ISet<PrUnitSaleTaxDetailDTO> PrUnitSaleTaxDetails { get; set; }
    }
    [Serializable]
    public class PrUnitSalePymtDTO
    {
        public PrUnitSalePymtDTO() { }
        public long Id { get; set; }
        public System.DateTime PymtDate { get; set; }
        public System.Nullable<decimal> PymtAmt { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO PymtType { get; set; }
        public PrUnitSaleDetailDTO PrUnitSaleDetail { get; set; }
    }
    [Serializable]
    public class PrUnitSaleTaxDetailDTO
    {
        public PrUnitSaleTaxDetailDTO() { }
        public long Id { get; set; }
        public System.Nullable<decimal> TaxPercentage { get; set; }
        public System.Nullable<decimal> TaxAmtLimit { get; set; }
        public System.Nullable<decimal> TaxAmt { get; set; }
        public string IncludeInTotalPymt { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO TaxType { get; set; }
        public PrUnitSaleDetailDTO PrUnitSaleDetail { get; set; }
    }
    [Serializable]
    public class PurchaseDetailDTO
    {
        public PurchaseDetailDTO() { }
        public long Id { get; set; }
        public System.Nullable<decimal> Quantity { get; set; }
        public System.Nullable<decimal> Rate { get; set; }
        public System.Nullable<decimal> Amount { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO Quality { get; set; }
        public PurchaseMasterDTO PurchaseMaster { get; set; }
        public StockItemDTO StockItem { get; set; }
    }
    [Serializable]
    public class PurchaseMasterDTO
    {
        public PurchaseMasterDTO() { }
        public long Id { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string InvoiceNo { get; set; }
        public System.Nullable<decimal> PymtAmt { get; set; }
        public System.Nullable<decimal> Tax { get; set; }
        public System.Nullable<decimal> Discount { get; set; }
        public System.Nullable<decimal> TotalAmt { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public FirmAccountDTO FirmAccount { get; set; }
        public FirmMemberDTO FirmMember { get; set; }
        public PropertyDTO Property { get; set; }
        public ISet<PurchaseDetailDTO> PurchaseDetails { get; set; }
        public SupplierDTO Supplier { get; set; }
    }
    [Serializable]
    public class RequestDTO
    {
        public RequestDTO() { }
        public long Id { get; set; }
        public string ReqIdentifier { get; set; }
        public string RequestType { get; set; }
        public System.DateTime GeneratedDate { get; set; }
        public string Name { get; set; }
        public string GeneratedBy { get; set; }
        public System.Nullable<System.DateTime> StartTime { get; set; }
        public System.Nullable<System.DateTime> EndTime { get; set; }
        public string Status { get; set; }
        public string SuccessMessage { get; set; }
        public string FailureMessage { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ISet<BulkDemandLetterDTO> BulkDemandLetters { get; set; }
    }
    [Serializable]
    public class StateDTO
    {
        public StateDTO() { }
        public long Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public ISet<AddressDTO> Addresses { get; set; }
        public ISet<CityDTO> Cities { get; set; }
        public CountryDTO Country { get; set; }
        public ISet<FirmAccountDTO> FirmAccounts { get; set; }
    }
    [Serializable]
    public class StockDetailDTO
    {
        public StockDetailDTO() { }
        public long Id { get; set; }
        public System.Nullable<System.DateTime> Date { get; set; }
        public System.Nullable<decimal> Quantity { get; set; }
        public string InvoiceNo { get; set; }
        public string Status { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public StockMasterDTO StockMaster { get; set; }
    }
    [Serializable]
    public class StockItemDTO
    {
        public StockItemDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
    }
    [Serializable]
    public class StockMasterDTO
    {
        public StockMasterDTO() { }
        public long Id { get; set; }
        public System.Nullable<decimal> TotalQuantity { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO Quality { get; set; }
        public PropertyDTO Property { get; set; }
        public ISet<StockDetailDTO> StockDetails { get; set; }
        public StockItemDTO StockItem { get; set; }
    }
    [Serializable]
    public class SupplierDTO
    {
        public SupplierDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public MasterControlDataDTO TypeId { get; set; }
        public ISet<PurchaseMasterDTO> PurchaseMasters { get; set; }
    }
    [Serializable]
    public class UserDefinitionDTO
    {
        public UserDefinitionDTO() { }
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecurityAnswer { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public System.Nullable<System.DateTime> ActivationDate { get; set; }
        public System.Nullable<System.DateTime> ExpirationDate { get; set; }
        public UserStatus Status { get; set; }
        public byte[] ProfileImg { get; set; }
        public string FirmNumber { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long Version { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public MasterControlDataDTO SecurityQuestion { get; set; }
        public UserRoleDTO UserRole { get; set; }
    }
    [Serializable]
    public class UserEntitlementDTO
    {
        public UserEntitlementDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public UserEntitlementDTO parent { get; set; }
        public ISet<UserRoleDTO> UserRoles { get; set; }
    }
    [Serializable]
    public class UserRoleDTO
    {
        public UserRoleDTO() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ISet<UserDefinitionDTO> UserDefinitions { get; set; }
        public ISet<UserEntitlementDTO> UserEntitlements { get; set; }
        public IList<string> entitlements { get; set; }
    }
}