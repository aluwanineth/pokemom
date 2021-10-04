using Pokemom.Api.Core.Features.GetPokemomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Features.SearchPokemom
{
    public class SearchPokemomResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public PokemomData Results { get; set; }
    }
}
