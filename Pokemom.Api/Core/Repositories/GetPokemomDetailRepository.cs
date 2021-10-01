using Microsoft.Extensions.Options;
using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Features.GetPokemomDetail;
using Pokemom.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pokemom.Api.Core.Repositories
{
    public class GetPokemomDetailRepository : IGetPokemomDetailRepository
    {
        private readonly ApiResource _apiResource;
        public GetPokemomDetailRepository(IOptions<ApiResource> apiResource)
        {
            _apiResource = apiResource.Value;
        }
        public async Task<GetPokemomDetailVm> GetPokemomDetail(string pokeId)
        {
            var apiResults = new GetPokemomDetailVm();


            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(_apiResource.BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string endpoint = string.Format("{0}/{1}/", _apiResource.EndPoint,pokeId);
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    apiResults = await response.Content.ReadAsAsync<GetPokemomDetailVm>();
                }
                else
                {
                    throw new Exception(response.Content.ToString());
                }
            }
            return apiResults;
        }
    }
}
