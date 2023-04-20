using ChainSafe.GamingWeb3.EVM.JsonRPC;

namespace ChainSafe.GamingWeb3.NetCore.Tests;

public class Web3EnvironmentTests
{
  private Web3 _web3;

  [SetUp]
  public async void Setup()
  {
    _web3 = new Web3Builder()
      .Configure(services =>
      {
        services.UseNetCoreEnvironment();
        services.UseJsonRpcEvmClient(new JsonRpcClientSettings());
      })
      .Build();

    await _web3.Initialize();
  }

  [Test]
  public async Task Test1()
  {
    // var response = await _web3.Environment.HttpClient.Post("url", data);
  }
}