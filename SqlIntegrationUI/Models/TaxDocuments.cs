using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("CustVendTransTableId", "dataAreaId", "TaxDocumentNumber")]
public partial class TaxDocuments
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public int CustVendTransTableId { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string TaxDocumentNumber { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Amount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AmountInTransactionCurrency { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxAmountInCurrency { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TaxCreditMemoDate { get; set; }

    [StringLength(2000)]
    public string? TaxCreditMemoNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxCreditMemoTransactionAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxCreditMemoTransactionAmountInTransactionCurrency { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxCreditMemoTransactionTaxAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxCreditMemoTransactionTaxAmountInCurrency { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxCreditMemoTransactionTaxValue { get; set; }

    [StringLength(2000)]
    public string? TaxCreditMemoTransactionTypeOfTax { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TaxDocumentDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxDocumentTransactionAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxDocumentTransactionAmountInTransactionCurrency { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxDocumentTransactionTaxAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxDocumentTransactionTaxAmountInCurrency { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxDocumentTransactionTaxValue { get; set; }

    [StringLength(2000)]
    public string? TaxDocumentTransactionTypeOfTax { get; set; }
}
