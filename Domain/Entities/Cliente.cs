namespace Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Cnpj { get; set; }
    }
}
