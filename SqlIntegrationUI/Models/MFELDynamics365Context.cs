using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

public partial class MFELDynamics365Context : DbContext
{
    public MFELDynamics365Context()
    {
    }

    public MFELDynamics365Context(DbContextOptions<MFELDynamics365Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AgreementLineReleasedLines> AgreementLineReleasedLines { get; set; }

    public virtual DbSet<AllProducts> AllProducts { get; set; }

    public virtual DbSet<BillOfMaterialsLinesV2> BillOfMaterialsLinesV2 { get; set; }

    public virtual DbSet<BudgetModels> BudgetModels { get; set; }

    public virtual DbSet<BudgetRegisterEntryHeaders> BudgetRegisterEntryHeaders { get; set; }

    public virtual DbSet<BudgetRegisterEntryLines> BudgetRegisterEntryLines { get; set; }

    public virtual DbSet<DemandStagings> DemandStagings { get; set; }

    public virtual DbSet<DimensionAttributeValueCombinations> DimensionAttributeValueCombinations { get; set; }

    public virtual DbSet<DimensionAttributes> DimensionAttributes { get; set; }

    public virtual DbSet<DirPartyLocations> DirPartyLocations { get; set; }

    public virtual DbSet<FinancialDimensionValues> FinancialDimensionValues { get; set; }

    public virtual DbSet<FormulaLineV3s> FormulaLineV3s { get; set; }

    public virtual DbSet<FormulaVersion2s> FormulaVersion2s { get; set; }

    public virtual DbSet<HGMRPCalculations> HGMRPCalculations { get; set; }

    public virtual DbSet<HGMRPDiscountCalculations> HGMRPDiscountCalculations { get; set; }

    public virtual DbSet<HGMRPDiscountMasters> HGMRPDiscountMasters { get; set; }

    public virtual DbSet<HGMRPMasters> HGMRPMasters { get; set; }

    public virtual DbSet<HGSalesInvoiceHeaders> HGSalesInvoiceHeaders { get; set; }

    public virtual DbSet<HSNCodes> HSNCodes { get; set; }

    public virtual DbSet<InventDims> InventDims { get; set; }

    public virtual DbSet<InventItemGroupItems> InventItemGroupItems { get; set; }

    public virtual DbSet<InventItemSalesSetups> InventItemSalesSetups { get; set; }

    public virtual DbSet<InventJournalTransDataEntities> InventJournalTransDataEntities { get; set; }

    public virtual DbSet<InventTableModules> InventTableModules { get; set; }

    public virtual DbSet<InventTransOrigins> InventTransOrigins { get; set; }

    public virtual DbSet<InventTransPostings> InventTransPostings { get; set; }

    public virtual DbSet<InventoryMovementJournalEntries> InventoryMovementJournalEntries { get; set; }

    public virtual DbSet<InventoryMovementJournalHeaders> InventoryMovementJournalHeaders { get; set; }

    public virtual DbSet<KPIStdDatas> KPIStdDatas { get; set; }

    public virtual DbSet<LineDiscountCustomerGroups> LineDiscountCustomerGroups { get; set; }

    public virtual DbSet<LogisticsLocations> LogisticsLocations { get; set; }

    public virtual DbSet<MainAccounts> MainAccounts { get; set; }

    public virtual DbSet<OvenPngMaintenanceTables> OvenPngMaintenanceTables { get; set; }

    public virtual DbSet<OvenPngProdTables> OvenPngProdTables { get; set; }

    public virtual DbSet<PartyLocationPostalAddressesV2> PartyLocationPostalAddressesV2 { get; set; }

    public virtual DbSet<PaymentTerms> PaymentTerms { get; set; }

    public virtual DbSet<PoweConsumptions> PoweConsumptions { get; set; }

    public virtual DbSet<PriceCustomerGroups> PriceCustomerGroups { get; set; }

    public virtual DbSet<ProdCalcTranss> ProdCalcTranss { get; set; }

    public virtual DbSet<ProdCratess> ProdCratess { get; set; }

    public virtual DbSet<ProdDieselStds> ProdDieselStds { get; set; }

    public virtual DbSet<ProdErrorQties> ProdErrorQties { get; set; }

    public virtual DbSet<ProdManpowerMasterEntities> ProdManpowerMasterEntities { get; set; }

    public virtual DbSet<ProdManpowerMasters> ProdManpowerMasters { get; set; }

    public virtual DbSet<ProdManpowerTranss> ProdManpowerTranss { get; set; }

    public virtual DbSet<ProdOvenTypes> ProdOvenTypes { get; set; }

    public virtual DbSet<ProdTableDataEntities> ProdTableDataEntities { get; set; }

    public virtual DbSet<ProdTableEntities> ProdTableEntities { get; set; }

    public virtual DbSet<ProdWastageAnalysiss> ProdWastageAnalysiss { get; set; }

    public virtual DbSet<ProdWastageCrumbs> ProdWastageCrumbs { get; set; }

    public virtual DbSet<ProductCategoryAssignments> ProductCategoryAssignments { get; set; }

    public virtual DbSet<ProductReceiptHeaders> ProductReceiptHeaders { get; set; }

    public virtual DbSet<ProductReceiptLines> ProductReceiptLines { get; set; }

    public virtual DbSet<ProductTranslations> ProductTranslations { get; set; }

    public virtual DbSet<ProductUnitOfMeasureConversions> ProductUnitOfMeasureConversions { get; set; }

    public virtual DbSet<ProductionOrderBillOfMaterialLines> ProductionOrderBillOfMaterialLines { get; set; }

    public virtual DbSet<ProductionOrderHeaders> ProductionOrderHeaders { get; set; }

    public virtual DbSet<ProductionOrderRouteOperations> ProductionOrderRouteOperations { get; set; }

    public virtual DbSet<ProductionRouteTransactions> ProductionRouteTransactions { get; set; }

    public virtual DbSet<PurchaseAgreementLinesV2> PurchaseAgreementLinesV2 { get; set; }

    public virtual DbSet<PurchaseAgreements> PurchaseAgreements { get; set; }

    public virtual DbSet<PurchaseOrderHeadersV2> PurchaseOrderHeadersV2 { get; set; }

    public virtual DbSet<PurchaseOrderLinesV2> PurchaseOrderLinesV2 { get; set; }

    public virtual DbSet<QualityOrderHeaders> QualityOrderHeaders { get; set; }

    public virtual DbSet<QualityOrderLineResults> QualityOrderLineResults { get; set; }

    public virtual DbSet<ReqTransFirmLogs> ReqTransFirmLogs { get; set; }

    public virtual DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; }

    public virtual DbSet<TaxDocuments> TaxDocuments { get; set; }

    public virtual DbSet<TestCertOfAnalysisTables> TestCertOfAnalysisTables { get; set; }

    public virtual DbSet<UnitOfMeasureConversions> UnitOfMeasureConversions { get; set; }

    public virtual DbSet<UnitsOfMeasure> UnitsOfMeasure { get; set; }

    public virtual DbSet<VendInvoiceJournalDatasEntity> VendInvoiceJournalDatasEntity { get; set; }

    public virtual DbSet<VendPackingSlipJourDatasEntity> VendPackingSlipJourDatasEntity { get; set; }

    public virtual DbSet<VendPackingSlipTransDatasEntity> VendPackingSlipTransDatasEntity { get; set; }

    public virtual DbSet<VendPaymModeBankAccounts> VendPaymModeBankAccounts { get; set; }

    public virtual DbSet<VendTransDatasEntity> VendTransDatasEntity { get; set; }

    public virtual DbSet<VendorBankAccounts> VendorBankAccounts { get; set; }

    public virtual DbSet<VendorInvoiceHeaders> VendorInvoiceHeaders { get; set; }

    public virtual DbSet<VendorInvoiceLines> VendorInvoiceLines { get; set; }

    public virtual DbSet<VendorInvoiceTransDatasEntity> VendorInvoiceTransDatasEntity { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MFELConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<HGSalesInvoiceHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InvoiceDate, e.InvoiceId }).HasName("PK__HGSalesI__5CBFCDA966F0B917");
        });

        modelBuilder.Entity<HSNCodes>(entity =>
        {
            entity.HasKey(e => new { e.Chapter, e.CountryExtension, e.dataAreaId, e.Heading, e.StatisticalSuffix, e.Subheading }).HasName("PK__HSNCodes__FCA467AB06D4269C");
        });

        modelBuilder.Entity<InventDims>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.inventDimId }).HasName("PK__InventDi__B1CF935F1A562A4A");
        });

        modelBuilder.Entity<InventItemGroupItems>(entity =>
        {
            entity.HasKey(e => new { e.ItemDataAreaId, e.ItemId }).HasName("PK__InventIt__D47D1304CA41D6EF");
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

        modelBuilder.Entity<InventTransOrigins>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.ItemId, e.ReferenceId }).HasName("PK__InventTr__E8FABEE1B83C01C7");
        });

        modelBuilder.Entity<InventTransPostings>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransOrigin, e.InventTransPostingType, e.TransDate, e.Voucher }).HasName("PK__InventTr__F4D04F34E38B8D59");
        });

        modelBuilder.Entity<InventoryMovementJournalEntries>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventorySiteId, e.InventoryStatusId, e.InventoryWarehouseId, e.ItemBatchNumber, e.ItemNumber, e.ItemSerialNumber, e.JournalNumber, e.LicensePlateNumber, e.ProductColorId, e.ProductConfigurationId, e.ProductSizeId, e.ProductStyleId, e.WarehouseLocationId }).HasName("PK__Inventor__959CC3B9BD03A7EA");
        });

        modelBuilder.Entity<InventoryMovementJournalHeaders>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.JournalNumber }).HasName("PK__Inventor__B343010FA9898CE1");
        });

        modelBuilder.Entity<KPIStdDatas>(entity =>
        {
            entity.HasKey(e => new { e.BagQty, e.dataAreaId, e.InventSiteId, e.ItemId, e.KPIBatchNo }).HasName("PK__KPIStdDa__CC15B33D3E99CA6A");
        });

        modelBuilder.Entity<LineDiscountCustomerGroups>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GroupCode }).HasName("PK__LineDisc__EB930704773892D1");
        });

        modelBuilder.Entity<LogisticsLocations>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Logistic__E7FEA497C4DAD47C");
        });

        modelBuilder.Entity<MainAccounts>(entity =>
        {
            entity.HasKey(e => new { e.ChartOfAccounts, e.MainAccountId }).HasName("PK__MainAcco__A8D7605C047280FF");
        });

        modelBuilder.Entity<OvenPngMaintenanceTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.OvenType, e.TransDate }).HasName("PK__OvenPngM__68F5919E98628D68");
        });

        modelBuilder.Entity<OvenPngProdTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventSiteId, e.OvenType, e.TransDate }).HasName("PK__OvenPngP__68F5919E3E7C60FB");
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

        modelBuilder.Entity<PriceCustomerGroups>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.GroupCode }).HasName("PK__PriceCus__EB930704CCCF93DD");
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

        modelBuilder.Entity<ProductTranslations>(entity =>
        {
            entity.HasKey(e => new { e.LanguageId, e.ProductNumber }).HasName("PK__ProductT__2DA26928DF49A766");
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

        modelBuilder.Entity<ReqTransFirmLogs>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventTransId, e.InventTransType, e.ItemId }).HasName("PK__ReqTrans__770B46E7BD1F4A52");
        });

        modelBuilder.Entity<SubledgerVoucherGeneralJournalEntryEntities>(entity =>
        {
            entity.HasKey(e => new { e.RecId1, e.Voucher }).HasName("PK__Subledge__1C1168DBFBA312F9");
        });

        modelBuilder.Entity<TaxDocuments>(entity =>
        {
            entity.HasKey(e => new { e.CustVendTransTableId, e.dataAreaId, e.TaxDocumentNumber }).HasName("PK__TaxDocum__95D040A210B144BB");
        });

        modelBuilder.Entity<TestCertOfAnalysisTables>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.InventCertificateOfAnalysisId }).HasName("PK__TestCert__C661F4D64D755048");
        });

        modelBuilder.Entity<UnitOfMeasureConversions>(entity =>
        {
            entity.HasKey(e => new { e.FromUnitSymbol, e.ToUnitSymbol }).HasName("PK__UnitOfMe__122102D9E9F0AE51");
        });

        modelBuilder.Entity<UnitsOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitSymbol).HasName("PK__UnitsOfM__A8B98BF88E5BAE21");
        });

        modelBuilder.Entity<VendInvoiceJournalDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.InvoiceDate, e.InvoiceId, e.LedgerVoucher, e.PurchId }).HasName("PK__VendInvo__3BFA42FE8A88D9EF");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
