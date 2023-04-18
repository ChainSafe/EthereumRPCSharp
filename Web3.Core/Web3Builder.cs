using System;
using ChainSafe.GamingWeb3.EVM;
using Microsoft.Extensions.DependencyInjection;

namespace ChainSafe.GamingWeb3
{
  /// <summary>
  /// Builder object for Web3. Used to configure set of services.
  /// </summary>
  public class Web3Builder
  {
    public delegate void ConfigureServicesDelegate(IWeb3ServiceCollection services);
    
    private readonly Web3ServiceCollection _serviceCollection;

    public Web3Builder()
    {
      _serviceCollection = new Web3ServiceCollection();
    }

    public Web3Builder Configure(ConfigureServicesDelegate configureMethod)
    {
      configureMethod(_serviceCollection);
      return this;
    }
    
    public Web3 Build()
    {
      var serviceProvider = _serviceCollection.BuildServiceProvider();
      var environment = AssertWeb3EnvironmentBound(serviceProvider);

      var web3 = new Web3
      {
        Environment = environment,
        EvmClient = serviceProvider.GetService<IEvmClient>()
      };

      return web3;
    }
    
    private IWeb3Environment AssertWeb3EnvironmentBound(IServiceProvider serviceProvider)
    {
      IWeb3Environment env;
      try
      {
        env = serviceProvider.GetRequiredService<IWeb3Environment>();
      }
      catch (InvalidOperationException e)
      {
        throw new Web3Exception($"{nameof(IWeb3Environment)} is a required service for Web3 to work.", e);
      }

      return env;
    }
  }
}