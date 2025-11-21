using ProjetoIntegrador.Database;

namespace ProjetoIntegrador.Repositories.RepositoryBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoIntegradorDbContext _context;

        // As propriedades da interface são preenchidas com instâncias concretas dos repositórios
        // public IContaRepository Contas { get; private set; } // Exemplo
        public IMesaRepository Mesas { get; private set; }
        public IFuncionarioRepository Funcionario { get; private set; }

        public UnitOfWork(ProjetoIntegradorDbContext context)
        {
            _context = context;

            // Inicializa os repositórios, passando o MESMO DbContext para todos.
            // Isso é crucial para que todos trabalhem na mesma transação.
            // Contas = new ContaRepository(_context); // Exemplo

            Mesas = new MesaRepository(_context);
        }

        // <summary>
        // Comita a transação para o banco de dados.
        // </summary>
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // <summary>
        // Libera a conexão do DbContext quando a Unit of Work for descartada.
        // </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
