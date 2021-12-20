using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.GetAll
{
    public interface IGetAllMotivoPerda
    {
        Task<object> Execute();
    }
}
