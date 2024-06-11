using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace BudgetModelService
{
    // Composite key defined using the [PrimaryKey] attribute (EF Core 7+)
    [PrimaryKey(nameof(BudgetModel), nameof(DataAreaId))]
    public class BudgetModelPoco
    {
        // Optional fields (nullable in the database)
        [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [JsonProperty("parentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParentReference { get; set; }

        [JsonProperty("cashFlowForecasts", NullValueHandling = NullValueHandling.Ignore)]
        public string? CashFlowForecasts { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("stopped", NullValueHandling = NullValueHandling.Ignore)]
        public string? Stopped { get; set; }

        // Non-nullable fields (required in the database)
        [JsonProperty("BudgetModel")]
        public string BudgetModel { get; set; }

        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }
    }

    public class BudgetModel : BudgetModelPoco { }

    public class BudgetModelTestR : BudgetModelPoco { }
}
