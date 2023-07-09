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

        public async Task<bool> ApagarAsync(int id)
        {
            Curso cursoDB = await ListarPorIdAsync(id);

            if (cursoDB == null) throw new Exception("Houve um erro na deleção do Curso.");
            _context.Cursos.Remove(cursoDB);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Curso> EditarAsync(Curso curso)
        {
            Curso cursoDB = await ListarPorIdAsync(curso.Id);

            if (cursoDB == null) throw new Exception("Houve um erro ao editar os dados do Curso.");

            cursoDB.Nome = curso.Nome;
            cursoDB.Duracao = curso.Duracao;
            cursoDB.Descricao = curso.Descricao;
            cursoDB.DataAtualizacao = DateTime.Now;

            _context.Cursos.Update(cursoDB);
            await _context.SaveChangesAsync();

            return cursoDB;
        }

        public async Task<List<Curso>> BuscarTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> ListarPorIdAsync(int id)
        {
            return await _context.Cursos.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Curso não encontrado.");
        }
    }
}
