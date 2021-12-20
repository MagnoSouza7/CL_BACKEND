using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Portal.GetAll
{
    public interface IGetAllPortal
    {
        Task<object> Execute();
    }
}
