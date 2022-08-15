using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIListaContatos.Models;

public class Contato
{
    [Key]
    public int ContatoId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(80)]
    public string? Conteudo { get; set; }

    public int PessoaId { get; set; }

    [JsonIgnore]
    public Pessoa? Pessoa { get; set; }
}
