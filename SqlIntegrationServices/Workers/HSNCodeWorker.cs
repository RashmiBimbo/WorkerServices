using CommonCode.Config;
using Newtonsoft.Json.Linq;
using static System.DateTime;

namespace SqlIntegrationServices
{
    //internal class HSNCodesWorker(IServiceScopeFactory serviceScopeFactory, ILogger<BaseWorker> logger, ServiceDetails config) : BaseWorker(serviceScopeFactory, logger, config)
    ////{
    ////    protected override async Task<List<long>> JsonToDbChild(JArray Items, string tableName)
    ////    {
    ////        if (ServiceConfig.Table.Contains("Test", StringComparison.OrdinalIgnoreCase))
    ////        {
    ////            return await UpdateTbl<SqlIntegrationServices.HSNCodesTest>(Items);
    ////        }
    ////        else
    ////        {
    ////            return await UpdateTbl<SqlIntegrationServices.HSNCodes>(Items);
    ////        }
    ////    }

    ////    private async Task<List<long>> UpdateTblHSNCodes(JArray Items)
    ////    {
    ////        long addCnt = 0, updtCnt = 0;
    ////        foreach (var itm in Items)
    ////        {
    ////            string itmJsn;
    ////            HSNCodes existingEntity = null;
    ////            for (int cnt = 1; cnt <= 2; cnt++)
    ////            {
    ////                try
    ////                {
    ////                    itmJsn = Serialize.ToJson(itm);
    ////                    HSNCodes poco = JsonConvert.DeserializeObject<HSNCodes>(itmJsn);
    ////                    if (poco is null) continue;

    ////                    // Find existing entity in the database
    ////                    if (cntxt.HSNCodes.Any())
    ////                        existingEntity = await cntxt.HSNCodes.AsNoTracking().FirstOrDefaultAsync(e => (e.Chapter == poco.Chapter) && (e.CountryExtension == poco.CountryExtension) && (e.DataAreaId == poco.DataAreaId) && (e.Heading == poco.Heading) && (e.StatisticalSuffix == poco.StatisticalSuffix) && (e.Subheading == poco.Subheading));

    ////                    // Check if the entity exists in the database
    ////                    if (cntxt.HSNCodes.Local.Count < 1 || !cntxt.HSNCodes.Local.Any(e => (e.Chapter == poco.Chapter) && (e.CountryExtension == poco.CountryExtension) && (e.DataAreaId == poco.DataAreaId) && (e.Heading == poco.Heading) && (e.StatisticalSuffix == poco.StatisticalSuffix) && (e.Subheading == poco.Subheading)))
    ////                    {
    ////                        HSNCodes ent = PrepareEntity(poco);

    ////                        if (existingEntity == null) // Add the new entity
    ////                        {
    ////                            cntxt.HSNCodes.Add(ent);
    ////                            addCnt++;
    ////                        }
    ////                        else // Update the existing entity if modified
    ////                        {
    ////                            if ((poco.ModifiedDateTime1 != null) && !(existingEntity.ModifiedDateTime1 != null) && (poco.ModifiedDateTime1 > existingEntity.ModifiedDateTime1))
    ////                            {
    ////                                cntxt.Entry(existingEntity).CurrentValues.SetValues(ent);
    ////                                updtCnt++;
    ////                            }
    ////                        }
    ////                    }
    ////                    break;
    ////                }
    ////                catch (Exception ex)
    ////                {
    ////                    LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex?.StackTrace}");
    ////                    if (cnt < 2)
    ////                        LogInfo($"{Now}: Saving entity failed. Retrying...");
    ////                    else
    ////                        throw;
    ////                }
    ////            }
    ////        }
    ////        return [addCnt, updtCnt];
    ////    }
    //}

}
