using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.EVM.Transactions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Block = ChainSafe.GamingWeb3.EVM.Blocks.Block;

namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmProvider
  {
    public ValueTask Connect();
    
    /// <summary>
    /// Gets current user balance
    /// </summary>
    public ValueTask<HexBigInteger> GetBalance(BlockParameter? blockTag = null);
    
    /// <summary>
    /// Gets balance for the provided wallet address
    /// </summary>
    public ValueTask<HexBigInteger> GetBalance(string address, BlockParameter? blockTag = null);

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
    public ValueTask<TransactionResponse> GetTransaction(string transactionHash);
    
    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<Network> GetNetwork(string transactionHash);
    
    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<string> Call(TransactionRequest transaction, BlockParameter blockTag = null);
    
    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<HexBigInteger> EstimateGas(TransactionRequest transaction);

    /// <summary>
    /// TODO
    /// </summary>
    public ValueTask<Transactions.TransactionReceipt> WaitForReceipt(string transactionHash,
      uint confirmations = 1,
      uint timeout = 30);
  }
}