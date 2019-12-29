using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;
using HahaFrame.Web.Infrastructure;

namespace HahaFrame.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);



            routes.MapRoute("Faq",              "faq",                                          new { controller = "Home", action = "Faq" });
            routes.MapRoute("Terms",            "terms",                                        new { controller = "Home", action = "StaticPageView" });
            routes.MapRoute("Privacy",          "privacy",                                      new { controller = "Home", action = "StaticPageView" });
            routes.MapRoute("StaticPageView",   "pages/{webName}",                              new { controller = "Home", action = "StaticPageView" });

            routes.MapRoute("FrameReport",      "{categoryWebName}/{frameId}_{webName}/report", new { controller = "Home", action = "FrameReport" }, new {frameId = @"\d+" });
            routes.MapRoute("FrameVote",        "{categoryWebName}/{frameId}_{webName}/vote",   new { controller = "Home", action = "FrameVote" }, new {frameId = @"\d+" });
            routes.MapRoute("FrameView",        "{categoryWebName}/{frameId}_{webName}",        new { controller = "Home", action = "FrameView" }, new {frameId = @"\d+" });
            routes.MapRoute("Featured",         "featured",                                     new { controller = "Home", action = "CategoryListFeatured" });
            routes.MapRoute("Newest",           "newest",                                       new { controller = "Home", action = "CategoryListNewest" });
            routes.MapRoute("Popular",          "popular",                                      new { controller = "Home", action = "CategoryListPopular" });
            routes.MapRoute("CategoryList",     "{webName}",                                    new { controller = "Home", action = "CategoryList" });


            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("Base", "{controller}/{action}");
        }
    }
}
