using HahaFrame.Data.Domain;
using PagedList;

namespace HahaFrame.Web.Models
{
    public class CategoryListModel
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string WebName { get; set; }
        public IPagedList<Frame> Frames { get; set; }
    }
}