using ClassScheduler.Models;

namespace ClassScheduler.Repo
{
    public interface ICursoRepo
    {
        Task<Curso> ListarPorIdAsync(int id);
        Task<List<Curso>> BuscarTodosAsync();
        Task<Curso> AdicionarAsync(Curso curso);
        Task<Curso> AtualizarAsync(Curso curso);
        Task<bool> ApagarAsync(int id);
    }
}
