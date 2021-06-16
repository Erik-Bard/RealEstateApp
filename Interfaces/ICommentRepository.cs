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

        void CreateComment(Comment comment);
    }
}
