using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneLoader 
{
    public async Task LoadScene(string sceneAddress)
       {
           AsyncOperationHandle handle = Addressables.LoadSceneAsync(sceneAddress);
           await handle.Task;
   
           if (handle.Status != AsyncOperationStatus.Succeeded)
           {
               Debug.LogError($"Failed to load scene: {sceneAddress}");
           }
       }
       
}
