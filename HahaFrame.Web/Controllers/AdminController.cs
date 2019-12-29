using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using HahaFrame.Data.Domain;
using HahaFrame.Services.Frame;
using HahaFrame.Services.KnowledgeBases;
using HahaFrame.Services.StaticPages;
using HahaFrame.Web.Filters;
using HahaFrame.Web.Models;
using NLog;

namespace HahaFrame.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [InitializeSimpleMembership] 
    public class AdminController : Controller
    {
        private static Logger _loggingService = LogManager.GetCurrentClassLogger();
        private static IStaticPageService _staticPageService;
        private static IKnowledgeBaseService _knowledgeBaseService;
        private static IFrameService _frameService;

        public AdminController(IStaticPageService staticPageService, IKnowledgeBaseService knowledgeBaseService, IFrameService frameService)
        {
            _staticPageService = staticPageService;
            _knowledgeBaseService = knowledgeBaseService;
            _frameService = frameService;
        }

        public ActionResult Index()
        {
            var model = new CategoryListModel();
            
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Approve(int? page)
        {
            var model = new CategoryListModel();

            model.Frames = _frameService.GetFramesPendingApproval(page ?? 1, int.Parse(ConfigurationManager.AppSettings["FramesPerPage"]));
            ViewBag.Categories = new List<SelectListItem>();
            foreach (var category in _frameService.GetCategories(1, 100))
                ViewBag.Categories.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.CategoryId.ToString(CultureInfo.InvariantCulture)
                });

            return View(model);
        }

        [HttpPost]
        public ActionResult Approve(int frameId, string title, string description, string webName, int? categoryId)
        {
            _frameService.UpdateFrame(frameId, title, description, webName, categoryId);
            _frameService.ApproveFrame(frameId);

            return RedirectToAction("Approve");
        }
    }
}