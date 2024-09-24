using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class SystemUsersBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string UserID { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountType { get; set; }

    [StringLength(2000)]
    public string? Alias { get; set; }

    public int? AutoLogOff { get; set; }

    [StringLength(2000)]
    public string? AutomaticUrlUpdate { get; set; }

    [StringLength(2000)]
    public string? Company { get; set; }

    [StringLength(2000)]
    public string? DefaultCountryRegion { get; set; }

    [StringLength(2000)]
    public string? Density { get; set; }

    [StringLength(2000)]
    public string? DocumentHandlingActive { get; set; }

    [StringLength(2000)]
    public string? Email { get; set; }

    [StringLength(2000)]
    public string? EmailProviderID { get; set; }

    public bool? Enabled { get; set; }

    public int? EventPollFrequency { get; set; }

    [StringLength(2000)]
    public string? EventPopUpDisplayWhen { get; set; }

    [StringLength(2000)]
    public string? EventPopUpLinkDestination { get; set; }

    [StringLength(2000)]
    public string? EventPopUps { get; set; }

    [StringLength(2000)]
    public string? EventWorkflowShowPopup { get; set; }

    public bool? ExternalUser { get; set; }

    [StringLength(2000)]
    public string? GlobalExcelExportFilePath { get; set; }

    public int? GlobalExcelExportMode { get; set; }

    public int? GlobalListPageLinkMode { get; set; }

    [StringLength(2000)]
    public string? Helplanguage { get; set; }

    public int? HomePageRefreshDuration { get; set; }

    [StringLength(2000)]
    public string? Language { get; set; }

    [StringLength(2000)]
    public string? MarkEmptyLinks { get; set; }

    [StringLength(2000)]
    public string? NetworkDomain { get; set; }

    [StringLength(2000)]
    public string? PersonName { get; set; }

    [StringLength(2000)]
    public string? PreferredCalendar { get; set; }

    [StringLength(2000)]
    public string? PreferredLocale { get; set; }

    [StringLength(2000)]
    public string? PreferredTimeZone { get; set; }

    [StringLength(2000)]
    public string? SendAlertAsEmailMessage { get; set; }

    [StringLength(2000)]
    public string? SendNotificationsInEmail { get; set; }

    [StringLength(2000)]
    public string? ShowAttachmentStatus { get; set; }

    [StringLength(2000)]
    public string? ShowNotificationsInTheMicrosoftDynamicsAX7Client { get; set; }

    [StringLength(2000)]
    public string? SqmEnabled { get; set; }

    [StringLength(36)]
    public string? SqmGUID { get; set; }

    [StringLength(2000)]
    public string? StartPage { get; set; }

    [StringLength(2000)]
    public string? Theme { get; set; }

    public bool? UserInfo_defaultPartition { get; set; }

    [StringLength(2000)]
    public string? UserInfo_language { get; set; }

    [StringLength(2000)]
    public string? UserName { get; set; }

    [StringLength(2000)]
    public string? WorkflowLineItemNotificationFormat { get; set; }

    [StringLength(2000)]
    public string? EventWorkflowTasksInActionCenter { get; set; }
}

public partial class SystemUsersTest : SystemUsersBase { }

public partial class SystemUsers : SystemUsersBase { }
