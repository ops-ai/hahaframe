using System;
using System.Collections.Generic;
using HahaFrame.Data.Domain;
using PagedList;

namespace HahaFrame.Services.Frame
{
    public partial interface IFrameService
    {
        FrameCategory GetCategoryByName(string webName);
        IPagedList<Data.Domain.Frame> GetFeaturedFrames(string ipAddress, int? userId, int pageIndex, int pageSize);
        IPagedList<Data.Domain.Frame> GetRecentFrames(string ipAddress, int? userId, int pageIndex, int pageSize);
        IPagedList<Data.Domain.Frame> GetPopularFrames(string ipAddress, int? userId, int pageIndex, int pageSize);
        IPagedList<Data.Domain.Frame> GetFramesPendingApproval(int pageIndex, int pageSize);
        IPagedList<FrameCategory> GetCategories(int pageIndex, int pageSize);
        IList<FrameCategory> GetMainCategories();
        IPagedList<Data.Domain.Frame> GetFramesByCategory(int categoryId, string ipAddress, int? userId, int pageIndex, int pageSize);
        IPagedList<Data.Domain.Frame> GetFramesByUser(int userId, string ipAddress, int pageIndex, int pageSize);
        Data.Domain.Frame GetFrameByIdForDisplay(int frameId, int? userId, string ipAddress);
        void InsertFrame(Data.Domain.Frame frame);
        void AddFrameVote(int frameId, byte vote, int userId, string ipAddress);
        void DeleteFrame(int frameId);
        void ApproveFrame(int frameId);
        void UpdateFrame(int frameId, string title, string description, string webName, int? categoryId);
        void FlagFrame(FlaggedContent flag);
    }
}
