using Gameplay.Road;
using Gameplay.Score;
using UnityEngine;

public class ComplicationOverTime : MonoBehaviour // Это можно самым разным способом мделать, я решил. сделать самым простым, чтобы просто присутсвовано какое-то усложнение
{
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
        if (_scoreController.CurrentScore >= 10000000)
            _spawnRoad.MoveSpeed = 40;
        else if (_scoreController.CurrentScore >= 1000000)
            _spawnRoad.MoveSpeed = 35;
        else if (_scoreController.CurrentScore >= 100000)
            _spawnRoad.MoveSpeed = 30;
        else if (_scoreController.CurrentScore >= 1000)
            _spawnRoad.MoveSpeed = 25;
        else _spawnRoad.MoveSpeed = 15;
    }


}
