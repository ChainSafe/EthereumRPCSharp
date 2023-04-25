using ChainSafe.GamingWeb3.Build;
using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3.EVM.JsonRpc
{
  public static class JsonRpcExtensions
  {
    /// <summary>
    /// Binds JSON RPC implementation of EVM Provider to Web3
    /// </summary>
    public static void UseJsonRpcProvider(this IWeb3ServiceCollection serviceCollection, JsonRpcProviderConfiguration configuration)
    {
      serviceCollection.AddSingleton(configuration);
      serviceCollection.AddSingleton<IEvmProvider, JsonRpcProvider>();
    }
    
    /// <summary>
    /// Binds JSON RPC implementation of EVM Provider to Web3
    /// </summary>
    public static void UseJsonRpcProvider(this IWeb3ServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IEvmProvider, JsonRpcProvider>();
    }
    
    /// <summary>
    /// Configures JSON RPC implementation of EVM Provider
    /// </summary>
    public static void ConfigureJsonRpcProvider(this IWeb3ServiceCollection serviceCollection, JsonRpcProviderConfiguration configuration)
    {
      serviceCollection.AddSingleton(configuration);
    }
    
    /// <summary>
    /// Binds JSON RPC implementation of EVM Wallet to Web3
    /// </summary>
    public static void UseJsonRpcWallet(this IWeb3ServiceCollection serviceCollection, JsonRpcWalletConfiguration configuration)
    {
      serviceCollection.AddSingleton(configuration);
      serviceCollection.AddSingleton<IEvmWallet, JsonRpcWallet>();
    }
    
    /// <summary>
    /// Binds JSON RPC implementation of EVM Wallet to Web3
    /// </summary>
    public static void UseJsonRpcWallet(this IWeb3ServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IEvmWallet, JsonRpcWallet>();
    }
    
    /// <summary>
    /// Configures JSON RPC implementation of EVM Wallet
    /// </summary>
    public static void ConfigureJsonRpcWallet(this IWeb3ServiceCollection serviceCollection, JsonRpcWalletConfiguration configuration)
    {
      serviceCollection.AddSingleton(configuration);
    }
  }
}