using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using trilha_net_api_desafio.Model;
using trilha_net_api_desafio.Repositories;

namespace trilha_net_api_desafio.Controllers;

[Route("v1/tarefa")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly ITarefa _context;

    public TarefaController(ITarefa context)
    {
        _context = context;
    }

    [HttpGet]
    public Task<IEnumerable<Tarefa>> Get()
    {
        return _context.Get();
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tarefa>> Get(int id)
    {
        
        var tarefa = await _context.Get(id);

        if(tarefa != null) { return Ok(tarefa); }

        return BadRequest("Id não localizado");
    }


    [HttpGet("{titulo}")]
    public async Task<IActionResult> Get(string titulo)
    {
        var tarefas = await _context.Get(titulo);
        if (tarefas != null && tarefas.Count > 0)
        {
            return Ok(tarefas);
        }
        return BadRequest("Tarefa não localizada");
        
    }

    [HttpGet("byDate")]
    public async Task<IActionResult> Get(DateTime data)
    {
        var tarefas = await _context.Get(data);
        return Ok(tarefas);
    }


    [HttpGet("{status:bool}")]
    public async Task<ActionResult<Tarefa>> Get(bool status)
    {
        var tarefas = await _context.Get(status);
        return Ok(tarefas);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Tarefa tarefa)
    {
        await _context.Update(tarefa);
        return Ok("Tarefa atualizada");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var tarefaRemover = await _context.Get(id);

        if (tarefaRemover != null)
        {
            await _context.Delete(id);
            return Ok("Tarefa Removida");

        }
        return BadRequest("Tarefa inválida ou não pode ser apagada no momento");
    }

    [HttpPost]
    public async Task<ActionResult> Post(Tarefa tarefa)
    {
        await _context.Create(tarefa);
        return Ok("Tarefa Criada");
    }

}

  
