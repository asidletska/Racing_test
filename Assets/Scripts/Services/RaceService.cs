using System;
using System.Collections.Generic;
using Configs.Race;
using UnityEngine;

public class RaceService
{
    private readonly RaceConfig _config;
    private readonly HashSet<Transform> _finished = new();

    public event Action<int, int> OnPlayerFinished;

    public RaceService(RaceConfig config)
    {
        _config = config;
    }

    public int TotalLaps => _config != null ? _config.totalLaps : 3;

    public void OnFinishPassed(OrderInRacing racer, PositionSystem positionSystem)
    {
        if (racer == null) return;

        racer.LapTriggerPassed();
        if (racer.currentLap < TotalLaps) return;

        if (_finished.Contains(racer.transform)) return;
        _finished.Add(racer.transform);

        if (!racer.CompareTag("Player"))
            return;

        int place = positionSystem != null ? positionSystem.GetPosition(racer.transform) : 1;

        int reward =
            place == 1 ? (_config != null ? _config.firstPlaceReward : 0) :
            place == 2 ? (_config != null ? _config.secondPlaceReward : 0) :
            place == 3 ? (_config != null ? _config.thirdPlaceReward : 0) :
            0;

        if (reward > 0)
            ServiceLocator.Get<EconomyService>().AddCoins(reward);

        OnPlayerFinished?.Invoke(place, reward);
    }
}