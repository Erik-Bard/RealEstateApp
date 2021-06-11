using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces
{
    public interface IAdvertismentRepository
    {
        IEnumerable<Advertisment> GetAllAdvertisments(bool trackChanges);
        Advertisment GetAdvertisment(Guid advertismentId, bool trackChanges);
        void CreateAdvertisment(Advertisment advertisment);
    }
}
