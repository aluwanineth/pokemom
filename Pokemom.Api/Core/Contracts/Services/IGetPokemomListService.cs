using Pokemom.Api.Core.Features.GetPokemomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Contracts.Services
{
    public interface IGetPokemomListService
    {
        Task<GetPokemomResponse> GetPokemomList(int offset, int limit);

    }
}
