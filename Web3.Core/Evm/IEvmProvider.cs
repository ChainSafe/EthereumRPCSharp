using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Evm;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Block = ChainSafe.GamingWeb3.Evm.Block;
using TransactionReceipt = ChainSafe.GamingWeb3.Evm.TransactionReceipt;

namespace ChainSafe.GamingWeb3.EVM
{
  public interface IEvmProvider
  {
    public ValueTask Initialize();
    
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
    public ValueTask<TransactionReceipt> WaitForReceipt(string transactionHash,
      uint confirmations = 1,
      uint timeout = 30);
  }
}