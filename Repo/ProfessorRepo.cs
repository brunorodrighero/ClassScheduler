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

        public async Task<bool> ApagarAsync(int id)
        {
            Professor professorDB = await ListarPorIdAsync(id);

            if (professorDB == null) throw new Exception("Houve um erro na deleção do(a) professor(a).");
            _context.Professores.Remove(professorDB);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Professor> EditarAsync(Professor professor)
        {
            Professor professorDB = await ListarPorIdAsync(professor.Id);

            if (professorDB == null) throw new Exception("Houve um erro ao editar os dados do(a) professor(a).");

            professorDB.Nome = professor.Nome;
            professorDB.Sobrenome = professor.Sobrenome;
            professorDB.Telefone = professor.Telefone;
            professorDB.Email = professor.Email;
            professorDB.Titulacao = professor.Titulacao;
            professorDB.DataAtualizacao = DateTime.Now;

            _context.Professores.Update(professorDB);
            await _context.SaveChangesAsync();

            return professorDB;
        }

        public async Task<List<Professor>> BuscarTodosAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task<Professor> ListarPorIdAsync(int id)
        {
            return await _context.Professores.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Professor não encontrado.");
        }
    }
}
