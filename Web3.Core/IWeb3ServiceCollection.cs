using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3
{
  public interface IWeb3ServiceCollection : IServiceCollection { }
  public class Web3ServiceCollection : ServiceCollection, IWeb3ServiceCollection { }
}