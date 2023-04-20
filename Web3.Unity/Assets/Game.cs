using ChainSafe.GamingWeb3;
using ChainSafe.GamingWeb3.Build;
using ChainSafe.GamingWeb3.EVM.JsonRpc;
using ChainSafe.GamingWeb3.Unity;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
  public static Game Instance { get; private set; }

  public string AuthScene = "Auth";
  
  public Web3 Web3 { get; private set; }
  
  private async void Start()
  {
    Instance = this;
    DontDestroyOnLoad(gameObject);
    
    Web3 = new Web3Builder()
      .Configure(services =>
      {
        services.UseUnityEnvironment();
        services.UseJsonRpcProvider(new JsonRpcProviderSettings());
        services.UseJsonRpcWallet(new JsonRpcWalletSettings());
      })
      .Build();
    
    print("Web3 built");

    await Web3.Initialize();
    
    print("Web3 initialized");

    await SceneManager.LoadSceneAsync(AuthScene);
  }
}
