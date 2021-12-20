using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.MotivoPerda.GetById
{
    public interface IGetByIdMotivoPerda
    {
        Task<object> Execute(int id);
    }
}
