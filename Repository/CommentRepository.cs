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
            .ToList();


        public void CreateComment(Comment comment) =>
            Create(comment);

    }
}
