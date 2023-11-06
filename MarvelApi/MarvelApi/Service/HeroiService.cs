using AutoMapper;
using MarvelApi.Dtos;
using MarvelApi.Interface;

namespace MarvelApi.Service
{
    public class HeroiService : IHeroisService
    {
        private readonly IMapper _mapper;
        private readonly IMarvelApi _marvelApi;

        public HeroiService(IMapper mapper, IMarvelApi marvelApi)
        {
            _mapper = mapper;
            _marvelApi = marvelApi;
        }

        public async Task<ResponseGenerico<HeroiResponse>> BuscarHeroi(string nome)
        {
            var heroi = await _marvelApi.BuscarHeroiPorNome(nome);
            return _mapper.Map<ResponseGenerico<HeroiResponse>>(heroi);
        }
    }
}
