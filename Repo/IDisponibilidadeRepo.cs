using ClassScheduler.Models;

namespace ClassScheduler.Repo
{
    public interface IDisponibilidadeRepo
    {
        Task<Professor> AdicionarProfAsync(Professor professor);
    }
}
