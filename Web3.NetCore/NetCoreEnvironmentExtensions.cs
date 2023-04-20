using ChainSafe.GamingWeb3.Environment;
using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3.NetCore;

public static class NetCoreEnvironmentExtensions
{
  /// <summary>
  /// Sets up .NET Core environment for Web3
  /// </summary>
  public static void UseNetCoreEnvironment(this IWeb3ServiceCollection serviceCollection)
  {
    serviceCollection.AddSingleton<IWeb3Environment, NetCoreEnvironment>();
  }
}