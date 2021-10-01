using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Features.GetPokemomDetail
{
    public class GetPokemomDetailResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public GetPokemomDetailVmResponse Results { get; set; }
    }
}
