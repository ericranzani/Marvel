using MarvelApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MarvelApi.Controllers
{
    [ApiController]
    [Route("/v1/public/characters/")]
    public class HeroisController : ControllerBase
    {
        public readonly IHeroisService _heroisService;

        public HeroisController (IHeroisService heroisService)
        {
            _heroisService = heroisService;
        }

        [HttpGet("{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarHeroi([FromRoute] string nome)
        {
            var response = await _heroisService.BuscarHeroi(nome);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
    }
}
