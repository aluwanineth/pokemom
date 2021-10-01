using Microsoft.Extensions.Options;
using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Contracts.Services;
using Pokemom.Api.Core.Features.GetPokemomList;
using Pokemom.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Services
{
    public sealed class GetPokemomListService : IGetPokemomListService
    {
        private readonly IGetPokemomListRepository _getPokemomListRepository;
        private readonly ApiResource _apiResource;
        public GetPokemomListService(IGetPokemomListRepository getPokemomListRepository, IOptions<ApiResource> apiResource)
        {
            _getPokemomListRepository = getPokemomListRepository;
            _apiResource = apiResource.Value;
        }
        public async Task<GetPokemomResponse> GetPokemomList(int offset, int limit)
        {
            GetPokemomResponse result = new GetPokemomResponse();
            var pokemoms = await _getPokemomListRepository.GetPokemomListFromApi(offset, limit);

            List<PokemomData> pokemomsList = new List<PokemomData>();
            foreach(var pokemom in pokemoms.Results)
            {
                var pokeID = pokemom.Url.Substring(0, pokemom.Url.LastIndexOf('/')).Split('/').Last();
                PokemomData pokemomData = new()
                {
                    Name = pokemom.Name,
                    ImageUrl = string.Format("{0}{1}", _apiResource.ImageUrl, pokeID),
                    PokeUrl = pokemom.Url
                };
                pokemomsList.Add(pokemomData);
            }

            if (pokemomsList.Count > 0)
            {
                result.Status = "200";
                result.Message = "Successfully retrieve pokemoms";
                result.results = pokemomsList;
            }
            else 
            {
                result.Status = "404";
                result.Message = "Record not found";
                result.results = pokemomsList;
            }
            return result;
        }
    }
}
