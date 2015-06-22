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
namespace WebApplication.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IUserService userService;
        public DocumentController(IDocumentService documentService,IUserService userService)
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
        public ActionResult CreateDocument(CreateDocumentModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file!=null)
            {
                StringBuilder documentName;
                int docId = documentService.FindDocument(model.Name);
                documentName = new StringBuilder(model.Name);
                if (docId != 0)
                {
                    documentName.Append(Constants.Constants.DocumentAddition);
                    documentName.Insert(documentName.Length - docId.ToString().Length, docId);
                }
                string path = documentService.SaveFile(file, documentName.ToString(), User.Identity.Name);
                documentService.CreateDocument(DocumentMapper.ToBllDocument(documentName.ToString(),userService.GetUserByName(User.Identity.Name).Id,file.ContentType,path));
                return RedirectToAction("Index", "Home");
            }
           
            return View(model);
        }
	}
}