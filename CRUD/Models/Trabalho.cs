namespace CRUD.Models
{
    public class Trabalho
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public List<Secao> Secoes { get; set; } = new List<Secao>();
    }
}
