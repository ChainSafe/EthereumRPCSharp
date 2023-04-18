using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.EVM;

namespace ChainSafe.GamingWeb3
{
  public class Web3 : IDisposable
  {
    public IWeb3Environment Environment { get; internal set; }
    public IEvmClient? EvmClient { get; internal set; }
    
    internal Web3()
    {
      
    }

    public async ValueTask Initialize()
    {
      return;
    }

    public void Terminate()
    {
      
    }

    public void Dispose()
    {
      Terminate();
    }
  }
}