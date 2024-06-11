using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace BudgetRegisterEntryHeadersService
{

    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(DataAreaId), nameof(EntryNumber), nameof(LegalEntityId))]
    public class BudgetRegisterEntryHeadersPoco
    { 
        // JSON Property: "@odata.etag"
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

        // JSON Property: "ReasonCode"
        [JsonProperty("ReasonCode")]
        public string ReasonCode { get; set; }

        // JSON Property: "BudgetCode"
        [JsonProperty("BudgetCode")]
        public string BudgetCode { get; set; }

        // JSON Property: "Status"
        [JsonProperty("Status")]
        public string Status { get; set; }

        // JSON Property: "WorkflowStatus"
        [JsonProperty("WorkflowStatus")]
        public string WorkflowStatus { get; set; }

        // JSON Property: "BudgetType"
        [JsonProperty("BudgetType")]
        public string BudgetType { get; set; }

        // JSON Property: "RevenueBudgetTotal"
        [JsonProperty("RevenueBudgetTotal")]
        public decimal RevenueBudgetTotal { get; set; }

        // JSON Property: "DefaultDate"
        [JsonProperty("DefaultDate")]
        public DateTime DefaultDate { get; set; }

        // JSON Property: "BudgetModelId"
        [JsonProperty("BudgetModelId")]
        public string BudgetModelId { get; set; }

        // JSON Property: "SourceDocument"
        [JsonProperty("SourceDocument")]
        public string SourceDocument { get; set; }

        // JSON Property: "ReasonComment"
        [JsonProperty("ReasonComment")]
        public string ReasonComment { get; set; }

        // JSON Property: "ExpenseBudgetTotal"
        [JsonProperty("ExpenseBudgetTotal")]
        public decimal ExpenseBudgetTotal { get; set; }

        // JSON Property: "OneTimeRevision"
        [JsonProperty("OneTimeRevision")]
        public string OneTimeRevision { get; set; }

        // JSON Property: "ProductTypes"
        [JsonProperty("ProductTypes")]
        public string ProductTypes { get; set; }

        // JSON Property: "BudgetClassifications"
        [JsonProperty("BudgetClassifications")]
        public string BudgetClassifications { get; set; }

        // JSON Property: "Budgetmaincategory"
        [JsonProperty("Budgetmaincategory")]
        public string Budgetmaincategory { get; set; }

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string ModifiedBy1 { get; set; }

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime ModifiedDateTime1 { get; set; }
    }

    public class BudgetRegisterEntryHeaders : BudgetRegisterEntryHeadersPoco { }

    public class BudgetRegisterEntryHeadersTestR : BudgetRegisterEntryHeadersPoco { }
}
