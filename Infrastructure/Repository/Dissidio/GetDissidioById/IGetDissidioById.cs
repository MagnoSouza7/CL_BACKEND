using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dissidio.GetDissidioById
{
    public interface IGetDissidioById
    {
        Task<object> Execute(int id);
    }
}
