using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers.Request.ConsultaPublica
{
    public class ConsultaPublicaRequestUpdate
    {
        public int Id { get; set; }
        public int NumConsulta { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public string Objeto { get; set; }
        public string HoraResposta { get; set; }
        public string DataResposta { get; set; }
        public AnexoRequestCreate Anexo { get; set; }
    }
}
