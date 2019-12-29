using System.Configuration;
using System.Web.Mvc;
using HahaFrame.Services.Frame;
using HahaFrame.Services.Globals;
using HahaFrame.Web.Models;

namespace HahaFrame.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly IGlobalService _globalService;
        private readonly IFrameService _frameService;

        public CommonController(IGlobalService globalService, IFrameService frameService)
        {
            _globalService = globalService;
            _frameService = frameService;
        }

        [Route("announcement")]
        [ChildActionOnly]
        public ActionResult Announcement()
        {
            return Content(_globalService.GetGlobalMessage("PublicMessage"));
        }

        [ChildActionOnly]
        public ActionResult TopCategories()
        {
            return View(_frameService.GetMainCategories());
        }

        [ChildActionOnly]
        public ActionResult WidgetPopular()
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName("popular");
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetFeaturedFrames(Request.UserHostAddress, null, 1, int.Parse(ConfigurationManager.AppSettings["RelatedFramesSidebar"]));

            return View("WidgetSidebar", model);
        }

        [ChildActionOnly]
        public ActionResult WidgetRecent()
        {
            var model = new CategoryListModel();
            var categroy = _frameService.GetCategoryByName("recent");
            model.MetaDescription = categroy.MetaDescription;
            model.Title = categroy.Name;
            model.WebName = categroy.WebName;

            model.Frames = _frameService.GetFeaturedFrames(Request.UserHostAddress, null, 1, int.Parse(ConfigurationManager.AppSettings["RelatedFramesSidebar"]));

            return View("WidgetSidebar", model);
        }
	}
}