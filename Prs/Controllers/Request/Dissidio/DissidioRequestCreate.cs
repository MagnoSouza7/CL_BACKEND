namespace Prs.Controllers.Request.Dissidio
{
    public class DissidioRequestCreate
    {
        public int EstadoId { get; set; }
        public string DataBase { get; set; }
        public string DataUltima { get; set; }
        public decimal? PisoSalarial8h { get; set; }
        public decimal? PisoSalarial6h { get; set; }
        public decimal? Ticket8h { get; set; }
        public decimal? Ticket6h { get; set; }
        public decimal? BenefInd8h { get; set; }
        public decimal? BenefInd6h { get; set; }
        public decimal? Reajuste { get; set; }
        public string Observacoes { get; set; }
        public string VigenciaInicio { get; set; }
        public string VigenciaFinal { get; set; }
        public string Cnpj { get; set; }
        public string ConformeCargoFuncao { get; set; }
        public string Nome { get; set; }
        public string tipo { get; set; }
        public byte[] base64 { get; set; }

        public AnexoRequestCreate arquivo { get; set; }
        public string Atalho { get; set; }

    }
}
