using Pokemom.Api.Core.Features.GetPokemomDetail;
using Pokemom.Api.Core.Features.GetPokemomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Repositories
{
    public interface IPokemomRepository
    {
        Task<GetPokemomDetailVm> GetPokemomDetail(string pokeId);
        Task<PokemomApiData> GetPokemomListFromApi(int offset, int limit);
        Task<Result> SearchForPokemom(string name);
    }
}
