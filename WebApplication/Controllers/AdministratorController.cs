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
    [Authorize(Roles=Constant.admin)]
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
            try
            {
                DocumentEntity doc = documentService.FindById(documentId);
                documentService.DeleteDocument(doc, doc.UserName);
                return RedirectToAction("Index", "Home");
            }
            catch {
                return RedirectToAction("Index","Error",new{error = Constant.error});
            }

           
        }
        public ActionResult FindDocument(string documentName)
        {
            try
            {
                IEnumerable<DocumentEntity> documentEntity = documentService.FindDocumentByAdmin(documentName);
                return PartialView("_FindDocument", documentEntity);
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = Constant.error });
            }

        }
        public ActionResult FindUser(string userName)
        {
            try
            {
            IEnumerable<UserEntity> userEntity = userService.GetUserAdminFind(userName);
            return PartialView("_FindUser", userEntity);
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { error = Constant.error });
            }
        }
	}
}