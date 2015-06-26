using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using WebApplication.Models;
using System.Text;
using WebApplication.Infrastructure.Mappers;
using Constants;
using System.Web.Security;
using WebApplication.Models;
using BLL.Interface.Entities;
namespace WebApplication.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IUserService userService;
        public DocumentController(IDocumentService documentService, IUserService userService)
        {
            this.documentService = documentService;
            this.userService = userService;
        }

        //
        // GET: /Document/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateDocument()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDocument(HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                StringBuilder documentName;
                int docId = documentService.FindDocument(file.FileName);
                documentName = new StringBuilder(file.FileName);
                if (docId != 0)
                {
                    documentName.Append(Constants.Constants.DocumentAddition);
                    documentName.Insert(documentName.Length - docId.ToString().Length, docId);
                }
                string path = documentService.SaveFile(file, User.Identity.Name);
                documentService.CreateDocument(DocumentViewMapper.ToBllDocument(documentName.ToString(), userService.GetUserByName(User.Identity.Name).Id, file.ContentType, path));
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult DeleteDocument(int documentId)
        {
            documentService.DeleteDocument(documentService.FindById(documentId));
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DownloadDocument(int documentId)
        {
            DocumentModel document = documentService.FindById(documentId).ToDocument();
            return File(AppDomain.CurrentDomain.BaseDirectory+document.DocumentPath,
                "application/force-download",document.Name);
        }
        public ActionResult ShowDocument()
        {
            IEnumerable<DocumentEntity> documentEntity = userService.GetUserDocument(User.Identity.Name);
            IEnumerable<DocumentViewModel> model;
            if (documentEntity != null)
                model = documentEntity.Select(x => x.ToDocumentView()).Reverse();
            else
                model = null;
            return PartialView("_ShowDocument", model);
        }
    }
	}
            
