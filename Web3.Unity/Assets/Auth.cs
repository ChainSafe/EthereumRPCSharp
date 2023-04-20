using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
  public class Auth : MonoBehaviour
  {
    public string ActualGameScene = "ActualGame";
    
    public async void ConnectWallet()
    {
      await Game.Instance.Web3.Wallet.Connect();
    
      print("Wallet connected");
      
      await SceneManager.LoadSceneAsync(ActualGameScene);
    }
  }
}