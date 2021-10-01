using Pokemom.Api.Core.Features.GetPokemomDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Repositories
{
    public interface IGetPokemomDetailRepository
    {
        Task<GetPokemomDetailVm> GetPokemomDetail(string pokeId);
    }
}
