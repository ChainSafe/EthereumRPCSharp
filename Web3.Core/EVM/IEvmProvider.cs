using System;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Block = ChainSafe.GamingWeb3.EVM.Blocks.Block;

namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmProvider
  {
    /// <summary>
    /// Gets current user's balance
    /// </summary>
    public ValueTask<HexBigInteger> GetBalance();
    
    /// <summary>
    /// Gets balance for the provided wallet address
    /// </summary>
    public ValueTask<HexBigInteger> GetBalance(string address);

    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<HexBigInteger> GetBlockNumber();

    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<Block> GetBlock(BlockParameter blockParameter = null);
    
    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<Block> GetTransaction(string transactionHash);
  }
}