using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.GetDissidioByEstadoId
{
    public interface IGetDissidioByEstadoId
    {
        Task<object> Execute(int id);
    }
}
