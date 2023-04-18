namespace ChainSafe.GamingWeb3.EVM.JsonRPC
{
  /// <summary>
  /// JSON RPC implementation of EVM Client for Web3
  /// </summary>
  public class JsonRpcEvmClient : IEvmClient
  {
    public IEvmProvider Provider { get; }
    public IEvmSigner Signer { get; }

    public JsonRpcEvmClient(JsonRpcProvider provider, JsonRpcSigner signer)
    {
      Provider = provider;
      Signer = signer;
    }
  }
}