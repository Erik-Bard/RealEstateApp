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
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Property> GetAllProperties(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.YearOfConstruction)
            .ToList();

        public Property GetProperty(Guid propertyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(propertyId), trackChanges)
                .SingleOrDefault();

        public void CreateProperty(Property property) =>
            Create(property);
    }
}
