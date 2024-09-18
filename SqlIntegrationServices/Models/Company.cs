using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class CompanyBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LegalEntityId { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountingPersonnel { get; set; }

    [StringLength(2000)]
    public string? AccountsOfficeReferenceNumber { get; set; }

    [StringLength(2000)]
    public string? AddressBooks { get; set; }

    [StringLength(2000)]
    public string? AddressCity { get; set; }

    [StringLength(255)]
    public string? AddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? AddressCounty { get; set; }

    [StringLength(2000)]
    public string? AddressDescription { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLatitude { get; set; }

    [StringLength(2000)]
    public string? AddressLocationRoles { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLongitude { get; set; }

    [StringLength(2000)]
    public string? AddressState { get; set; }

    [StringLength(2000)]
    public string? AddressStreet { get; set; }

    [StringLength(2000)]
    public string? AddressTimeZone { get; set; }

    public DateTime? AddressValidFrom { get; set; }

    public DateTime? AddressValidTo { get; set; }

    [StringLength(2000)]
    public string? AddressZipCode { get; set; }

    [StringLength(2000)]
    public string? BusinessItem { get; set; }

    [StringLength(2000)]
    public string? CertifiedTaxAccountantName { get; set; }

    [StringLength(2000)]
    public string? CommerceRegistration { get; set; }

    [StringLength(2000)]
    public string? CompanyCountry { get; set; }

    [StringLength(2000)]
    public string? CompanyName { get; set; }

    [StringLength(2000)]
    public string? CompanyRepresentative { get; set; }

    [StringLength(2000)]
    public string? CompanyType { get; set; }

    [StringLength(2000)]
    public string? CUC { get; set; }

    [StringLength(2000)]
    public string? CurpLegalRepresentative { get; set; }

    [StringLength(2000)]
    public string? CurpNumber { get; set; }

    [StringLength(2000)]
    public string? DNBRoutingNumber { get; set; }

    [StringLength(2000)]
    public string? ExternalLegalRepresentativeName { get; set; }

    [StringLength(2000)]
    public string? FICreditorID { get; set; }

    [StringLength(2000)]
    public string? FiscalCode { get; set; }

    [StringLength(2000)]
    public string? FullPrimaryAddress { get; set; }

    [StringLength(255)]
    public string? ImportVATNum { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InitialCapitalInvestment { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LegalForm { get; set; }

    [StringLength(2000)]
    public string? LegalNature { get; set; }

    [StringLength(2000)]
    public string? LegalRepresentativeName { get; set; }

    [StringLength(2000)]
    public string? LocalizationCountryRegionCode { get; set; }

    [StringLength(2000)]
    public string? NAICS { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? NameAlias { get; set; }

    [StringLength(2000)]
    public string? NationalClassificationOfCompanyEconomicActivity { get; set; }

    [StringLength(2000)]
    public string? NationalRegistryNumber { get; set; }

    [StringLength(2000)]
    public string? PartyNumber { get; set; }

    [StringLength(2000)]
    public string? PersonInCharge { get; set; }

    [StringLength(2000)]
    public string? PhoneticName { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressLocationId { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmail { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailIsIM { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebook { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebookDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactFacebookIsPrivate { get; set; }

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

    [StringLength(2000)]
    public string? PrimaryContactLinkedIn { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactLinkedInDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactLinkedInIsPrivate { get; set; }

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
    public string? PrimaryContactTwitterIsPrivate { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactTwitterPurpose { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURL { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURLDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURLPurpose { get; set; }

    [StringLength(2000)]
    public string? PrintCorrectiveInvoice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PrintCorrectiveInvoiceStartingDate { get; set; }

    [StringLength(2000)]
    public string? PrintEnterpriseRegister { get; set; }

    [StringLength(2000)]
    public string? PrintINNKPPInAddress { get; set; }

    [StringLength(2000)]
    public string? ProfitMarginScheme { get; set; }

    [StringLength(2000)]
    public string? RegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? ReportFolder { get; set; }

    [StringLength(2000)]
    public string? Rfc { get; set; }

    [StringLength(2000)]
    public string? RfcLegalRepresentative { get; set; }

    [StringLength(2000)]
    public string? SiconDisplayFlag { get; set; }

    [StringLength(2000)]
    public string? SoftwareIdentificationCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDateOfBusiness { get; set; }

    [StringLength(2000)]
    public string? StateInscription { get; set; }

    [StringLength(2000)]
    public string? TimeZone { get; set; }

    [StringLength(2000)]
    public string? TraderNumber { get; set; }

    [StringLength(2000)]
    public string? UseForFinancialConsolidationProcess { get; set; }

    [StringLength(2000)]
    public string? UseForFinancialEliminationProcess { get; set; }

    [StringLength(255)]
    public string? VATNum { get; set; }

    [StringLength(2000)]
    public string? VATOnCustomerBehalf { get; set; }

    [StringLength(2000)]
    public string? VATRefund { get; set; }
}

public partial class CompanyTest : CompanyBase { }

public partial class Company : CompanyBase { }
