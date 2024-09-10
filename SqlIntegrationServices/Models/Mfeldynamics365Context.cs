using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public partial class MFELDynamics365Context : DbContext
{
    public MFELDynamics365Context()
    {
    }

    public MFELDynamics365Context(DbContextOptions<MFELDynamics365Context> options)
        : base(options)
    {
    }


    public virtual DbSet<Accountants> Accountants { get; set; }


    public virtual DbSet<AddressStates> AddressStates { get; set; }


    public virtual DbSet<AgreementLineReleasedLines> AgreementLineReleasedLines { get; set; }


    public virtual DbSet<AgreementLineReleasedLinesTest> AgreementLineReleasedLinesTest { get; set; }


    public virtual DbSet<AllProducts> AllProducts { get; set; }


    public virtual DbSet<AllProductsTest> AllProductsTest { get; set; }


    public virtual DbSet<BillOfMaterialsLinesV2> BillOfMaterialsLinesV2 { get; set; }


    public virtual DbSet<BillOfMaterialsLinesV2Test> BillOfMaterialsLinesV2Test { get; set; }


    public virtual DbSet<BillOfMaterialsVersionsV2> BillOfMaterialsVersionsV2 { get; set; }


    public virtual DbSet<BudgetModel> BudgetModel { get; set; }


    public virtual DbSet<BudgetModels> BudgetModels { get; set; }


    public virtual DbSet<BudgetModelsTest> BudgetModelsTest { get; set; }


    public virtual DbSet<BudgetRegisterEntryHeaders> BudgetRegisterEntryHeaders { get; set; }


    public virtual DbSet<BudgetRegisterEntryHeadersTest> BudgetRegisterEntryHeadersTest { get; set; }


    public virtual DbSet<BudgetRegisterEntryLines> BudgetRegisterEntryLines { get; set; }


    public virtual DbSet<BudgetRegisterEntryLinesTest> BudgetRegisterEntryLinesTest { get; set; }


    public virtual DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }


    public virtual DbSet<Companies> Companies { get; set; }


    public virtual DbSet<Company> Company { get; set; }


    public virtual DbSet<CustInvoiceJour> CustInvoiceJour { get; set; }


    public virtual DbSet<CustInvoiceJourTest> CustInvoiceJourTest { get; set; }


    public virtual DbSet<CustInvoiceJour_1> CustInvoiceJour_1 { get; set; }


    public virtual DbSet<CustInvoiceTrans> CustInvoiceTrans { get; set; }


    public virtual DbSet<CustInvoiceTrans_1> CustInvoiceTrans_1 { get; set; }


    public virtual DbSet<CustTransBiEntities> CustTransBiEntities { get; set; }


    public virtual DbSet<CustomerItems> CustomerItems { get; set; }


    public virtual DbSet<CustomerItemsTest> CustomerItemsTest { get; set; }


    public virtual DbSet<CustomersV2> CustomersV2 { get; set; }


    public virtual DbSet<CustomersV3> CustomersV3 { get; set; }


    public virtual DbSet<DIRPARTYTABLELOCATION> DIRPARTYTABLELOCATION { get; set; }


    public virtual DbSet<DefaultDimensionViews> DefaultDimensionViews { get; set; }


    public virtual DbSet<DemandStagings> DemandStagings { get; set; }


    public virtual DbSet<DimensionAttributeValueCombinations> DimensionAttributeValueCombinations { get; set; }


    public virtual DbSet<DimensionAttributeValueCombinationsTest> DimensionAttributeValueCombinationsTest { get; set; }


    public virtual DbSet<DimensionAttributes> DimensionAttributes { get; set; }


    public virtual DbSet<DirPartyLocations> DirPartyLocations { get; set; }


    public virtual DbSet<DirPartyLocationsTest> DirPartyLocationsTest { get; set; }


    public virtual DbSet<DirPartyTables> DirPartyTables { get; set; }


    public virtual DbSet<DynamicsExport> DynamicsExport { get; set; }


    public virtual DbSet<EInvoiceDetails> EInvoiceDetails { get; set; }


    public virtual DbSet<EcoResProductTranslations> EcoResProductTranslations { get; set; }


    public virtual DbSet<EcoResProducts> EcoResProducts { get; set; }


    public virtual DbSet<Employees> Employees { get; set; }


    public virtual DbSet<Employees_1> Employees_1 { get; set; }


    public virtual DbSet<Employments> Employments { get; set; }


    public virtual DbSet<FinancialDimensionValues> FinancialDimensionValues { get; set; }


    public virtual DbSet<FinancialDimensionValuesTest> FinancialDimensionValuesTest { get; set; }


    public virtual DbSet<FormulaLineV3s> FormulaLineV3s { get; set; }


    public virtual DbSet<FormulaLineV3sTest> FormulaLineV3sTest { get; set; }


    public virtual DbSet<FormulaVersion2s> FormulaVersion2s { get; set; }


    public virtual DbSet<FormulaVersion2sTest> FormulaVersion2sTest { get; set; }


    public virtual DbSet<GeneralJournalAccountEntryV2Entities> GeneralJournalAccountEntryV2Entities { get; set; }


    public virtual DbSet<GeneralJournalAccountEntryV2Entities_T> GeneralJournalAccountEntryV2Entities_T { get; set; }


    public virtual DbSet<GeneralJournalEntryEntities> GeneralJournalEntryEntities { get; set; }


    public virtual DbSet<GeneralLedgerCustInvoiceJournalHeaders> GeneralLedgerCustInvoiceJournalHeaders { get; set; }


    public virtual DbSet<GeneralLedgerCustInvoiceJournalLines> GeneralLedgerCustInvoiceJournalLines { get; set; }


    public virtual DbSet<HCMEmployments> HCMEmployments { get; set; }


    public virtual DbSet<HCMWorkers> HCMWorkers { get; set; }


    public virtual DbSet<HGCustTransEntity> HGCustTransEntity { get; set; }


    public virtual DbSet<HGMRPCalculations> HGMRPCalculations { get; set; }


    public virtual DbSet<HGMRPDiscountCalculations> HGMRPDiscountCalculations { get; set; }


    public virtual DbSet<HGMRPDiscountMasters> HGMRPDiscountMasters { get; set; }


    public virtual DbSet<HGMRPMasters> HGMRPMasters { get; set; }


    public virtual DbSet<HGSalesInvoiceHeaders> HGSalesInvoiceHeaders { get; set; }


    public virtual DbSet<HGSalesInvoiceHeadersTest> HGSalesInvoiceHeadersTest { get; set; }


    public virtual DbSet<HGSalesInvoiceHeaders_1> HGSalesInvoiceHeaders_1 { get; set; }


    public virtual DbSet<HSNCodeTable_IN> HSNCodeTable_IN { get; set; }


    public virtual DbSet<HSNCodes> HSNCodes { get; set; }


    public virtual DbSet<HSNCodesTest> HSNCodesTest { get; set; }


    public virtual DbSet<IncentivePrices> IncentivePrices { get; set; }


    public virtual DbSet<InvIRNDataDatas> InvIRNDataDatas { get; set; }


    public virtual DbSet<InventDims> InventDims { get; set; }


    public virtual DbSet<InventDimsTest> InventDimsTest { get; set; }


    public virtual DbSet<InventItemGroupItem> InventItemGroupItem { get; set; }


    public virtual DbSet<InventItemGroupItems> InventItemGroupItems { get; set; }


    public virtual DbSet<InventItemGroupItemsTest> InventItemGroupItemsTest { get; set; }


    public virtual DbSet<InventItemSalesSetup> InventItemSalesSetup { get; set; }


    public virtual DbSet<InventItemSalesSetups> InventItemSalesSetups { get; set; }


    public virtual DbSet<InventItemSalesSetupsTest> InventItemSalesSetupsTest { get; set; }


    public virtual DbSet<InventJournalTransDataEntities> InventJournalTransDataEntities { get; set; }


    public virtual DbSet<InventJournalTransDataEntitiesTest> InventJournalTransDataEntitiesTest { get; set; }


    public virtual DbSet<InventTableModules> InventTableModules { get; set; }


    public virtual DbSet<InventTableModulesTest> InventTableModulesTest { get; set; }


    public virtual DbSet<InventTransEntities> InventTransEntities { get; set; }


    public virtual DbSet<InventTransEntities__r_204536460> InventTransEntities__r_204536460 { get; set; }


    public virtual DbSet<InventTransOrigins> InventTransOrigins { get; set; }


    public virtual DbSet<InventTransOriginsTest> InventTransOriginsTest { get; set; }


    public virtual DbSet<InventTransPostings> InventTransPostings { get; set; }


    public virtual DbSet<InventTransPostingsTest> InventTransPostingsTest { get; set; }


    public virtual DbSet<InventTransV2> InventTransV2 { get; set; }


    public virtual DbSet<InventTransferJourLines> InventTransferJourLines { get; set; }


    public virtual DbSet<InventTransferJours> InventTransferJours { get; set; }


    public virtual DbSet<InventoryMovementJournalEntries> InventoryMovementJournalEntries { get; set; }


    public virtual DbSet<InventoryMovementJournalEntriesTest> InventoryMovementJournalEntriesTest { get; set; }


    public virtual DbSet<InventoryMovementJournalHeaders> InventoryMovementJournalHeaders { get; set; }


    public virtual DbSet<InventoryMovementJournalHeadersTest> InventoryMovementJournalHeadersTest { get; set; }


    public virtual DbSet<InvoiceSubLinesV2> InvoiceSubLinesV2 { get; set; }


    public virtual DbSet<ItemCrateMappings> ItemCrateMappings { get; set; }


    public virtual DbSet<ItemSiteMappings> ItemSiteMappings { get; set; }


    public virtual DbSet<ItemWarehouseMappings> ItemWarehouseMappings { get; set; }


    public virtual DbSet<KPIStdDatas> KPIStdDatas { get; set; }


    public virtual DbSet<KPIStdDatasTest> KPIStdDatasTest { get; set; }


    public virtual DbSet<LineDiscountCustomerGroups> LineDiscountCustomerGroups { get; set; }


    public virtual DbSet<LineDiscountCustomerGroupsTest> LineDiscountCustomerGroupsTest { get; set; }


    public virtual DbSet<LogisticsAddressCountryRegion> LogisticsAddressCountryRegion { get; set; }


    public virtual DbSet<LogisticsAddressStates> LogisticsAddressStates { get; set; }


    public virtual DbSet<LogisticsLocation> LogisticsLocation { get; set; }


    public virtual DbSet<LogisticsLocations> LogisticsLocations { get; set; }


    public virtual DbSet<LogisticsPostalAddress> LogisticsPostalAddress { get; set; }


    public virtual DbSet<LogisticsPostalAddresss> LogisticsPostalAddresss { get; set; }


    public virtual DbSet<LogisticsPostalAddresss_3> LogisticsPostalAddresss_3 { get; set; }


    public virtual DbSet<MTRouteMasters> MTRouteMasters { get; set; }


    public virtual DbSet<MainAccountCategories> MainAccountCategories { get; set; }


    public virtual DbSet<MainAccounts> MainAccounts { get; set; }


    public virtual DbSet<MainAccountsTest> MainAccountsTest { get; set; }


    public virtual DbSet<MainAccounts_1> MainAccounts_1 { get; set; }


    public virtual DbSet<MarkupTransTransTaxInformations> MarkupTransTransTaxInformations { get; set; }


    public virtual DbSet<MarkupTransTransTaxInformations_1> MarkupTransTransTaxInformations_1 { get; set; }


    public virtual DbSet<OvenPngMaintEntities> OvenPngMaintEntities { get; set; }


    public virtual DbSet<OvenPngMaintenanceTables> OvenPngMaintenanceTables { get; set; }


    public virtual DbSet<OvenPngMaintenanceTablesTest> OvenPngMaintenanceTablesTest { get; set; }


    public virtual DbSet<OvenPngProdTables> OvenPngProdTables { get; set; }


    public virtual DbSet<OvenPngProdTablesTest> OvenPngProdTablesTest { get; set; }


    public virtual DbSet<OvenPngProdTables_1> OvenPngProdTables_1 { get; set; }


    public virtual DbSet<OvenPngProdTables_2> OvenPngProdTables_2 { get; set; }


    public virtual DbSet<PartyLocationPostalAddressesV2> PartyLocationPostalAddressesV2 { get; set; }


    public virtual DbSet<PartyLocationPostalAddressesV2Test> PartyLocationPostalAddressesV2Test { get; set; }


    public virtual DbSet<PartyLocationPostalAddressesV2_1> PartyLocationPostalAddressesV2_1 { get; set; }


    public virtual DbSet<PaymentTerms> PaymentTerms { get; set; }


    public virtual DbSet<PaymentTermsTest> PaymentTermsTest { get; set; }


    public virtual DbSet<PoweConsumptions> PoweConsumptions { get; set; }


    public virtual DbSet<PoweConsumptionsTest> PoweConsumptionsTest { get; set; }


    public virtual DbSet<PoweConsumptions_1> PoweConsumptions_1 { get; set; }


    public virtual DbSet<PriceCustomerGroups> PriceCustomerGroups { get; set; }


    public virtual DbSet<PriceCustomerGroupsTest> PriceCustomerGroupsTest { get; set; }


    public virtual DbSet<PriceDiscTable> PriceDiscTable { get; set; }


    public virtual DbSet<PriceDiscTables> PriceDiscTables { get; set; }


    public virtual DbSet<ProdCalcTranss> ProdCalcTranss { get; set; }


    public virtual DbSet<ProdCalcTranssTest> ProdCalcTranssTest { get; set; }


    public virtual DbSet<ProdCalcTranss_1> ProdCalcTranss_1 { get; set; }


    public virtual DbSet<ProdCratess> ProdCratess { get; set; }


    public virtual DbSet<ProdDieselStds> ProdDieselStds { get; set; }


    public virtual DbSet<ProdDieselStdsTest> ProdDieselStdsTest { get; set; }


    public virtual DbSet<ProdErrorQties> ProdErrorQties { get; set; }


    public virtual DbSet<ProdErrorQtiesTest> ProdErrorQtiesTest { get; set; }


    public virtual DbSet<ProdManpowerMasterEntities> ProdManpowerMasterEntities { get; set; }


    public virtual DbSet<ProdManpowerMasterEntitiesTest> ProdManpowerMasterEntitiesTest { get; set; }


    public virtual DbSet<ProdManpowerMasters> ProdManpowerMasters { get; set; }


    public virtual DbSet<ProdManpowerMastersTest> ProdManpowerMastersTest { get; set; }


    public virtual DbSet<ProdManpowerTranss> ProdManpowerTranss { get; set; }


    public virtual DbSet<ProdManpowerTranssTest> ProdManpowerTranssTest { get; set; }


    public virtual DbSet<ProdOvenTypes> ProdOvenTypes { get; set; }


    public virtual DbSet<ProdOvenTypesTest> ProdOvenTypesTest { get; set; }


    public virtual DbSet<ProdTableDataEntities> ProdTableDataEntities { get; set; }


    public virtual DbSet<ProdTableDataEntitiesTest> ProdTableDataEntitiesTest { get; set; }


    public virtual DbSet<ProdTableEntities> ProdTableEntities { get; set; }


    public virtual DbSet<ProdTableEntitiesTest> ProdTableEntitiesTest { get; set; }


    public virtual DbSet<ProdWastageAnalysiss> ProdWastageAnalysiss { get; set; }


    public virtual DbSet<ProdWastageAnalysissTest> ProdWastageAnalysissTest { get; set; }


    public virtual DbSet<ProdWastageCrumbs> ProdWastageCrumbs { get; set; }


    public virtual DbSet<ProdWastageCrumbsTest> ProdWastageCrumbsTest { get; set; }


    public virtual DbSet<ProductCategories> ProductCategories { get; set; }


    public virtual DbSet<ProductCategory> ProductCategory { get; set; }


    public virtual DbSet<ProductCategoryAssignments> ProductCategoryAssignments { get; set; }


    public virtual DbSet<ProductCategoryAssignmentsTest> ProductCategoryAssignmentsTest { get; set; }


    public virtual DbSet<ProductReceiptHeaders> ProductReceiptHeaders { get; set; }


    public virtual DbSet<ProductReceiptHeadersTest> ProductReceiptHeadersTest { get; set; }


    public virtual DbSet<ProductReceiptLines> ProductReceiptLines { get; set; }


    public virtual DbSet<ProductReceiptLinesTest> ProductReceiptLinesTest { get; set; }


    public virtual DbSet<ProductSpecificUnitOfMeasureConversions> ProductSpecificUnitOfMeasureConversions { get; set; }


    public virtual DbSet<ProductTranslations> ProductTranslations { get; set; }


    public virtual DbSet<ProductTranslationsTest> ProductTranslationsTest { get; set; }


    public virtual DbSet<ProductUnitOfMeasureConversions> ProductUnitOfMeasureConversions { get; set; }


    public virtual DbSet<ProductUnitOfMeasureConversionsTest> ProductUnitOfMeasureConversionsTest { get; set; }


    public virtual DbSet<ProductionOrderBillOfMaterialLines> ProductionOrderBillOfMaterialLines { get; set; }


    public virtual DbSet<ProductionOrderBillOfMaterialLinesTest> ProductionOrderBillOfMaterialLinesTest { get; set; }


    public virtual DbSet<ProductionOrderHeaders> ProductionOrderHeaders { get; set; }


    public virtual DbSet<ProductionOrderHeadersTest> ProductionOrderHeadersTest { get; set; }


    public virtual DbSet<ProductionOrderRouteOperations> ProductionOrderRouteOperations { get; set; }


    public virtual DbSet<ProductionOrderRouteOperationsTest> ProductionOrderRouteOperationsTest { get; set; }


    public virtual DbSet<ProductionRouteTransactions> ProductionRouteTransactions { get; set; }


    public virtual DbSet<ProductionRouteTransactionsTest> ProductionRouteTransactionsTest { get; set; }


    public virtual DbSet<ProductsV2> ProductsV2 { get; set; }


    public virtual DbSet<PurchaseAgreementLinesV2> PurchaseAgreementLinesV2 { get; set; }


    public virtual DbSet<PurchaseAgreementLinesV2Test> PurchaseAgreementLinesV2Test { get; set; }


    public virtual DbSet<PurchaseAgreements> PurchaseAgreements { get; set; }


    public virtual DbSet<PurchaseAgreementsTest> PurchaseAgreementsTest { get; set; }


    public virtual DbSet<PurchaseOrderHeadersV2> PurchaseOrderHeadersV2 { get; set; }


    public virtual DbSet<PurchaseOrderHeadersV2Test> PurchaseOrderHeadersV2Test { get; set; }


    public virtual DbSet<PurchaseOrderLinesV2> PurchaseOrderLinesV2 { get; set; }


    public virtual DbSet<PurchaseOrderLinesV2Test> PurchaseOrderLinesV2Test { get; set; }


    public virtual DbSet<QualityOrderHeaders> QualityOrderHeaders { get; set; }


    public virtual DbSet<QualityOrderHeadersTest> QualityOrderHeadersTest { get; set; }


    public virtual DbSet<QualityOrderLineResults> QualityOrderLineResults { get; set; }


    public virtual DbSet<QualityOrderLineResultsTest> QualityOrderLineResultsTest { get; set; }


    public virtual DbSet<ReleasedProductMastersV2> ReleasedProductMastersV2 { get; set; }


    public virtual DbSet<ReleasedProductsV2> ReleasedProductsV2 { get; set; }


    public virtual DbSet<ReqTransFirmLogs> ReqTransFirmLogs { get; set; }


    public virtual DbSet<ReqTransFirmLogsTest> ReqTransFirmLogsTest { get; set; }


    public virtual DbSet<ReturnReasonCode> ReturnReasonCode { get; set; }


    public virtual DbSet<SalesDemandStagings> SalesDemandStagings { get; set; }


    public virtual DbSet<SalesInvoiceHeaders> SalesInvoiceHeaders { get; set; }


    public virtual DbSet<SalesInvoiceHeadersTest> SalesInvoiceHeadersTest { get; set; }


    public virtual DbSet<SalesInvoiceHeadersV2> SalesInvoiceHeadersV2 { get; set; }


    public virtual DbSet<SalesInvoiceHeadersV2Test> SalesInvoiceHeadersV2Test { get; set; }


    public virtual DbSet<SalesInvoiceLines> SalesInvoiceLines { get; set; }


    public virtual DbSet<SalesInvoiceLinesTest> SalesInvoiceLinesTest { get; set; }


    public virtual DbSet<SalesInvoiceV2Lines> SalesInvoiceV2Lines { get; set; }


    public virtual DbSet<SalesOrderHeaders> SalesOrderHeaders { get; set; }


    public virtual DbSet<Site> Site { get; set; }


    public virtual DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; }


    public virtual DbSet<SubledgerVoucherGeneralJournalEntryEntitiesTest> SubledgerVoucherGeneralJournalEntryEntitiesTest { get; set; }


    public virtual DbSet<SuppItems> SuppItems { get; set; }


    public virtual DbSet<SyncTable> SyncTable { get; set; }


    public virtual DbSet<SystemUsers> SystemUsers { get; set; }


    public virtual DbSet<TCustomers> TCustomers { get; set; }


    public virtual DbSet<TaxDocuments> TaxDocuments { get; set; }


    public virtual DbSet<TaxDocumentsTest> TaxDocumentsTest { get; set; }


    public virtual DbSet<TaxInfoManagement> TaxInfoManagement { get; set; }


    public virtual DbSet<TaxInformationCustTable_IN> TaxInformationCustTable_IN { get; set; }


    public virtual DbSet<TaxInformationCustTable_INDs> TaxInformationCustTable_INDs { get; set; }


    public virtual DbSet<TaxRegistrationNumbers_INDs> TaxRegistrationNumbers_INDs { get; set; }


    public virtual DbSet<TaxTransInDataEntity> TaxTransInDataEntity { get; set; }


    public virtual DbSet<TaxTransInDataEntity_1> TaxTransInDataEntity_1 { get; set; }


    public virtual DbSet<TaxTranss> TaxTranss { get; set; }


    public virtual DbSet<TaxTranss_1> TaxTranss_1 { get; set; }


    public virtual DbSet<TaxTranss_D> TaxTranss_D { get; set; }


    public virtual DbSet<TaxWithholdTrans> TaxWithholdTrans { get; set; }


    public virtual DbSet<TestCertOfAnalysisTables> TestCertOfAnalysisTables { get; set; }


    public virtual DbSet<TestCertOfAnalysisTablesTest> TestCertOfAnalysisTablesTest { get; set; }


    public virtual DbSet<TransOriginsV2> TransOriginsV2 { get; set; }


    public virtual DbSet<TransPostings> TransPostings { get; set; }


    public virtual DbSet<TransferJourLines> TransferJourLines { get; set; }


    public virtual DbSet<TransferJours> TransferJours { get; set; }


    public virtual DbSet<TransferOrderHeaders> TransferOrderHeaders { get; set; }


    public virtual DbSet<TransferOrderLines> TransferOrderLines { get; set; }


    public virtual DbSet<UnitOfMeasureConversions> UnitOfMeasureConversions { get; set; }


    public virtual DbSet<UnitOfMeasureConversionsTest> UnitOfMeasureConversionsTest { get; set; }


    public virtual DbSet<UnitsOfMeasure> UnitsOfMeasure { get; set; }


    public virtual DbSet<UnitsOfMeasureTest> UnitsOfMeasureTest { get; set; }


    public virtual DbSet<VehicleCodeMaster> VehicleCodeMaster { get; set; }


    public virtual DbSet<VehicleCodeMasters> VehicleCodeMasters { get; set; }


    public virtual DbSet<VehicleTagMaster> VehicleTagMaster { get; set; }


    public virtual DbSet<VehicleTagMasters> VehicleTagMasters { get; set; }


    public virtual DbSet<VendInvoiceInfoDataEntity> VendInvoiceInfoDataEntity { get; set; }


    public virtual DbSet<VendInvoiceJournalDatasEntity> VendInvoiceJournalDatasEntity { get; set; }


    public virtual DbSet<VendInvoiceJournalDatasEntityTest> VendInvoiceJournalDatasEntityTest { get; set; }


    public virtual DbSet<VendInvoiceJournalHeaders> VendInvoiceJournalHeaders { get; set; }


    public virtual DbSet<VendInvoiceJournalLines> VendInvoiceJournalLines { get; set; }


    public virtual DbSet<VendPackingSlipJourDatasEntity> VendPackingSlipJourDatasEntity { get; set; }


    public virtual DbSet<VendPackingSlipJourDatasEntityTest> VendPackingSlipJourDatasEntityTest { get; set; }


    public virtual DbSet<VendPackingSlipTransDatasEntity> VendPackingSlipTransDatasEntity { get; set; }


    public virtual DbSet<VendPackingSlipTransDatasEntityTest> VendPackingSlipTransDatasEntityTest { get; set; }


    public virtual DbSet<VendPaymModeBankAccounts> VendPaymModeBankAccounts { get; set; }


    public virtual DbSet<VendPaymModeBankAccountsTest> VendPaymModeBankAccountsTest { get; set; }


    public virtual DbSet<VendTransDatasEntity> VendTransDatasEntity { get; set; }


    public virtual DbSet<VendTransDatasEntityTest> VendTransDatasEntityTest { get; set; }


    public virtual DbSet<VendorBankAccounts> VendorBankAccounts { get; set; }


    public virtual DbSet<VendorBankAccountsTest> VendorBankAccountsTest { get; set; }


    public virtual DbSet<VendorInvoiceHeaders> VendorInvoiceHeaders { get; set; }


    public virtual DbSet<VendorInvoiceHeadersTest> VendorInvoiceHeadersTest { get; set; }


    public virtual DbSet<VendorInvoiceLines> VendorInvoiceLines { get; set; }


    public virtual DbSet<VendorInvoiceLinesTest> VendorInvoiceLinesTest { get; set; }


    public virtual DbSet<VendorInvoiceTransDatasEntity> VendorInvoiceTransDatasEntity { get; set; }


    public virtual DbSet<VendorInvoiceTransDatasEntityTest> VendorInvoiceTransDatasEntityTest { get; set; }


    public virtual DbSet<VendorsV2> VendorsV2 { get; set; }


    public virtual DbSet<Warehouses> Warehouses { get; set; }


    public virtual DbSet<Warehouses_1> Warehouses_1 { get; set; }


    public virtual DbSet<WorkCalendarDate> WorkCalendarDate { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MFELConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accountants>(entity =>
        {
            entity.HasKey(e => new { e.CPF, e.CRC }).HasName("PK__Accounta__9DE71F4F7A98F9FE");
        });

        modelBuilder.Entity<AddressStates>(entity =>
        {
            entity.HasKey(e => new { e.CountryRegionId, e.State }).HasName("PK__AddressS__2E40C63449056F54");
        });

        modelBuilder.Entity<AgreementLineReleasedLines>(entity =>
        {
            entity.HasKey(e => new { e.AgreementLine, e.CustInvoiceTrans, e.ProjInvoiceItem, e.PurchLineDataAreaId, e.PurchLineInventTransId, e.SalesLineDataAreaId, e.SalesLineInventTransId, e.VendInvoiceTrans }).HasName("PK__Agreemen__EA724F76280DFD0F");
        });

        modelBuilder.Entity<AllProducts>(entity =>
        {
            entity.HasKey(e => e.ProductNumber).HasName("PK__AllProdu__49A3C83874B23797");
        });

        modelBuilder.Entity<BillOfMaterialsLinesV2>(entity =>
        {
            entity.HasKey(e => new { e.BOMId, e.dataAreaId, e.LineCreationSequenceNumber }).HasName("PK__BillOfMa__3F0849EC9F8E6A44");
        });

        modelBuilder.Entity<BillOfMaterialsVersionsV2>(entity =>
        {
            entity.HasKey(e => new { e.BOMId, e.dataAreaId, e.FromQuantity, e.IsActive, e.ManufacturedItemNumber, e.ProductColorId, e.ProductConfigurationId, e.ProductionSiteId, e.ProductSizeId, e.ProductStyleId, e.ValidFromDate }).HasName("PK__BillOfMa__804B17717892E227");
        });

        modelBuilder.Entity<BudgetModels>(entity =>
        {
            entity.HasKey(e => new { e.BudgetModel, e.dataAreaId }).HasName("PK__BudgetMo__D4BAF4954D4E1BAD");
        });

        modelBuilder.Entity<BudgetRegisterEntryHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.EntryNumber, e.LegalEntityId }).HasName("PK__BudgetRe__9FF0A0EB53823221");
        });

        modelBuilder.Entity<BudgetRegisterEntryLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.EntryNumber, e.LegalEntityId, e.LineNumber }).HasName("PK__BudgetRe__EFB93F89C67682F8");
        });

        modelBuilder.Entity<ChartOfAccounts>(entity =>
        {
            entity.HasKey(e => e.ChartOfAccounts1).HasName("PK__ChartOfA__A1B246CF173BED24");
        });

        modelBuilder.Entity<Companies>(entity =>
        {
            entity.HasKey(e => e.DataArea).HasName("PK__Companie__97C966EA2C456F2B");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.LegalEntityId).HasName("PK__Company__5266B182B3E8086B");
        });

        modelBuilder.Entity<CustInvoiceTrans>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber, e.LedgerVoucher, e.LineCreationSequenceNumber }).HasName("PK__CustInvo__9E72CFB81F99EB30");
        });

        modelBuilder.Entity<CustInvoiceTrans_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber, e.LedgerVoucher, e.LineCreationSequenceNumber }).HasName("PK__CustInvo__9E72CFB8533FEBBA");
        });

        modelBuilder.Entity<CustTransBiEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.SourceKey }).HasName("PK__CustTran__1726F95B102F4B3B");
        });

        modelBuilder.Entity<CustomerItems>(entity =>
        {
            entity.HasKey(e => new { e.CustVendRelation, e.dataAreaId, e.FromDate, e.ItemId, e.ToDate }).HasName("PK__Customer__5C6B865B266305DB");
        });

        modelBuilder.Entity<CustomersV2>(entity =>
        {
            entity.HasKey(e => new { e.CustomerAccount, e.dataAreaId }).HasName("PK__Customer__FA1301346B7EAB00");
        });

        modelBuilder.Entity<CustomersV3>(entity =>
        {
            entity.HasKey(e => new { e.CustomerAccount, e.dataAreaId }).HasName("PK__Customer__FA130134E13F7D6C");
        });

        modelBuilder.Entity<DIRPARTYTABLELOCATION>(entity =>
        {
            entity.HasKey(e => new { e.LocationId, e.PartyNumber, e.ValidFrom }).HasName("PK__DIRPARTY__CB2758086655EE81");
        });

        modelBuilder.Entity<DefaultDimensionViews>(entity =>
        {
            entity.HasKey(e => new { e.DefaultDimension, e.DisplayValue }).HasName("PK__DefaultD__1DD8CC118BAFC1C9");
        });

        modelBuilder.Entity<DimensionAttributeValueCombinations>(entity =>
        {
            entity.HasKey(e => new { e.DisplayValue, e.RecId1 }).HasName("PK__Dimensio__E7EC353FFC9110C4");
        });

        modelBuilder.Entity<DimensionAttributes>(entity =>
        {
            entity.HasKey(e => e.DimensionName).HasName("PK__Dimensio__9DDFD088CAF39322");
        });

        modelBuilder.Entity<DirPartyLocations>(entity =>
        {
            entity.HasKey(e => new { e.DirPartyTable_FK_PartyNumber, e.LogisticsLocation_FK_LocationId }).HasName("PK__DirParty__CE90B26C63E57A22");
        });

        modelBuilder.Entity<DirPartyTables>(entity =>
        {
            entity.HasKey(e => e.PartyNumber).HasName("PK__DirParty__EEC324CE92677CF4");
        });

        modelBuilder.Entity<EInvoiceDetails>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceId, e.Irn }).HasName("PK__EInvoice__DD978F878BA69DF3");
        });

        modelBuilder.Entity<EcoResProductTranslations>(entity =>
        {
            entity.HasKey(e => new { e.LanguageId, e.ProductNumber }).HasName("PK__EcoResPr__2DA269289A0A5FFF");
        });

        modelBuilder.Entity<EcoResProducts>(entity =>
        {
            entity.HasKey(e => e.ProductNumber).HasName("PK__EcoResPr__49A3C838418285BC");
        });

        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => new { e.EmploymentEndDate, e.EmploymentLegalEntityId, e.EmploymentStartDate, e.PersonnelNumber }).HasName("PK__Employee__03046882D7BB72F2");
        });

        modelBuilder.Entity<Employees_1>(entity =>
        {
            entity.HasKey(e => new { e.EmploymentEndDate, e.EmploymentLegalEntityId, e.EmploymentStartDate, e.PersonnelNumber }).HasName("PK__Employee__030468823915EFF6");
        });

        modelBuilder.Entity<Employments>(entity =>
        {
            entity.HasKey(e => new { e.EmploymentEndDate, e.EmploymentStartDate, e.LegalEntityId, e.PersonnelNumber }).HasName("PK__Employme__02C62DCCE233935C");
        });

        modelBuilder.Entity<FinancialDimensionValues>(entity =>
        {
            entity.HasKey(e => new { e.DimensionValue, e.FinancialDimension, e.LegalEntityId }).HasName("PK__Financia__E9C0478C253C15C9");
        });

        modelBuilder.Entity<FormulaLineV3s>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.FormulaId, e.LineCreationSequenceNumber }).HasName("PK__FormulaL__819523E29F029FFD");
        });

        modelBuilder.Entity<FormulaVersion2s>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.FormulaId, e.IsActive, e.ProductionSiteId }).HasName("PK__FormulaV__CA95C516D9DD3DA6");
        });

        modelBuilder.Entity<GeneralJournalAccountEntryV2Entities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GeneralJournalAccountEntryRecId }).HasName("PK__GeneralJ__6B1114CCE806622B");
        });

        modelBuilder.Entity<GeneralJournalAccountEntryV2Entities_T>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GeneralJournalAccountEntryRecId }).HasName("PK__GeneralJ__6B1114CC1E2421A4");
        });

        modelBuilder.Entity<GeneralJournalEntryEntities>(entity =>
        {
            entity.HasKey(e => e.JournalNumber).HasName("PK__GeneralJ__B6972334655AEAE3");
        });

        modelBuilder.Entity<GeneralLedgerCustInvoiceJournalHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalBatchNumber }).HasName("PK__GeneralL__CEF678E935427480");
        });

        modelBuilder.Entity<GeneralLedgerCustInvoiceJournalLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalBatchNumber, e.LineNumber }).HasName("PK__GeneralL__CA6F8ECE1CEBB35F");
        });

        modelBuilder.Entity<HCMEmployments>(entity =>
        {
            entity.HasKey(e => new { e.EmploymentEndDate, e.EmploymentStartDate, e.LegalEntityId, e.PersonnelNumber }).HasName("PK__HCMEmplo__02C62DCC5A3E92C7");
        });

        modelBuilder.Entity<HCMWorkers>(entity =>
        {
            entity.HasKey(e => e.PersonnelNumber).HasName("PK__HCMWorke__EC6A9E5DD21A8AB2");
        });

        modelBuilder.Entity<HGSalesInvoiceHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceId }).HasName("PK__HGSalesI__5CBFCDA966F0B917");
        });

        modelBuilder.Entity<HGSalesInvoiceHeaders_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceId }).HasName("PK__HGSalesI__5CBFCDA9252914D0");
        });

        modelBuilder.Entity<HSNCodeTable_IN>(entity =>
        {
            entity.HasKey(e => new { e.Chapter, e.CountryExtension, e.dataAreaId, e.Heading, e.StatisticalSuffix, e.Subheading }).HasName("PK__HSNCodeT__FCA467AB7D891DCA");
        });

        modelBuilder.Entity<HSNCodes>(entity =>
        {
            entity.HasKey(e => new { e.Chapter, e.CountryExtension, e.dataAreaId, e.Heading, e.StatisticalSuffix, e.Subheading }).HasName("PK__HSNCodes__FCA467AB06D4269C");
        });

        modelBuilder.Entity<IncentivePrices>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.FromDate, e.ItemId, e.RouteCode, e.ToDate }).HasName("PK__Incentiv__F2932D14477A041C");
        });

        modelBuilder.Entity<InvIRNDataDatas>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__InvIRNDa__D796AAB5F0F7D646");
        });

        modelBuilder.Entity<InventDims>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.inventDimId }).HasName("PK__InventDi__B1CF935F1A562A4A");
        });

        modelBuilder.Entity<InventItemGroupItem>(entity =>
        {
            entity.HasKey(e => new { e.ItemDataAreaId, e.ItemId }).HasName("PK__InventIt__D47D130441049982");
        });

        modelBuilder.Entity<InventItemGroupItems>(entity =>
        {
            entity.HasKey(e => new { e.ItemDataAreaId, e.ItemId }).HasName("PK__InventIt__D47D1304CA41D6EF");
        });

        modelBuilder.Entity<InventItemSalesSetup>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventDimId, e.ItemId }).HasName("PK__InventIt__0A700B439EC5DDB7");
        });

        modelBuilder.Entity<InventItemSalesSetups>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventDimId, e.ItemId }).HasName("PK__InventIt__0A700B43AAC30B6E");
        });

        modelBuilder.Entity<InventJournalTransDataEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalId, e.LineNum }).HasName("PK__InventJo__E30B4ADD67ED788D");
        });

        modelBuilder.Entity<InventTableModules>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ItemId, e.ModuleType }).HasName("PK__InventTa__4290AE4301A6AFC5");
        });

        modelBuilder.Entity<InventTransEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RecId1, e.RecId2 }).HasName("PK__InventTr__727835E600908E48");
        });

        modelBuilder.Entity<InventTransEntities__r_204536460>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RecId1, e.RecId2 }).HasName("PK__InventTr__727835E69450DC08");
        });

        modelBuilder.Entity<InventTransOrigins>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.ItemId, e.ReferenceId }).HasName("PK__InventTr__E8FABEE1B83C01C7");
        });

        modelBuilder.Entity<InventTransPostings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransOrigin, e.InventTransPostingType, e.TransDate, e.Voucher }).HasName("PK__InventTr__F4D04F34E38B8D59");
        });

        modelBuilder.Entity<InventTransferJourLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventDimId, e.LineNum, e.TransferId, e.VoucherId }).HasName("PK__InventTr__895A3261DF36E343");
        });

        modelBuilder.Entity<InventTransferJours>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.TransferId, e.VoucherId }).HasName("PK__InventTr__C1440D4C0A3E4361");
        });

        modelBuilder.Entity<InventoryMovementJournalEntries>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventorySiteId, e.InventoryStatusId, e.InventoryWarehouseId, e.ItemBatchNumber, e.ItemNumber, e.ItemSerialNumber, e.JournalNumber, e.LicensePlateNumber, e.ProductColorId, e.ProductConfigurationId, e.ProductSizeId, e.ProductStyleId, e.WarehouseLocationId }).HasName("PK__Inventor__959CC3B9BD03A7EA");
        });

        modelBuilder.Entity<InventoryMovementJournalHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalNumber }).HasName("PK__Inventor__B343010FA9898CE1");
        });

        modelBuilder.Entity<InvoiceSubLinesV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceLineNumber, e.InvoiceLineReference, e.ProductReceiptNumber, e.PurchaseOrder }).HasName("PK__InvoiceS__A0BCEB69AD37B820");
        });

        modelBuilder.Entity<ItemCrateMappings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.ItemId }).HasName("PK__ItemCrat__FA58535509B4E9C7");
        });

        modelBuilder.Entity<ItemSiteMappings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.ItemId }).HasName("PK__ItemSite__FA58535551A31C47");
        });

        modelBuilder.Entity<ItemWarehouseMappings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventLocationId, e.ItemId }).HasName("PK__ItemWare__0A930E0C5B185657");
        });

        modelBuilder.Entity<KPIStdDatas>(entity =>
        {
            entity.HasKey(e => new { e.BagQty, e.dataAreaId, e.InventSiteId, e.ItemId, e.KPIBatchNo }).HasName("PK__KPIStdDa__CC15B33D3E99CA6A");
        });

        modelBuilder.Entity<LineDiscountCustomerGroups>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GroupCode }).HasName("PK__LineDisc__EB930704773892D1");
        });

        modelBuilder.Entity<LogisticsAddressCountryRegion>(entity =>
        {
            entity.HasKey(e => e.CountryRegion).HasName("PK__Logistic__1666687F02E05005");
        });

        modelBuilder.Entity<LogisticsAddressStates>(entity =>
        {
            entity.HasKey(e => new { e.CountryRegionId, e.State }).HasName("PK__Logistic__2E40C6343F490967");
        });

        modelBuilder.Entity<LogisticsLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Logistic__E7FEA497CD67E99C");
        });

        modelBuilder.Entity<LogisticsLocations>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Logistic__E7FEA497C4DAD47C");
        });

        modelBuilder.Entity<LogisticsPostalAddress>(entity =>
        {
            entity.HasKey(e => new { e.Location_LocationId, e.ValidFrom }).HasName("PK__Logistic__934D99FC2EBE9D89");
        });

        modelBuilder.Entity<LogisticsPostalAddresss>(entity =>
        {
            entity.HasKey(e => new { e.Location_LocationId, e.ValidFrom }).HasName("PK__Logistic__934D99FC0962FC52");
        });

        modelBuilder.Entity<LogisticsPostalAddresss_3>(entity =>
        {
            entity.HasKey(e => new { e.Location_LocationId, e.ValidFrom }).HasName("PK__Logistic__934D99FC4218B6C2");
        });

        modelBuilder.Entity<MTRouteMasters>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RouteId }).HasName("PK__MTRouteM__20230A8885DCA416");
        });

        modelBuilder.Entity<MainAccountCategories>(entity =>
        {
            entity.HasKey(e => e.ReferenceId).HasName("PK__MainAcco__E1A99A194C7FB457");

            entity.Property(e => e.ReferenceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MainAccounts>(entity =>
        {
            entity.HasKey(e => new { e.ChartOfAccounts, e.MainAccountId }).HasName("PK__MainAcco__A8D7605C047280FF");
        });

        modelBuilder.Entity<MainAccounts_1>(entity =>
        {
            entity.HasKey(e => new { e.ChartOfAccounts, e.MainAccountId }).HasName("PK__MainAcco__A8D7605C220F48EC");
        });

        modelBuilder.Entity<MarkupTransTransTaxInformations>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNum, e.TransRecId, e.TransTableId }).HasName("PK__MarkupTr__9E8A4F3C633C1110");
        });

        modelBuilder.Entity<MarkupTransTransTaxInformations_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNum, e.TransRecId, e.TransTableId }).HasName("PK__MarkupTr__9E8A4F3C81ADAE8E");
        });

        modelBuilder.Entity<OvenPngMaintenanceTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.OvenType, e.TransDate }).HasName("PK__OvenPngM__68F5919E98628D68");
        });

        modelBuilder.Entity<OvenPngProdTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.OvenType, e.TransDate }).HasName("PK__OvenPngP__68F5919E3E7C60FB");
        });

        modelBuilder.Entity<OvenPngProdTables_2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.OvenType, e.TransDate }).HasName("PK__OvenPngP__68F5919E6AEB742A");
        });

        modelBuilder.Entity<PartyLocationPostalAddressesV2>(entity =>
        {
            entity.HasKey(e => new { e.LocationId, e.PartyNumber, e.ValidFrom }).HasName("PK__PartyLoc__CB275808551A1BF2");
        });

        modelBuilder.Entity<PaymentTerms>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.Name }).HasName("PK__PaymentT__8F1D2B734FC5CBDA");
        });

        modelBuilder.Entity<PoweConsumptions>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.DGNo, e.InventSiteId, e.TransDate }).HasName("PK__PoweCons__2C823C60F3C1A842");
        });

        modelBuilder.Entity<PoweConsumptions_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.DGNo, e.InventSiteId, e.TransDate }).HasName("PK__PoweCons__2C823C6075D25B4A");
        });

        modelBuilder.Entity<PriceCustomerGroups>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GroupCode }).HasName("PK__PriceCus__EB930704CCCF93DD");
        });

        modelBuilder.Entity<PriceDiscTable>(entity =>
        {
            entity.HasKey(e => new { e.AccountCode, e.AccountRelation, e.AgreementHeaderExt_RU_AgreementId, e.Currency, e.dataAreaId, e.FromDate, e.InventDimId, e.ItemCode, e.ItemRelation, e.QuantityAmountFrom, e.relation, e.UnitId }).HasName("PK__PriceDis__394EF8454CFD3CA2");
        });

        modelBuilder.Entity<PriceDiscTables>(entity =>
        {
            entity.HasKey(e => new { e.AccountCode, e.AccountRelation, e.AgreementHeaderExt_RU_AgreementId, e.Currency, e.dataAreaId, e.FromDate, e.InventDimId, e.ItemCode, e.ItemRelation, e.QuantityAmountFrom, e.relation, e.UnitId }).HasName("PK__PriceDis__394EF845535B27B7");
        });

        modelBuilder.Entity<ProdCalcTranss>(entity =>
        {
            entity.HasKey(e => new { e.CollectRefLevel, e.CollectRefProdId, e.dataAreaId, e.InventDimId, e.LineNum }).HasName("PK__ProdCalc__32B051733F6D91B8");
        });

        modelBuilder.Entity<ProdDieselStds>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.HG_Recid, e.InventSiteId, e.ItemId }).HasName("PK__ProdDies__F2390844ACAC552F");
        });

        modelBuilder.Entity<ProdErrorQties>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.ItemId, e.OvenType, e.TransDate }).HasName("PK__ProdErro__7BD5A891083D7596");
        });

        modelBuilder.Entity<ProdManpowerMasterEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.FromDate, e.Shift, e.ToDate }).HasName("PK__ProdManp__8C82B0EF8DFCCA8E");
        });

        modelBuilder.Entity<ProdManpowerMasters>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.FromDate, e.InventSiteId, e.Shift, e.ToDate }).HasName("PK__ProdManp__5BDD72DC3557C3A2");
        });

        modelBuilder.Entity<ProdManpowerTranss>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.Shift, e.TransDate }).HasName("PK__ProdManp__AC84C61BAFF04C1F");
        });

        modelBuilder.Entity<ProdOvenTypes>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.FromDate, e.InventSiteId, e.ItemId, e.OvenType, e.ToDate }).HasName("PK__ProdOven__3153D81E57E9927E");
        });

        modelBuilder.Entity<ProdTableDataEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ProdId }).HasName("PK__ProdTabl__A8680B620208E0B2");
        });

        modelBuilder.Entity<ProdTableEntities>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ProdId }).HasName("PK__ProdTabl__A8680B6257D1EEC7");
        });

        modelBuilder.Entity<ProdWastageAnalysiss>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.ItemId, e.Shift, e.TransDate }).HasName("PK__ProdWast__2792BDE96D3D38D0");
        });

        modelBuilder.Entity<ProdWastageCrumbs>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.ItemId, e.TransDate }).HasName("PK__ProdWast__E5FD2E913DF8A7F0");
        });

        modelBuilder.Entity<ProductCategories>(entity =>
        {
            entity.HasKey(e => new { e.CategoryName, e.ProductCategoryHierarchyName }).HasName("PK__ProductC__2588539DA5A0FAFD");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => new { e.ProductCategoryHierarchyName, e.ProductCategoryName, e.ProductNumber }).HasName("PK__ProductC__6C5E4C8867EF9A32");
        });

        modelBuilder.Entity<ProductCategoryAssignments>(entity =>
        {
            entity.HasKey(e => new { e.ProductCategoryHierarchyName, e.ProductCategoryName, e.ProductNumber }).HasName("PK__ProductC__6C5E4C88D08E7633");
        });

        modelBuilder.Entity<ProductReceiptHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RecordId }).HasName("PK__ProductR__679784B2EF129A3D");
        });

        modelBuilder.Entity<ProductReceiptLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RecordId }).HasName("PK__ProductR__679784B216DBC422");
        });

        modelBuilder.Entity<ProductSpecificUnitOfMeasureConversions>(entity =>
        {
            entity.HasKey(e => new { e.FromUnitSymbol, e.ProductNumber, e.ToUnitSymbol }).HasName("PK__ProductS__281FDE386101CC5F");
        });

        modelBuilder.Entity<ProductTranslations>(entity =>
        {
            entity.HasKey(e => new { e.LanguageId, e.ProductNumber }).HasName("PK__ProductT__2DA26928DF49A766");
        });

        modelBuilder.Entity<ProductTranslationsTest>(entity =>
        {
            entity.HasKey(e => new { e.LanguageId, e.ProductNumber }).HasName("PK_ProductTranslationsTestR");
        });

        modelBuilder.Entity<ProductUnitOfMeasureConversions>(entity =>
        {
            entity.HasKey(e => new { e.FromUnitSymbol, e.ProductNumber, e.ToUnitSymbol }).HasName("PK__ProductU__281FDE3826E1E68E");
        });

        modelBuilder.Entity<ProductionOrderBillOfMaterialLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNumber, e.ProductionOrderNumber }).HasName("PK__Producti__3480B2A3DE506E75");
        });

        modelBuilder.Entity<ProductionOrderHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ProductionOrderNumber }).HasName("PK__Producti__BB704DC59962031D");
        });

        modelBuilder.Entity<ProductionOrderRouteOperations>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.OperationNumber, e.OperationPriority, e.ProductionOrderNumber }).HasName("PK__Producti__535C6137D9B3F3C2");
        });

        modelBuilder.Entity<ProductionRouteTransactions>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.EstimatedAccountingDate, e.OperationNumber, e.RecordId }).HasName("PK__Producti__5FA23D42F1D8D781");
        });

        modelBuilder.Entity<ProductsV2>(entity =>
        {
            entity.HasKey(e => e.ProductNumber).HasName("PK__Products__49A3C838FAC26D42");
        });

        modelBuilder.Entity<PurchaseAgreementLinesV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNumber, e.PurchaseAgreementId }).HasName("PK__Purchase__19DA7DEE8CC28A4F");
        });

        modelBuilder.Entity<PurchaseAgreements>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.PurchaseAgreementId }).HasName("PK__Purchase__6EDCB917DBA7A432");
        });

        modelBuilder.Entity<PurchaseOrderHeadersV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.PurchaseOrderNumber }).HasName("PK__Purchase__614832A80D9DC579");
        });

        modelBuilder.Entity<PurchaseOrderLinesV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNumber, e.PurchaseOrderNumber }).HasName("PK__Purchase__E9233555BC528BEE");
        });

        modelBuilder.Entity<QualityOrderHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.QualityOrderNumber }).HasName("PK__QualityO__10BC8BB03EDC099F");
        });

        modelBuilder.Entity<QualityOrderLineResults>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.QualityOrderNumber, e.QualityOrderSequenceNumber, e.QualityTestId, e.ResultLineNumber }).HasName("PK__QualityO__51827995ECA2456C");
        });

        modelBuilder.Entity<ReleasedProductMastersV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ItemNumber }).HasName("PK__Released__9402DFE704D15427");
        });

        modelBuilder.Entity<ReleasedProductsV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.ItemNumber }).HasName("PK__Released__9402DFE75B3C33DE");
        });

        modelBuilder.Entity<ReqTransFirmLogs>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.InventTransType, e.ItemId }).HasName("PK__ReqTrans__770B46E7BD1F4A52");
        });

        modelBuilder.Entity<ReturnReasonCode>(entity =>
        {
            entity.Property(e => e.RecId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SalesInvoiceHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber }).HasName("PK__SalesInv__69BF2DEA33AB2094");
        });

        modelBuilder.Entity<SalesInvoiceHeadersV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber, e.LedgerVoucher }).HasName("PK__SalesInv__DA5957AA2F835DBE");
        });

        modelBuilder.Entity<SalesInvoiceLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber, e.LineCreationSequenceNumber }).HasName("PK__SalesInv__2B06ACCE1A30A65C");
        });

        modelBuilder.Entity<SalesInvoiceV2Lines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceNumber, e.LedgerVoucher, e.LineCreationSequenceNumber }).HasName("PK__SalesInv__9E72CFB8F4A51A2D");
        });

        modelBuilder.Entity<SalesOrderHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.SalesOrderNumber }).HasName("PK__SalesOrd__14DCB4320675C07B");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.SiteId }).HasName("PK__Site__C3B7B8AAE290B022");
        });

        modelBuilder.Entity<SubledgerVoucherGeneralJournalEntryEntities>(entity =>
        {
            entity.HasKey(e => new { e.RecId1, e.Voucher }).HasName("PK__Subledge__1C1168DBFBA312F9");
        });

        modelBuilder.Entity<SubledgerVoucherGeneralJournalEntryEntitiesTest>(entity =>
        {
            entity.HasKey(e => new { e.RecId1, e.Voucher }).HasName("PK_SubledgerVoucherGeneralJournalEntryEntitiesTestR");
        });

        modelBuilder.Entity<SuppItems>(entity =>
        {
            entity.HasKey(e => new { e.AccountRelation, e.dataAreaId, e.FromDate, e.ItemRelation, e.ToDate }).HasName("PK__SuppItem__0059257A18B7CDDF");
        });

        modelBuilder.Entity<SystemUsers>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__SystemUs__1788CCAC3DC1F6EB");
        });

        modelBuilder.Entity<TCustomers>(entity =>
        {
            entity.HasKey(e => new { e.CustomerAccount, e.dataAreaId }).HasName("PK__TCustome__FA13013430E5CD1A");
        });

        modelBuilder.Entity<TaxDocuments>(entity =>
        {
            entity.HasKey(e => new { e.CustVendTransTableId, e.dataAreaId, e.TaxDocumentNumber }).HasName("PK__TaxDocum__95D040A210B144BB");
        });

        modelBuilder.Entity<TaxInfoManagement>(entity =>
        {
            entity.HasKey(e => new { e.LocationId, e.Name }).HasName("PK__TaxInfoM__80C9FCD8948EECC9");
        });

        modelBuilder.Entity<TaxInformationCustTable_IN>(entity =>
        {
            entity.HasKey(e => new { e.CustTable, e.dataAreaId }).HasName("PK__TaxInfor__22AB272AA1FCE2FC");
        });

        modelBuilder.Entity<TaxInformationCustTable_INDs>(entity =>
        {
            entity.HasKey(e => new { e.CustTable, e.dataAreaId }).HasName("PK__TaxInfor__22AB272A920E400A");
        });

        modelBuilder.Entity<TaxRegistrationNumbers_INDs>(entity =>
        {
            entity.HasKey(e => new { e.RegistrationNumber, e.RegistrationType, e.TaxType }).HasName("PK__TaxRegis__D05F7ED7F42F9483");
        });

        modelBuilder.Entity<TaxTransInDataEntity>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.InvoiceId, e.ItemId, e.TaxCode, e.TaxDirection, e.TransDate, e.Voucher }).HasName("PK__TaxTrans__9BF245F760E7FEF7");
        });

        modelBuilder.Entity<TaxTransInDataEntity_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.TaxCode, e.TransDate }).HasName("PK__TaxTrans__F4B13365B62F98EE");
        });

        modelBuilder.Entity<TaxTranss>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.TaxCode, e.TransDate }).HasName("PK__TaxTrans__F4B13365B110AF48");
        });

        modelBuilder.Entity<TaxTranss_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId }).HasName("PK__TaxTrans__C306DAFB08B49471");
        });

        modelBuilder.Entity<TaxTranss_D>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.TaxCode, e.TransDate, e.Voucher }).HasName("PK__TaxTrans__267D789B99A2F63C");
        });

        modelBuilder.Entity<TaxWithholdTrans>(entity =>
        {
            entity.HasKey(e => new { e.CustInvoiceTrans, e.dataAreaId, e.Invoice, e.RecId1, e.SalesId }).HasName("PK__TaxWithh__FCCB1FB0616967DD");
        });

        modelBuilder.Entity<TestCertOfAnalysisTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventCertificateOfAnalysisId }).HasName("PK__TestCert__C661F4D64D755048");
        });

        modelBuilder.Entity<TransOriginsV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId }).HasName("PK__TransOri__C306DAFB1C952CDF");
        });

        modelBuilder.Entity<TransPostings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransOrigin_InventTransId, e.InventTransPostingType, e.TransDate, e.Voucher }).HasName("PK__TransPos__B426B0D7BD36C2B4");
        });

        modelBuilder.Entity<TransferJourLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventDimId, e.LineNum, e.TransferId, e.VoucherId }).HasName("PK__Transfer__895A32614ADBE55F");
        });

        modelBuilder.Entity<TransferJours>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.TransferId, e.VoucherId }).HasName("PK__Transfer__C1440D4C7F9B8C73");
        });

        modelBuilder.Entity<TransferOrderHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.TransferOrderNumber }).HasName("PK__Transfer__AEBDA645ECFDCC02");
        });

        modelBuilder.Entity<TransferOrderLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineNumber, e.TransferOrderNumber }).HasName("PK__Transfer__35DC6C1B5A4E89C8");
        });

        modelBuilder.Entity<UnitOfMeasureConversions>(entity =>
        {
            entity.HasKey(e => new { e.FromUnitSymbol, e.ToUnitSymbol }).HasName("PK__UnitOfMe__122102D9E9F0AE51");
        });

        modelBuilder.Entity<UnitOfMeasureConversionsTest>(entity =>
        {
            entity.HasKey(e => new { e.FromUnitSymbol, e.ToUnitSymbol }).HasName("PK_UnitOfMeasureConversionsTestR");
        });

        modelBuilder.Entity<UnitsOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitSymbol).HasName("PK__UnitsOfM__A8B98BF88E5BAE21");
        });

        modelBuilder.Entity<VehicleCodeMaster>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VehicleCode }).HasName("PK__VehicleC__1CD3AFBECB5CEA73");
        });

        modelBuilder.Entity<VehicleCodeMasters>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VehicleCode }).HasName("PK__VehicleC__1CD3AFBE2FF9DBC2");
        });

        modelBuilder.Entity<VehicleTagMaster>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VehicleTag }).HasName("PK__VehicleT__59EE000E997F8A69");
        });

        modelBuilder.Entity<VehicleTagMasters>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VehicleTag }).HasName("PK__VehicleT__59EE000E4C18F2C6");
        });

        modelBuilder.Entity<VendInvoiceInfoDataEntity>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.RecId1, e.TableRefId1 }).HasName("PK__VendInvo__47E222B27E689716");
        });

        modelBuilder.Entity<VendInvoiceJournalDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.InvoiceDate, e.InvoiceId, e.LedgerVoucher, e.PurchId }).HasName("PK__VendInvo__3BFA42FE8A88D9EF");
        });

        modelBuilder.Entity<VendInvoiceJournalHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalBatchNumber }).HasName("PK__VendInvo__CEF678E9301C790B");
        });

        modelBuilder.Entity<VendInvoiceJournalLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalBatchNumber, e.LineNumber }).HasName("PK__VendInvo__CA6F8ECEC496A517");
        });

        modelBuilder.Entity<VendPackingSlipJourDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.DocumentDate, e.PackingSlipId, e.RecId1 }).HasName("PK__VendPack__222657BAFE589741");
        });

        modelBuilder.Entity<VendPackingSlipTransDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.InventDate, e.ItemId, e.PackingSlipId, e.RecId1 }).HasName("PK__VendPack__6976DF2840380B92");
        });

        modelBuilder.Entity<VendPaymModeBankAccounts>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.LineId }).HasName("PK__VendPaym__6AC0956EE041EBA9");
        });

        modelBuilder.Entity<VendTransDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.RecId1 }).HasName("PK__VendTran__910D226CCAEF0A96");
        });

        modelBuilder.Entity<VendorBankAccounts>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VendorAccountNumber, e.VendorBankAccountId }).HasName("PK__VendorBa__5D6DB24224885FF4");
        });

        modelBuilder.Entity<VendorInvoiceHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.HeaderReference }).HasName("PK__VendorIn__AB59B669118390AD");
        });

        modelBuilder.Entity<VendorInvoiceLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.HeaderReference, e.InvoiceLineNumber }).HasName("PK__VendorIn__D5CA6BFFA189E2B4");
        });

        modelBuilder.Entity<VendorInvoiceTransDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.RecId1 }).HasName("PK__VendorIn__910D226CDBA18221");
        });

        modelBuilder.Entity<VendorsV2>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.VendorAccountNumber }).HasName("PK__VendorsV__F8A3461AE145180B");
        });

        modelBuilder.Entity<Warehouses>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.WarehouseId }).HasName("PK__Warehous__6A4AF9C38FBB41B2");
        });

        modelBuilder.Entity<Warehouses_1>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.WarehouseId }).HasName("PK__Warehous__6A4AF9C37C6D48C0");
        });

        modelBuilder.Entity<WorkCalendarDate>(entity =>
        {
            entity.HasKey(e => new { e.CalendarId, e.dataAreaId, e.TransDate }).HasName("PK__WorkCale__771ABF3FCC3B0B40");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
