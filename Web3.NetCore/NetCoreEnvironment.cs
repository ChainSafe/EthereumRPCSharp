namespace ChainSafe.GamingWeb3.NetCore;

public class NetCoreEnvironment : IWeb3Environment
{
  public IHttpClient HttpClient { get; } = new NetCoreHttpClient();
}