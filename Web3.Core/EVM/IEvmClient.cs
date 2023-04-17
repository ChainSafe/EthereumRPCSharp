namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmClient
  {
    IEvmProvider Provider { get; }
    IEvmSigner Signer { get; }
  }
}