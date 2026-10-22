using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform playerSpawn;
    public Transform[] aiSpawns;
    [SerializeField] private Transform playerCarHolder;
    [SerializeField] private Transform[] opponentCarHolders;
    [SerializeField] private Transform opponentsRoot;
    public PositionSystem positionSystem;

    private void Start()
    {
        SpawnPlayer();
        SpawnAI();
    }

    public void SpawnPlayer()
    {
        var save = ServiceLocator.Get<SaveService>();

        int index = save.Data.selectedCarIndex;
        if (!save.Data.unlockedCars.Contains(index))
            index = 0;

        if (playerCarHolder != null)
            ClearChildren(playerCarHolder);

        var parent = playerCarHolder != null ? playerCarHolder : null;

        GameObject playerCar = Instantiate(
            carPrefabs[index],
            playerSpawn.position,
            playerSpawn.rotation,
            parent
        );

        playerCar.tag = "Player";
        positionSystem.RegisterRacer(playerCar.transform);
    }

    public void SpawnAI()
    {
        if (aiSpawns == null || aiSpawns.Length == 0) return;

        if (opponentCarHolders != null && opponentCarHolders.Length > 0)
        {
            int count = Mathf.Min(aiSpawns.Length, opponentCarHolders.Length);

            for (int i = 0; i < count; i++)
            {
                var holder = opponentCarHolders[i];
                var spawn = aiSpawns[i];

                if (holder != null)
                    ClearChildren(holder);

                int carIndex = GetRandomAICarIndex();

                GameObject ai = Instantiate(
                    carPrefabs[carIndex],
                    spawn.position,
                    spawn.rotation,
                    holder
                );

                ai.tag = "AI";
                positionSystem.RegisterRacer(ai.transform);
            }

            return;
        }

        if (opponentsRoot != null)
            ClearChildren(opponentsRoot);

        foreach (var spawn in aiSpawns)
        {
            int carIndex = GetRandomAICarIndex();

            GameObject ai = Instantiate(
                carPrefabs[carIndex],
                spawn.position,
                spawn.rotation,
                opponentsRoot
            );

            ai.tag = "AI";
            positionSystem.RegisterRacer(ai.transform);
        }
    }

    private int GetRandomAICarIndex()
    {
        if (carPrefabs == null || carPrefabs.Length == 0) return 0;
        return Random.Range(0, carPrefabs.Length);
    }

    private void ClearChildren(Transform root)
    {
        if (root == null) return;

        for (int i = root.childCount - 1; i >= 0; i--)
            Destroy(root.GetChild(i).gameObject);
    }
}