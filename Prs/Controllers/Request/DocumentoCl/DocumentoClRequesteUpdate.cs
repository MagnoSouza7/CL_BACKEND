using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers.Request.DocumentoCl
{
    public class DocumentoClRequesteUpdate
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public AnexoRequestCreate Anexo { get; set; }
    }
}
