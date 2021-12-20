using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.GetAllMotivoComum
{
    public interface IGetAllMotivoComum
    {
        Task<object> Execute();
    }
}
