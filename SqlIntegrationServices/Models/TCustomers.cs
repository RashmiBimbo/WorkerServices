using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CustomerAccount", "dataAreaId")]
public abstract partial class TCustomersBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CustomerAccount { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountStatement { get; set; }

    [StringLength(2000)]
    public string? AddressBooks { get; set; }

    [StringLength(2000)]
    public string? AddressBrazilianCNPJOrCPF { get; set; }

    [StringLength(2000)]
    public string? AddressBrazilianIE { get; set; }

    [StringLength(2000)]
    public string? AddressBuildingComplement { get; set; }

    [StringLength(2000)]
    public string? AddressCity { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? AddressCounty { get; set; }

    [StringLength(2000)]
    public string? AddressDescription { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AddressLatitude { get; set; }

    [StringLength(2000)]
    public string? AddressLocationId { get; set; }

    [StringLength(2000)]
    public string? AddressLocationRoles { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AddressLongitude { get; set; }

    [StringLength(2000)]
    public string? AddressPostbox { get; set; }

    public long? AddressRecordId { get; set; }

    [StringLength(2000)]
    public string? AddressState { get; set; }

    [StringLength(2000)]
    public string? AddressStreet { get; set; }

    [StringLength(2000)]
    public string? AddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? AddressTimeZone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AddressValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AddressValidTo { get; set; }

    [StringLength(2000)]
    public string? AddressZipCode { get; set; }

    [StringLength(2000)]
    public string? AuthorityOffice { get; set; }

    [StringLength(2000)]
    public string? BirthCountyCode { get; set; }

    [StringLength(2000)]
    public string? BirthPlace { get; set; }

    [StringLength(2000)]
    public string? BrazilianCCM { get; set; }

    [StringLength(2000)]
    public string? BrazilianCNAE { get; set; }

    [StringLength(2000)]
    public string? BrazilianCNPJOrCPF { get; set; }

    [StringLength(2000)]
    public string? BrazilianIE { get; set; }

    [StringLength(2000)]
    public string? BrazilianINSSCEI { get; set; }

    [StringLength(2000)]
    public string? BrazilianNIT { get; set; }

    [StringLength(2000)]
    public string? CalculateWithholdingTax { get; set; }

    [StringLength(2000)]
    public string? CentralBankPurposeCode { get; set; }

    [StringLength(2000)]
    public string? CentralBankPurposeNotes { get; set; }

    [StringLength(2000)]
    public string? ChargesGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClosedDate { get; set; }

    [StringLength(2000)]
    public string? CollectionLetterCode { get; set; }

    [StringLength(2000)]
    public string? CollectionsContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CommissionCustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? CommissionSalesGroupId { get; set; }

    [StringLength(2000)]
    public string? CompanyChain { get; set; }

    [StringLength(2000)]
    public string? CompanyType { get; set; }

    public int? ConsolidationDay { get; set; }

    [StringLength(2000)]
    public string? ContactNumber { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CreditCardAddressVerification { get; set; }

    [StringLength(2000)]
    public string? CreditCardAddressVerificationIsAuthorizationVoidedOnFailure { get; set; }

    [StringLength(2000)]
    public string? CreditCardAddressVerificationLevel { get; set; }

    [StringLength(2000)]
    public string? CreditCardCVC { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CreditLimit { get; set; }

    [StringLength(2000)]
    public string? CreditLimitIsMandatory { get; set; }

    [StringLength(2000)]
    public string? CreditRating { get; set; }

    [StringLength(2000)]
    public string? CredManAccountStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManBusinessStarted { get; set; }

    [StringLength(2000)]
    public string? CredManCollectionGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManCreditLimitDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManCreditLimitExpiryDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CredManCustCreditMaxAlt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManCustomerSince { get; set; }

    [StringLength(2000)]
    public string? CredManCustUnlimitedCredit { get; set; }

    [StringLength(2000)]
    public string? CredManEligibleCreditLimitCurrency { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManEligibleCreditLimitDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CredManEligibleCreditMax { get; set; }

    [StringLength(2000)]
    public string? CredManExclude { get; set; }

    [StringLength(2000)]
    public string? CredManGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManLastReviewDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CredManNextSchedReviewDate { get; set; }

    [StringLength(2000)]
    public string? CredManNotes { get; set; }

    [StringLength(2000)]
    public string? CredManStatusReasonId { get; set; }

    [StringLength(2000)]
    public string? CredManTitleHeld { get; set; }

    [StringLength(2000)]
    public string? CredManWithAgency { get; set; }

    [StringLength(2000)]
    public string? CURPNumber { get; set; }

    [StringLength(2000)]
    public string? CustCashFlowId { get; set; }

    [StringLength(2000)]
    public string? CustCat { get; set; }

    [StringLength(255)]
    public string? CustClassificationId { get; set; }

    public long? CustOffsetAccount { get; set; }

    [StringLength(2000)]
    public string? CustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? CustomerMonitorFlag { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentFinancialInterestCode { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentFineCode { get; set; }

    [StringLength(2000)]
    public string? CustomerRebateGroupId { get; set; }

    [StringLength(2000)]
    public string? CustomerTMAGroupId { get; set; }

    [StringLength(2000)]
    public string? CustomerType { get; set; }

    [StringLength(2000)]
    public string? CustomerTYpeOldNew { get; set; }

    [StringLength(2000)]
    public string? CustomerWithholdingContributionType { get; set; }

    [StringLength(2000)]
    public string? CustPOReference { get; set; }

    [StringLength(2000)]
    public string? CustReferenceQlik { get; set; }

    [StringLength(2000)]
    public string? CustSubCat { get; set; }

    [StringLength(2000)]
    public string? CustType { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultECommerceOperator { get; set; }

    [StringLength(2000)]
    public string? DefaultInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressBuildingComplement { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCounty { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressState { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressTimeZone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryAddressValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryAddressValidTo { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryFreightZone { get; set; }

    [StringLength(2000)]
    public string? DeliveryMode { get; set; }

    [StringLength(2000)]
    public string? DeliveryReason { get; set; }

    [StringLength(2000)]
    public string? DeliveryTerms { get; set; }

    [StringLength(2000)]
    public string? DemandFlag { get; set; }

    [StringLength(2000)]
    public string? DestinationCode { get; set; }

    [StringLength(2000)]
    public string? DiscountPriceGroupId { get; set; }

    [StringLength(2000)]
    public string? EInvoiceAttachment { get; set; }

    [StringLength(2000)]
    public string? EInvoiceRegister { get; set; }

    [StringLength(2000)]
    public string? ElectronicInvoiceEAN { get; set; }

    [StringLength(2000)]
    public string? ElectronicLocationId { get; set; }

    [StringLength(2000)]
    public string? EmployeeResponsibleNumber { get; set; }

    [StringLength(2000)]
    public string? ExportSale { get; set; }

    [StringLength(2000)]
    public string? FederalAgencyLocationCode { get; set; }

    [StringLength(2000)]
    public string? FederalComments { get; set; }

    [StringLength(2000)]
    public string? FederalIndicator { get; set; }

    [StringLength(2000)]
    public string? FiscalCode { get; set; }

    [StringLength(2000)]
    public string? ForeignCustomer { get; set; }

    [StringLength(2000)]
    public string? ForeignerId { get; set; }

    [StringLength(2000)]
    public string? ForeignResident { get; set; }

    [StringLength(2000)]
    public string? FrenchSiret { get; set; }

    [StringLength(2000)]
    public string? FulfillmentPolicyName { get; set; }

    [StringLength(2000)]
    public string? FullPrimaryAddress { get; set; }

    [StringLength(2000)]
    public string? GiroType { get; set; }

    [StringLength(2000)]
    public string? GiroTypeAccountStatement { get; set; }

    [StringLength(2000)]
    public string? GiroTypeCollectionletter { get; set; }

    [StringLength(2000)]
    public string? GiroTypeFreeTextInvoice { get; set; }

    [StringLength(2000)]
    public string? GiroTypeInterestNote { get; set; }

    [StringLength(2000)]
    public string? GiroTypeProjInvoice { get; set; }

    [StringLength(2000)]
    public string? HasSuframaDiscountPISandCOFINS { get; set; }

    [StringLength(2000)]
    public string? IdentificationNumber { get; set; }

    [StringLength(2000)]
    public string? IncentiveSchedule { get; set; }

    [StringLength(2000)]
    public string? InterCompanyAutoCreateOrders { get; set; }

    [StringLength(2000)]
    public string? InterCompanyBranch { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddress { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressBuildingComplement { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCity { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCounty { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressDescription { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressLocationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressState { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreet { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressTimeZone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceAddressValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceAddressValidTo { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? InvoicePostingType { get; set; }

    [StringLength(2000)]
    public string? IRS1099CIndicator { get; set; }

    [StringLength(2000)]
    public string? IsAllowCreateIndirectOrderLines { get; set; }

    [StringLength(2000)]
    public string? IsElectronicInvoice { get; set; }

    [StringLength(2000)]
    public string? IsExcludedFromCollectionFeeCalculation { get; set; }

    [StringLength(2000)]
    public string? IsExcludedFromInterestChargeCalculation { get; set; }

    [StringLength(2000)]
    public string? IsExpressBillOfLadingAccepted { get; set; }

    [StringLength(2000)]
    public string? IsExternallyMaintained { get; set; }

    [StringLength(2000)]
    public string? IsFinalUser { get; set; }

    [StringLength(2000)]
    public string? IsFreightAccrued { get; set; }

    [StringLength(2000)]
    public string? IsFuelSurchargeApplied { get; set; }

    [StringLength(2000)]
    public string? IsICMSContributor { get; set; }

    [StringLength(2000)]
    public string? IsIncomingFiscalDocumentGenerated { get; set; }

    [StringLength(2000)]
    public string? IsInSuframaRegion { get; set; }

    [StringLength(2000)]
    public string? IsOneTimeCustomer { get; set; }

    [StringLength(2000)]
    public string? IsOrderNumberReferenceUsed { get; set; }

    [StringLength(2000)]
    public string? IsPublicSector_IT { get; set; }

    [StringLength(2000)]
    public string? IsPurchRequestUsed { get; set; }

    [StringLength(2000)]
    public string? IsSalesTaxIncludedInPrices { get; set; }

    [StringLength(2000)]
    public string? IsServiceDeliveryAddressBased { get; set; }

    [StringLength(2000)]
    public string? IsTransactionPostedAsShipment { get; set; }

    [StringLength(2000)]
    public string? IsWithholdingTaxCalculated { get; set; }

    [StringLength(2000)]
    public string? ItemCustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? KnownAs { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LineDiscountCode { get; set; }

    [StringLength(2000)]
    public string? LineOfBusinessId { get; set; }

    [StringLength(2000)]
    public string? MerchantID { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? MTRouteId { get; set; }

    [StringLength(2000)]
    public string? MultiLineDiscountCode { get; set; }

    [StringLength(2000)]
    public string? MultipleInvoiceFlag { get; set; }

    [StringLength(2000)]
    public string? NAFCode { get; set; }

    [StringLength(2000)]
    public string? NameAlias { get; set; }

    [StringLength(2000)]
    public string? NationalRegistryNumber { get; set; }

    [StringLength(2000)]
    public string? NatureOfAssessee { get; set; }

    [StringLength(2000)]
    public string? NewCustomerFlag { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OffsetAccountType { get; set; }

    [StringLength(2000)]
    public string? OldReference { get; set; }

    [StringLength(2000)]
    public string? OnHoldStatus { get; set; }

    [StringLength(2000)]
    public string? OrderEntryDeadline { get; set; }

    [StringLength(2000)]
    public string? OrganizationABCCode { get; set; }

    [StringLength(2000)]
    public string? OrganizationName { get; set; }

    [StringLength(2000)]
    public string? OrganizationNumber { get; set; }

    public int? OrganizationNumberOfEmployees { get; set; }

    [StringLength(2000)]
    public string? OrganizationPhoneticName { get; set; }

    [StringLength(2000)]
    public string? OverRate { get; set; }

    [StringLength(2000)]
    public string? PackingDutyLicense { get; set; }

    [StringLength(2000)]
    public string? PackingMaterialFeeLicenseNumber { get; set; }

    [StringLength(2000)]
    public string? PANNumber { get; set; }

    [StringLength(2000)]
    public string? PANReferenceNumber { get; set; }

    [StringLength(2000)]
    public string? PanStatus { get; set; }

    [StringLength(2000)]
    public string? PartyCountry { get; set; }

    [StringLength(2000)]
    public string? PartyNumber { get; set; }

    [StringLength(2000)]
    public string? PartyState { get; set; }

    [StringLength(2000)]
    public string? PartyType { get; set; }

    [StringLength(2000)]
    public string? PaymentBankAccount { get; set; }

    [StringLength(2000)]
    public string? PaymentCashDiscount { get; set; }

    [StringLength(2000)]
    public string? PaymentDay { get; set; }

    [StringLength(2000)]
    public string? PaymentFactoringAccount { get; set; }

    [StringLength(2000)]
    public string? PaymentIdType { get; set; }

    [StringLength(2000)]
    public string? PaymentMethod { get; set; }

    [StringLength(2000)]
    public string? PaymentSchedule { get; set; }

    [StringLength(2000)]
    public string? PaymentSpecification { get; set; }

    [StringLength(2000)]
    public string? PaymentTerms { get; set; }

    public int? PaymentTermsBaseDays { get; set; }

    [StringLength(2000)]
    public string? PaymentUseCashDiscount { get; set; }

    public int? PersonAnniversaryDay { get; set; }

    [StringLength(2000)]
    public string? PersonAnniversaryMonth { get; set; }

    public int? PersonAnniversaryYear { get; set; }

    [StringLength(2000)]
    public string? PersonChildrenNames { get; set; }

    [StringLength(2000)]
    public string? PersonFirstName { get; set; }

    [StringLength(2000)]
    public string? PersonGender { get; set; }

    [StringLength(2000)]
    public string? PersonHobbies { get; set; }

    [StringLength(2000)]
    public string? PersonInitials { get; set; }

    [StringLength(2000)]
    public string? PersonLastName { get; set; }

    [StringLength(2000)]
    public string? PersonLastNamePrefix { get; set; }

    [StringLength(2000)]
    public string? PersonMaritalStatus { get; set; }

    [StringLength(2000)]
    public string? PersonMiddleName { get; set; }

    [StringLength(2000)]
    public string? PersonPhoneticFirstName { get; set; }

    [StringLength(2000)]
    public string? PersonPhoneticLastName { get; set; }

    [StringLength(2000)]
    public string? PersonPhoneticMiddleName { get; set; }

    [StringLength(2000)]
    public string? PersonProfessionalSuffix { get; set; }

    [StringLength(2000)]
    public string? PersonProfessionalTitle { get; set; }

    [StringLength(2000)]
    public string? PreferentialCustomer { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmail { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailIsIM { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailPurpose { get; set; }

    public long? PrimaryContactEmailRecordId { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebook { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebookDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebookPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFax { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFaxDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFaxExtension { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFaxPurpose { get; set; }

    public long? PrimaryContactFaxRecordId { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactLinkedIn { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactLinkedInDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactLinkedInPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhone { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhoneDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhoneExtension { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhoneIsMobile { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhonePurpose { get; set; }

    public long? PrimaryContactPhoneRecordId { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTelex { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTelexDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTelexPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTwitter { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTwitterDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTwitterPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURL { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURLDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURLPurpose { get; set; }

    public long? PrimaryContactURLRecordId { get; set; }

    [StringLength(2000)]
    public string? Priority { get; set; }

    [StringLength(2000)]
    public string? ReceiptCalendar { get; set; }

    [StringLength(2000)]
    public string? ReceiptEmail { get; set; }

    [StringLength(2000)]
    public string? ReceiptOption { get; set; }

    [StringLength(2000)]
    public string? RejectionGroup { get; set; }

    [StringLength(2000)]
    public string? ReliefGroupId { get; set; }

    [StringLength(2000)]
    public string? ResidenceForeignCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? RFCNumber { get; set; }

    [StringLength(2000)]
    public string? SalesAccountNumber { get; set; }

    [StringLength(2000)]
    public string? SalesCurrencyCode { get; set; }

    [StringLength(2000)]
    public string? SalesDistrict { get; set; }

    [StringLength(2000)]
    public string? SalesMemo { get; set; }

    [StringLength(2000)]
    public string? SalesOrderPoolId { get; set; }

    [StringLength(2000)]
    public string? SalesReturnTaxGroup { get; set; }

    [StringLength(2000)]
    public string? SalesSegmentId { get; set; }

    [StringLength(2000)]
    public string? SalesSubsegmentId { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroup { get; set; }

    [StringLength(2000)]
    public string? SiconStatus { get; set; }

    [StringLength(2000)]
    public string? SiteId { get; set; }

    [StringLength(2000)]
    public string? State { get; set; }

    [StringLength(2000)]
    public string? StateInscription { get; set; }

    [StringLength(2000)]
    public string? StatisticsGroupId { get; set; }

    public int? StdSaleTime { get; set; }

    [StringLength(2000)]
    public string? StoreCode { get; set; }

    [StringLength(2000)]
    public string? SuframaNumber { get; set; }

    [StringLength(2000)]
    public string? SupplementaryItemGroupId { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? TaxRegistrationId { get; set; }

    [StringLength(2000)]
    public string? TCSGroup { get; set; }

    [StringLength(2000)]
    public string? TDSGroup { get; set; }

    [StringLength(2000)]
    public string? TotalDiscountCode { get; set; }

    [StringLength(2000)]
    public string? TransactionPresenceType { get; set; }

    [StringLength(2000)]
    public string? VehicleRouteID { get; set; }

    [StringLength(2000)]
    public string? VehicleTag { get; set; }

    [StringLength(2000)]
    public string? VendorAccount { get; set; }

    [StringLength(2000)]
    public string? WarehouseId { get; set; }

    [StringLength(2000)]
    public string? WarehouseIsASNGenerated { get; set; }

    [StringLength(2000)]
    public string? WarehouseIsEntireShipmentFilled { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? WriteoffReason { get; set; }
}

public partial class TCustomersTest : TCustomersBase { }

public partial class TCustomers : TCustomersBase { }
