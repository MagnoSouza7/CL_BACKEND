using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers.Request.ConsultaPublica
{
    public class ConsultaPublicaFiltroRequest
    {
        public int? Id { get; set; }
        public int? NumConsulta { get; set; }
        public int? ClienteId { get; set; }
        public int? EmpresaId { get; set; }
        public string DataRespostaInicio { get; set; }
        public string DataRespostaFinal { get; set; }
    }
}
