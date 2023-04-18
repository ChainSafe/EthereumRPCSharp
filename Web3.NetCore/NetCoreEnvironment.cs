namespace ChainSafe.GamingWeb3.NetCore;

/// <summary>
/// .NET Core version of Web3 Environment
/// </summary>
public class NetCoreEnvironment : IWeb3Environment
{
  public IHttpClient HttpClient { get; } = new NetCoreHttpClient();
}