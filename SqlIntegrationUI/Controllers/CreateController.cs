using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using static SqlIntegrationUI.UIUtilities.UICommonCode;

namespace SqlIntegrationUI.Controllers
{
    public class CreateController : Controller
    {
        public static List<ServiceDetail>? ProposedServices
        {
            get
            {
                try
                {
                    if (!memoryCache.TryGetValue("ProposedServices", out List<ServiceDetail> services))
                    {
                        return null;
                    }
                    return services;
                }
                catch (Exception Ex)
                {
                    throw;
                }
            }
            set
            {
                if (value == null)
                {
                    memoryCache.Remove("ProposedServices");
                }
                else if (value is List<ServiceDetail>)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("ProposedServices", value, cacheEntryOptions);
                }
                else
                {
                    throw new Exception("The passed object is not of List<ServiceDetail> type!");
                }
            }
        }

        // GET: CreateController/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create");
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        // POST: CreateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceDetail service)
        {
            if (service is null)
                Problem("Error creating Service! \r\n Service is null.");

            try
            {
                service.Name = service.Name?.Trim();
                service.Endpoint = service.Endpoint?.Trim();
                service.Table = service.Table?.Trim();
                service.QueryString = service.QueryString?.Trim();

                string qStr = service.QueryString;
                string fltr = "cross-company=true";
                service.QueryString += IsEmpty(qStr) ? fltr : qStr.Contains(fltr, StrComp) ? Emp : "&" + fltr;
                JObject jObj = await GetServiceJObject(service);

                AddedServices ??= [];
                AddedServices.TryAdd(service.Table, jObj);

                if (!ConfigServices.ServiceSet.Any(s => s.Name.Equals(service.Endpoint, StrComp)))
                {
                    service.Columns = await GetColumns(jObj);
                    ConfigServices.ServiceSet.Add(service);
                }
                return RedirectToAction(nameof(ServicesController.Index), nameof(ServicesController).Replace("Controller", Emp));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return View();
            }
        }

        // GET: CreateController
        public ActionResult CreateFromExcel()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        // POST: CreateController/CreateFromExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromExcel(List<ServiceDetail> serviceList)
        {
            try
            {
                ProposedServices = serviceList;
                foreach (ServiceDetail service in serviceList)
                {
                    if (service is null || IsEmpty(service.Endpoint))
                        continue;

                    if (!ConfigServices.ServiceSet.Any(s => s.Endpoint.Equals(service.Endpoint, StrComp)))
                    {
                        JObject jObj = await GetServiceJObject(service);
                        service.Columns = await GetColumns(jObj, service);
                        if (IsEmpty(service.QueryString))
                            service.QueryString = "cross-company = true";
                        else
                        {
                            _ = service.QueryString.Replace("?", Emp);
                            service.QueryString += service.QueryString.Contains("cross-company=true") ? Emp : "cross-company = true";
                        }
                        ConfigServices.ServiceSet.Add(service);
                        AddedServices ??= [];
                        AddedServices.TryAdd(service.Endpoint, jObj);
                    }
                }
                ProposedServices = null;
                return RedirectToAction(nameof(ServicesController.Index), "Services");
            }
            catch (Exception ex)
            {
                //ErrorViewModel errMdl = new();
                //return View("Error", errMdl);
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
            //return View();
        }

        // Post: CreateController/Upload
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile xlFile)
        {
            IActionResult rslt = await Validate(xlFile);
            if (rslt != null) return rslt;

            // Set a success message
            ViewData["SuccessMessage"] = $"File '{xlFile.FileName}' uploaded successfully!";

            ProposedServices = null;
            var serviceList = new List<ServiceDetail>();

            // Save the file to the specified path
            using var stream = new MemoryStream();
            try
            {
                xlFile.CopyToAsync(stream);
                stream.Position = 0;

                using SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false);
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheet sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                int columnIndex = 0;

                // Assuming that Emp is a predefined string, and GetCellValue is a method that retrieves the cell's value
                var headerRow = sheetData.Elements<Row>().First(); // Get the first row, which is the header

                // Map column names to their Excel cell references (e.g., "A", "B", "C", etc.)
                Dictionary<string, string> columnMappings = [];
                foreach (Cell headerCell in headerRow.Elements<Cell>())
                {
                    string columnName = GetCellValue(doc, headerCell);
                    columnName = columnName.Replace(" ", Emp).ToUpper();
                    string cellReference = headerCell.CellReference.Value.Substring(0, 1); // "A", "B", etc.
                    columnMappings[columnName] = cellReference;
                }
                foreach (Row row in sheetData.Elements<Row>().Skip(1))
                {
                    string endPoint = GetCellValueByColumn(doc, row, columnMappings, "ENDPOINT");
                    if (IsEmpty(endPoint))
                        continue;
                    //string name = GetCellValueByColumn(doc, row, columnMappings, "Name");
                    //if (IsEmpty(name)) name = endPoint;

                    //string period = GetCellValueByColumn(doc, row, columnMappings, "PERIOD");
                    //if (IsEmpty(period)) period = "30";

                    //string tbl = GetCellValueByColumn(doc, row, columnMappings, "Table");
                    //if (IsEmpty(name)) tbl = endPoint + "Test";

                    ServiceDetail service = new()
                    {
                        Name = GetCellValueByColumn(doc, row, columnMappings, "NAME"),
                        Endpoint = endPoint,
                        Period = Convert.ToInt16(GetCellValueByColumn(doc, row, columnMappings, "PERIOD")),
                        Table = GetCellValueByColumn(doc, row, columnMappings, "TABLE")
                    };

                    string queryString = GetCellValueByColumn(doc, row, columnMappings, "QueryString");
                    service.QueryString = string.IsNullOrWhiteSpace(queryString) ? "cross-company=true" : queryString;
                    if (!service.QueryString.Contains("cross-company=true"))
                    {
                        service.QueryString += "cross-company=true";
                    }
                    serviceList.Add(service);
                }
                ProposedServices = serviceList;

                return View("CreateFromExcel", ProposedServices);
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        // Retrieves the cell value based on the column name
        private string GetCellValueByColumn(SpreadsheetDocument doc, Row row, Dictionary<string, string> columnMappings, string columnName)
        {
            try
            {
                if (columnMappings.TryGetValue(columnName, out string cellReference))
                {
                    Cell cell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference.Value.StartsWith(cellReference));
                    return GetCellValue(doc, cell);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return null;
            }
        }

        private async Task<IActionResult> Validate(IFormFile excelFile)
        {
            try
            {
                // Validate if file is selected
                if (excelFile == null || excelFile.Length == 0)
                {
                    // Handle the case when no file is uploaded
                    ModelState.AddModelError("file", "Please upload a file.");
                    ViewData["ErrorMessage"] = "Please upload a file.";
                    return View("CreateFromExcel");
                }
                // Validate based on file extension
                var allowedExtensions = new[] { ".xls", ".xlsx" };
                var extension = Path.GetExtension(excelFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("file", "Please upload a valid Excel file (.xls or .xlsx).");
                    ViewData["ErrorMessage"] = "Please upload a valid Excel file (.xls or .xlsx).";
                    return View("CreateFromExcel");
                }
                // Validate based on MIME type
                var allowedMimeTypes = new[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };

                if (!allowedMimeTypes.Contains(excelFile.ContentType))
                {
                    ModelState.AddModelError("file", "Please upload a valid Excel file.");
                    ViewData["ErrorMessage"] = "Please upload a valid Excel file.";
                    return View("CreateFromExcel");
                }
                return null;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        private string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            try
            {
                if (cell == null)
                    return Emp;

                SharedStringTablePart stringTablePart = doc.WorkbookPart.SharedStringTablePart;
                string value = cell.CellValue?.InnerText;

                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    value = stringTablePart?.SharedStringTable?.ChildElements[int.Parse(IsEmpty(value) ? Emp : value)].InnerText;
                    return value;
                }
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                LogInfo(ex, LogFile, NameSpacesUsed);
                return Emp;
            }
        }

        [HttpGet]
        public IActionResult Reset()
        {
            try
            {
                return View("CreateFromExcel", ProposedServices);
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }
    }
}
