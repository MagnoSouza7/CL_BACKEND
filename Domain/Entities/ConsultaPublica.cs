using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ConsultaPublica : Entity
    {
        public int NumConsulta { get; set; }
        public Cliente Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public string Objeto { get; set; }
        public DateTime DataResposta { get; set; }
        public Anexo Anexo { get; set; }
    }
}
