using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "VendorAccountNumber")]
public abstract partial class VendorsV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string VendorAccountNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AddressBooks { get; set; }

    [StringLength(2000)]
    public string? AddressBrazilianCNPJOrCPF { get; set; }

    [StringLength(2000)]
    public string? AddressBrazilianIE { get; set; }

    [StringLength(2000)]
    public string? AddressBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? AddressCity { get; set; }

    [StringLength(2000)]
    public string? AddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? AddressCountyId { get; set; }

    [StringLength(2000)]
    public string? AddressDescription { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLatitude { get; set; }

    [StringLength(2000)]
    public string? AddressLocationId { get; set; }

    [StringLength(2000)]
    public string? AddressLocationRoles { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLongitude { get; set; }

    [StringLength(2000)]
    public string? AddressPostBox { get; set; }

    public long? AddressRecordId { get; set; }

    [StringLength(2000)]
    public string? AddressStateId { get; set; }

    [StringLength(2000)]
    public string? AddressStreet { get; set; }

    [StringLength(2000)]
    public string? AddressStreetInKana { get; set; }

    [StringLength(2000)]
    public string? AddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? AddressTimeZone { get; set; }

    public DateTime? AddressValidFrom { get; set; }

    public DateTime? AddressValidTo { get; set; }

    [StringLength(2000)]
    public string? AddressZipCode { get; set; }

    [StringLength(2000)]
    public string? ArePricesIncludingSalesTax { get; set; }

    [StringLength(2000)]
    public string? BankAccountId { get; set; }

    [StringLength(2000)]
    public string? BankOrderOfPayment { get; set; }

    [StringLength(2000)]
    public string? BankTransactionType { get; set; }

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
    public string? BusinessSegmentCode { get; set; }

    [StringLength(2000)]
    public string? BusinessSubsegmentCode { get; set; }

    [StringLength(2000)]
    public string? BuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [StringLength(2000)]
    public string? CentralBankPurposeCode { get; set; }

    [StringLength(2000)]
    public string? CentralBankPurposeText { get; set; }

    [StringLength(2000)]
    public string? ChargeVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? CISCompanyRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? CISNationalInsuranceNumber { get; set; }

    [StringLength(2000)]
    public string? CISStatus { get; set; }

    [StringLength(2000)]
    public string? CISUniqueTaxPayerReference { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CISVerificationDate { get; set; }

    [StringLength(2000)]
    public string? CISVerificationNumber { get; set; }

    [StringLength(2000)]
    public string? ClearingPeriodPaymentTermsId { get; set; }

    [StringLength(2000)]
    public string? CommercialRegisterInsetNumber { get; set; }

    [StringLength(2000)]
    public string? CommercialRegisterName { get; set; }

    [StringLength(2000)]
    public string? CommercialRegisterSection { get; set; }

    [StringLength(2000)]
    public string? CompanyChainName { get; set; }

    [StringLength(2000)]
    public string? CompanyType { get; set; }

    [StringLength(2000)]
    public string? CompositionScheme { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CreditLimit { get; set; }

    [StringLength(2000)]
    public string? CreditRating { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CUSIPDetails { get; set; }

    [StringLength(2000)]
    public string? CUSIPIdentificationNumber { get; set; }

    [StringLength(2000)]
    public string? CustReference { get; set; }

    [StringLength(2000)]
    public string? DefaultAgentVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? DefaultCashDiscountUsage { get; set; }

    [StringLength(2000)]
    public string? DefaultDeliveryModeId { get; set; }

    [StringLength(2000)]
    public string? DefaultDeliveryTermsCode { get; set; }

    [StringLength(2000)]
    public string? DefaultFromShippingPortId { get; set; }

    [StringLength(2000)]
    public string? DefaultInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultOffsetAccountType { get; set; }

    [StringLength(2000)]
    public string? DefaultOffsetLedgerAccountDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultPaymentDayName { get; set; }

    [StringLength(2000)]
    public string? DefaultPaymentScheduleName { get; set; }

    [StringLength(2000)]
    public string? DefaultPaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? DefaultProcumentWarehouseId { get; set; }

    [StringLength(2000)]
    public string? DefaultPurchaseOrderPoolId { get; set; }

    [StringLength(2000)]
    public string? DefaultPurchaseSiteId { get; set; }

    [StringLength(2000)]
    public string? DefaultSupplementaryProductVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? DefaultTotalDiscountVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? DefaultVendorPaymentMethodName { get; set; }

    [StringLength(2000)]
    public string? DestinationCode { get; set; }

    [StringLength(2000)]
    public string? DIOTCountryCode { get; set; }

    [StringLength(2000)]
    public string? DIOTOperationType { get; set; }

    [StringLength(2000)]
    public string? DIOTVendorType { get; set; }

    [StringLength(2000)]
    public string? DUNSNumber { get; set; }

    [StringLength(2000)]
    public string? ElectronicLocationId { get; set; }

    [StringLength(2000)]
    public string? EnterpriseNumber { get; set; }

    [StringLength(2000)]
    public string? EthnicOriginId { get; set; }

    [StringLength(2000)]
    public string? FactoringVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? FiscalCode { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentIncomeCode { get; set; }

    [StringLength(2000)]
    public string? FiscalOperationPresenceType { get; set; }

    [StringLength(2000)]
    public string? ForeignerId { get; set; }

    [StringLength(2000)]
    public string? ForeignResident { get; set; }

    [StringLength(2000)]
    public string? ForeignVendor { get; set; }

    [StringLength(2000)]
    public string? ForeignVendorTaxRegistrationId { get; set; }

    [StringLength(2000)]
    public string? FormattedPrimaryAddress { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [StringLength(2000)]
    public string? GTAVendor { get; set; }

    [StringLength(2000)]
    public string? HasOnlyTakenBids { get; set; }

    [StringLength(2000)]
    public string? InterCompanyCheck { get; set; }

    [StringLength(2000)]
    public string? InventoryProfile { get; set; }

    [StringLength(2000)]
    public string? InventoryProfileType { get; set; }

    [StringLength(2000)]
    public string? InvoiceVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? IsChangeManagementActivated { get; set; }

    [StringLength(2000)]
    public string? IsChangeMangementOverrideByVendorAllowed { get; set; }

    [StringLength(2000)]
    public string? IsCUSIPIdentificationNumberApplicable { get; set; }

    [StringLength(2000)]
    public string? IsFlaggedWithSecondTIN { get; set; }

    [StringLength(2000)]
    public string? IsForeignEntity { get; set; }

    [StringLength(2000)]
    public string? IsGSTCompositionSchemeEnabled { get; set; }

    [StringLength(2000)]
    public string? IsICMSContributor { get; set; }

    [StringLength(2000)]
    public string? IsImportCostingVendor { get; set; }

    [StringLength(2000)]
    public string? IsIncomingFiscalDocumentGenerated { get; set; }

    [StringLength(2000)]
    public string? IsMinorityOwned { get; set; }

    [StringLength(2000)]
    public string? ISNationalRegistryNumber { get; set; }

    [StringLength(2000)]
    public string? IsOneTimeVendor { get; set; }

    [StringLength(2000)]
    public string? IsOwnerDisabled { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryEmailAddressIMEnabled { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryPhoneNumberMobile { get; set; }

    [StringLength(2000)]
    public string? IsPublicSector_IT { get; set; }

    [StringLength(2000)]
    public string? IsPurchaseConsumed { get; set; }

    [StringLength(2000)]
    public string? IsPurchaseOrderChangeRequestOverrideAllowed { get; set; }

    [StringLength(2000)]
    public string? IsReportingTax1099 { get; set; }

    [StringLength(2000)]
    public string? IsServiceDeliveryAddressBased { get; set; }

    [StringLength(2000)]
    public string? IsServiceVeteranOwned { get; set; }

    [StringLength(2000)]
    public string? IsSmallBusiness { get; set; }

    [StringLength(2000)]
    public string? IsSubcontractor { get; set; }

    [StringLength(2000)]
    public string? IsTaxationOverPayroll_BR { get; set; }

    [StringLength(2000)]
    public string? IsTransportationServicesProvider { get; set; }

    [StringLength(2000)]
    public string? IsVendorLocallyOwned { get; set; }

    [StringLength(2000)]
    public string? IsVendorLocatedInHUBZone { get; set; }

    [StringLength(2000)]
    public string? IsVendorPayingBankPaymentFee { get; set; }

    [StringLength(2000)]
    public string? IsW9CheckingEnabled { get; set; }

    [StringLength(2000)]
    public string? IsW9Received { get; set; }

    [StringLength(2000)]
    public string? IsWithholdingTaxCalculated { get; set; }

    [StringLength(2000)]
    public string? IsWomanOwner { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LineDiscountVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? LineOfBusinessId { get; set; }

    [StringLength(2000)]
    public string? MainContactPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? MSME { get; set; }

    [StringLength(2000)]
    public string? MSMENumber { get; set; }

    [StringLength(2000)]
    public string? MultilineDiscountVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? NAFCode { get; set; }

    [StringLength(2000)]
    public string? NameControl { get; set; }

    [StringLength(2000)]
    public string? Nationality { get; set; }

    [StringLength(2000)]
    public string? NationalRegistryNumberId { get; set; }

    [StringLength(2000)]
    public string? NatureOfAssessee { get; set; }

    [StringLength(2000)]
    public string? Notes { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroupId { get; set; }

    [StringLength(2000)]
    public string? OIDInvestorType { get; set; }

    [StringLength(2000)]
    public string? OIDNomineeDetails { get; set; }

    [StringLength(2000)]
    public string? OnHoldStatus { get; set; }

    [StringLength(2000)]
    public string? OrganizationABCCode { get; set; }

    public int? OrganizationEmployeeAmount { get; set; }

    [StringLength(2000)]
    public string? OrganizationNumber { get; set; }

    [StringLength(2000)]
    public string? OrganizationPhoneticName { get; set; }

    [StringLength(2000)]
    public string? OurAccountNumber { get; set; }

    [StringLength(2000)]
    public string? PANNumber { get; set; }

    [StringLength(2000)]
    public string? PANReferenceNumber { get; set; }

    [StringLength(2000)]
    public string? PANStatus { get; set; }

    [StringLength(2000)]
    public string? PaymentFeeGroupId { get; set; }

    [StringLength(2000)]
    public string? PaymentId { get; set; }

    [StringLength(2000)]
    public string? PaymentSpecificationId { get; set; }

    [StringLength(2000)]
    public string? PaymentTransactionCode { get; set; }

    public int? PersonAnniversaryDay { get; set; }

    [StringLength(2000)]
    public string? PersonAnniversaryMonth { get; set; }

    public int? PersonAnniversaryYear { get; set; }

    public int? PersonBirthDay { get; set; }

    [StringLength(2000)]
    public string? PersonBirthMonth { get; set; }

    public int? PersonBirthYear { get; set; }

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
    public string? PersonPersonalSuffix { get; set; }

    [StringLength(2000)]
    public string? PersonPersonalTitle { get; set; }

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
    public string? PreferentialVendor { get; set; }

    [StringLength(2000)]
    public string? PriceVendorGroupId { get; set; }

    public long? PrimaryContactEmailRecordId { get; set; }

    public long? PrimaryContactFaxRecordId { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPersonId { get; set; }

    public long? PrimaryContactPhoneRecordId { get; set; }

    public long? PrimaryContactURLRecordId { get; set; }

    [StringLength(2000)]
    public string? PrimaryEmailAddress { get; set; }

    [StringLength(2000)]
    public string? PrimaryEmailAddressDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryEmailAddressPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryFacebook { get; set; }

    [StringLength(2000)]
    public string? PrimaryFacebookDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryFacebookPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryFaxNumber { get; set; }

    [StringLength(2000)]
    public string? PrimaryFaxNumberDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryFaxNumberExtension { get; set; }

    [StringLength(2000)]
    public string? PrimaryFaxNumberPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryLinkedIn { get; set; }

    [StringLength(2000)]
    public string? PrimaryLinkedInDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryLinkedInPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryPhoneNumber { get; set; }

    [StringLength(2000)]
    public string? PrimaryPhoneNumberDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryPhoneNumberExtension { get; set; }

    [StringLength(2000)]
    public string? PrimaryPhoneNumberPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryTelex { get; set; }

    [StringLength(2000)]
    public string? PrimaryTelexDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryTelexPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryTwitter { get; set; }

    [StringLength(2000)]
    public string? PrimaryTwitterDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryTwitterPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryURL { get; set; }

    [StringLength(2000)]
    public string? PrimaryURLDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryURLPurpose { get; set; }

    [StringLength(2000)]
    public string? ProductDescriptionVendorGroupId { get; set; }

    public int? PurchaseOrderConsolidationDayOfMonth { get; set; }

    [StringLength(2000)]
    public string? PurchaseRebateVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? PurchaseWorkCalendarId { get; set; }

    [StringLength(2000)]
    public string? ResidenceForeignCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? RFCFederalTaxNumber { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? SeparateDivisionId { get; set; }

    [StringLength(2000)]
    public string? ShippingVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? ShippingVendorType { get; set; }

    [StringLength(2000)]
    public string? SiretNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SSIValidityDate { get; set; }

    [StringLength(2000)]
    public string? SSIVendor { get; set; }

    [StringLength(2000)]
    public string? StateInscription { get; set; }

    [StringLength(2000)]
    public string? StructureDepartment { get; set; }

    [StringLength(2000)]
    public string? Tax1099BoxId { get; set; }

    [StringLength(2000)]
    public string? Tax1099DoingBusinessAsName { get; set; }

    [StringLength(2000)]
    public string? Tax1099FederalTaxId { get; set; }

    [StringLength(2000)]
    public string? Tax1099IdType { get; set; }

    [StringLength(2000)]
    public string? Tax1099NameToUse { get; set; }

    [StringLength(2000)]
    public string? Tax1099Type { get; set; }

    [StringLength(2000)]
    public string? TaxAgent { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? TaxOperationCode { get; set; }

    [StringLength(2000)]
    public string? TaxPartnerKind { get; set; }

    [StringLength(2000)]
    public string? TCSGroup { get; set; }

    [StringLength(2000)]
    public string? TDSGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [StringLength(2000)]
    public string? UniquePopulationRegistryCode { get; set; }

    [StringLength(2000)]
    public string? UPSFreightZone { get; set; }

    [StringLength(2000)]
    public string? VendCashId { get; set; }

    [StringLength(2000)]
    public string? VendOldReference { get; set; }

    [StringLength(2000)]
    public string? Vendor2P { get; set; }

    [StringLength(2000)]
    public string? Vendor3P { get; set; }

    [StringLength(2000)]
    public string? VendorCostTypeGroup { get; set; }

    [StringLength(2000)]
    public string? VendorExceptionGroupId { get; set; }

    [StringLength(2000)]
    public string? VendorGroupId { get; set; }

    public DateTime? VendorHoldReleaseDate { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceDeclarationId { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceLineMatchingPolicy { get; set; }

    [StringLength(2000)]
    public string? VendorKnownAsName { get; set; }

    [StringLength(2000)]
    public string? VendorOrganizationName { get; set; }

    [StringLength(2000)]
    public string? VendorOverUnderdeliveryToleranceGroupId { get; set; }

    [StringLength(2000)]
    public string? VendorPartyNumber { get; set; }

    [StringLength(2000)]
    public string? VendorPartyType { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentFinancialInterestCode { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentFineCode { get; set; }

    [StringLength(2000)]
    public string? VendorPortalCollaborationMethod { get; set; }

    [StringLength(2000)]
    public string? VendorPriceToleranceGroupId { get; set; }

    [StringLength(2000)]
    public string? VendorSearchName { get; set; }

    [StringLength(2000)]
    public string? WillInvoiceProcessingSummaryUpdatePurchaseOrder { get; set; }

    [StringLength(2000)]
    public string? WillProductReceiptProcessingSummaryUpdatePurchaseOrder { get; set; }

    [StringLength(2000)]
    public string? WillPurchaseOrderIncludePricesAndAmounts { get; set; }

    [StringLength(2000)]
    public string? WillPurchaseOrderProcessingSummaryUpdatePurchaseOrder { get; set; }

    [StringLength(2000)]
    public string? WillReceiptsListProcessingSummaryUpdatePurchaseOrder { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxVendorType { get; set; }

    [StringLength(2000)]
    public string? ZakatFileNumber { get; set; }

    [StringLength(2000)]
    public string? ZakatRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? ZakatServiceType { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }

    [StringLength(2000)]
    public string? VendorDUNSNumber { get; set; }

    [StringLength(2000)]
    public string? BarcodeNumberSequence { get; set; }

    [StringLength(2000)]
    public string? ColorIdPrefix { get; set; }

    [StringLength(2000)]
    public string? CreateBarcodeIfNeeded { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchangeRate { get; set; }

    [StringLength(2000)]
    public string? FixedExchangeRate { get; set; }

    [StringLength(2000)]
    public string? PricePointGroupId { get; set; }

    [StringLength(2000)]
    public string? PricePointRoundingType { get; set; }

    [StringLength(2000)]
    public string? RoundingMethod { get; set; }

    [StringLength(2000)]
    public string? SalesPriceRounding { get; set; }

    [StringLength(2000)]
    public string? ServiceCategory { get; set; }

    [StringLength(2000)]
    public string? SizeIdPrefix { get; set; }

    [StringLength(2000)]
    public string? StyleIdPrefix { get; set; }

    public long? VendorProductHierarchyId { get; set; }

    [StringLength(2000)]
    public string? VendorType { get; set; }

    [StringLength(2000)]
    public string? PurchaseShipCalendarId { get; set; }

    [StringLength(2000)]
    public string? Aadhar { get; set; }

    [StringLength(2000)]
    public string? HGPanStatus { get; set; }

    [StringLength(2000)]
    public string? TPI { get; set; }
}

public partial class VendorsV2Test : VendorsV2Base { }

public partial class VendorsV2 : VendorsV2Base { }
