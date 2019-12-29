using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using HahaFrame.Data.Domain;
using HahaFrame.Services.Frame;
using HahaFrame.Services.KnowledgeBases;
using HahaFrame.Services.StaticPages;
using HahaFrame.Web.Models;
using NLog;

namespace HahaFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        private static Logger _loggingService = LogManager.GetCurrentClassLogger();
        private static IStaticPageService _staticPageService;
        private static IKnowledgeBaseService _knowledgeBaseService;
        private static IFrameService _frameService;

        public HomeController(IStaticPageService staticPageService, IKnowledgeBaseService knowledgeBaseService, IFrameService frameService)
        {
            _staticPageService = staticPageService;
            _knowledgeBaseService = knowledgeBaseService;
            _frameService = frameService;
        }

        public ActionResult Index(int? page)
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName("recent");
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetRecentFrames(Request.UserHostAddress, null, page ?? 1, int.Parse(ConfigurationManager.AppSettings["FramesPerPage"]));

            return View(model);
        }

        public ActionResult CategoryList(string webName, int? page)
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName(webName);
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetFramesByCategory(categroy.CategoryId, Request.UserHostAddress, null, page ?? 1, int.Parse(ConfigurationManager.AppSettings["FramesPerPage"]));

            return View("FrameCategoryList", model);
        }

        public ActionResult CategoryListFeatured(int? page)
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName("featured");
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetFeaturedFrames(Request.UserHostAddress, null, page ?? 1, int.Parse(ConfigurationManager.AppSettings["FramesPerPage"]));

            return View("FrameCategoryList", model);
        }

        public ActionResult CategoryListPopular(int? page)
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName("popular");
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetPopularFrames(Request.UserHostAddress, null, page ?? 1, int.Parse(ConfigurationManager.AppSettings["FramesPerPage"]));

            return View("FrameCategoryList", model);
        }

        public ActionResult FrameView(string categoryWebName, int frameId, string webName)
        {
            var model = new FrameViewModel();
            var categroy = _frameService.GetCategoryByName(categoryWebName);
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frame = _frameService.GetFrameByIdForDisplay(frameId, null, Request.UserHostAddress);

            return View(model);
        }

        public ActionResult FrameReport(string categoryWebName, int frameId, string webName)
        {
            return View();
        }

        public ActionResult FrameVote(string categoryWebName, int frameId, string webName, int vote)
        {
            _frameService.AddFrameVote(frameId, (byte) vote, 0, Request.UserHostAddress);

            return Json(new {success = true});
        }

        public ActionResult Privacy()
        {
            var page = _staticPageService.GetStaticPageByName("privacy");

            return View("StaticPageView", page);
        }

        public ActionResult Terms()
        {
            var page = _staticPageService.GetStaticPageByName("terms");

            return View("StaticPageView", page);
        }

        public ActionResult Faq()
        {
            var model = _knowledgeBaseService.GetKnowledgeBases();

            return View(model);
        }

        public ActionResult StaticPageView(string webName)
        {
            var page = _staticPageService.GetStaticPageByName(webName);

            return View("StaticPageView", page);
        }

        public ActionResult Import(string passCode)
        {
            if (passCode == "JHiyudshanjk8776**")
            {
                foreach (var importFile in Directory.GetFiles(Server.MapPath("~/Content")))
                {
                    var frame = new Frame
                    {
                        Active = false,
                        CategoryId = 9,
                        DateUploaded = DateTime.Now,
                        Deleted = false,
                        Featured = false,
                        MetaDescription = Path.GetFileNameWithoutExtension(importFile),
                        PhotoUrl = Path.GetFileName(importFile),
                        Title = Path.GetFileNameWithoutExtension(importFile),
                        UserId = 1,
                        WebName = ""
                    };

                    _frameService.InsertFrame(frame);
                }
            }

            return Redirect("/");
        }

        public string GetIPAddress()
        {
            var szRemoteAddr = Request.ServerVariables["REMOTE_ADDR"];
            var szXForwardedFor = Request.ServerVariables["X_FORWARDED_FOR"];
            string szIP;

            if (szXForwardedFor == null)
            {
                szIP = szRemoteAddr;
            }
            else
            {
                szIP = szXForwardedFor;

                if (szIP.IndexOf(",", StringComparison.Ordinal) <= 0) return szIP;
                var arIPs = szIP.Split(',');

                foreach (var item in arIPs)
                    return item;
            }
            return szIP;
        }
    }
}