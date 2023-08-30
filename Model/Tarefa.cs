using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace trilha_net_api_desafio.Model;

public class Tarefa
{
    [Key]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? Data { get; set; }
    public bool Status { get; set; }
}
