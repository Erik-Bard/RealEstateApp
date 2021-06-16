using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Comment> GetAllComments(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderByDescending(e => e.CreatedOn)
            .ToList();


        public IEnumerable<Comment> GetCommentsByAdvertisment(bool trackChanges, Guid advertismentId) =>
            FindAll(trackChanges)
            .Where(e => e.AdvertismentId == advertismentId)
            .OrderByDescending(e => e.CreatedOn)
            .ToList();

        public IEnumerable<Comment> GetCommentsByUserId(bool trackChanges, string userId) =>
            FindAll(trackChanges)
            .Where(e => e.UserId == userId)
            .OrderByDescending(e => e.CreatedOn)
            .ToList();

        public void CreateComment(Comment comment) =>
            Create(comment);

    }
}
