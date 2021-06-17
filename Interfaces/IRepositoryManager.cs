using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryManager
    {
        IPropertyRepository Property { get; }
        IAdvertismentRepository Advertisment { get; }
        ICommentRepository Comment { get; }
        void Save();
    }
}
