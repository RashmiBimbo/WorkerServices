using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceId")]
public partial class HGSalesInvoiceHeaders
{
    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceId { get; set; } = null!;

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Address { get; set; }

    [StringLength(2000)]
    public string? Backorder { get; set; }

    public long? BankLCExportLine { get; set; }

    [StringLength(2000)]
    public string? BillOfLadingId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CashDisc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscBaseDate { get; set; }

    [StringLength(2000)]
    public string? CashDiscCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CashDiscPercent { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CountryRegionId { get; set; }

    [StringLength(2000)]
    public string? County { get; set; }

    public int? CovStatus { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CustGroup { get; set; }

    [StringLength(2000)]
    public string? CustomerRef { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    public long? DeliveryPostalAddress { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DemandDateJour { get; set; }

    public long? DirectDebitMandate { get; set; }

    [StringLength(2000)]
    public string? DlvMode { get; set; }

    [StringLength(2000)]
    public string? DlvTerm { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNum { get; set; }

    [StringLength(2000)]
    public string? DriverCode { get; set; }

    [StringLength(2000)]
    public string? DriverName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(2000)]
    public string? EInvoiceAccountCode { get; set; }

    [StringLength(2000)]
    public string? EInvoiceLineSpecific { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EndDisc { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EndDiscMST { get; set; }

    [StringLength(2000)]
    public string? EnterpriseNumber { get; set; }

    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? EUSalesList { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchRateSecondary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FixedDueDate { get; set; }

    [StringLength(2000)]
    public string? GiroType { get; set; }

    [StringLength(2000)]
    public string? InclTax { get; set; }

    [StringLength(2000)]
    public string? InterCompanyCompanyId { get; set; }

    [StringLength(2000)]
    public string? InterCompanyPosted { get; set; }

    [StringLength(2000)]
    public string? InterCompanyPurchId { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? IntrastatFulfillmentDate_HU { get; set; }

    [StringLength(2000)]
    public string? inventLocationId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoiceAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoiceAmountMST { get; set; }

    public long? InvoicePostalAddress { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoiceRoundOff { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoiceRoundOffMST { get; set; }

    [StringLength(2000)]
    public string? InvoicingName { get; set; }

    [StringLength(2000)]
    public string? IsCorrection { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LedgerVoucher { get; set; }

    [StringLength(2000)]
    public string? Listcode { get; set; }

    [StringLength(2000)]
    public string? LoaderCode { get; set; }

    [StringLength(2000)]
    public string? LoaderName { get; set; }

    [StringLength(2000)]
    public string? Log { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MCRDueAmount { get; set; }

    [StringLength(2000)]
    public string? MCREmail { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MCRPaymAmount { get; set; }

    [StringLength(2000)]
    public string? numberSequenceGroup { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OLAPCostValue { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OnAccountAmount { get; set; }

    [StringLength(2000)]
    public string? OneTimeCustomer { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    [StringLength(2000)]
    public string? PackerCode { get; set; }

    [StringLength(2000)]
    public string? PackerName { get; set; }

    [StringLength(2000)]
    public string? ParmId { get; set; }

    public long? Partition1 { get; set; }

    [StringLength(2000)]
    public string? PaymDayId { get; set; }

    [StringLength(2000)]
    public string? Payment { get; set; }

    [StringLength(2000)]
    public string? PaymentSched { get; set; }

    [StringLength(2000)]
    public string? PaymId { get; set; }

    [StringLength(2000)]
    public string? PORefID { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? Prepayment { get; set; }

    public int? PrintedOriginals { get; set; }

    [StringLength(2000)]
    public string? PrintMgmtSiteId { get; set; }

    [StringLength(2000)]
    public string? Proforma { get; set; }

    [StringLength(2000)]
    public string? ProvisionalAssessment_IN { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrder { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Qty { get; set; }

    [StringLength(2000)]
    public string? RCSalesList_UK { get; set; }

    public long? ReasonTableRef { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReceiptDateConfirmed_ES { get; set; }

    [StringLength(2000)]
    public string? ReturnItemNum { get; set; }

    [StringLength(2000)]
    public string? ReturnReasonCodeId { get; set; }

    [StringLength(2000)]
    public string? ReturnStatus { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReverseCharge_UK { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReverseChargeAmount { get; set; }

    public long? ReversedRecId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SalesBalance { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SalesBalanceMST { get; set; }

    [StringLength(2000)]
    public string? SalesId { get; set; }

    [StringLength(2000)]
    public string? SalesOriginId { get; set; }

    [StringLength(2000)]
    public string? SalesType { get; set; }

    [StringLength(2000)]
    public string? SentElectronically { get; set; }

    [StringLength(2000)]
    public string? ShipCarrierBlindShipment { get; set; }

    public long? SourceDocumentHeader { get; set; }

    public long? SourceDocumentLine { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumLineDisc { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumLineDiscMST { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumMarkup { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumMarkupMST { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumTax { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SumTaxMST { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    [StringLength(2000)]
    public string? TaxInvoiceSalesId { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroup { get; set; }

    [StringLength(2000)]
    public string? TaxPrintOnInvoice { get; set; }

    [StringLength(2000)]
    public string? TaxSpecifyByLine { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TotalTaxAmount { get; set; }

    public long? TransportationDocument { get; set; }

    [StringLength(2000)]
    public string? Triangulation { get; set; }

    [StringLength(2000)]
    public string? Updated { get; set; }

    [StringLength(2000)]
    public string? VATNum { get; set; }

    [StringLength(2000)]
    public string? VehicleCode { get; set; }

    [StringLength(2000)]
    public string? VehicleTag { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Volume { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Weight { get; set; }

    public long? WorkerSalesTaker { get; set; }

    [StringLength(2000)]
    public string? ZipCode { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? OrderId { get; set; }
}
