using System.Threading.Tasks;

namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmWallet
  {
    bool Connected { get; }
    ValueTask Connect();
    
    // todo sign and send
  }
}