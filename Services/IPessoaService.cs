using APIListaContatos.Models;

namespace APIListaContatos.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetPessoas();
        Task<IEnumerable<Pessoa>> GetPessoasContatos();
        Task<Pessoa> GetPessoa(int id);
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);
    }
}
