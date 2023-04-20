using System.Threading.Tasks;

namespace ChainSafe.GamingWeb3.EVM.JsonRpc
{
  /// <summary>
  /// JSON RPC implementation of EVM Wallet
  /// </summary>
  public class JsonRpcWallet : IEvmWallet
  {
    private JsonRpcWalletSettings _settings;
    private IEvmProvider _provider;

    public JsonRpcWallet(JsonRpcWalletSettings settings, IEvmProvider provider)
    {
      _provider = provider;
      _settings = settings;
    }
    
    public bool Connected { get; private set; }
    
    public async ValueTask Connect()
    {
      // todo
      
      Connected = true;
    }
  }
}