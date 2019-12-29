using HahaFrame.Data.Domain;

namespace HahaFrame.Services.StaticPages
{
    public partial interface IStaticPageService
    {
        StaticPage GetStaticPageByName(string name);

        StaticPage GetStaticPageById(int pageId);
    }
}
