using Microsoft.Extensions.Options;
using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Contracts.Services;
using Pokemom.Api.Core.Features.GetPokemomDetail;
using Pokemom.Api.Core.Features.GetPokemomList;
using Pokemom.Api.Core.Features.SearchPokemom;
using Pokemom.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Services
{
    public sealed class PokemomService : IPokemomService
    {
        private readonly IPokemomRepository _pokemomRepository;
        private readonly ApiResource _apiResource;

        public PokemomService(IPokemomRepository pokemomRepository, IOptions<ApiResource> apiResource)
        {
            _pokemomRepository = pokemomRepository;
            _apiResource = apiResource.Value;
        }
        public async Task<GetPokemomDetailResponse> GetPokemomDetail(string pokeId, string name)
        {
            GetPokemomDetailResponse result = new();
            var pokemom = await _pokemomRepository.GetPokemomDetail(pokeId);

            if (pokemom != null)
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

        public async Task<GetPokemomResponse> GetPokemomListFromApi(int offset, int limit)
        {
            GetPokemomResponse result = new GetPokemomResponse();
            var pokemoms = await _pokemomRepository.GetPokemomListFromApi(offset, limit);

            List<PokemomData> pokemomsList = new List<PokemomData>();
            foreach (var pokemom in pokemoms.Results)
            {
                var pokeID = pokemom.Url.Substring(0, pokemom.Url.LastIndexOf('/')).Split('/').Last();
                PokemomData pokemomData = new()
                {   
                    Name = pokemom.Name,
                    ImageUrl = string.Format("{0}{1}.png", _apiResource.ImageUrl, pokeID),
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

        public async Task<SearchPokemomResponse> SearchForPokemom(string name)
        {
            var pokemom = new SearchPokemomResponse();
            var result = await _pokemomRepository.SearchForPokemom(name);

            if(result != null)
            {
                var pokeID = result.Url.Substring(0, result.Url.LastIndexOf('/')).Split('/').Last();
                pokemom.Message = "Successfully retrieve pokemom data";
                pokemom.Status = "200";

                PokemomData pokemomData = new()
                { 
                    PokeUrl = result.Url,
                    Name = result.Name,
                    ImageUrl = string.Format("{0}{1}.png", _apiResource.ImageUrl, pokeID)
                };
                pokemom.Results = pokemomData; 
            }
            else
            {
                pokemom.Message = "pokemom not found";
                pokemom.Status = "404";
                pokemom.Results = null;
            }

            return pokemom;
        }
    }
}