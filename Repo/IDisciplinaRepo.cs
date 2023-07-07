using ClassScheduler.Models;

namespace ClassScheduler.Repo
{
    public interface IDisciplinaRepo
    {
        Task<Disciplina> ListarPorIdAsync(int id);
        Task<List<Disciplina>> BuscarTodosAsync();
        Task<Disciplina> AdicionarAsync(Disciplina disciplina);
        Task<Disciplina> EditarAsync(Disciplina disciplina);
        Task<bool> ApagarAsync(int id);
        Task<List<Disciplina>> BuscarTodosComCursoAsync();
    }
}
