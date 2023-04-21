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
    private ChainProvider _chainProvider;

    public JsonRpcProvider(JsonRpcProviderSettings settings, IWeb3Environment environment, ChainProvider chainProvider)
    {
      _chainProvider = chainProvider;
      _environment = environment;
      _settings = settings;
    }
    
    public async ValueTask Initialize()
    {
      // _network = await RequestNetwork();
    }

    public async ValueTask<HexBigInteger> GetBalance(string address, BlockParameter? blockTag = null)
    {
      // todo logging?
      
      blockTag ??= new BlockParameter();
      var balanceString = await ExecuteRpc<string>("eth_getBalance", address, blockTag);
      var balance = new HexBigInteger(balanceString);
      return balance;
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
        throw new Web3Exception(errorMessage);
      }

      var serializer = JsonSerializer.Create();
      return serializer.Deserialize<TResponse>(new JTokenReader(response.Result))!;
    }

    private async ValueTask<Network> RequestNetwork()
    {
      var chainIdHexString = await ExecuteRpc<string>("eth_chainId");
      var chainId = new HexBigInteger(chainIdHexString).ToUlong();

      if (chainId <= 0)
      {
        throw new Web3Exception("Couldn't detect network");
      }

      var chain = await _chainProvider.GetChain(chainId);

      if (chain == null)
      {
        return new Network
        {
          Name = "Unknown",
          ChainId = chainId
        };
      }

      return new Network
      {
        Name = chain.Name,
        ChainId = chainId
      };
    }
  }
}