using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.Environment;
using ChainSafe.GamingWeb3.EVM;

namespace ChainSafe.GamingWeb3
{
  /// <summary>
  /// Facade for all Web3-related services
  /// </summary>
  public class Web3 : IDisposable
  {
    private IEvmProvider? _provider;
    private IEvmWallet? _wallet;
    private bool _initialized;
    
    public IWeb3Environment Environment { get; internal set; }

    public IEvmProvider Provider
    {
      get => AssertComponentAccessible(_provider, nameof(Provider))!;
      internal set => _provider = value;
    }

    public IEvmWallet Wallet
    {
      get => AssertComponentAccessible(_wallet, nameof(Wallet))!;
      internal set => _wallet = value;
    }

    internal Web3() { }
    public void Dispose() => Terminate();

    public async ValueTask Initialize()
    {
      if (_provider != null) await _provider.Initialize();
      
      // todo initialize other components
      
      _initialized = true;
    }

    public void Terminate()
    {
      // todo
    }

    private T AssertComponentAccessible<T>(T value, string propertyName)
    {
      if (value == null)
      {
        throw new Web3Exception(
          $"{propertyName} is not bound. Make sure to add an implementation of {propertyName} before using it.");
      }
      
      if (!_initialized)
      {
        throw new Web3Exception($"Can't access {propertyName}. Initialize Web3 first.");
      }

      return value;
    }
  }
}