using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments(bool trackChanges);

        IEnumerable<Comment> GetCommentsByAdvertisment(bool trackChanges, Guid advertismentId);
        IEnumerable<Comment> GetCommentsByUserId(bool trackChanges, string userId);

        void CreateComment(Comment comment);
    }
}
