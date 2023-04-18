namespace ChainSafe.GamingWeb3.EVM.JsonRPC
{
  /// <summary>
  /// JSON RPC implementation of EVM Signer
  /// </summary>
  public class JsonRpcSigner : IEvmSigner
  {
    private JsonRpcClientSettings _settings;

    public JsonRpcSigner(JsonRpcClientSettings settings)
    {
      _settings = settings;
    }
    
    // todo
  }
}