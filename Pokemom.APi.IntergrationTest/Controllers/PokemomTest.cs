using Newtonsoft.Json;
using Pokemom.Api;
using Pokemom.Api.Core.Features.GetPokemomDetail;
using Pokemom.Api.Core.Features.GetPokemomList;
using Pokemom.Api.Core.Features.SearchPokemom;
using Pokemom.API.IntegrationTest.Base;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pokemom.APi.IntergrationTest.Controllers
{
    public class PokemomTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public PokemomTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsGetPokemomListSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Pokemoms/getPokemomList?offset=100&limit=100");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var pokemoms = JsonConvert.DeserializeObject<GetPokemomResponse>(responseString);
            pokemoms.results.Count.ShouldBe(100);
            pokemoms.ShouldBeOfType<GetPokemomResponse>();


        }

        [Fact]
        public async Task ReturnsGetPokemomDetailSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Pokemoms/getPokemomDetail?pokeId=100&name=exeggcute");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GetPokemomDetailResponse>(responseString);
            Assert.Equal(5, result.Results.Height);
            Assert.Equal("exeggcute", result.Results.Name);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnsSearchForPokemomSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/Pokemoms/searchForPokemom?name=exeggcute");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SearchPokemomResponse>(responseString);

            Assert.Equal("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/102.png", result.Results.ImageUrl);
            Assert.Equal("exeggcute", result.Results.Name);
            Assert.NotNull(result);
        }
    }
}
