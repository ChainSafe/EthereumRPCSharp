using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3.NetCore;

public static class NetCoreEnvironmentExtensions
{
  public static void UseNetCoreEnvironment(this IWeb3ServiceCollection serviceCollection)
  {
    serviceCollection.AddSingleton<IWeb3Environment, NetCoreEnvironment>();
  }
}