using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Features.GetPokemomDetail
{
    public class GetPokemomDetailVmResponse
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public Sprites Sprites { get; set; }
        public Stat[] Stat { get; set; }
        public Species Species { get; set; }
        public int Height { get; set; }
        


    }
}
