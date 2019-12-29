using System;
using System.Collections.Generic;
using System.Linq;
using HahaFrame.Data.Domain;
using HahaFrame.Data.Repository;
using PagedList;

namespace HahaFrame.Services.Frame
{
    public class FrameService : IFrameService
    {
        private readonly IRepository<Data.Domain.Frame> _frameRepository;
        private readonly IRepository<FrameCategory> _frameCategoryRepository;
        private readonly IRepository<FrameView> _frameViewRepository;
        private readonly IRepository<FrameVote> _frameVoteRepository;
        private readonly IRepository<FlaggedContent> _flaggedContentRepository;

        public FrameService(IRepository<Data.Domain.Frame> frameRepository, IRepository<FrameCategory> frameCategoryRepository, IRepository<FrameView> frameViewRepository,
            IRepository<FrameVote> frameVoteRepository, IRepository<FlaggedContent> flaggedContentRepository)
        {
            _frameRepository = frameRepository;
            _frameCategoryRepository = frameCategoryRepository;
            _frameViewRepository = frameViewRepository;
            _frameVoteRepository = frameVoteRepository;
            _flaggedContentRepository = flaggedContentRepository;
        }

        public FrameCategory GetCategoryByName(string webName)
        {
            var query = _frameCategoryRepository.Table;

            query = from t in query
                    where !t.Deleted && t.WebName.Equals(webName, StringComparison.CurrentCultureIgnoreCase)
                    select t;

            return query.FirstOrDefault();
        }

        public IPagedList<FrameCategory> GetCategories(int pageIndex, int pageSize)
        {
            var query = _frameCategoryRepository.Table;

            query = from t in query
                    where !t.Deleted
                    orderby t.Name ascending
                    select t;

            return new PagedList<FrameCategory>(query, pageIndex, pageSize);
        }

        public IList<FrameCategory> GetMainCategories()
        {
            var query = _frameCategoryRepository.Table;

            query = from t in query
                    where !t.Deleted && t.ParentCategoryId == null && !t.Special
                    select t;

            return query.ToList();
        }

        public IPagedList<Data.Domain.Frame> GetFramesByCategory(int categoryId, string ipAddress, int? userId, int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && t.CategoryId == categoryId && t.Active
                    orderby t.DateUploaded descending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            foreach (var frame in pagedList)
            {
                _frameViewRepository.Insert(new FrameView
                {
                    DateVisited = DateTime.Now,
                    FrameId = frame.FrameId,
                    IPAddress = ipAddress,
                    Type = 0,
                    UserId = userId
                });
            }

            return pagedList;
        }

        public IPagedList<Data.Domain.Frame> GetRecentFrames(string ipAddress, int? userId, int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && t.Active
                    orderby t.DateUploaded descending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            foreach (var frame in pagedList)
            {
                _frameViewRepository.Insert(new FrameView
                {
                    DateVisited = DateTime.Now,
                    FrameId = frame.FrameId,
                    IPAddress = ipAddress,
                    Type = 0,
                    UserId = userId
                });
            }

            return pagedList;
        }

        public IPagedList<Data.Domain.Frame> GetFramesPendingApproval(int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && !t.Active
                    orderby t.DateUploaded ascending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            return pagedList;
        }

        public IPagedList<Data.Domain.Frame> GetPopularFrames(string ipAddress, int? userId, int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && t.Active
                    orderby t.FrameViews descending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            foreach (var frame in pagedList)
            {
                _frameViewRepository.Insert(new FrameView
                {
                    DateVisited = DateTime.Now,
                    FrameId = frame.FrameId,
                    IPAddress = ipAddress,
                    Type = 0,
                    UserId = userId
                });
            }

            return pagedList;
        }

        public IPagedList<Data.Domain.Frame> GetFeaturedFrames(string ipAddress, int? userId, int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && t.Featured && t.Active
                    orderby t.DateUploaded descending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            foreach (var frame in pagedList)
            {
                _frameViewRepository.Insert(new FrameView
                {
                    DateVisited = DateTime.Now,
                    FrameId = frame.FrameId,
                    IPAddress = ipAddress,
                    Type = 0,
                    UserId = userId
                });
            }

            return pagedList;
        }

        public IPagedList<Data.Domain.Frame> GetFramesByUser(int userId, string ipAddress, int pageIndex, int pageSize)
        {
            var query = _frameRepository.Table;

            query = from t in query
                    where !t.Deleted && t.UserId == userId
                    orderby t.DateUploaded descending
                    select t;

            var pagedList = new PagedList<Data.Domain.Frame>(query, pageIndex, pageSize);

            foreach (var frame in pagedList)
            {
                _frameViewRepository.Insert(new FrameView
                {
                    DateVisited = DateTime.Now,
                    FrameId = frame.FrameId,
                    IPAddress = ipAddress,
                    Type = 0,
                    UserId = userId
                });
            }

            return pagedList;
        }

        public Data.Domain.Frame GetFrameByIdForDisplay(int frameId, int? userId, string ipAddress)
        {
            var frame = _frameRepository.GetById(frameId);
            if (!frame.Active)
                return null;

            _frameViewRepository.Insert(new FrameView
            {
                DateVisited = DateTime.Now,
                FrameId = frame.FrameId,
                IPAddress = ipAddress,
                Type = 1,
                UserId = userId
            });

            return frame;
        }

        public void InsertFrame(Data.Domain.Frame frame)
        {
            frame.DateUploaded = DateTime.Now;
            frame.Deleted = false;

            _frameRepository.Insert(frame);
        }

        public void AddFrameVote(int frameId, byte voteValue, int userId, string ipAddress)
        {
            var existingVote = _frameVoteRepository.Table.FirstOrDefault(t => t.FrameId == frameId && t.UserId == userId);
            if (existingVote != null)
            {
                existingVote.VoteValue = voteValue;
                existingVote.IPAddress = ipAddress;

                _frameVoteRepository.Update(existingVote);
            }
            else
            {
                var vote = new FrameVote
                {
                    DatePosted = DateTime.Now,
                    Deleted = false,
                    FrameId = frameId,
                    IPAddress = ipAddress,
                    UserId = userId,
                    VoteValue = voteValue
                };

                _frameVoteRepository.Insert(vote);
            }
        }

        public void DeleteFrame(int frameId)
        {
            var frame = _frameRepository.GetById(frameId);
            if (frame != null)
            {
                frame.Deleted = true;
                _frameRepository.Update(frame);
            }
        }

        public void ApproveFrame(int frameId)
        {
            var frame = _frameRepository.GetById(frameId);
            if (frame != null)
            {
                frame.Active = true;
                frame.DateUploaded = DateTime.Now;
                _frameRepository.Update(frame);
            }
        }

        public void UpdateFrame(int frameId, string title, string description, string webName, int? categoryId)
        {
            var frame = _frameRepository.GetById(frameId);
            if (frame != null)
            {
                if (!string.IsNullOrEmpty(title))
                    frame.Title = title;

                if (!string.IsNullOrEmpty(description))
                    frame.MetaDescription = description;

                if (!string.IsNullOrEmpty(webName))
                    frame.WebName = webName;

                if (categoryId.HasValue)
                    frame.CategoryId = categoryId.Value;
                
                _frameRepository.Update(frame);
            }
        }

        public void FlagFrame(FlaggedContent flag)
        {
            _flaggedContentRepository.Insert(flag);
        }
    }
}
