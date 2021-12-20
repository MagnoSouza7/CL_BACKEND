using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Anexo.GetById
{
    public interface IGetByIdAnexo
    {
        Task<Domain.Entities.Anexo> Execute(int id);
    }
}
