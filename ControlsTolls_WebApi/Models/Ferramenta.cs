namespace ControlsTools_WebApi.Models
{
    public class Ferramenta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime? DataColeta { get; set; } 
        public DateTime? DataDevolucao { get; set; } 
    }
}
