using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoComum.GetByIdMotivoComum
{
    public interface IGetByIdMotivoComum
    {
        Task<object> Execute(int id);
    }
}
