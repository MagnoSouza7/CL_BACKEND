using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.ObterStatusDissidios
{
    public interface IObterStatusDissidios
    {
        Task<object> Execute();
    }
}
