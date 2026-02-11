using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] carPrefabs;

    [Header("Spawns")]
    public Transform playerSpawn;
    public Transform[] aiSpawns;

    [Header("References")]
    public PositionSystem positionSystem;

    private void Start()
    {
        SpawnPlayer();
        SpawnAI();
    }

    public void SpawnPlayer()
    {
        var save = ServiceLocator.Get<SaveService>();

        GameObject playerCar = Instantiate(
            carPrefabs[save.Data.selectedCarIndex],
            playerSpawn.position,
            playerSpawn.rotation);

        playerCar.tag = "Player";

        positionSystem.RegisterRacer(playerCar.transform);
    }

    public void SpawnAI()
    {
        foreach (var spawn in aiSpawns)
        {
            GameObject ai = Instantiate(
                carPrefabs[0],
                spawn.position,
                spawn.rotation);

            ai.tag = "AI";

            positionSystem.RegisterRacer(ai.transform);
        }
    }
}