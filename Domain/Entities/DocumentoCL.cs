using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class DocumentoCL: Entity
    {
        public string Descricao { get; set; }

        public Anexo Anexo { get; set; }
    }
}
