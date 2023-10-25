using ControlsTools_WebApi.Data;
using ControlsTools_WebApi.Models;

namespace ControlsTools_WebApi.Services.FerramentaService
{
    public class FerramentaService : IFerramentaService
    {
        private static List<Ferramenta> _Ferramentas = new List<Ferramenta> {
               new Ferramenta
                {   Id = 1,
                    Nome = "Chave de Fenda",
                    Descricao ="Black&Decker, avariada",
                    Status = "Disponível"
                },
                 new Ferramenta
                {   Id = 2,
                    Nome = "Chave Inglesa",
                    Descricao ="IronBest, nova chegada",
                    Status = "Disponível"
                },
                 new Ferramenta
                {   Id = 3,
                    Nome = "Martelo",
                    Descricao ="IronBest, seminovo",
                    Status = "Disponível"
                }
        };

        private readonly DataContext _context;

        public FerramentaService(DataContext context)
        {
                _context = context;
        }

        public async Task<Ferramenta?> BuscarFeramentaPorId(int id)
        {
            var ferramenta = await _context.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return null;

            return ferramenta;
        }

        public async Task<List<Ferramenta>?> CadastrarFerramenta(Ferramenta ferramenta)
        {
            _context.Add(ferramenta);
            await _context.SaveChangesAsync();
            return await _context.Ferramentas.ToListAsync();
        }

        public async Task<List<Ferramenta>?> EditarFerramenta(int id, Ferramenta request)
        {
            var ferramenta = await _context.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return null;

            ferramenta.Nome = request.Nome;
            ferramenta.Status = request.Status;
            ferramenta.Descricao = request.Descricao;
            ferramenta.DataColeta = request.DataColeta;
            ferramenta.DataDevolucao = request.DataDevolucao;

            await _context.SaveChangesAsync();

            return await _context.Ferramentas.ToListAsync();
        }

        public async Task<List<Ferramenta>?> ExcluirFerramenta(int id)
        {
            var ferramenta = await _context.Ferramentas.FindAsync(id);
            if (ferramenta is null)
                return null;

            _context.Remove(ferramenta);
            await _context.SaveChangesAsync();
            return await _context.Ferramentas.ToListAsync();
        }

        public async Task<List<Ferramenta>> ListarFerramentas()
        {
            var ferramentas = await _context.Ferramentas.ToListAsync();
            return ferramentas;
        }
    }
}
