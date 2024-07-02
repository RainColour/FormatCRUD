namespace CRUD.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
    }
}