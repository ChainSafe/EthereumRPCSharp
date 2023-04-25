using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Evm;
using Nethereum.Hex.HexTypes;

namespace ChainSafe.GamingWeb3.EVM.JsonRpc
{
  /// <summary>
  /// JSON RPC implementation of EVM Wallet
  /// </summary>
  public class JsonRpcWallet : IEvmWallet
  {
    private JsonRpcWalletConfiguration _configuration;
    private IEvmProvider _provider;

    public JsonRpcWallet(JsonRpcWalletConfiguration configuration, IEvmProvider provider)
    {
      _provider = provider;
      _configuration = configuration;
    }
    
    public bool Connected { get; private set; }
    
    public async ValueTask Connect()
    {
      // todo
      
      Connected = true;
    }

    public ValueTask<HexBigInteger> GetBalance()
    {
      AssertConnected();
      throw new System.NotImplementedException();
    }

    public ValueTask<string> SignMessage(byte[] message)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<string> SignMessage(string message)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<string> SignTransaction(TransactionRequest transaction)
    {
      throw new System.NotImplementedException();
    }

    private void AssertConnected()
    {
      if (Connected) return;

      throw new Web3Exception("Wallet is not connected yet");
    }
  }
}