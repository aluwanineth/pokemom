using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Contracts.Services;
using Pokemom.Api.Core.Features.GetPokemomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemomsController : ControllerBase
    {
        private readonly IGetPokemomListService _getPokemomList;
        private readonly IGetPokemomDetailService _getPokemomDetailService;

        public PokemomsController(IGetPokemomListService getPokemomList, IGetPokemomDetailService getPokemomDetailService)
        {
            _getPokemomDetailService = getPokemomDetailService;
            _getPokemomList = getPokemomList;
        }

        [HttpGet("getPokemomList", Name = "GetPokemomList")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<GetPokemomResponse>>> GetPokemomList(int offset = 100, int limit = 100)
        {
            var res = await _getPokemomList.GetPokemomList(offset, limit);
            return Ok(res);
        }

        [HttpGet("getPokemomDetail", Name = "GetPokemomDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<GetPokemomResponse>>> GetPokemomDetail(string pokeId, string name)
        {
            var res = await _getPokemomDetailService.GetPokemomDetail(pokeId,name);
            return Ok(res);
        }


    }
}
