namespace Checkpoint03API.Model
{
    public interface IStatusRepository
    {
        public Status? ObterPorId(int id);
        public IEnumerable<Status> Listar();
        public void Cadastrar(Status status);
        public void Atualizar(Status status);
        public void Remover(Status status);
    }
}
