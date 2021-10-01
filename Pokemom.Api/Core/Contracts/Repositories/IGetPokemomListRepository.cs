using Pokemom.Api.Core.Features.GetPokemomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Repositories
{
    public interface IGetPokemomListRepository
    {
        Task<PokemomApiData> GetPokemomListFromApi(int offset, int limit);
    }
}
