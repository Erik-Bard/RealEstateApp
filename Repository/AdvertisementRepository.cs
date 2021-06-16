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
    public class AdvertismentRepository : RepositoryBase<Advertisment>, IAdvertismentRepository
    {
        public AdvertismentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Advertisment> GetAllAdvertisments(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.PropertyType)
            .ToList();

        public Advertisment GetAdvertisment(Guid advertisementId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(advertisementId), trackChanges)
                .FirstOrDefault();
                

        public void CreateAdvertisment(Advertisment advertisment) =>
            Create(advertisment);
    }
}
