using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AdminFileController : Controller
    {
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<ObjFile> ObjFiles = new List<ObjFile>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/AdminFiles")))
            {
                FileInfo fi = new FileInfo(strfile);
                ObjFile obj = new ObjFile();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                ObjFiles.Add(obj);
            }

            return View(ObjFiles);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/AdminFiles"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        public ActionResult Delete(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/AdminFiles"), fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Search(string search)
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/AdminFiles"));
            List<ObjFile> files = new List<ObjFile>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ObjFile { File = Path.GetFileName(filePath) });
            }

            return View(files.Where(x => x.File.Contains(search)));
        }

        public ActionResult ShowPdfInBrowser(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/AdminFiles"), fileName);
            byte[] pdfContent = System.IO.File.ReadAllBytes(fullPath);
            if (pdfContent == null)
            {
                return null;
            }
            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = "someFilename.pdf"
            };
            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
            return File(pdfContent, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".pdf":
                    return "PDF File";
                case ".mp4":
                    return "Video";
                case ".jpg":
                case ".png":
                    return "Image";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public ActionResult Index(ObjFile doc)
        {
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/AdminFiles"), fileName);
                    file.SaveAs(filePath);
                }
            }
            TempData["Message"] = "Files uploaded successfully";
            return RedirectToAction("Index");
        }
    }
}