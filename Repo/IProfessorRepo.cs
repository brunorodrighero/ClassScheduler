using ClassScheduler.Models;

namespace ClassScheduler.Repo
{
    public interface IProfessorRepo
    {
        Task<Professor> ListarPorIdAsync(int id);
        Task<List<Professor>> BuscarTodosAsync();
        Task<Professor> AdicionarAsync(Professor professor);
        Task<Professor> EditarAsync(Professor professor);
        Task<bool> ApagarAsync(int id);
    }
}
