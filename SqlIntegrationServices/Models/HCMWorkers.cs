using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class HCMWorkersBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

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
    public string? AddressNameDescription { get; set; }

    [StringLength(2000)]
    public string? AddressPurpose { get; set; }

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

    [StringLength(2000)]
    public string? AllowRehire { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AnniversaryDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [StringLength(2000)]
    public string? CitizenshipCountryRegion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeceasedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DisabledVerificationDate { get; set; }

    [StringLength(2000)]
    public string? Education { get; set; }

    [StringLength(2000)]
    public string? ElectronicLocationId { get; set; }

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

    public int? NumberOfDependents { get; set; }

    [StringLength(36)]
    public string? ObjectId { get; set; }

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

    [StringLength(2000)]
    public string? ProfessionalSuffix { get; set; }

    [StringLength(2000)]
    public string? ProfessionalTitle { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SeniorityDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SummaryValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SummaryValidTo { get; set; }

    [StringLength(255)]
    public string? TitleId { get; set; }

    [StringLength(255)]
    public string? VeteranStatusId { get; set; }

    [StringLength(2000)]
    public string? WorkerStatus { get; set; }

    [StringLength(2000)]
    public string? WorkerType { get; set; }

    [StringLength(2000)]
    public string? WorksFromHome { get; set; }
}

public partial class HCMWorkersTest : HCMWorkersBase {}

public partial class HCMWorkers : HCMWorkersBase {}
