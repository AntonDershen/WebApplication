using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constants;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;
namespace WebApplication.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdministratorController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IUserService userService;
        public AdministratorController(IDocumentService documentService, IUserService userService)
        {
            this.documentService = documentService;
            this.userService = userService;

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeleteUser(int userId)
        {
            userService.DeleteUser(userService.GetUserById(userId));

            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteDocument(int documentId)
        {
            DocumentEntity doc  =  documentService.FindById(documentId);
            documentService.DeleteDocument(doc,doc.UserName );
            return RedirectToAction("Index", "Home");
        }
        public ActionResult FindDocument(string documentName)
        {
            IEnumerable<DocumentEntity> documentEntity = documentService.FindDocumentByAdmin(documentName);
            return PartialView("_FindDocument",documentEntity);
        }
        public ActionResult FindUser(string userName)
        {
            IEnumerable<UserEntity> userEntity = userService.GetUserAdminFind(userName);
            return PartialView("_FindUser", userEntity);
        }
	}
}