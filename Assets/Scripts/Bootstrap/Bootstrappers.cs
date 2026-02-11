using Services;
using UnityEngine;

public class Bootstrappers : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Register(new SaveLoadService());
        //ServiceLocator.Register(new GameFactory());
        ServiceLocator.Register(new RaceService());
    }
}
