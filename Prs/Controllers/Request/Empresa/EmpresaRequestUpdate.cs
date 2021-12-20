using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers.Request.Empresa
{
    public class EmpresaRequestUpdate
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public bool Ativo { get; set; }

    }
}
