using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Environment;
using ChainSafe.GamingWeb3.Evm;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client.RpcMessages;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Block = ChainSafe.GamingWeb3.Evm.Block;
using TransactionReceipt = ChainSafe.GamingWeb3.Evm.TransactionReceipt;

namespace ChainSafe.GamingWeb3.EVM.JsonRpc
{
  /// <summary>
  /// JSON RPC implementation of EVM Provider
  /// </summary>
  public class JsonRpcProvider : IEvmProvider
  {
    private readonly JsonRpcProviderSettings _settings;
    private readonly IWeb3Environment _environment;
    private uint _nextMessageId;
    private Network _network;

    public JsonRpcProvider(JsonRpcProviderSettings settings, IWeb3Environment environment)
    {
      _environment = environment;
      _settings = settings;
    }
    
    public async ValueTask Initialize()
    {
      var chainIdHexString = await ExecuteRpc<string>("eth_chainId");
      var chainId = new HexBigInteger(chainIdHexString).ToUlong();

      if (chainId == 0)
      {
        throw new Web3Exception("Couldn't detect network");
      }

      throw new NotImplementedException();
    }

    public ValueTask<HexBigInteger> GetBalance(BlockParameter? blockTag = null)
    {
      throw new System.NotImplementedException();
    }

    public async ValueTask<HexBigInteger> GetBalance(string address, BlockParameter? blockTag = null)
    {
      // todo network should be ready at this moment
      
      blockTag ??= new BlockParameter();
      var balanceString = await ExecuteRpc<string>("eth_getBalance", address, blockTag);
      var balance = new HexBigInteger(balanceString);
      
      throw new NotImplementedException();
    }

    public ValueTask<HexBigInteger> GetBlockNumber()
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<Block> GetBlock(BlockParameter blockParameter = null)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<TransactionResponse> GetTransaction(string transactionHash)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<Network> GetNetwork(string transactionHash)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<string> Call(TransactionRequest transaction, BlockParameter blockTag = null)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<HexBigInteger> EstimateGas(TransactionRequest transaction)
    {
      throw new System.NotImplementedException();
    }

    public ValueTask<TransactionReceipt> WaitForReceipt(string transactionHash, uint confirmations = 1, uint timeout = 30)
    {
      throw new System.NotImplementedException();
    }

    private async ValueTask<TResponse> ExecuteRpc<TResponse>(string method, params object[] parameters)
    {
      var httpClient = _environment.HttpClient;
      var request = new RpcRequestMessage(_nextMessageId++, method, parameters);
      var response = await httpClient.Post<RpcRequestMessage, RpcResponseMessage>(_settings.RpcNodeUrl, request);
      
      if (response.HasError)
      {
        var error = response.Error;
        var errorMessage = $"RPC returned error for \"{method}\": {error.Code} {error.Message} {error.Data}";
        throw new Web3Exception( errorMessage);
      }

      var serializer = JsonSerializer.Create();
      return serializer.Deserialize<TResponse>(new JTokenReader(response.Result))!;
    }
  }
}