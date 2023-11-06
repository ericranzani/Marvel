using MarvelApi.Dtos;
using MarvelApi.Modals;

namespace MarvelApi.Interface
{
    public interface IMarvelApi
    {
        Task<ResponseGenerico<HeroiModal>> BuscarHeroiPorNome(string nome);
    }
}
