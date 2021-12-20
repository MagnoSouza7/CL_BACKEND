using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers.Request.DocumentoCl
{
    public class DocumentoClRequesteCreate
    {
        public AnexoRequestCreate Anexo { get; set; }
        public string Descricao { get; set; }


    }
}
