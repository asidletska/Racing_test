using System.Collections.Generic;
using UnityEngine;

public class GameFactory 
{
    private readonly SceneLoader _sceneLoader;

    public GameFactory(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void CreateRace(GameObject playerPrefab, GameObject aiPrefab, Transform[] spawnPoints)
    {
        List<CarMovement> cars = new List<CarMovement>();
        List<AICarLogic> AiCar = new List<AICarLogic>();

        var playerObj = Object.Instantiate(playerPrefab, spawnPoints[0].position, spawnPoints[0].rotation);
        var playerCar = playerObj.GetComponent<CarMovement>();
        cars.Add(playerCar);

        for (int i = 1; i < spawnPoints.Length; i++)
        {
            var aiObj = Object.Instantiate(aiPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            var aiCar = aiObj.GetComponent<AICarLogic>();
            AiCar.Add(aiCar);
        }

        var raceManagerObj = new GameObject("RaceManager");
        var raceManager = raceManagerObj.AddComponent<RaceManager>();

        raceManager.SpawnPlayer();
        raceManager.SpawnAI();
    }
}
