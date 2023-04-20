using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Evm;
using Nethereum.Hex.HexTypes;

namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmWallet
  {
    bool Connected { get; }
    ValueTask Connect();
    ValueTask<HexBigInteger> GetBalance();
    public ValueTask<string> SignMessage(byte[] message);
    public ValueTask<string> SignMessage(string message);
    public ValueTask<string> SignTransaction(TransactionRequest transaction);
    // todo sign and send
  }
}