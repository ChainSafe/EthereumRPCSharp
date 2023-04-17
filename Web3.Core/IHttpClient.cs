using System.Threading.Tasks;

namespace ChainSafe.GamingWeb3
{
  public interface IHttpClient
  {
    ValueTask<TResponse> Post<TRequest, TResponse>(string url, TRequest data);
  }
}