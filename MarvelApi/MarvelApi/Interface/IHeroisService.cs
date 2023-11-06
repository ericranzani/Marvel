using MarvelApi.Dtos;
using MarvelApi.Modals;

namespace MarvelApi.Interface
{
    public interface IHeroisService
    {
        Task<ResponseGenerico<HeroiResponse>> BuscarHeroi(string nome);
    }
}
