using trilha_net_api_desafio.Model;

namespace trilha_net_api_desafio.Repositories;

public interface ITarefa
{
    Task<IEnumerable<Tarefa>> Get();
    Task<Tarefa> Get(int id);

    Task<List<Tarefa>> Get(string titulo);
    Task<List<Tarefa>> Get(DateTime data);
    Task<List<Tarefa>> Get(bool status);
    Task<Tarefa> Create(Tarefa tarefa);
    Task Delete(int id);
    Task Update(Tarefa tarefa);

}
