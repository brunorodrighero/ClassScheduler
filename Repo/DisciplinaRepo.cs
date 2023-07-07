using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Repo
{
    public class DisciplinaRepo : IDisciplinaRepo
    {
        private readonly ApplicationDbContext _context;
        public DisciplinaRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Disciplina> AdicionarAsync(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<bool> ApagarAsync(int id)
        {
            Disciplina disciplinaDB = await ListarPorIdAsync(id);

            if (disciplinaDB == null) throw new Exception("Houve um erro na deleção da Disciplina.");
            _context.Disciplinas.Remove(disciplinaDB);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Disciplina> EditarAsync(Disciplina disciplina)
        {
            Disciplina disciplinaDB = await ListarPorIdAsync(disciplina.Id);

            if (disciplinaDB == null) throw new Exception("Houve um erro ao editar os dados da Disciplina.");

            disciplinaDB.Nome = disciplina.Nome;
            disciplinaDB.CargaHoraria = disciplina.CargaHoraria;
            disciplinaDB.Descricao = disciplina.Descricao;
            disciplinaDB.Creditos = disciplina.Creditos;
            disciplinaDB.DataAtualizacao = DateTime.Now;

            _context.Disciplinas.Update(disciplinaDB);
            await _context.SaveChangesAsync();

            return disciplinaDB;
        }

        public async Task<List<Disciplina>> BuscarTodosAsync()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task<Disciplina> ListarPorIdAsync(int id)
        {
            return await _context.Disciplinas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Disciplina>> BuscarTodosComCursoAsync()
        {
            return await _context.Disciplinas.Include(d => d.Curso).ToListAsync();
        }
    }
}
