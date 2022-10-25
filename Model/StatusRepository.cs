namespace Checkpoint03API.Model
{
    public class StatusRepository : IStatusRepository
    {
        private readonly StatusApiDbContext _context;

        public StatusRepository(StatusApiDbContext context)
        {
            _context = context;
        }

        public void Atualizar(Status status)
        {
            Status statusDB = ObterPorId(status.Id);
            statusDB.Nome = status.Nome;
            statusDB.Descricao = status.Descricao;

            _context.SaveChanges();
        }

        public void Cadastrar(Status status)
        {
            _context.Status.Add(status);

            _context.SaveChanges();
        }

        public IEnumerable<Status> Listar()
        {
            return _context.Status.OrderBy(c => c.Nome);
        }

        public Status? ObterPorId(int id)
        {
            return _context.Status.FirstOrDefault(c => c.Id == id);
        }

        public void Remover(Status status)
        {
            _context.Status.Remove(status);

            _context.SaveChanges();
        }
    }
}
