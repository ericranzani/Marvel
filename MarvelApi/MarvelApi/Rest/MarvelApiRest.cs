using MarvelApi.Dtos;
using MarvelApi.Interface;
using MarvelApi.Modals;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MarvelApi.Rest
{
    public class MarvelApiRest : IMarvelApi
    {   
        public async Task<ResponseGenerico<HeroiModal>> BuscarHeroiPorNome(string nome)
        {
            var publicKey = "d4f79819885e182be6af62e415745c09";
            var privateKey = "f1c18c18032f94ed41d33909e82e7712b2fe6641";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var hash = CalculateHash(timestamp, privateKey, publicKey);
            var url = $"http://gateway.marvel.com/v1/public/characters?ts={timestamp}&apikey={publicKey}&hash={hash}&name={nome}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            var response = new ResponseGenerico<HeroiModal>();
            using (var client = new HttpClient())
            {
                var responseMarvelApi = await client.SendAsync(request);
                var contentResp = await responseMarvelApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<HeroiModal>(contentResp);

                if (responseMarvelApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseMarvelApi.StatusCode;
                    response.DadosRetorno = objResponse;
                } 
                else
                {
                    response.CodigoHttp = responseMarvelApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

        private string CalculateHash(string timestamp, string privateKey, string publicKey)
        {
            var input = timestamp + privateKey + publicKey;
            using (var md5 = MD5.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
