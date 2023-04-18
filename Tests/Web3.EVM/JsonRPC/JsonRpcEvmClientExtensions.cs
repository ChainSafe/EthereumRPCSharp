using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3.EVM.JsonRPC
{
  public static class JsonRpcEvmClientExtensions
  {
    /// <summary>
    /// Binds JSON RPC implementation of EVM Client to Web3
    /// </summary>
    public static void UseJsonRpcEvmClient(this IWeb3ServiceCollection serviceCollection, JsonRpcClientSettings settings)
    {
      serviceCollection.AddSingleton(settings);
      serviceCollection.AddSingleton<IEvmClient, JsonRpcEvmClient>();
      serviceCollection.AddSingleton<JsonRpcProvider>();
      serviceCollection.AddSingleton<JsonRpcSigner>();
    }
  }
}