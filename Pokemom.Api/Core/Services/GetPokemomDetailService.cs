using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Contracts.Services;
using Pokemom.Api.Core.Features.GetPokemomDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Services
{
    public sealed class GetPokemomDetailService : IGetPokemomDetailService
    {
        private readonly IGetPokemomDetailRepository _getPokemomDetailRepository;

        public GetPokemomDetailService(IGetPokemomDetailRepository getPokemomDetailRepository)
        {
            _getPokemomDetailRepository = getPokemomDetailRepository;
        }
        public async Task<GetPokemomDetailResponse> GetPokemomDetail(string pokeId, string name)
        {
            GetPokemomDetailResponse result = new();
            var pokemom = await _getPokemomDetailRepository.GetPokemomDetail(pokeId);

            if(pokemom != null)
            {
                GetPokemomDetailVmResponse getPokemomDetailVmResponse = new()
                {
                    Sprites = pokemom.Sprites,
                    ImageUri = pokemom.Sprites.FrontDefault.AbsoluteUri,
                    Species = pokemom.Species,
                    Height = pokemom.Height,
                    Stat = pokemom.Stats,
                    Name = name
                };
                result.Message = "Successfully retrieve pokemom detail";
                result.Status = "200";
                result.Results = getPokemomDetailVmResponse;
            }
            return result;
        }
    }
}
