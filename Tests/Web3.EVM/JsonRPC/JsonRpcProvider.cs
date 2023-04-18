namespace ChainSafe.GamingWeb3.EVM.JsonRPC
{
  /// <summary>
  /// JSON RPC implementation of EVM Provider
  /// </summary>
  public class JsonRpcProvider : IEvmProvider
  {
    private JsonRpcClientSettings _settings;

    public JsonRpcProvider(JsonRpcClientSettings settings)
    {
      _settings = settings;
    }
    
    // todo
  }
}