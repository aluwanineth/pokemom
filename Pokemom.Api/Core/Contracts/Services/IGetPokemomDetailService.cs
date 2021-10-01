using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Features.GetPokemomDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Services
{
    public interface IGetPokemomDetailService
    {
        Task<GetPokemomDetailResponse> GetPokemomDetail(string pokeId, string name);
    }
}
