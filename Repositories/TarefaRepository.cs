using Microsoft.EntityFrameworkCore;
using trilha_net_api_desafio.Model;

namespace trilha_net_api_desafio.Repositories;

public class TarefaRepository : ITarefa
{
    public readonly DBAppContext _context;

    public TarefaRepository(DBAppContext context)
    {

        _context = context;

    }

    public async Task<IEnumerable<Tarefa>> Get()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public async Task<Tarefa> Get(int id)
    {
        return await _context.Tarefas.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Tarefa>> Get(string titulo)
    {
        return await _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToListAsync();
    }


    public async Task<List<Tarefa>> Get(bool status)
    {
        return await _context.Tarefas.Where(t => t.Status == status).ToListAsync();
    }

    public async Task<List<Tarefa>> Get(DateTime data)
    {
        return await _context.Tarefas.Where(t => t.Data == data).ToListAsync();
    }

    public async Task<Tarefa> Create(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }


    public async Task Update(Tarefa tarefa)
    {
        _context.Entry(tarefa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
                        
            _context.Remove(tarefa);
            await _context.SaveChangesAsync();
}

}

