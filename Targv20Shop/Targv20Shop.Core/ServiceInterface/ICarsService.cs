using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface ICarsService
    {
        Task<Cars> Edit(Guid id);
        Task<Cars> Add(CarsDto dto);
        Task<Cars> Update(CarsDto dto);
        Task<Cars> Delete(Guid id);
    }
}
