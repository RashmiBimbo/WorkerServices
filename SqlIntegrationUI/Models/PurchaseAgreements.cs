using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "PurchaseAgreementId")]
public partial class PurchaseAgreements
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PurchaseAgreementId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? AgreementDate { get; set; }

    [StringLength(2000)]
    public string? AgreementStatus { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AgreementSum { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AgreementVatAmount { get; set; }

    [StringLength(2000)]
    public string? AgreementVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? AgreementWorkflowStatus { get; set; }

    [StringLength(2000)]
    public string? AmountDifferenceInTaxAccounting { get; set; }

    [StringLength(2000)]
    public string? BuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? BuyingLegalEntityId { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [StringLength(2000)]
    public string? ChargeVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? CommissionAgreement { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CreditLimit { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DefaultCommitmentType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DefaultEffectiveDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DefaultExpirationDate { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? DeliveryCityInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    [StringLength(2000)]
    public string? DeliveryStreetInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsCode { get; set; }

    [StringLength(2000)]
    public string? DocumentTitle { get; set; }

    [StringLength(2000)]
    public string? ExcludeFromReserveInBusinessAccounting { get; set; }

    [StringLength(2000)]
    public string? ExcludeFromReserveInTaxAccounting { get; set; }

    [StringLength(2000)]
    public string? Extension { get; set; }

    [StringLength(2000)]
    public string? ExternalDocumentReference { get; set; }

    [StringLength(2000)]
    public string? Fax { get; set; }

    [StringLength(2000)]
    public string? FormattedDeliveryAddress { get; set; }

    [StringLength(2000)]
    public string? InternetAddress { get; set; }

    [StringLength(2000)]
    public string? InventoryProfile { get; set; }

    [StringLength(2000)]
    public string? InvoiceVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? IsAgreementRenewable { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressAgreementSpecific { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsInterestBasedOnCentralEuropeanBank { get; set; }

    [StringLength(2000)]
    public string? KindOfActivity { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LineOfBusiness { get; set; }

    [StringLength(2000)]
    public string? MatchingPolicy { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumContractAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MinimumContractAmount { get; set; }

    [StringLength(2000)]
    public string? MobilePhone { get; set; }

    [StringLength(2000)]
    public string? PaymDay { get; set; }

    [StringLength(2000)]
    public string? PaymentScheduleName { get; set; }

    [StringLength(2000)]
    public string? PaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? PostingProfileWithPrepaymentJournalVoucher { get; set; }

    [StringLength(2000)]
    public string? PreparerPersonPartyNumber { get; set; }

    [StringLength(2000)]
    public string? PrimaryResponsibleWorkerName { get; set; }

    [StringLength(2000)]
    public string? ProcurementClassification { get; set; }

    [StringLength(2000)]
    public string? ProjectId { get; set; }

    [StringLength(2000)]
    public string? PurchaseAgreementClassificationName { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderPoolId { get; set; }

    public long? PurchaseResponsible { get; set; }

    [StringLength(2000)]
    public string? PurchasingProcedureType { get; set; }

    [StringLength(2000)]
    public string? PurchasingPurpose { get; set; }

    [StringLength(2000)]
    public string? SecondaryResponsibleWorkerName { get; set; }

    [StringLength(255)]
    public string? ShippingCarrierId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceGroupId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceId { get; set; }

    [StringLength(2000)]
    public string? SubjectOfAnAgreement { get; set; }

    [StringLength(2000)]
    public string? Telephone { get; set; }

    [StringLength(2000)]
    public string? TelexNumber { get; set; }

    [StringLength(2000)]
    public string? TransportationModeId { get; set; }

    [StringLength(2000)]
    public string? TransportationRoutePlanId { get; set; }

    [StringLength(2000)]
    public string? TransportationTemplateId { get; set; }

    [StringLength(2000)]
    public string? VATCharge { get; set; }

    [StringLength(2000)]
    public string? VATOperationCode { get; set; }

    [StringLength(2000)]
    public string? VendorBankAccountId { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentMethodName { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentMethodSpecificationName { get; set; }

    [StringLength(2000)]
    public string? VendorReference { get; set; }

    [StringLength(2000)]
    public string? ShipCalendarId { get; set; }

    public long? RecIdCopy1 { get; set; }
}
