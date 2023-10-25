
using ControlsTools_WebApi.Models;
using ControlsTools_WebApi.Services.FerramentaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlsTools_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerramentasController : ControllerBase
    {
        private readonly IFerramentaService _ferramentaService;

        public FerramentasController(IFerramentaService ferramentaService)
        {
            _ferramentaService = ferramentaService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ferramenta>>> ListarFerramentas()
        {   
            return await _ferramentaService.ListarFerramentas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ferramenta>>> BuscarFerramentaPorId(int id)
        {
            var ferramenta =  await _ferramentaService.BuscarFeramentaPorId(id);

            if (ferramenta is null)
                return NotFound("Esta ferramenta não foi encontrada, verifique o número do Id");

            return Ok(ferramenta);
        }

        [HttpPost]
        public async Task<ActionResult<List<Ferramenta>>> CadastrarFerramenta(Ferramenta ferramenta)
        {
            var result = await _ferramentaService.CadastrarFerramenta(ferramenta);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Ferramenta>>> EditarFerramenta(int id, Ferramenta request)
        {
            var result = await _ferramentaService.EditarFerramenta(id, request);
            if (result is null)
                return NotFound("Ferramenta não encontrada.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Ferramenta>>> ExlcuirFerramenta(int id)
        {
            var result = await _ferramentaService.ExcluirFerramenta(id);
            if (result is null)
                return NotFound("Ferramenta não encontrada.");

            return Ok(result);
        }

    }
}
