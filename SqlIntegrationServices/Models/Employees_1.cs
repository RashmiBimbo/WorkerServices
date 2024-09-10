using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("EmploymentEndDate", "EmploymentLegalEntityId", "EmploymentStartDate", "PersonnelNumber")]
[Index("PersonnelNumber", Name = "idx_PersonnelNumber")]
public abstract partial class Employees_1Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime EmploymentEndDate { get; set; }

    [Key]
    [StringLength(255)]
    public string EmploymentLegalEntityId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime EmploymentStartDate { get; set; }

    [Key]
    [StringLength(255)]
    public string PersonnelNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AddressBooks { get; set; }

    [StringLength(2000)]
    public string? AddressCity { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? AddressCounty { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? AddressLocationId { get; set; }

    [StringLength(2000)]
    public string? AddressLocationRoles { get; set; }

    [StringLength(2000)]
    public string? AddressNameDescription { get; set; }

    [StringLength(2000)]
    public string? AddressState { get; set; }

    [StringLength(2000)]
    public string? AddressStreet { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AddressValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AddressValidTo { get; set; }

    [StringLength(2000)]
    public string? AddressZipCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AdjustedWorkerStartDate { get; set; }

    [StringLength(2000)]
    public string? AllowRehire { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AnniversaryDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [StringLength(2000)]
    public string? CalendarId { get; set; }

    [StringLength(2000)]
    public string? Category { get; set; }

    [StringLength(2000)]
    public string? CitizenshipCountryRegion { get; set; }

    [StringLength(2000)]
    public string? CompanyDataID { get; set; }

    [StringLength(2000)]
    public string? ContactNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeceasedDate { get; set; }

    [StringLength(2000)]
    public string? DimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DisabledVerificationDate { get; set; }

    [StringLength(2000)]
    public string? Education { get; set; }

    [StringLength(2000)]
    public string? ElectronicLocationId { get; set; }

    [StringLength(2000)]
    public string? EmpDepot { get; set; }

    [StringLength(2000)]
    public string? EmpDesignation { get; set; }

    [StringLength(2000)]
    public string? EmpDesignation2 { get; set; }

    [StringLength(2000)]
    public string? EmpDesignation3 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmployeeDetailsEffective { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmployeeDetailsExpiration { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmploymentDetailsEffective { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmploymentDetailsExpiration { get; set; }

    public int? EmploymentNoticeEmployerQuantity { get; set; }

    [StringLength(2000)]
    public string? EmploymentNoticeEmployerUnit { get; set; }

    public int? EmploymentNoticeWorkerQuantity { get; set; }

    [StringLength(2000)]
    public string? EmploymentNoticeWorkerUnit { get; set; }

    [StringLength(2000)]
    public string? EmpName { get; set; }

    [StringLength(255)]
    public string? EthnicOriginId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpatriateRulingValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpatriateRulingValidTo { get; set; }

    [StringLength(2000)]
    public string? FatherBirthCountryRegion { get; set; }

    [StringLength(2000)]
    public string? FirstName { get; set; }

    [StringLength(2000)]
    public string? Gender { get; set; }

    [StringLength(2000)]
    public string? IsDisabled { get; set; }

    [StringLength(2000)]
    public string? IsDisabledVeteran { get; set; }

    [StringLength(2000)]
    public string? IsExpatriateRulingApplicable { get; set; }

    [StringLength(2000)]
    public string? IsFulltimeStudent { get; set; }

    [StringLength(2000)]
    public string? KnownAs { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastDateWorked { get; set; }

    [StringLength(2000)]
    public string? LastName { get; set; }

    [StringLength(2000)]
    public string? LastNamePrefix { get; set; }

    [StringLength(2000)]
    public string? MaritalStatus { get; set; }

    [StringLength(2000)]
    public string? MiddleName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MilitaryServiceEndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MilitaryServiceStartDate { get; set; }

    [StringLength(2000)]
    public string? MotherBirthCountryRegion { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? NameAlias { get; set; }

    [StringLength(2000)]
    public string? NameSequenceDisplayAs { get; set; }

    [StringLength(2000)]
    public string? NationalityCountryRegion { get; set; }

    [StringLength(255)]
    public string? NativeLanguageId { get; set; }

    [StringLength(2000)]
    public string? NewEMPCode { get; set; }

    public int? NumberOfDependents { get; set; }

    [StringLength(2000)]
    public string? OfficeLocation { get; set; }

    [StringLength(2000)]
    public string? OfficeLocationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OriginalHireDateTime { get; set; }

    [StringLength(255)]
    public string? PartyNumber { get; set; }

    [StringLength(2000)]
    public string? PartyType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PensionEnrollment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PensionStart { get; set; }

    [StringLength(2000)]
    public string? PersonalSuffix { get; set; }

    [StringLength(2000)]
    public string? PersonalTitle { get; set; }

    [StringLength(2000)]
    public string? PersonBirthCity { get; set; }

    [StringLength(2000)]
    public string? PersonBirthCountryRegion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PersonDetailsValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PersonDetailsValidTo { get; set; }

    [StringLength(2000)]
    public string? PhoneticFirstName { get; set; }

    [StringLength(2000)]
    public string? PhoneticLastName { get; set; }

    [StringLength(2000)]
    public string? PhoneticMiddleName { get; set; }

    public long? PrimaryAddressLocation { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmail { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailIsIM { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactEmailIsPrivate { get; set; }

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
    public string? PrimaryContactFaxIsPrivate { get; set; }

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
    public string? PrimaryContactPhoneIsPrivate { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactPhonePurpose { get; set; }

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
    public string? PrimaryContactURLIsPrivate { get; set; }

    [StringLength(2000)]
    public string? PrimaryContactURLPurpose { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProbationPeriod { get; set; }

    [StringLength(2000)]
    public string? ProfessionalSuffix { get; set; }

    [StringLength(2000)]
    public string? ProfessionalTitle { get; set; }

    [StringLength(2000)]
    public string? RegulatoryEstablishmentId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RelocationReimbursement { get; set; }

    [StringLength(2000)]
    public string? scionYes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SeniorityDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SummaryValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SummaryValidTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TerminationDate { get; set; }

    [StringLength(2000)]
    public string? TerminationReasonCodeId { get; set; }

    [StringLength(255)]
    public string? TitleId { get; set; }

    [StringLength(2000)]
    public string? Type { get; set; }

    [StringLength(255)]
    public string? VeteranStatusId { get; set; }

    [StringLength(2000)]
    public string? WorksFromHome { get; set; }

    [StringLength(255)]
    public string? CalendarDataAreaId { get; set; }
}

public partial class Employees_1Test : Employees_1Base {}

public partial class Employees_1 : Employees_1Base {}
