namespace CRUD.Models
{
    public class Secao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
    }
}
