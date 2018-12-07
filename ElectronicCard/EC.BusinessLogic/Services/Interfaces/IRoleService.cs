using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(Role item);
        void DeleteRole(int? id);
    }
}
