using ChainSafe.GamingWeb3.EVM;

namespace ChainSafe.GamingWeb3
{
  public class Web3
  {
    public IWeb3Environment Environment { get; internal set; }
    public IEvmClient? EvmClient { get; internal set; }
    
    internal Web3()
    {
      
    }
  }
}