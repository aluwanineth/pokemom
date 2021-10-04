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
        private readonly IPokemomService _pokemomService;
       

        public PokemomsController(IPokemomService pokemomService)
        {
            _pokemomService = pokemomService;
        }

        /// <summary>
        /// Get Pokemom List
        /// </summary>
        /// <remarks>
        /// Sample value of message
        /// 
        /// [
        ///   {
        ///      "status": "200",
        ///      "message": "Successfully retrieve pokomom list",
        ///      "results": [
        ///      {
        ///        "name": "cubone",
        ///        "imageUrl": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/104.png",
        ///        "pokeUrl": "https://pokeapi.co/api/v2/pokemon/104/"
        ///      }
        ///     ]
        ///    }
        ///]
        ///     
        /// </remarks>

        [HttpGet("getPokemomList", Name = "GetPokemomList")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<GetPokemomResponse>>> GetPokemomList(int offset = 100, int limit = 100)
        {
            var res = await _pokemomService.GetPokemomListFromApi(offset, limit);
            return Ok(res);
        }

        /// <summary>
        /// Get Pokemom Detail
        /// </summary>
        /// <remarks>
        /// This will return pokemom details
        /// 
        ///     
        /// </remarks>

        [HttpGet("getPokemomDetail", Name = "GetPokemomDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<GetPokemomResponse>>> GetPokemomDetail(string pokeId, string name)
        {
            var res = await _pokemomService.GetPokemomDetail(pokeId,name);
            return Ok(res);
        }

        /// <summary>
        /// Search For Pokemom
        /// </summary>
        /// <remarks>
        /// Return a single pokemom with name and image
        /// 
        ///     {
        ///         "status": "200",
        ///         "message": "Seccessfully retrieve pokemom data",
        ///         "results": {
        ///             "name": "marowak",
        ///             "imageUrl": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/105.png",
        ///             "pokeUrl": "https://pokeapi.co/api/v2/pokemon/105/"
        ///         }
        ///     }
        ///     
        /// </remarks>

        [HttpGet("searchForPokemom", Name = "SearchForPokemom")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<GetPokemomResponse>>> SearchForPokemom(string name)
        {
            var res = await _pokemomService.SearchForPokemom(name);
            return Ok(res);
        }

    }
}
