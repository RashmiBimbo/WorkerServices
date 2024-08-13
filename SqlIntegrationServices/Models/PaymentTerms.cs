using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "Name")]
public abstract partial class PaymentTermsBase
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
    public string Name { get; set; } = null!;

    public int? AdditionalMonthsForCutoffDate { get; set; }

    [StringLength(2000)]
    public string? CashPaymentMainAccountIdDisplayValue { get; set; }

    [StringLength(2000)]
    public string? CreditCardCreditCheckType { get; set; }

    [StringLength(2000)]
    public string? CreditCardPaymentType { get; set; }

    [StringLength(2000)]
    public string? CustomerDueDateUpdatePolicy { get; set; }

    public int? CutoffDayOfMonth { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? IsCashPayment { get; set; }

    [StringLength(2000)]
    public string? IsCertifiedCompanyCheck { get; set; }

    [StringLength(2000)]
    public string? IsDefaultPaymentTerm { get; set; }

    public int? NumberOfDays { get; set; }

    public int? NumberOfMonths { get; set; }

    [StringLength(255)]
    public string? PaymentDayName { get; set; }

    [StringLength(2000)]
    public string? PaymentMethodType { get; set; }

    [StringLength(255)]
    public string? PaymentScheduleName { get; set; }

    [StringLength(2000)]
    public string? PostOffsettingAR { get; set; }

    [StringLength(2000)]
    public string? VendorDueDateUpdatePolicy { get; set; }
}

public partial class PaymentTermsTest : PaymentTermsBase {}

public partial class PaymentTerms : PaymentTermsBase {}
