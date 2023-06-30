using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Repo
{
    public class ProfessorRepo : IProfessorRepo
    {
        private readonly ApplicationDbContext _context;
        public ProfessorRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Professor> AdicionarAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public Task<bool> ApagarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> AtualizarAsync(Professor professor)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Professor>> BuscarTodosAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public Task<Professor> ListarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
