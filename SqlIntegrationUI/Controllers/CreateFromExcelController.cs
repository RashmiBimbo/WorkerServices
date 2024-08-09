using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SqlIntegrationUI.Controllers
{
    public class CreateFromExcelController : Controller
    {
        // GET: CreateFromExcelController
        public ActionResult CreateFromExcel()
        {
            return View();
        }

        // GET: CreateFromExcelController/Details/5
        [HttpPost]
        public async Task<IActionResult> View(IFormFile XlFile)
        {
            // Validate if file is selected
            if (XlFile == null || XlFile.Length == 0)
            {
                    // Handle the case when no file is uploaded
                    ModelState.AddModelError("file", "Please upload a file.");
                return View("CreateFromExcel");
            }

            // Validate the file extension
            var extension = Path.GetExtension(XlFile.FileName).ToLowerInvariant();
            if (extension != ".xls" && extension != ".xlsx")
            {
                ViewData["Message"] = "Only Excel files (.xls, .xlsx) are allowed.";
                return View("CreateFromExcel");
            }

            // Define a path where the uploaded files will be stored
            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            Directory.CreateDirectory(uploadsDir); // Ensure the directory exists

            // Create a file path with a unique name to avoid overwriting
            var filePath = Path.Combine(uploadsDir, Path.GetRandomFileName() + extension);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await XlFile.CopyToAsync(stream);
            }
            // Set a success message
            ViewData["Message"] = $"File '{XlFile.FileName}' uploaded successfully!";

            return View("CreateFromExcel");
        }

        // GET: CreateFromExcelController/Create
        public ActionResult Create()
        {
            return View();
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
