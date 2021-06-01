using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties(bool trackChanges);
        Property GetProperty(Guid propertyId, bool trackChanges);
        void CreateProperty(Property property);
    }
}
