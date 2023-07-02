using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Repo
{
    public class CursoRepo : ICursoRepo
    {
        private readonly ApplicationDbContext _context;
        public CursoRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Curso> AdicionarAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public Task<bool> ApagarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> EditarAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Curso>> BuscarTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public Task<Curso> ListarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
