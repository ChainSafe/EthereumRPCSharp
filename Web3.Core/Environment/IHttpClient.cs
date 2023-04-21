using System.Threading.Tasks;

namespace ChainSafe.GamingWeb3.Environment
{
  public interface IHttpClient
  {
    ValueTask<TResponse> Get<TResponse>(string url);
    ValueTask<TResponse> Post<TRequest, TResponse>(string url, TRequest data);
  }
}