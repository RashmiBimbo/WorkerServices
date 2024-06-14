
namespace SubledgerVoucherGeneralJournalEntryEntitiesService
{
    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(Voucher), nameof(RecId1))]
    public abstract partial class SubledgerVoucherGeneralJournalEntryEntitiesBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "Voucher"
        [JsonProperty("Voucher")]
        public string Voucher { get; set; } // Non-nullable key property

        // JSON Property: "RecId1"
        [JsonProperty("RecId1")]
        public long RecId1 { get; set; } // Non-nullable key property

        // JSON Property: "GeneralJournalEntry"
        [JsonProperty("GeneralJournalEntry")]
        public long? GeneralJournalEntry { get; set; } // Nullable long

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "TransferId"
        [JsonProperty("TransferId")]
        public long? TransferId { get; set; } // Nullable long

        // JSON Property: "RecVersion1"
        [JsonProperty("RecVersion1")]
        public long? RecVersion1 { get; set; } // Nullable long

        // JSON Property: "SubledgerJournalEntry"
        [JsonProperty("SubledgerJournalEntry")]
        public long? SubledgerJournalEntry { get; set; } // Nullable long

        // JSON Property: "VoucherDataAreaId"
        [JsonProperty("VoucherDataAreaId")]
        public string? VoucherDataAreaId { get; set; } // Non-nullable key property

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime

        // JSON Property: "AccountingDate"
        [JsonProperty("AccountingDate")]
        public DateTime? AccountingDate { get; set; } // Nullable DateTime

        // JSON Property: "Partition1"
        [JsonProperty("Partition1")]
        public long? Partition1 { get; set; } // Nullable long
    }

public partial class SubledgerVoucherGeneralJournalEntryEntitiesBase
{
    public static SubledgerVoucherGeneralJournalEntryEntitiesBase FromJson(string json) => JsonConvert.DeserializeObject<SubledgerVoucherGeneralJournalEntryEntitiesBase>(json, Converter.Settings);
}

public class SubledgerVoucherGeneralJournalEntryEntities : SubledgerVoucherGeneralJournalEntryEntitiesBase { }

public class SubledgerVoucherGeneralJournalEntryEntitiesTestR : SubledgerVoucherGeneralJournalEntryEntitiesBase { }
}

