using Gameplay.Road;
using Gameplay.Score;
using System;
using UnityEngine;

public class ComplicationOverTime : MonoBehaviour // Это можно самым разным способом мделать, я решил. сделать самым простым, чтобы просто присутсвовано какое-то усложнение
{
    public static Action<int> RoadSpeedChaged;

    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private SpawnRoad _spawnRoad;

    private void OnEnable()
    {
        ScoreController.ScoreAdd += HowManyPointsToAddOverTime;        
        ScoreController.ScoreAdd += RoadSpeedOverTime;        
    }

    private void OnDisable()
    {
        ScoreController.ScoreAdd -= HowManyPointsToAddOverTime;
        ScoreController.ScoreAdd -= RoadSpeedOverTime;
    }

    private void HowManyPointsToAddOverTime() 
    {
        if (_scoreController.CurrentScore >= 10000000)
            _scoreController.AddScoreCount = 10000;
        else if (_scoreController.CurrentScore >= 1000000)
            _scoreController.AddScoreCount = 1000;
        else if (_scoreController.CurrentScore >= 100000)
            _scoreController.AddScoreCount = 100;
        else if (_scoreController.CurrentScore >= 1000)
            _scoreController.AddScoreCount = 10;
        else _scoreController.AddScoreCount = 1;
    }

    private void RoadSpeedOverTime()
    {
        if (_scoreController.CurrentScore >= 10000)
            RoadSpeedChaged?.Invoke(25);
        else if (_scoreController.CurrentScore >= 1000)
            RoadSpeedChaged?.Invoke(20);
        else RoadSpeedChaged?.Invoke(15);
    }


}
