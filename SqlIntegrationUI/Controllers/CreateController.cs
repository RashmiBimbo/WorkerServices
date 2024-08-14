using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Linq;

namespace SqlIntegrationUI.Controllers
{
    public class CreateController : Controller
    {
        // GET: CreateController
        public ActionResult CreateFromExcel()
        {
            return View();
        }

        // Post: CreateController/
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile excelFile)
        {
            // Validate if file is selected
            if (excelFile == null || excelFile.Length == 0)
            {
                // Handle the case when no file is uploaded
                ModelState.AddModelError("file", "Please upload a file.");
                ViewData["ErrorMessage"] = "Please upload a file.";
                return View("CreateFromExcel");
            }
            var serviceList = new List<ServiceDetail>();

            // Save the file to the specified path
            using (var stream = new MemoryStream())
            {
                await excelFile.CopyToAsync(stream);
                stream.Position = 0;

                using SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false);
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheet sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                foreach (Row row in sheetData.Elements<Row>().Skip(1)) // Assuming the first row is a header
                {
                    int i = 0;
                    ServiceDetail rowData = new ServiceDetail
                    {
                        Name = GetCellValue(doc, row.Elements<Cell>().ElementAt(i++)),
                        Enable = true,
                        Period = Convert.ToInt16(GetCellValue(doc, row.Elements<Cell>().ElementAt(i++))),
                        Table = GetCellValue(doc, row.Elements<Cell>().ElementAt(i++)),
                        Endpoint = GetCellValue(doc, row.Elements<Cell>().ElementAt(i++))
                    };
                    try
                    {
                        rowData.QueryString = GetCellValue(doc, row.Elements<Cell>().ElementAt(i++));
                    }
                    catch (Exception ex)
                    {
                        rowData.QueryString = Emp;
                    }
                    serviceList.Add(rowData);
                }
            }
            // Set a success message
            // Set a success message
            //ViewData["SuccessMessage"] = $"File '{XlFile.FileName}' uploaded successfully!";

            return View("CreateFromExcel", serviceList);
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
                return Emp;
            }
        }


        // POST: CreateController/CreateFromExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromExcel(List<ServiceDetail> serviceList)
        {
            try
            {
                foreach (ServiceDetail service in serviceList)
                {
                    if (!Common.Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StrComp)))
                    {
                        JObject jObj = await GetServiceJObject(service);
                        service.Columns = await GetColumns(jObj);
                        Common.Services.ServiceSet.Add(service);
                        AddedServices ??= [];
                        AddedServices.TryAdd(service.Table, jObj);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }


        // GET: CreateController/Create
        public ActionResult Create()
        {
            return View("Create");
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
                if (!Common.Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StrComp)))
                {
                    service.Columns = await GetColumns(jObj);
                    Common.Services.ServiceSet.Add(service);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: CreateFromExcelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateFromExcelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateFromExcelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateFromExcelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateFromExcelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
