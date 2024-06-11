using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetRegisterEntryLinesService
{
    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(DataAreaId), nameof(LineNumber), nameof(LegalEntityId), nameof(EntryNumber))]
    public abstract partial class BudgetRegisterEntryLinesBase  
    {
        [JsonProperty("@odata.etag")]
        public string ODataEtag { get; set; }

        // JSON Property: "dataAreaId"
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }

        // JSON Property: "LegalEntityId"
        [JsonProperty("LegalEntityId")]
        public string LegalEntityId { get; set; }

        // JSON Property: "EntryNumber"
        [JsonProperty("EntryNumber")]
        public string EntryNumber { get; set; }

        // JSON Property: "LineNumber"
        [JsonProperty("LineNumber")]
        public int LineNumber { get; set; }

        // JSON Property: "WorkflowStatus"
        [JsonProperty("WorkflowStatus")]
        public string WorkflowStatus { get; set; }

        // JSON Property: "BudgetCheckResult"
        [JsonProperty("BudgetCheckResult")]
        public string BudgetCheckResult { get; set; }

        // JSON Property: "AccountingCurrencyAmount"
        [JsonProperty("AccountingCurrencyAmount")]
        public decimal AccountingCurrencyAmount { get; set; }

        // JSON Property: "DimensionAccountStructure"
        [JsonProperty("DimensionAccountStructure")]
        public string DimensionAccountStructure { get; set; }

        // JSON Property: "CurrencyCode"
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        // JSON Property: "Price"
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        // JSON Property: "TransactionCurrencyAmount"
        [JsonProperty("TransactionCurrencyAmount")]
        public decimal TransactionCurrencyAmount { get; set; }

        // JSON Property: "DimensionDisplayValue"
        [JsonProperty("DimensionDisplayValue")]
        public string DimensionDisplayValue { get; set; }

        // JSON Property: "Comment"
        [JsonProperty("Comment")]
        public string Comment { get; set; }

        // JSON Property: "EntryDate"
        [JsonProperty("EntryDate")]
        public DateTime EntryDate { get; set; }

        // JSON Property: "Quantity"
        [JsonProperty("Quantity")]
        public decimal Quantity { get; set; }

        // JSON Property: "IncludeInCashFlowForecast"
        [JsonProperty("IncludeInCashFlowForecast")]
        public string IncludeInCashFlowForecast { get; set; }

        // JSON Property: "AmountType"
        [JsonProperty("AmountType")]
        public string AmountType { get; set; }

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string ModifiedBy1 { get; set; }

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime ModifiedDateTime1 { get; set; }
    }
    
    public partial class BudgetRegisterEntryLinesBase
    {
        public static BudgetRegisterEntryLinesBase FromJson(string json) => JsonConvert.DeserializeObject<BudgetRegisterEntryLinesBase>(json, Converter.Settings);
    }

    public class BudgetRegisterEntryLines : BudgetRegisterEntryLinesBase { }

    public class BudgetRegisterEntryLinesTestR : BudgetRegisterEntryLinesBase { }
}

