using Pokemom.Api.Core.Features.GetPokemomDetail;
using Pokemom.Api.Core.Features.GetPokemomList;
using Pokemom.Api.Core.Features.SearchPokemom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Services
{
    public interface IPokemomService
    {
        Task<GetPokemomDetailResponse> GetPokemomDetail(string pokeId, string name);
        Task<GetPokemomResponse> GetPokemomListFromApi(int offset, int limit);
        Task<SearchPokemomResponse> SearchForPokemom(string name);
    }
}
