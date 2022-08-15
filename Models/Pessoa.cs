using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIListaContatos.Models;

public class Pessoa
{
    public Pessoa()
    {
        Contatos = new Collection<Contato>();
    }

    [Key]
    public int PessoaId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    public int? Idade { get; set; }
    [StringLength(9)]
    public string? Sexo { get; set; }

    public ICollection<Contato>? Contatos { get; set; }
}
