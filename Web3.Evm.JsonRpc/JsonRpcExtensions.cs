using ChainSafe.GamingWeb3.Build;
using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3.EVM.JsonRpc
{
  public static class JsonRpcExtensions
  {
    /// <summary>
    /// Binds JSON RPC implementation of EVM Provider to Web3
    /// </summary>
    public static void UseJsonRpcProvider(this IWeb3ServiceCollection serviceCollection, JsonRpcProviderSettings settings)
    {
      serviceCollection.AddSingleton(settings);
      serviceCollection.AddSingleton<IEvmProvider, JsonRpcProvider>();
    }
    
    /// <summary>
    /// Binds JSON RPC implementation of EVM Wallet to Web3
    /// </summary>
    public static void UseJsonRpcWallet(this IWeb3ServiceCollection serviceCollection, JsonRpcWalletSettings settings)
    {
      serviceCollection.AddSingleton(settings);
      serviceCollection.AddSingleton<IEvmWallet, JsonRpcWallet>();
    }
  }
}