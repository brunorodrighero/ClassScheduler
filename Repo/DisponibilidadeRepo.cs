using ClassScheduler.Data;
using ClassScheduler.Models;

namespace ClassScheduler.Repo
{
    public class DisponibilidadeRepo : IDisponibilidadeRepo
    {
        private readonly ApplicationDbContext _context;
        public DisponibilidadeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> AdicionarProfAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

    }
}
