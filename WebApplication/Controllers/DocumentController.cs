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
using BLL.Interface.Entities;
namespace WebApplication.Controllers
{
    [Authorize(Roles=Constants.Constant.user)]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IUserService userService;
        public DocumentController(IDocumentService documentService, IUserService userService)
        {
            this.documentService = documentService;
            this.userService = userService;

        }
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
        public ActionResult CreateDocument(DocumentCreateModel model,HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid && file != null)
                {
                    StringBuilder documentName;
                    int docId = documentService.FindDocument(file.FileName);
                    documentName = new StringBuilder(file.FileName);
                    if (docId != 0)
                    {
                        documentName.Append(Constants.Constant.documentAddition);
                        documentName.Insert(documentName.Length - docId.ToString().Length, docId);
                    }
                    documentService.CreateDocument(DocumentViewMapper.ToBllDocument(documentName.ToString(), userService.GetUserByName(User.Identity.Name).Id, file.ContentType, model.Access,User.Identity.Name),file,User.Identity.Name);
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = Constant.error });
            }
        }
        public ActionResult DeleteDocument(int documentId)
        {
            try
            {
                documentService.DeleteDocument(documentService.FindById(documentId), User.Identity.Name);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = Constant.error });
            }
        }
        public ActionResult DownloadDocument(int documentId)
        {
            DocumentModel document = documentService.FindById(documentId).ToDocument();
            if (document != null && (document.Access == true || (User.Identity.IsAuthenticated && User.Identity.Name == document.UserName)))
            {
                byte[] context = documentService.GetFileContext(documentId);
                return File(documentService.GetFileContext(documentId), document.Type, document.Name);
            }
            return RedirectToAction("Index", "Error", new { error = "Файл не найден" });
        }
        public ActionResult ShowDocument()
        {
            try
            {
                IEnumerable<DocumentEntity> documentEntity = userService.GetUserDocument(User.Identity.Name);
                IEnumerable<DocumentViewModel> model;
                if (documentEntity != null)
                    model = documentEntity.Select(x => x.ToDocumentView()).Reverse();
                else
                    model = null;
                return PartialView("_ShowDocument", model);
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = Constant.error });
            }
        }
        public void ChangeAccess(int id)
        { 
             try
            {
                DocumentEntity docEntity = documentService.FindById(id);
                 if(User.Identity.Name == docEntity.UserName)
                documentService.ChangeAccess(id);
            }
            catch
            {
               
            }
        }
    }
}
            
