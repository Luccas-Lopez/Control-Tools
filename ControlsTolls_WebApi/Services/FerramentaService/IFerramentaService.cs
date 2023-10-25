namespace ControlsTools_WebApi.Services.FerramentaService
{
    public interface IFerramentaService
    {
        Task<Ferramenta?> BuscarFeramentaPorId(int id);
        Task<List<Ferramenta>?> CadastrarFerramenta(Ferramenta ferramenta);
        Task<List<Ferramenta>?> EditarFerramenta(int id, Ferramenta request);
        Task<List<Ferramenta>?> ExcluirFerramenta(int id);
        Task<List<Ferramenta>> ListarFerramentas();
    }
}
