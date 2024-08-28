using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "VendorAccountNumber", "VendorBankAccountId")]
public abstract partial class VendorBankAccountsBase
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

    [Key]
    [StringLength(255)]
    public string VendorBankAccountId { get; set; } = null!;

    public DateTime? ActiveDate { get; set; }

    [StringLength(2000)]
    public string? AddressBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? AddressCity { get; set; }

    [StringLength(2000)]
    public string? AddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? AddressCountry { get; set; }

    [StringLength(2000)]
    public string? AddressCountryISOCode { get; set; }

    [StringLength(2000)]
    public string? AddressCounty { get; set; }

    [StringLength(2000)]
    public string? AddressDescription { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLatitude { get; set; }

    [StringLength(2000)]
    public string? AddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AddressLongitude { get; set; }

    [StringLength(2000)]
    public string? AddressPostBox { get; set; }

    [StringLength(2000)]
    public string? AddressState { get; set; }

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
    public string? BankAccountNumber { get; set; }

    [StringLength(2000)]
    public string? BankAccountType { get; set; }

    [StringLength(2000)]
    public string? BankConstantSymbol { get; set; }

    [StringLength(2000)]
    public string? BankCorrespondenceAccountBankGroupId { get; set; }

    [StringLength(2000)]
    public string? BankCorrespondenceBankGroupId { get; set; }

    [StringLength(255)]
    public string? BankGroupId { get; set; }

    [StringLength(2000)]
    public string? BankInformationOrigin { get; set; }

    [StringLength(2000)]
    public string? BankMessage { get; set; }

    [StringLength(2000)]
    public string? BankName { get; set; }

    [StringLength(2000)]
    public string? BankNameInKana { get; set; }

    [StringLength(2000)]
    public string? BankSpecificSymbol { get; set; }

    [StringLength(2000)]
    public string? BankTransactionType { get; set; }

    [StringLength(2000)]
    public string? Comments { get; set; }

    [StringLength(2000)]
    public string? ContactEmailAddress { get; set; }

    [StringLength(2000)]
    public string? ContactEmailAddressForSendingSMS { get; set; }

    [StringLength(2000)]
    public string? ContactFaxNumber { get; set; }

    [StringLength(2000)]
    public string? ContactInternetAddress { get; set; }

    [StringLength(2000)]
    public string? ContactMobilePhoneNumber { get; set; }

    [StringLength(2000)]
    public string? ContactName { get; set; }

    [StringLength(2000)]
    public string? ContactPager { get; set; }

    [StringLength(2000)]
    public string? ContactPhoneNumber { get; set; }

    [StringLength(2000)]
    public string? ContactPhoneNumberExtension { get; set; }

    [StringLength(2000)]
    public string? ContactTelexNumber { get; set; }

    [StringLength(2000)]
    public string? ControlInternalNumber { get; set; }

    [StringLength(2000)]
    public string? CorrespondenceBankAccountNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CrossRate { get; set; }

    [StringLength(255)]
    public string? CurrentCurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DUNS4NumberSuffix { get; set; }

    [StringLength(2000)]
    public string? DUNSNumber { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [StringLength(2000)]
    public string? ForeignBankAccountNumber { get; set; }

    [StringLength(2000)]
    public string? ForeignBankGroupId { get; set; }

    [StringLength(2000)]
    public string? ForeignBankSWIFTCode { get; set; }

    [StringLength(2000)]
    public string? FormattedAddress { get; set; }

    [StringLength(2000)]
    public string? IBAN { get; set; }

    [StringLength(2000)]
    public string? InterimBankCorrespondenceBankAccountNumber { get; set; }

    [StringLength(2000)]
    public string? InterimVendorBankAccountNumber { get; set; }

    [StringLength(2000)]
    public string? IsDefaultBankAccount { get; set; }

    [StringLength(2000)]
    public string? IsDefaultBankAccountForCurrentCurrency { get; set; }

    [StringLength(2000)]
    public string? PaymentSpecificationParameter { get; set; }

    [StringLength(2000)]
    public string? QRIBAN { get; set; }

    [StringLength(2000)]
    public string? RateOfExchangeReference { get; set; }

    [StringLength(2000)]
    public string? RecipientTextCode { get; set; }

    [StringLength(2000)]
    public string? Reviewed { get; set; }

    [StringLength(2000)]
    public string? RoutingNumber { get; set; }

    [StringLength(2000)]
    public string? RoutingNumberType { get; set; }

    [StringLength(2000)]
    public string? SWIFTCode { get; set; }

    [StringLength(2000)]
    public string? IFSC { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class VendorBankAccountsTest : VendorBankAccountsBase {}

public partial class VendorBankAccounts : VendorBankAccountsBase {}
