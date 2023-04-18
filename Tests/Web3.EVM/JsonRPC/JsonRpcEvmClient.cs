﻿namespace ChainSafe.GamingWeb3.EVM.JsonRPC
{
  public class JsonRpcEvmClient : IEvmClient
  {
    public IEvmProvider Provider { get; }
    public IEvmSigner Signer { get; }

    public JsonRpcEvmClient(JsonRpcProvider provider, JsonRpcSigner signer)
    {
      Provider = provider;
      Signer = signer;
    }
  }
}