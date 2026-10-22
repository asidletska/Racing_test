using Configs.Race;
using UnityEngine;

public class Bootstrappers : MonoBehaviour
{
    [Header("Config")] [SerializeField] private RaceConfig raceConfig;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        RegisterServices();
    }

    private void RegisterServices()
    {
        var save = GetComponent<SaveService>();
        if (save == null) save = gameObject.AddComponent<SaveService>();
        ServiceLocator.Register(save);

        ServiceLocator.Register(new EconomyService());
        ServiceLocator.Register(new ShopService());
        ServiceLocator.Register(new LevelProgressService());
        ServiceLocator.Register(new RaceService(raceConfig));
    }
}