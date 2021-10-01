using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Features.GetPokemomList
{
    public class GetPokemomResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PokemomData> results { get; set; }
    }
}
