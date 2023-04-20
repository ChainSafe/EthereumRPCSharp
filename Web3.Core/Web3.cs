using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Environment;
using ChainSafe.GamingWeb3.EVM;

namespace ChainSafe.GamingWeb3
{
  /// <summary>
  /// Facade for all Web3-related services
  /// </summary>
  public class Web3 : IDisposable
  {
    public IWeb3Environment Environment { get; internal set; }
    public IEvmProvider? EvmProvider { get; internal set; }
    public IEvmWallet? EvmWallet { get; internal set; }

    private bool _initialized;
    
    internal Web3() { }
    public void Dispose() => Terminate();

    public async ValueTask Initialize()
    {
      if (EvmProvider != null) await EvmProvider.Initialize();
      
      // todo initialize other components
      
      _initialized = true;
    }

    public void Terminate()
    {
      // todo
    }

  }
}