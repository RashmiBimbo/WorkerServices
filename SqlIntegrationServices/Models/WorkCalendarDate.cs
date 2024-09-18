using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CalendarId", "dataAreaId", "TransDate")]
public abstract partial class WorkCalendarDateBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CalendarId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [StringLength(2000)]
    public string? ClosedForPickup { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? WorkTimeControl { get; set; }

    [StringLength(2000)]
    public string? BaseWorkCalendarId { get; set; }

    [StringLength(2000)]
    public string? CalendarName { get; set; }

    public int? DefaultEndingTime { get; set; }

    public int? DefaultStartingTime { get; set; }

    [StringLength(2000)]
    public string? IsFridayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsMondayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsSaturdayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsSundayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsThursdayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsTuesdayWorkingDay { get; set; }

    [StringLength(2000)]
    public string? IsWednesdayWorkingDay { get; set; }

    [StringLength(255)]
    public string? WorkCalendarHolidayId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? WorkHours { get; set; }
}

public partial class WorkCalendarDateTest : WorkCalendarDateBase { }

public partial class WorkCalendarDate : WorkCalendarDateBase { }
